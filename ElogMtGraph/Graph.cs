using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;
using System.Collections;
using System.IO;
using System.Collections.Generic;

namespace ElogMtGraph
{
	public static class Graph
	{
		private static ZedGraphControl myZedGraphCtrl;
		private static MasterPane myMaster;

		private static GraphPane[] myPane;

		// グラフ描画用　タイムスタンプ
		private static DateTime[] timestamp;
		// グラフ描画用　観測値
		private static int[,] data;
		// グラフ描画用　データ個数
		private static UInt32 data_length = 0;

		// 読み込んだデータのディレクトリ名
		private static string dataFileDirName = "";
		// データ読み込み用　タイムスタンプ
		private static DateTime[] readTimestamp;
		// データ読み込み用　観測値
		private static int[,] readData;
		// データ読み込み用　データ個数
		private static UInt32 readData_length = 0;

		//		private static double range_h_save = -1;
		//		private static double range_y_save = -1;

		private const double VOLT_MAX_E = 2.5;
		private const double VOLT_MIN_E = -2.5;
		private const double VOLT_MAX_H = 10.0;
		private const double VOLT_MIN_H = -10.0;

		// Volt/LSB 
		private const double VOLT_LSB_E = 2.5 / 8388608;
		private const double VOLT_LSB_H = 10.0 / 8388608;

		// 1=ファイルが読み込まれていない
		private static int firsttime;
		// 入力file path
		private static string input_dir;
        // true=Graph描画中
        private static bool mutex = false;

        private static string[] graphCaption = { "CH1(EX)","CH2(EY)", "CH3(HX)", "CH4(HY)", "CH5(HZ)" };

		// コンストラクタ
		//
		static Graph()
		{
			try
			{
				/* プロットするデータ用メモリ確保
				 * 間引きをするので、画面横幅*10程度あれば良い
				 */
//				timestamp = new DateTime[2560*10*24];
//				data = new int[2560*10*24, Constants.CHNUM];
                // 間引きを無くしたので15Hzデータ1日分のメモリを確保する
                timestamp = new DateTime[86400*Constants.SAMP_FREQ+1024];
                data = new int[86400*Constants.SAMP_FREQ+1024, Constants.CHNUM];
				readTimestamp = new DateTime[86400 * Constants.SAMP_FREQ + 1024];
				readData = new int[86400 * Constants.SAMP_FREQ + 1024, Constants.CHNUM];

				firsttime = 1;
//				input_dir = "";
			}
			catch(Exception e)
			{
				Console.Write("Graph(): "+e.Message+"\n");
				Console.Write(e.StackTrace.ToString()+"\n");
				Debug.ShowStackTrace();
				return;
			}

		}
		// ウィンドウ絡みの初期設定
		public static void Init()
		{
			try
			{
				myZedGraphCtrl = new ZedGraphControl();
				myMaster = myZedGraphCtrl.MasterPane;
	
				// tabにZedGraphControl配置
				Program.FormMain.SetZedGraph(ref myZedGraphCtrl);
				
				// グラフPaneの生成しておく
				MakePane();

				// デフォルトで用紙を横向きに
				myZedGraphCtrl.PrintDocument.DefaultPageSettings.Landscape = true;
			}
			catch(Exception e)
			{
				Console.Write("Graph.Init(): "+e.Message+"\n");
				Console.Write(e.StackTrace.ToString()+"\n");
				Debug.ShowStackTrace();
				return;
			}

		}

		//
		// TsからTeを含むデータを切り取るためのインデックスを探す関数
		//
        private static (int, int) searchTsTe(DateTime[] dateTimes, int len, DateTime ts, DateTime te)
        {
			int tsindex = Array.BinarySearch(dateTimes, 0, len, ts);
			if (tsindex < 0) tsindex = ~tsindex;

			int teindex = Array.BinarySearch(dateTimes, tsindex, len - tsindex, te);
			if (teindex < 0) teindex = ~teindex - 1;

			return (tsindex, teindex);
		}

		//
		// データとtimestampを描画範囲に応じて切り取る
		//
		private static void DataCrop(DateTime ts, DateTime te)
        {
			int tsindex;
			int teindex;
			(tsindex, teindex) = searchTsTe(timestamp, (int)data_length, ts, te);

			data_length = (uint)(teindex - tsindex) + 1;
			for(int i=0; i < data_length; ++i)
            {
				for(int ch = 0; ch < Constants.CHNUM; ++ch)
                {
					data[i, ch] = data[i + tsindex, ch];
				}
				timestamp[i] = timestamp[i + tsindex];
            }
		}

		// グラフ描画する
		// データ読み込み済みである必要有り
		//
		// double range_t: 時間軸レンジ　Hour 
		// double range_y: Y軸レンジ　Volt/FS 中心値±range_y/2の範囲になる
        public static void DrawGraph()
		{
            int range_t = Program.FormMain.GetComboPeriod();
            double range_hy = Program.FormMain.GetComboHY();
            double range_ey = Program.FormMain.GetComboEY();

			try
			{
				if (timestamp == null) return;
				if (range_t <= 0) return;
				if (range_hy <= 0 && range_hy != -1.0) return;
				if (range_ey <= 0 && range_ey != -1.0) return;
				if (data_length < 0) return;
				// 描画中ならばreturn
				if (mutex) return;
				mutex = true;

				Program.FormMain.StatusLabel_SetText("グラフ描画中");
				// スクロールバーEnable/Disable　Disableにするとバーをドラッグ出来なくなる
				//				Program.FormMain.TimeScrollBarDisable();
				// カーソルwait
				Cursor.Current = Cursors.WaitCursor;
				// スクロールバー設定
				Program.FormMain.TimeScrollBarSetMinMax(0, 24 * 60 * 60, (int)range_t / 5, range_t);
				Program.FormMain.Refresh();

				Graph.RefreshData();
				if (Program.FormMain.IsAverageFilterEnable()) Graph.AverageFilter(Program.FormMain.GetDataModeFreq());

				//
				// 時間軸レンジ計算
				//
				DateTime ts = new DateTime();
				DateTime te = new DateTime();

				//　グラフの描画範囲(時間)を計算
				{
					// スクロールバーの値get　単位:秒
					int start = Program.FormMain.TimeScrollBarGetValue();
					// start
					int h, m, s;
					h = start / 60 / 60; h %= 24;
					m = start % 3600 / 60;
					s = (int)Math.Round((double)(start % 60) / 30.0) * 30;
					if (s >= 60)
					{
						m += 1;
						if (m >= 60)
						{
							m -= 60;
							h += 1;
						}
						s -= 60;
					}
					ts = new DateTime(timestamp[0].Year, timestamp[0].Month, timestamp[0].Day, h, m, s);
					// end
					h = range_t / 60 / 60;
					m = range_t % 3600 / 60;
					s = range_t % 60;

					//                    Console.WriteLine("DrawGraph() h={0}, m={1}, range_t={2}", h, m, range_t);
					TimeSpan interval = new TimeSpan(h, m, s);
					te = ts + interval;

					DateTime nextDay0000 = new DateTime(timestamp[0].Year, timestamp[0].Month, timestamp[0].Day, 0, 0, 0) + new TimeSpan(1, 0, 0, 0);
					if (te > nextDay0000)
					{
						TimeSpan over = te - nextDay0000;
						ts -= over;
						te = nextDay0000;
					}
					//                    Console.WriteLine("DrawGraph() ts={0}, te={1}, interval={2}", ts, te, interval);
				}

				//int tsindex;
				//int teindex;
				//(tsindex, teindex) = searchTsTe(timestamp, (int)data_length, ts, te);
				DataCrop(ts, te);

				if (Program.FormMain.IsDetrendEnable()) Graph.Detrend();

				/*
				 * グラフ描画
				 */
				Dictionary<int, double> autoRanges = new Dictionary<int, double>();
				// CHループ
				for (int ch = 0; ch < Constants.CHNUM; ch++)
				{
					// AD bits
					// 変換係数get Volt/LSB
					double coef = VOLT_LSB_E;
					double volt_max = VOLT_MAX_E;
					double volt_min = VOLT_MIN_E;

					double range_y = range_ey;

					if (ch >= 2)
					{
						coef = VOLT_LSB_H;
						volt_max = VOLT_MAX_H;
						volt_min = VOLT_MIN_H;
						range_y = range_hy;
					}


					Console.WriteLine("DrawGraph() CH={0} start, data_elngth={1}", ch, data_length);
					GraphPane myp;
					myp = myPane[ch];
					// 
					// 時間軸レンジ設定
					myp.XAxis.Scale.Min = new XDate(ts.Year, ts.Month, ts.Day, ts.Hour, ts.Minute, ts.Second);
					myp.XAxis.Scale.Max = new XDate(te.Year, te.Month, te.Day, te.Hour, te.Minute, te.Second);
					// Console.WriteLine("XAxis.Scale.Min={0}", myp.XAxis.Scale.Min);
					// Console.WriteLine("XAxis.Scale.Max={0}", myp.XAxis.Scale.Max);
					// 時間軸目盛り
					if (range_t < 2 * 3600)
					{
						myp.XAxis.Scale.Format = "HH:mm:ss";    // HH=24時間制
					}
					else
					{
						myp.XAxis.Scale.Format = "HH:mm";   // HH=24時間制
					}
					//
					PointPairList list = new PointPairList();
					// データ数zeroの時はグラフクリアするのみ
					if (data_length > 0)
					{
						// データをグラフ用に抜き出すループ
						double yavg = 0;
						double yMax = double.MinValue;
						double yMin = double.MaxValue;
						int avg_num = 0;
						list.Clear();

						int WindowWidth = Program.FormMain.getScreenWidth();
						int mabikiLen = WindowWidth * 3; // 高速化のための間引き後の点数の半分

						// mabikiLen * 2 < data_lengthならば(間引きをして点数が減るならば)間引きをして描画
						// そうでないなら間引きをしないで描画
						if (!(mabikiLen * 2 < data_length))
						{
							for (int i = 0; i < data_length; ++i)
							{

								double x = (double)new XDate(timestamp[i].Year, timestamp[i].Month, timestamp[i].Day,
																	timestamp[i].Hour, timestamp[i].Minute, timestamp[i].Second, timestamp[i].Millisecond);
								double y = (double)data[i, ch] * coef;
								list.Add(x, y);
								yavg += y;
								avg_num++;

								yMax = Math.Max(yMax, y);
								yMin = Math.Min(yMin, y);
							}
						}
						else
						{
							//double mabikiYmin, mabikiYmax;
							//double mabikiXmin, mabikiXmax; 

							//(mabikiYmin, mabikiYmax) = (double.MaxValue, double.MinValue);

							double x;
							double y;

							for (int i = 0; i < mabikiLen; ++i)
							{
								int start = (int)((long)data_length * i / mabikiLen);
								int end = (int)((long)data_length * (i + 1) / mabikiLen - 1);

								int min = int.MaxValue;
								int max = int.MinValue;
								int minindex = 0;
								int maxindex = 0;
								for (int j = start; j <= end; ++j)
								{
									if (min > data[j, ch])
									{
										min = data[j, ch];
										minindex = j;
									}
									if (max < data[j, ch])
									{
										max = data[j, ch];
										maxindex = j;
									}

									y = (double)data[j, ch] * coef;
									yavg += y;
									avg_num++;

									yMax = Math.Max(yMax, y);
									yMin = Math.Min(yMin, y);
								}
								//var mindata = new PointPair(list[minindex]);
								//var maxdata = new PointPair(list[maxindex]);
								if (minindex < maxindex)
								{
									x = (double)new XDate(timestamp[minindex].Year, timestamp[minindex].Month, timestamp[minindex].Day,
																	timestamp[minindex].Hour, timestamp[minindex].Minute, timestamp[minindex].Second, timestamp[minindex].Millisecond);
									y = (double)data[minindex, ch] * coef;
									list.Add(x, y);

									x = (double)new XDate(timestamp[maxindex].Year, timestamp[maxindex].Month, timestamp[maxindex].Day,
																	timestamp[maxindex].Hour, timestamp[maxindex].Minute, timestamp[maxindex].Second, timestamp[maxindex].Millisecond);
									y = (double)data[maxindex, ch] * coef;
									list.Add(x, y);
								}
								else
								{
									x = (double)new XDate(timestamp[maxindex].Year, timestamp[maxindex].Month, timestamp[maxindex].Day,
																	timestamp[maxindex].Hour, timestamp[maxindex].Minute, timestamp[maxindex].Second, timestamp[maxindex].Millisecond);
									y = (double)data[maxindex, ch] * coef;
									list.Add(x, y);

									x = (double)new XDate(timestamp[minindex].Year, timestamp[minindex].Month, timestamp[minindex].Day,
																	timestamp[minindex].Hour, timestamp[minindex].Minute, timestamp[minindex].Second, timestamp[minindex].Millisecond);
									y = (double)data[minindex, ch] * coef;
									list.Add(x, y);
								}
							}
						}

						// オートスケールのときの処理
						if (range_y == -1.0)
						{
							double rangemin = yMin == double.MaxValue ? -20.0 : yMin;
							double rangemax = yMax == double.MinValue ? 20.0 : yMax;
							double range = rangemax - rangemin;
							if (range < 0.0001) range = 0.0001;
							rangemin = rangemin - range * 0.05;
							rangemax = rangemax + range * 0.05;

							myp.YAxis.Scale.Min = rangemin;
							myp.YAxis.Scale.Max = rangemax;
							Console.WriteLine("autorange {0}: {1}", ch, range);
							autoRanges.Add(ch, range);
						}
						// オートスケールではないときの処理
						else
						{
							// Y軸中心値計算
							if (avg_num <= 0) avg_num = 1;
							double ycenter = yavg / avg_num;
							// Y軸レンジ設定
							double min = ycenter - range_y / 2;
							double max = ycenter + range_y / 2;
							if (min < volt_min)
							{
								min = volt_min;
								max = min + range_y;
							}
							if (max > volt_max)
							{
								max = volt_max;
								min = max - range_y;
							}
							myp.YAxis.Scale.Min = min;
							myp.YAxis.Scale.Max = max;
						}

					} // if (data_length > 0)
					  // プロットする
					myp.CurveList.Clear();
					myp.AddCurve("", list, Color.Red, SymbolType.None);
					// グラフタイトル・サイズ
					//					myp.Title.Text = graphCaption[ch] + "\n" + Path.GetFileName(input_dir);
					//					Program.FormMain.dataText = Path.GetFileName(input_dir);
					myp.Title.FontSpec.Size = (int)(14 * 1000 * 2.0 / (Program.FormMain.Size.Height));
					myp.Title.IsVisible = false;
					myp.XAxis.Title.FontSpec.Size = (int)(14 * 1000 * 2.0 / Program.FormMain.Size.Height);
					myp.XAxis.Title.IsVisible = false;
					myp.XAxis.Scale.FontSpec.Size = (int)(14 * 1000 * 2.0 / Program.FormMain.Size.Height);
					//					myp.XAxis.IsVisible = false;
					//					myp.YAxis.Title.Text = graphCaption[ch] + "\n" + Path.GetFileName(input_dir)+"\n\nVolt";
					myp.YAxis.Title.Text = graphCaption[ch] + "\n" + "Volt";
					myp.YAxis.Title.FontSpec.Size = (int)(14 * 1000 * 2.0 / Program.FormMain.Size.Height);
					myp.YAxis.Scale.FontSpec.Size = (int)(14 * 1000 * 2.0 / Program.FormMain.Size.Height);
					myp.YAxis.MinSpace = 300;

					// myp.Title.Text = "CH"+ (ch+1).ToString() + "\n" + Path.GetFileName(input_dir);
					Console.WriteLine("DrawGraph() CH={0} end", ch);
				} // CHループ
				string label = dataFileDirName + " ";
				if (autoRanges.Count > 0)
				{
					label += "Range ";
					string[] s = { "EX", "EY", "HX", "HY", "HZ" };
					foreach (var entry in autoRanges)
					{
						label += s[entry.Key] + " " + UnitUtils.NumberToVoltRep(entry.Value) + " ";
					}

				}
				Program.FormMain.SetYRangeValueLabel(label);

				using (Graphics g = myZedGraphCtrl.CreateGraphics())
				{
					myMaster.AxisChange(g);
				}

			}
			catch (Exception e)
			{
				Console.Write("DrawGraph(): " + e.Message + "\n");
				Console.Write(e.StackTrace.ToString() + "\n");
				Debug.ShowStackTrace();
				return;
			}
			finally
			{
				Console.WriteLine("DrawGraph().finally()");
				// スクロールバーEnable
				Program.FormMain.TimeScrollBarEnable();
				// カーソル戻す
				Cursor.Current = Cursors.Default;
				Program.FormMain.Refresh();
				mutex = false;
				Program.FormMain.StatusLabel_SetText("");
			}		
		}

		/*
		 * データのトレンドを除去する
		 * 
		 */
		public static void Detrend()
        {
			for(int ch = 0; ch < Constants.CHNUM; ++ch)
            {
				double S_xy = 0.0;
				double S_xx = 0.0;
				double Ave_X = 0.0;
				double Ave_Y = 0.0;

				for (int i = 0; i < data_length; ++i)
                {
					Ave_Y += data[i, ch];
					Ave_X += i;
				}
				Ave_X /= data_length;
				Ave_Y /= data_length;

				for (int i = 0; i < data_length; ++i)
				{
					S_xy += (data[i, ch] - Ave_Y) * (i - Ave_X);
					S_xx += (i - Ave_X) * (i - Ave_X);
				}

				double a = S_xy / S_xx; // 回帰直線がy=ax+bのときの傾きa
				// double b = Ave_Y - a * Ave_X; // 回帰直線がy=ax+bのときの切片b

				for (int i = 0; i < data_length; ++i)
				{
					data[i, ch] = (int)(data[i, ch] - a * i);
				}
			}
        }

		/*
		 * 読み込んだデータをそのままグラフ描画用の配列にコピーする
		 * 
		 */
		public static void RefreshData()
        {
			Array.Copy(readData, data, readData.Length);
			Array.Copy(readTimestamp, timestamp, readTimestamp.Length);
			data_length = readData_length;
		}

		/*
		 * xxHzのデータを1Hzに平均化する
		 * arg:filter_length 平均化するデータの個数
		 */
		public static void AverageFilter(int filter_length)
        {
			for (int ch = 0; ch < Constants.CHNUM; ++ch)
			{
				int sum = 0;
				for (int i = 0; i < data_length; ++i)
                {
					sum += data[i, ch];
					if(i % filter_length == filter_length - 1)
                    {
						data[i / filter_length, ch] = sum / filter_length;
						sum = 0;
                    }
                }
			}

			DateTime baseTime = new DateTime();
			TimeSpan timeSpan = new TimeSpan();
			for (int i = 0; i < data_length; ++i)
			{
				if(i % filter_length == 0)
                {
					baseTime = timestamp[i];
					timeSpan = new TimeSpan();
				}
                else
                {
					timeSpan += timestamp[i] - baseTime;
					if (i % filter_length == filter_length - 1)
					{
						timestamp[i / filter_length] = baseTime + new TimeSpan(timeSpan.Ticks / filter_length);
					}
				}
			}

			data_length = (uint)(data_length / filter_length);
		}



		/*
         * ディレクトリから1日分のファイル読み込んでグラフ描画する
		 * 一番最初のグラフ描画、横スクロールしたとき、ウィンドウサイズ変わったとき
         */
		public static bool ReadAndDraw(String input_dir0, bool first = false, bool interactive = true)
		{
			input_dir = input_dir0;
			// dir存在チェック
		    if (!System.IO.Directory.Exists(input_dir)) {
				if (interactive)
				{
					MessageBox.Show(Program.FormMain.rm.GetString("_Error_No_Directory") + "\n" + input_dir, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				Program.FormMain.SetYRangeValueLabel("");
                dataFileDirName = "";
				return false;
    		}
            // Graph Clear
            for (int ch = 0; ch < Constants.CHNUM; ch++)
            {
                myPane[ch].CurveList.Clear();
            }
            Program.FormMain.SetDescriptionBoxText(input_dir);
			// ディレクトリからファイル一覧をget
			Console.WriteLine ("dir={0}", input_dir);
			DirectoryInfo dir = new DirectoryInfo(input_dir);
			FileInfo[] file_list = dir.GetFiles();
			dataFileDirName = dir.Name;

			readData_length = 0;
			if(Program.FormMain.GetDataModeFreq() == 15) {
				int fileCount = 0;
				foreach (FileInfo f in file_list) {
					if (f != null) {
						if (f.Name.IndexOf("_15Hz") >= 0) {
							Console.WriteLine("{0}", f.Name);
							if (ReadFile(f.FullName, ref readData_length) < 0) {
								// 読み込みエラー
								if (interactive)
								{
                                    MessageBox.Show(Program.FormMain.rm.GetString("_Error_Readng_File") + "\n" + f.FullName, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                Program.FormMain.SetYRangeValueLabel("");
                                dataFileDirName = "";
                                return false;
							}
                            else
                            {
								fileCount++;
                            }
						}
					}
				}
                if (fileCount == 0)
                {
					if (interactive)
					{
                        MessageBox.Show(Program.FormMain.rm.GetString("_Error_no_15Hz_data"), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return false;
				}
			}
			if(Program.FormMain.GetDataModeFreq() == 32) {
				int fileCount = 0;
				foreach (FileInfo f in file_list) {
					if (f != null) {
						if (f.Name.IndexOf("_32Hz") >= 0) {
							Console.WriteLine("{0}", f.Name);
							if (ReadFile(f.FullName, ref readData_length) < 0) {
								// 読み込みエラー
								if (interactive)
								{
									MessageBox.Show(Program.FormMain.rm.GetString("_Error_Readng_File") + "\n" + f.FullName, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
								}
								return false;
							}
                            else
                            {
								fileCount++;
                            }
						}
					}
				}
                if (fileCount == 0)
                {
					if (interactive)
					{
						MessageBox.Show(Program.FormMain.rm.GetString("_Error_no_32Hz_data"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					return false;
				}
			}

			RefreshData();

            if (first && readData_length > 0)
            {
//				Program.FormMain.SetComboPeriod(Constants.comboPeriod_InitialList[0]);
				//double span = (readTimestamp[readData_length-1] - readTimestamp[0]).TotalHours;
				int Datastart = 
					(int)(readTimestamp[0] - new DateTime(readTimestamp[0].Year, readTimestamp[0].Month, readTimestamp[0].Day, 0, 0, 0)).TotalSeconds;
				int Dataend =
					(int)(readTimestamp[readData_length - 1] - new DateTime(readTimestamp[0].Year, readTimestamp[0].Month, readTimestamp[0].Day, 0, 0, 0)).TotalSeconds;

				for (int i=0; i< Constants.comboPeriod_InitialList.Length; ++i)
                {
					// 表示範囲の最初
					var start = ((uint)(Datastart / Constants.comboPeriod_InitialList[i] * 3600)) * Constants.comboPeriod_InitialList[i] * 3600;
					// 表示範囲の終わり
					var end = start + Constants.comboPeriod_InitialList[i] * 3600;

                    if (Dataend <= end)
                    {
						Program.FormMain.SetComboPeriod(Constants.comboPeriod_InitialList[i]);
						Program.FormMain.TimeScrollBarSetValue((int)start);
						break;
                    }
				}
            }

			// Graph描画
			DrawGraph();

			return true;
		}

		
		/*
		 * ファイル読み込み　間引きあり
		 * file_path 読み込むファイルのパス
		 * cnt 読み込んだ結果としての全体のデータ数 間引き後
		 * return: 0=OK -1=ERROR
		 */
		private static int ReadFile(string file_path, ref UInt32 cnt)
		{
			try {
// TODO: ファイル名から年月日を得たい
				// カーソルwait
//				Program.FormMain.Cursor = Cursors.WaitCursor;
				Cursor.Current = Cursors.WaitCursor;
				Program.FormMain.Refresh();
				// 一番最初のデータ読み込みならば、
				if (firsttime == 1) {
					// スクロールバー位置をゼロに
					Program.FormMain.TimeScrollBarSetValue(0);
	
					firsttime = 0;
				}
				//
				// 時間軸レンジ計算
				//
				DateTime ts = new DateTime();
				DateTime te = new DateTime();
				int range_t = Program.FormMain.GetComboPeriod();
	
				//　グラフの描画範囲(時間)を計算
				// スクロールバーの値get　単位:秒
				int start = Program.FormMain.TimeScrollBarGetValue();
				int h, m, s;
				h = start / 60 / 60;
				m = start % 3600 / 60;
				s = start % 60;
				// ファイルには年月日が記録されていないため1970/1/1にしておく
				ts = new DateTime(1970, 1, 1, h, m, s);

				h = range_t / 60 / 60;
				m = range_t % 3600 / 60;
				s = range_t % 60;
				TimeSpan interval = new TimeSpan(h, m, s);
				te = ts + interval;
//                Console.WriteLine("ReadFile() ts={0}, te={1}, interval={2}", ts, te, interval);
				
				// データの間引き数計算
				// Sample rate,グラフの描画期間,グラフの横pixelから計算する
//				GraphPane myp = myPane[0];
//				int mabiki = ((int)interval.TotalSeconds * Constants.SAMP_FREQ) / (int)myp.Rect.Width / 10;
//                if (mabiki <= 0) mabiki = 1;
                // 間引きを無くした
                int mabiki = 1;				
				// 指定した時間範囲(ts〜te)のデータだけをファイルから読み込む
				// ts,teの指定は機能してない
				// 間引き有り
				decode.ReadFile(file_path, ref readTimestamp, ref readData, ref cnt, ts, te, mabiki);
				return 0;
			} // try()
			catch(Exception e)
			{
				Console.Write("ReadFile(): " + e.Message + "\n");
				Console.Write(e.StackTrace.ToString() + "\n");
				Debug.ShowStackTrace();
				return -1;
			} finally {
				// スクロールバーEnable/Disable
				Program.FormMain.TimeScrollBarEnable();
				// カーソル戻す
//				Program.FormMain.Cursor = Cursors.Default;
				Cursor.Current = Cursors.Default;
				Program.FormMain.Refresh();
			}		
		}
		// Print
		public static int PrintGraph()
		{

			//myZedGraphCtrl.DoPrint();
			//myZedGraphCtrl.DoPrintPreview();

			try
			{
				System.Drawing.Printing.PrintDocument pd = myZedGraphCtrl.PrintDocument;

				if (pd != null)
				{
					myPrintPreviewDialog ppd = new myPrintPreviewDialog();
					

					//pd.PrintPage += new PrintPageEventHandler( Graph_PrintPage );
					ppd.Document = pd;
					ppd.Show();
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}

			return 0;
		}

        // Page Setup
        public static int PageSetup()
		{
			
			myZedGraphCtrl.DoPageSetup();
			return 0;
		}
		/*
		 * グラフPaneの生成
		 */
		private static void MakePane()
		{
			// Remove the default pane that comes with the ZedGraphControl.MasterPane
			myMaster.PaneList.Clear();
			
			// Set the margins and the space between panes to 10 points
			myMaster.Margin.All = 0;
			myMaster.InnerPaneGap = 0;

			myPane = new GraphPane[Constants.CHNUM];

			//空白のグラフを挿入するので+1
			//myPane = new GraphPane[Constants.CHNUM + 1];

			for (int ch = 0; ch < Constants.CHNUM; ch++) {
	//			// ch2とch3の間に空白のグラフを挿入する。
    //            if (ch == 2)
    //            {
    //                myPane[Constants.CHNUM] = new GraphPane();
    //                GraphPane myp2 = myPane[Constants.CHNUM];
	//				myp2.Margin.All = 9999F; // 適当な大きい数字
    //                myMaster.Add(myp2);
    //            }

                // Create a new GraphPane
                myPane[ch] = new GraphPane();
				GraphPane myp = myPane[ch];
				//myp.Title.Text = "CH"+ (ch+1).ToString();
				myp.Title.Text = graphCaption[ch];
				//myp.Title.FontSpec.Size = 16;
				//myp.XAxis.Title.Text = "t";
				//myp.YAxis.Title.Text = "Volt";
				//myp.Margin.All = 0;	
				myp.XAxis.Scale.Format = "HH:mm";   // HH=24時間制

				myp.Title.FontSpec.Size = (int)(14 * 1000 * 2.0 / (Program.FormMain.Size.Height));
				myp.Title.IsVisible = false;
				myp.XAxis.Title.FontSpec.Size = (int)(14 * 1000 * 2.0 / Program.FormMain.Size.Height);
				myp.XAxis.Title.IsVisible = false;
				myp.XAxis.Scale.FontSpec.Size = (int)(14 * 1000 * 2.0 / Program.FormMain.Size.Height);
				myp.YAxis.Title.Text = graphCaption[ch] + "\n" + "Volt";
				myp.YAxis.Title.FontSpec.Size = (int)(14 * 1000 * 2.0 / Program.FormMain.Size.Height);
				myp.YAxis.Scale.FontSpec.Size = (int)(14 * 1000 * 2.0 / Program.FormMain.Size.Height);
				myp.YAxis.MinSpace = 300;

				//                myp.XAxis.Scale.FormatAuto = true;
				// X軸を時間軸に
				myp.XAxis.Type = AxisType.Date;
//					myPane.XAxis.Scale.MajorUnit = DateUnit.Hour;
				
				// Reduce the base dimension to 6 inches, since these panes tend to be smaller
				myp.BaseDimension = 6.0F;

				// Add the new GraphPane to the MasterPane
				myMaster.Add( myp );
			}
			
			// グラフのズームdisable
			myZedGraphCtrl.IsEnableZoom = false;
			// Tell ZedGraph to auto layout all the panes
			using ( Graphics g = myZedGraphCtrl.CreateGraphics() )
			{
				myMaster.SetLayout( g, PaneLayout.SingleColumn );
				myMaster.AxisChange( g );
				//g.Dispose();
			}
		}
	}
}


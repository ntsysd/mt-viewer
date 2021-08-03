using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;
using System.Collections;
using System.IO;

namespace ElogMtGraph
{
	public static class Graph
	{

		private static ZedGraphControl myZedGraphCtrl;
		private static MasterPane myMaster;

		private static GraphPane[] myPane;

		// データ読み込み用　タイムスタンプ
		private static DateTime[] timestamp;
		// データ読み込み用　観測値
		private static int[,] data;
		// データ個数
		private static UInt32 data_length = 0;
		
//		private static double range_h_save = -1;
//		private static double range_y_save = -1;

		private const double	VOLT_MAX = 2.5;
		private const double	VOLT_MIN = -2.5;
		// Volt/LSB 
		private const double VOLT_LSB = 2.5 / 8388608;
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
			}
			catch(Exception e)
			{
				Console.Write("Graph.Init(): "+e.Message+"\n");
				Console.Write(e.StackTrace.ToString()+"\n");
				Debug.ShowStackTrace();
				return;
			}

		}

		// グラフ描画する
		// データ読み込み済みである必要有り
		//
		// double range_t: 時間軸レンジ　Hour 
		// double range_y: Y軸レンジ　Volt/FS 中心値±range_y/2の範囲になる
        public static void DrawGraph(double range_t, double range_y)
		{
			try {
				if (timestamp == null) return;
				if (range_t <= 0) return;
				if (range_y <= 0) return;
				if (data_length < 0) return;
                // 描画中ならばreturn
                if (mutex) return;
                mutex = true;  
				
				// スクロールバーEnable/Disable　Disableにするとバーをドラッグ出来なくなる
//				Program.FormMain.TimeScrollBarDisable();
				// カーソルwait
				Cursor.Current = Cursors.WaitCursor;
				// スクロールバー設定
				Program.FormMain.TimeScrollBarSetMinMax(0.0, 24, range_t/5, range_t);
				Program.FormMain.Refresh();
				
				//
				// 時間軸レンジ計算
				//
				DateTime ts = new DateTime();
				DateTime te = new DateTime();

				//　グラフの描画範囲(時間)を計算
				{
					// スクロールバーの値get　単位:時
					double start = Program.FormMain.TimeScrollBarGetValue();
                    // start
					int h, m;
                    h = (int)Math.Floor(start); h %= 24;
					m = (int)Math.Floor((start - h) * 60); m %= 60;
					ts = new DateTime(timestamp[0].Year, timestamp[0].Month, timestamp[0].Day, h, m, 0);
                    // end
                    h = (int)Math.Floor(range_t);
                    m = (int)Math.Floor((range_t - h) * 60);
//                    Console.WriteLine("DrawGraph() h={0}, m={1}, range_t={2}", h, m, range_t);
                    if (h == 0 && m == 0) m = 1;
					TimeSpan interval = new TimeSpan(h, m, 0);
					te = ts + interval;
//                    Console.WriteLine("DrawGraph() ts={0}, te={1}, interval={2}", ts, te, interval);
                }
				// AD bits
				// 変換係数get Volt/LSB
				double coef = VOLT_LSB;

				/*
				 * グラフ描画
				 */
				// CHループ
				for(int ch = 0; ch < Constants.CHNUM; ch++) {
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
                    if (range_t < 2) {
                        myp.XAxis.Scale.Format = "HH:mm:ss";	// HH=24時間制
                    } else {
                        myp.XAxis.Scale.Format = "HH:mm";	// HH=24時間制
                    }
                    //
                    PointPairList list = new PointPairList();
					// データ数zeroの時はグラフクリアするのみ
                    if (data_length > 0)
                    {
                        // データをグラフ用に抜き出すループ
                        double yavg = 0;
                        int avg_num = 0;
                        list.Clear();
                        for (int i = 0; i < data_length; i += 1)
                        {
                            if (ts <= timestamp[i] && timestamp[i] <= te)
                            {
                                double x = (double)new XDate(timestamp[i].Year, timestamp[i].Month, timestamp[i].Day,
                                                                  timestamp[i].Hour, timestamp[i].Minute, timestamp[i].Second, timestamp[i].Millisecond);
                                double y = (double)data[i, ch] * coef;
                                list.Add(x, y);
                                yavg += y;
                                avg_num++;
                            }
                        }
                        // Y軸中心値計算
                        if (avg_num <= 0) avg_num = 1;
                        double ycenter = yavg / avg_num;
                        // Y軸レンジ設定
                        double min = ycenter - range_y / 2;
                        double max = ycenter + range_y / 2;
                        if (min < VOLT_MIN)
                        {
                            min = VOLT_MIN;
                            max = min + range_y;
                        }
                        if (max > VOLT_MAX)
                        {
                            max = VOLT_MAX;
                            min = max - range_y;
                        }
                        myp.YAxis.Scale.Min = min;
                        myp.YAxis.Scale.Max = max;
                    } // if (data_length > 0)
                    // プロットする
					myp.CurveList.Clear();
					myp.AddCurve( "", list, Color.Red, SymbolType.None );
					// グラフタイトル
					myp.Title.Text = "CH"+ (ch+1).ToString() + "\n" + Path.GetFileName(input_dir);
                    Console.WriteLine("DrawGraph() CH={0} end", ch);
                } // CHループ
				using ( Graphics g = myZedGraphCtrl.CreateGraphics() )
				{
					myMaster.AxisChange( g );
				}
				//
//				range_h_save = range_t;
//				range_y_save = range_y;
			}
			catch(Exception e)
			{
				Console.Write("DrawGraph(): "+e.Message+"\n");
				Console.Write(e.StackTrace.ToString()+"\n");
				Debug.ShowStackTrace();
				return;
			} finally {
                Console.WriteLine("DrawGraph().finally()");
                // スクロールバーEnable
				Program.FormMain.TimeScrollBarEnable();
				// カーソル戻す
				Cursor.Current = Cursors.Default;
				Program.FormMain.Refresh();
                mutex = false;
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
         * ディレクトリから1日分のファイル読み込んでグラフ描画する
		 * 一番最初のグラフ描画、横スクロールしたとき、ウィンドウサイズ変わったとき
         */
		public static int ReadAndDraw(String input_dir0)
		{
			input_dir = input_dir0;
			// dir存在チェック
		    if (!System.IO.Directory.Exists(input_dir)) {
				MessageBox.Show("ディレクトリが存在しません\n" + input_dir , "ERROR" , MessageBoxButtons.OK, MessageBoxIcon.Error);
				return -1;
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

			data_length = 0;
			if(Program.FormMain.GetComboDataModeFreq() == 15) {
				int fileCount = 0;
				foreach (FileInfo f in file_list) {
					if (f != null) {
						if (f.Name.IndexOf("_15Hz") >= 0) {
							Console.WriteLine("{0}", f.Name);
							if (ReadFile(f.FullName, ref data_length) < 0) {
								// 読み込みエラー
								MessageBox.Show("ファイル読み込み中にエラー\n" + f.FullName, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
								return -1;
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
					MessageBox.Show("15Hzデータがありません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			if(Program.FormMain.GetComboDataModeFreq() == 32) {
				int fileCount = 0;
				foreach (FileInfo f in file_list) {
					if (f != null) {
						if (f.Name.IndexOf("_32Hz") >= 0) {
							Console.WriteLine("{0}", f.Name);
							if (ReadFile(f.FullName, ref data_length) < 0) {
								// 読み込みエラー
								MessageBox.Show("ファイル読み込み中にエラー\n" + f.FullName, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
								return -1;
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
					MessageBox.Show("32Hzデータがありません", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			// Graph描画
			double period = Program.FormMain.GetComboPeriod();
			double yrange = Program.FormMain.GetComboY();
			DrawGraph(period, yrange);

			return 0;
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
					Program.FormMain.TimeScrollBarSetValue(0.0);
	
					firsttime = 0;
				}
				//
				// 時間軸レンジ計算
				//
				DateTime ts = new DateTime();
				DateTime te = new DateTime();
				double range_t = Program.FormMain.GetComboPeriod();
	
				//　グラフの描画範囲(時間)を計算
				// スクロールバーの値get　単位:時
				double start = Program.FormMain.TimeScrollBarGetValue();
				int h, m;
				h = (int)Math.Floor(start);
				m = (int)Math.Floor((start - h) * 60);
				// ファイルには年月日が記録されていないため1970/1/1にしておく
				ts = new DateTime(1970, 1, 1, h, m, 0);
	
				h = (int)Math.Floor(range_t);
				m = (int)Math.Floor((range_t - h) * 60);
				TimeSpan interval = new TimeSpan(h, m, 0);
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
				decode.ReadFile(file_path, ref timestamp, ref data, ref cnt, ts, te, mabiki);
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
			
			myPane = new GraphPane[Constants.CHNUM+1];
			
			for(int ch = 0; ch < Constants.CHNUM; ch++) {
				// ch2とch3の間に空白のグラフを挿入する。
                if (ch == 2)
                {
                    myPane[Constants.CHNUM] = new GraphPane();
                    GraphPane myp2 = myPane[Constants.CHNUM];
					myp2.Margin.All = 9999F; // 適当な大きい数字
                    myMaster.Add(myp2);
                }

                // Create a new GraphPane
                myPane[ch] = new GraphPane();
				GraphPane myp = myPane[ch];
				//myp.Title.Text = "CH"+ (ch+1).ToString();
				myp.Title.Text = graphCaption[ch];
				myp.Title.FontSpec.Size = 16;	
				myp.XAxis.Title.Text = "t";
				myp.YAxis.Title.Text = "Volt";
				myp.Margin.All = 0;	
				myp.XAxis.Scale.Format = "HH:mm";	// HH=24時間制
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
				myMaster.SetLayout( g, PaneLayout.SquareColPreferred );
				myMaster.AxisChange( g );
				//g.Dispose();
			}
		}
	}
}


using System;
using System.IO;
using System.Diagnostics;		
using System.Text;

namespace ElogMtGraph
{
	public static class decode
	{
		private const int TIME_LEN = 3;	// 1block先頭のタイムスタンプ(h:m:s)データ長
		private const int DATA_LEN = 3; // 1sample 1chデータ長
        static int samp_freq = 0;

        static decode()
		{
		}
		/*
		 * 指定された時間範囲のデータをファイルから読み込み
		 * file_path
		 * timestamp
		 * data[,]
		 * out_cnt inデータを配列に書き込む位置　outデータの最終位置を返す
		 * ts 読込する時間範囲　開始　使わず
		 * te 読込する時間範囲　終了　使わず
		 * mabiki 読み込みデータを間引く間隔
		 * return 0=OK -1=ERR
		 */
		public static int ReadFile(string filepath, ref DateTime[] timestamp, ref int[,] data, ref UInt32 out_cnt, DateTime ts, DateTime te, int mabiki)
		{
			samp_freq = Program.FormMain.GetDataModeFreq();
			int ONEBLOCK = (TIME_LEN + (DATA_LEN*Constants.CHNUM) * samp_freq); // 1block(1sec)データ長
			DateTime [] timestamp0 = new DateTime[samp_freq];
			int [,] data0 = new int[samp_freq, Constants.CHNUM];
			FileStream fs = null;
//			int out_cnt = 0; // 出力データ　書き込み位置
			try
			{
				if (System.IO.File.Exists(filepath)) {
					byte[] buf = new byte[ONEBLOCK];
					fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
					int fileSize = (int)fs.Length;
					int remain = fileSize;
					int in_cnt = 0; // 間引き用カウンタ

					while (remain > 0) {
						// 1block読み込んでデコード
						int readSize = fs.Read(buf, 0, ONEBLOCK);
						remain -= readSize;
						DecodeBlock(ref buf,ref timestamp0, ref data0);
						// 間引く
						for(int i=0; i < samp_freq; i++) {
							if (in_cnt % mabiki == 0) {
								timestamp[out_cnt] = timestamp0[i];
								for(int ch=0; ch < Constants.CHNUM; ch++) {
									data[out_cnt, ch] = data0[i, ch];
								}
								out_cnt++;
							}
							in_cnt++;
						}
					}
				} else {
					Console.WriteLine("ReadFile(): " + filepath + " not exist!");
					return -1;
				}
			}
			catch(Exception e)
			{
				Console.Write("ReadFile(): " + e.Message + "\n");
				Console.Write(e.StackTrace.ToString() + "\n");
				return -1;
			}
			finally {
				if (fs != null) {
					fs.Close();
				}
			}
			return 0;
		}

		/**
		 * 1block(1sec)データをデコード
		 */
		private static int DecodeBlock(ref byte[] buf, ref DateTime[] timestamp, ref int[,] data)
		{
			ulong index = 0;
			int msec;
			int h,m,s;

			h = buf[index++];
			m = buf[index++];
			s = buf[index++];

			for (int i = 0; i < samp_freq; i++)
			{
				msec = (1000*i)/ samp_freq;
				// ファイルには年月日が記録されていないため1970/1/1にしておく
				timestamp[i] = new DateTime(1970, 1, 1, h, m, s, msec);
//				Console.Write(timestamp[i].ToString("HH:mm:ss.fff"));

				for (int ch = 0; ch < Constants.CHNUM; ch++) {
					data[i, ch] = Byte3_to_int32 (ref buf, index);  // 電圧に変換するか？
					index += DATA_LEN;
//					Console.Write(",{0}", data[i, ch].ToString("D8"));
				}
//				Console.WriteLine();

//				Console.Write(h); Console.Write(":"); Console.Write(m); Console.Write(":"); Console.Write(s); Console.Write("."); Console.Write(msec);
//				Console.Write(","); Console.Write(ch1[i]);
//				Console.Write(","); Console.WriteLine(ch2[i]); //確認用。
			}
			return 0;
		}
		/**
		 * リトルエンディアンの3バイトバイナリ符号付き整数を4バイト符号付き整数に変換する
		 */
		private static Int32 Byte3_to_int32(ref byte[] src0, ulong ofs) 
		{
			byte[] src = new byte[4];
			src[0] = src0[ofs + 0];
			src[1] = src0[ofs + 1];
			src[2] = src0[ofs + 2];

			if ((src[2] & 0x80) != 0) {
				src[3] = 0xFF;
			} else {
				src[3] = 0;
			}
			return BitConverter.ToInt32(src, 0);
		}

	}
}


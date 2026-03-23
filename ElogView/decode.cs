using System;
using System.IO;

namespace ElogView
{
    public static class decode
    {
        private const int TIME_LEN = 3; // 1block先頭のタイムスタンプ(h:m:s)データ長
        private const int DATA_LEN = 3; // 1sample 1chデータ長

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
        public static int ReadFile(string filepath, int channels, ref DateTime[] timestamp, ref int[,] data, ref UInt32 out_cnt, DateTime ts, DateTime te, int mabiki)
        {
            int samp_freq = Program.FormMain.GetDataModeFreq();
            int ONEBLOCK = (TIME_LEN + (DATA_LEN * channels) * samp_freq); // 1block(1sec)データ長
            DateTime[] timestamp0 = new DateTime[samp_freq];
            int[,] data0 = new int[samp_freq, channels];
            FileStream fs = null;
            //			int out_cnt = 0; // 出力データ　書き込み位置
            try
            {
                if (System.IO.File.Exists(filepath))
                {
                    byte[] buf = new byte[ONEBLOCK];
                    fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                    long fileSize = fs.Length;
                    long remain = fileSize;
                    int in_cnt = 0; // 間引き用カウンタ

                    while (remain > 0)
                    {
                        // 1block読み込んでデコード
                        // fs.Read()は要求バイト数より少なく返す場合があるため
                        // (外部SSD等でshort read発生)、ループで確実に読み切る
                        int totalRead = 0;
                        while (totalRead < ONEBLOCK && remain > 0)
                        {
                            int readSize = fs.Read(buf, totalRead, ONEBLOCK - totalRead);
                            if (readSize == 0) break; // EOF
                            totalRead += readSize;
                        }
                        remain -= totalRead;
                        if (totalRead < ONEBLOCK) break; // 不完全ブロックはスキップ
                        if (DecodeBlock(samp_freq, channels, ref buf, ref timestamp0, ref data0) < 0)
                        {
                            continue; // タイムスタンプ異常のブロックはスキップ
                        }
                        // 間引く
                        for (int i = 0; i < samp_freq; i++)
                        {
                            if (in_cnt % mabiki == 0)
                            {
                                timestamp[out_cnt] = timestamp0[i];
                                for (int ch = 0; ch < channels; ch++)
                                {
                                    data[out_cnt, ch] = data0[i, ch];
                                }
                                out_cnt++;
                            }
                            in_cnt++;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("ReadFile(): " + filepath + " not exist!");
                    return -1;
                }
            }
            catch (Exception e)
            {
                Console.Write("ReadFile(): " + e.Message + "\n");
                Console.Write(e.StackTrace.ToString() + "\n");
                return -1;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
            return 0;
        }

        /**
		 * 1block(1sec)データをデコード
		 * return 0=OK -1=タイムスタンプ異常
		 */
        private static int DecodeBlock(int samp_freq, int channels, ref byte[] buf, ref DateTime[] timestamp, ref int[,] data)
        {
            ulong index = 0;
            int msec;
            int h, m, s;

            h = buf[index++];
            m = buf[index++];
            s = buf[index++];

            // タイムスタンプ値域チェック
            if (h > 23 || m > 59 || s > 59)
            {
                Console.WriteLine("DecodeBlock(): invalid timestamp h={0} m={1} s={2}", h, m, s);
                return -1;
            }

            for (int i = 0; i < samp_freq; i++)
            {
                msec = (1000 * i) / samp_freq;
                // ファイルには年月日が記録されていないため1970/1/1にしておく
                timestamp[i] = new DateTime(1970, 1, 1, h, m, s, msec);
                //				Console.Write(timestamp[i].ToString("HH:mm:ss.fff"));

                for (int ch = 0; ch < channels; ch++)
                {
                    data[i, ch] = Byte3_to_int32(ref buf, index);
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
            int val = src0[ofs] | (src0[ofs + 1] << 8) | (src0[ofs + 2] << 16);
            if ((val & 0x800000) != 0)
            {
                val |= unchecked((int)0xFF000000);
            }
            return val;
        }

    }
}

using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace ElogMtGraph
{
    static class Program
    {
        public static MainWindow FormMain;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormMain = new MainWindow();
            Graph.Init();
            Application.Run(FormMain);
        }
    }

    public static class Constants
    {
        public const int CHNUM = 5;
        public const int SAMP_FREQ = 32;

        public static double[] comboPeriod_InitialList = { 0.00833, 0.017, 0.1, 0.2, 0.5, 1, 2, 4, 8, 12, 24 };
    }

    public class Debug
    {
        public static void ShowStackTrace()
        {
            StackTrace st = new StackTrace();
            StringBuilder sb = new StringBuilder();
            for (int LoopCounter = 0; LoopCounter < st.FrameCount; LoopCounter++)
            {
                StackFrame sf = st.GetFrame(LoopCounter);
                sb.Append(sf.GetMethod().ToString());
                sb.Append("\n");
            }
            MessageBox.Show(sb.ToString());
        }
    }
}

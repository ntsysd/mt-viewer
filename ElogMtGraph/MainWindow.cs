using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElogMtGraph
{
    public partial class MainWindow : Form
    {
		// データファイルのディレクトリリスト
		private ArrayList dir_list = new ArrayList();
		// 現在表示しているディレクトリリストの番号
		private int dir_index = -1;

		public MainWindow()
        {
            InitializeComponent();

            Text = "ELOG-MT AUD/PHX Data Viewer " + Application.ProductVersion;

			comboBoxDataMode.SelectedIndex = 0;
			comboBoxPeriod.SelectedIndex = comboBoxPeriod.Items.Count - 1;
			comboBoxY.SelectedIndex = comboBoxPeriod.Items.Count - 1;

			this.comboBoxPeriod.SelectedIndexChanged += new System.EventHandler(this.comboBoxPeriod_SelectedIndexChanged);
			this.comboBoxY.SelectedIndexChanged += new System.EventHandler(this.comboBoxY_SelectedIndexChanged);
		}

		public void SetZedGraph(ref ZedGraph.ZedGraphControl myZedGraphCtrl)
		{
			tabPage1.Controls.Clear();
			tabPage1.Controls.Add(myZedGraphCtrl);

			myZedGraphCtrl.Width = tabPage1.Width;
			myZedGraphCtrl.Height = tabPage1.Height;

			myZedGraphCtrl.Anchor = AnchorStyles.Left | AnchorStyles.Top
												| AnchorStyles.Right | AnchorStyles.Bottom;

			richTextBox1.Text = "";

			// tell the control to rescale itself
			myZedGraphCtrl.AxisChange();

			// redraw the entire form
			Invalidate();
		}

		// 時間軸スクロールバー　Enable
		public void TimeScrollBarEnable()
		{
			this.hScrollBar1.Enabled = true;
//			this.hscrollbar.Refresh();
		}
		// 時間軸スクロールバー　Disable
		public void TimeScrollBarDisable()
		{
			this.hScrollBar1.Enabled = false;
//			this.hscrollbar.Refresh();
		}
		// 時間軸スクロールバー　範囲設定　単位:時
		public void TimeScrollBarSetMinMax(double min, double max, double small, double large)
		{
			this.hScrollBar1.Minimum = (int)(min * 100);
			this.hScrollBar1.Maximum = (int)(max * 100);
			this.hScrollBar1.SmallChange = (int)(small * 100);
			this.hScrollBar1.LargeChange = (int)(large * 100);
		}
		// 時間軸スクロールバー　値設定　単位:時
		public void TimeScrollBarSetValue(double value)
		{
			this.hScrollBar1.Value = (int)(value * 100);
		}
		// 時間軸スクロールバー　値get　単位:時
		public double TimeScrollBarGetValue()
		{
			return this.hScrollBar1.Value / 100.0;
		}
		// Periodコンボの値get　単位:時
		public double GetComboPeriod()
		{
			return double.Parse(this.comboBoxPeriod.SelectedItem.ToString());
		}
		// Yコンボの値get　単位:Volt
		public double GetComboY()
		{
			return double.Parse(this.comboBoxY.SelectedItem.ToString());
		}
		public int GetComboDataModeFreq()
		{
			switch (this.comboBoxDataMode.Text)
			{
				case "PHX(15Hz)": return 15;
				case "ADU(32Hz)": return 32;
				default: return -1;
			}
		}

		// Periodコンボの値set
		// コンボにセットされているitemと同じ値が指定されたら、コンボの選択をそれに変更する
		public void SetComboPeriod(double period)
		{
			foreach (object item in this.comboBoxPeriod.Items)
			{
				//				Console.WriteLine(item.ToString());
				if (double.Parse(item.ToString()) == period)
				{
					this.comboBoxPeriod.SelectedItem = item;
					break;
				}
			}
		}
		// Yコンボの値set
		// コンボにセットされているitemと同じ値が指定されたら、コンボの選択をそれに変更する
		public void SetComboY(double y)
		{
			foreach (object item in this.comboBoxY.Items)
			{
				//				Console.WriteLine(item.ToString());
				if (double.Parse(item.ToString()) == y)
				{
					this.comboBoxY.SelectedItem = item;
					break;
				}
			}
		}
		// descriptionBoxにテキスト設定
		public void SetDescriptionBoxText(string text)
		{
			this.richTextBox1.Text = text;
		}

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
			OpenFileDialog ofd = new OpenFileDialog();

			//ダイアログを表示する
			if (ofd.ShowDialog() == DialogResult.OK)
            {
				//OKボタンがクリックされた
				Console.WriteLine(ofd.FileName);
				/*
				 * 親directory内のデータdirリストを取得しておく
				 */
				dir_list.Clear();
				// 親Dir取得
				string DirName = System.IO.Path.GetDirectoryName(ofd.FileName);
				DirectoryInfo DirInfo = System.IO.Directory.GetParent(DirName);
				Console.WriteLine("Parent={0}", DirInfo.FullName);
				// 親Dir内のデータ子Dirリスト YYYYMMDD
				foreach (string stDirPath in Directory.GetDirectories(DirInfo.FullName))
				{
					// YYYYMMDD形式のみ抽出
					if (System.Text.RegularExpressions.Regex.IsMatch(
						Path.GetFileName(stDirPath),
						@"\A\d{8}\z",
						System.Text.RegularExpressions.RegexOptions.ECMAScript))
					{
						//						Console.WriteLine(stDirPath);
						dir_list.Add(stDirPath);
					}
				}
				// ソート
				dir_list.Sort();
				foreach (string a in dir_list)
				{
					Console.WriteLine(a);
				}
				// これからグラフ化するデータのArrayList内位置番号取得
				dir_index = dir_list.IndexOf(DirName);
				Console.WriteLine("dir_index={0}", dir_index);

				// コンボsetする 24H 20V
				this.SetComboPeriod(24);
				this.SetComboY(5.0);
				// ファイル読み込んでグラフ描く
				//				Graph.SetInputDir(fbd.SelectedPath);
				Graph.ReadAndDraw(DirName);
			}
		}

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Graph.PageSetup();
		}

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
			Graph.PrintGraph();
		}

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
			System.Environment.Exit(0);
		}

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
			//			Console.WriteLine("hscrollbar_ValueChaged(): " + this.hscrollbar.Value );
			// グラフ描画
			//			Graph.ReadAndDraw();
			// ファイル読み込まずに、読み込み済みのデータをプロット
			Graph.DrawGraph(GetComboPeriod(), GetComboY());
		}

        private void comboBoxPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
			System.Windows.Forms.ComboBox combobox = (System.Windows.Forms.ComboBox)sender;
			if (combobox == null) return;

			Console.WriteLine("comboPeriod_SelectedIndexChanged() " + combobox.SelectedIndex);
			Console.WriteLine("combo: " + combobox.SelectedItem.ToString());

			if (combobox.SelectedItem == null)
			{
				Console.WriteLine("comboPeriod_SelectedIndexChanged(): SelectedIndex == NULL!");
				return;
			}
			// グラフ描画
			//			Graph.ReadAndDraw();
			// ファイル読み込まずに、読み込み済みのデータをプロット
			Graph.DrawGraph(GetComboPeriod(), GetComboY());
		}

        private void comboBoxY_SelectedIndexChanged(object sender, EventArgs e)
        {
			System.Windows.Forms.ComboBox combobox = (System.Windows.Forms.ComboBox)sender;
			if (combobox == null) return;

			Console.WriteLine("comboY_SelectedIndexChanged() " + combobox.SelectedIndex);
			Console.WriteLine("combo: " + combobox.SelectedItem.ToString());

			if (combobox.SelectedItem == null)
			{
				Console.WriteLine("comboY_SelectedIndexChanged(): SelectedIndex == NULL!");
				return;
			}
			// グラフ描画
			Graph.DrawGraph(GetComboPeriod(), GetComboY());
		}

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
			//受け取ったキーを表示する
			Console.WriteLine(e.KeyCode);
			if (dir_index < 0) return;

			if (e.KeyCode == Keys.PageUp || e.KeyCode == Keys.Right)
			{
				dir_index++;
				if (dir_index >= dir_list.Count)
					dir_index = 0;
			}
			else if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.Left)
			{
				dir_index--;
				if (dir_index < 0)
					dir_index = dir_list.Count;
			}
			else
			{
				return;
			}
			if (dir_index >= 0 && dir_index < dir_list.Count)
			{
				Console.WriteLine("dir_list[{0}]={1}", dir_index, dir_list[dir_index]);
				// コンボsetする 24H 20V
				this.SetComboPeriod(24);
				this.SetComboY(5.0);
				// ファイル読み込んでグラフ描く
				Graph.ReadAndDraw((string)dir_list[dir_index]);
			}
		}

        private void buttonDetrend_Click(object sender, EventArgs e)
        {
			Console.WriteLine("DeTrend");

			Graph.Detrend();
			Graph.DrawGraph(GetComboPeriod(), GetComboY());
		}
    }
}

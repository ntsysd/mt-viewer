using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElogMtGraph
{
    public partial class MainWindow : Form
    {
		// データファイルのディレクトリリスト
		private ArrayList dir_list = new ArrayList();
		// データファイル名
		private string dataFilename = "";
		// 現在表示しているディレクトリリストの番号
		private int dir_index = -1;
		private int currentFreq = -1;

		public MainWindow()
        {
            InitializeComponent();

            Text = "ELOG-MT AUD/PHX Data Viewer " + Application.ProductVersion;

			comboBoxDataMode.SelectedIndex = 0;
            foreach (var item in Constants.comboPeriod_InitialList)
            {
				comboBoxPeriod.Items.Add(item);
            }
			comboBoxPeriod.SelectedIndex = comboBoxPeriod.Items.Count - 1;
			comboBoxY.SelectedIndex = comboBoxY.Items.Count - 1;
			comboBoxEY.SelectedIndex = comboBoxEY.Items.Count - 1;

			SetAverageFilterEnable(false, false);
			SetDetrendEnable(false, false);

			LoadSettings(@"settings.xml");

			bool sizeFix = false;
			Size newSize = this.Size;
			Point newLocation = this.Location;
				
			if(this.Size.Width > Screen.GetWorkingArea(this).Width)
			{
				sizeFix = true;
				newSize.Width = Screen.GetWorkingArea(this).Width;
				newLocation.X = 0;
			}
			if (this.Size.Height > Screen.GetWorkingArea(this).Height)
			{
				sizeFix = true;
				newSize.Height = Screen.GetWorkingArea(this).Height;
				newLocation.Y = 0;
			}

			// タスクバーが上にあったときの処理
			if (Screen.GetWorkingArea(this).Top > newLocation.Y)
			{
				newLocation.Y = Screen.GetWorkingArea(this).Top;
			}

			if (sizeFix)
			{
				this.Size = newSize;
				this.Location = newLocation;
			}
			
			this.comboBoxPeriod.SelectedIndexChanged += new System.EventHandler(this.comboBoxPeriod_SelectedIndexChanged);
            this.comboBoxY.Validating += new System.ComponentModel.CancelEventHandler(this.comboBoxY_Validating);
			this.comboBoxY.Validated += new System.EventHandler(this.comboBoxY_Validated);
			this.comboBoxY.SelectedIndexChanged += new System.EventHandler(this.comboBoxY_SelectedIndexChanged);

			currentFreq = GetComboDataModeFreq();
			button32Hz.Text = currentFreq.ToString() + "Hz";
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
            try
            {
				return double.Parse(this.comboBoxY.Text);
			}
			catch(FormatException e)
            {
				return -1.0;
            }
		}

		private int GetComboDataModeFreq()
        {
			switch (this.comboBoxDataMode.Text)
			{
				case "PHX(15Hz)": return 15;
				case "ADU(32Hz)": return 32;
				default: return -1;
			}
		}

		private void SetComboDataModeFreq(int freq)
		{
            if (freq == 15)
            {
				this.comboBoxDataMode.Text = "PHX(15Hz)";
			}
			else if(freq == 32)
            {
				this.comboBoxDataMode.Text = "ADU(32Hz)";
			}
		}

		public int GetDataModeFreq()
		{
			return currentFreq;
		}

		public int getScreenWidth()
		{
			return Screen.GetWorkingArea(this).Width;
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
			if (y == -1)
			{
				// means AUTO
				return;
			}

			string yValue = y.ToString();
			this.comboBoxY.SelectedIndex = comboBoxY.FindStringExact(yValue);

			if (this.comboBoxY.SelectedIndex < 0)
			{
				this.comboBoxY.Text = yValue;
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

			ofd.CheckFileExists = false;
			ofd.FileName = "Folder Select";
            ofd.FileOk += Ofd_FileOk;

			//ダイアログを表示する
			if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされた
                string filename = ofd.FileName;
                if (LoadAndDraw(filename))
				{
					this.dataFilename = filename;
				} else
				{
					this.dataFilename = "";
				}
            }
        }

        private bool LoadAndDraw(string filename, bool intaractive = true)
		{
            Console.WriteLine(filename);
            /*
			 * 親directory内のデータdirリストを取得しておく
			 */
            dir_list.Clear();
            // 親Dir取得
            string dirName = System.IO.Path.GetDirectoryName(filename);
            if (!System.IO.Directory.Exists(dirName))
            {
				if (intaractive)
				{
					MessageBox.Show("ディレクトリが存在しません\n" + dirName, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
                return false;
            }
            DirectoryInfo dirInfo = System.IO.Directory.GetParent(dirName);
            Console.WriteLine("Parent={0}", dirInfo.FullName);
            // 親Dir内のデータ子Dirリスト YYYYMMDD
            foreach (string stDirPath in Directory.GetDirectories(dirInfo.FullName))
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
            dir_index = dir_list.IndexOf(dirName);
            Console.WriteLine("dir_index={0}", dir_index);

            // コンボsetする 24H AUTO-V
            this.SetComboPeriod(24);
            //this.SetComboY("AUTO");

            // フィルタの周波数を設定
            currentFreq = GetComboDataModeFreq();
            button32Hz.Text = currentFreq.ToString() + "Hz";
            return Graph.ReadAndDraw(dirName, true, intaractive);
        }

        // 中身がなにもないフォルダを開こうとしたらキャンセルする
        private void Ofd_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
				var ofd = sender as OpenFileDialog;

				var filename = ofd.FileName;

				string directoryName = Path.GetDirectoryName(filename);

				var list = Directory.GetFiles(directoryName);

				if(list.Length == 0)
                {
					e.Cancel = true;
				}
			}
            catch
            {

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

            Graph.DrawGraph(GetComboPeriod(), GetComboY());
		}

        private void comboBoxY_SelectedIndexChanged(object sender, EventArgs e)
        {
			System.Windows.Forms.ComboBox combobox = (System.Windows.Forms.ComboBox)sender;
			if (combobox == null) return;
            this.comboYErrorProvider.SetError(combobox, String.Empty);
            // グラフ描画
            Graph.DrawGraph(GetComboPeriod(), GetComboY());
		}

		private void comboBoxY_Validating(object sender, CancelEventArgs e)
		{
			System.Windows.Forms.ComboBox combobox = (System.Windows.Forms.ComboBox)sender;
			if (combobox == null) return;
			if (combobox.Text == "AUTO")
			{
                return;
			}
			double value;
			if (!double.TryParse(combobox.Text, out value))
			{
				this.comboYErrorProvider.SetError(combobox, "数値を入力してください");

                e.Cancel = true;
				return;
			}

            Console.WriteLine("validate success on value:" + combobox.Text);
        }

		private void comboBoxY_Validated(object sender, EventArgs e)
		{
            System.Windows.Forms.ComboBox combobox = (System.Windows.Forms.ComboBox)sender;
            if (combobox == null) return;
            this.comboYErrorProvider.SetError(combobox, String.Empty);
            Graph.DrawGraph(GetComboPeriod(), GetComboY());
        }
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
		{
			//受け取ったキーを表示する
			Console.WriteLine(e.KeyCode);
			if (dir_index < 0) return;

			if(e.KeyCode == Keys.PageUp || e.KeyCode == Keys.PageDown)
            {
				if (e.KeyCode == Keys.PageUp)
				{
					dir_index++;
					if (dir_index >= dir_list.Count)
						dir_index = 0;
				}
				else if (e.KeyCode == Keys.PageDown)
				{
					dir_index--;
					if (dir_index < 0)
						dir_index = dir_list.Count-1;
				}

				if (dir_index >= 0 && dir_index < dir_list.Count)
				{
					Console.WriteLine("dir_list[{0}]={1}", dir_index, dir_list[dir_index]);
					// コンボsetする 24H 20V
					//this.SetComboPeriod(24);
					//this.SetComboY(5.0);

					// 時間を0:00にする
					TimeScrollBarSetValue(0.0);

					// ファイル読み込んでグラフ描く
					Graph.ReadAndDraw((string)dir_list[dir_index]);
				}

				// フォーカスのあるコンボボックスの値が変わってしまうことを抑制
				e.Handled = true;
			}

			if(e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            {
				int subMax = this.hScrollBar1.Maximum - this.hScrollBar1.LargeChange;
				if (e.KeyCode == Keys.Right)
				{
					if (subMax <= this.hScrollBar1.Value)
					{
						dir_index++;
						if (dir_index >= dir_list.Count)
							dir_index = 0;

						//時刻を0:00にする
						hScrollBar1.Value = 0;
						// ファイル読み込んでグラフ描く
						Graph.ReadAndDraw((string)dir_list[dir_index]);
					}
					else
					{
						this.hScrollBar1.Value = Math.Min(subMax, this.hScrollBar1.Value + this.hScrollBar1.LargeChange);
						Graph.DrawGraph(GetComboPeriod(), GetComboY());
					}
				}
				else if (e.KeyCode == Keys.Left)
				{
					if (this.hScrollBar1.Minimum == this.hScrollBar1.Value)
					{
						dir_index--;
						if (dir_index < 0)
							dir_index = dir_list.Count-1;

						//時刻を一番うしろにする
						hScrollBar1.Value = subMax;
						// ファイル読み込んでグラフ描く
						Graph.ReadAndDraw((string)dir_list[dir_index]);
					}
					else
					{
						this.hScrollBar1.Value = Math.Max(this.hScrollBar1.Minimum, this.hScrollBar1.Value - this.hScrollBar1.LargeChange);
						Graph.DrawGraph(GetComboPeriod(), GetComboY());
					}
				}

				// フォーカスのあるコンボボックスの値が変わってしまうことを抑制
				e.Handled = true;
			}
		}

		private void buttonDetrendOn_Click(object sender, EventArgs e)
		{
			SetDetrendEnable(true);
		}

		private void buttonDetrendOff_Click(object sender, EventArgs e)
		{
			SetDetrendEnable(false);
		}

		private void SetDetrendEnable(bool enable, bool draw = true)
        {
			// フォーカスがボタンに行ってしまって選択されているか紛らわしいので適当なコントロールにフォーカスをずらす
			this.ActiveControl = richTextBox1;

			if (enable)
			{
				buttonDetrendOn.Enabled = false;
				buttonDetrendOff.Enabled = true;
				buttonDetrendOn.BackColor = Color.Yellow;
				buttonDetrendOff.BackColor = Color.FromKnownColor(KnownColor.Control);
			}
			else
			{
				buttonDetrendOn.Enabled = true;
				buttonDetrendOff.Enabled = false;
				buttonDetrendOn.BackColor = Color.FromKnownColor(KnownColor.Control);
				buttonDetrendOff.BackColor = Color.Yellow;
			}
			if (draw) Graph.DrawGraph(GetComboPeriod(), GetComboY());
		}

		public bool IsDetrendEnable()
        {
			return !buttonDetrendOn.Enabled;
        }

		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = false;
			string filename = @"settings.xml";

			SaveSettings(filename);
		}

		private void MainWindow_Shown(object sender, EventArgs e)
		{
			if (this.dataFilename.Length > 0)
			{
				if (!this.LoadAndDraw(this.dataFilename, false))	
				{
					this.dataFilename = "";
				}
			}
		}

		private void LoadSettings(string filename)
		{
			if (!File.Exists(filename))
			{
				return;
			}
			using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
			{

				var xDocument = System.Xml.Linq.XDocument.Load(stream);

				this.Size = new Size(
					int.Parse(xDocument.Element("Settings").Element("Size").Element("Width").Value),
					int.Parse(xDocument.Element("Settings").Element("Size").Element("Height").Value));

				SetDetrendEnable(xDocument.Element("Settings").Element("View").Element("Detrend").Value == "On", false);
                SetAverageFilterEnable(xDocument.Element("Settings").Element("View").Element("AveFilter").Value == "On", false);
				SetComboDataModeFreq(int.Parse(xDocument.Element("Settings").Element("View").Element("Mode").Value));
				SetComboPeriod(double.Parse(xDocument.Element("Settings").Element("View").Element("Period").Value));
				SetComboY(double.Parse(xDocument.Element("Settings").Element("View").Element("Y").Value));
				this.dataFilename = xDocument.Element("Settings").Element("DataFilename").Value;
				Console.WriteLine(this.dataFilename);
			}
		}

		private void SaveSettings(string filename)
		{
			using (var stream = new FileStream(filename, FileMode.Create, FileAccess.Write))
			{
				var xDocument = new System.Xml.Linq.XDocument(new System.Xml.Linq.XDeclaration("1.0", "utf-8", "Yes"));
				var xSettings = new System.Xml.Linq.XElement("Settings");
				var xSize = new System.Xml.Linq.XElement("Size");
				xSize.Add(new System.Xml.Linq.XElement("Height", this.Size.Height));
				xSize.Add(new System.Xml.Linq.XElement("Width", this.Size.Width));
				var xView = new System.Xml.Linq.XElement("View");
				xView.Add(new System.Xml.Linq.XElement("Detrend", IsDetrendEnable()?"On":"Off"));
				xView.Add(new System.Xml.Linq.XElement("AveFilter", IsAverageFilterEnable()?"On":"Off"));
				xView.Add(new System.Xml.Linq.XElement("Mode", GetComboDataModeFreq()));
				xView.Add(new System.Xml.Linq.XElement("Period", GetComboPeriod()));
				xView.Add(new System.Xml.Linq.XElement("Y", GetComboY()));
				xSettings.Add(xSize);
				xSettings.Add(xView);
                var xDataFilename = new System.Xml.Linq.XElement("DataFilename", this.dataFilename);
				xSettings.Add(xDataFilename);
                xDocument.Add(xSettings);
                xDocument.Save(stream);
			}
		}

		public void StatusLabel_SetText(string text)
        {
			toolStripStatusLabel1.Text = text;
			statusStrip1.Refresh();
        }

        private void button32Hz_Click(object sender, EventArgs e)
        {
			SetAverageFilterEnable(false);
        }

        private void button1Hz_Click(object sender, EventArgs e)
        {
			SetAverageFilterEnable(true);
        }

		public bool IsAverageFilterEnable()
        {
			return button32Hz.Enabled;
		}

		private void SetAverageFilterEnable(bool enable, bool draw = true)
        {
			// フォーカスがボタンに行ってしまって選択されているか紛らわしいので適当なコントロールにフォーカスをずらす
			this.ActiveControl = richTextBox1;

			if (enable)
            {
				button1Hz.Enabled = false;
				button32Hz.Enabled = true;
				button1Hz.BackColor = Color.Yellow;
				button32Hz.BackColor = Color.FromKnownColor(KnownColor.Control);
			}
            else
            {
				button1Hz.Enabled = true;
				button32Hz.Enabled = false;
				button1Hz.BackColor = Color.FromKnownColor(KnownColor.Control);
				button32Hz.BackColor = Color.Yellow;
			}

			if (draw) Graph.DrawGraph(GetComboPeriod(), GetComboY());
		}

    }
}

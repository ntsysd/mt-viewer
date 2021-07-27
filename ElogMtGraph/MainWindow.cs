using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElogMtGraph
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            Text = "ELOG-MT AUD/PHX Data Viewer " + Application.ProductVersion;
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
			return 0.0;// double.Parse(this.comboPeriod.SelectedItem.ToString());
		}
		// Yコンボの値get　単位:Volt
		public double GetComboY()
		{
			return 0.0;// double.Parse(this.comboY.SelectedItem.ToString());
		}
		public int GetComboDataModeFreq()
		{
			return 0;/*
			switch (this.comboDataMode.Text)
			{
				case "PHX(15Hz)": return 15;
				case "ADU(32Hz)": return 32;
				default: return -1;
			}*/
		}

		// Periodコンボの値set
		// コンボにセットされているitemと同じ値が指定されたら、コンボの選択をそれに変更する
		public void SetComboPeriod(double period)
		{
			/*foreach (object item in this.comboPeriod.Items)
			{
				//				Console.WriteLine(item.ToString());
				if (double.Parse(item.ToString()) == period)
				{
					this.comboPeriod.SelectedItem = item;
					break;
				}
			}*/
		}
		// Yコンボの値set
		// コンボにセットされているitemと同じ値が指定されたら、コンボの選択をそれに変更する
		public void SetComboY(double y)
		{
			/*foreach (object item in this.comboY.Items)
			{
				//				Console.WriteLine(item.ToString());
				if (double.Parse(item.ToString()) == y)
				{
					this.comboY.SelectedItem = item;
					break;
				}
			}*/
		}
		// descriptionBoxにテキスト設定
		public void SetDescriptionBoxText(string text)
		{
			this.richTextBox1.Text = text;
		}
	}
}

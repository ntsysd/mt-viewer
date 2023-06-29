namespace ElogMtGraph
{
    partial class MainWindow
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxChannelMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.yRangeValueLabel = new System.Windows.Forms.Label();
            this.comboBoxHY = new System.Windows.Forms.ComboBox();
            this.labelHY = new System.Windows.Forms.Label();
            this.labelEYUnit = new System.Windows.Forms.Label();
            this.buttonDetrendOff = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1Hz = new System.Windows.Forms.Button();
            this.button32Hz = new System.Windows.Forms.Button();
            this.comboBoxEY = new System.Windows.Forms.ComboBox();
            this.comboBoxPeriod = new System.Windows.Forms.ComboBox();
            this.comboBoxDataMode = new System.Windows.Forms.ComboBox();
            this.labelYUnit = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelHour = new System.Windows.Forms.Label();
            this.labelPeriod = new System.Windows.Forms.Label();
            this.labelMode = new System.Windows.Forms.Label();
            this.buttonDetrendOn = new System.Windows.Forms.Button();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.comboHYErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.comboEYErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboHYErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboEYErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.pageSetupToolStripMenuItem,
            this.printToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // pageSetupToolStripMenuItem
            // 
            this.pageSetupToolStripMenuItem.Name = "pageSetupToolStripMenuItem";
            resources.ApplyResources(this.pageSetupToolStripMenuItem, "pageSetupToolStripMenuItem");
            this.pageSetupToolStripMenuItem.Click += new System.EventHandler(this.pageSetupToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            resources.ApplyResources(this.printToolStripMenuItem, "printToolStripMenuItem");
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxChannelMode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.yRangeValueLabel);
            this.groupBox1.Controls.Add(this.comboBoxHY);
            this.groupBox1.Controls.Add(this.labelHY);
            this.groupBox1.Controls.Add(this.labelEYUnit);
            this.groupBox1.Controls.Add(this.buttonDetrendOff);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1Hz);
            this.groupBox1.Controls.Add(this.button32Hz);
            this.groupBox1.Controls.Add(this.comboBoxEY);
            this.groupBox1.Controls.Add(this.comboBoxPeriod);
            this.groupBox1.Controls.Add(this.comboBoxDataMode);
            this.groupBox1.Controls.Add(this.labelYUnit);
            this.groupBox1.Controls.Add(this.labelY);
            this.groupBox1.Controls.Add(this.labelHour);
            this.groupBox1.Controls.Add(this.labelPeriod);
            this.groupBox1.Controls.Add(this.labelMode);
            this.groupBox1.Controls.Add(this.buttonDetrendOn);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // comboBoxChannelMode
            // 
            this.comboBoxChannelMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBoxChannelMode, "comboBoxChannelMode");
            this.comboBoxChannelMode.FormattingEnabled = true;
            this.comboBoxChannelMode.Items.AddRange(new object[] {
            resources.GetString("comboBoxChannelMode.Items"),
            resources.GetString("comboBoxChannelMode.Items1")});
            this.comboBoxChannelMode.Name = "comboBoxChannelMode";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // yRangeValueLabel
            // 
            resources.ApplyResources(this.yRangeValueLabel, "yRangeValueLabel");
            this.yRangeValueLabel.Name = "yRangeValueLabel";
            // 
            // comboBoxHY
            // 
            resources.ApplyResources(this.comboBoxHY, "comboBoxHY");
            this.comboBoxHY.FormattingEnabled = true;
            this.comboBoxHY.Items.AddRange(new object[] {
            resources.GetString("comboBoxHY.Items"),
            resources.GetString("comboBoxHY.Items1"),
            resources.GetString("comboBoxHY.Items2"),
            resources.GetString("comboBoxHY.Items3"),
            resources.GetString("comboBoxHY.Items4"),
            resources.GetString("comboBoxHY.Items5"),
            resources.GetString("comboBoxHY.Items6"),
            resources.GetString("comboBoxHY.Items7"),
            resources.GetString("comboBoxHY.Items8"),
            resources.GetString("comboBoxHY.Items9"),
            resources.GetString("comboBoxHY.Items10"),
            resources.GetString("comboBoxHY.Items11"),
            resources.GetString("comboBoxHY.Items12"),
            resources.GetString("comboBoxHY.Items13")});
            this.comboBoxHY.Name = "comboBoxHY";
            // 
            // labelHY
            // 
            resources.ApplyResources(this.labelHY, "labelHY");
            this.labelHY.Name = "labelHY";
            // 
            // labelEYUnit
            // 
            resources.ApplyResources(this.labelEYUnit, "labelEYUnit");
            this.labelEYUnit.Name = "labelEYUnit";
            // 
            // buttonDetrendOff
            // 
            resources.ApplyResources(this.buttonDetrendOff, "buttonDetrendOff");
            this.buttonDetrendOff.Name = "buttonDetrendOff";
            this.buttonDetrendOff.UseVisualStyleBackColor = true;
            this.buttonDetrendOff.Click += new System.EventHandler(this.buttonDetrendOff_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // button1Hz
            // 
            resources.ApplyResources(this.button1Hz, "button1Hz");
            this.button1Hz.Name = "button1Hz";
            this.button1Hz.UseVisualStyleBackColor = true;
            this.button1Hz.Click += new System.EventHandler(this.button1Hz_Click);
            // 
            // button32Hz
            // 
            resources.ApplyResources(this.button32Hz, "button32Hz");
            this.button32Hz.Name = "button32Hz";
            this.button32Hz.UseVisualStyleBackColor = true;
            this.button32Hz.Click += new System.EventHandler(this.button32Hz_Click);
            // 
            // comboBoxEY
            // 
            resources.ApplyResources(this.comboBoxEY, "comboBoxEY");
            this.comboBoxEY.FormattingEnabled = true;
            this.comboBoxEY.Items.AddRange(new object[] {
            resources.GetString("comboBoxEY.Items"),
            resources.GetString("comboBoxEY.Items1"),
            resources.GetString("comboBoxEY.Items2"),
            resources.GetString("comboBoxEY.Items3"),
            resources.GetString("comboBoxEY.Items4"),
            resources.GetString("comboBoxEY.Items5"),
            resources.GetString("comboBoxEY.Items6"),
            resources.GetString("comboBoxEY.Items7"),
            resources.GetString("comboBoxEY.Items8"),
            resources.GetString("comboBoxEY.Items9"),
            resources.GetString("comboBoxEY.Items10"),
            resources.GetString("comboBoxEY.Items11")});
            this.comboBoxEY.Name = "comboBoxEY";
            // 
            // comboBoxPeriod
            // 
            this.comboBoxPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBoxPeriod, "comboBoxPeriod");
            this.comboBoxPeriod.FormattingEnabled = true;
            this.comboBoxPeriod.Name = "comboBoxPeriod";
            // 
            // comboBoxDataMode
            // 
            this.comboBoxDataMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBoxDataMode, "comboBoxDataMode");
            this.comboBoxDataMode.Items.AddRange(new object[] {
            resources.GetString("comboBoxDataMode.Items"),
            resources.GetString("comboBoxDataMode.Items1")});
            this.comboBoxDataMode.Name = "comboBoxDataMode";
            // 
            // labelYUnit
            // 
            resources.ApplyResources(this.labelYUnit, "labelYUnit");
            this.labelYUnit.Name = "labelYUnit";
            // 
            // labelY
            // 
            resources.ApplyResources(this.labelY, "labelY");
            this.labelY.Name = "labelY";
            // 
            // labelHour
            // 
            resources.ApplyResources(this.labelHour, "labelHour");
            this.labelHour.Name = "labelHour";
            // 
            // labelPeriod
            // 
            resources.ApplyResources(this.labelPeriod, "labelPeriod");
            this.labelPeriod.Name = "labelPeriod";
            // 
            // labelMode
            // 
            resources.ApplyResources(this.labelMode, "labelMode");
            this.labelMode.Name = "labelMode";
            // 
            // buttonDetrendOn
            // 
            resources.ApplyResources(this.buttonDetrendOn, "buttonDetrendOn");
            this.buttonDetrendOn.Name = "buttonDetrendOn";
            this.buttonDetrendOn.UseVisualStyleBackColor = true;
            this.buttonDetrendOn.Click += new System.EventHandler(this.buttonDetrendOn_Click);
            // 
            // hScrollBar1
            // 
            resources.ApplyResources(this.hScrollBar1, "hScrollBar1");
            this.hScrollBar1.Maximum = 86400;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            // 
            // comboHYErrorProvider
            // 
            this.comboHYErrorProvider.ContainerControl = this;
            // 
            // comboEYErrorProvider
            // 
            this.comboEYErrorProvider.ContainerControl = this;
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboHYErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboEYErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pageSetupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ComboBox comboBoxEY;
        private System.Windows.Forms.ComboBox comboBoxPeriod;
        private System.Windows.Forms.ComboBox comboBoxDataMode;
        private System.Windows.Forms.Label labelYUnit;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelHour;
        private System.Windows.Forms.Label labelPeriod;
        private System.Windows.Forms.Label labelMode;
        private System.Windows.Forms.Button buttonDetrendOn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button32Hz;
        private System.Windows.Forms.Button button1Hz;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDetrendOff;
        private System.Windows.Forms.ErrorProvider comboHYErrorProvider;
        private System.Windows.Forms.ComboBox comboBoxHY;
        private System.Windows.Forms.Label labelHY;
        private System.Windows.Forms.Label labelEYUnit;
        private System.Windows.Forms.ErrorProvider comboEYErrorProvider;
        private System.Windows.Forms.Label yRangeValueLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxChannelMode;
    }
}


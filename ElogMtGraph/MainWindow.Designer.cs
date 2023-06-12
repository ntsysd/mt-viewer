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
            this.comboEYErrorProvider.SetError(this.splitContainer1, resources.GetString("splitContainer1.Error"));
            this.comboHYErrorProvider.SetError(this.splitContainer1, resources.GetString("splitContainer1.Error1"));
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.comboHYErrorProvider.SetIconAlignment(this.splitContainer1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer1.IconAlignment"))));
            this.comboEYErrorProvider.SetIconAlignment(this.splitContainer1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer1.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.splitContainer1, ((int)(resources.GetObject("splitContainer1.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.splitContainer1, ((int)(resources.GetObject("splitContainer1.IconPadding1"))));
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.comboEYErrorProvider.SetError(this.splitContainer1.Panel1, resources.GetString("splitContainer1.Panel1.Error"));
            this.comboHYErrorProvider.SetError(this.splitContainer1.Panel1, resources.GetString("splitContainer1.Panel1.Error1"));
            this.comboHYErrorProvider.SetIconAlignment(this.splitContainer1.Panel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer1.Panel1.IconAlignment"))));
            this.comboEYErrorProvider.SetIconAlignment(this.splitContainer1.Panel1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer1.Panel1.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.splitContainer1.Panel1, ((int)(resources.GetObject("splitContainer1.Panel1.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.splitContainer1.Panel1, ((int)(resources.GetObject("splitContainer1.Panel1.IconPadding1"))));
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.comboEYErrorProvider.SetError(this.splitContainer1.Panel2, resources.GetString("splitContainer1.Panel2.Error"));
            this.comboHYErrorProvider.SetError(this.splitContainer1.Panel2, resources.GetString("splitContainer1.Panel2.Error1"));
            this.comboHYErrorProvider.SetIconAlignment(this.splitContainer1.Panel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer1.Panel2.IconAlignment"))));
            this.comboEYErrorProvider.SetIconAlignment(this.splitContainer1.Panel2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("splitContainer1.Panel2.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.splitContainer1.Panel2, ((int)(resources.GetObject("splitContainer1.Panel2.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.splitContainer1.Panel2, ((int)(resources.GetObject("splitContainer1.Panel2.IconPadding1"))));
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.comboEYErrorProvider.SetError(this.tabControl1, resources.GetString("tabControl1.Error"));
            this.comboHYErrorProvider.SetError(this.tabControl1, resources.GetString("tabControl1.Error1"));
            this.comboEYErrorProvider.SetIconAlignment(this.tabControl1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tabControl1.IconAlignment"))));
            this.comboHYErrorProvider.SetIconAlignment(this.tabControl1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tabControl1.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.tabControl1, ((int)(resources.GetObject("tabControl1.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.tabControl1, ((int)(resources.GetObject("tabControl1.IconPadding1"))));
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.comboEYErrorProvider.SetError(this.tabPage1, resources.GetString("tabPage1.Error"));
            this.comboHYErrorProvider.SetError(this.tabPage1, resources.GetString("tabPage1.Error1"));
            this.comboHYErrorProvider.SetIconAlignment(this.tabPage1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tabPage1.IconAlignment"))));
            this.comboEYErrorProvider.SetIconAlignment(this.tabPage1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("tabPage1.IconAlignment1"))));
            this.comboEYErrorProvider.SetIconPadding(this.tabPage1, ((int)(resources.GetObject("tabPage1.IconPadding"))));
            this.comboHYErrorProvider.SetIconPadding(this.tabPage1, ((int)(resources.GetObject("tabPage1.IconPadding1"))));
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            resources.ApplyResources(this.richTextBox1, "richTextBox1");
            this.comboHYErrorProvider.SetError(this.richTextBox1, resources.GetString("richTextBox1.Error"));
            this.comboEYErrorProvider.SetError(this.richTextBox1, resources.GetString("richTextBox1.Error1"));
            this.comboHYErrorProvider.SetIconAlignment(this.richTextBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("richTextBox1.IconAlignment"))));
            this.comboEYErrorProvider.SetIconAlignment(this.richTextBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("richTextBox1.IconAlignment1"))));
            this.comboEYErrorProvider.SetIconPadding(this.richTextBox1, ((int)(resources.GetObject("richTextBox1.IconPadding"))));
            this.comboHYErrorProvider.SetIconPadding(this.richTextBox1, ((int)(resources.GetObject("richTextBox1.IconPadding1"))));
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.comboEYErrorProvider.SetError(this.menuStrip1, resources.GetString("menuStrip1.Error"));
            this.comboHYErrorProvider.SetError(this.menuStrip1, resources.GetString("menuStrip1.Error1"));
            this.comboHYErrorProvider.SetIconAlignment(this.menuStrip1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("menuStrip1.IconAlignment"))));
            this.comboEYErrorProvider.SetIconAlignment(this.menuStrip1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("menuStrip1.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.menuStrip1, ((int)(resources.GetObject("menuStrip1.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.menuStrip1, ((int)(resources.GetObject("menuStrip1.IconPadding1"))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.pageSetupToolStripMenuItem,
            this.printToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            // 
            // openToolStripMenuItem
            // 
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // pageSetupToolStripMenuItem
            // 
            resources.ApplyResources(this.pageSetupToolStripMenuItem, "pageSetupToolStripMenuItem");
            this.pageSetupToolStripMenuItem.Name = "pageSetupToolStripMenuItem";
            this.pageSetupToolStripMenuItem.Click += new System.EventHandler(this.pageSetupToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            resources.ApplyResources(this.printToolStripMenuItem, "printToolStripMenuItem");
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
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
            this.comboHYErrorProvider.SetError(this.groupBox1, resources.GetString("groupBox1.Error"));
            this.comboEYErrorProvider.SetError(this.groupBox1, resources.GetString("groupBox1.Error1"));
            this.comboEYErrorProvider.SetIconAlignment(this.groupBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("groupBox1.IconAlignment"))));
            this.comboHYErrorProvider.SetIconAlignment(this.groupBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("groupBox1.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.groupBox1, ((int)(resources.GetObject("groupBox1.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.groupBox1, ((int)(resources.GetObject("groupBox1.IconPadding1"))));
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // yRangeValueLabel
            // 
            resources.ApplyResources(this.yRangeValueLabel, "yRangeValueLabel");
            this.comboHYErrorProvider.SetError(this.yRangeValueLabel, resources.GetString("yRangeValueLabel.Error"));
            this.comboEYErrorProvider.SetError(this.yRangeValueLabel, resources.GetString("yRangeValueLabel.Error1"));
            this.comboHYErrorProvider.SetIconAlignment(this.yRangeValueLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("yRangeValueLabel.IconAlignment"))));
            this.comboEYErrorProvider.SetIconAlignment(this.yRangeValueLabel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("yRangeValueLabel.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.yRangeValueLabel, ((int)(resources.GetObject("yRangeValueLabel.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.yRangeValueLabel, ((int)(resources.GetObject("yRangeValueLabel.IconPadding1"))));
            this.yRangeValueLabel.Name = "yRangeValueLabel";
            // 
            // comboBoxHY
            // 
            resources.ApplyResources(this.comboBoxHY, "comboBoxHY");
            this.comboHYErrorProvider.SetError(this.comboBoxHY, resources.GetString("comboBoxHY.Error"));
            this.comboEYErrorProvider.SetError(this.comboBoxHY, resources.GetString("comboBoxHY.Error1"));
            this.comboBoxHY.FormattingEnabled = true;
            this.comboEYErrorProvider.SetIconAlignment(this.comboBoxHY, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("comboBoxHY.IconAlignment"))));
            this.comboHYErrorProvider.SetIconAlignment(this.comboBoxHY, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("comboBoxHY.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.comboBoxHY, ((int)(resources.GetObject("comboBoxHY.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.comboBoxHY, ((int)(resources.GetObject("comboBoxHY.IconPadding1"))));
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
            this.comboHYErrorProvider.SetError(this.labelHY, resources.GetString("labelHY.Error"));
            this.comboEYErrorProvider.SetError(this.labelHY, resources.GetString("labelHY.Error1"));
            this.comboHYErrorProvider.SetIconAlignment(this.labelHY, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("labelHY.IconAlignment"))));
            this.comboEYErrorProvider.SetIconAlignment(this.labelHY, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("labelHY.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.labelHY, ((int)(resources.GetObject("labelHY.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.labelHY, ((int)(resources.GetObject("labelHY.IconPadding1"))));
            this.labelHY.Name = "labelHY";
            // 
            // labelEYUnit
            // 
            resources.ApplyResources(this.labelEYUnit, "labelEYUnit");
            this.comboHYErrorProvider.SetError(this.labelEYUnit, resources.GetString("labelEYUnit.Error"));
            this.comboEYErrorProvider.SetError(this.labelEYUnit, resources.GetString("labelEYUnit.Error1"));
            this.comboHYErrorProvider.SetIconAlignment(this.labelEYUnit, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("labelEYUnit.IconAlignment"))));
            this.comboEYErrorProvider.SetIconAlignment(this.labelEYUnit, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("labelEYUnit.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.labelEYUnit, ((int)(resources.GetObject("labelEYUnit.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.labelEYUnit, ((int)(resources.GetObject("labelEYUnit.IconPadding1"))));
            this.labelEYUnit.Name = "labelEYUnit";
            // 
            // buttonDetrendOff
            // 
            resources.ApplyResources(this.buttonDetrendOff, "buttonDetrendOff");
            this.comboHYErrorProvider.SetError(this.buttonDetrendOff, resources.GetString("buttonDetrendOff.Error"));
            this.comboEYErrorProvider.SetError(this.buttonDetrendOff, resources.GetString("buttonDetrendOff.Error1"));
            this.comboHYErrorProvider.SetIconAlignment(this.buttonDetrendOff, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("buttonDetrendOff.IconAlignment"))));
            this.comboEYErrorProvider.SetIconAlignment(this.buttonDetrendOff, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("buttonDetrendOff.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.buttonDetrendOff, ((int)(resources.GetObject("buttonDetrendOff.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.buttonDetrendOff, ((int)(resources.GetObject("buttonDetrendOff.IconPadding1"))));
            this.buttonDetrendOff.Name = "buttonDetrendOff";
            this.buttonDetrendOff.UseVisualStyleBackColor = true;
            this.buttonDetrendOff.Click += new System.EventHandler(this.buttonDetrendOff_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.comboHYErrorProvider.SetError(this.label1, resources.GetString("label1.Error"));
            this.comboEYErrorProvider.SetError(this.label1, resources.GetString("label1.Error1"));
            this.comboHYErrorProvider.SetIconAlignment(this.label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment"))));
            this.comboEYErrorProvider.SetIconAlignment(this.label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.label1, ((int)(resources.GetObject("label1.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.label1, ((int)(resources.GetObject("label1.IconPadding1"))));
            this.label1.Name = "label1";
            // 
            // button1Hz
            // 
            resources.ApplyResources(this.button1Hz, "button1Hz");
            this.comboHYErrorProvider.SetError(this.button1Hz, resources.GetString("button1Hz.Error"));
            this.comboEYErrorProvider.SetError(this.button1Hz, resources.GetString("button1Hz.Error1"));
            this.comboHYErrorProvider.SetIconAlignment(this.button1Hz, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("button1Hz.IconAlignment"))));
            this.comboEYErrorProvider.SetIconAlignment(this.button1Hz, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("button1Hz.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.button1Hz, ((int)(resources.GetObject("button1Hz.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.button1Hz, ((int)(resources.GetObject("button1Hz.IconPadding1"))));
            this.button1Hz.Name = "button1Hz";
            this.button1Hz.UseVisualStyleBackColor = true;
            this.button1Hz.Click += new System.EventHandler(this.button1Hz_Click);
            // 
            // button32Hz
            // 
            resources.ApplyResources(this.button32Hz, "button32Hz");
            this.comboHYErrorProvider.SetError(this.button32Hz, resources.GetString("button32Hz.Error"));
            this.comboEYErrorProvider.SetError(this.button32Hz, resources.GetString("button32Hz.Error1"));
            this.comboHYErrorProvider.SetIconAlignment(this.button32Hz, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("button32Hz.IconAlignment"))));
            this.comboEYErrorProvider.SetIconAlignment(this.button32Hz, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("button32Hz.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.button32Hz, ((int)(resources.GetObject("button32Hz.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.button32Hz, ((int)(resources.GetObject("button32Hz.IconPadding1"))));
            this.button32Hz.Name = "button32Hz";
            this.button32Hz.UseVisualStyleBackColor = true;
            this.button32Hz.Click += new System.EventHandler(this.button32Hz_Click);
            // 
            // comboBoxEY
            // 
            resources.ApplyResources(this.comboBoxEY, "comboBoxEY");
            this.comboHYErrorProvider.SetError(this.comboBoxEY, resources.GetString("comboBoxEY.Error"));
            this.comboEYErrorProvider.SetError(this.comboBoxEY, resources.GetString("comboBoxEY.Error1"));
            this.comboBoxEY.FormattingEnabled = true;
            this.comboEYErrorProvider.SetIconAlignment(this.comboBoxEY, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("comboBoxEY.IconAlignment"))));
            this.comboHYErrorProvider.SetIconAlignment(this.comboBoxEY, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("comboBoxEY.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.comboBoxEY, ((int)(resources.GetObject("comboBoxEY.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.comboBoxEY, ((int)(resources.GetObject("comboBoxEY.IconPadding1"))));
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
            resources.ApplyResources(this.comboBoxPeriod, "comboBoxPeriod");
            this.comboBoxPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboHYErrorProvider.SetError(this.comboBoxPeriod, resources.GetString("comboBoxPeriod.Error"));
            this.comboEYErrorProvider.SetError(this.comboBoxPeriod, resources.GetString("comboBoxPeriod.Error1"));
            this.comboBoxPeriod.FormattingEnabled = true;
            this.comboEYErrorProvider.SetIconAlignment(this.comboBoxPeriod, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("comboBoxPeriod.IconAlignment"))));
            this.comboHYErrorProvider.SetIconAlignment(this.comboBoxPeriod, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("comboBoxPeriod.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.comboBoxPeriod, ((int)(resources.GetObject("comboBoxPeriod.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.comboBoxPeriod, ((int)(resources.GetObject("comboBoxPeriod.IconPadding1"))));
            this.comboBoxPeriod.Name = "comboBoxPeriod";
            // 
            // comboBoxDataMode
            // 
            resources.ApplyResources(this.comboBoxDataMode, "comboBoxDataMode");
            this.comboBoxDataMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboHYErrorProvider.SetError(this.comboBoxDataMode, resources.GetString("comboBoxDataMode.Error"));
            this.comboEYErrorProvider.SetError(this.comboBoxDataMode, resources.GetString("comboBoxDataMode.Error1"));
            this.comboEYErrorProvider.SetIconAlignment(this.comboBoxDataMode, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("comboBoxDataMode.IconAlignment"))));
            this.comboHYErrorProvider.SetIconAlignment(this.comboBoxDataMode, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("comboBoxDataMode.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.comboBoxDataMode, ((int)(resources.GetObject("comboBoxDataMode.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.comboBoxDataMode, ((int)(resources.GetObject("comboBoxDataMode.IconPadding1"))));
            this.comboBoxDataMode.Items.AddRange(new object[] {
            resources.GetString("comboBoxDataMode.Items"),
            resources.GetString("comboBoxDataMode.Items1")});
            this.comboBoxDataMode.Name = "comboBoxDataMode";
            // 
            // labelYUnit
            // 
            resources.ApplyResources(this.labelYUnit, "labelYUnit");
            this.comboHYErrorProvider.SetError(this.labelYUnit, resources.GetString("labelYUnit.Error"));
            this.comboEYErrorProvider.SetError(this.labelYUnit, resources.GetString("labelYUnit.Error1"));
            this.comboHYErrorProvider.SetIconAlignment(this.labelYUnit, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("labelYUnit.IconAlignment"))));
            this.comboEYErrorProvider.SetIconAlignment(this.labelYUnit, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("labelYUnit.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.labelYUnit, ((int)(resources.GetObject("labelYUnit.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.labelYUnit, ((int)(resources.GetObject("labelYUnit.IconPadding1"))));
            this.labelYUnit.Name = "labelYUnit";
            // 
            // labelY
            // 
            resources.ApplyResources(this.labelY, "labelY");
            this.comboHYErrorProvider.SetError(this.labelY, resources.GetString("labelY.Error"));
            this.comboEYErrorProvider.SetError(this.labelY, resources.GetString("labelY.Error1"));
            this.comboHYErrorProvider.SetIconAlignment(this.labelY, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("labelY.IconAlignment"))));
            this.comboEYErrorProvider.SetIconAlignment(this.labelY, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("labelY.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.labelY, ((int)(resources.GetObject("labelY.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.labelY, ((int)(resources.GetObject("labelY.IconPadding1"))));
            this.labelY.Name = "labelY";
            // 
            // labelHour
            // 
            resources.ApplyResources(this.labelHour, "labelHour");
            this.comboHYErrorProvider.SetError(this.labelHour, resources.GetString("labelHour.Error"));
            this.comboEYErrorProvider.SetError(this.labelHour, resources.GetString("labelHour.Error1"));
            this.comboHYErrorProvider.SetIconAlignment(this.labelHour, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("labelHour.IconAlignment"))));
            this.comboEYErrorProvider.SetIconAlignment(this.labelHour, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("labelHour.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.labelHour, ((int)(resources.GetObject("labelHour.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.labelHour, ((int)(resources.GetObject("labelHour.IconPadding1"))));
            this.labelHour.Name = "labelHour";
            // 
            // labelPeriod
            // 
            resources.ApplyResources(this.labelPeriod, "labelPeriod");
            this.comboHYErrorProvider.SetError(this.labelPeriod, resources.GetString("labelPeriod.Error"));
            this.comboEYErrorProvider.SetError(this.labelPeriod, resources.GetString("labelPeriod.Error1"));
            this.comboHYErrorProvider.SetIconAlignment(this.labelPeriod, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("labelPeriod.IconAlignment"))));
            this.comboEYErrorProvider.SetIconAlignment(this.labelPeriod, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("labelPeriod.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.labelPeriod, ((int)(resources.GetObject("labelPeriod.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.labelPeriod, ((int)(resources.GetObject("labelPeriod.IconPadding1"))));
            this.labelPeriod.Name = "labelPeriod";
            // 
            // labelMode
            // 
            resources.ApplyResources(this.labelMode, "labelMode");
            this.comboHYErrorProvider.SetError(this.labelMode, resources.GetString("labelMode.Error"));
            this.comboEYErrorProvider.SetError(this.labelMode, resources.GetString("labelMode.Error1"));
            this.comboHYErrorProvider.SetIconAlignment(this.labelMode, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("labelMode.IconAlignment"))));
            this.comboEYErrorProvider.SetIconAlignment(this.labelMode, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("labelMode.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.labelMode, ((int)(resources.GetObject("labelMode.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.labelMode, ((int)(resources.GetObject("labelMode.IconPadding1"))));
            this.labelMode.Name = "labelMode";
            // 
            // buttonDetrendOn
            // 
            resources.ApplyResources(this.buttonDetrendOn, "buttonDetrendOn");
            this.comboHYErrorProvider.SetError(this.buttonDetrendOn, resources.GetString("buttonDetrendOn.Error"));
            this.comboEYErrorProvider.SetError(this.buttonDetrendOn, resources.GetString("buttonDetrendOn.Error1"));
            this.comboHYErrorProvider.SetIconAlignment(this.buttonDetrendOn, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("buttonDetrendOn.IconAlignment"))));
            this.comboEYErrorProvider.SetIconAlignment(this.buttonDetrendOn, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("buttonDetrendOn.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.buttonDetrendOn, ((int)(resources.GetObject("buttonDetrendOn.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.buttonDetrendOn, ((int)(resources.GetObject("buttonDetrendOn.IconPadding1"))));
            this.buttonDetrendOn.Name = "buttonDetrendOn";
            this.buttonDetrendOn.UseVisualStyleBackColor = true;
            this.buttonDetrendOn.Click += new System.EventHandler(this.buttonDetrendOn_Click);
            // 
            // hScrollBar1
            // 
            resources.ApplyResources(this.hScrollBar1, "hScrollBar1");
            this.comboEYErrorProvider.SetError(this.hScrollBar1, resources.GetString("hScrollBar1.Error"));
            this.comboHYErrorProvider.SetError(this.hScrollBar1, resources.GetString("hScrollBar1.Error1"));
            this.comboEYErrorProvider.SetIconAlignment(this.hScrollBar1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("hScrollBar1.IconAlignment"))));
            this.comboHYErrorProvider.SetIconAlignment(this.hScrollBar1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("hScrollBar1.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.hScrollBar1, ((int)(resources.GetObject("hScrollBar1.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.hScrollBar1, ((int)(resources.GetObject("hScrollBar1.IconPadding1"))));
            this.hScrollBar1.Maximum = 86400;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.comboEYErrorProvider.SetError(this.statusStrip1, resources.GetString("statusStrip1.Error"));
            this.comboHYErrorProvider.SetError(this.statusStrip1, resources.GetString("statusStrip1.Error1"));
            this.comboHYErrorProvider.SetIconAlignment(this.statusStrip1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("statusStrip1.IconAlignment"))));
            this.comboEYErrorProvider.SetIconAlignment(this.statusStrip1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("statusStrip1.IconAlignment1"))));
            this.comboHYErrorProvider.SetIconPadding(this.statusStrip1, ((int)(resources.GetObject("statusStrip1.IconPadding"))));
            this.comboEYErrorProvider.SetIconPadding(this.statusStrip1, ((int)(resources.GetObject("statusStrip1.IconPadding1"))));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
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
            resources.ApplyResources(this.comboHYErrorProvider, "comboHYErrorProvider");
            // 
            // comboEYErrorProvider
            // 
            this.comboEYErrorProvider.ContainerControl = this;
            resources.ApplyResources(this.comboEYErrorProvider, "comboEYErrorProvider");
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
    }
}


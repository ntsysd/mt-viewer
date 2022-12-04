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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.comboHYErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.comboEYErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboHYErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboEYErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1660, 42);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.pageSetupToolStripMenuItem,
            this.printToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(67, 36);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(259, 40);
            this.openToolStripMenuItem.Text = "Open(&O)";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // pageSetupToolStripMenuItem
            // 
            this.pageSetupToolStripMenuItem.Name = "pageSetupToolStripMenuItem";
            this.pageSetupToolStripMenuItem.Size = new System.Drawing.Size(259, 40);
            this.pageSetupToolStripMenuItem.Text = "PageSetup(&S)";
            this.pageSetupToolStripMenuItem.Click += new System.EventHandler(this.pageSetupToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(259, 40);
            this.printToolStripMenuItem.Text = "Print(&P)";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(259, 40);
            this.exitToolStripMenuItem.Text = "Exit(&X)";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
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
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 42);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox1.Size = new System.Drawing.Size(1660, 128);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // yRangeValueLabel
            // 
            this.yRangeValueLabel.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.yRangeValueLabel.Location = new System.Drawing.Point(1062, 75);
            this.yRangeValueLabel.Name = "yRangeValueLabel";
            this.yRangeValueLabel.Size = new System.Drawing.Size(536, 24);
            this.yRangeValueLabel.TabIndex = 16;
            this.yRangeValueLabel.Text = "EY: 0000 EX: 0000  HX: 0000 HY: 0000 HZ: 00000000";
            this.yRangeValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBoxHY
            // 
            this.comboBoxHY.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxHY.FormattingEnabled = true;
            this.comboBoxHY.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.comboBoxHY.Items.AddRange(new object[] {
            "0.0001",
            "0.0005",
            "0.001",
            "0.01",
            "0.1",
            "0.2",
            "0.4",
            "0.8",
            "1",
            "2.5",
            "5.0",
            "10",
            "20",
            "AUTO"});
            this.comboBoxHY.Location = new System.Drawing.Point(1392, 26);
            this.comboBoxHY.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.comboBoxHY.Name = "comboBoxHY";
            this.comboBoxHY.Size = new System.Drawing.Size(112, 32);
            this.comboBoxHY.TabIndex = 14;
            // 
            // labelHY
            // 
            this.labelHY.AutoSize = true;
            this.labelHY.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelHY.Location = new System.Drawing.Point(1355, 27);
            this.labelHY.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelHY.Name = "labelHY";
            this.labelHY.Size = new System.Drawing.Size(25, 24);
            this.labelHY.TabIndex = 13;
            this.labelHY.Text = "H";
            // 
            // labelEYUnit
            // 
            this.labelEYUnit.AutoSize = true;
            this.labelEYUnit.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelEYUnit.Location = new System.Drawing.Point(1509, 30);
            this.labelEYUnit.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelEYUnit.Name = "labelEYUnit";
            this.labelEYUnit.Size = new System.Drawing.Size(89, 24);
            this.labelEYUnit.TabIndex = 15;
            this.labelEYUnit.Text = "Volt/FS";
            // 
            // buttonDetrendOff
            // 
            this.buttonDetrendOff.AutoSize = true;
            this.buttonDetrendOff.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonDetrendOff.Location = new System.Drawing.Point(189, 20);
            this.buttonDetrendOff.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonDetrendOff.Name = "buttonDetrendOff";
            this.buttonDetrendOff.Size = new System.Drawing.Size(92, 39);
            this.buttonDetrendOff.TabIndex = 2;
            this.buttonDetrendOff.Text = "OFF";
            this.buttonDetrendOff.UseVisualStyleBackColor = true;
            this.buttonDetrendOff.Click += new System.EventHandler(this.buttonDetrendOff_Click);
            this.buttonDetrendOff.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(10, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detrend";
            // 
            // button1Hz
            // 
            this.button1Hz.AutoSize = true;
            this.button1Hz.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1Hz.Location = new System.Drawing.Point(385, 20);
            this.button1Hz.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button1Hz.Name = "button1Hz";
            this.button1Hz.Size = new System.Drawing.Size(84, 39);
            this.button1Hz.TabIndex = 4;
            this.button1Hz.Text = "1Hz";
            this.button1Hz.UseVisualStyleBackColor = true;
            this.button1Hz.Click += new System.EventHandler(this.button1Hz_Click);
            this.button1Hz.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // button32Hz
            // 
            this.button32Hz.AutoSize = true;
            this.button32Hz.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button32Hz.Location = new System.Drawing.Point(303, 20);
            this.button32Hz.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button32Hz.Name = "button32Hz";
            this.button32Hz.Size = new System.Drawing.Size(85, 39);
            this.button32Hz.TabIndex = 3;
            this.button32Hz.Text = "32Hz";
            this.button32Hz.UseVisualStyleBackColor = true;
            this.button32Hz.Click += new System.EventHandler(this.button32Hz_Click);
            this.button32Hz.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // comboBoxEY
            // 
            this.comboBoxEY.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxEY.FormattingEnabled = true;
            this.comboBoxEY.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.comboBoxEY.Items.AddRange(new object[] {
            "0.0001",
            "0.0005",
            "0.001",
            "0.01",
            "0.1",
            "0.2",
            "0.4",
            "0.8",
            "1",
            "2.5",
            "5.0",
            "10",
            "20",
            "AUTO"});
            this.comboBoxEY.Location = new System.Drawing.Point(1110, 24);
            this.comboBoxEY.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.comboBoxEY.Name = "comboBoxEY";
            this.comboBoxEY.Size = new System.Drawing.Size(112, 32);
            this.comboBoxEY.TabIndex = 11;
            // 
            // comboBoxPeriod
            // 
            this.comboBoxPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPeriod.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxPeriod.FormattingEnabled = true;
            this.comboBoxPeriod.Location = new System.Drawing.Point(857, 22);
            this.comboBoxPeriod.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.comboBoxPeriod.Name = "comboBoxPeriod";
            this.comboBoxPeriod.Size = new System.Drawing.Size(97, 32);
            this.comboBoxPeriod.TabIndex = 8;
            this.comboBoxPeriod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // comboBoxDataMode
            // 
            this.comboBoxDataMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataMode.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxDataMode.Items.AddRange(new object[] {
            "PHX(15Hz)",
            "ADU(32Hz)"});
            this.comboBoxDataMode.Location = new System.Drawing.Point(565, 22);
            this.comboBoxDataMode.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.comboBoxDataMode.Name = "comboBoxDataMode";
            this.comboBoxDataMode.Size = new System.Drawing.Size(162, 32);
            this.comboBoxDataMode.TabIndex = 6;
            this.comboBoxDataMode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // labelYUnit
            // 
            this.labelYUnit.AutoSize = true;
            this.labelYUnit.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelYUnit.Location = new System.Drawing.Point(1228, 28);
            this.labelYUnit.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelYUnit.Name = "labelYUnit";
            this.labelYUnit.Size = new System.Drawing.Size(89, 24);
            this.labelYUnit.TabIndex = 12;
            this.labelYUnit.Text = "Volt/FS";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelY.Location = new System.Drawing.Point(1075, 27);
            this.labelY.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(24, 24);
            this.labelY.TabIndex = 10;
            this.labelY.Text = "E";
            // 
            // labelHour
            // 
            this.labelHour.AutoSize = true;
            this.labelHour.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelHour.Location = new System.Drawing.Point(967, 27);
            this.labelHour.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelHour.Name = "labelHour";
            this.labelHour.Size = new System.Drawing.Size(54, 24);
            this.labelHour.TabIndex = 9;
            this.labelHour.Text = "hour";
            // 
            // labelPeriod
            // 
            this.labelPeriod.AutoSize = true;
            this.labelPeriod.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPeriod.Location = new System.Drawing.Point(768, 27);
            this.labelPeriod.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelPeriod.Name = "labelPeriod";
            this.labelPeriod.Size = new System.Drawing.Size(74, 24);
            this.labelPeriod.TabIndex = 7;
            this.labelPeriod.Text = "Period";
            // 
            // labelMode
            // 
            this.labelMode.AutoSize = true;
            this.labelMode.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMode.Location = new System.Drawing.Point(495, 27);
            this.labelMode.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.labelMode.Name = "labelMode";
            this.labelMode.Size = new System.Drawing.Size(64, 24);
            this.labelMode.TabIndex = 5;
            this.labelMode.Text = "Mode";
            // 
            // buttonDetrendOn
            // 
            this.buttonDetrendOn.AutoSize = true;
            this.buttonDetrendOn.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonDetrendOn.Location = new System.Drawing.Point(115, 20);
            this.buttonDetrendOn.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.buttonDetrendOn.Name = "buttonDetrendOn";
            this.buttonDetrendOn.Size = new System.Drawing.Size(78, 39);
            this.buttonDetrendOn.TabIndex = 1;
            this.buttonDetrendOn.Text = "ON";
            this.buttonDetrendOn.UseVisualStyleBackColor = true;
            this.buttonDetrendOn.Click += new System.EventHandler(this.buttonDetrendOn_Click);
            this.buttonDetrendOn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 170);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1660, 554);
            this.splitContainer1.SplitterDistance = 452;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 2;
            this.splitContainer1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1660, 452);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tabPage1.Size = new System.Drawing.Size(1652, 420);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ELOG";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(1660, 96);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 724);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(1660, 17);
            this.hScrollBar1.TabIndex = 2;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            this.hScrollBar1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 741);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 23, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1660, 38);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(100, 31);
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1660, 779);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.statusStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainWindow_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
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


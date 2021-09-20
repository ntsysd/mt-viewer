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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pageSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button32Hz = new System.Windows.Forms.Button();
            this.comboBoxY = new System.Windows.Forms.ComboBox();
            this.comboBoxPeriod = new System.Windows.Forms.ComboBox();
            this.comboBoxDataMode = new System.Windows.Forms.ComboBox();
            this.labelYUnit = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelHour = new System.Windows.Forms.Label();
            this.labelPeriod = new System.Windows.Forms.Label();
            this.labelMode = new System.Windows.Forms.Label();
            this.buttonDetrend = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button1Hz = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.pageSetupToolStripMenuItem,
            this.printToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 25);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.openToolStripMenuItem.Text = "Open(&O)";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // pageSetupToolStripMenuItem
            // 
            this.pageSetupToolStripMenuItem.Name = "pageSetupToolStripMenuItem";
            this.pageSetupToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.pageSetupToolStripMenuItem.Text = "PageSetup(&S)";
            this.pageSetupToolStripMenuItem.Click += new System.EventHandler(this.pageSetupToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.printToolStripMenuItem.Text = "Print(&P)";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(173, 26);
            this.exitToolStripMenuItem.Text = "Exit(&X)";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1Hz);
            this.groupBox1.Controls.Add(this.button32Hz);
            this.groupBox1.Controls.Add(this.comboBoxY);
            this.groupBox1.Controls.Add(this.comboBoxPeriod);
            this.groupBox1.Controls.Add(this.comboBoxDataMode);
            this.groupBox1.Controls.Add(this.labelYUnit);
            this.groupBox1.Controls.Add(this.labelY);
            this.groupBox1.Controls.Add(this.labelHour);
            this.groupBox1.Controls.Add(this.labelPeriod);
            this.groupBox1.Controls.Add(this.labelMode);
            this.groupBox1.Controls.Add(this.buttonDetrend);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 45);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // button32Hz
            // 
            this.button32Hz.AutoSize = true;
            this.button32Hz.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button32Hz.Location = new System.Drawing.Point(133, 13);
            this.button32Hz.Name = "button32Hz";
            this.button32Hz.Size = new System.Drawing.Size(51, 26);
            this.button32Hz.TabIndex = 9;
            this.button32Hz.Text = "32Hz";
            this.button32Hz.UseVisualStyleBackColor = true;
            this.button32Hz.Click += new System.EventHandler(this.button32Hz_Click);
            // 
            // comboBoxY
            // 
            this.comboBoxY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxY.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxY.FormattingEnabled = true;
            this.comboBoxY.Items.AddRange(new object[] {
            "0.0001",
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
            this.comboBoxY.Location = new System.Drawing.Point(657, 15);
            this.comboBoxY.Name = "comboBoxY";
            this.comboBoxY.Size = new System.Drawing.Size(69, 24);
            this.comboBoxY.TabIndex = 8;
            // 
            // comboBoxPeriod
            // 
            this.comboBoxPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPeriod.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxPeriod.FormattingEnabled = true;
            this.comboBoxPeriod.Items.AddRange(new object[] {
            "0.017",
            "0.1",
            "0.2",
            "0.5",
            "1",
            "2",
            "4",
            "8",
            "12",
            "24"});
            this.comboBoxPeriod.Location = new System.Drawing.Point(514, 15);
            this.comboBoxPeriod.Name = "comboBoxPeriod";
            this.comboBoxPeriod.Size = new System.Drawing.Size(60, 24);
            this.comboBoxPeriod.TabIndex = 7;
            // 
            // comboBoxDataMode
            // 
            this.comboBoxDataMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataMode.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBoxDataMode.Items.AddRange(new object[] {
            "PHX(15Hz)",
            "ADU(32Hz)"});
            this.comboBoxDataMode.Location = new System.Drawing.Point(310, 15);
            this.comboBoxDataMode.Name = "comboBoxDataMode";
            this.comboBoxDataMode.Size = new System.Drawing.Size(122, 24);
            this.comboBoxDataMode.TabIndex = 6;
            // 
            // labelYUnit
            // 
            this.labelYUnit.AutoSize = true;
            this.labelYUnit.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelYUnit.Location = new System.Drawing.Point(728, 18);
            this.labelYUnit.Name = "labelYUnit";
            this.labelYUnit.Size = new System.Drawing.Size(62, 16);
            this.labelYUnit.TabIndex = 5;
            this.labelYUnit.Text = "Volt/FS";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelY.Location = new System.Drawing.Point(638, 18);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(17, 16);
            this.labelY.TabIndex = 4;
            this.labelY.Text = "Y";
            // 
            // labelHour
            // 
            this.labelHour.AutoSize = true;
            this.labelHour.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelHour.Location = new System.Drawing.Point(580, 18);
            this.labelHour.Name = "labelHour";
            this.labelHour.Size = new System.Drawing.Size(38, 16);
            this.labelHour.TabIndex = 3;
            this.labelHour.Text = "hour";
            // 
            // labelPeriod
            // 
            this.labelPeriod.AutoSize = true;
            this.labelPeriod.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPeriod.Location = new System.Drawing.Point(461, 18);
            this.labelPeriod.Name = "labelPeriod";
            this.labelPeriod.Size = new System.Drawing.Size(51, 16);
            this.labelPeriod.TabIndex = 2;
            this.labelPeriod.Text = "Period";
            // 
            // labelMode
            // 
            this.labelMode.AutoSize = true;
            this.labelMode.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMode.Location = new System.Drawing.Point(268, 18);
            this.labelMode.Name = "labelMode";
            this.labelMode.Size = new System.Drawing.Size(44, 16);
            this.labelMode.TabIndex = 1;
            this.labelMode.Text = "Mode";
            // 
            // buttonDetrend
            // 
            this.buttonDetrend.AutoSize = true;
            this.buttonDetrend.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonDetrend.Location = new System.Drawing.Point(24, 13);
            this.buttonDetrend.Name = "buttonDetrend";
            this.buttonDetrend.Size = new System.Drawing.Size(92, 26);
            this.buttonDetrend.TabIndex = 0;
            this.buttonDetrend.Text = "Detrend";
            this.buttonDetrend.UseVisualStyleBackColor = true;
            this.buttonDetrend.Click += new System.EventHandler(this.buttonDetrend_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 74);
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
            this.splitContainer1.Size = new System.Drawing.Size(800, 337);
            this.splitContainer1.SplitterDistance = 111;
            this.splitContainer1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 111);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 85);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ELOG";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(800, 222);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrollBar1.Location = new System.Drawing.Point(0, 411);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(800, 17);
            this.hScrollBar1.TabIndex = 3;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(100, 17);
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1Hz
            // 
            this.button1Hz.AutoSize = true;
            this.button1Hz.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1Hz.Location = new System.Drawing.Point(183, 13);
            this.button1Hz.Name = "button1Hz";
            this.button1Hz.Size = new System.Drawing.Size(51, 26);
            this.button1Hz.TabIndex = 10;
            this.button1Hz.Text = "1Hz";
            this.button1Hz.UseVisualStyleBackColor = true;
            this.button1Hz.Click += new System.EventHandler(this.button1Hz_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.hScrollBar1);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
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
        private System.Windows.Forms.ComboBox comboBoxY;
        private System.Windows.Forms.ComboBox comboBoxPeriod;
        private System.Windows.Forms.ComboBox comboBoxDataMode;
        private System.Windows.Forms.Label labelYUnit;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelHour;
        private System.Windows.Forms.Label labelPeriod;
        private System.Windows.Forms.Label labelMode;
        private System.Windows.Forms.Button buttonDetrend;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button32Hz;
        private System.Windows.Forms.Button button1Hz;
    }
}


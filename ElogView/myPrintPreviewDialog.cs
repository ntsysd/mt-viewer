using System;
using System.Windows.Forms;

namespace ElogView
{
    public class myPrintPreviewDialog : System.Windows.Forms.PrintPreviewDialog
    {
        public myPrintPreviewDialog()
        {
            InitializeComponent();

            ToolStrip ts = (ToolStrip)this.Controls[1];
            ToolStripButton newPrintButtun = new System.Windows.Forms.ToolStripButton();
            newPrintButtun.Image = ts.Items[0].Image;
            newPrintButtun.ImageTransparentColor = ts.Items[0].ImageTransparentColor;
            newPrintButtun.Name = ts.Items[0].Name;
            newPrintButtun.Size = ts.Items[0].Size;
            newPrintButtun.Text = ts.Items[0].Text;
            ts.Items.RemoveAt(0);
            ts.Items.Insert(0, newPrintButtun);
            newPrintButtun.Click += NewPrintButtun_Click;
        }

        private void NewPrintButtun_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = Document;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                Document.Print();
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // myPrintPreviewDialog
            // 
            this.ClientSize = new System.Drawing.Size(639, 420);
            this.Name = "myPrintPreviewDialog";
            this.ResumeLayout(false);

        }
    }
}

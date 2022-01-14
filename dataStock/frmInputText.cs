using System;
using System.Windows.Forms;

namespace Giwer.dataStock
{
    public partial class frmInputText : Form
    {
        public frmInputText(string header)
        {
            InitializeComponent();
            this.Text = header;
            label1.Text = header;
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bttnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

using System;
using System.Windows.Forms;

namespace Giwer.dataStock
{
    public partial class frmTextInput : Form
    {
        public string inpuText = "";
        public frmTextInput(string label)
        {
            InitializeComponent();
            lblTitle.Text = label;
            this.Text = label; // "Text input box";
            this.ActiveControl = tbText;
        }


        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            inpuText = "";
        }

        private void bttnOk_Click(object sender, EventArgs e)
        {
            inpuText = tbText.Text;
            this.DialogResult = DialogResult.OK;
        }

    }
}

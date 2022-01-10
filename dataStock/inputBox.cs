using System;
using System.Windows.Forms;

namespace Giwer.dataStock
{
    public partial class inputBox : Form
    {
        public enum opType { Plus, Minus, Exor };
        public opType operationType;
        //GeoImageTools gm = new GeoImageTools();
        public inputBox(string Operation)
        {
            InitializeComponent();   
            this.Text = Operation;            
        }


        private void cmbOperation_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbCombination.Text = "(Current band) " + cmbOperation.SelectedItem.ToString() + " (band#0 from selected image)";
            switch (cmbOperation.SelectedItem.ToString())
            {
                case "Plus":
                    operationType = opType.Plus;
                    break;
                case "Minus":
                    operationType = opType.Minus;
                    break;
                case "Xor":
                    operationType = opType.Exor;
                    break;
            }
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bttnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

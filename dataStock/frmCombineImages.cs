using System;
using System.Windows.Forms;

namespace Giwer.dataStock
{
    public partial class frmCombineImages : Form
    {
        public enum opType { Plus, Minus, Exor };
        public opType operationType;
        GeoImageData gimda;
        public string filename1 = "";
        public string filename2 = "";
        public frmCombineImages(GeoImageData gmd)
        {
            gimda = gmd;
            InitializeComponent();
            fillCombo();
            cmbBand1.SelectedIndex = 0;
            cmbBand2.SelectedIndex = 1;
            cmbOperationType.SelectedIndex = 1;
        }

        void fillCombo()
        {
            for (int i = 0; i < gimda.Nbands; i++)
            {
                cmbBand1.Items.Add(i);
                cmbBand2.Items.Add(i);
            }
        }

        private void bttnCombineOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            filename1 = System.IO.Path.GetDirectoryName(gimda.FileName) + "\\" + System.IO.Path.GetFileNameWithoutExtension(gimda.FileName) + "\\" + cmbBand1.SelectedItem + ".gwr";
            filename2 = System.IO.Path.GetDirectoryName(gimda.FileName) + "\\" + System.IO.Path.GetFileNameWithoutExtension(gimda.FileName) + "\\" + cmbBand2.SelectedItem + ".gwr";
            this.Close();
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cmbOperationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbOperationType.SelectedItem.ToString())
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
    }
}

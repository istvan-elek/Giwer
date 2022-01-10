using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Giwer.dataStock
{
    public partial class frmPCA : Form
    {
        GeoImageData gida;
        string GiwerDataFolder;
        public byte[] PCN;

        public frmPCA(GeoImageData gd, string dirGWR)
        {
            InitializeComponent();
            GiwerDataFolder = dirGWR;
            gida = gd;
            initCheckList(gida.Nbands);
            this.DialogResult = DialogResult.Cancel;
        }

        void initCheckList(int nBands)
        {
            for (int i=0; i< nBands; i++)
            {
                chkListBands.Items.Add(i);
                chkListBands.SetItemChecked(i, true);
                cmbWhichPC.Items.Add(i+1);
            }
            cmbWhichPC.SelectedIndex = 0;
        }

        private void chkbBands_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbBands.Checked)
            {
                chkbBands.Checked = true;
                selectAllChkListItems(true);
            }
            else
            {
                chkbBands.Checked = false;
                selectAllChkListItems(false);
            }
        }

        void selectAllChkListItems(Boolean flag)
        {
            bttnOKCorr.Enabled = flag;
            for (int i=0; i< chkListBands.Items.Count; i++)
            {
                chkListBands.SetItemChecked(i, flag);
            }
        }

        private void bttnOK_Click(object sender, EventArgs e)
        {
            if (chkListBands.CheckedItems.Count==0) { return; }
            this.Cursor = Cursors.WaitCursor;
            List<int> lst4PCA = new List<int>(gida.Nbands);
            foreach (var item in chkListBands.CheckedItems)
            {
                lst4PCA.Add((int)item);
            }
            GeoImageTools gimt = new GeoImageTools(gida);
            StatMath sm = new StatMath(gida, gimt, GiwerDataFolder);
            double[,] corr = sm.computeCorrelationMatrix(lst4PCA);
            printCorrelationMatrix(corr, lst4PCA.Count);
            double[] pca = sm.PCA(lst4PCA, sm.EigenVectors(corr), cmbWhichPC.SelectedIndex);
            PCN = pca.Select(n => { return Convert.ToByte(n); }).ToArray();
            this.Cursor = Cursors.Default;
            bttnComputePCs.Enabled = true;
            //this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        void printCorrelationMatrix(double[,] cor, int N)
        {
            string line = "";
            tbCorr.Text = "";
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    line += cor[i, j].ToString("F3") + "\t"; 
                }
                tbCorr.AppendText(line + Environment.NewLine);
                line = "";
            }
        }

        private void chkListBands_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkListBands.CheckedItems.Count > 0) { bttnOKCorr.Enabled = true; } else {bttnOKCorr.Enabled = false; }
        }

        private void frmPCA_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        private void bttnComputePCs_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

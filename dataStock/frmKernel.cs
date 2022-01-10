using System;
using System.Drawing;
using System.Windows.Forms;

namespace Giwer.dataStock
{
    public partial class frmKernel : Form
    {
        public int kernelLength;
        public int limitPixels;
        public double[,] Kernel;
        public int threshold = 0;
        byte[] byteIn;
        int maxkernelSize=51;
        string filterName;
        
        public frmKernel(string filtername)
        {
            InitializeComponent();
            filterName = filtername;
            setUpGroups();
        }

        public frmKernel(string filtername,byte[] byIn)
        {
            InitializeComponent();
            filterName = filtername;
            setUpGroups();
            byteIn = byIn;
        }

        void setUpGroups()
        {
            switch (filterName)
            {
                case "median":
                    this.Size = new Size(250, 120);
                    grpMedian.Dock = DockStyle.Fill;
                    grpMedian.Visible = true;
                    grpMedian.BringToFront();
                    bttnOK.BringToFront();
                    grpFilters.Visible = false;
                    grpThreshold.Visible = false;
                    fillComboMedian();
                    break;
                case "gauss":
                    this.Size = new Size(300, 300);
                    grpFilters.Dock = DockStyle.Fill;
                    grpMedian.Visible = false;
                    grpThreshold.Visible = false;
                    grpFilters.Text = "Gauss filter's kernel";
                    grpFilters.Visible = true;
                    grpFilters.BringToFront();
                    bttnOK.BringToFront();
                    fillComboGauss();
                    break;
                case "sinc":
                    this.Size = new Size(300, 300);
                    grpFilters.Dock = DockStyle.Fill;
                    grpMedian.Visible = false;
                    grpThreshold.Visible = false;
                    grpFilters.Visible = true;
                    grpFilters.Text = "Sinc filter's kernel";
                    grpFilters.BringToFront();
                    bttnOK.BringToFront();
                    fillComboGauss();
                    break;
                case "threshold":
                    this.Size = new Size(250, 120);
                    grpThreshold.Dock = DockStyle.Fill;
                    grpMedian.Visible = false;
                    grpFilters.Visible = false;
                    grpThreshold.Visible = true;
                    grpThreshold.BringToFront();
                    bttnOK.BringToFront();
                    break;
                case "highpass":
                    this.Size = new Size(300, 300);
                    grpFilters.Dock = DockStyle.Fill;
                    grpMedian.Visible = false;
                    grpThreshold.Visible = false;
                    grpFilters.Text = "High-pass filter's kernel";
                    grpFilters.Visible = true;
                    grpFilters.BringToFront();
                    bttnOK.BringToFront();
                    fillComboGauss();
                    break;


            }
        }

        void fillComboMedian()
        {
            for (int i=3; i< maxkernelSize; i+=2) { cmbMedianLength.Items.Add(i); }
        }

        void fillComboGauss()
        {
            for (int i = 1; i < maxkernelSize/2; i++) { cmbPixelNumber.Items.Add(i); }
        }

        private void cmbLenght_SelectedIndexChanged(object sender, EventArgs e)
        {
            kernelLength = Convert.ToInt16(cmbMedianLength.SelectedItem);
            bttnOK.Enabled = true;
        }

        private void bttnOK_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


        private void cmbPixelNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            limitPixels = Convert.ToInt16(cmbPixelNumber.SelectedItem);
            bttnComputeKernel.Enabled = true;
        }

        private void bttnComputeKernel_Click_1(object sender, EventArgs e)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();
            Filter Kernels = new Filter();
            if (filterName == "gauss")
            {
                Kernel = Kernels.lowPassKernelGauss(limitPixels);
            }
            if (filterName == "sinc")
            {
                Kernel = Kernels.lowPassKernelSinc(limitPixels);
            }
            if (filterName == "highpass")
            {
                Kernel = Kernels.highPassKernel(limitPixels);
            }


            kernelLength = (int)Math.Sqrt(Kernel.Length);
            for (int i = 0; i < kernelLength; i++)
            {
                dgv.Columns.Add(i.ToString(), "");
            }

            for (int i = 0; i < kernelLength; i++)
            {
                dgv.Rows.Add();
            }

            for (int j = 0; j < kernelLength; j++)
            {
                dgv.Rows[j].HeaderCell.Value = (j + 1).ToString();
                for (int i = 0; i < kernelLength; i++)
                {
                    dgv.Rows[j].Cells[i].Value = Kernel[i, j];
                }
            }
            dgv.RowHeadersWidth = 50;
            bttnOK.Enabled = true;
        }

        private void tbThreshold_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbThreshold.Text=="Threshold value") { tbThreshold.Text = ""; }
            int parsedValue;
            if (e.KeyCode == Keys.Enter)
            {
                if (!int.TryParse(tbThreshold.Text, out parsedValue))
                {
                    MessageBox.Show("This is a number only field");
                    return;
                }
                else
                {
                    threshold = parsedValue;
                    bttnOK.Enabled = true;
                    this.AcceptButton = bttnOK;
                }
            }
        }

        private void bttnShowHisto_Click(object sender, EventArgs e)
        {
            Histogram3 histo = new Histogram3(byteIn, "");
            histo.bttnRecalcEqualiz.Text = "Set threshold";
            if (histo.ShowDialog()==DialogResult.OK)
            {
                threshold = histo.IntMin;
                tbThreshold.Text = threshold.ToString();
                bttnOK_Click_1(sender, e);
            }
        }

        private void dgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int selectedRow = e.RowIndex;
            DataGridViewRow row = dgv.SelectedRows[0];
            int rowLength = dgv.Columns.Count;
            float[] val = new float[rowLength];
            for (int i=0; i<rowLength;i++)
            {
                val[i] = Convert.ToSingle( row.Cells[i].Value);
            }
            string[] minmax= getMinMax(Kernel);
            Single min = Convert.ToSingle(minmax[0]);
            Single max = Convert.ToSingle(minmax[1]);
            frmShowKernel showKern = new frmShowKernel(val,min,max,e.RowIndex+1);
            showKern.Show();
        }

        string[] getMinMax(double[,] k)
        {
            string[] minmax = new string[2];
            float max = -10000F;
            float min = 10000F;
            foreach (float item in k)
            {
                if (item > max) { max = item; }
                if (item < min) { min = item; }
            }
            minmax[0] = min.ToString();
            minmax[1] = max.ToString();
            return minmax;
        }

    }
}

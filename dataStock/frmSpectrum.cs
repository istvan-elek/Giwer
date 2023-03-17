using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SQLite;

namespace Giwer.dataStock
{
    public partial class frmSpectrum : Form
    {
        //DataTable spectrum2Save;
        string[] waves;
        Point[] specPoints;
        int lastSelectedSpecIndex=0;
        Color valueColor = Color.DeepSkyBlue;
        frmConfig conf = new frmConfig();
        string SpectrumBankPath;
        string SpectrumBankName;
        SQLiteConnectionStringBuilder cnsb = new SQLiteConnectionStringBuilder();

        public frmSpectrum()
        {
            InitializeComponent();
        }

        DataTable loadTableData(string cmdSql)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                try
                {
                    cnn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(cmdSql, cnn))
                    {
                        SQLiteDataReader dr = cmd.ExecuteReader();
                        dt.Load(dr);
                    }
                    return dt;
                }
                catch (SQLiteException e)
                {
                    //throw;
                    MessageBox.Show("Error in SQL command:" + e.Message, "Sql error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        #region chart functions
        public void displaySpectrum(Point[] pnt, string[] wave)
        {
            waves = wave;
            specPoints = pnt;
            int[] x = new int[pnt.Length];
            int[] y = new int[pnt.Length];
              for (int i = 0; i < pnt.Length; i++)
            {
                x[i] = pnt[i].X;
                y[i] = pnt[i].Y;
            }
            //chart1.Series[0].Points.Clear();           
            chart1.Series[0].Points.DataBindXY(x, y);
            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 9, System.Drawing.FontStyle.Regular);
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 9, System.Drawing.FontStyle.Regular);
            chart1.ChartAreas[0].AxisX.Maximum = pnt.Length-1;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            int n = 10 * (2 * (pnt.Length / 10) / 5);
            chart1.ChartAreas[0].AxisX.Interval = n;
            chart1.ChartAreas[0].AxisY.Maximum = 255;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Interval = 50;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisX.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.MajorTickMark.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisX.Title = "Bands";
            chart1.ChartAreas[0].AxisY.Title = "Intensity";
            chart1.Series[0].ChartType = SeriesChartType.Column;
            chart1.Series[0].Color = valueColor;
            this.dgv1.DefaultCellStyle.Font = new Font("Tahoma", 8);
            bttnSaveSpectrum.Visible = true;
            label1.Visible = true;
            cmbBankName.Visible = true;
            label2.Visible = true;
            tbCathegoryName.Visible = true;
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (chart1.Series[0].Points.Count==0) return;
            HitTestResult hit = chart1.HitTest(e.X, e.Y);
            //dgv1.ClearSelection();
            //if (hit.PointIndex >-1) dgv1.Rows[hit.PointIndex].Selected = true;
            if (waves != null)
            {
                if (hit.PointIndex >= 0) this.Text = "Wavelength [nm]: " + waves[hit.PointIndex];  
                else this.Text = "Spectrum ";
            }
            else
            {
                if (hit.PointIndex >= 0) this.Text = "Band: " + hit.PointIndex;  //+ hit.PointIndex;
                else this.Text = "Spectrum ";
            }
        }

        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            HitTestResult hit = chart1.HitTest(e.X, e.Y);
            dgv1.ClearSelection();
            if (hit.PointIndex > -1)
            {
                dgv1.Rows[hit.PointIndex].Selected = true;
                dgv1.CurrentCell = dgv1.Rows[hit.PointIndex].Cells[0];
                highlightValue(hit.PointIndex);
            }
        }

        private void chart1_MouseUp(object sender, MouseEventArgs e)
        {
            //HitTestResult hit = chart1.HitTest(e.X, e.Y);
        }

        #endregion
        public void showSpectrumAsTable(Point[] pnt, string[] waves)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("band");
            dt.Columns.Add("wavelength");
            dt.Columns.Add("intensity");
            for (int i = 0; i < pnt.Length; i++)
            {
                if (waves != null) dt.Rows.Add(pnt[i].X, waves[i], pnt[i].Y);
                else dt.Rows.Add(pnt[i].X, null, pnt[i].Y);
            }
            dgv1.DataSource = dt;
        }

        public void spectrumInit()
        {
            dgv1.DataSource = null;
            chart1.Series[0].Points.Clear();
            bttnSaveSpectrum.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            cmbBankName.Visible = false;
            tbCathegoryName.Visible = false;
        }



        void highlightValue(int index)
        {
            chart1.Series[0].Points[lastSelectedSpecIndex].Color = valueColor;
            HitTestResult hit = chart1.HitTest(0,0);
            hit.PointIndex = index;
            if (hit.PointIndex > -1)
            {
                chart1.Series[0].Points[hit.PointIndex].Color = Color.Orange;
                lastSelectedSpecIndex = hit.PointIndex;
            }
        }

        private void dgv1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            highlightValue(e.RowIndex);
        }

        private void bttnSaveSpectrum_Click(object sender, EventArgs e)
        {
            if (cmbBankName.SelectedItem == null) { MessageBox.Show("Missing bank name, select one."); return; }
            if (tbCathegoryName.Text == "") { MessageBox.Show("Missing 'cathegory', which is mandatory"); return; }
            insertNewSpectrum();

        }

        private void cmbBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            SpectrumBankName = cmbBankName.SelectedItem.ToString();
        }

        void insertNewSpectrum()
        {
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                cnn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand())
                {
                    cmd.Connection = cnn;
                    foreach(DataGridViewRow row in dgv1.Rows)
                    {
                        cmd.CommandText = "INSERT INTO spectrums " + "(bankname,name,band,wavelength,intensity) VALUES('" + SpectrumBankName + "','" + tbCathegoryName.Text + "',"+ row.Cells["band"].Value + ",'" + row.Cells["wavelength"].Value + "'," + row.Cells["intensity"].Value + ")";
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Spectrum has been saved");
                }
            }
        }

        private void frmSpectrum_Load(object sender, EventArgs e)
        {
            chart1.Legends.Clear();
            this.Text = "Spectrum in the selected point";
            SpectrumBankPath = conf.config["SpectrumBankPath"];
            if (System.IO.File.Exists(SpectrumBankPath))
            {
                tslblSpectrumBankName.Text = SpectrumBankPath;
                cnsb.DataSource = SpectrumBankPath;
                cnsb.Version = 3;
                DataTable dt = loadTableData("select bankname from banks");
                if (dt == null) return;
                foreach (DataRow dr in dt.Rows)
                {
                    cmbBankName.Items.Add(dr[0]);
                }
            }
            else 
            {
                OpenFileDialog of = new OpenFileDialog();
                of.Filter = "Spectrumbank files|*.s3db";
                if (of.ShowDialog()==DialogResult.OK)
                {
                    SpectrumBankPath = System.IO.Path.GetDirectoryName(SpectrumBankPath);
                    tslblSpectrumBankName.Text = SpectrumBankPath;
                    cnsb.DataSource = SpectrumBankPath;
                    cnsb.Version = 3;
                    DataTable dt = loadTableData("select bankname from banks");
                    if (dt == null) return;
                    foreach (DataRow dr in dt.Rows)
                    {
                        cmbBankName.Items.Add(dr[0]);
                    }
                }
            }
        }

        private void frmSpectrum_Activated(object sender, EventArgs e)
        {
            SpectrumBankPath = conf.config["SpectrumBankPath"];
            tslblSpectrumBankName.Text = SpectrumBankPath;
        }
    }
}

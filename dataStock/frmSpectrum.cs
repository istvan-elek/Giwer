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
using System.IO;

namespace Giwer.dataStock
{
    public partial class frmSpectrum : Form
    {
        //GeoImageData gida;
        string[] waves;
        Point[] specPoints;
        int lastSelectedSpecIndex=0;
        Color valueColor = Color.DeepSkyBlue;
        public frmSpectrum()
        {
            InitializeComponent();
            chart1.Legends.Clear();
        }


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

        void showSpectrumAsTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Band");
            dt.Columns.Add("Wavelength");
            dt.Columns.Add("Value");
            for (int i=0; i< chart1.Series[0].Points.Count;i++)
            {
                if (waves !=null) dt.Rows.Add(chart1.Series[0].Points[i].XValue, waves[i], chart1.Series[0].Points[i].YValues[0]);
                else dt.Rows.Add(chart1.Series[0].Points[i].XValue, null, chart1.Series[0].Points[i].YValues[0]);
            }
            dgv1.DataSource = dt;
        }

        public void showSpectrumAsTable(Point[] pnt, string[] waves)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Band");
            dt.Columns.Add("Wavelength");
            dt.Columns.Add("Value");
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
        }

        private void chart1_MouseUp(object sender, MouseEventArgs e)
        {
            //HitTestResult hit = chart1.HitTest(e.X, e.Y);


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
            frmSpectrumBank specBank = new frmSpectrumBank();
            specBank.Show();
            //SaveFileDialog sf = new SaveFileDialog();
            //sf.Filter = "Spectrum bank files (*.spb)| *.spb";
            //if (sf.ShowDialog()==DialogResult.OK)
            //{
            //    saveCurrentSpectrum(sf.FileName);
            //}
        }

        void saveCurrentSpectrum(string filename)
        {
            using (FileStream fs = new FileStream(filename,FileMode.OpenOrCreate,FileAccess.Write))
            {
                using (StreamWriter sw= new StreamWriter(fs))
                {
                    DataTable dtGridSource = (DataTable)dgv1.DataSource;
                    StringBuilder line = new StringBuilder();
                    line.Append(dgv1.Columns[0].Name + "; ");
                    line.Append(dgv1.Columns[1].Name + "; ");
                    line.Append(dgv1.Columns[2].Name);
                    sw.WriteLine(line);
                    foreach (DataRow row in dtGridSource.Rows)
                    {
                        line.Clear();
                        object[] arr = row.ItemArray;
                        for (int i = 0; i < arr.Length; i++)
                        {
                            line.Append(Convert.ToString(arr[i]));
                            if (i< arr.Length-1 )line.Append(";");
                        }
                        sw.WriteLine(line);
                    }
                }
            }
        }
    }
}

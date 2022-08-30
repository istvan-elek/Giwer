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

namespace Giwer.dataStock
{
    public partial class frmChart : Form
    {
        public frmChart()
        {
            InitializeComponent();
        }

        public void displaySpectrum(DataTable dt)  //Point[] pnt, string[] wave)
        {
            int pntCount = dt.Rows.Count;
            int[] x = new int[pntCount];
            int[] y = new int[pntCount];
            for (int i = 0; i < pntCount; i++)
            {
                x[i] = int.Parse(dt.Rows[i]["band"].ToString());
                y[i] = int.Parse(dt.Rows[i]["intensity"].ToString());
            }
            //chart1.Series[0].; // = false;
            chart1.Series[0].Points.DataBindXY(x, y);
            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 9, System.Drawing.FontStyle.Regular);
            chart1.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 9, System.Drawing.FontStyle.Regular);
            chart1.ChartAreas[0].AxisX.Maximum = pntCount - 1;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            int n = 10 * (2 * (pntCount / 10) / 5);
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

        }



        private void frmChart_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Close();
            //this.Dispose();
        }
    }
}

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

namespace dataStock
{
    public partial class histogram : Form
    {
        int bandNumber;
        public int IntMin = 0;
        public int IntMax = 0;
        string fname;
        float[] reHisto = new float[256];
        public histogram(float[] histogramIn, int band,string fileName)
        {
            InitializeComponent();
            reHisto = histogramIn;
            fname = fileName;
            bandNumber = band;
            drawDiagram(histogramIn,fileName,0,255);
            this.Text = "Histogram of " + System.IO.Path.GetFileName(fileName);
            label2.Text = "Left mouse click: Set min value \r\nRight  mouse click: set max value";
            this.DialogResult = DialogResult.No;
        }


        private void drawDiagram(float[] histog, string fname, int min, int max)
        {
            ch1.ChartAreas[0].AxisX.Title = "Intensity"; 
            ch1.ChartAreas[0].AxisY.Title = "Occurrence (normed)";  
            ch1.ChartAreas[0].AxisX.Maximum = max;
            ch1.ChartAreas[0].AxisX.Minimum = min;
            ch1.ChartAreas[0].AxisX.Interval = 50;
            ch1.ChartAreas[0].AxisY.Maximum = 1;
            ch1.ChartAreas[0].AxisY.Minimum = 0;
            ch1.BackColor = System.Drawing.Color.White;
            ch1.Titles.Clear();
            ch1.Titles.Add("Band:" + bandNumber.ToString() );
            int[] x = new int[256];
            for (int i = 0; i < 256; i++) { x[i] = i; }
            ch1.Series[0].Name = "Gray";
            ch1.Series[0].ChartType = SeriesChartType.Column;
            ch1.Series[0].BorderWidth = 1;
            ch1.Series[0].Points.DataBindXY(x, histog);
            ch1.Series[0].Color = System.Drawing.Color.Black;

            float[] cumulativeHisto=new float[histog.Length];
            float sum=0;
            for (int i = 0; i < histog.Length; i++) 
            { 
                sum += histog[i]; 
                cumulativeHisto[i] = sum; 
            }
            float cumMax = cumulativeHisto.Max();
            for (int i = 0; i < histog.Length; i++) { cumulativeHisto[i] /= cumMax; }
            ch1.Series[1].Name = "Cumulative";
            ch1.Series[1].ChartType = SeriesChartType.Line;
            ch1.Series[1].BorderWidth = 2;
            ch1.Series[1].Points.DataBindXY(x, cumulativeHisto);
            ch1.Series[1].Color = System.Drawing.Color.Gray;
        }

        private void ch1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblIntensityMin.Text = "Min value: " + ch1.ChartAreas[0].AxisX.PixelPositionToValue(e.X).ToString("##");
                IntMin = Convert.ToInt16(ch1.ChartAreas[0].AxisX.PixelPositionToValue(e.X).ToString("##"));
                ch1.Series[2].Points[0].XValue = IntMin;
                ch1.Series[2].Points[0].YValues[0] = 10;
                drawDiagram(reHisto, fname, IntMin, IntMax);

            }
            if (e.Button == MouseButtons.Right)
            {
                lblIntensityMax.Text = "Max value: " + ch1.ChartAreas[0].AxisX.PixelPositionToValue(e.X).ToString("##");
                IntMax = Convert.ToInt16(ch1.ChartAreas[0].AxisX.PixelPositionToValue(e.X).ToString("##"));
                ch1.Series[2].Points[1].XValue = IntMax;
                ch1.Series[2].Points[1].YValues[0] = 10;
                drawDiagram(reHisto, fname, IntMin, IntMax);
            }
        }



        private void bttnRecalcHisto_Click(object sender, EventArgs e)
        {
            if (IntMax != IntMin)
            {
                if (IntMax > IntMin)
                {
                    drawDiagram(reHisto, fname, IntMin, IntMax);
                }
                else { MessageBox.Show("Min value is bigger then Max velue. Select proper values.", "Bad values", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            }
            else { MessageBox.Show("Min and max values are equal", "Bad values", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);}

        }

        private void bttnRecalcEqualize_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


    }

}

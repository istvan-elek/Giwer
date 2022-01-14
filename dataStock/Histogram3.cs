using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Giwer.dataStock
{
    public partial class Histogram3 : Form
    {
        public int IntMin = 0;
        public int IntMax = 255;
        public int RIntMin = 0;
        public int RIntMax = 255;
        public int GIntMin = 0;
        public int GIntMax = 255;
        public int BIntMin = 0;
        public int BIntMax = 255;
        string fname;
        public byte[] reHisto = new byte[256];
        byte[] reHistoR = new byte[256];
        byte[] reHistoG = new byte[256];
        byte[] reHistoB = new byte[256];
        int[] x = new int[256];
        int[] y = new int[256];
        int[] Ry = new int[256];
        int[] Gy = new int[256];
        int[] By = new int[256];
        byte[] bandRed;
        byte[] bandGreen;
        byte[] bandBlue;
        byte[] bandGray;


        public Histogram3(byte[] r, byte[] g, byte[] b, string fileName)
        {
            InitializeComponent();
            bandRed = r;
            bandGreen = g;
            bandBlue = b;
            grpHistoRGB.Visible = true;
            grpHistoOneBand.Visible = false;
            fname = fileName;
            //reHisto = computeHistogram(bandGray)
            reHistoR = computeHistogram(bandRed);
            reHistoG = computeHistogram(bandGreen);
            reHistoB = computeHistogram(bandBlue);
            drawDiagram(reHistoR, reHistoG, reHistoB, fileName, RIntMin, RIntMax, GIntMin, GIntMax, BIntMin, BIntMax, 0, 255);
            this.Text = "Histogram of " + System.IO.Path.GetFileName(fileName);
            label1.Text = "Select min/max values for each band: \r\nLeft mouse click: Set min value \r\nRight  mouse click: set max value";
            this.DialogResult = DialogResult.No;
        }

        public Histogram3(byte[] bIn, string fileName)
        {
            InitializeComponent();
            grpHistoOneBand.Visible = true;
            grpHistoRGB.Visible = false;
            bandGray = bIn;
            reHisto = computeHistogram(bandGray);
            fname = fileName;
            this.Text = "Histogram of " + System.IO.Path.GetFileName(fileName);
            label2.Text = "Select min/max values: \r\n \r\nLeft mouse click: Set min value \r\nRight mouse click: set max value";
            initSeries1();
            drawDiagram(reHisto, fileName, IntMin, IntMax);
        }

        public Histogram3()
        {

        }

        void initSeries1()
        {
            for (int i = 0; i < 256; i++)
            {
                x[i] = i;
                y[i] = -1;
                Ry[i] = -1;
                Gy[i] = -1;
                By[i] = -1;
            }
            y[0] = 1;
            y[255] = 1;
            Ry[0] = 1;
            Ry[255] = 1;
            Gy[0] = 1;
            Gy[255] = 1;
            By[0] = 1;
            By[255] = 1;
        }

        [UserAttr("u")]
        public byte[] HistogramEqualization(byte[] byIn)
        {
            byte[] histo = computeHistogram(byIn);
            byte[] byteOut = new byte[byIn.Length];

            int min = 0;
            int max = 0;
            for (int i = 0; i < 256; i++)
            {
                if (histo[i] > 0 && min == 0) { min = i; }
            }

            for (int i = 255; i > 0; i--)
            {
                if (histo[i] > 0 && max == 0) { max = i; }
            }
            byteOut = HistogramEqualization(byIn, min, max);
            return byteOut;
        }

        [UserAttr("u")]
        public byte[] HistogramEqualization(byte[] currentBand, int min, int max)
        {
            byte[] byteOut = new byte[currentBand.Length];
            int diff = max - min;
            for (Int32 i = 0; i < currentBand.Length; i++)
            {
                float intensity = 255F * (currentBand[i] - min) / diff;
                if (intensity < 0) { intensity = 0; }
                if (intensity > 255) { intensity = 255; }
                byteOut[i] = (byte)intensity;
            }
            return byteOut;
        }


        [UserAttr("u")]
        public byte[] computeHistogram(byte[] byIn)
        {
            float[] Fhisto = new float[256];
            byte[] histo = new byte[256];
            for (int k = 0; k < histo.Length; k++) { Fhisto[k] = 0; }  // histogram init

            for (Int64 i = 0; i < byIn.Length; i++)
            {
                Fhisto[byIn[i]] += 1F;
            }

            Fhisto[0] = 0;// 
            float histomax = Fhisto.Max();
            float histomin = Fhisto.Min();
            float d = histomax - histomin;
            for (int j = 0; j < histo.Length; j++)
            {
                Fhisto[j] = 256 * (Fhisto[j] - histomin) / (d);
                histo[j] = (byte)(int)Fhisto[j];
            }
            return histo;
        }

        public void drawDiagram(byte[] histogR, string fname, int min, int max) // for one band only
        {
            //----red
            chart1.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 9, System.Drawing.FontStyle.Italic);
            chart1.ChartAreas[0].AxisX.Maximum = max;
            chart1.ChartAreas[0].AxisX.Minimum = min;
            chart1.ChartAreas[0].AxisX.Interval = 50;
            chart1.ChartAreas[0].AxisY.Maximum = 255;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisX.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.LightGray;
            chart1.ChartAreas[0].AxisY.MajorTickMark.LineColor = Color.LightGray;
            chart1.BackColor = System.Drawing.Color.White;
            chart1.Series[0].ChartType = SeriesChartType.Column;
            chart1.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            chart1.Series[0].BorderWidth = 1;
            chart1.Series[0].Points.DataBindXY(x, histogR);
            chart1.Series[0].Color = System.Drawing.Color.DarkGray;
            chart1.Series[1].Color = System.Drawing.Color.DarkRed;
            chart1.Series[1].Points.DataBindXY(x, y);
        }


        private void drawDiagram(byte[] histogR, byte[] histogG, byte[] histogB, string fname, int Rmin, int Rmax, int Gmin, int Gmax, int Bmin, int Bmax, int Hmin, int Hmax)  // for three bands
        {
            //----red
            ch1.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 9, System.Drawing.FontStyle.Italic);
            ch1.ChartAreas[0].AxisX.Maximum = Hmax;
            ch1.ChartAreas[0].AxisX.Minimum = Hmin;
            ch1.ChartAreas[0].AxisX.Interval = 50;
            ch1.ChartAreas[0].AxisY.Maximum = 256;
            ch1.ChartAreas[0].AxisY.Minimum = 0;
            ch1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            ch1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            ch1.ChartAreas[0].AxisX.LineColor = Color.LightGray;
            ch1.ChartAreas[0].AxisY.LineColor = Color.LightGray;
            ch1.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.LightGray;
            ch1.ChartAreas[0].AxisY.MajorTickMark.LineColor = Color.LightGray;
            ch1.BackColor = System.Drawing.Color.White;
            ch1.Series[0].ChartType = SeriesChartType.Column;
            ch1.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            ch1.Series[0].BorderWidth = 1;
            ch1.Series[0].Points.DataBindXY(x, histogR);
            ch1.Series[0].Color = System.Drawing.Color.Red;

            //-----green
            ch2.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 9, System.Drawing.FontStyle.Italic);
            ch2.ChartAreas[0].AxisX.Maximum = Hmax;
            ch2.ChartAreas[0].AxisX.Minimum = Hmin;
            ch2.ChartAreas[0].AxisX.Interval = 50;
            ch2.ChartAreas[0].AxisY.Maximum = 256;
            ch2.ChartAreas[0].AxisY.Minimum = 0;
            ch2.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            ch2.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            ch2.ChartAreas[0].AxisX.LineColor = Color.LightGray;
            ch2.ChartAreas[0].AxisY.LineColor = Color.LightGray;
            ch2.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.LightGray;
            ch2.ChartAreas[0].AxisY.MajorTickMark.LineColor = Color.LightGray;
            ch2.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            ch2.BackColor = System.Drawing.Color.White;
            ch2.Series[0].ChartType = SeriesChartType.Column;
            ch2.Series[0].BorderWidth = 1;
            ch2.Series[0].Points.DataBindXY(x, histogG);
            ch2.Series[0].Color = System.Drawing.Color.Green;


            //-----blue
            ch3.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 9, System.Drawing.FontStyle.Italic);
            ch3.ChartAreas[0].AxisX.Maximum = Hmax;
            ch3.ChartAreas[0].AxisX.Minimum = Hmin;
            ch3.ChartAreas[0].AxisX.Interval = 50;
            ch3.ChartAreas[0].AxisY.Maximum = 256;
            ch3.ChartAreas[0].AxisY.Minimum = 0;
            ch3.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            ch3.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            ch3.ChartAreas[0].AxisX.LineColor = Color.LightGray;
            ch3.ChartAreas[0].AxisY.LineColor = Color.LightGray;
            ch3.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.LightGray;
            ch3.ChartAreas[0].AxisY.MajorTickMark.LineColor = Color.LightGray;
            ch3.BackColor = System.Drawing.Color.White;
            ch3.Series[0].ChartType = SeriesChartType.Column;
            ch3.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
            ch3.Series[0].BorderWidth = 1;
            ch3.Series[0].Points.DataBindXY(x, histogB);
            ch3.Series[0].Color = System.Drawing.Color.Blue;
        }


        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    lblIntensityMin.Text = "Min value: " + Convert.ToInt16(chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X).ToString("##"));
                    y[IntMin] = -1;
                    IntMin = Convert.ToInt16(chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X).ToString("##"));
                    y[IntMin] = 255;
                    chart1.Series[1].Points.DataBindXY(x, y);
                    drawDiagram(reHisto, fname, 0, 255);
                }
                catch (Exception)
                {
                    drawDiagram(reHisto, fname, 0, 255);
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    lblIntensityMax.Text = "Max value: " + chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X).ToString("##");
                    y[IntMax] = -1;
                    IntMax = Convert.ToInt16(chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X).ToString("##"));
                    y[IntMax] = 255;
                    chart1.Series[1].Points.DataBindXY(x, y);
                    drawDiagram(reHisto, fname, 0, 255);
                }
                catch (Exception)
                {
                    drawDiagram(reHisto, fname, 0, 255);
                }
            }
        }


        private void bttnRecalcEqualiz_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


        private void ch1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Ry[RIntMin] = -1;
                RIntMin = Convert.ToInt16(ch1.ChartAreas[0].AxisX.PixelPositionToValue(e.X).ToString("##"));
                lblRedMinMax.Text = "RedMinMax:" + RIntMin + "," + RIntMax;
                Ry[RIntMin] = 255;
                ch1.Series[1].Points.DataBindXY(x, Ry);
                drawDiagram(reHistoR, reHistoG, reHistoB, fname, RIntMin, RIntMax, GIntMin, GIntMax, BIntMin, BIntMax, 0, 255);

            }
            if (e.Button == MouseButtons.Right)
            {
                //lblRedMinMax. = "Max value: " + chart1.ChartAreas[0].AxisX.PixelPositionToValue(e.X).ToString("##");
                Ry[RIntMax] = -1;
                RIntMax = Convert.ToInt16(ch1.ChartAreas[0].AxisX.PixelPositionToValue(e.X).ToString("##"));
                lblRedMinMax.Text = "RedMinMax:" + RIntMin + "," + RIntMax;
                Ry[RIntMax] = 255;
                ch1.Series[1].Points.DataBindXY(x, Ry);
                drawDiagram(reHistoR, reHistoG, reHistoB, fname, RIntMin, RIntMax, GIntMin, GIntMax, BIntMin, BIntMax, 0, 255);
            }
        }

        private void ch2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Gy[GIntMin] = -1;
                GIntMin = Convert.ToInt16(ch1.ChartAreas[0].AxisX.PixelPositionToValue(e.X).ToString("##"));
                lblGreenMinMax.Text = "GreenMinMax:" + GIntMin + "," + GIntMax;
                Gy[GIntMin] = 255;
                ch2.Series[1].Points.DataBindXY(x, Gy);
                drawDiagram(reHistoR, reHistoG, reHistoB, fname, RIntMin, RIntMax, GIntMin, GIntMax, BIntMin, BIntMax, 0, 255);
            }
            if (e.Button == MouseButtons.Right)
            {
                Gy[GIntMax] = -1;
                GIntMax = Convert.ToInt16(ch2.ChartAreas[0].AxisX.PixelPositionToValue(e.X).ToString("##"));
                lblGreenMinMax.Text = "GreenMinMax:" + GIntMin + "," + GIntMax;
                Gy[GIntMax] = 255;
                ch2.Series[1].Points.DataBindXY(x, Gy);
                drawDiagram(reHistoR, reHistoG, reHistoB, fname, RIntMin, RIntMax, GIntMin, GIntMax, BIntMin, BIntMax, 0, 255);
            }
        }

        private void ch3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                By[BIntMin] = -1;
                BIntMin = Convert.ToInt16(ch3.ChartAreas[0].AxisX.PixelPositionToValue(e.X).ToString("##"));
                lblBlueMinMax.Text = "BlueMinMax:" + BIntMin + "," + BIntMax;
                By[BIntMin] = 255;
                ch3.Series[1].Points.DataBindXY(x, By);
                drawDiagram(reHistoR, reHistoG, reHistoB, fname, RIntMin, RIntMax, GIntMin, GIntMax, BIntMin, BIntMax, 0, 255);
            }
            if (e.Button == MouseButtons.Right)
            {
                By[BIntMax] = -1;
                BIntMax = Convert.ToInt16(ch3.ChartAreas[0].AxisX.PixelPositionToValue(e.X).ToString("##"));
                lblBlueMinMax.Text = "BlueMinMax:" + BIntMin + "," + BIntMax;
                By[BIntMax] = 255;
                ch3.Series[1].Points.DataBindXY(x, By);
                drawDiagram(reHistoR, reHistoG, reHistoB, fname, RIntMin, RIntMax, GIntMin, GIntMax, BIntMin, BIntMax, 0, 255);
            }
        }


        private void bttnRecalcEqualizeRGB_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }



    }
}

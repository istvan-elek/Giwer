using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Giwer.dataStock
{
    //public delegate void MyEventHandler(object source, MyEventArgs e);
    //public class MyEventArgs : EventArgs
    //{
    //    private string EventInfo;
    //    public MyEventArgs(string Text)
    //    {
    //        EventInfo = Text;
    //    }
    //    public string GetInfo()
    //    {
    //        return EventInfo;
    //    }
    //}
    public partial class CrossPlot : Form
    {
        public byte[] band1;
        byte[] band2;
        Color clr= System.Drawing.Color.DarkBlue;
        int msize = 2;
        Point startP;
        public Point s1;
        public Point s2;
        Boolean flUpper = true;

        //public event MyEventHandler Apply2Image;

        GeoImageData gida;
        public CrossPlot(GeoImageData gimda)
        {
            InitializeComponent();
            gida = gimda;
            fillCmbBands(gida.Nbands);
            this.Text = "Cross-Plot for " + System.IO.Path.GetFileName(gida.FileName);
            this.DialogResult = DialogResult.Cancel;
        }

        void fillCmbBands(int bandNum)
        {
            for (int i=0; i<bandNum; i++)
            {
                cmbXaxis.Items.Add(i);
                cmbYaxis.Items.Add(i);
            }
        }


        private void cmbXaxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            GeoImageTools gimt = new GeoImageTools(gida);
            band1 = gimt.getOneBandBytes(cmbXaxis.SelectedIndex);
        }

        private void cmbYaxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            GeoImageTools gimt = new GeoImageTools(gida);
            band2 = gimt.getOneBandBytes(cmbYaxis.SelectedIndex);
        }

        private void DrawPlot_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (cmbXaxis.SelectedIndex>-1 & cmbYaxis.SelectedIndex > -1)
            {
                ch1.ChartAreas[0].AxisX.Title = "Band#" + cmbXaxis.SelectedItem;
                ch1.ChartAreas[0].AxisY.Title = "Band#" + cmbYaxis.SelectedItem; ;
                ch1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                ch1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                ch1.ChartAreas[0].AxisX.LineColor = Color.LightGray;
                ch1.ChartAreas[0].AxisY.LineColor = Color.LightGray;
                ch1.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.LightGray;
                ch1.ChartAreas[0].AxisY.MajorTickMark.LineColor = Color.LightGray;
                ch1.Series[0].MarkerColor = clr;
                ch1.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Gray;
                ch1.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Gray;
                ch1.Series[0].MarkerSize = msize;
                computeChartPoints();
            }
            this.Cursor = Cursors.Default;
        }


        void computeChartPoints()
        {
            var set = new HashSet<string>();

            ch1.Series[0].Points.Clear();
            for (Int32 i=0; i<band1.Length;i++)
            {
                set.Add(band1[i] + "," + band2[i]);
            }
            List < string> lst = set.ToList();
            foreach (String item in lst)
            {
                string[] s = item.Split(',');
                double x = Convert.ToDouble(item.Split(',')[0]);
                double y = Convert.ToDouble(item.Split(',')[1]);
                ch1.Series[0].Points.AddXY(x,y);
            }
        }

        private void bttnPointColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
                clr = cd.Color;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            msize = (int)numericUpDown1.Value;
        }

        private void ch1_MouseDown(object sender, MouseEventArgs e)
        {
            var result = ch1.HitTest(e.X, e.Y);
            double x = result.ChartArea.AxisX.PixelPositionToValue(e.X);
            double y = result.ChartArea.AxisY.PixelPositionToValue(e.Y); 
            ch1.Series[1].Points.Clear();
            startP = new Point((int)x, (int)y);
            ch1.Series[1].MarkerSize = msize;
        }

        private void ch1_MouseUp(object sender, MouseEventArgs e)
        {
            var result = ch1.HitTest(e.X, e.Y);
            double x = result.ChartArea.AxisX.PixelPositionToValue(e.X);
            double y = result.ChartArea.AxisY.PixelPositionToValue(e.Y);
            if (startP.X == (int)x || startP.Y == (int)y)
            {
                startP.X = 0;
                startP.Y = 0;
                grBox.Visible = false;
                return;
            }
            ch1.Series[1].MarkerSize = 4;
            Point endP = new Point((int)x, (int)y); 
            ch1.Series[1].Points.AddXY(startP.X, startP.Y);
            ch1.Series[1].Points.AddXY(endP.X, endP.Y);
            float m = (float)((int)y - startP.Y) / (float)((int)x - startP.X);
            float a = startP.Y - m * startP.X;
            drawLongLine(m, a);
            startP.X = 0;
            startP.Y = 0;
            grBox.Visible = true;
        }

        private void ch1_MouseMove(object sender, MouseEventArgs e)
        {
            if (startP.IsEmpty) return;
            var result = ch1.HitTest(e.X, e.Y);
            if (result.Object == null) return;
            double x = result.ChartArea.AxisX.PixelPositionToValue(e.X);
            double y = result.ChartArea.AxisY.PixelPositionToValue(e.Y);
            ch1.Series[1].Points.Clear();
            Point endP = new Point((int)x, (int)y);
            ch1.Series[1].Points.AddXY(startP.X, startP.Y);
            ch1.Series[1].Points.AddXY(endP.X, endP.Y);
        }

        void drawLongLine(float m, float a)
        {
            s1 = new Point();
            int xmax=255;
            int ymax = (int)(m * 255 +a);
            s2 = new Point(xmax, ymax);
            if (a>0)
            {
                s1.X = 0;
                s1.Y = (int)a;
            }
            else
            {
                float c = -a / m;
                s1.X = (int)c;
                s1.Y = 0;
            }
            ch1.Series[1].Points.Clear();
            ch1.Series[1].Points.AddXY(s1.X, s1.Y);
            ch1.Series[1].Points.AddXY(s2.X, s2.Y);
        }

        private void bttnApply2Image_Click(object sender, EventArgs e)
        {
            float m = (float)(s2.Y - s1.Y) / (float)(s2.X - s1.X);
            for (int i = 0; i < band1.Length; i++)
            {
                if (flUpper)
                {
                    if (band1[i] > (byte)(s1.Y + (int)(m * (float)band2[i]))) band1[i] = 255;
                }
                else
                {
                    if (band1[i] < (byte)(s1.Y + (int)(m * (float)band2[i]))) band1[i] = 255;
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void bttnAbove_Click(object sender, EventArgs e)
        {
            flUpper = true;
        }

        private void bttnBelow_Click(object sender, EventArgs e)
        {
            flUpper = false;
        }


    }
}

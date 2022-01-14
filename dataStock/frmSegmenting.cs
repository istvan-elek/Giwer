using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Giwer.dataStock
{
    public partial class frmSegmenting : Form
    {
        byte[] curBand;
        public byte[] segmentedImage;
        Segmentation seg;
        byte[] x = new byte[256];
        byte[] y1 = new byte[256];
        byte[] y2 = new byte[256];

        public frmSegmenting(byte[] currentBand)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            curBand = currentBand;
            initX();
            if (rbSegByHisto.Checked) { panel1.Visible = true; }
        }

        private void bttnSegmentedComputeHisto_Click(object sender, EventArgs e)
        {
            if (rbSegByHisto.Checked)
            {
                PerformSeg();
            }
        }

        void PerformSeg()
        {
            this.Cursor = Cursors.WaitCursor;
            seg = new Segmentation(curBand, Convert.ToInt16(tbThresh.Text));
            y1 = seg.histo;
            setSegValuesforChart();
            //y2 = seg.segValues;    
            drawDiagram();
            this.Cursor = Cursors.Default;
        }

        void setSegValuesforChart()
        {
            for (int i = 0; i < seg.segBoundaries.Length; i++)
            {
                y2[seg.segBoundaries[i]] = seg.segValues[i];
            }
        }

        private void bttnDisplayResult_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            segmentedImage = seg.computeSegmentedImage();  //seg.segmentedImage;
            this.Close();
        }

        private void rbSegByHisto_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSegByHisto.Checked) { panel1.Visible = true; } else { panel1.Visible = false; }
        }

        public void drawDiagram() // for one band only
        {
            chart1.ChartAreas[0].AxisX.Maximum = 255;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
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
            chart1.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chart1.Series[0].BorderWidth = 1;
            chart1.Series[0].Points.DataBindXY(x, y1);
            chart1.Series[0].Color = System.Drawing.Color.DarkGray;
            chart1.Series[1].ChartType = SeriesChartType.Line;
            chart1.Series[1].Color = System.Drawing.Color.DarkRed;
            chart1.Series[1].Points.DataBindXY(x, y2);
        }

        void initX()
        {
            for (int i = 0; i < 256; i++)
            {
                x[i] = (byte)i;
                y1[i] = 0;
            }
        }

        private void tbThresh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformSeg();
            }
        }
    }
}

using System.Drawing;
using System.Windows.Forms;

namespace Giwer.dataStock
{
    public partial class frmShowKernel : Form
    {
        int Xmax = 15;
        int Xmin=-15;
        int[] x;
        float[] y;
        //float[] hiperbola;
        int[] zeroAxis;
        int halflength;
        float Ymax;
        float Ymin;
        public frmShowKernel(float[] values, float ymin, float ymax, int Row)
        {
            InitializeComponent();
            this.Text = "Kernel's section at line " + Row.ToString();
            Xmin = -(int)(values.Length / 2F);
            Xmax = (int)(values.Length / 2F);
            Ymax = ymax;
            Ymin = ymin;
            x = new int[values.Length];
            halflength = (values.Length - 1) / 2;
            //Xmax = halflength;
            //Xmin = -halflength;
            y = new float[values.Length];
            zeroAxis = new int[values.Length];
            //hiperbola = new float[values.Length];
            initChart(values.Length,values);
            drawHisto();
        }


        void initChart(int length, float[] val)
        {
            for (int i = 0; i < length; i++)
            {
                x[i] = i-halflength;
                y[i] = val[i];
                zeroAxis[i] = 0;

                //if (i != halflength)
                //{
                    //hiperbola[i] = 1F / ( i - halflength - 1 +0.00000000001F);
                //}
                //else
                //{
                //    hiperbola[i]=1000;
                //}
            }
        }

        void drawHisto()
        {
            ch1.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8, System.Drawing.FontStyle.Italic);
            ch1.BackColor = System.Drawing.Color.White;
            ch1.ChartAreas[0].AxisX.Maximum = Xmax;
            ch1.ChartAreas[0].AxisX.Minimum = Xmin;
            ch1.ChartAreas[0].AxisY.Maximum = Ymax;
            ch1.ChartAreas[0].AxisY.Minimum = Ymin; // Ymin;
            ch1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            ch1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
            ch1.ChartAreas[0].AxisX.LineColor = Color.LightGray;
            ch1.ChartAreas[0].AxisY.LineColor = Color.LightGray;
            ch1.ChartAreas[0].AxisX.MajorTickMark.LineColor = Color.LightGray;
            ch1.ChartAreas[0].AxisY.MajorTickMark.LineColor = Color.LightGray;
            ch1.ChartAreas[0].AxisY.LabelStyle.Enabled = true;
            ch1.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8, System.Drawing.FontStyle.Italic);
            ch1.Series[0].BorderWidth = 2;
            ch1.Series[0].Points.DataBindXY(x, y);
            ch1.Series[0].Color = System.Drawing.Color.Red;
            ch1.Series[1].Points.DataBindXY(x, zeroAxis);
            ch1.Series[1].Color = System.Drawing.Color.Black;
            ch1.Series[1].MarkerSize = 1;
            ch1.Series[1].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot;
            //ch1.Series[2].Points.DataBindXY(x, hiperbola);
            //ch1.Series[2].Color = System.Drawing.Color.DeepSkyBlue;
            //ch1.Series[2].MarkerSize = 1;
            //ch1.Series[2].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDotDot;

        }
    }
}

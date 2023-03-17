using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Giwer.dataStock;
using System.IO;

namespace Giwer.Mosaic
{
    public partial class frmMain : Form
    {
        Project proj = new Project();
        Int32[] colp = new int[256];
        //GeoImageData gimda;
        public frmMain()
        {
            InitializeComponent();
        }

        public frmMain(Project proj)
        {
            InitializeComponent();
        }

        private void tabtnLoadProject_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Project files|*.proj";
            if (of.ShowDialog() == DialogResult.OK)
            {
                proj.initProject();
                lstProj.Items.Clear();
                clearPicture();
                loadAvailableColorPalettes();
                proj.ProjectFileName = of.FileName;
                for(int i=0; i < proj.FileNames.Count; i++)
                {
                    lstProj.Items.Add(Path.GetFileName( proj.FileNames[i]));
                }
            }
            DrawPicture(proj.FileNames.ToArray(), splitContainer1.Panel2.ClientSize.Width/2, splitContainer1.Panel2.ClientSize.Height/2);
        }

        void clearPicture()
        {
            Graphics g = splitContainer1.Panel2.CreateGraphics();
            g.Clear(Color.White);
        }


        void DrawPicture(string[] fnames, int x, int y)
        {
            Graphics g = splitContainer1.Panel2.CreateGraphics();
            g.Clear(Color.White);
            for (int i = 0; i < fnames.Length; i++)
            {
                Giwer.dataStock.GeoImageData GeoImage = new GeoImageData();
                GeoImage.FileName = fnames[i];
                GeoImageData gimda = GeoImage;
                pbCompas_Paint(gimda);
                GeoImageTools gt = new GeoImageTools(GeoImage);
                byte[] imRed = gt.getOneBandBytes(2);
                byte[] imGreen = gt.getOneBandBytes(1);
                byte[] imBlue = gt.getOneBandBytes(0);
                GeoMultiBandMethods gmb = new GeoMultiBandMethods();                
                Bitmap bmp = gmb.createRGB_gwr(GeoImage, imRed, imGreen, imBlue); //for 24 bits image only
                int wid = bmp.Width / 10;
                int hei = bmp.Height / 10;
                Rectangle srcRect = new Rectangle(x - i * 50, y /*- i * 50*/, wid, hei);
                GraphicsUnit units = GraphicsUnit.Pixel;
                //Rectangle nextRect = new Rectangle(x - i * 50, y - i * 50, wid, hei);
                g.DrawImage(bmp, srcRect);
                //g.DrawRectangle(Pens.Black, srcRect);
            }
        }

        private void tsbtnMakeMosaic_Click(object sender, EventArgs e)
        {
            DrawPicture(proj.FileNames.ToArray(), splitContainer1.Panel2.ClientSize.Width / 2, splitContainer1.Panel2.ClientSize.Height / 2);
        }

        private void tsbtnMakeGauss_Click(object sender, EventArgs e)
        {

        }

        void loadAvailableColorPalettes() // loads available color palettes
        {
            string[] fileEntries = Directory.GetFiles(Application.StartupPath, "*.cp");
        }

        private void pbCompas_Paint(GeoImageData gimda)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0), 8);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
            Graphics g = pbCompas.CreateGraphics();
            g.Clear(Color.White);
            if (gimda != null)
            {
                double alfa = -Math.PI * gimda.Camera_yaw / 180;
                int centerX = 30;
                int centerY = 30;
                int eps = 10;
                int radius = 25;
                int x2 = Convert.ToInt16(centerX - (centerX - eps) * Math.Sin(alfa));
                int y2 = Convert.ToInt16(centerY + (centerY - eps) * Math.Cos(alfa));
                int x1 = Convert.ToInt16(centerX + (centerX - eps) * Math.Sin(alfa));
                int y1 = Convert.ToInt16(centerY - (centerY - eps) * Math.Cos(alfa));
                SolidBrush rBrush = new SolidBrush(Color.FromArgb(100, 255, 255, 255));
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.FillEllipse(rBrush, centerX - radius, centerY - radius, radius + radius, radius + radius);
                g.DrawLine(pen, x1, y1, x2, y2);
                g.Dispose();
            }
        }


    }
}

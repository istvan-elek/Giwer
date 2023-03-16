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
                GeoImageTools gt = new GeoImageTools(GeoImage);
                byte[] imRed = gt.getOneBandBytes(2);
                byte[] imGreen = gt.getOneBandBytes(1);
                byte[] imBlue = gt.getOneBandBytes(0);
                GeoMultiBandMethods gmb = new GeoMultiBandMethods();                
                Bitmap bmp = gmb.createRGB_gwr(GeoImage, imRed, imGreen, imBlue); //for 24 bits image only
                int wid = bmp.Width / 10;
                int hei = bmp.Height / 10;
                Rectangle srcRect = new Rectangle(x - i * 50, y - i * 50, wid, hei);
                GraphicsUnit units = GraphicsUnit.Pixel;
                Rectangle nextRect = new Rectangle(x - i * 50, y - i * 50, wid, hei);
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


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Giwer
{
    public partial class ImageDisplay : UserControl
    {
        int screenWidth;
        int screenHeight;
        GeoImageData gimDa = new GeoImageData();
        GeoImageTools git = new GeoImageTools();
        byte[] curBand;

        public ImageDisplay(byte[] byIn, GeoImageData gd)
        {
            gimDa = gd;
            InitializeComponent();
            curBand = byIn;
            screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            initImage();
        }

        void initImage()
        {
            pbImage.Size = new Size(gimDa.Ncols, gimDa.Nrows);
            pbImage.Image = git.convertOneBandBytesto24bitBitmap(curBand, gimDa.Ncols, gimDa.Nrows);
        }

        void loadImage()
        {

        }

        private void pbImage_MouseMove(object sender, MouseEventArgs e)
        {
            lblCursorPos.Text = e.X +", " + e.Y;
        }
    }

}

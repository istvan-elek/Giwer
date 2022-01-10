using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using MetadataExtractor.Formats.Bmp;

namespace Giwer
{
    public partial class ImageWindow : UserControl
    {
        Bitmap bmp;
        Rectangle BMPContainer;
        Rectangle BMPSource;
        int newWidth = 0;
        int newHeight = 0;
        int posX = 0;
        int posY = 0;
        int startx = 0;
        int starty = 0;
        float zoomLevel = 1F;
        float zl = 1F;
        public float zoomFactor = 0.2F;
        string displayImageSize;
        string displayCursorPosition;
        float[,] dem;


        public ImageWindow(string displayImageS, string displayCursorPos) //constructor of ImageWindow
        {
            InitializeComponent();
            panel1.Cursor = Cursors.Hand;
            displayImageSize = displayImageS;
            displayCursorPosition = displayCursorPos;
            //colp = colPal;
        }

        //public ImageWindow(GeoImageData gda, byte[] byIn, string displayImageS, string displayCursorPos) //constructor of ImageWindow
        //{
        //    InitializeComponent();
        //    panel1.Cursor = Cursors.Hand;
        //    displayImageSize = displayImageS;
        //    displayCursorPosition = displayCursorPos;
        //    GeoImageTools gimt = new GeoImageTools();
        //    Bitmap bmp = gimt.ByteArrayToBitmap(byIn, gda.Ncols, gda.Nrows);
        //}

        private void panel1_MouseDown(object sender, MouseEventArgs e) // panel mouse down event handler
        {
            startx = (int)(e.X);
            starty = (int)(e.Y);
        }

        public void InitImage(Image imgIn) // loads an image
        {
            bmp = (Bitmap)imgIn;
            posX = 0;
            posY = 0;
            zoomLevel = 1F;
            zl = 1F;

            if (displayImageSize== "true") {tslbl.Text = "Image size: " + bmp.Width + " x " + bmp.Height; }
            zoomFull();
        }

        public void InitImage(byte[] byIn, Int32 imWidth, Int32 imHeight, Int32[] colp) // loads an image
        {
            GeoImageTools gimt = new GeoImageTools();
            bmp = gimt.convertOneBandBytesto8bitBitmap(byIn, imWidth, imHeight, colp);
            //bmp = gimt.convertOneBandBytesto24bitBitmap(byIn, imWidth, imHeight);
            posX = 0;
            posY = 0;
            zoomLevel = 1F;
            zl = 1F;
            if (displayImageSize == "true") { tslbl.Text = "Image size:(" + bmp.Width + "," + bmp.Height +")"; }
            zoomFull();
        }

        //public void InitImage(byte[] byIn, Int32 imWidth, Int32 imHeight, Int32[] colp) // loads an image
        //{
        //float[,] dtm
        //    GeoImageTools gimt = new GeoImageTools();
        //    bmp = gimt.convertOneBandBytesto8bitBitmap(byIn, imWidth, imHeight, colp);
        //    //bmp = gimt.convertOneBandBytesto24bitBitmap(byIn, imWidth, imHeight);
        //    posX = 0;
        //    posY = 0;
        //    zoomLevel = 1F;
        //    zl = 1F;
        //    if (displayImageSize == "true") { tslbl.Text = "Image size:(" + bmp.Width + "," + bmp.Height + ")"; }
        //    zoomFull();
        //}



        public void InitImage(byte[] byIn, Int32 imWidth, Int32 imHeight, Int32[] colp, float[,] dm) // loads an image
        {
            dem = dm;
            GeoImageTools gimt = new GeoImageTools();
            bmp = gimt.convertOneBandBytesto8bitBitmap(byIn, imWidth, imHeight, colp);
            //bmp = gimt.convertOneBandBytesto24bitBitmap(byIn, imWidth, imHeight);
            posX = 0;
            posY = 0;
            zoomLevel = 1F;
            zl = 1F;
            if (displayImageSize == "true") { tslbl.Text = "Image size:(" + bmp.Width + "," + bmp.Height + ")"; }
            zoomFull();
        }


        public void loadImage(Bitmap bmpIn) // load an image
        {
            bmp = bmpIn;
            if (displayImageSize == "true") { tslbl.Text = "Image size:(" + bmp.Width + "," + bmp.Height + ")"; }
            zoomFull();
        }

        public void clearImage() // clears panel's graphics
        {
           
            bmp = new Bitmap(1, 1);
            tslbl.Text = "";
            imageDraw();

        }
        private void panel1_MouseUp(object sender, MouseEventArgs e) // panel mouse up event handler
        {
            int dx = e.X - startx;
            int dy = e.Y - starty;
            posX -= (int)(dx * zl);
            posY -= (int)(dy * zl);
            imageDraw();
        }

        private void bttnPlus_Click(object sender, EventArgs e)  // zooming in
        {
            zl = zl * (1 - zoomFactor);
            zoomLevel = 1 - zoomFactor;
            posX = posX + (int)((float)newWidth * (1F - zoomLevel) / 2F);
            posY = posY + (int)((float)newHeight * (1F - zoomLevel) / 2F);
            newWidth = (int)((float)newWidth * zoomLevel);
            newHeight = (int)((float)newHeight * zoomLevel);
            imageDraw();
        }

        private void bttnMinus_Click(object sender, EventArgs e) // zooming out
        {
            zl = zl * (1 + zoomFactor);
            zoomLevel = 1 + zoomFactor;
            posX = posX + (int)((float)newWidth * (1F - zoomLevel) / 2F);
            posY = posY + (int)((float)newHeight * (1F - zoomLevel) / 2F);
            newWidth = (int)((float)newWidth * zoomLevel);
            newHeight = (int)((float)newHeight * zoomLevel);
            imageDraw();
        }

        private void bttnZoomFull_Click(object sender, EventArgs e)
        {
            zoomFull();
        }


        void zoomFull() //zooming to full extent of an image
        {
            newWidth = bmp.Height * panel1.Width / (panel1.Height);
            newHeight = bmp.Height;
            posY = 0;
            posX = 0;
            zoomLevel = 1 + zl * zoomFactor;
            zl = (float)bmp.Height / (float)panel1.Height;
            imageDraw();
        }
        void imageDraw() // draws a bitmap on the panel
        {
            if (bmp != null)
            {
                Graphics g = panel1.CreateGraphics();
                g.Clear(Color.White);
                BMPContainer = panel1.ClientRectangle;
                BMPSource = new Rectangle(posX, posY, newWidth, newHeight);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.DrawImage(bmp, BMPContainer, BMPSource, GraphicsUnit.Pixel);
        }
    }

        private void panel1_Resize(object sender, EventArgs e) // it happens if the panel is resized
        {
            newWidth = (int)(panel1.Width * zl);
            newHeight = (int)(panel1.Height * zl);
            imageDraw();
        }

        public Image getImage()
        {

            return this.bmp;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e) // it happens if the mouse is moving on the panel
        {
            if (bmp == null) { return; }
            if (bmp.Width != 1)
            {
                if (displayCursorPosition == "true")
                {
                    float z = (float)BMPSource.Width / (float)panel1.Width;
                    int xx = (int)(e.X * z + posX);
                    int yy = (int)(e.Y * z + posY);
                    string loc = xx + "," + yy;
                    tslblCursorPos.Text = "";
                    if ((xx > 0 && xx < bmp.Width) && (yy > 0 && yy < bmp.Height))
                    {
                        if (dem != null)
                        {
                            tslblCursorPos.Text = "Corsor position: (" + loc + ") " + "| Elevation: {" + dem[xx,yy] + "}";
                        }
                        else
                        {
                            Color col = bmp.GetPixel(xx, yy);
                            tslblCursorPos.Text = "Corsor position: (" + loc + ") " + "| Pixel values: {R:" + col.R + ", G:" + col.G + ",B:" + col.B + "}";
                        }

                    }
                }
            }
        }
    }
}

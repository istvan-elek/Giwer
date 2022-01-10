using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;

namespace Giwer.dataStock
{
    public partial class ImageWindow : UserControl
    {
        Int32 width;
        Int32 height;
        GeoImageData gimda;
        int startx;
        int starty;
        float imageAspect = 1F;     //   (float)pbImage.Width / pbImage.Height;
        float controlAspect = 1F;   //   (float)pb.ClientSize.Width / pb.ClientSize.Height;
        Boolean drawRectangleBool;
        float[,] elev;
        byte[] imageIn;
        //byte[,] imIn2D;
        byte[] actualImage;
        Point startPosImage; 
        Point endPosImage; 
        byte[] iminRed;
        byte[] iminGreen;
        byte[] iminBlue;
        byte[] actualiminRed;
        byte[] actualiminGreen;
        byte[] actualiminBlue;
        Int32[] colorPal;
        Size sizeClipedImage;
        Point imageStartIndex=new Point(0,0);
        Boolean flagRGB;
        frmSpectrum spectrum=new frmSpectrum();
        Point [] spec;

        public event EventHandler<Tuple<int, int, int>> MouseClicked;

        public void DrawCross(int locInd, Color col)
        {
            int y = locInd / gimda.Ncols;
            int x = locInd % gimda.Ncols;
            Point cur = imgPoint2WindowPoint(new Point(x, y));
            Graphics gr = pb.CreateGraphics();
            Pen p = new Pen(col, 2.0f);
            gr.DrawLine(p, cur.X, cur.Y-10, cur.X, cur.Y+10);
            gr.DrawLine(p, cur.X-10, cur.Y, cur.X+10, cur.Y);
        }

        public void DrawLine(int locInd1, int locInd2, Color col)
        {
            int y1 = locInd1 / gimda.Ncols;
            int x1 = locInd1 % gimda.Ncols;
            int y2 = locInd2 / gimda.Ncols;
            int x2 = locInd2 % gimda.Ncols;
            Point begin = imgPoint2WindowPoint(new Point(x1, y1));
            Point end = imgPoint2WindowPoint(new Point(x2, y2));
            Graphics gr = pb.CreateGraphics();
            Pen p = new Pen(col, 1.0f);
            gr.DrawLine(p, begin.X, begin.Y, end.X, end.Y);
        }

        public void fillPolygon(List<int> vertices, Color col)
        {
            Point[] curvePoints = new Point[vertices.Count];
            for (int i=0; i<vertices.Count; ++i)
            {
                int y = vertices[i] / gimda.Ncols;
                int x = vertices[i] % gimda.Ncols;
                Point p = imgPoint2WindowPoint(new Point(x, y));
                curvePoints[i] = p;
            }
            Graphics gr = pb.CreateGraphics();
            SolidBrush b = new SolidBrush(Color.FromArgb(100, col.R, col.G, col.B));
            gr.FillPolygon(b, curvePoints);
        }


        public void ClearDrawings()
        {
            pb.Refresh();
        }

        public ImageWindow()
        {
            InitializeComponent();
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Dock = DockStyle.Fill;
            pbCompas.Parent = pb;
        }

        public void Clear(GeoImageData gd) // erase image of picture box
        {
            gimda = gd;
            pb.Image = null;
            lblCursorPosition.Text = "";
            this.Enabled = false;
            imageStartIndex = new Point(0, 0);
            sizeClipedImage = new Size(gimda.Ncols, gimda.Nrows);
            width = gimda.Ncols;
            height = gimda.Nrows;
        }

        public void LoadImageFromFile(string fileName)  // load an image to picture box (pb) from files (jpg vagy tif)
        {
            Image img = Image.FromFile(fileName);
            pb.Image = img;            
        }

        public void LoadImageFromFile(Bitmap bmp)
        {
            pb.Image = bmp;
        }

        public void DrawImage(GeoImageData gida, byte[] image, Int32[] colp) //  drawing 8bits color palette image to picture box
        {
            Clear(gida);
            this.Enabled = true;
            flagRGB = false;
            gimda = gida;
            GeoImageTools gt = new GeoImageTools(gimda);
            width = gimda.Ncols;
            height = gimda.Nrows;
            imageAspect = (float)width / height;
            imageIn = image;
            //imIn2D = Onedim2dim(imageIn, width, height);
            actualImage = image;
            pb.Image = gt.convertOneBandBytesto8bitBitmap(image, width, height, colp);
            colorPal = colp;
            bttnPlus.Checked = true;
            bttnPan.Checked = false;
            pb.Cursor = Cursors.Default;
        }

        public void DrawImageDDM(GeoImageData gida, byte[] image, float[,] elevation, int[] colp)  // drawing 8bits color palette image to picture box, which contains elevation based grey scale
        {
            elev = elevation;
            Clear(gida);
            this.Enabled = true;
            flagRGB = false;
            gimda = gida;
            GeoImageTools gt = new GeoImageTools(gimda);
            width = gimda.Ncols;
            height = gimda.Nrows;
            imageAspect = (float)width / height;
            imageIn = image;
            actualImage = image;
            pb.Image = gt.convertOneBandBytesto8bitBitmap(image, width, height, colp);
            colorPal = colp;
            bttnPlus.Checked = true;
            bttnPan.Checked = false;
            pb.Cursor = Cursors.Default;
        }

        public void DrawImageRGB(GeoImageData gida, byte[] red, byte[] green, byte[] blue)   // drawing the 24bits RGB byte array (red,green,blue) to the picture box (pb)
        {
            bttnMinus.Enabled = false;
            Clear(gida);
            this.Enabled = true;
            flagRGB = true;
            //gimda = gida;
            GeoImageTools gt = new GeoImageTools(gimda);
            width = gida.Ncols;
            height = gida.Nrows;
            imageAspect = (float)width / height;
            iminRed = red;
            iminGreen = green;
            iminBlue = blue;
            actualiminRed = red;
            actualiminGreen = green;
            actualiminBlue = blue;
            GeoMultiBandMethods gmb = new GeoMultiBandMethods();
            pb.Image = gmb.createRGB_gwr(gida, iminRed, iminGreen, iminBlue);
            bttnPlus.Checked = true;
            bttnPan.Checked = false;
            pb.Cursor = Cursors.Default;
        }

        public Point imgPoint2WindowPoint(Point inPoint) // convert image pixels' position to window position
        {
            Point coordinates = new Point(inPoint.X - imageStartIndex.X, inPoint.Y - imageStartIndex.Y);
            imageAspect = (float)sizeClipedImage.Width / (float)sizeClipedImage.Height;
            controlAspect = (float)pb.ClientSize.Width / (float)pb.ClientSize.Height;
            float newX = coordinates.X;
            float newY = coordinates.Y;
            if (imageAspect > controlAspect)
            {
                // This means that we are limited by width, meaning the image fills up the entire control from left to right
                float ratioWidth = (float)sizeClipedImage.Width / (float)pb.ClientSize.Width;
                float scale = (float)pb.ClientSize.Width / (float)sizeClipedImage.Width;
                float displayHeight = scale * (float)sizeClipedImage.Height;
                float diffHeight = pb.ClientSize.Height - displayHeight;
                diffHeight /= 2F;
                newY *= scale;
                newY += diffHeight;
                newX /= ratioWidth;
            }
            else
            {
                // This means that we are limited by height, meaning the image fills up the entire control from top to bottom
                float ratioHeight = (float)sizeClipedImage.Height / (float)pb.ClientSize.Height;
                float scale = (float)pb.ClientSize.Height / (float)sizeClipedImage.Height;
                float displayWidth = scale * (float)sizeClipedImage.Width;
                float diffWidth = pb.ClientSize.Width - displayWidth;
                diffWidth /= 2F;
                newX *= scale;
                newX += diffWidth;
                newY /= ratioHeight;
            }
            return new Point((int)newX , (int)newY );
        }

        public Point TranslateZoomMousePosition(Point coordinates, Image pbImage) // convert cursor position to image pixels' position
        {
            imageAspect = (float)pbImage.Width / (float)pbImage.Height;
            controlAspect = (float)pb.ClientSize.Width / (float)pb.ClientSize.Height;
            float newX = coordinates.X;
            float newY = coordinates.Y;
            if (imageAspect > controlAspect)
            {
                // This means that we are limited by width, meaning the image fills up the entire control from left to right
                float ratioWidth = (float)pbImage.Width / (float)pb.ClientSize.Width;
                newX *= ratioWidth;
                float scale = (float)pb.ClientSize.Width / (float)pbImage.Width;
                float displayHeight = scale * (float)pbImage.Height;
                float diffHeight = pb.ClientSize.Height - displayHeight;
                diffHeight /= 2F;
                newY -= diffHeight;
                newY /= scale;
            }
            else
            {
                // This means that we are limited by height, meaning the image fills up the entire control from top to bottom
                float ratioHeight = (float)pbImage.Height / (float)pb.ClientSize.Height;
                newY *= ratioHeight;
                float scale = (float)pb.ClientSize.Height / (float)pbImage.Height;
                float displayWidth = scale * (float)pbImage.Width;
                float diffWidth = pb.ClientSize.Width - displayWidth;
                diffWidth /= 2F;
                newX -= diffWidth;
                newX /= scale;
            }
            return new Point((int)newX, (int)newY);
        }

        Point TranslateZoomMousePosition(Point coordinates, Int32 imagewidth, Int32 imageheight) // convert cursor position to image pixels' position
        {
            imageAspect = (float)imagewidth / (float)imageheight;
            controlAspect = (float)pb.ClientSize.Width / (float)pb.ClientSize.Height;
            float newX = coordinates.X;
            float newY = coordinates.Y;
            if (imageAspect > controlAspect)
            {
                // This means that we are limited by width, meaning the image fills up the entire control from left to right
                float ratioWidth = (float)imagewidth / (float)pb.ClientSize.Width;
                newX *= ratioWidth;
                float scale = (float)pb.ClientSize.Width / (float)imagewidth;
                float displayHeight = scale * (float)imageheight;
                float diffHeight = pb.ClientSize.Height - displayHeight;
                diffHeight /= 2F;
                newY -= diffHeight;
                newY /= scale;
            }
            else
            {
                // This means that we are limited by height, meaning the image fills up the entire control from top to bottom
                float ratioHeight = (float)imagewidth / (float)pb.ClientSize.Height;
                newY *= ratioHeight;
                float scale = (float)pb.ClientSize.Height / (float)imageheight;
                float displayWidth = scale * (float)imagewidth;
                float diffWidth = pb.ClientSize.Width - displayWidth;
                diffWidth /= 2F;
                newX -= diffWidth;
                newX /= scale;
            }
            return new Point((int)newX, (int)newY);
        }

        void DrawRectang(int newx, int newy)
        {
            Graphics gr = pb.CreateGraphics();
            System.Drawing.SolidBrush br = new System.Drawing.SolidBrush(Color.FromArgb(40, 100, 10, 00));
            //gr.FillRectangle(br, startx, starty, (newx - startx), (newy - starty));
            gr.DrawRectangle(new Pen(Color.White), startx, starty, (newx - startx), (newy - starty));
        }

        void DrawBox(int newx, int newy)
        {
            Graphics gr = pb.CreateGraphics();
            Pen p = new Pen(Color.White);
            //gr.DrawRectangle(new Pen(Color.White), startx, starty, Math.Abs((newx - startx)), Math.Abs((newy - starty)));
            gr.DrawLine(p, startx, starty, startx , newy);
            gr.DrawLine(p, startx, starty, newx, starty);
            gr.DrawLine(p, newx, starty, newx, newy);
            gr.DrawLine(p, newx, newy, startx, newy);
        }

        private void Pb_MouseDown(object sender, MouseEventArgs e)
        {
            if (!tsbttnSpectrum.Checked)
            {
                Point loc = TranslateZoomMousePosition(e.Location, pb.Image);
                Point cur = new Point(imageStartIndex.X + loc.X, imageStartIndex.Y + loc.Y);
                if (e.Button == MouseButtons.Left) MouseClicked?.Invoke(this, new Tuple<int, int, int>(cur.X, cur.Y, gimda.Ncols));
                if (e.Button == MouseButtons.Right) MouseClicked?.Invoke(this, new Tuple<int, int, int>(cur.X, cur.Y, -gimda.Ncols));
                startx = e.X;
                starty = e.Y;
                drawRectangleBool = true;
            }
            else  // if spectrum button is checked
            {
                Point loc = TranslateZoomMousePosition(e.Location, pb.Image);
                Point cur = new Point(imageStartIndex.X + loc.X, imageStartIndex.Y + loc.Y);
                if (((cur.X < 0) || (cur.Y < 0)) || ((cur.X > gimda.Ncols - 1) || (cur.Y > gimda.Nrows - 1))) return;
                Int32 bytePos = width * cur.Y + cur.X;
                spec = new Point[gimda.Nbands];
                createSpectrum(bytePos);
                spectrum.displaySpectrum(spec, gimda.Wavelength);
                if (e.Button == MouseButtons.Left) spectrum.showSpectrumAsTable(spec, gimda.Wavelength);
                this.Focus();
                drawRectangleBool = false;
            }
        }


        private void Pb_MouseMove(object sender, MouseEventArgs e)
        {        
            if (tsbttnSpectrum.Checked)
            {
                if (e.Button == MouseButtons.Right)
                {
                    Point locc = TranslateZoomMousePosition(e.Location, pb.Image);
                    Point curc = new Point(imageStartIndex.X + locc.X, imageStartIndex.Y + locc.Y);
                    if (((curc.X < 0) || (curc.Y < 0)) || ((curc.X > gimda.Ncols - 1) || (curc.Y > gimda.Nrows - 1))) return;
                    Int32 bytePos = width * curc.Y + curc.X;
                    spec = new Point[gimda.Nbands];
                    createSpectrum(bytePos);
                    spectrum.displaySpectrum(spec, gimda.Wavelength);
                    this.Focus();
                    drawRectangleBool = false;
                }
                return;
            }

            Point loc = TranslateZoomMousePosition(e.Location, pb.Image);
            Point cur = new Point(imageStartIndex.X + loc.X, imageStartIndex.Y + loc.Y);
            if (((cur.X < 0) || (cur.Y < 0)) || ((cur.X > gimda.Ncols - 1) || (cur.Y > gimda.Nrows - 1))) lblCursorPosition.Text = ""; // "Position: (X:" + e.X + " Y:" + e.Y + ")";// "";
            else
            {
                if (gimda.FileType == GeoImageData.fTypes.DDM)
                {
                    lblCursorPosition.Text = "Pixel position: (" + cur.X + "," + cur.Y + ")  --  X,Y coords: (" + (gimda.Ulxmap + cur.X * gimda.Xdim).ToString() + ", " + (gimda.Ulymap - cur.Y * gimda.Ydim).ToString() + ")  --  Elevation: " + elev[cur.X, cur.Y].ToString();
                }
                else lblCursorPosition.Text = "Pixel position: (X:" + cur.X + " Y:" + cur.Y + "), Value: " + imageIn[width * cur.Y + cur.X].ToString();  //+ imIn2D[cur.X, cur.Y].ToString();
            }
            if (bttnPlus.Checked)
            {
                if (drawRectangleBool)
                {
                    pb.Invalidate();
                    DrawBox(e.X, e.Y);
                }
            }
        }

        private void Pb_MouseUp(object sender, MouseEventArgs e)
        {
            //if (tsbttnSpectrum.Checked) return;
            byte[] clipedImage;
            if (tsbttnSpectrum.Checked)
            {
                Point loc = TranslateZoomMousePosition(e.Location, pb.Image);
                Point cur = new Point(imageStartIndex.X + loc.X, imageStartIndex.Y + loc.Y);
                if (((cur.X < 0) || (cur.Y < 0)) || ((cur.X > gimda.Ncols - 1) || (cur.Y > gimda.Nrows - 1))) return;
                Int32 bytePos = width * cur.Y + cur.X;
                spec = new Point[gimda.Nbands];
                createSpectrum(bytePos);
                spectrum.displaySpectrum(spec, gimda.Wavelength);
                spectrum.showSpectrumAsTable(spec, gimda.Wavelength);
                this.Focus();
                drawRectangleBool = false;
                return;
            }
            if (bttnPlus.Checked)   // if zoom in mode is active
            {
                drawRectangleBool = false;
                startPosImage = TranslateZoomMousePosition(new Point(startx, starty), pb.Image); // compute start position in the image
                endPosImage = TranslateZoomMousePosition(e.Location, pb.Image);  // compute end position in the image
                if (startPosImage.X == endPosImage.X || startPosImage.Y == endPosImage.Y) return;
                Int32 tmp = 0; ;
                if (startPosImage.X > endPosImage.X)
                {
                    tmp = startPosImage.X;
                    startPosImage.X = endPosImage.X;
                    endPosImage.X = tmp;
                }
                tmp = 0;
                if (startPosImage.Y > endPosImage.Y)
                {
                    tmp = startPosImage.Y;
                    startPosImage.Y = endPosImage.Y;
                    endPosImage.Y = tmp;
                }
                float clipedImageAspect = (int)((float)(startPosImage.X - endPosImage.X) / (float)(startPosImage.Y - endPosImage.Y));
                if (clipedImageAspect >= controlAspect) sizeClipedImage = new Size((int)(float)((endPosImage.Y - startPosImage.Y) * controlAspect), endPosImage.Y - startPosImage.Y);
                else sizeClipedImage = new Size((int)(endPosImage.X - startPosImage.X), (int)(float)((endPosImage.X - startPosImage.X) / controlAspect + 0.5F));
                sizeClipedImage.Width = 20 * ((sizeClipedImage.Width+10) / 20);
                if (startPosImage.X + sizeClipedImage.Width > width) startPosImage.X = width - sizeClipedImage.Width;
                if (startPosImage.Y + sizeClipedImage.Height > height) startPosImage.Y = height - sizeClipedImage.Height;
                if (!flagRGB)  // if we are drawing a single band image
                {
                    if (sizeClipedImage.Width <= 0 || sizeClipedImage.Height <= 0) { MessageBox.Show("Too small window to display"); return; }
                    clipedImage = ClipImage(actualImage, startPosImage, sizeClipedImage, width, height);
                    GeoImageTools gt = new GeoImageTools(gimda);
                    pb.Image = gt.convertOneBandBytesto8bitBitmap(clipedImage, sizeClipedImage.Width, sizeClipedImage.Height, colorPal);
                    actualImage = clipedImage;
                }
                else
                {
                    //actualiminRed = ClipImage(actualiminRed, startPosImage, sizeClipedImage, width, height);
                    //actualiminGreen = ClipImage(actualiminGreen, startPosImage, sizeClipedImage, width, height);
                    //actualiminBlue = ClipImage(actualiminBlue, startPosImage, sizeClipedImage, width, height);
                    //GeoMultiBandMethods gmb = new GeoMultiBandMethods();
                    //pb.Image = gmb.createRGB_gwr(sizeClipedImage, actualiminRed, actualiminGreen, actualiminBlue);
                }
                width = sizeClipedImage.Width;
                height = sizeClipedImage.Height;
                imageStartIndex = new Point(imageStartIndex.X + startPosImage.X, imageStartIndex.Y + startPosImage.Y);
                bttnPan.Enabled = true;
            }
            if (bttnPan.Checked)  // if pan mode is active
            {
                sizeClipedImage.Width = 20 * ((sizeClipedImage.Width+10) / 20);
                if ((width == gimda.Ncols) && (height == gimda.Nrows)) return;
                drawRectangleBool = false;
                Point loc = TranslateZoomMousePosition(e.Location, pb.Image);
                Point cur = new Point(imageStartIndex.X + loc.X, imageStartIndex.Y + loc.Y);
                //lb1.Text = "Pan point in image: (X:" + cur.X + " Y:" + cur.Y + ")";
                imageStartIndex.X = cur.X - sizeClipedImage.Width / 2; 
                if (imageStartIndex.X < 0) imageStartIndex.X = 0;
                if (imageStartIndex.X + sizeClipedImage.Width > gimda.Ncols) imageStartIndex.X = gimda.Ncols - sizeClipedImage.Width;
                imageStartIndex.Y = cur.Y - sizeClipedImage.Height / 2; 
                if (imageStartIndex.Y < 0) imageStartIndex.Y = 0;
                if (imageStartIndex.Y + sizeClipedImage.Height > gimda.Nrows) imageStartIndex.Y = gimda.Nrows - sizeClipedImage.Height;
                if (!flagRGB) // if we are drawing a single band image
                {
                    clipedImage = ClipImage(imageIn, imageStartIndex, sizeClipedImage, gimda.Ncols, gimda.Nrows);
                    GeoImageTools gt = new GeoImageTools(gimda);
                    pb.Image = gt.convertOneBandBytesto8bitBitmap(clipedImage, sizeClipedImage.Width, sizeClipedImage.Height, colorPal);
                    actualImage = clipedImage;
                }
                else// in case of RGB image
                {
                    actualiminRed = ClipImage(iminRed, imageStartIndex, sizeClipedImage, gimda.Ncols, gimda.Nrows);
                    actualiminGreen = ClipImage(iminGreen, imageStartIndex, sizeClipedImage, gimda.Ncols, gimda.Nrows);
                    actualiminBlue = ClipImage(iminBlue, imageStartIndex, sizeClipedImage, gimda.Ncols, gimda.Nrows);
                    GeoMultiBandMethods gmb = new GeoMultiBandMethods();
                    pb.Image = gmb.createRGB_gwr(sizeClipedImage, actualiminRed, actualiminGreen, actualiminBlue);
                }
            }
        }


        byte[] ClipImage(byte[] byIn, Point imStart, Size imSize, Int32 IWidth, Int32 IHeight)
        {
            Int32 k = 0;
            Int32 endy = imSize.Height + imStart.Y;
            Int32 endx = imSize.Width + imStart.X;
            byte[] byOut = new byte[(imSize.Width * imSize.Height)];
            for (Int32 i = imStart.Y; i < endy; i++)
            {
                for (Int32 j = imStart.X; j < endx; j++)
                {
                    byOut[k] = byIn[j + i*IWidth];
                    k++;
                }
            }
            return byOut;
        }


        byte[,] Onedim2dim(byte[] byIn, Int32 wid, Int32 hgt)
        {
            byte[,] byOut = new byte[wid, hgt];
            Int32 k = 0;
            for (Int32 i = 0; i < hgt; i++)
            {
                for (Int32 j = 0; j < wid; j++)
                {
                    byOut[j, i] = byIn[k];
                    k++;
                }
            }
            return byOut;
        }


        void ZoomOutImageRGB(Point imStart, Size imSize, Int32 IWidth, Int32 IHeight)
        {
            byte[] ar = new byte[imSize.Width * imSize.Height];
            byte[] ag = new byte[imSize.Width * imSize.Height];
            byte[] ab = new byte[imSize.Width * imSize.Height];
            Int32 k = 0;
            Int32 endy = imSize.Height + imStart.Y;
            Int32 endx = imSize.Width + imStart.X;
            for (Int32 i = imStart.Y; i < endy; i++)
            {
                for (Int32 j = imStart.X; j < endx; j++)
                {
                    ar[k] = iminBlue[j + i * IWidth];
                    ag[k] = iminGreen[j + i * IWidth];
                    ab[k] = iminRed[j + i * IWidth];
                    k++;
                }
            }
            actualiminBlue = ab;
            actualiminGreen = ag;
            actualiminRed = ar;
        }

        private void BttnMinus_Click(object sender, EventArgs e)
        {
            byte[] clipedImage;
            imageStartIndex.X -= sizeClipedImage.Width / 4;
            imageStartIndex.Y -= sizeClipedImage.Height / 4;
            Int32 newwid = (int)(sizeClipedImage.Width * 1.2F);
            Int32 newhgt = (Int32)(sizeClipedImage.Height * 1.2F);
            if (newwid > gimda.Ncols) newwid = gimda.Ncols;
            if (newhgt > gimda.Nrows) newhgt = gimda.Nrows;
            sizeClipedImage = new Size((int)(newwid), (int)(newhgt));
            if (imageStartIndex.X < 0) imageStartIndex.X = 0;
            if (imageStartIndex.Y < 0) imageStartIndex.Y = 0;
            if (imageStartIndex.X > gimda.Ncols - sizeClipedImage.Width) imageStartIndex.X = gimda.Ncols - sizeClipedImage.Width;
            if (imageStartIndex.Y > gimda.Nrows - sizeClipedImage.Height) imageStartIndex.Y = gimda.Nrows - sizeClipedImage.Height;
            if (!flagRGB)
            {
                clipedImage = ClipImage(imageIn, imageStartIndex, sizeClipedImage, gimda.Ncols, gimda.Nrows);
                GeoImageTools gt = new GeoImageTools(gimda);
                pb.Image = gt.convertOneBandBytesto8bitBitmap(clipedImage, sizeClipedImage.Width, sizeClipedImage.Height, colorPal);
                actualImage = clipedImage;
                spectrum.Hide();
                tsbttnSpectrum.Checked = false;
                bttnPlus.Checked = true;
            }

            else
            {
                ZoomOutImageRGB(imageStartIndex, sizeClipedImage, gimda.Ncols, gimda.Nrows);
                GeoMultiBandMethods gmb = new GeoMultiBandMethods();
                pb.Image = gmb.createRGB_gwr(sizeClipedImage, actualiminRed, actualiminGreen, actualiminBlue);
            }
            width = sizeClipedImage.Width;
            height = sizeClipedImage.Height;
        }

        private void BttnZoomFull_Click(object sender, EventArgs e)
        {
            width = gimda.Ncols;
            height = gimda.Nrows;
            sizeClipedImage.Width=width;
            sizeClipedImage.Height=height;
            if (!flagRGB)
            {
                DrawImage(gimda, imageIn, colorPal);
            }
            else
            {
                DrawImageRGB(gimda, iminRed, iminGreen, iminBlue);
            }
            imageStartIndex = new Point(0, 0);
             bttnPlus.Checked = true;
            bttnPan.Checked = false;
            pb.Cursor = Cursors.Default;
            bttnPan.Enabled = false;
            spectrum.Hide();
            tsbttnSpectrum.Checked = false;
        }


        private void BttnPlus_Click(object sender, EventArgs e)
        {
            tsbttnSpectrum.Checked = false;
            bttnPlus.Checked = true;
            bttnPan.Checked = false;
            pb.Cursor = Cursors.Default;
            spectrum.Hide();
            tsbttnSpectrum.Checked = false;
        }

        private void BttnPan_Click(object sender, EventArgs e)
        {
            bttnPan.Checked = true;
            bttnPlus.Checked = false;
            tsbttnSpectrum.Checked = false;
            pb.Cursor = Cursors.Cross;
            spectrum.Hide();
            tsbttnSpectrum.Checked = false;
        }

        public Bitmap GetImage()
        {
            return (Bitmap)pb.Image;           
        }

        private void tsbttnCompas_Click(object sender, EventArgs e)
        {
            pbCompas.Visible = !pbCompas.Visible;
        }

        private static void PaintTransparentBackground(Control c, PaintEventArgs e)
        {
            if (c.Parent == null || !Application.RenderWithVisualStyles)
                return;

            ButtonRenderer.DrawParentBackground(e.Graphics, c.ClientRectangle, c);
        }

        private void pbCompas_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(255, 0, 0), 8);
            pen.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.NoAnchor;
            double alfa = -Math.PI * gimda.Camera_yaw/180;
            int centerX = 30;
            int centerY = 30;
            int eps = 10;
            int radius = 25;
            int x2 = Convert.ToInt16(centerX - (centerX-eps)* Math.Sin(alfa));
            int y2 = Convert.ToInt16(centerY +(centerY-eps) * Math.Cos(alfa));
            int x1 = Convert.ToInt16(centerX + (centerX-eps)* Math.Sin(alfa));
            int y1 = Convert.ToInt16(centerY - (centerY-eps) * Math.Cos(alfa));
            SolidBrush rBrush = new SolidBrush(Color.FromArgb(100, 255, 255, 255));
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.FillEllipse(rBrush, centerX - radius, centerY - radius, radius + radius, radius + radius);
            e.Graphics.DrawLine(pen, x1, y1, x2, y2);
            e.Dispose();
        }

        private void tsbttnSpectrum_Click(object sender, EventArgs e)
        {
            tsbttnSpectrum.Checked = !tsbttnSpectrum.Checked;
            if (tsbttnSpectrum.Checked)
            {
                foreach (ToolStripItem item in toolStrip1.Items)
                {
                    if (item.GetType().ToString() == typeof(ToolStripButton).ToString())
                    {
                        ToolStripButton tsb = item as ToolStripButton;
                        tsb.Checked = false;
                    }
                }

                tsbttnSpectrum.Checked = true;
                Point pstart = Properties.Settings.Default.StartLocation;
                Size psize = Properties.Settings.Default.FormSize;
                //spectrum = new frmSpectrum(gimda);
                spectrum.Location = new Point(pstart.X + psize.Width, pstart.Y);
                spectrum.Show();
                pb.Cursor = Cursors.Default;
            }
            else
            {
                spectrum.Hide();
                spectrum.spectrumInit();
                bttnPlus.Checked = true;
                pb.Cursor = Cursors.Default;
            }
        }

        public void createSpectrum(Int32 bytePosition)
        {
            spec = new Point[gimda.Nbands];
            for (int i = 0; i < gimda.Nbands; i++)
            {
                spec[i] = new Point(i, getPixelValue(bytePosition, i));
            }
        }

        int getPixelValue(int position, int band)
        {
            int value = 0;
            string path = Path.GetDirectoryName(gimda.FileName) + @"\" + Path.GetFileNameWithoutExtension(gimda.FileName) + @"\" + band + ".gwr";
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                BinaryReader br = new BinaryReader(fs);
                fs.Seek(position, SeekOrigin.Begin);
                value = br.ReadByte();
            }
            return value;
        }
    }
}

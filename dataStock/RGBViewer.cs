using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Giwer.dataStock
{
    public partial class RGBViewer : Form
    {
        GeoImageData imgDat;
        GeoImageTools imgTools;
        //ImageWindRGB imv;
        ImageWindow imw;
        byte[] red;
        byte[] green;
        byte[] blue;
        string gwrDataFolder;
        //string DisplayCursorPosition;
        //string DisplayImageSize;
        //Boolean flagGWR;

        public RGBViewer(GeoImageData imgIn, string giwerDataFolder) 
        {
            InitializeComponent();
            imgDat = imgIn;
            imgTools = new GeoImageTools(imgDat);
            if (imgDat.Nbands < 2) { MessageBox.Show("You have too few bands, thus RGB creation is not possible","Missing band", MessageBoxButtons.OK,MessageBoxIcon.Error); this.Close(); return; }
            //this.Location = Giwer.Properties.Settings.Default.StartLocation;
            loadChecklist(imgDat.Nbands);
            gwrDataFolder = giwerDataFolder;
            frmConfig conf = new frmConfig();
            //DisplayCursorPosition = conf.config["DisplayCursorPosition"];
            //DisplayImageSize = conf.config["DisplayImageSize"];
            //imw = new ImageWindRGB();
            imw = new ImageWindow();
            this.WindowState = Properties.Settings.Default.RGBWindowState;
            this.Location = Properties.Settings.Default.RGBWindowStartLocation;
            this.Size = Properties.Settings.Default.RGBWindowSize;
            this.Text = "RGB creation for " + System.IO.Path.GetFileName(imgDat.FileName);
        }

        void loadChecklist(int bands) //load the first 3 bands for creating rgb
        {
            for (int i=0;i<bands;i++)
            {
                cmbBlue.Items.Add(i);
                cmbGreen.Items.Add(i);
                cmbRed.Items.Add(i);
            }
            cmbRed.SelectedIndex = 2;
            cmbGreen.SelectedIndex = 1;
            cmbBlue.SelectedIndex = 0;
        }

        private void bttnCreateRGB_Click(object sender, EventArgs e) // create rgb from the given 3 bands
        {
            if (cmbRed.SelectedIndex != -1 && cmbGreen.SelectedIndex != -1 && cmbBlue.SelectedIndex != -1)
            {
                this.Cursor = Cursors.WaitCursor;
                panel1.Controls.Add(imw);
                imw.Dock = DockStyle.Fill;
                imw.Show();

                if (imgDat.FileType==GeoImageData.fTypes.BIL || imgDat.FileType == GeoImageData.fTypes.BSQ || imgDat.FileType == GeoImageData.fTypes.ENVI) // if files are ibn bil or envi format
                {
                    //flagGWR = false;
                    //createRGB_bil();
                    getRGBbandsfromBil();
                    imw.DrawImageRGB(imgDat, red, green, blue);
                    bttnHistoEq.Enabled = true;
                    bttnHisto.Enabled = true;
                    tsBttnSaveImage.Enabled = true;
                }
                if (imgDat.FileType == GeoImageData.fTypes.GWH) // if files are in giwer format
                {
                    string redFileName = gwrDataFolder + @"\" + Path.GetFileNameWithoutExtension(imgDat.FileName) + @"\" + cmbRed.SelectedIndex + ".gwr";
                    string greenFileName = gwrDataFolder + @"\" + Path.GetFileNameWithoutExtension(imgDat.FileName) + @"\" + cmbGreen.SelectedIndex + ".gwr";
                    string blueFileName = gwrDataFolder + @"\" + Path.GetFileNameWithoutExtension(imgDat.FileName) + @"\" + cmbBlue.SelectedIndex + ".gwr";
                    red = readGwrFile(redFileName);
                    green = readGwrFile(greenFileName);
                    blue = readGwrFile(blueFileName);
                    //flagGWR = false;
                    imw.DrawImageRGB(imgDat, red, green, blue);
                    bttnHisto.Enabled = true;
                    bttnHistoEq.Enabled = true;
                    tsBttnSaveImage.Enabled = true;                    
                }
                this.Cursor = Cursors.Default;
            }
            else { MessageBox.Show("Too few bands were selected for RGB", "Missing band",MessageBoxButtons.OK,MessageBoxIcon.Exclamation); }
        }

        void getRGBbandsfromBil()
        {
            red = imgTools.getOneBandBytes(Convert.ToInt16(cmbRed.SelectedItem));
            green = imgTools.getOneBandBytes(Convert.ToInt16(cmbGreen.SelectedItem));
            blue = imgTools.getOneBandBytes(Convert.ToInt16(cmbBlue.SelectedItem));
        }


        Bitmap createRGB_bil() // create rgb from a bil file
        {
            this.Cursor = Cursors.WaitCursor;
            Bitmap bmp = new Bitmap(imgDat.Ncols, imgDat.Nrows, PixelFormat.Format24bppRgb);
            int res = (imgDat.Ncols) % 4;
            int stride = (imgDat.Ncols + res) * 3;
            byte[] byOut = new byte[stride * imgDat.Nrows];
            Int32 ind = 0;
            red = imgTools.getOneBandBytes(Convert.ToInt16(cmbRed.SelectedItem));
            green = imgTools.getOneBandBytes(Convert.ToInt16(cmbGreen.SelectedItem));
            blue = imgTools.getOneBandBytes(Convert.ToInt16(cmbBlue.SelectedItem));
            for (int i = 0; i < imgDat.Nrows; i++)
            {
                for (int j = 0; j < imgDat.Ncols; j++)
                {
                    byte redb = red[i * imgDat.Ncols + j];
                    byte greenb = green[i * imgDat.Ncols + j];
                    byte blueb = blue[i * imgDat.Ncols + j];
                    byOut[ind] = blueb;
                    ind++;
                    byOut[ind] = greenb;
                    ind++;
                    byOut[ind] = redb;
                    ind++;
                }
                ind += res;
            }

            bmp = imgTools.ByteArrayToBitmap(byOut, imgDat.Ncols, imgDat.Nrows);
            this.Cursor = Cursors.Default;
            return bmp;        
        }

        byte[] readGwrFile(string fName) // read the given giwer file
        {
            byte[] byteIn = System.IO.File.ReadAllBytes(fName);
            return byteIn;
        }

        byte[] mergeRGBBands_gwr() // create rg from giwer files
        {
            //int res = (imgDat.Ncols) % 4;
            //Math.DivRem(4 - res, 4, out res);
            int res = (imgDat.Ncols) % 4;
            Int32 stride = (imgDat.Ncols + res) * 3;

            //int res = (imgDat.Ncols) % 4;
            //int stride = (imgDat.Ncols + res) * 3;
            byte[] byOut = new byte[stride * imgDat.Nrows];
            Int32 ind = 0;
            this.Cursor = Cursors.WaitCursor;
            for (int i = 0; i < imgDat.Nrows; i++)
            {
                for (int j = 0; j < imgDat.Ncols; j++)
                {
                    byte redb = red[i * imgDat.Ncols + j];
                    byte greenb = green[i * imgDat.Ncols + j];
                    byte blueb = blue[i * imgDat.Ncols + j];
                    byOut[ind] = blueb;
                    ind++;
                    byOut[ind] = greenb;
                    ind++;
                    byOut[ind] = redb;
                    ind++;
                }
                ind += res;
            }
            //Bitmap bmp = new Bitmap(imgDat.Ncols, imgDat.Nrows, PixelFormat.Format24bppRgb);
            //bmp = imgTools.ByteArrayToBitmap(byOut, imgDat.Ncols, imgDat.Nrows);
            this.Cursor = Cursors.Default;
            return byOut;
            //return bmp;
        }

        Bitmap createRGB_gwr() // create rgb from giwer files
        {
            int res = (imgDat.Ncols) % 4;
            int stride = (imgDat.Ncols + res) * 3;
            byte[] byOut = new byte[stride * imgDat.Nrows];
            Int32 ind = 0;
            this.Cursor = Cursors.WaitCursor;
            for (int i = 0; i < imgDat.Nrows; i++)
            {
                for (int j = 0; j < imgDat.Ncols; j++)
                {
                    byte redb = red[i * imgDat.Ncols + j];
                    byte greenb = green[i * imgDat.Ncols + j];
                    byte blueb = blue[i * imgDat.Ncols + j];
                    byOut[ind] = blueb;
                    ind++;
                    byOut[ind] = greenb;
                    ind++;
                    byOut[ind] = redb;
                    ind++;
                }
                ind += res;
            }
            Bitmap bmp = new Bitmap(imgDat.Ncols, imgDat.Nrows, PixelFormat.Format24bppRgb);
            bmp = imgTools.ByteArrayToBitmap(byOut, imgDat.Ncols, imgDat.Nrows);
            this.Cursor = Cursors.Default;
            return bmp;
        }


        private void bttnShowHisto_Click(object sender, EventArgs e) // activates histogram drawing from files in giwer format 
        {
            Histogram3 hist = new Histogram3(red, green, blue, Path.GetFileName(imgDat.FileName));
            if (hist.ShowDialog() == DialogResult.OK)
            {
                red = hist.HistogramEqualization(red, hist.RIntMin, hist.RIntMax);
                green = hist.HistogramEqualization(green, hist.GIntMin, hist.GIntMax);
                blue = hist.HistogramEqualization(blue, hist.BIntMin, hist.BIntMax);
                imw.DrawImageRGB(imgDat, red, green, blue);
            }
        }

        private void bttnHistoEq_Click(object sender, EventArgs e)
        {
            Histogram3 hist = new Histogram3(red, green, blue, Path.GetFileName(imgDat.FileName));
            red = hist.HistogramEqualization(red);
            green = hist.HistogramEqualization(green);
            blue = hist.HistogramEqualization(blue);
            imw.DrawImageRGB(imgDat, red, green, blue);
        }


        private void bttnSaveAsImage_Click(object sender, EventArgs e) // save result as image (tif or jpeg)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Jpg files|*.jpg|Tif files|*.tif";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                Image bmpSave = imw.GetImage();
                string ext = Path.GetExtension(sf.FileName);
                if (ext.ToLower() == ".jpg")
                {
                    bmpSave.Save(sf.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                if (ext.ToLower() == ".tif")
                {
                    bmpSave.Save(sf.FileName, System.Drawing.Imaging.ImageFormat.Tiff);
                }
            }
        }

        private void RGBViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                Properties.Settings.Default["RGBWindowStartLocation"] = this.Location;
                Properties.Settings.Default["RGBWindowState"] = this.WindowState;
                if (this.WindowState == FormWindowState.Normal) Properties.Settings.Default["RGBWindowSize"] = this.Size;
                Properties.Settings.Default.Save();
            }
        }
    }
}

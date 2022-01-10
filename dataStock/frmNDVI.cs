using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Giwer.dataStock
{
    public partial class frmNDVI : Form
    {
        public int NIRed;
        public int Red;
        GeoImageData imgDat;
        ImageWindow iw = new ImageWindow();  //new ImageWindow("0", "0");
        string GiwerDataFolder;
        byte[] currentBand;
        int[] colPalette;
        public frmNDVI(GeoImageData imgD, string gdf)
        {
            GiwerDataFolder = gdf;
            imgDat = imgD;
            InitializeComponent();
            for (int i=0;i < imgDat.Nbands; i++)
            {
                cmbInfraRed.Items.Add(i);
                cmbRed.Items.Add(i);
            }
            cmbRed.SelectedIndex = 2;
            loadAvailableCPFiles();
            //colPalette = loadColorPalette(Application.StartupPath + "\\" + cmbColorPalettes.SelectedItem + ".cp");
            if (imgDat.Nbands > 3) { cmbInfraRed.SelectedIndex = 3; }
        }

        void loadAvailableCPFiles()
        {
            string[] fileEntries = Directory.GetFiles(Application.StartupPath, "*.cp");
            foreach (string item in fileEntries)
            {
                cmbColorPalettes.Items.Add(Path.GetFileNameWithoutExtension(item.ToLower()));
            }
            cmbColorPalettes.SelectedItem = "ndvi";
        }

        Int32[] loadColorPalette(string fileName)
        {
            Int32[] cp = new Int32[256];
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    sr.ReadLine();
                    for (int i = 0; i < 256; i++)
                    {
                        string line = sr.ReadLine();
                        Int32 col = Convert.ToInt32(line.Split(';')[1]);
                        cp[i] = col;
                    }
                }
            }
            return cp;
        }

        private void bttnOK_Click(object sender, EventArgs e)
        {
            colPalette = loadColorPalette(Application.StartupPath + "\\" + cmbColorPalettes.SelectedItem + ".cp");
            NIRed = cmbInfraRed.SelectedIndex;
            Red = cmbRed.SelectedIndex;
            this.Cursor = Cursors.WaitCursor;
            panel1.Controls.Add(iw);
            iw.Dock = DockStyle.Fill;
            iw.Show();
            GeoMultiBandMethods ndvi = new GeoMultiBandMethods();
            string filesNamesNIR = GiwerDataFolder + "\\" + System.IO.Path.GetFileNameWithoutExtension(imgDat.FileName) + @"\" + NIRed + ".gwr";
            string filesNamesRed = GiwerDataFolder + "\\" + System.IO.Path.GetFileNameWithoutExtension(imgDat.FileName) + @"\" + Red + ".gwr";
            if (NIRed != -1 & Red != -1)
            {
                GeoImageData gima = new GeoImageData();
                gima.FileName = GiwerDataFolder + "\\" + System.IO.Path.GetFileNameWithoutExtension(imgDat.FileName) + ".gwh";
                GeoImageTools gmt = new GeoImageTools(gima);
                byte[] bnir = gmt.readGwrFile(filesNamesNIR);
                byte[] bred = gmt.readGwrFile(filesNamesRed);
                currentBand = ndvi.NDVI(bnir, bred);
                iw.DrawImage(gima, currentBand, colPalette);
                //iw.InitImage(gmt.convertOneBandBytesto8bitBitmap(currentBand,imgDat.Ncols,imgDat.Nrows,colPalette));
                bttnHisto.Visible = true;
                bttnSaveAsImage.Visible = true;
                bttnSaveToGiwerFormat.Visible = true;
            }
            else { MessageBox.Show("Missing band! Two bands need to be selected"); }
            this.Cursor = Cursors.Default;
        }

        private void bttnHisto_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(imgDat.Ncols, imgDat.Nrows);
            Histogram3 hist = new Histogram3(currentBand, System.IO.Path.GetFileName(imgDat.FileName));
            GeoImageTools gmt = new GeoImageTools();
            if (hist.ShowDialog() == DialogResult.OK)
            {
                GeoMultiBandMethods gm = new GeoMultiBandMethods();
                currentBand = hist.HistogramEqualization(currentBand, hist.IntMin, hist.IntMax);
                if (imgDat.FileType == GeoImageData.fTypes.GWH)
                {
                    iw.DrawImage(imgDat, currentBand, colPalette);
                    //iw.InitImage(gmt.convertOneBandBytesto8bitBitmap(currentBand, imgDat.Ncols, imgDat.Nrows, colPalette));
                    //Bitmap bm = gm.createRGB_gwr(imgDat, currentBand, currentBand, currentBand);
                    //iw.loadImage(bm);
                }
                if (imgDat.FileType == GeoImageData.fTypes.BIL)
                {
                    Bitmap bm = gm.createRGB_gwr(imgDat, currentBand, currentBand, currentBand);
                    //iw.loadImage(bm);
                }
            }
        }

        private void bttnSaveAsImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Jpg files|*.jpg|Tif files|*.tif";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                Image bmpSave = iw.GetImage();
                string ext = System.IO.Path.GetExtension(sf.FileName);
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

        private void bttnSaveToGiwerFormat_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Giwer header|*.gwh";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                GeoImageTools gita = new GeoImageTools(imgDat);
                frmTextInput tbInput = new frmTextInput("Comment");
                tbInput.ShowDialog();
                string desc = tbInput.inpuText;
                gita.saveOneBandResultAsGiwerFormat(sf.FileName, currentBand, desc);
            }
        }
    }
}

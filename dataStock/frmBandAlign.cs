using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Giwer.dataStock
{
    public partial class frmBandAlign : Form
    {
        string currentFolder;
        GeoImageData gimda;
        public enum opType { Plus, Minus, Exor };
        public opType operationType;
        int cropMargin; // margin around the image in pixels. Image will be croped outside of this mrgin
        int offset;  // buffer for image aligning in pixels
        ImageWindow imw = new ImageWindow();
        List<string> shifts = new List<string>();

        public frmBandAlign()
        {
            InitializeComponent();
            stLabFolder.Text = "";
        }

        public frmBandAlign(GeoImageData gd)
        {
            InitializeComponent();
            bttnOK.Select();
            gimda = gd;
            stLabFolder.Text = "";
            fillList();
            panel1.Controls.Add(imw);
            imw.Dock = DockStyle.Fill;
            imw.BackColor = Color.White;
            imw.Visible = true;
            imw.BringToFront();

        }


        void fillList()
        {
            bttnOK.Enabled = true;
            currentFolder = System.IO.Path.GetDirectoryName(gimda.FileName) + @"\" + System.IO.Path.GetFileNameWithoutExtension(gimda.FileName);
            stLabFolder.Text = "Current folder: " + currentFolder;
            for (int i = 0; i < gimda.Nbands; i++)
            {
                lstFiles.Items.Add("Band_" + i);
            }
        }

        private void bttnOpenBands_Click(object sender, EventArgs e)
        {
            lstFiles.Items.Clear();
            bttnOK.Enabled = true;
            currentFolder = System.IO.Path.GetDirectoryName(gimda.FileName);
            stLabFolder.Text = "Current folder: " + currentFolder;
            fillList();
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void bttnClearList_Click(object sender, EventArgs e)
        {
            lstFiles.Items.Clear();
            bttnOK.Enabled = false;
            imw.Clear(gimda);
            panel1.Visible = false;
        }

        private void bttnClearSelected_Click(object sender, EventArgs e)
        {
            if (lstFiles.SelectedIndex != -1)
            {
                lstFiles.Items.RemoveAt(lstFiles.SelectedIndex);
                imw.Clear(gimda);
                panel1.Visible = false;
                if (lstFiles.Items.Count == 0) bttnOK.Enabled = false;
            }
            else { MessageBox.Show("There is no selected item"); }

        }

        private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFiles.SelectedItem != null)
            {
                GeoImageTools gtools = new GeoImageTools();

                string fn = currentFolder + @"\" + lstFiles.SelectedItem.ToString().Split('_')[1] + ".gwr";
                byte[] by = gtools.readGwrFile(fn);
                imw.DrawImage(gimda, by, loadColorPalette(Application.StartupPath + "\\" + "default.cp"));
                panel1.Visible = true;
            }
            else { panel1.Visible = false; }
        }

        Int32[] loadColorPalette(string fileName) // loads a color palette
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
            textBox1.Text = "";
            if (lstFiles.Items.Count > 1)
            {
                this.Cursor = Cursors.WaitCursor;
                AligningBands();
                this.Cursor = Cursors.Default;
            }
            else { MessageBox.Show("Too few files on the list. You need two files at least. Add another one or more", "Too few files", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
            bttnClose.Focus();
            bttnOK.Enabled = false;
        }


        void AligningBands() // band aligning for all bands: Band0 - Band1, Band0 - Band2, Band0 - Band3, ...
        {
            shifts.Clear();
            pbar.Minimum = 0;
            pbar.Maximum = lstFiles.Items.Count - 1;
            pbar.Step = 1;
            pbar.Value = 0;
            pbar.Visible = true;
            cropMargin = 100 * (int)(gimda.Nrows / 300);
            offset = (int)(cropMargin / 15);
            GeoImageTools gtools = new GeoImageTools(gimda);
            List<float> listOfDiffs;
            List<string> listOfInds;
            Point startp1 = new Point(gimda.Ncols / 2 - cropMargin / 2, gimda.Nrows / 2 - cropMargin / 2);
            string fname1 = currentFolder + "\\" + lstFiles.Items[0].ToString().Split('_')[1] + ".gwr";
            byte[] fileToCombine1 = ClipImage(gtools.readGwrFile(fname1), startp1, new Size(cropMargin, cropMargin), gimda.Ncols, gimda.Nrows);
            Point startp2 = startp1;
            shifts.Add("0;0");
            textBox1.Text = "";
            for (int i = 1; i < lstFiles.Items.Count; i++) // computes differences between bands one after the other
            {
                pbar.PerformStep();
                Application.DoEvents();
                string fname2 = currentFolder + "\\" + lstFiles.Items[i].ToString().Split('_')[1] + ".gwr";
                byte[] fileToCombine2 = gtools.readGwrFile(fname2);
                DifferenceOfShifts(fileToCombine1, fileToCombine2, startp2, out listOfDiffs, out listOfInds);
                float min;
                string minindex;
                getMin(listOfDiffs, listOfInds, out min, out minindex);
                shifts.Add(minindex);
                listOfDiffs.Clear();
                listOfInds.Clear();
                if (i > 1) textBox1.AppendText(Environment.NewLine);
                textBox1.AppendText("B0-B" + i + " -> shift: " + minindex);
                //textBox1.AppendText(Environment.NewLine + "difference: " + min.ToString("#.###"));
                textBox1.Visible = true;
            }
            pbar.Visible = false;
            string minmax = getShiftsMinMax();
            recoverBands(minmax);
            MessageBox.Show("Align process completed");
        }

        void recoverBands(string minmax) // minmax =  minx; miny; maxx; maxy; minindex; maxindex
        {
            GeoImageTools gt = new GeoImageTools(gimda);
            GeoImageData gdOut = new GeoImageData();
            gdOut = gimda;
            int widorig = gimda.Ncols;
            int hgtorig = gimda.Nrows;
            byte[] byin = new byte[widorig * hgtorig];
            int maxindex = Convert.ToInt16(minmax.Split(';')[5]);
            int minindex = Convert.ToInt16(minmax.Split(';')[4]);
            int a = Math.Abs(Convert.ToInt16(shifts[minindex].Split(';')[0])); // get minx value from the shifts list
            int b = Math.Abs(Convert.ToInt16(shifts[maxindex].Split(';')[0])); // get maxx value from the shifts list
            int newwid = widorig - (a + b);
            int c = Math.Abs(Convert.ToInt16(shifts[minindex].Split(';')[1])); // get miny value from the shifts list
            int d = Math.Abs(Convert.ToInt16(shifts[maxindex].Split(';')[1])); // get maxy value from the shifts list
            int newhgt = hgtorig - (c + d);
            gdOut.Ncols = newwid;
            gdOut.Nrows = newhgt;
            gdOut.Nbits = 8;
            Size commonSize = new Size(newwid, newhgt);
            string fn = Path.GetDirectoryName(gimda.FileName) + "\\" + Path.GetFileNameWithoutExtension(gimda.FileName) + "_aligned.gwh";
            GeoImageTools gtsave = new GeoImageTools(gdOut);
            gtsave.saveHeader2Giwer(fn);
            gdOut.FileName = fn;
            gtsave.saveHeader2Giwer(fn);

            for (int i = 0; i < lstFiles.Items.Count; i++)
            {
                int px = Math.Abs(Convert.ToInt16(shifts[i].Split(';')[0]));
                int py = Math.Abs(Convert.ToInt16(shifts[i].Split(';')[1]));
                //int px = Convert.ToInt16(shifts[maxindex].Split(';')[0]) - Convert.ToInt16(shifts[i].Split(';')[0]);
                //int py = Convert.ToInt16(shifts[maxindex].Split(';')[1]) - Convert.ToInt16(shifts[i].Split(';')[1]);
                Point startp = new Point(px, py);
                string fname = currentFolder + "\\" + lstFiles.Items[i].ToString().Split('_')[1] + ".gwr";
                byin = gtsave.readGwrFile(fname);
                byte[] byOut = ClipImage(byin, startp, commonSize, widorig, hgtorig);
                string dirname = Path.GetDirectoryName(gdOut.FileName) + "\\" + Path.GetFileNameWithoutExtension(gdOut.FileName);
                gt.saveGivenBand2GiwerFormat(dirname, byOut, i, "");
            }
        }

        string getShiftsMinMax()
        {
            const int min = 1000000;
            const int max = -min;
            string minmax;
            int minx = min;
            int miny = min;
            int maxx = max;
            int maxy = max;
            int minindex = min;
            int maxindex = -min; ;
            for (int i = 0; i < shifts.Count; i++)
            {
                if (((Convert.ToInt32(shifts[i].Split(';')[0]))) < minx) { minx = Convert.ToInt32(shifts[i].Split(';')[0]); minindex = i; }
                if (((Convert.ToInt32(shifts[i].Split(';')[0]))) > maxx) { maxx = Convert.ToInt32(shifts[i].Split(';')[0]); maxindex = i; }
                if (((Convert.ToInt32(shifts[i].Split(';')[1]))) < miny) { miny = Convert.ToInt32(shifts[i].Split(';')[1]); minindex = i; }
                if (((Convert.ToInt32(shifts[i].Split(';')[1]))) > maxy) { maxy = Convert.ToInt32(shifts[i].Split(';')[1]); maxindex = i; }
            }
            //minmax = new Rectangle(minx, miny, maxx, maxy);
            minmax = minx + ";" + miny + ";" + maxx + ";" + maxy + ";" + minindex + ";" + maxindex;
            return minmax;
        }


        //compute band shifts between im1 and im2 bands started at startpoint from -halfoffset to halfoffset
        void DifferenceOfShifts(byte[] im1, byte[] im2, Point startpoint, out List<float> lstDiffs, out List<string> lstInds)
        {
            lstDiffs = new List<float>();
            lstInds = new List<string>();
            Size sz = new Size(cropMargin, cropMargin);
            byte[] im3; // = new byte[cropMargin * cropMargin];
            byte[] difference; // = new byte[im3.Length];
            GeoImageTools gtools = new GeoImageTools(gimda);
            int halfoffset = offset / 2;
            for (Int32 i = -halfoffset; i < halfoffset; i++)
            {
                for (Int32 j = -halfoffset; j < halfoffset; j++)
                {
                    im3 = ClipImage(im2, new Point(startpoint.X + j, startpoint.Y + i), sz, gimda.Ncols, gimda.Nrows);
                    difference = gtools.combine2Images(GeoImageTools.OperationType.Minus, im1, im3);
                    lstDiffs.Add(summa(difference));
                    lstInds.Add(j + ";" + i);
                }
            }
        }

        byte[] ClipImage(byte[] byIn, Point imStart, Size imSize, Int32 IWidth, Int32 IHeight) //clips a image (byin) with new imagesize
        {
            Int32 k = 0;
            Int32 endy = imSize.Height + imStart.Y;
            Int32 endx = imSize.Width + imStart.X;
            byte[] byOut = new byte[(imSize.Width * imSize.Height)];
            for (Int32 i = imStart.Y; i < endy; i++)
            {
                for (Int32 j = imStart.X; j < endx; j++)
                {
                    byOut[k] = byIn[j + i * IWidth];
                    k++;
                }
            }
            return byOut;
        }
        float summa(byte[] bin) // summarize a byte array elements normed by array length
        {
            float summa = 0;
            foreach (byte s in bin)
            {
                summa += s;
            }
            return summa /= bin.Length;
        }

        void getMin(List<float> lstDif, List<string> lstInd, out float min, out string minIndex) // gets min value and minindex from lists
        {
            min = 100000;
            minIndex = "";
            for (int ind = 0; ind < lstDif.Count; ind++)
            {
                if (lstDif[ind] < min)
                {
                    min = lstDif[ind];
                    minIndex = lstInd[ind];
                }
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Threading;

namespace Giwer.dataStock
{
    public partial class frmClassifyBySpectrum : Form
    {
        string SpectrumBankPath;
        SQLiteConnectionStringBuilder cnsb = new SQLiteConnectionStringBuilder();
        DataTable spectrums = new DataTable();
        byte[,] specb;
        string spectrumBankPath;
        ImageWindow iw = new ImageWindow();
        //byte[] byOut;
        double[,] corrOut;
        GeoImageData gida = new GeoImageData();
        frmConfig conf = new frmConfig();
        string GiwerDataFolder="";
        Int32[] colorpal = new int[256];

        public frmClassifyBySpectrum(string specPath, Int32[] cp)
        {
            InitializeComponent();
            colorpal = cp;
            SpectrumBankPath = specPath;
            cnsb.DataSource = specPath;
            if (System.IO.File.Exists(specPath))
            {
                LoadAvailableBanks();
                tslblBankFile.Text = specPath;
            }
            else tslblBankFile.Text = "";
            iw.Dock = DockStyle.Fill;
            iw.BackColor = Color.White;
            iw.tsbttnSpectrum.Visible = false;
            iw.Visible = false;
            this.panel1.Controls.Add(iw);
            spectrumBankPath = conf.config["SpectrumBankPath"];
            tslblBankFile.Text = "Spectrum bank file - " + Path.GetFileName(spectrumBankPath);
            GiwerDataFolder = conf.config["GiwerDataFolder"];
            tslblGiwerFileName.Text = "";
        }

        void LoadAvailableBanks()
        {
            cmbSpecBanks.Items.Clear();
            DataTable dt = new DataTable();
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                dt = loadTableData("select bankname from banks");
                if (dt == null) { tslblBankFile.Text = ""; return; }
                foreach(DataRow row in dt.Rows)
                {
                    cmbSpecBanks.Items.Add(row[0].ToString());
                }
            }
        }

        DataTable loadTableData(string cmdSql)
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection cnn = new SQLiteConnection(cnsb.ConnectionString))
            {
                try
                {
                    cnn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(cmdSql, cnn))
                    {
                        SQLiteDataReader dr = cmd.ExecuteReader();
                        dt.Load(dr);
                    }
                    return dt;
                }
                catch (SQLiteException e)
                {
                    MessageBox.Show("Error in SQL command:" + e.Message, "Sql error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        private void cmbSpecBanks_SelectedIndexChanged(object sender, EventArgs e)
        {
            spectrums = loadTableData("select name, band, intensity from spectrums where bankname='" + cmbSpecBanks.SelectedItem + "'");
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.InitialDirectory = GiwerDataFolder;
            of.Filter = "Giwer header files|*.gwh";
            if (of.ShowDialog()==DialogResult.OK)
            {
                gida.FileName = of.FileName;

                tslblGiwerFileName.Text = "   Giwer data file name - " + Path.GetFileName(gida.FileName) + "      ";
            }
        }

        private void btnOpenSpectrumBank_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.InitialDirectory = Path.GetDirectoryName(spectrumBankPath);
            of.Filter = "Spectrum bank files|*.s3db";
            if (of.ShowDialog() == DialogResult.OK)
            {
                spectrumBankPath = of.FileName;
                tslblBankFile.Text = "Spectrum bank file - " + Path.GetFileName(spectrumBankPath);
                LoadAvailableBanks();
            }
        }

        private void btnStartClassification_Click(object sender, EventArgs e)
        {
            double eps;
            byte[] currentBand;
            int len;
            int size=gida.Nrows * gida.Ncols;
                this.Cursor = Cursors.WaitCursor;
            if (!iw.Visible)
            {
                tsPb.Visible = true;
                tsPb.Maximum = gida.Nbands;

                /*byte[,]*/ specb = getSpectrumBankValues();
                //Task.Factory.StartNew(runProcess).ContinueWith(task =>
                //{
                    corrOut = runProcess(specb);
                    len = corrOut.GetLength(0);
                    eps = Convert.ToDouble(tbConfidenceValue.Text, System.Globalization.CultureInfo.InvariantCulture);
                      //new double[gida.Nbands, size];
                    currentBand = compare(size, len, corrOut, eps);
                    iw.Clear(gida);
                    iw.DrawImage(gida, currentBand, colorpal);
                    iw.Visible = true;            
                    iw.Show();
                    tsPb.Visible = false;
                    tsPb.Value = 0;
                //});
                this.Cursor = Cursors.Default;
            }
            else
            {
                eps = Convert.ToDouble(tbConfidenceValue.Text, System.Globalization.CultureInfo.InvariantCulture);
                len = corrOut.GetLength(0);
                currentBand = compare(size, len, corrOut, eps);
                iw.Clear(gida);
                iw.DrawImage(gida, currentBand, colorpal);
            }

        }

        void runProcess()
        {
            int size = gida.Nrows * gida.Ncols;
            int len = specb.GetLength(0); // iSpec is the spektrum bank intensity values, len is number of cathegory
            /*double[,]*/ corrOut = new double[len, size];
            byte[] bOut = new byte[size];
            byte[] iPixelValues = null; //current pixel's intensity values
            byte[] spect = new byte[gida.Nbands];
            FileStream[] fs = new FileStream[gida.Nbands];
            BinaryReader[] br = new BinaryReader[gida.Nbands];
            for (int i = 0; i < gida.Nbands; i++)
            {
                //tsPb.PerformStep();
                string path = Path.GetDirectoryName(gida.FileName) + @"\" + Path.GetFileNameWithoutExtension(gida.FileName) + @"\" + i + ".gwr";
                using (fs[i] = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    for (int ipix = 0; ipix < size; ipix++)  //run process for every cathegory
                    {
                        br[i] = new BinaryReader(fs[i]);
                        fs[i].Seek(ipix, SeekOrigin.Begin);
                        spect[i] = br[i].ReadByte();
                    }
                }
            }
            //tsPb.Value = 0;
            //tsPb.Maximum = size;
            for (int ipix = 0; ipix < size; ipix++)  //run process for every cathegory
            {
                //tsPb.PerformStep();
                iPixelValues = readCurrentPosition(ipix);
                for (int i = 0; i < len; i++)
                {
                    StatMath sm = new StatMath();
                    byte[] b = Enumerable.Range(0, specb.GetLength(1)).Select(x => specb[i, x]).ToArray();
                    corrOut[i, ipix] = sm.computeCorrelation(b, iPixelValues);
                }
            }
        }

        byte[] compare(int size, int len, double[,] corrOut, double eps)
        {
            byte[] bOut = new byte[size];
            //double eps = Convert.ToDouble(tbConfidenceValue.Text, System.Globalization.CultureInfo.InvariantCulture);
            int step = 256 / len;
            for (int icat = 0; icat < len; icat++)
            {
                for (int ipx = 0; ipx < size; ipx++)
                {
                    if (corrOut[icat, ipx] > eps) bOut[ipx] = (byte)(255 - (icat) * step);
                }
            }
            return bOut;
        }

        byte[,] getSpectrumBankValues()
        {
            DataTable dtCathegoryNames = loadTableData("select name from spectrums where bankname='" + cmbSpecBanks.SelectedItem.ToString() + "' group by name"); // getting cathegory names from 'spectrums' table
            DataTable numofspecitem = loadTableData("select count(*) from spectrums where name='" + dtCathegoryNames.Rows[0][0].ToString() + "'");
            int leng = int.Parse(numofspecitem.Rows[0][0].ToString());
            int catNum = dtCathegoryNames.Rows.Count;
            byte[,] iSpec = new byte[catNum, leng] ; 
            int k = 0;
            for (int i = 0; i < catNum; i++)  //run process for every cathegory
            {
                DataTable dtSpec = loadTableData("select band, intensity from spectrums where name='" + dtCathegoryNames.Rows[i][0].ToString() + "'");  // select spectrum values for every cathegory (name) in a datatable (dtSpec)

                for (int j = 0; j < dtSpec.Rows.Count; j++) // convert spectrum values of the given cathegory (dtSpec.Rows) to an byte array (iSpec)
                {
                    iSpec[k, j] = byte.Parse(dtSpec.Rows[j]["intensity"].ToString());
                }
                k += 1;
            }          
            return iSpec;
        }
         
        double[,] runProcess(byte[,] iSpec)
        {
            int size = gida.Nrows * gida.Ncols;
            int len = iSpec.GetLength(0); // iSpec is the spektrum bank intensity values, len is number of cathegory
            double[,] corrOut = new double[len, size];
            byte[] bOut = new byte[size];           
            byte[] iPixelValues = null; //current pixel's intensity values
            byte[] spect = new byte[gida.Nbands];
            FileStream[] fs = new FileStream[gida.Nbands];
            BinaryReader[] br = new BinaryReader[gida.Nbands];
            for (int i = 0; i < gida.Nbands; i++)
            {
                tsPb.PerformStep();
                string path = Path.GetDirectoryName(gida.FileName) + @"\" + Path.GetFileNameWithoutExtension(gida.FileName) + @"\" + i + ".gwr";
                using (fs[i] = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    for (int ipix = 0; ipix < size; ipix++)  //run process for every cathegory
                    {
                        br[i] = new BinaryReader(fs[i]);
                        fs[i].Seek(ipix, SeekOrigin.Begin);
                        spect[i] = br[i].ReadByte();
                    }
                }
            }
            tsPb.Value = 0;
            tsPb.Maximum = size;
            for (int ipix = 0; ipix < size; ipix++)  //run process for every cathegory
            {
                tsPb.PerformStep();
                iPixelValues = readCurrentPosition(ipix);
                for (int i = 0; i < len; i++)
                {
                    StatMath sm = new StatMath();
                    byte[] b = Enumerable.Range(0, iSpec.GetLength(1)).Select(x => iSpec[i, x]).ToArray();
                    corrOut[i, ipix] = sm.computeCorrelation(b, iPixelValues);
                }
            }
            return corrOut;
        }

        byte[] readCurrentPosition(Int32 bytePosition)
        {
            byte[] spect = new byte[gida.Nbands];
            FileStream[] fs=new FileStream[gida.Nbands];
            BinaryReader[] br = new BinaryReader[gida.Nbands];
            for (int i=0; i<gida.Nbands; i++)
            {
                string path = Path.GetDirectoryName(gida.FileName) + @"\" + Path.GetFileNameWithoutExtension(gida.FileName) + @"\" + i + ".gwr";
                using (fs[i]=new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                br[i] = new BinaryReader(fs[i]);
                    fs[i].Seek(bytePosition, SeekOrigin.Begin);
                    spect[i] = br[i].ReadByte();
                }
            }
            return spect;
        }


        public byte[] getCurrentSpectrum(Int32 bytePosition) //gets intensity values for each bands in a current pixel (current spectrum)
        {

            byte[] spec=new byte[gida.Nbands];   //spec = new Point[gida.Nbands];
            for (int i = 0; i < gida.Nbands; i++)
            {
                spec[i] = getPixelValue(bytePosition, i);
            }
            return spec;
        }

        byte getPixelValue(int position, int band) //get pixel values of a given position in a given band
        {
            byte value = 0;
            string path = Path.GetDirectoryName(gida.FileName) + @"\" + Path.GetFileNameWithoutExtension(gida.FileName) + @"\" + band + ".gwr";
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

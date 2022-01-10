using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Giwer.dataStock
{
    public partial class frmSpectrumAnalysis : Form
    {
        GeoImageData gida;
        byte[] currentBand;
        Int32[] colorpal = new int[256];
        ImageWindow imw = new ImageWindow();
        frmSpectrum spectrum = new frmSpectrum();
        Point[] spec;
        Point cursorPosition= new Point(0,0);

        public frmSpectrumAnalysis(GeoImageData gimda, Int32[] colp)
        {
            InitializeComponent();
            gida = gimda;
            colorpal = colp;
            fillListBands();
            splitContainer1.Panel2.Controls.Add(imw);
            imw.Dock = DockStyle.Fill;
            GeoImageTools GTools = new GeoImageTools(gida);
            currentBand = GTools.getOneBandBytes(lstBands.SelectedIndex);
            imw.DrawImage(gida, currentBand, colp);
            spectrum.Show();
            spectrum.BringToFront();
            spectrum.Location = new Point(0, 0);
            //spec = new Point[gida.Nbands];
            //createSpectrum(cursorPosition);
            //spectrum.displaySpectrum(spec);

        }

        public void createSpectrum(Point cursor)
        {
            Int32 bytePosition = 0;
            for (int i=0; i < gida.Nbands; i++)
            {
                spec[i] = new Point(i, getPixelValue(i, bytePosition));
            }
        }

        int getPixelValue(int position, int band)
        {
            int value = 0 ;
            string path = Path.GetDirectoryName(gida.FileName) + @"\" + Path.GetFileNameWithoutExtension(gida.FileName) + @"\" + band + ".gwr";
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                BinaryReader br = new BinaryReader(fs);
                fs.Seek(position,SeekOrigin.Begin);
                value = br.ReadByte();
            }
            return value;
        }
        

        void fillListBands()
        {
            for (int i = 0; i < gida.Nbands; i++) { lstBands.Items.Add("Band_" + i); lstBands.SelectedIndex = 0; }
        }

        private void lstBands_SelectedIndexChanged(object sender, EventArgs e)
        {
            imw.Dock = DockStyle.Fill;
            GeoImageTools GTools = new GeoImageTools(gida);
            currentBand = GTools.getOneBandBytes(lstBands.SelectedIndex);
            imw.DrawImage(gida, currentBand, colorpal);
            spec = new Point[gida.Nbands];
            createSpectrum(cursorPosition);
            spectrum.displaySpectrum(spec,gida.Wavelength);
            spectrum.BringToFront();
        }
    }
}

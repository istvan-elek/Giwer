using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace Giwer
{
    public class ESRI_BIL
    {
        // properties -------------------------------------------
        string _filename;
        public string FileName
        {
            get
            {
                return _filename;
            }
            set
            {
                _filename = value;
                parseHeader();
            } 
        }


        string _byteorder;
        public string ByteOrder
        {
            get { return _byteorder; }
        }

        int _nbits;
        public int Nbits
        {
            get { return _nbits; }
        }

        double _xdim;
        public double Xdim
        {
            get { return _xdim; }
        }

        double _ydim;
        public double Ydim
        {
            get { return _ydim; }
        }

        double _cellsize;
        public double  CellSize
        { get { return _cellsize; } }

        int _ncols;
        public int Ncols
        {
            get { return _ncols; }
        }

        int _nrows;
        public int Nrows
        {
            get { return _nrows; }
        }

        int _nbands;
        public int Nbands
        {
            get { return _nbands; }
        }

        double _ulxmap;
        public double Ulxmap
        {
            get { return _ulxmap; }
        }

        double _ulymap;
        public double Ulymap
        {
            get { return _ulymap; }
        }

        double _xllcenter;
        public double XllCenter
        { get { return _xllcenter; } }

        double _yllcenter;
        public double YllCenter
        { get { return _yllcenter; } }

        string _comment="";
        public string Comment
        {
            get { return _comment; }
        }

        string _layout = "";
        public string Layout
        { get{ return _layout; } }


        // local procedures
        void parseHeader()
        {
            using (FileStream fs = new FileStream(_filename, FileMode.Open, FileAccess.Read))
            {
                StreamReader sr = new StreamReader(fs);
                string line;
                while (!sr.EndOfStream)
                {
                    line = System.Text.RegularExpressions.Regex.Replace(sr.ReadLine(), @"\s{2,}", " "); // multi space are removed and substitute with one space " "
                    getParams(line);
                }
            }
        }

        void getParams(string line)
        {
            if (line.ToLower().Contains("byteorder")) { _byteorder = line.Split(' ')[1]; }
            if (line.ToLower().Contains("layout")) { _layout = line.Split(' ')[1]; }
            if (line.ToLower().Contains("nbits")) { _nbits = Convert.ToInt16( line.Split(' ')[1]);}
            if (line.ToLower().Contains("xdim")) { _xdim = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("ydim")) { _ydim = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("ncols")) { _ncols = Convert.ToInt16(line.Split(' ')[1]); }
            if (line.ToLower().Contains("nrows")) { _nrows = Convert.ToInt16(line.Split(' ')[1]); }
            if (line.ToLower().Contains("nbands")) { _nbands = Convert.ToInt16(line.Split(' ')[1]); }
            if (line.ToLower().Contains("ulxmap")) { _ulxmap = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("ulymap")) { _ulymap = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.Substring(0, 1) == "#") { _comment = line; }
            if (line.ToLower().Contains("xllcenter")) { _xllcenter = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("yllcenter")) { _yllcenter = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }
            if (line.ToLower().Contains("cellsize")) { _cellsize = Convert.ToDouble(line.Split(' ')[1], System.Globalization.CultureInfo.InvariantCulture); }

        }



        // global procedures and functions ---------------------------------------------------------


        public byte[] getOneBandBytes(int whichBand) //this routine reads only the given band (whichBand) from the binary file (_fileName), and put values to a byte array (byteOut)
        {
            byte[] byteOut = new byte[_ncols * _nrows];


            using (FileStream fs = new FileStream(System.IO.Path.ChangeExtension(_filename, "bil"), FileMode.Open, FileAccess.Read))
            {
                BinaryReader br = new BinaryReader(fs);

                int ind = 0;
                int startPos = 0;

                for (int i = 0; i < _nrows; i++)
                {
                    startPos = (_nbands * i + whichBand) * _ncols; //  _nbands * _ncols * i  + whichBand * _ncols
                    fs.Position = startPos;
                    for (int j = 0; j < _ncols; j++)
                    {
                        byteOut[ind] = br.ReadByte();
                        ind++;
                    }
                }
            }
            return byteOut;
        }



        public Bitmap convertOneBandBytestoBitmap(byte[] byIn)  //this routine converts values of one band, which stored in a byte array (ByIn). It comes from getOneBandBytes (whichBand) routine.
        {
            Bitmap bmp = new Bitmap(_ncols, _nrows, PixelFormat.Format24bppRgb);

            //getting one band values from the byteIn and convert it to rgb grayscale
            int res = (_ncols) % 4;
            /* the byte lenght of every rows has to be divided by 4 without remainder. 
            If not, rows have to be completed with zeros until the byte length becomes zero remainder */
            int stride = (_ncols + res) * 3;
            byte[] byOut = new byte[stride * _nrows];
            int ind = 0;

            for (int i = 0; i < _nrows; i++)
            {
                ind += res;

                for (int j = 0; j < _ncols; j++)
                {
                    byte b = byIn[i * _ncols + j];
                    for (int k = 0; k < 3; k++)
                    {
                        byOut[ind] = b;
                        ind++;
                    }
                }
            }

            bmp = ByteArrayToBitmap(byOut, _ncols, _nrows);
            return bmp;
        }


        public byte[] BitmapToByteArray(Bitmap img)
        {
            BitmapData bmpData = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, img.PixelFormat);

            int pixelbytes = Image.GetPixelFormatSize(img.PixelFormat) / 8;
            IntPtr ptr = bmpData.Scan0;
            Int32 psize = bmpData.Stride * bmpData.Height;
            byte[] byOut = new byte[psize];
            System.Runtime.InteropServices.Marshal.Copy(ptr, byOut, 0, psize);
            img.UnlockBits(bmpData);
            return byOut;
        }

        //convert byte array to bitmap
        public Bitmap ByteArrayToBitmap(byte[] byteIn, int imwidth, int imheight)
        {
            Bitmap picOut = new Bitmap(imwidth, imheight, PixelFormat.Format24bppRgb);
            BitmapData bmpData = picOut.LockBits(new Rectangle(0, 0, imwidth, imheight), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            IntPtr ptr = bmpData.Scan0;
            Int32 psize = bmpData.Stride * imheight;
            System.Runtime.InteropServices.Marshal.Copy(byteIn, 0, ptr, psize);
            picOut.UnlockBits(bmpData);
            return picOut;
        }

    }
}

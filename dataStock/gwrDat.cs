using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giwer
{
    public class gwrDat
    {
  
        string[] hdr;

        void getHdrParameters(string[] pars)
        {
            foreach (string line in pars)
            {
                if (line.Contains("Source file name")) { _fileName = line.Split(';')[1]; }
                if (line.Contains("BytesPerPixel")) { _bytesPerPixel = Convert.ToInt16(line.Split(';')[1]); }
                if (line.Contains("Nbands")) { _nbands = Convert.ToInt16(line.Split(';')[1]); }
                if (line.Contains("ImageWidth")) { _imageWidth = Convert.ToInt16(line.Split(';')[1]); }
                if (line.Contains("ImageHeight")) { _imageHeight = Convert.ToInt16(line.Split(';')[1]); }
                if (line.Contains("Stride")) { _stride = Convert.ToInt16(line.Split(';')[1]); }
                //if (line.Contains("ColorDepth")) { _pixelFormat = System.Drawing.Imaging.PixelFormat.Format24bppRgb; }
            }
        }

        public void getHdrParameters(string fname)
        {
            hdr = System.IO.File.ReadAllLines(fname);
            foreach (string line in hdr)
            {
                if (line.Contains("Source file name")) { _fileName = line.Split(';')[1]; }
                if (line.Contains("BytesPerPixel")) { _bytesPerPixel = Convert.ToInt16(line.Split(';')[1]); }
                if (line.Contains("Nbands")) { _nbands = Convert.ToInt16(line.Split(';')[1]); }
                if (line.Contains("ImageWidth")) { _imageWidth = Convert.ToInt16(line.Split(';')[1]); }
                if (line.Contains("ImageHeight")) { _imageHeight = Convert.ToInt16(line.Split(';')[1]); }
                if (line.Contains("Stride")) { _stride = Convert.ToInt16(line.Split(';')[1]); }
                //if (line.Contains("ColorDepth")) { _pixelFormat = System.Drawing.Imaging.PixelFormat.Format24bppRgb; }
            }
        }


        string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
                hdr = System.IO.File.ReadAllLines(_fileName);
                getHdrParameters(hdr);
            }
        }

        Int32 _imageWidth;
        public Int32 ImageWidth
        {
            get { return _imageWidth; }
            set { _imageWidth = value; }
        }

        Int32 _imageHeight;
        public Int32 ImageHeight
        {
            get { return _imageHeight; }
            set { _imageHeight = value; }
        }

        int _stride;
        public int Stride
        {
            get { return _stride; }
            set { _stride = value; }
        }

        int _nbands;
        public int Nbands
        {
            get { return _nbands; }
            set { _nbands = value; }
        }

        System.Drawing.Imaging.PixelFormat _pixelFormat;
        public System.Drawing.Imaging.PixelFormat PixelFormat
        {
            get { return _pixelFormat; }
            set { _pixelFormat = value; }
        }

        int _bytesPerPixel;
        public int BytesPerPixel
        {
            get { return _bytesPerPixel; }
            set { _bytesPerPixel = value; }
        }

    }
}

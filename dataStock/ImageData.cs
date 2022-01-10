using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace Giwer
{
    public class ImageData
    {
        string[] hdr;
        public ImageData(string fName, Giwer.frmDataStock.fTypes ftype)
        {
            _fileName = fName;
            _type = ftype;
            if (_type == Giwer.frmDataStock.fTypes.Tif)  { getTifImageParameters(_fileName); }
            if (_type== Giwer.frmDataStock.fTypes.Gwr) { getHdrParameters(fName); }
            if (_type == Giwer.frmDataStock.fTypes.Bil)
            {
                ESRI_BIL bl = new ESRI_BIL();
                bl.FileName = fName;
                bl.parseHeader();
                _fileName = fName;
                _type = ftype;
                _imageHeight = bl.Nrows;
                _imageWidth = bl.Ncols;
                _nbands = bl.Nbands;
                _bytesPerPixel = bl.Nbits;
            }
        }

        public void getHdrParameters(string fname)
        {
            hdr = System.IO.File.ReadAllLines(fname);
            foreach (string line in hdr)
            {
                if (line.Contains("Source file name")) { _fileName = line.Split(';')[1]; }
                if (line.Contains("ImageWidth")) { _imageWidth = Convert.ToInt16(line.Split(';')[1]); }
                if (line.Contains("ImageHeight")) { _imageHeight = Convert.ToInt16(line.Split(';')[1]); }
                if (line.Contains("Nbands")) { _nbands = Convert.ToInt16(line.Split(';')[1]); }
                if (line.Contains("Stride")) { _stride = Convert.ToInt16(line.Split(';')[1]); }
                if (line.Contains("BytesPerPixel")) { _bytesPerPixel = Convert.ToInt16(line.Split(';')[1]); }
            }
        }

        void getTifImageParameters(string _fileName)
        {
            switch (_type)
            {
                case Giwer.frmDataStock.fTypes.Tif:
                    Bitmap bmpTif = (Bitmap)Bitmap.FromFile(_fileName);
                    BitmapData bitmapdataTif = bmpTif.LockBits(new Rectangle(0, 0, bmpTif.Width, bmpTif.Height), ImageLockMode.ReadOnly, bmpTif.PixelFormat);
                    _imageHeight = bmpTif.Height;
                    _imageWidth = bmpTif.Width;
                    _stride = bitmapdataTif.Stride;
                    bmpTif.UnlockBits(bitmapdataTif);
                    _nbands = 3;
                    _bytesPerPixel = 3;
                    bmpTif.Dispose();
                    return;
                case Giwer.frmDataStock.fTypes.Bil:
                    ESRI_BIL bl = new ESRI_BIL();
                    bl.FileName = _fileName;
                    _imageHeight = bl.Nrows;
                    _imageWidth = bl.Ncols;
                    _bytesPerPixel = bl.Nbits;
                    _nbands = bl.Nbands;
                    _stride = bl.Ncols * bl.Nbits;
                    return;
            }
        }

      
        Giwer.frmDataStock.fTypes _type;
        public Giwer.frmDataStock.fTypes Type
        {
            get { return _type; }
        }

        string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set
            {
                _fileName = value;
            }
        }



        int _imageWidth;
        public int ImageWidth
        {
            get { return _imageWidth; }
            set { _imageWidth = value; }
        }

        int _imageHeight;
        public int ImageHeight
        {
            get { return _imageHeight; }
            set { _imageHeight = value; }
        }


        int _stride;
        public int Stride
        {
            get { return _stride; }

        }

        int _nbands;
        public int Nbands
        {
            get { return _nbands; }
            set { _nbands = value; }
        }

        int _bytesPerPixel;
        public int BytesPerPixel
        {
            get { return _bytesPerPixel; }
            set { _bytesPerPixel = value; }
        }
            

    }
}

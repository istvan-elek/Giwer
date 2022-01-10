using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;

namespace Giwer
{
    /* This class contains the following methods:
           * bitmap to byte array conversion
           * byte array to bitmap conversion
    */
    class imageByteArray
    {

        public imageByteArray()
        { }

        //public imageByteArray(Int32 imW, Int32 imH)
        //{
        //    _ncols = imW;
        //    _nrows = imH;
        //    Bitmap bmp = new Bitmap(imW, imH, PixelFormat.Format24bppRgb);
        //    _coldepth = bmp.PixelFormat;
        //    BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, imW, imH), ImageLockMode.ReadOnly, bmp.PixelFormat);
        //    _bytesPerPixel = Image.GetPixelFormatSize(bmp.PixelFormat) / 8;
        //    _stride = bmpData.Stride;
        //    bmp.UnlockBits(bmpData);
        //}

        public imageByteArray(Bitmap bmp)
        {
            _ncols = bmp.Width;
            _nrows = bmp.Height;
            _coldepth = bmp.PixelFormat;
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
            _bytesPerPixel = Image.GetPixelFormatSize(bmp.PixelFormat) / 8;
            _stride = bmpData.Stride;
            bmp.UnlockBits(bmpData);
        }

        //convert bitmap to byte array
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

        //public properties *******************************************************

        private int _stride;
        public int Stride
        {
            get { return _stride; }
        }


        private Int32 _bytesPerPixel;
        public Int32 BytesPerPixel
        {
            get { return _bytesPerPixel; }
        }


        private Int32 _nrows;
        public Int32 Nrows
        {
            get { return _nrows; }
        }


        private Int32 _ncols;
        public Int32 Ncols
        {
            get { return _ncols; }
        }


        private PixelFormat _coldepth;
        public PixelFormat ColDepth
        {
            get { return _coldepth; }
        }


    }
}

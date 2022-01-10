using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;

namespace biller
{
    class imageByteArray
    {
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
    }
}

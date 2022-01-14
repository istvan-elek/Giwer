using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Giwer.dataStock
{
    public class GeoMultiBandMethods
    {
        /* NDVI
         * PCA
         * Clustering
         * Segmentation
         * CreateRGB
         * grayscale conversion
         * invert image
         */

        [UserAttr("u")]
        public byte[] NDVI(byte[] bNIR, byte[] bIR)
        {
            byte[] ndvi = new byte[bNIR.Length];
            for (Int32 i = 0; i < bNIR.Length; i++)
            {
                int d = bNIR[i] + bIR[i];
                if (d > 0)
                {
                    int nd = (255 * (bNIR[i] -
                        bIR[i])) / d;
                    if (nd < 0) { nd = 0; }
                    ndvi[i] = (byte)nd;
                }
            }
            return ndvi;
        }

        [UserAttr("u")]
        public Bitmap createRGB_gwr(GeoImageData imgDat, byte[] red, byte[] green, byte[] blue)
        {
            Bitmap bmp = new Bitmap(imgDat.Ncols, imgDat.Nrows, PixelFormat.Format24bppRgb);
            int res = (imgDat.Ncols) % 4;
            //Math.DivRem(4 - res, 4, out res);
            int stride = (imgDat.Ncols + res) * 3;
            byte[] byOut = new byte[stride * imgDat.Nrows];
            Int32 ind = 0;
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
            GeoImageTools imgTools = new GeoImageTools(imgDat);
            bmp = imgTools.ByteArrayToBitmap(byOut, imgDat.Ncols, imgDat.Nrows);
            return bmp;
        }

        [UserAttr("u")]
        public Bitmap createRGB_gwr(Size ncolnrows, byte[] red, byte[] green, byte[] blue)
        {
            Bitmap bmp = new Bitmap(ncolnrows.Width, ncolnrows.Height, PixelFormat.Format24bppRgb);
            int res = (ncolnrows.Width) % 4;
            //Math.DivRem(4 - res, 4, out res);
            int stride = (ncolnrows.Width + res) * 3;
            byte[] byOut = new byte[stride * ncolnrows.Height];

            Int32 ind = 0;
            for (int i = 0; i < ncolnrows.Height; i++)
            {
                ind += res;
                for (int j = 0; j < ncolnrows.Width; j++)
                {
                    byte redb = red[i * ncolnrows.Width + j];
                    byte greenb = green[i * ncolnrows.Width + j];
                    byte blueb = blue[i * ncolnrows.Width + j];
                    byOut[ind] = blueb;
                    ind++;
                    byOut[ind] = greenb;
                    ind++;
                    byOut[ind] = redb;
                    ind++;
                }
            }
            GeoImageTools imgTools = new GeoImageTools();
            bmp = imgTools.ByteArrayToBitmap(byOut, ncolnrows.Width, ncolnrows.Height);
            return bmp;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;

namespace Giwer
{
    public class PointMethods
    {
        /* this class contains the following methods: 
           *********************************************************   
             *   invert color
             *   grayscale conversion
             *   create RGB
             *   get Min Max intensity
             *   histogram equalization
             *   compute histogram
             *   thresholding
             *   simple vectorizing
             *   combine two images (add or substract)
             *   compute image average and/or scatter
             *   get one band from the given bitmap to a byte array
             *   create grayscal bitmap from one band: createGrayscaleImagefromOneBand

           ***********************************************************/

        // color inversion of a byte array
        public byte[] InvertColor(byte[] byIn)
        {
            byte[] byOut = new byte[byIn.Length];
            for (Int32 i = 0; i < byIn.Length; i++)
            {
                byOut[i] = (byte)(255 - byIn[i]);
            }
            return byOut;
        }

        // convert image to grayscale from byte arrays of the R,G,B bands
        public byte[] GrayscaleConversion(byte[] byInR, byte[] byInG, byte[] byInB)
        {
            byte[] byGray = new byte[byInR.Length];
            for (Int32 i=0; i<byGray.Length; i++)
            {
                byGray[i] = Convert.ToByte((byInB[i] + byInG[i] + byInR[i]) / 3F);
            }
            return byGray;
        }

        // create RGB image from red, green, blue byte arrays
        public Bitmap createRGB(byte[] byInR, byte[] byInG, byte[] byInB, int width, int height)
        {
            Bitmap bmpOut = new Bitmap(width, height);

            return bmpOut;
        }

        // get min max values from a byte array
        public string getMinMax(byte[] byIn)
        {
            string MinMax="";
            int min = 255;
            int max = 0;
            for (Int32 i=0; i<byIn.Length; i++)
            {
                if (byIn[i] < min) { min = byIn[i]; }
                if (byIn[i] > max) { max = byIn[i]; }
            }
            return MinMax = min + "," + max;
        }


        //histogram equalization
        byte[] HistogramEqualization(byte[] currentBand, int min, int max)
        {
            byte[] byteOut = new byte[currentBand.Length];
            int diff = max - min;
            for (Int32 i = 0; i < currentBand.Length; i++)
            {
                float intensity = 255F * (currentBand[i] - min) / diff;
                byteOut[i] = (byte)intensity;
            }
            return byteOut;
        }


        //compute histogram normed [0,1] interval
        public float[] computeHistogram(byte[] byIn)
        {
            float[] histo = new float[256];
            for (int k = 0; k < histo.Length; k++) { histo[k] = 0; }
            for (int i = 0; i < byIn.Length; i++)
            {
                histo[byIn[i]] += 1;
            }
            float histomax = histo.Max();
            float histomin = histo.Min();
            for (int j = 0; j < histo.Length; j++)
            {
                histo[j] = (histo[j] - histomin) / (histomax - histomin);
            }
            return histo;
        }


        // thresholding
        public byte[] thresholding(byte[] byIn, string eps)
        {
            byte[] byOut = new byte[byIn.Length];
            for (Int32 i = 0; i < byIn.Length; i++)
            {
                if (byIn[i] < Convert.ToInt16(eps)) { byOut[i] = 0; }
                else { byOut[i] = 255; }                
            }
            return byOut;
        }

        // simple vectorizing
        public byte[] vectorize(byte[] byIn, string param)
        {
            byte[] byOut=new byte[byIn.Length];
            for (Int32 i = 0; i < byIn.Length; i++)
            {
                if (byIn[i] == 0) { byOut[i] = 0; }
                else { byOut[i] = 255; }
            }
            return byOut;
        }

        // combine two inmages: + or -
        public byte[] combineTwoImages(byte[] b1, byte[] b2, string action)
        {
            byte[] byOut = new byte[b1.Length];
            if (action == "+")
            {
                for (Int32 i = 0; i < b1.Length; i++)
                {
                    int sum = (b1[i] / 2) + (b2[i] / 2);
                    byOut[i] = (byte)sum;
                }
            }

            if (action == "-")
            {
                for (Int32 i = 0; i < b1.Length; i++)
                {
                    int sum = Convert.ToByte(Math.Abs((b1[i] * 2) - (b2[i] * 2))/2F);
                    byOut[i] = (byte)sum;
                }
            }
            return byOut;
        }

        // compute image average and/or scatter
        public string computeImageAverageAndScatter(byte[] byIn, string param)
        {
            string result = "";
            double average = 0D;
            double scatter=0D;
            if (param=="A")
            {
                result = Convert.ToString(average, CultureInfo.InvariantCulture);
            }
            if (param=="S")
            {
                result = Convert.ToString(scatter, CultureInfo.InvariantCulture);
            }
            if (param=="A,S")
            {
                result = Convert.ToString(average, CultureInfo.InvariantCulture) + "," + Convert.ToString(scatter, CultureInfo.InvariantCulture);
            }
            return result;
        }



        // get one band from the given bitmap to a byte array
        public byte[] getOneBandtoByteArray(Bitmap img, int band)
        {
            imageByteArray imba = new imageByteArray(img);
            byte[] byIn = imba.BitmapToByteArray(img);

            int res = (img.Width) % 4;
            Int32 stride = imba.Stride; 
            Int32 length = (Int32)(stride * img.Height );
            byte[] byOut = new byte[length];
            Int32 ind = 0;
            Int32 indOut = 0;
            for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    ind = i * stride + j * imba.BytesPerPixel;
                    int col = byIn[ind + 2 - band];
                    byOut[indOut] = (byte)col;
                    indOut += 1;
                }

            }
            return byOut;
        }

        //create grayscal bitmap from one band
        public Bitmap createGrayscaleImagefromOneBand(byte[] byIn, int imgWidth, int imgHeight, int Stride, int BytesPerPixel)
        {
            Bitmap bmp = new Bitmap(imgWidth, imgHeight, PixelFormat.Format24bppRgb);
            byte[] byOut = new byte[Stride * imgHeight];
            Int32 ind = 0;
            for (int i = 0; i < imgHeight; i++)
            {
                for (int j = 0; j < imgWidth; j++)
                {
                    byte b = byIn[i * imgWidth + j];
                    ind = i * Stride + j * BytesPerPixel;
                    for (int k = 0; k < 3; k++)
                    {
                        byOut[ind] = b;
                        ind++;
                    }
                }
            }
            imageByteArray imba = new imageByteArray();
            bmp = imba.ByteArrayToBitmap(byOut, imgWidth, imgHeight);
            return bmp;
        }

        // Convert of the image content from a given band into a bitmap
        public Bitmap convertOneBandBytestoBitmap(byte[] byIn, Int32 _ncols, Int32 _nrows)  //this routine converts values of one band, which stored in a byte array (ByIn). It comes from getOneBandBytes (whichBand) routine.
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

        //convert byte array to bitmap
        public Bitmap ByteArrayToBitmap(byte[] byteIn, Int32 imwidth, Int32 imheight)
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

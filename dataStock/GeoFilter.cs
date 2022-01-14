using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Giwer.dataStock
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class UserAttr : System.Attribute
    {
        public string Name { get; private set; }
        public UserAttr(string name)
        { Name = name; }
    }

    public class Filter
    {
        //public class UserAttr : System.Attribute
        //{
        //    public string Name { get; private set; }
        //    public UserAttr(string name) { Name = name; }
        //}
        /* This class (Filter) contains the following methods:
         * median filter 3 bands
         * median filter One band
         * red band: get red band
         * green band: get green band
         * blue band: get blue band
         * laplace filter 3Bands
         * laplace filter OneBand
         * convolution
         * compute high pass kernel 
         * compute low pass Gauss kernel
         * compute low pass Box kernel
         * compute low pass kernel
         * compute box filter's kernel
         * compute NDVI
         * 
         */



        //Median for filter3Bands
        public byte[] MedianFilter3Bands(byte[] byIn, int Width, int Height, int Stride, int BytesPerPixel, byte KernelSize) // nincs meghívva sehol
        {
            byte[] byOut = new byte[byIn.Length];
            byte[] kernel1 = new byte[KernelSize * KernelSize];
            byte[] kernel2 = new byte[KernelSize * KernelSize];
            byte[] kernel3 = new byte[KernelSize * KernelSize];
            int ks = KernelSize / 2;

            for (int row = ks; row < Height - ks; row++)
            {
                for (int col = ks; col < Width - ks; col++)
                {
                    Int32 index = row * Stride + col * BytesPerPixel;
                    int k = 0;
                    for (int irow = 0; irow <= ks; irow++)
                    {
                        for (int icol = 0; icol <= ks; icol++)
                        {
                            Int32 curindex = (row + irow - 1) * Stride + (col + icol - 1) * BytesPerPixel;
                            kernel1[k] = byIn[curindex];
                            kernel2[k] = byIn[curindex + 1];
                            kernel3[k] = byIn[curindex + 2];//Red
                            k += 1;
                        }
                    }
                    Array.Sort(kernel1);
                    Array.Sort(kernel2);
                    Array.Sort(kernel3);
                    byOut[index] = kernel1[ks + 1];
                    byOut[index + 1] = kernel2[ks + 1];
                    byOut[index + 2] = kernel3[ks + 1];
                }
            }
            return byOut;
        }

        [UserAttr("u")]
        public byte[] MedianFilterOneBand(byte[] byIn, int kSize, int imgWidth, int imgHeight)  //median filter for one band
        {
            int KernelSize = kSize;
            byte[] byOut = new byte[byIn.Length];
            byte[] kernel1 = new byte[KernelSize * KernelSize];
            int ks = KernelSize / 2;

            for (int row = ks; row < imgHeight - ks; row++)
            {
                for (int col = ks; col < imgWidth - ks; col++)
                {
                    Int32 index = row * imgWidth + col;
                    int k = 0;
                    for (int irow = 0; irow <= ks; irow++)
                    {
                        for (int icol = 0; icol <= ks; icol++)
                        {
                            Int32 curindex = (row + irow - 1) * imgWidth + (col + icol - 1);
                            kernel1[k] = byIn[curindex];
                            k += 1;
                        }
                    }
                    Array.Sort(kernel1);
                    byOut[index] = kernel1[ks + 1];
                }
            }
            return byOut;
        }

        [UserAttr("u")]
        public byte[] OneDimensionalMedian(byte[] byIn, int kSize)
        {
            byte[] byOut = new byte[byIn.Length];
            byte[] kernel1 = new byte[kSize];
            int ks = kSize / 2;

            for (int i = ks; i < byIn.Length - ks; i++)
            {
                for (int j = 0; j < kSize; j++)
                {
                    kernel1[j] = byIn[i - ks + j];
                }
                Array.Sort(kernel1);
                byOut[i] = kernel1[ks + 1];
            }
            return byOut;
        }


        //Laplace filter for 3 bands
        public byte[] Laplace3Bands(byte[] byIn, int Width, int Height, int Stride, int BytesPerPixel)
        {
            Int16[] kernel = { 0, 1, 0, 1, -4, 1, 0, 1, 0 };    //int kLength = 3;

            byte[] byOut = new byte[byIn.Length];

            for (int row = 2; row < Height - 1; row++)
            {
                for (int col = 2; col < Width - 1; col++)
                {
                    Int32 ind = row * Stride + col * BytesPerPixel;
                    Int32 Rsum = 0;
                    Int32 Gsum = 0;
                    Int32 Bsum = 0;

                    for (int irow = 0; irow < 3; irow++)
                    {
                        for (int icol = 0; icol < 3; icol++)
                        {
                            Int32 curindex = (row + irow - 1) * Stride + (col + icol - 1) * BytesPerPixel;
                            Bsum = Bsum + byIn[curindex] * kernel[irow + icol];
                            Gsum = Gsum + byIn[curindex + 1] * kernel[irow + icol];
                            Rsum = Rsum + byIn[curindex + 2] * kernel[irow + icol];
                        }
                    }
                    byOut[ind + 2] = (byte)Rsum;
                    byOut[ind + 1] = (byte)Gsum;
                    byOut[ind] = (byte)Bsum;
                }
            }
            return byOut;
        }

        [UserAttr("u")]
        public byte[] LaplaceOneBand(byte[] byIn, int imgWidth, int imgHeight) // Laplace filter for one band
        {
            //weak kernel kernel = { 0, 1, 0, 1, -4, 1, 0, 1, 0 };
            byte[] byOut = new byte[byIn.Length];
            for (int row = 1; row < imgHeight - 1; row++)
            {
                for (int col = 1; col < imgWidth - 1; col++)
                {
                    Int32 ind2 = (row - 1) * imgWidth + col;
                    Int32 ind4 = row * imgWidth + col - 1;
                    Int32 ind5 = row * imgWidth + col;
                    Int32 ind6 = (row) * imgWidth + col + 1;
                    Int32 ind8 = (row + 1) * imgWidth + col;
                    int c2 = byIn[ind2];
                    int c4 = byIn[ind4];
                    int c5 = 4 * (byIn[ind5]);
                    int c6 = byIn[ind6];
                    int c8 = byIn[ind8];
                    byOut[ind5] = (byte)((c2 + c4 - c5 + c6 + c8) / 9);
                }
            }
            return byOut;
        }



        //public byte[] LaplaceOneBand(byte[] byIn, int imgWidth, int imgHeight)
        //{
        //    Int16[] kernel = { 0, 1, 0, 1, -4, 1, 0, 1, 0 };
        //    //int kLength = 3;

        //    byte[] byOut = new byte[byIn.Length];

        //    for (int row = 2; row < imgHeight - 1; row++)
        //    {
        //        for (int col = 2; col < imgWidth - 1; col++)
        //        {
        //            Int32 ind = row * imgWidth + col;
        //            Int32 ksum = 0;

        //            for (int irow = 0; irow < 3; irow++)
        //            {
        //                for (int icol = 0; icol < 3; icol++)
        //                {
        //                    Int32 curindex = (row + irow - 1) * imgWidth + (col + icol - 1);
        //                    ksum = ksum + byIn[curindex] * kernel[irow + icol];
        //                }
        //            }
        //            byOut[ind] = (byte)(ksum/9);
        //        }
        //    }
        //    return byOut;
        //}


        [UserAttr("u")]
        public byte[] Thresholding(byte[] byIn, int imgWidth, int imgHeight, int thres)
        {
            byte[] byOut = new byte[byIn.Length];
            for (Int32 i = 0; i < byIn.Length; i++)
            {
                if (byIn[i] < thres) { byOut[i] = 0; } else { byOut[i] = 255; }
            }
            return byOut;
        }

        [UserAttr("u")]
        public byte[] vectorize(byte[] byIn, int Width, int Height)
        {
            byte[] byOut = new byte[byIn.Length];
            for (int i = 0; i < Height - 1; i++)
            {
                for (int j = 0; j < Width - 1; j++)
                {
                    Int32 ind = i * Width + j;
                    if (byIn[ind] == 0)
                    {
                        byOut[ind] = 0;
                    }
                    else
                    {
                        byOut[ind + 1] = 255;
                    }
                }
            }
            return byOut;
        }

        public byte[] OneDimensionalConvolution(byte[] arrIn, float[] kern)
        {
            byte[] arrOut = new byte[arrIn.Length];
            int kernHalf = (int)(kern.Length / 2F);
            float kernsum = kern.Sum();

            float val = 0;
            int ind = 0;
            for (int i = kernHalf; i < 256 - kernHalf; i++)
            {
                for (int k = -kernHalf; k < kernHalf; k++)
                {
                    val += arrIn[i + k] * kern[k + kernHalf];
                }
                arrOut[ind] = (byte)(int)(val / kernsum);
                ind++;
                val = 0;
            }
            return arrOut;
        }

        [UserAttr("u")]
        public byte[] ConvolSingleBand(double[,] kernel, byte[] byteIn, int Width, int Height)
        {
            byte[] byteOut = new byte[byteIn.Length];
            int kernelLength = (int)Math.Sqrt(kernel.Length);
            int kernelHalf = (int)(kernelLength / 2F);
            for (int row = kernelHalf; row < Height - kernelHalf; row++)
            {
                for (int col = kernelHalf; col < Width - kernelHalf; col++)
                {
                    Int32 index = row * Width + col;
                    double Bsum = 0;
                    byteOut[index] = byteIn[index];
                    for (int irow = 0; irow < kernelLength; irow++)
                    {
                        for (int icol = 0; icol < kernelLength; icol++)
                        {
                            Int32 curindex = (row + irow - kernelHalf) * Width + (col + icol - kernelHalf);
                            Bsum = Bsum + byteIn[curindex] * kernel[irow, icol];
                        }
                    }
                    byteOut[index] = (byte)Bsum;
                }
            }
            return byteOut;
        }

        //convolution
        public byte[] Convol3bands(double[,] kernel, byte[] byteIn, int Width, int Height, int Stride, int BytesPerPixel)
        {
            byte[] byteOut = new byte[byteIn.Length];
            int kernelLength = (int)Math.Sqrt(kernel.Length);
            int kernelHalf = (int)(kernelLength / 2F);
            for (int row = kernelHalf; row < Height - kernelHalf; row++)
            {
                for (int col = kernelHalf; col < Width - kernelHalf; col++)
                {
                    Int32 index = row * Stride + col * BytesPerPixel;
                    double Rsum = 0;
                    double Gsum = 0;
                    double Bsum = 0;

                    for (int irow = 0; irow < kernelLength; irow++)
                    {
                        for (int icol = 0; icol < kernelLength; icol++)
                        {
                            Int32 curindex = (row + irow - kernelHalf) * Stride + (col + icol - kernelHalf) * BytesPerPixel;
                            Bsum = Bsum + byteIn[curindex] * kernel[irow, icol];
                            Gsum = Gsum + byteIn[curindex + 1] * kernel[irow, icol];
                            Rsum = Rsum + byteIn[curindex + 2] * kernel[irow, icol];
                        }
                    }
                    if (Rsum < 0) { Rsum = 0; }
                    if (Rsum > 255) { Rsum = 255; }
                    if (Gsum < 0) { Gsum = 0; }
                    if (Gsum > 255) { Gsum = 255; }
                    if (Bsum < 0) { Bsum = 0; }
                    if (Bsum > 255) { Bsum = 255; }
                    byteOut[index + 2] = (byte)Rsum;
                    byteOut[index + 1] = (byte)Gsum;
                    byteOut[index] = (byte)Bsum;
                }
            }
            return byteOut;
        }

        [UserAttr("u")]
        //kernels
        public double[,] highPassKernel(int Kernlength)  //még nem jó, nincs használva
        {
            int Klength = 2 * Kernlength + 1;
            double[,] kern = new double[Klength, Klength];
            double kernSum = 0;
            double kernHalf = (Klength - 1D) / 2D;
            double sigma = kernHalf / 2D;
            for (int i = 0; i < Klength; i++)
            {
                for (int j = 0; j < Klength; j++)
                {
                    double fx = i - kernHalf;
                    double fy = j - kernHalf;
                    double a = 1D / (Math.Sqrt(2D * Math.PI) * sigma * sigma);
                    double B = Math.Exp(-((fx * fx + fy * fy) / (2D * sigma * sigma)));
                    kern[i, j] = -(a * B);
                    kernSum += Math.Abs(kern[i, j]);
                }
            }
            kern[(int)kernHalf, (int)kernHalf] = 0D;
            for (int i = 0; i < Klength; i++)
            {
                for (int j = 0; j < Klength; j++)
                {
                    kern[i, j] /= kernSum;
                }
            }
            return kern;
        }

        [UserAttr("u")]
        public double[,] lowPassKernelGauss(int Kernlength)
        {
            int Klength = 2 * Kernlength + 1;
            double[,] kern = new double[Klength, Klength];
            double kernSum = 0;
            double kernHalf = (Klength - 1D) / 2D;
            double sigma = kernHalf / 2D;
            for (int i = 0; i < Klength; i++)
            {
                for (int j = 0; j < Klength; j++)
                {
                    double fx = i - kernHalf;
                    double fy = j - kernHalf;
                    double a = 1D / (Math.Sqrt(2D * Math.PI) * sigma * sigma);
                    double B = Math.Exp(-((fx * fx + fy * fy) / (2D * sigma * sigma)));
                    kern[i, j] = a * B;
                    kernSum += kern[i, j];
                }
            }
            for (int i = 0; i < Klength; i++)
            {
                for (int j = 0; j < Klength; j++)
                {
                    kern[i, j] /= kernSum;
                }
            }
            return kern;
        }

        [UserAttr("u")]
        public double[,] lowPassKernelSinc(double limitFreq)
        {
            double[,] kern;
            List<double> lstValues = new List<double>();
            double kernSum = 0;
            double eps = 1D / limitFreq;
            int i = 1;
            double val;
            double valPrev = 0;
            do
            {
                double a = Math.PI * i * eps;
                double fx = Math.Sin(Math.PI * i * eps);
                val = fx / a;
                lstValues.Add(val);
                if (Math.Abs(val - valPrev) < 0.01) { break; }
                valPrev = val;
                i += 1;
            } while (true);

            int klength = 2 * i + 1;
            kern = new double[klength, klength];
            int half = klength / 2;
            for (int j = 0; j < i; j++)
            {
                kern[j, half] = lstValues[i - j - 1];
                kern[j + i + 1, half] = lstValues[j];
                kernSum += 2 * kern[j, half];
            }
            kern[i, half] = 1D;
            kernSum += 1;

            for (int k = 0; k < klength; k++)
            {
                for (int j = 0; j < klength; j++)
                {
                    kern[k, j] /= kernSum;
                }
            }
            return kern;
        }

        public double[,] lowPassKernelBox(int Klength)
        {
            double[,] box = new double[Klength, Klength];
            double kernsum = Klength * Klength;
            for (int i = 0; i < Klength; i++)
            {
                for (int j = 0; j < Klength; j++)
                {
                    box[i, j] = 1F / kernsum;
                }
            }
            return box;
        }

        //resampling
        public Bitmap resampling(int rate, Bitmap bmpIn)
        {
            double[,] kernel = lowPassKernelGauss(2 * rate - 1);
            int newWidth = (int)(bmpIn.Width / rate);
            int newHeight = (int)(bmpIn.Height / rate);
            int length = 2 * rate - 1;
            Bitmap bmpOut = new Bitmap(newWidth, newHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            for (int i = 0; i < newHeight - 1; i++)
            {
                for (int j = 0; j < newWidth - 1; j++)
                {
                    Single avgColorR = 0;
                    Single avgColorG = 0;
                    Single avgColorB = 0;

                    for (int k = 0; k < length; k++)
                    {
                        Color c = bmpIn.GetPixel(j * rate + k, i * rate + k);
                        avgColorR += c.R;
                        avgColorG += c.G;
                        avgColorB += c.B;
                    }
                    avgColorR /= length;
                    avgColorG /= length;
                    avgColorB /= length;
                    bmpOut.SetPixel(j, i, Color.FromArgb((int)avgColorR, (int)avgColorG, (int)avgColorB));
                }
            }
            return bmpOut;
        }

        [UserAttr("u")]
        public byte[] Sobel(byte[] byIn, Int32 imWidth, Int32 imHeight)
        {
            // Sobel filter's kernel G_x = {1,0,-1,  2,0,-2,  1,0,-1}    G_y = {1,2,1,  0,0,0,  -1,-2,-1},    G = SQRT (G_x ^2 + G_y ^2)
            int[,] g_x = new int[,] { { 1, 0, -1 }, { 2, 0, -2 }, { 1, 0, -1 } };
            int[,] g_y = new int[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };
            byte[] byOut = new byte[byIn.Length];

            for (Int32 row = 1; row < imHeight - 1; row++)
            {
                for (Int32 col = 1; col < imWidth - 1; col++)
                {
                    int sumx = 0;
                    int sumy = 0;
                    Int32 ind = row * imWidth + col;
                    for (int irow = 0; irow < 3; irow++)
                    {
                        for (int icol = 0; icol < 3; icol++)
                        {
                            Int32 curindex = (row + irow - 1) * imWidth + (col + icol - 1);
                            sumx = sumx + byIn[curindex] * g_x[irow, icol];
                            sumy = sumy + byIn[curindex] * g_y[irow, icol];
                        }
                    }
                    int Gx = sumx;
                    int Gy = sumy;
                    byOut[ind] = (byte)Math.Sqrt(Gx * Gx + Gy * Gy);
                }
            }
            return byOut;
        }

        [UserAttr("u")]
        public byte[] Prewitt(byte[] byIn, Int32 imWidth, Int32 imHeight)
        {
            // Prewitt filter's kernel:  G_x = {1,0,-1,  1,0,-1,  1,0,-1}    G_y = {1,1,1,  0,0,0,  -1,-1,-1},    G = SQRT (G_x ^2 + G_y ^2)
            int[,] g_x = new int[,] { { 1, 0, -1 }, { 1, 0, -1 }, { 1, 0, -1 } };
            int[,] g_y = new int[,] { { 1, 1, 1 }, { 0, 0, 0 }, { -1, -1, -1 } };
            byte[] byOut = new byte[byIn.Length];

            for (Int32 row = 1; row < imHeight - 1; row++)
            {
                for (Int32 col = 1; col < imWidth - 1; col++)
                {
                    int sumx = 0;
                    int sumy = 0;
                    Int32 ind = row * imWidth + col;
                    for (int irow = 0; irow < 3; irow++)
                    {
                        for (int icol = 0; icol < 3; icol++)
                        {
                            Int32 curindex = (row + irow - 1) * imWidth + (col + icol - 1);
                            sumx = sumx + byIn[curindex] * g_x[irow, icol];
                            sumy = sumy + byIn[curindex] * g_y[irow, icol];
                        }
                    }
                    int Gx = sumx;
                    int Gy = sumy;
                    byOut[ind] = (byte)Math.Sqrt(Gx * Gx + Gy * Gy);
                }
            }
            return byOut;
        }


    }
}

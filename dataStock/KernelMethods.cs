using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dataStock
{
    class KernelMethods
    {
        /* This class contains the following filter methods
             * median filter
             * laplace filter
             * convolution
             * compute high pass kernel 
             * compute low pass kernel
             * compute box filter's kernel
             * compute NDVI
             * 
         */

        // median filter
        public byte[] MedianFilter(byte[] byIn, string kSize, int imgHeight, int imgWidth)
        {
            int KernelSize = Convert.ToInt16(kSize);
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

        // laplace filter
        public byte[] Laplace(byte[] byIn, int imgWidth, int imgHeight)
        {
            Int16[] kernel = { 0, 1, 0, 1, -4, 1, 0, 1, 0 };
            //int kLength = 3;

            byte[] byOut = new byte[byIn.Length];

            for (int row = 2; row < imgHeight - 1; row++)
            {
                for (int col = 2; col < imgWidth - 1; col++)
                {
                    Int32 ind = row * imgWidth + col;
                    Int32 ksum = 0;

                    for (int irow = 0; irow < 3; irow++)
                    {
                        for (int icol = 0; icol < 3; icol++)
                        {
                            Int32 curindex = (row + irow - 1) * imgWidth + (col + icol - 1);
                            ksum = ksum + byIn[curindex] * kernel[irow + icol];

                        }
                    }
                    byOut[ind] = (byte)ksum;
                }
            }
            return byOut;
        }

        // convolution
        public byte[] Convolution(double[,] kernel, byte[] byIn, int imgWidth, int imgHeight, string mode)
        {
            byte[] byteOut = new byte[byIn.Length];
            double kernelSum = 0;
            int kernelLength = (int)Math.Sqrt(kernel.Length);

            for (int i = 0; i < kernelLength; i++)
            {
                for (int j = 0; j < kernelLength; j++)
                {
                    kernelSum += kernel[i, j];
                }
            }
            int kernelHalf = (int)(kernelLength / 2F);
            for (int row = kernelHalf; row < imgHeight - kernelHalf; row++)
            {
                for (int col = kernelHalf; col < imgWidth - kernelHalf; col++)
                {
                    Int32 index = row * imgWidth + col;
                    double Rsum = 0;

                    for (int irow = 0; irow < kernelLength; irow++)
                    {
                        for (int icol = 0; icol < kernelLength; icol++)
                        {
                            Int32 curindex = (row + irow - kernelHalf) * imgWidth + (col + icol - kernelHalf);
                            Rsum = Rsum + byIn[curindex] * kernel[irow, icol];
                        }
                    }

                    Rsum = Rsum / kernelSum;
                    if (Rsum < 0) { Rsum = 0; }
                    if (mode == "lowpass")
                    {
                        byteOut[index] = (byte)Rsum;
                    }
                    else
                    {
                        byteOut[index] = (byte)(byIn[index] - (byte)Rsum);
                    }
                }
            }
            return byteOut;
        }

        // compute high pass kernel
        public double[,] highPassKernel(int Klength)  //még nem jó, nincs használva
        {
            Single sigma = Klength / 2F;
            double[,] kern = new double[Klength, Klength];
            double kernSum = 0;
            int kernHalf = (Klength - 1) / 2;
            for (int i = 0; i < Klength; i++)
            {
                for (int j = 0; j < Klength; j++)
                {
                    int fx = i - kernHalf;
                    int fy = j - kernHalf;
                    kern[i, j] = 1 - (1F / (2 * Math.PI * sigma * sigma)) * Math.Exp(-((fx * fx + fy * fy) / (2 * sigma * sigma)));
                    kernSum += kern[i, j];
                }
            }
            return kern;
        }

        //compute low pass kernel
        public double[,] lowPassKernel(int Klength)
        {
            double[,] kern = new double[Klength, Klength];
            double kernSum = 0;
            int kernHalf = (Klength - 1) / 2;
            int sigma = Klength;
            for (int i = 0; i < Klength; i++)
            {
                for (int j = 0; j < Klength; j++)
                {
                    int fx = i - kernHalf;
                    int fy = j - kernHalf;
                    kern[i, j] = (1F / (2 * Math.PI * sigma * sigma)) * Math.Exp(-((fx * fx + fy * fy) / (2 * sigma * sigma)));
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

        // compute box filter's kernel
        public double[,] boxKernel(int Klength)
        {
            double[,] box = new double[Klength, Klength];
            for (int i = 0; i < Klength; i++)
            {
                for (int j = 0; j < Klength; j++)
                {
                    box[i, j] = 1;
                }
            }
            return box;
        }

        // compute NDVI
        public byte[] computeNDVI(byte[] b1, byte[] b2)
        {
            byte[] byOutNDVI = new byte[b1.Length];
            for (Int32 i=0; i< b1.Length;i++)
            {
                if (b1[i] - b2[i] < 0) { byOutNDVI[i] =0; }
                else { byOutNDVI[i] = (byte)(b1[i] - b2[i]);}              
            }
            PointMethods minMax = new PointMethods();
            string mm = minMax.getMinMax(byOutNDVI);
            int min = Convert.ToInt16(mm.Split(',')[0]);
            int max = Convert.ToInt16(mm.Split(',')[1]);
            int diff = max - min;
            for (Int32 i=0; i<byOutNDVI.Length; i++)
            {
                byOutNDVI[i] =(byte)(((int)(byOutNDVI[i] - min) / diff)*255);
            }
            return byOutNDVI;
        }


    }
}

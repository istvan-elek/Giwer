using System;
using System.Collections.Generic;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Factorization;

namespace Giwer.dataStock
{
    public class StatMath
    {
        GeoImageData gida;
        GeoImageTools gito;
        string GiwerDataFolder;


        public StatMath(GeoImageData gid,GeoImageTools git, string gwrDatDir)
        {
            gida = gid;
            gito = git;
            GiwerDataFolder = gwrDatDir;
        }

        public StatMath(GeoImageData gid)
        {
            gida = gid;
        }

        //compute derivatives of an image: f'(x,y) = {[f(x+Dx,y+Dy)-f(x+Dx,y-Dy)]-[f(x-Dx,y+Dy)-f(x-Dx,y-Dy)]}/(4*Dx*Dy)
       public byte[] derivatives(byte[] byIn)
        {
            byte[] byDerivative = new byte[byIn.Length];
            for (Int32 row = 1; row < gida.Nrows-1; row++)
            {
                for (Int32 col = 1; col < gida.Ncols-1; col++)
                {
                    Int32 ind = row * gida.Ncols + col;
                    Int32 idpx = ind + 1;
                    Int32 idpy = ind + gida.Ncols;
                    Int32 idmx = ind - 1;
                    Int32 idmy = ind - gida.Ncols;
                    byte f1 = byIn[idpx];
                    byte f2 = byIn[idmx];
                    byte f3 = byIn[idpy];
                    byte f4 = byIn[idmy];
                    byDerivative[ind] = (byte)(Math.Abs(((f1 - f2) - (f3 - f4)) / 4F));
                }
            }
            return byDerivative;
        }

        public byte[,] convertbyte1Dtobyte2D(byte[] byIn)
        {
            byte[,] byOut = new byte[gida.Ncols, gida.Nrows];
            for (int row = 0; row < gida.Nrows; row++)
            {
                for (int col = 0; col < gida.Ncols; col++)
                {
                    Int32 ind = row * gida.Ncols + col;
                    byOut[col, row] = byIn[ind];
                }
            }
            return byOut;
        }


        //computes image average
        [UserAttr("u")]
        public double imageAverage(byte[] byIn)
        {
            double average = 0F;
            foreach (byte item in byIn)
            {
                average += item;
            }
            return average / byIn.Length;
        }

        [UserAttr("u")]
        //computes image scatter
        public double imageScatter(byte[] imIn, double avrg)
        {
            double s = 0D;
            double N = imIn.Length;
            double onePerN = 1D / (N - 1);
            for (Int32 i = 0; i < N; i++)
            {
                s += (imIn[i] - avrg) * (imIn[i] - avrg);
            }
            return Math.Sqrt(s / N);
        }

        public string getMinMax(double[] ArrIn)
        {
            string MinMax = "";
            double min = 1000000000;
            double max = -1000000000;
            for (Int32 i = 0; i < ArrIn.Length; i++)
            {
                if (ArrIn[i]< min) { min = ArrIn[i]; }
                if (ArrIn[i]>max) { max = ArrIn[i]; }
            }
            MinMax = min + ";" + max;
            return MinMax;
        }

        [UserAttr("u")]
        public string getMinMax(int[] ArrIn)
        {
            string MinMax = "";
            Int32 min = 1000000000;
            Int32 max = -1000000000;
            for (Int32 i = 0; i < ArrIn.Length; i++)
            {
                if (ArrIn[i] < min) { min = ArrIn[i]; }
                if (ArrIn[i] > max) { max = ArrIn[i]; }
            }
            MinMax = min + ";" + max;
            return MinMax;
        }
        
        [UserAttr("u")]
        // standardize image
        public double[] imageStandardization(byte[] imIn, double aver, double scat)
        {
            double[] imOut = new double[imIn.Length];
            for (Int32 i = 0; i < imIn.Length; i++)
            {
                imOut[i] = (imIn[i] - aver) / scat;
            }
            return imOut;
        }

        [UserAttr("u")]
        //compute correlation between 2 bands
        public double computeCorrelation(double[] A, double[] B)
        {
            double ro = 0;
            Int32 leng = A.Length;
            for (Int32 i = 0; i < leng; i++)
            {
                ro += (A[i] * B[i]);
            }
            return ro / leng;
        }

        [UserAttr("u")]
        //compute correlation matrix for the given bands (lst4PCA contains bands' name)
        public double[,] computeCorrelationMatrix(List<int> lst4PCA)
        {
            double[,] corr = new double[lst4PCA.Count, lst4PCA.Count];
            for (int k = 0; k < lst4PCA.Count; k++) { corr[k, k] = 1; }
            for (int j = 0; j < lst4PCA.Count; j++)
            {
                string fnA = GiwerDataFolder + @"\" + System.IO.Path.GetFileNameWithoutExtension(gida.FileName) + @"\" + lst4PCA[j] + ".gwr";
                byte[] curBandA = gito.readGwrFile(fnA);
                double averageA = imageAverage(curBandA);
                double scatterA = imageScatter(curBandA, averageA);
                double[] standA = imageStandardization(curBandA, averageA, scatterA);
                double[] standB = new double[standA.Length];
                for (int i = j + 1; i < lst4PCA.Count; i++)
                {
                    string fnB = GiwerDataFolder + @"\" + System.IO.Path.GetFileNameWithoutExtension(gida.FileName) + @"\" + lst4PCA[i] + ".gwr";
                    byte[] curBandB = gito.readGwrFile(fnB);
                    double averageB = imageAverage(curBandB);
                    double scatterB = imageScatter(curBandB, averageB);
                    standB = imageStandardization(curBandB, averageB, scatterB);
                    corr[j, i] = computeCorrelation(standA, standB);
                    corr[i, j] = corr[j, i];
                    //corr[i, lst4PCA.Count - j-1] = corr[i, j];
                }
            }
            return corr;
        }

        [UserAttr("u")]
        //computes eigenvectors and eigenvalues of the given correlation matrix
        public double[,] EigenVectors(double[,] corrMatrix)
        {
            int length = (int)Math.Sqrt(corrMatrix.Length);
            double[,] eigenVectors = new double[length, length];
            Matrix<double> A = DenseMatrix.OfArray(corrMatrix); 
            Evd<double> eigen = A.Evd();
            Matrix<double> eigenvectors = eigen.EigenVectors;
            Vector<Complex> eigenvalues = eigen.EigenValues;
            for (int i=0; i< length; i++)
            {
                for (int j=0; j < length; j++)
                {
                    eigenVectors[i, j] = eigenvectors[i, j];
                }
            }
            return eigenVectors;
        }

        [UserAttr("u")]
        public double[] PCA(List<int> lst, double[,] eigenvec, int pcN)
        {
            double[] eigen = new double[(int)Math.Sqrt(eigenvec.Length)];
            for (int k=0; k< eigen.Length;k++)
            {
                eigen[k] = eigenvec[pcN,k];
            }
            Int32 bsize = gida.Ncols * gida.Nrows;
            byte[] curBand = new byte[bsize];
            double[] pca = new double[bsize];
            
            for (int i=0; i < lst.Count; i++)
            {
                string fileNamme = GiwerDataFolder + @"\" + System.IO.Path.GetFileNameWithoutExtension(gida.FileName) + @"\" + lst[i] + ".gwr";
                curBand = System.IO.File.ReadAllBytes(fileNamme);
                for (Int32 j=0; j< bsize; j++)
                {
                    pca[j] += curBand[j] * eigen[i];
                }
            }
            string minmax = getMinMax(pca);
            double min = Convert.ToDouble(minmax.Split(';')[0]);
            double max = Convert.ToDouble(minmax.Split(';')[1]);
            double mamimi=max - min;
            for (int i=0; i<pca.Length; i++)
            {
                pca[i] = 255 *(pca[i] - min) / (mamimi);
            }
            return pca;
        }

        //Matrix<double> A = DenseMatrix.OfArray(new double[,] { { 1.0, 2.0, 3.0 }, { 4.0, 5.0, 6.0 }, { 7.0, 8.0, 9.0 } });
        //Evd<double> eigen = A.Evd();
        //Matrix<double> eigenvectors = eigen.EigenVectors;
        //Vector<Complex> eigenvalues = eigen.EigenValues;

    }
}

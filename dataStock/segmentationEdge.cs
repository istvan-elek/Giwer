using System;
using System.Collections.Generic;

namespace Giwer.dataStock
{
    class segmentationEdge
    {
        GeoImageData gida;
        //byte[] border;
        enum direction { UP, DOWN };
        direction dir = new direction();

        public segmentationEdge(GeoImageData gimda)
        {
            gida = gimda;
        }

        public byte[] setupStepValues(byte[] bnd, byte[] byIn)
        {
            //byte[] bndX = DetectBoundaries(byIn);
            byte[] byOutSegmentsX = compMinMaxValue(bnd, byIn);
            //byte[] bndY = transpose(DetectBoundaries(transpose(byIn)));
            byte[] byOutSegmentsY = compMinMaxValue(bnd, transpose(byIn));
            return bndOR(byOutSegmentsX, byOutSegmentsY);
        }
        public byte[] computeBoundaries(byte[] byIn)
        {
            //Filter fil = new Filter();
            //byIn = fil.MedianFilterOneBand(byIn, 7, gida.Ncols, gida.Nrows);
            byte[] bndX = DetectBoundaries(byIn); //new byte[byIn.Length];  // szegmenshatárok X irányban
            byte[] bndY = transpose(DetectBoundaries(transpose(byIn)));   // szegmenshatárok Y irányban
            byte[] byOut = new byte[byIn.Length];
            for (Int32 i = 0; i < byIn.Length; i++)
            {
                byOut[i] = (byte)(Math.Sqrt(bndX[i] * bndX[i] + bndY[i] * bndY[i]));
            }

            //byte[] byOut = bndOR(bndX, bndY);
            return byOut; // byOut;
        }




        public byte[] computeStepValues(byte[] border, byte[] byIn)
        {
            byte[] byOutSegmentsX = compMinMaxValue(border, byIn);  // step value is the min or max value of the certain intervall
            byte[] byOutSegmentsY = transpose(compMinMaxValue(transpose(border), transpose(byIn)));  // step value is the min or max value of the certain intervall
            return bndOR(byOutSegmentsX, byOutSegmentsY);
            //return aver(byOutSegmentsX, byOutSegmentsY);
        }


        byte[] transpose(byte[] byIn)
        {
            byte[] transposed = new byte[byIn.Length];
            Int32 k = 0;
            for (int i = 0; i < gida.Nrows; i++)
            {
                for (int j = 0; j < gida.Ncols; j++)
                {
                    transposed[k] = byIn[j * gida.Ncols + i];
                    k++;
                }
            }
            return transposed;
        }


        byte[] bndOR(byte[] X, byte[] Y)
        {
            byte[] byOut = new byte[X.Length];
            for (int i = 0; i < X.Length; i++)
            {
                if (X[i] != 0 || Y[i] != 0) byOut[i] = 255;// (byte)(X[i] / 2 + Y[i] / 2);
            }
            return byOut;
        }

        byte[] aver(byte[] bnd, byte[] by1, byte[] by2)
        {
            //byte[] byOut = new byte[by1.Length];
            //Int32 sum = 0;
            //for (int i = 0; i < by1.Length; i++)
            //{
            //    if (bnd[i] == 0)
            //    {
            //        sum = by1[i] + by2[i];
            //    }
            //}
            return null;
        }


        void upSetup(byte[] byIn)
        {
            if (byIn[1] - byIn[0] < 0) { dir = direction.DOWN; } else { dir = direction.UP; }
        }

        byte[] DetectBoundaries(byte[] byIn)
        {
            byte[] bnd = new byte[byIn.Length];
            upSetup(byIn);
            bnd[0] = byIn[0];
            List<int> puff = new List<int>();

            for (int i = 1; i < byIn.Length; i++)
            {
                int diff = (byIn[i] - byIn[i - 1]);
                if ((dir == direction.UP && diff >= 0) || (dir == direction.DOWN && diff <= 0))  // növekvő vagy csökkenő tendencia
                {
                    puff.Add(diff);
                }
                else
                {
                    if (puff.Count > 3) // csak akkor fut ez a rész, ha azélen futó pontok száma nagyobb 2-nél
                    {
                        int ind = puff.Count / 2;
                        if (!((i - ind) < 0)) bnd[i - ind] = byIn[i - ind];
                        if (diff < 0)
                        {
                            dir = direction.DOWN;
                        }
                        else
                        {
                            dir = direction.UP;
                        }
                        puff.Clear(); // a szegmenshatár megállapítása után kitörli a puffert, de az utolsó elemet a következő pufferbe is beteszi
                        puff.Add(diff);
                    }
                    else
                    {
                        puff.Add(diff); // ide akkor lép, ha a pufferben 3-nál kevesebb elem van
                        if (diff < 0)
                        {
                            dir = direction.DOWN;
                        }
                        else
                        {
                            dir = direction.UP;
                        }
                    }
                }
            }
            bnd[bnd.Length - 1] = byIn[byIn.Length - 1];
            return bnd;
        }


        byte[] compMinMaxValue(byte[] border, byte[] byIn)
        {
            byte[] byOut = new byte[byIn.Length];
            int k = 0;
            byte max = 0;
            byte min = 255;
            for (int i = 1; i < byIn.Length; i++)
            {
                if (border[i] == 0)
                {
                    if (byIn[i] < min) min = byIn[i];
                    if (byIn[i] > max) max = byIn[i];
                    k++;
                }
                else
                {
                    k++;
                    if (max > byIn[i - k] && max > byIn[i])   //max lesz a szegmens érték
                    {
                        for (int j = 0; j <= k; j++)
                        {
                            byOut[i - j] = max;
                        }
                    }
                    if (min < byIn[i - k] && min < byIn[i]) // min lesz a szegmens érték
                    {
                        for (int j = 0; j <= k; j++)
                        {
                            byOut[i - j] = min;
                        }
                    }
                    if (!(max > byIn[i - k] && max > byIn[i]) && !(min < byIn[i - k] && min < byIn[i]))     // ha min és max is a szélen van
                    {
                        for (int j = 0; j <= k; j++)
                        {
                            byOut[i - j] = (byte)((max + min) / 2);
                        }
                    }

                    if ((max > byIn[i - k] && max > byIn[i]) && (min < byIn[i - k] && min < byIn[i]))   //ha sem min sem max nincs a szélen
                    {
                        for (int j = 0; j <= k; j++)
                        {
                            byOut[i - j] = (byte)((max + min) / 2);
                        }
                    }
                    k = 0;
                    max = 0;
                    min = 255;
                }
            }
            return byOut;
        }
    }
}

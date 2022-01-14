using System;
using System.Collections.Generic;
using System.Linq;

namespace Giwer.dataStock
{
    public class Segmentation
    {
        byte[] curBand;
        List<byte> segmentBoundaries = new List<byte>();
        List<byte> segmentValues = new List<byte>();
        public byte[] segValues;
        public byte[] segBoundaries;
        public byte[] histo;
        public byte[] segmentedImage;
        string[] pointsHisto = new string[256];
        int eps;

        public Segmentation(byte[] currentBand, int epsilon)
        {
            eps = epsilon;
            curBand = currentBand;
            histo = computeHistogram(curBand);
            int mlength = eps;
            Filter fi = new Filter();
            histo = fi.OneDimensionalMedian(histo, mlength);

            segmentBoundaries = DiffOneDimension(histo, eps);
            segBoundaries = segmentBoundaries.ToArray();
            segmentValues = computeSegmentValues(histo);
            segValues = segmentValues.ToArray();
        }


        List<byte> computeSegmentValues(byte[] hist)
        {
            List<byte> sValues = new List<byte>();
            int indStart = 0;
            int indEnd = segBoundaries[0];
            for (int i = 0; i < segBoundaries.Length; i++)
            {
                indEnd = segBoundaries[i];
                Int32 sum = 0;
                for (int j = indStart; j < indEnd; j++)
                {
                    sum += histo[j];  //összegzés a segmensen belül
                }
                sum /= (indEnd - indStart + 1);
                sValues.Add((byte)sum);
                indStart = indEnd + 1;
            }
            return sValues;
        }



        public byte[] computeSegmentedImage()
        {
            segmentedImage = segmentingImage(curBand, segBoundaries, eps);
            return segmentedImage;
        }


        byte[] segmentingImage(byte[] byIn, byte[] segBounds, int eps)
        {
            byte[] byOut = new byte[byIn.Length];
            byte[] h = new byte[256];

            int indStart = 0;
            int indEnd = segBoundaries[0];
            for (int i = 0; i < segBoundaries.Length; i++)
            {
                indEnd = segBoundaries[i];
                for (int j = indStart; j < indEnd; j++)
                {
                    h[j] = segValues[i];
                }

                indStart = indEnd + 1;
            }

            for (Int32 i = 0; i < byIn.Length; i++)
            {
                byOut[i] = h[byIn[i]];
            }

            return byOut;
        }

        byte[] computeHistogram(byte[] byIn)
        {
            float[] Fhisto = new float[256];
            byte[] histo = new byte[256];
            for (int k = 0; k < histo.Length; k++) { Fhisto[k] = 0; }  // histogram init

            for (int i = 0; i < byIn.Length; i++)
            {
                Fhisto[byIn[i]] += 1;
            }
            Fhisto[0] = 0; Fhisto[255] = 0;
            float histomax = Fhisto.Max();
            float histomin = Fhisto.Min();
            float d = histomax - histomin;
            for (int j = 0; j < histo.Length; j++)
            {
                Fhisto[j] = 255 * (Fhisto[j] - histomin) / (d);
                histo[j] = (byte)(int)Fhisto[j];
            }
            return histo;
        }


        List<byte> DiffOneDimension(byte[] byIn, int eps)
        {
            List<byte> sBounds = new List<byte>();
            for (byte i = 0; i < byIn.Length - 1; i++)
            {
                int diff = Math.Abs(byIn[i] - byIn[i + 1]);
                if (diff > eps)
                {
                    sBounds.Add(i);
                }
            }
            sBounds.Add(255);
            return sBounds;
        }

    }
}

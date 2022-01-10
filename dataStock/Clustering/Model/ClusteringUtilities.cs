using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Giwer.dataStock.Clustering.Model
{
    class ClusteringUtilities
    {
        public static T[] PickRandom<T>(Random _random, T[] points, int numberOfPicks) // based on Richard Durstenfeld's Fisher-Yates shuffle 
        {
            T[] selected = new T[numberOfPicks];

            int pointCount = points.Length;
            var availableKeys = Enumerable.Range(0, pointCount).ToList();
            int maxKeyInd = pointCount - 1;
            int picksRemaining = Math.Min(numberOfPicks, pointCount);
            int currentIndex = 0;

            while (picksRemaining > 0)
            {
                int randKeyInd = _random.Next(0, maxKeyInd + 1);
                int randInd = availableKeys[randKeyInd];
                availableKeys[randKeyInd] = availableKeys[maxKeyInd];
                selected[currentIndex] = points[randInd];
                maxKeyInd--;
                picksRemaining--;
                currentIndex++;
            }

            return selected;
        }

        public static int[] PickFromRangeWithoutReplacement(Random _random, int minValue, int maxValueExcl, int numberOfPicks) // based on Richard Durstenfeld's Fisher-Yates shuffle 
        {
            int[] picks = new int[numberOfPicks];

            int pointCount = maxValueExcl - minValue;
            var availableKeys = Enumerable.Range(minValue, pointCount).ToList();
            int maxInd = pointCount - 1;
            int picksRemaining = Math.Min(numberOfPicks, pointCount);
            int currentIndex = 0;

            while (picksRemaining > 0)
            {
                int randInd = _random.Next(minValue, maxInd + 1);
                picks[currentIndex] = availableKeys[randInd];
                availableKeys[randInd] = availableKeys[maxInd];
                maxInd--;
                picksRemaining--;
                currentIndex++;
            }

            return picks;
        }

        public static int[] PickFromRangeWithReplacement(Random _random, int minValue, int maxValueExcl, int numberOfPicks)
        {
            int[] picks = new int[numberOfPicks];

            for (int i = 0; i < numberOfPicks; ++i)
            {
                picks[i] = _random.Next(minValue, maxValueExcl);
            }

            return picks;
        }

        public static byte[] Add(byte[] x, byte[] y)
        {
            Debug.Assert(x.Length == y.Length);

            byte[] result = new byte[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                byte sum = (byte)(x[i] + y[i]);
                result[i] = sum;
            }
            return result;
        }

        public static byte[] Subtract(byte[] x, byte[] y)
        {
            Debug.Assert(x.Length == y.Length);

            byte[] result = new byte[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                byte sum = (byte)(x[i] - y[i]);
                result[i] = sum;
            }
            return result;
        }

        public static byte[] MeanOf(IEnumerable<byte[]> points, int dim)
        {
            Debug.Assert(points.Count() != 0 && dim > 0);

            byte[] mean = new byte[dim];
            for (int i = 0; i < dim; i++)
            {
                int sum = 0;
                foreach (var point in points)
                {
                    sum += point[i];
                }
                mean[i] = (byte)(sum / points.Count());
            }
            return mean;
        }

        public static byte[] WeightedAverageOf(byte[] x, int weight1, byte[] y, int weight2)
        {
            Debug.Assert(x.Length == y.Length);

            byte[] avg = new byte[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                int weightedSum = x[i] * weight1 + y[i] * weight2;
                byte weightedAvg = (byte)(weightedSum / (weight1 + weight2));
                avg[i] = weightedAvg;
            }
            return avg;
        }

        public static int[] DimwiseDiff(byte[] x, byte[] y)
        {
            Debug.Assert(x.Length == y.Length);

            int[] diffs = new int[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                diffs[i] = x[i] - y[i];
            }
            return diffs;
        }
    }
}

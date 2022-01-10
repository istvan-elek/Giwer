using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Giwer.dataStock.Clustering.Model
{
    public abstract partial class CentroidBasedClustering
    {
        protected class Point
        {
            protected byte[] _data;

            public int Dim => _data.Length;

            public Point(int dim) => _data = new byte[dim];

            public byte this[int dim]
            {
                set { _data[dim] = value; }
            }

            public static float SquaredEuclDist(Point x, Point y)
            {
                Debug.Assert(x.Dim == y.Dim);

                float res = 0.0F;
                for (int i = 0; i < x.Dim; i++)
                {
                    int diff = x._data[i] - y._data[i];
                    res += diff * diff;
                }
                return res;
            }

            public void Add(Point other)
            {
                Debug.Assert(Dim == other.Dim);

                for (int i = 0; i < Dim; i++)
                {
                    byte sum = (byte)(_data[i] + other._data[i]);
                    this[i] = sum;
                }
            }

            public void Subtract(Point other)
            {
                Debug.Assert(Dim == other.Dim);

                for (int i = 0; i < Dim; i++)
                {
                    byte diff = (byte)(_data[i] - other._data[i]);
                    this[i] = diff;
                }
            }

            public void SetMeanOf(IEnumerable<Point> points)
            {
                Debug.Assert(points.Count() != 0);

                for (int i = 0; i < Dim; i++)
                {
                    int sum = 0;
                    foreach (var point in points)
                    {
                        sum += point._data[i];
                    }

                    byte mean = (byte)(sum / points.Count());
                    this[i] = mean;
                }
            }

            public void SetWeightedAverageOf(Point x, int weight1, Point y, int weight2)
            {
                Debug.Assert(Dim == x.Dim);
                Debug.Assert(Dim == y.Dim);
                
                for (int i = 0; i < Dim; i++)
                {
                    int weightedSum = x._data[i] * weight1 + y._data[i] * weight2;
                    byte weightedAvg = (byte)(weightedSum / (weight1 + weight2));
                    this[i] = weightedAvg;
                }
            }

            public static int[] DimwiseDiff(Point x, Point y)
            {
                Debug.Assert(x.Dim == y.Dim);

                int[] res = new int[x.Dim];
                for (int i = 0; i < x.Dim; i++)
                {
                    res[i] = x._data[i] - y._data[i];
                }
                return res;
            }
            
            public void CopyValuesFrom(Point toCopy)
            {
                _data = toCopy._data.ToArray();
            }

        }

    }
}

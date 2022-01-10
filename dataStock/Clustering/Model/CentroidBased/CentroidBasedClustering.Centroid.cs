using System;
using System.Collections.Generic;
using System.Linq;

namespace Giwer.dataStock.Clustering.Model.CentroidBased
{
    public abstract partial class CentroidBasedClustering
    {
        protected class Centroid
        {
            private static readonly Random _random = new Random();

            public byte[] Values { get; private set; }

            public uint ID { get; private set; }
            public int Dim => Values.Length;

            public byte this[int dim]
            {
                set { Values[dim] = value; }
            }

            /// <summary>
            /// Create a new CentroidPoint and assign an unique ID to it.
            /// </summary>
            /// <param name="dim">The dimension of the CentroidPoint to be created.</param>
            public Centroid(int dim)
            {
                Values = new byte[dim];
                ID = _clusterIDGen;
                _clusterIDGen++;
            }

            public void FillWithRandomValues()
            {
                _random.NextBytes(Values);
            }

            public void Add(byte[] other)
            {
                Values = ClusteringUtilities.Add(Values, other);
            }

            public void Subtract(byte[] other)
            {
                Values = ClusteringUtilities.Subtract(Values, other);
            }

            public void SetMeanOf(IEnumerable<byte[]> points)
            {
                Values = ClusteringUtilities.MeanOf(points, Dim);
            }

            public void SetWeightedAverageOf(Centroid ctr1, int weight1, Centroid ctr2, int weight2)
            {
                Values = ClusteringUtilities.WeightedAverageOf(ctr1.Values, weight1, ctr2.Values, weight2);
            }

            /// <summary>
            /// Creates a new CentroidPoint and fills its values with a deep copy of the values of an existing CentroidPoint.
            /// The ID is not copied from the existing CentroidPoint.
            /// </summary>
            /// <returns>The newly created CentroidPoint.</returns>
            public static Centroid CentroidOfValues(Centroid toCopy)
            {
                Centroid res = new Centroid(toCopy.Dim);
                res.CopyValuesFrom(toCopy.Values);
                return res;
            }

            public void CopyValuesFrom(byte[] toCopy)
            {
                Values = toCopy.ToArray();
            }
        }
    }
}


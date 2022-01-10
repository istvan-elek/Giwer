using System.Collections;
using System.Collections.Generic;
using Giwer.dataStock.Clustering.Model.Distance;

namespace Giwer.dataStock.Clustering.Model.CentroidBased
{
    public abstract partial class CentroidBasedClustering
    {
        /// <summary>
        /// Representation of a cluster with its points and its centroid.
        /// </summary>
        /// <remarks>The points and their centroids may become "invalidated", when manipulated through some of the methods.
        /// This is intended behavior, but should be carefully considered for each use case.</remarks>
        protected class Cluster : IEnumerable<byte[]>
        {
            public List<uint> PointIndices { get; private set; }
            public int PointCount { get { return PointIndices.Count; } }
            private int PointDim => Centroid.Dim;
            public Centroid Centroid { get; private set; }
            public uint CentroidID => Centroid.ID;

            private byte[][] _points;
            private IDistance _distance;

            public Cluster(byte[][] points, IDistance distance, Centroid centroid)
            {
                _points = points;
                _distance = distance;
                PointIndices = new List<uint>();
                Centroid = centroid;
            }

            public void ClearPoints()
            {
                PointIndices.Clear();
            }

            public void AddPoint(uint pointInd)
            {
                PointIndices.Add(pointInd);
            }
            
            public IEnumerator<byte[]> GetEnumerator()
            {
                var iter = PointIndices.GetEnumerator();
                while (iter.MoveNext())
                {
                    yield return _points[iter.Current];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            /// <summary>
            /// Squared sum of errors of the points and their current mean. Uses the Euclidean distance.
            /// </summary>
            public float SSE()
            {
                byte[] mean = GetCurrentMeanPoint(); // TODO: could be Centroid instead if we would make sure that the Centroid is the current mean
                float res = 0.0F;
                foreach (uint ind in PointIndices)
                {
                    res += _distance.Calculate(mean, _points[ind]);
                }
                return res;
            }

            private byte[] GetCurrentMeanPoint()
            {
                if (PointCount != 0)
                {
                    return ClusteringUtilities.MeanOf(this, PointDim);
                }
                else
                {
                    return Centroid.Values;
                }
            }

            public void SetCentroidToMean()
            {
                if (PointCount != 0) // otherwise the centroid can remain unchanged
                {
                    Centroid.SetMeanOf(this);
                }
            }

            public void SetCentroidToWeightedAverageOf(Cluster cl1, Cluster cl2)
            {
                Centroid ctr1 = cl1.Centroid;
                int weight1 = cl1.PointCount;
                Centroid ctr2 = cl2.Centroid;
                int weight2 = cl2.PointCount;

                if (weight1 + weight2 != 0) // otherwise the centroid can remain unchanged
                {
                    Centroid.SetWeightedAverageOf(ctr1, weight1, ctr2, weight2);
                }
            }
        }
    }
}

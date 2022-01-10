using System.Collections;
using System.Collections.Generic;

namespace Giwer.dataStock.Clustering.Model
{
    public abstract partial class CentroidBasedClustering
    {
        /// <summary>
        /// Representation of a cluster with its points and its centroid.
        /// </summary>
        /// <remarks>The points and their centroids may become "invalidated", when manipulated through some of the methods.
        /// This is intended behavior, but should be carefully considered for each use case.</remarks>
        protected class Cluster : IEnumerable<ImagePoint>
        {
            public HashSet<ImagePoint> Points { get; }
            public int PointCount { get { return Points.Count; } }
            private int PointDim => Centroid.Dim;
            public CentroidPoint Centroid { get; }
            public uint CentroidID => Centroid.ID;

            public Cluster(CentroidPoint centroid)
            {
                Points = new HashSet<ImagePoint>();
                Centroid = centroid;
            }

            public void ClearPoints()
            {
                Points.Clear();
            }

            public void AddPoint(ImagePoint point)
            {
                Points.Add(point);
            }
            public IEnumerator<ImagePoint> GetEnumerator()
            {
                return ((IEnumerable<ImagePoint>)Points).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)Points).GetEnumerator();
            }
        
            /// <summary>
            /// Squared sum of errors of the points and their current mean. Uses the euclidean distance.
            /// </summary>
            public float SSE()
            {
                Point mean = GetCurrentMeanPoint(); // TODO: could be Centroid instead if we would make sure that the Centroid is the current mean
                float res = 0.0F;
                foreach (var point in Points)
                {
                    res += Point.SquaredEuclDist(mean, point);
                }
                return res;
            }

            private Point GetCurrentMeanPoint()
            {
                Point currentMean = new Point(PointDim);
                if (PointCount != 0)
                {
                    currentMean.SetMeanOf(Points);
                }
                else
                {
                    currentMean = Centroid;
                }
                return currentMean;
            }

            public void SetCentroidToMean()
            {
                if (PointCount != 0) // otherwise the centroid can remain unchanged
                {
                    Centroid.SetMeanOf(Points);
                }
            }

            public void SetCentroidToWeightedAverageOf(Cluster cl1, Cluster cl2)
            {
                CentroidPoint ctr1 = cl1.Centroid;
                int weight1 = cl1.PointCount;
                CentroidPoint ctr2 = cl2.Centroid;
                int weight2 = cl2.PointCount;

                if (weight1 + weight2 != 0) // otherwise the centroid can remain unchanged
                {
                    Centroid.SetWeightedAverageOf(ctr1, weight1, ctr2, weight2);
                }
            }

        }
    }
}

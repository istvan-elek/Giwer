using System;
using System.Linq;

namespace Giwer.dataStock.Clustering.Model
{
    public abstract partial class CentroidBasedClustering
    {
        protected class CentroidPoint : Point
        {
            private static readonly Random _random = new Random();

            public uint ID { get; }

            /// <summary>
            /// Create a new CentroidPoint and assign an unique ID to it.
            /// </summary>
            /// <param name="dim">The dimension of the CentroidPoint to be created.</param>
            public CentroidPoint(int dim) : base(dim)
            {
                ID = _clusterIDGen;
                _clusterIDGen++;
            }

            public void FillWithRandomValues()
            {
                _random.NextBytes(_data);
            }

            /// <summary>
            /// Creates a new CentroidPoint and fills its values with a deep copy of the values of an existing CentroidPoint.
            /// The ID is not copied from the existing CentroidPoint.
            /// </summary>
            /// <returns>The newly created CentroidPoint.</returns>
            public static CentroidPoint CentroidOfValues(CentroidPoint toCopy)
            {
                CentroidPoint res = new CentroidPoint(toCopy.Dim);
                res.CopyValuesFrom(toCopy);
                return res;
            }

        }

    }
}

using System;

namespace Giwer.dataStock.Clustering.Model
{
    public abstract partial class CentroidBasedClustering
    {
        protected class ImagePoint : Point, IEquatable<ImagePoint>
        {
            /// <summary>
            /// Used to identify the original pixel that this point is based on.
            /// </summary>
            public int Index { get; }

            /// <summary>
            /// Create a new ImagePoint that should correspond to a pixel of the input image.
            /// </summary>
            /// <param name="dim">The dimension of the ImagePoint to be created.</param>
            /// <param name="index">The value that can be used to identify the original pixel that this point corresponds to.</param>
            public ImagePoint(int dim, int index) : base(dim)
            {
                Index = index;
            }

            public override bool Equals(Object obj)
            {
                var other = obj as ImagePoint;

                if (other == null)
                {
                    return false;
                }
                return Equals(other);
            }

            public override int GetHashCode()
            {
                return Index;
            }

            public bool Equals(ImagePoint other)
            {
                return Index.Equals(other.Index);
            }
        }

    }
}

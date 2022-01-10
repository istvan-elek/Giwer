namespace Giwer.dataStock.Clustering.Model
{
    public abstract partial class CentroidBasedClustering
    {
        private abstract class PointLoader
        {
            /// <summary>
            /// Fill an array of ImagePoints from a certain image source.
            /// </summary>
            /// <returns>The array of ImagePoints containing the values from the source.</returns>
            public ImagePoint[] LoadPoints()
            {
                ImagePoint[] points = InitPoints(PointDim);
                SetPointsFromLoadedBands(points);
                return points;
            }

            private ImagePoint[] InitPoints(int dim)
            {
                long pixelCount = PixelCount;
                ImagePoint[] points = new ImagePoint[pixelCount];
                for (int pixelInd = 0; pixelInd < pixelCount; pixelInd++)
                {
                    points[pixelInd] = new ImagePoint(dim, pixelInd);
                }
                return points;
            }

            /// <summary>
            /// The number of pixels in the source image.
            /// </summary>
            protected abstract long PixelCount { get; }
            /// <summary>
            /// The dimension of each pixel (the number of bands) in the source image.
            /// </summary>
            public abstract int PointDim { get; }

            /// <summary>
            /// Set each dimension of each point with the corresponding band values of pixels.
            /// </summary>
            /// <param name="points">The initialized array to set the points' values in.</param>
            protected abstract void SetPointsFromLoadedBands(ImagePoint[] points);
            
            protected void SetPointsAtDim(ImagePoint[] points, byte[] loadedBand, int dim)
            {
                for (int pixelInd = 0; pixelInd < loadedBand.Length; pixelInd++)
                {
                    byte pixelVal = loadedBand[pixelInd];
                    ImagePoint point = points[pixelInd];
                    point[dim] = pixelVal;
                }
            }
        }

    }
}

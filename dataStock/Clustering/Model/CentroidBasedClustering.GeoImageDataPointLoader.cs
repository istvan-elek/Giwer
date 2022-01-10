namespace Giwer.dataStock.Clustering.Model
{
    public abstract partial class CentroidBasedClustering
    {
        private class GeoImageDataPointLoader : PointLoader
        {
            private GeoImageData _gImgData;
            private int[] _includedBands;
            public GeoImageDataPointLoader(GeoImageData gImgData, int[] includedBands)
            {
                _gImgData = gImgData;
                _includedBands = includedBands;
            }

            protected override long PixelCount { get { return _gImgData.Ncols * _gImgData.Nrows; } }
            public override int PointDim => _includedBands.Length;

            protected override void SetPointsFromLoadedBands(ImagePoint[] points)
            {
                GeoImageTools gImgTools = new GeoImageTools(_gImgData);
                for (int curDim = 0; curDim < PointDim; curDim++)
                {
                    int bandInd = _includedBands[curDim];
                    byte[] loadedBand = gImgTools.getOneBandBytes(bandInd);
                    SetPointsAtDim(points, loadedBand, curDim);
                }
            }
        }
    }
}

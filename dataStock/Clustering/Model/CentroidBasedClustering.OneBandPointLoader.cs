namespace Giwer.dataStock.Clustering.Model
{
    public abstract partial class CentroidBasedClustering
    {
        private class OneBandPointLoader : PointLoader
        {
            private byte[] _band;
            public OneBandPointLoader(byte[] band)
            {
                _band = band;
            }

            protected override long PixelCount { get { return _band.Length; } }
            public override int PointDim => 1;

            protected override void SetPointsFromLoadedBands(ImagePoint[] points)
            {
                SetPointsAtDim(points, _band, 0);
            }
        }
    }
}

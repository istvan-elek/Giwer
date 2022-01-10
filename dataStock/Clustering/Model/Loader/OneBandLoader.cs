using System;

namespace Giwer.dataStock.Clustering.Model.Loader
{
    public class OneBandLoader : ImageLoader
    {
        private byte[] _band;

        public OneBandLoader(byte[] band)
        {
            _band = band;

            PointCount = _band.Length;
            BandCount = 1;
        }

        protected override void SetValuesFromLoadedBands<T>(T values, Action<T,  byte[], int> setAtBand)
        {
            setAtBand(values, _band, 0);
        }
    }
}

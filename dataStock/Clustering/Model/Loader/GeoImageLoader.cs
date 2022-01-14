using System;

namespace Giwer.dataStock.Clustering.Model.Loader
{
    public class GeoImageLoader : ImageLoader
    {
        private GeoImageData _gImgData;
        private int[] _includedBands;

        public GeoImageLoader(GeoImageData gImgData, params int[] includedBands)
        {
            _gImgData = gImgData;
            _includedBands = includedBands;

            PointCount = _gImgData.Ncols * _gImgData.Nrows;
            BandCount = _includedBands.Length;
        }

        protected override void SetValuesFromLoadedBands<T>(T values, Action<T, byte[], int> setAtBand)
        {
            GeoImageTools gImgTools = new GeoImageTools(_gImgData);
            for (int bandInd = 0; bandInd < BandCount; bandInd++)
            {
                int currentBand = _includedBands[bandInd];
                byte[] loadedBand = gImgTools.getOneBandBytes(currentBand);
                setAtBand(values, loadedBand, bandInd);
            }
        }
    }
}

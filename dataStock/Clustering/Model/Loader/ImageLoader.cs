using System;

namespace Giwer.dataStock.Clustering.Model.Loader
{
    public abstract class ImageLoader
    {
        /// <summary>
        /// The number of pixels in the source image.
        /// </summary>
        public int PointCount { get; protected set; }

        /// <summary>
        /// The dimension of each pixel (the number of bands) in the source image.
        /// </summary>
        public int BandCount { get; protected set; }

        public byte[][] LoadJaggedPoints()
        {
            return LoadJagged(PointCount, BandCount, SetJaggedPointsAtBand);
        }

        public byte[][] LoadJaggedBands()
        {
            return LoadJagged(BandCount, PointCount, SetJaggedBandsAtBand);
        }

        public byte[] LoadPoints()
        {
            return LoadContinuous(SetPointsAtBand);
        }

        public byte[] LoadBands()
        {
            return LoadContinuous(SetBandsAtBand);
        }

        private byte[][] LoadJagged(int firstDim, int secondDim, Action<byte[][], byte[], int> setAtBand)
        {
            byte[][] values = InitJagged(firstDim, secondDim);
            SetValuesFromLoadedBands(values, setAtBand);
            return values;
        }

        private byte[][] InitJagged(int firstDim, int secondDim)
        { 
            byte[][] jaggedArray = new byte[firstDim][];
            for (int i = 0; i < firstDim; i++)
            {
                jaggedArray[i] = new byte[secondDim];
            }
            return jaggedArray;
        }
        
        private byte[] LoadContinuous(Action<byte[], byte[], int> setAtBand)
        {
            byte[] values = new byte[PointCount * BandCount];
            SetValuesFromLoadedBands(values, setAtBand);
            return values;
        }

        /// <summary>
        /// Describes how the array values should be filled with each band of the input image.
        /// </summary>
        /// <param name="values">The array containing the loaded image.</param>
        /// <param name="setAtBand">The method that sets the values with a certain band.</param>
        protected abstract void SetValuesFromLoadedBands<T>(T values, Action<T, byte[], int> setAtBand);

        private void SetJaggedPointsAtBand(byte[][] points, byte[] loadedBand, int bandInd)
        {
            for (int pointInd = 0; pointInd < PointCount; pointInd++)
            {
                points[pointInd][bandInd] = loadedBand[pointInd];
            }
        }

        private void SetJaggedBandsAtBand(byte[][] bands, byte[] loadedBand, int bandInd)
        {
            bands[bandInd] = loadedBand;
        }

        private void SetPointsAtBand(byte[] points, byte[] loadedBand, int bandInd)
        {
            for (int pointInd = 0; pointInd < PointCount; pointInd++)
            {
                points[pointInd * BandCount + bandInd] = loadedBand[pointInd];
            }
        }

        private void SetBandsAtBand(byte[] bands, byte[] loadedBand, int bandInd)
        {
            for (int pointInd = 0; pointInd < PointCount; pointInd++)
            {
                bands[bandInd + pointInd] = loadedBand[pointInd];
            }
        }
    }
}

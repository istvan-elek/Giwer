using Giwer.dataStock.Clustering.Model.Loader;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Giwer.dataStock.Clustering.Model
{
    public abstract class AbstractAsyncClustering : IClustering
    {
        #region Properties
        public virtual int ClusterNum { get; protected set; }
        protected IProgress<ClusteringProgress> Progress { get; set; }
        protected CancellationToken CancellationToken { get; set; }
        #endregion

        #region Implemented methods
        public async Task<byte[]> ExecuteAsync(GeoImageData geoImageData, int[] includedBands,
                                               IProgress<ClusteringProgress> progress, CancellationToken cancellationToken)
        {
            if (includedBands.Length == 0 || includedBands.Length > geoImageData.Nbands)
                throw new ArgumentOutOfRangeException(nameof(includedBands), "Array length out of range predefined by the GeoImageData.");

            var imageLoader = new GeoImageLoader(geoImageData, includedBands);
            return await ExecuteAsync(imageLoader, progress, cancellationToken);
        }

        public async Task<byte[]> ExecuteAsync(byte[] imageBand,
                                               IProgress<ClusteringProgress> progress, CancellationToken cancellationToken)
        {
            var imageLoader = new OneBandLoader(imageBand);
            return await ExecuteAsync(imageLoader, progress, cancellationToken);
        }

        protected async Task<byte[]> ExecuteAsync(ImageLoader imageLoader,
                                                  IProgress<ClusteringProgress> progress, CancellationToken cancellationToken)
        {
            Progress = progress;
            CancellationToken = cancellationToken;

            return await Task.Run(() =>
            {
                return Execute(imageLoader);
            });
        }
        #endregion

        #region Abstract methods
        /// <summary>
        /// The main clustering execution logic, including the initialization (loading), cancellation, and progress handling.
        /// </summary>
        /// <param name="imageLoader">The initialized image loader object.</param>
        /// <returns></returns>
        protected abstract byte[] Execute(ImageLoader imageLoader);
        #endregion
    }
}

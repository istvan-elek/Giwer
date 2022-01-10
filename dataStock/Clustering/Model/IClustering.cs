using System;
using System.Threading;
using System.Threading.Tasks;

namespace Giwer.dataStock.Clustering.Model
{
    public interface IClustering
    {
        /// <summary>
        /// Executes the clustering with the given parameters.
        /// </summary>
        /// <param name="geoImageData">The header data corresponding to the input image to execute the clustering on.</param>
        /// <param name="includedBands">The indices of the bands that should be included in the execution of the clustering.</param>
        /// <param name="progress">The progress object used to report the status of the execution.</param>
        /// <param name="cancellationToken">The cancellation token object used to cancel the execution.</param>
        /// <returns>The corresponding cluster value (byte) of each input pixel, laid out in a byte[].</returns>
        /// <exception cref="NoClustersException">Thrown when the number of clusters ends up being zero during the computation,
        /// possibly due to some error in the parameters of the clustering.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the execution task is interrupted, e.g. via a request by the user.</exception>
        Task<byte[]> ExecuteAsync(GeoImageData geoImageData, int[] includedBands, IProgress<ClusteringProgress> progress, CancellationToken cancellationToken);

        /// <summary>
        /// Executes the clustering with the given parameters.
        /// </summary>
        /// <param name="imageBand">The loaded byte[] of a single image band to execute the clustering on.</param>
        /// <param name="progress">The progress object used to report the status of the execution.</param>
        /// <param name="cancellationToken">The cancellation token object used to cancel the execution.</param>
        /// <returns>The corresponding cluster value (byte) of each input pixel, laid out in a byte[].</returns>
        /// <exception cref="NoClustersException">Thrown when the number of clusters ends up being zero during the computation,
        /// possibly due to some error in the parameters of the clustering.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the execution task is interrupted, e.g. via a request by the user.</exception>
        Task<byte[]> ExecuteAsync(byte[] imageBand, IProgress<ClusteringProgress> progress, CancellationToken cancellationToken);

        /// <summary>
        /// The current number of clusters.
        /// </summary>
        int ClusterNum { get; }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Giwer.dataStock.Clustering.Model.Supervised
{
    public interface ISupervisedTrainer
    {
        Task<ISupervisedModel> TrainAsync(GeoImageData image, int[] includedBands, GeoImageData clustering, int clusteringBand,
                                          IProgress<ClusteringProgress> progress, CancellationToken cancellationToken);
    }
}

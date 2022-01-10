using System;
using System.Threading;
using System.Threading.Tasks;

namespace Giwer.dataStock.Clustering.Model.Supervised
{
    public interface ISupervisedModel
    {
        byte[] Predict(byte[][] points, IProgress<ClusteringProgress> progress, CancellationToken cancellationToken);

        Task SaveAsync(string fileName);

        Task LoadAsync(string fileName);

        int BandCount { get; }
    }
}

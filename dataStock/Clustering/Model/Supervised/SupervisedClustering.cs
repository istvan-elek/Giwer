using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Giwer.dataStock.Clustering.Model.Loader;

namespace Giwer.dataStock.Clustering.Model.Supervised
{
    public class SupervisedClustering : AbstractAsyncClustering
    {
        private ISupervisedModel _model;

        public SupervisedClustering(ISupervisedModel model)
        {
            _model = model;
        }        

        public override int ClusterNum { get; protected set; }

        protected override byte[] Execute(ImageLoader imageLoader)
        {
            Progress.Report(ClusteringProgress.Initializing(100));
            byte[][] points = imageLoader.LoadJaggedPoints();
            CancellationToken.ThrowIfCancellationRequested();

            var clusters = _model.Predict(points, Progress, CancellationToken);
            GetResult(clusters);
            return clusters;
        }

        private byte[] GetResult(byte[] rawResult)
        {
            ClusterNum = ClusterCount(rawResult);

            if (ClusterNum > 1)
            {
                GetEquallyDistributedClusterValuesIn(rawResult, ClusterNum);
            }

            return rawResult;
        }

        private int ClusterCount(byte[] result)
        {
            return result.Distinct().Count();
        }

        public static void GetEquallyDistributedClusterValuesIn(byte[] rawResult, int clusterCount)
        {
            byte currentClusterVal = 0;
            byte clusterValStride = (byte)(byte.MaxValue / (clusterCount - 1));

            var values = new Dictionary<byte, byte>();
            for (int i = 0; i < rawResult.Length; ++i)
            {
                if (values.TryGetValue(rawResult[i], out byte val))
                {
                    rawResult[i] = val;
                }
                else
                {
                    values.Add(rawResult[i], currentClusterVal);
                    currentClusterVal += clusterValStride;
                }
            }
        }
    }
}

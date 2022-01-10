using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Giwer.dataStock.Clustering.Model
{
    public class KmeansClustering : CentroidBasedClustering
    {
        #region Constants
            public const float ChangeThresholdMinVal = 0.0F;
            public const float ChangeThresholdMaxVal = 1.0F;
            public const float ChangeThresholdDefaultVal = 0.96F;

            public const uint MinClusterNumMinVal = 2;
            public const uint MinClusterNumMaxVal = 256;
            public const uint MinClusterNumDefaultVal = 2;
            public const uint MaxProcessNum = 8;
        #endregion

        #region Input parameters
        /// <summary>
        /// The upper limit of change in SSE during the steps of the iteration.
        /// </summary>
        public float ChangeThreshold { get; private set; }
        /// <summary>
        /// Minimum number of clusters to execute the clustering with.
        /// </summary>
        public uint MinClusterNum { get; private set; }
        public float Elbow { get; private set; }
        #endregion

        #region Constructors
        public KmeansClustering(GeoImageData gImgData, int[] bandsToUse, 
            uint maxIter,
            float changeThreshold,
            uint minClusterNum,
            uint maxClusterNum,
            float changeElbow)
            : base(gImgData, bandsToUse, maxIter, maxClusterNum)
        {
            InitParameters(changeThreshold, minClusterNum, maxClusterNum, changeElbow);
        }

        public KmeansClustering(byte[] band,
            uint maxIter,
            float changeThreshold,
            uint minClusterNum,
            uint maxClusterNum,
            float changeElbow)
            : base(band, maxIter, maxClusterNum)
        {
            InitParameters(changeThreshold, minClusterNum, maxClusterNum, changeElbow);
        }

        private void InitParameters(float changeThreshold, uint minClusterNum, uint maxClusterNum, float changeElbow)
        {
            if (changeThreshold < ChangeThresholdMinVal || changeThreshold > ChangeThresholdMaxVal)
                throw new ArgumentOutOfRangeException(nameof(changeThreshold), "Value is out of the predefined range.");

            if (minClusterNum < MinClusterNumMinVal || minClusterNum > MinClusterNumMaxVal)
                throw new ArgumentOutOfRangeException(nameof(minClusterNum), "Value is out of the predefined range.");

            if (minClusterNum > MaxClusterNum)
                throw new ArgumentOutOfRangeException(nameof(minClusterNum), "The minimum number of clusters must be less than the maximum.");

            ChangeThreshold = changeThreshold;
            MinClusterNum = minClusterNum;
            Elbow = changeElbow; // TODO: verify this + add default values
        }
        #endregion

        /// <summary>
        /// Initialize empty clusters with centroid values based on their distances from each other.
        /// </summary>
        /// <param name="clusterCount">Number of clusters to initialize.</param>
        protected void InitEmptyKmeansClusters(uint clusterCount)
        {
            _clusters = new Dictionary<uint, Cluster>();
            CentroidPoint firstcentroid = new CentroidPoint(PointDim);
            firstcentroid.FillWithRandomValues();                        //first center is random
            _clusters.Add(firstcentroid.ID, new Cluster(firstcentroid));

            for (uint i = 1; i < clusterCount; i++)
            {
                CentroidPoint centroid = new CentroidPoint(PointDim);
                Point farthest = new Point(PointDim);
                float maxDist = 0.0f;
                foreach (ImagePoint point in _points)
                {
                    float dist = 0.0f;
                    foreach (var cluster in _clusters)
                    {
                        dist += Point.SquaredEuclDist(cluster.Value.Centroid, point);
                    }

                    if (dist > maxDist)
                    {
                        maxDist = dist;
                        farthest = point;
                    }
                }
                centroid.CopyValuesFrom(farthest);
                _clusters.Add(centroid.ID, new Cluster(centroid));
            }
        }

        protected override byte[] Execute()
        {
            uint ClusterNum = MinClusterNum;
            bool RelativeChange = false;
            float GlobalPrevSSE = float.MaxValue;
            while (ClusterNum <= MaxClusterNum && !RelativeChange)
            {
                InitEmptyKmeansClusters(ClusterNum);
                AssignPointsToClusters();
                uint iter = 1;
                float prevSSE = float.MaxValue;
                float currentSSE = TotalSSE();
                while (iter <= MaxIter && (currentSSE / prevSSE) < ChangeThreshold)
                {
                    prevSSE = currentSSE;
                    UpdateCentroids();
                    ReassignPointsToClusters();
                    currentSSE = TotalSSE();

                    CancellationToken.ThrowIfCancellationRequested();
                    OnExecutionProgressUpdated(iter);
                    ++iter;
                    System.Diagnostics.Debug.WriteLine("(currentSSE / prevSSE): " + (currentSSE / prevSSE));
                }
                System.Diagnostics.Debug.WriteLine("Clusternum: " + ClusterNum + " with iterations: " + (iter-1) +
                    " and SSE = " + currentSSE + " and relative change = " + (currentSSE / GlobalPrevSSE) + " current elbow: " + Elbow);
                RelativeChange = (currentSSE / GlobalPrevSSE > Elbow);
                GlobalPrevSSE = currentSSE;
                ++ClusterNum;
                
            }

            return GetResultInByteArray();
        }
        

        private async Task<uint> GetElbow()
        {
            var currentClusteringTasks = new List<Task<KeyValuePair<uint, float>>>();
            for (uint i = MinClusterNum; i <= MaxClusterNum && i <= MinClusterNum + MaxProcessNum; ++i)
            {
                currentClusteringTasks.Add(ClusteringAtGivenNumberAsync(i));
            }

            var remainingClusteringTasks = new List<Task<KeyValuePair<uint, float>>>();
            for (uint i = MinClusterNum + MaxProcessNum + 1; i <= MaxClusterNum; ++i)
            {
                remainingClusteringTasks.Add(ClusteringAtGivenNumberAsync(i));
            }

            var sseValues = new SortedDictionary<uint, float>();
            while (currentClusteringTasks.Count > 0)
            {
                var finishedTask = await Task.WhenAny<KeyValuePair<uint, float>>(currentClusteringTasks);
                KeyValuePair<uint, float> Pair = await finishedTask;
                sseValues.Add(Pair.Key, Pair.Value);

                currentClusteringTasks.Remove(finishedTask);
                if (remainingClusteringTasks.Count > 0)
                {
                    currentClusteringTasks.Add(remainingClusteringTasks[0]);
                    remainingClusteringTasks.RemoveAt(0);
                }
            }

            uint ret = MinClusterNum;
            bool found = false;
            float sse;
            float sseNext;
            float sseNextNext;
            if (sseValues.Count > 3)
            {
                while (!found && sseValues.TryGetValue(ret, out sse) && sseValues.TryGetValue(ret+1, out sseNext) && sseValues.TryGetValue(ret+2, out sseNextNext))
                {
                    found = Math.Abs(sse / sseNext - sseNext / sseNextNext) < Elbow;
                    ++ret;
                } 
                if (ret > MinClusterNum)
                {
                    --ret;
                }
            }
            return ret;
        }

        
        private async Task<KeyValuePair<uint, float>> ClusteringAtGivenNumberAsync(uint numberOfClusters)
        {
            var clusteringTask = Task.Run(() =>
            {
                return new KeyValuePair<uint, float>(numberOfClusters, ClusteringAtGivenNumber(numberOfClusters));
            });
            return await clusteringTask;
        }

        private float ClusteringAtGivenNumber(uint numberOfClusters)
        {           
            InitEmptyKmeansClusters(numberOfClusters);
            AssignPointsToClusters();
            uint iter = 1;
            float prevSSE = float.MaxValue;
            float currentSSE = TotalSSE();
            while (iter <= MaxIter && (currentSSE / prevSSE) < ChangeThreshold)
            {
                prevSSE = currentSSE;
                UpdateCentroids();
                ReassignPointsToClusters();
                currentSSE = TotalSSE();
                CancellationToken.ThrowIfCancellationRequested();
                ++iter;
            }
            System.Diagnostics.Debug.WriteLine("numberOfClusters: " + numberOfClusters + " with iterations: " + (iter - 1) +
                " and SSE = " + currentSSE);

            return currentSSE;
        }




    }
}

using System;
using System.Collections.Generic;

namespace Giwer.dataStock.Clustering.Model.CentroidBased
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
        public float FinalSSE { get; private set; }
        protected override int MaxStep => (int)MaxIter;


        #region Constructors
        public KmeansClustering(
            uint maxIter,
            float changeThreshold,
            uint minClusterNum,
            uint maxClusterNum,
            float changeElbow)
            : base(maxIter, maxClusterNum)
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
            Centroid firstcentroid = new Centroid(PointDim);
            firstcentroid.FillWithRandomValues();                        //first center is random
            _clusters.Add(firstcentroid.ID, new Cluster(_points, _distance, firstcentroid));

            for (uint i = 1; i < clusterCount; i++)
            {
                Centroid centroid = new Centroid(PointDim);
                byte[] farthest = new byte[PointDim];
                float maxDist = 0.0f;
                foreach (byte[] point in _points)
                {
                    float dist = 0.0f;
                    foreach (var cluster in _clusters.Values)
                    {
                        dist += _distance.Calculate(cluster.Centroid.Values, point);
                    }

                    if (dist > maxDist)
                    {
                        maxDist = dist;
                        farthest = point;
                    }
                }
                centroid.CopyValuesFrom(farthest);
                _clusters.Add(centroid.ID, new Cluster(_points, _distance, centroid));
            }
        }

        protected override byte[] ExecuteBody()
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
                    Progress.Report(ClusteringProgress.StepTaken((int)iter));
                    ++iter;
                    System.Diagnostics.Debug.WriteLine("(currentSSE / prevSSE): " + (currentSSE / prevSSE));
                }
                System.Diagnostics.Debug.WriteLine("Clusternum: " + ClusterNum + " with iterations: " + (iter - 1) +
                    " and SSE = " + currentSSE + " and relative change = " + (currentSSE / GlobalPrevSSE) + " current elbow: " + Elbow);
                RelativeChange = (1 - (currentSSE / GlobalPrevSSE) < Elbow);
                GlobalPrevSSE = currentSSE;
                ++ClusterNum;

            }

            FinalSSE = GlobalPrevSSE;
            return GetResultInByteArray();
        }

        public float ClusteringAtGivenNumber(uint numberOfClusters)
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
                Progress.Report(ClusteringProgress.StepTaken((int)iter));
                ++iter;
            }
            System.Diagnostics.Debug.WriteLine("Async numberOfClusters: " + numberOfClusters + " with iterations: " + (iter - 1) +
                " and SSE = " + currentSSE);

            return currentSSE;
        }




    }
}

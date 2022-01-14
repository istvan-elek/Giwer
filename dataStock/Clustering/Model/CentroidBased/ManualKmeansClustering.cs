using System;
using System.Collections.Generic;

namespace Giwer.dataStock.Clustering.Model.CentroidBased
{
    public class ManualKmeansClustering : CentroidBasedClustering
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
        public float _ChangeThreshold { get; private set; }
        /// <summary>
        /// Minimum number of clusters to execute the clustering with.
        /// </summary>
        public List<int> _Clusters { get; private set; }
        #endregion
        public float FinalSSE { get; private set; }
        protected override int MaxStep => (int)MaxIter;
        private bool _isPoly;
        private List<List<int>> _polysInPoints;


        #region Constructors
        public ManualKmeansClustering(
            uint maxIter,
            float changeThreshold,
            List<int> Clusters,
            bool isPoly,
            List<List<int>> polysInPoints)
            : base(maxIter, (uint)Clusters.Count)
        {
            if (changeThreshold < ChangeThresholdMinVal || changeThreshold > ChangeThresholdMaxVal)
                throw new ArgumentOutOfRangeException(nameof(changeThreshold), "Value is out of the predefined range.");

            _ChangeThreshold = changeThreshold;
            _Clusters = Clusters;
            _isPoly = isPoly;
            _polysInPoints = polysInPoints;
        }
        #endregion


        protected override byte[] ExecuteBody()
        {
            if (_isPoly)
                InitManualClustersPoly(_polysInPoints);
            else
                InitManualClusters(_Clusters);

            AssignPointsToClusters();
            uint iter = 1;
            float prevSSE = float.MaxValue;
            float currentSSE = TotalSSE();
            while (iter <= MaxIter && (currentSSE / prevSSE) < _ChangeThreshold)
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
            System.Diagnostics.Debug.WriteLine("Clusternum: " + ClusterNum + " with iterations: " + (iter - 1) + " and SSE = " + currentSSE);

            return GetResultInByteArray();
        }


    }
}

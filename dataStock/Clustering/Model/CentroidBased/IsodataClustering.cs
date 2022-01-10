using System;
using System.Collections.Generic;
using System.Linq;

namespace Giwer.dataStock.Clustering.Model.CentroidBased
{
    /// <summary>
    /// ISODATA clustering algorithm based on: Tou, Julius T. and Rafael C. Gonzalez. 1974. Pattern Recognition Principles. Addison-Wesley Publishing Co.
    /// </summary>
    public class IsodataClustering : CentroidBasedClustering
    {
        #region Constants
        public const uint InitClusterNumMinVal = 2;
        public const uint InitClusterNumMaxVal = 256;
        public const uint InitClusterNumDefaultVal = 10;

        public const uint MinClusterSizeMinVal = 1;
        public const uint MinClusterSizeMaxVal = 100_000;
        public const uint MinClusterSizeDefaultVal = 100;

        public const float SDLimitMinVal = 0.0F;
        public const float SDLimitMaxVal = 100_000.0F;
        public const float SDLimitDefaultVal = 1.0F;

        public const float MinCentroidDistMinVal = 0.0F;
        public const float MinCentroidDistMaxVal = 100_000.0F;
        public const float MinCentroidDistDefaultVal = 1_000.0F;

        public const uint MaxMergePerIterMinVal = 0;
        public const uint MaxMergePerIterMaxVal = 100_000;
        public const uint MaxMergePerIterDefaultVal = 10;
        #endregion

        #region Input parameters
        /// <summary>
        /// Initial number of clusters.
        /// </summary>
        public uint InitClusterNum { get; private set; }
        /// <summary>
        /// Minimum number of points that can form a cluster.
        /// </summary>
        public uint MinClusterSize { get; private set; }
        /// <summary>
        /// Maximum std deviation of points from their cluster center along each axis, SQUARED.
        /// </summary>
        public float SDSquaredLimit { get; private set; }
        /// <summary>
        /// Minimum required distance between two centroids.
        /// </summary>
        public float MinCentroidDist { get; private set; }
        /// <summary>
        /// Maximum number of cluster pairs that can be merged per iteration.
        /// </summary>
        public uint MaxMergePerIter { get; private set; }
        #endregion

        #region Properties
        protected override int MaxStep => (int)MaxIter;
        /// <summary>
        /// Current iteration number. The iteration starts with the value of 1.
        /// </summary>
        public uint CurrentIter { get; private set; }
        /// <summary>
        /// The factor that helps determine the extent of change in the new centroids emerging after splitting.
        /// </summary>
        public float SplittingCentroidFactor { get; private set; }
        private float CurrentMinCentroidDist { get; set; }
        #endregion

        #region Constructors
        public IsodataClustering(
            uint maxIter = MaxIterDefaultVal,
            uint initClusterNum = InitClusterNumDefaultVal, 
            uint maxClusterNum = MaxClusterNumDefaultVal,
            uint minClusterSize = MinClusterSizeDefaultVal,
            float pointsFromCentroidSDLimit = SDLimitDefaultVal,
            float minCentroidDist = MinCentroidDistDefaultVal,
            uint maxMergePerIter = MaxMergePerIterDefaultVal)
            : base(maxIter, maxClusterNum)
        {
            if (initClusterNum < InitClusterNumMinVal || initClusterNum > InitClusterNumMaxVal)
                throw new ArgumentOutOfRangeException(nameof(initClusterNum), "Value is out of the predefined range.");

            if (initClusterNum > MaxClusterNum)
                throw new ArgumentOutOfRangeException(nameof(initClusterNum), "The initial number of clusters must be less than the maximum.");

            if (minClusterSize < MinClusterSizeMinVal || minClusterSize > MinClusterSizeMaxVal)
                throw new ArgumentOutOfRangeException(nameof(minClusterSize), "Value is out of the predefined range.");

            if (pointsFromCentroidSDLimit < SDLimitMinVal || pointsFromCentroidSDLimit > SDLimitMaxVal)
                throw new ArgumentOutOfRangeException(nameof(pointsFromCentroidSDLimit), "Value is out of the predefined range.");

            if (minCentroidDist < MinCentroidDistMinVal || minCentroidDist > MinCentroidDistMaxVal)
                throw new ArgumentOutOfRangeException(nameof(minCentroidDist), "Value is out of the predefined range.");

            if (maxMergePerIter < MaxMergePerIterMinVal || maxMergePerIter > MaxMergePerIterMaxVal)
                throw new ArgumentOutOfRangeException(nameof(maxMergePerIter), "Value is out of the predefined range.");

            SplittingCentroidFactor = 0.5F;
            InitClusterNum = initClusterNum;
            MinClusterSize = minClusterSize;
            SDSquaredLimit = pointsFromCentroidSDLimit * pointsFromCentroidSDLimit;
            MinCentroidDist = minCentroidDist;
            MaxMergePerIter = maxMergePerIter;
        }
        #endregion

        #region Overridden methods
        protected override byte[] ExecuteBody()
        {
            InitEmptyClustersFromRandomImagePoints(InitClusterNum);
            ExecuteIteration();
            return GetResultInByteArray();
        }
        #endregion

        #region Methods for the iteration
        private void ExecuteIteration()
        {
            CurrentIter = 1; // an even numbered iteration is every second one
            CurrentMinCentroidDist = MinCentroidDist;
            while (IsIterationNeeded)
            {
                TakeIterationStep();
                CurrentIter++;
            }
        }

        private bool IsIterationNeeded => CurrentIter <= MaxIter;

        private bool IsLastIter => CurrentIter == MaxIter;

        private void TakeIterationStep()
        {
            IterationStep();
            OnIterationStepTaken();
        }

        /// <summary>
        /// The main body of the iteration.
        /// </summary>
        /// <remarks>
        /// The original algorithm in Pattern Recognition Principles calculates
        /// the average point to centroid distances, and their overall average right after updating the centroids.
        /// In this implementation, they are only calculated if necessary during the cluster splitting.
        /// </remarks>
        private void IterationStep()
        {
            ReassignPointsToClusters();
            bool hasRemovedClusters = RemoveClustersWithFewPoints();
            UpdateCentroids();

            if (!hasRemovedClusters)
            {
                ResetMinCentroidDistIfNecessary();
                bool hasSplitClusters = SplitClustersIfNecessary();

                if (!hasSplitClusters)
                {
                    MergeClustersWhereNecessary();
                }
            }
        }

        private void OnIterationStepTaken()
        {
            CancellationToken.ThrowIfCancellationRequested();
            Progress.Report(ClusteringProgress.StepTaken((int)CurrentIter));
        }
        #endregion

        #region Methods for removing clusters
        private bool RemoveClustersWithFewPoints()
        {
            var clustersToRemove = ClustersWithFewPoints();
            foreach (var cluster in clustersToRemove)
            {
                _clusters.Remove(cluster.CentroidID);
            }
            return clustersToRemove.Any();
        }

        private List<Cluster> ClustersWithFewPoints()
        {
            return _clusters.Where(ckv => ckv.Value.PointCount < MinClusterSize)
                            .Select(ckv => ckv.Value)
                            .ToList();
        }
        #endregion

        #region Methods for cluster splitting
        /// <summary>
        /// Splits clusters if it is necessary in general in the current iteration.
        /// </summary>
        /// <returns>Boolean value describing whether the splitting took place.</returns>
        private bool SplitClustersIfNecessary()
        {
            if (IsSplittingNecessary)
            {
                return SplitClustersWhereNecessary();
            }
            return false;
        }

        private bool IsSplittingNecessary => !NoSplittingNecessary && !IsClusterNumAtUpperLimit;

        private bool NoSplittingNecessary => IsLastIter
                                             || (2 * ClusterNum > InitClusterNum
                                                && (IsEven(CurrentIter) || ClusterNum >= 2 * InitClusterNum));

        private bool IsEven(uint num)
        {
            return num % 2 == 0;
        }

        private bool IsClusterNumAtUpperLimit => ClusterNum >= MaxClusterNum;

        /// <summary>
        /// Splits each cluster where it is necessary.
        /// </summary>
        /// <returns>Boolean value describing whether the splitting took place.</returns>
        private bool SplitClustersWhereNecessary()
        {
            bool hasSplitClusters = false;

            var avgDists = AveragePointToCentroidDists();

            var clustersBeforeSplitting = _clusters.Values.ToList();
            foreach (Cluster cluster in clustersBeforeSplitting)
            {
                hasSplitClusters = SplitClusterIfNecessary(cluster, avgDists);
            }

            return hasSplitClusters;
        }

        private (float, Dictionary<Cluster, float>) AveragePointToCentroidDists()
        {
            var SSEs = AllSSEs();

            float totalAvgDist = TotalAvgPointToCentroidDist(SSEs);
            var avgDists = AllAvgPointToCentroidDists(SSEs);

            return (totalAvgDist, avgDists);
        }

        private Dictionary<Cluster, float> AllSSEs()
        {
            var SSEs = new Dictionary<Cluster, float>();
            foreach (var cluster in _clusters.Values)
            {
                SSEs.Add(cluster, cluster.SSE());
            }
            return SSEs;
        }

        private float TotalAvgPointToCentroidDist(Dictionary<Cluster, float> SSEs)
        {
            float totalSSE = 0.0F;
            foreach (var sse in SSEs.Values)
            {
                totalSSE += sse;
            }
            return totalSSE / _points.Length;
        }
        
        private Dictionary<Cluster, float> AllAvgPointToCentroidDists(Dictionary<Cluster, float> SSEs)
        {
            var avgDists = new Dictionary<Cluster, float>();
            foreach (var ckv in SSEs)
            {
                int pointCount = ckv.Key.PointCount;
                float avgDist = pointCount * ckv.Value;

                avgDists.Add(ckv.Key, avgDist);
            }
            return avgDists;
        }

        /// <summary>
        /// Split a single cluster, provided it is necessary.
        /// </summary>
        /// <param name="cluster">Cluster to (possibly) be split.</param>
        /// <param name="avgDists">Overall average of D in all clusters, 
        /// and averages of D for each cluster,
        /// where D is the distance between the centroid and the corresponding points.</param>
        /// <returns>Boolean value describing whether the splitting took place.</returns>
        private bool SplitClusterIfNecessary(Cluster cluster, (float, Dictionary<Cluster, float>) avgDists)
        {
            var maxSDSquaredAndDim = MaxSDSquaredAndDim(cluster);

            float maxSDSquared = maxSDSquaredAndDim.Item1;
            int maxSDDim = maxSDSquaredAndDim.Item2;
            float totalAvgDist = avgDists.Item1;
            float avgDist = avgDists.Item2[cluster];

            if (IsSplittingNecessaryInCluster(cluster, maxSDSquared, avgDist, totalAvgDist))
            {
                SplitCluster(cluster, maxSDDim, maxSDSquared);
                return true;
            }
            return false;
        }

        private (float, int) MaxSDSquaredAndDim(Cluster cluster)
        {
            int[] dimwiseDiffsSquaredSum = DimwiseDiffsSquaredSum(cluster);
            // originally all dimwiseDiffs would be divided by the number of points in the cluster here,
            // but it should be adequate to find the max from the unmodified list and only divide that max
            int maxDim = ArgMax(dimwiseDiffsSquaredSum);
            float maxSquaredSD = dimwiseDiffsSquaredSum[maxDim] / cluster.PointCount;
            return (maxSquaredSD, maxDim);
        }

        private int[] DimwiseDiffsSquaredSum(Cluster cluster)
        {
            List<int[]> dimwiseDiffs = DimwiseDiffsFromCentroid(cluster);
            return DimwiseSquaredSum(dimwiseDiffs);
        }

        private List<int[]> DimwiseDiffsFromCentroid(Cluster cluster)
        {
            List<int[]> res = new List<int[]>();
            foreach (byte[] point in cluster)
            {
                int[] dimwiseDiff = ClusteringUtilities.DimwiseDiff(point, cluster.Centroid.Values);
                res.Add(dimwiseDiff);
            }
            return res;
        }

        private int[] DimwiseSquaredSum(List<int[]> diffs)
        {
            System.Diagnostics.Debug.Assert(diffs.Count != 0);

            int dim = diffs[0].Length;
            int[] dimwiseSquaredSum = new int[dim];
            for (int i = 0; i < dim; i++)
            {
                dimwiseSquaredSum[i] = SquaredSumAtDim(i, diffs);
            }
            return dimwiseSquaredSum;
        }

        private int SquaredSumAtDim(int dim, List<int[]> diffs)
        {
            int squaredSum = 0;
            foreach (int[] diff in diffs)
            {
                squaredSum += diff[dim] * diff[dim];
            }
            return squaredSum;
        }

        private int ArgMax(int[] values)
        {
            int maxValue = values[0];
            int maxInd = 0;
            for (int i = 1; i < values.Length; i++)
            {
                int thisValue = values[i];
                if (thisValue > maxValue)
                {
                    maxValue = thisValue;
                    maxInd = i;
                }
            }
            return maxInd;
        }

        private bool IsSplittingNecessaryInCluster(Cluster cluster, float maxClusterSDSquared, float avgPointToCentroidDist, float totalAvgPointToCentroidDist)
        {
            return maxClusterSDSquared > SDSquaredLimit
                   & (((avgPointToCentroidDist > totalAvgPointToCentroidDist)
                           && (cluster.PointCount > 2 * MinClusterSize + 2))
                      || ClusterNum <= (InitClusterNum / 2));
        }

        /// <summary>
        /// Splits the given cluster: the cluster is removed, and two clusters are added,
        /// with their centroids based on the deleted cluster's centroid.
        /// </summary>
        /// <param name="cluster">Cluster to be split.</param>
        /// <param name="maxSDDim">The index of the dimension where the maximal standard deviation is found.</param>
        /// <param name="maxSDSquared">The square of the maximal standard deviation value.</param>
        private void SplitCluster(Cluster cluster, int maxSDDim, float maxSDSquared)
        {
            byte[] offset = SplittingCentroidOffset(maxSDDim, maxSDSquared);
            var newCentroids = SplittingCentroidsFor(cluster, offset);

            CreateSplitClusterFrom(newCentroids.Item1);
            CreateSplitClusterFrom(newCentroids.Item2);

            _clusters.Remove(cluster.CentroidID);
        }

        private byte[] SplittingCentroidOffset(int maxSDDim, float maxSDSquared)
        {
            byte modifier = (byte)(maxSDSquared * SplittingCentroidFactor);

            byte[] offset = new byte[PointDim];
            offset[maxSDDim] = modifier;

            return offset;
        }

        private (Centroid, Centroid) SplittingCentroidsFor(Cluster cluster, byte[] offset)
        {
            Centroid ctr1 = Centroid.CentroidOfValues(cluster.Centroid);
            ctr1.Add(offset);

            Centroid ctr2 = Centroid.CentroidOfValues(cluster.Centroid);
            ctr2.Subtract(offset);

            return (ctr1, ctr2);
        }

        private void CreateSplitClusterFrom(Centroid newCentroid)
        {
            _clusters[newCentroid.ID] = new Cluster(_points, _distance, newCentroid);
        }
        #endregion

        #region Methods for cluster merging
        private void ResetMinCentroidDistIfNecessary()
        {
            if (IsLastIter)
            {
                CurrentMinCentroidDist = 0.0F;
            }
        }

        /// <summary>
        /// Merges cluster pairs based on the distance between their centroids.
        /// </summary>
        /// <remarks>
        /// Some small optimizations can be found in the computation of the pairwise centroid distances
        /// as opposed to the steps described in Pattern Recognition Principles.
        /// </remarks>
        private void MergeClustersWhereNecessary()
        {
            var pairsToMerge = CentroidPairsSortedAndFiltered();

            for (int i = 0; i < MaxMergePerIter && pairsToMerge.Any(); i++)
            {
                (uint, uint) pairWithMinDist = pairsToMerge.First();
                MergeClusterPair(pairWithMinDist);
                RemoveAlreadyMergedElementsFrom(pairsToMerge, pairWithMinDist);
            }
        }

        /// <summary>
        /// Gets the pair of identifiers of clusters, where the distances between their centroids is smaller than
        /// the predefined threshold. The identifiers are sorted based on the mentioned distance in ascending order.
        /// </summary>
        /// <returns>List of cluster identifier pairs.</returns>
        private List<(uint, uint)> CentroidPairsSortedAndFiltered()
        {
            var filteredDists = FilteredCentroidDists();
            return SortedPairsFromCentroidDists(filteredDists);
        }

        private List<(uint, uint, float)> FilteredCentroidDists()
        {
            List<(uint, uint, float)> dists = new List<(uint, uint, float)>();
            // lower triangle without main diagonal:
            for (int i = 0; i < _clusters.Count; i++)
            {
                for (int j = 0; j < _clusters.Count && j < i; j++)
                {
                    Centroid ctr1 = _clusters.ElementAt(i).Value.Centroid;
                    Centroid ctr2 = _clusters.ElementAt(j).Value.Centroid;
                    AddPairDistBelowThresholdTo(dists, ctr1, ctr2);
                }
            }
            return dists;
        }

        private void AddPairDistBelowThresholdTo(List<(uint, uint, float)> dists, Centroid ctr1, Centroid ctr2)
        {
            float dist = _distance.Calculate(ctr1.Values, ctr2.Values);
            if (dist <= CurrentMinCentroidDist)
            {
                dists.Add((ctr1.ID, ctr2.ID, dist));
            }
        }

        private List<(uint, uint)> SortedPairsFromCentroidDists(List<(uint, uint, float)> dists)
        {
            return dists.OrderBy(x => x.Item3)
                        .Select(x => (x.Item1, x.Item2))
                        .ToList();
        }
        
        /// <summary>
        /// Merges two clusters into one. The new cluster has the id of the first to-be-merged centroid,
        /// and a new centroid that is the weighted average of the original two centroids.
        /// The second to-be-merged cluster is removed.
        /// </summary>
        /// <param name="clusterIDsToMerge">The pair of cluster ids corresponding to the clusters to be merged.</param>
        private void MergeClusterPair((uint, uint) clusterIDsToMerge)
        {
            Cluster cl1 = _clusters[clusterIDsToMerge.Item1];
            Cluster cl2 = _clusters[clusterIDsToMerge.Item2];
            MergeClusters(cl1, cl2);
        }

        private void MergeClusters(Cluster cl1, Cluster cl2)
        {
            cl1.SetCentroidToWeightedAverageOf(cl1, cl2);
            _clusters.Remove(cl2.CentroidID);
        }

        /// <summary>
        /// Removes all pairs from the list that contain the id of the clusters that have already been merged.
        /// </summary>
        /// <param name="pairsToMerge">The list of cluster id pairs to be deleted from.</param>
        /// <param name="mergedPair">The pair of the two ids, each of which should not appear in any of the pairs in the list.</param>
        private void RemoveAlreadyMergedElementsFrom(List<(uint, uint)> pairsToMerge, (uint, uint) mergedPair)
        {
            for (int i = pairsToMerge.Count - 1; i >= 0; --i)
            {
                if (ContainsAtLeastOne(pairsToMerge[i], mergedPair))
                {
                    pairsToMerge.RemoveAt(i);
                }
            }
        }

        private bool ContainsAtLeastOne((uint, uint) container, (uint, uint) values)
        {
            uint value1 = values.Item1;
            uint value2 = values.Item2;
            return Contains(container, value1) || Contains(container, value2);
        }

        private bool Contains((uint, uint) container, uint val)
        {
            return (container.Item1 == val || container.Item2 == val);
        }
        #endregion
    }
}

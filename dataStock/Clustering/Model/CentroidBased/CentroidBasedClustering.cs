using System;
using System.Collections.Generic;
using System.Threading;
using Giwer.dataStock.Clustering.Model.Distance;
using Giwer.dataStock.Clustering.Model.Loader;

namespace Giwer.dataStock.Clustering.Model.CentroidBased
{
    public abstract partial class CentroidBasedClustering : AbstractAsyncClustering
    {
        #region Constants
        public const uint MaxIterMinVal = 1;
        public const uint MaxIterMaxVal = 100;
        public const uint MaxIterDefaultVal = 15;

        public const uint MaxClusterNumMinVal = 2;
        public const uint MaxClusterNumMaxVal = 256;
        public const uint MaxClusterNumDefaultVal = 256;
        #endregion

        #region Input parameters
        /// <summary>
        /// The maximum number of iterations that should take place during the execution of the clustering.
        /// </summary>
        public uint MaxIter { get; protected set; }
        /// <summary>
        /// The maximum number of clusters that may form during the clustering.
        /// </summary>
        public uint MaxClusterNum { get; protected set; }
        #endregion

        #region Members and properties
        protected Dictionary<uint, Cluster> _clusters;
        protected byte[][] _points;
        protected IDistance _distance;

        /// <summary>
        /// The current number of clusters.
        /// </summary>
        public override int ClusterNum => _clusters.Count;
        protected int PointDim { get; set; }

        private static uint _clusterIDGen = 0;
        private static readonly Random _random = new Random();

        /// <summary>
        /// The maximum number of steps that are tracked as progress.
        /// </summary>
        protected abstract int MaxStep { get; }
        #endregion

        #region Constructors
        protected CentroidBasedClustering(
            uint maxIter = MaxIterDefaultVal,
            uint maxClusterNum = MaxClusterNumDefaultVal)
        {
            if (maxIter < MaxIterMinVal || maxIter > MaxIterMaxVal)
                throw new ArgumentOutOfRangeException(nameof(maxIter), "Value is out of the predefined range.");

            if (maxClusterNum < MaxClusterNumMinVal || maxClusterNum > MaxClusterNumMaxVal)
                throw new ArgumentOutOfRangeException(nameof(maxClusterNum), "Value is out of the predefined range.");

            MaxIter = maxIter;
            MaxClusterNum = maxClusterNum;
            _distance = new SquaredEuclideanDistance();
        }
        #endregion

        #region Methods for the handling of execution
        protected override byte[] Execute(ImageLoader imageLoader)
        { 
            Progress.Report(ClusteringProgress.Initializing(MaxStep));
            LoadPoints(imageLoader);
            CancellationToken.ThrowIfCancellationRequested();
            return ExecuteBody();
        }

        /// <summary>
        /// Executes the main logic of the specific clustering algorithm.
        /// </summary>
        /// <returns>The corresponding cluster value (byte) of each input pixel.</returns>
        protected abstract byte[] ExecuteBody();
        #endregion

        #region Methods for loading the clusters
        private void LoadPoints(ImageLoader imageLoader)
        {
            _points = imageLoader.LoadJaggedPoints();
            PointDim = imageLoader.BandCount;
        }
        #endregion

        #region Methods used during clustering
        /// <summary>
        /// Initialize empty clusters with centroid values randomly generated from their domain.
        /// </summary>
        /// <param name="clusterCount">Number of clusters to initialize.</param>
        protected void InitEmptyClusters(uint clusterCount)
        {
            _clusters = new Dictionary<uint, Cluster>();
            for (uint i = 0; i < clusterCount; i++)
            {
                Centroid centroid = new Centroid(PointDim);
                centroid.FillWithRandomValues();
                _clusters.Add(centroid.ID, new Cluster(_points, _distance, centroid));
            }
        }

        /// <summary>
        /// Initialize clusters with pixel indexes of the loaded input image as centroids.
        /// </summary>
        /// <param name="samplePointIndexes">List of image indexes to determine cluster centrioids.</param>
        protected void InitManualClusters(List<int> samplePointIndexes)
        {
            _clusters = new Dictionary<uint, Cluster>();
            foreach (var ind in samplePointIndexes)
            {
                Centroid centroid = new Centroid(PointDim);
                byte[] sample = _points[ind];
                centroid.CopyValuesFrom(sample);
                _clusters.Add(centroid.ID, new Cluster(_points, _distance, centroid));
            }
        }

        /// <summary>
        /// Initialize clusters with centroids determined by means of image points.
        /// </summary>
        /// <param name="polysInPoints">List of List of image indexes. Each list contains image indexes, the means of these points will be the centroid ponits</param>
        protected void InitManualClustersPoly(List<List<int>> polysInPoints)
        {
            _clusters = new Dictionary<uint, Cluster>();
            System.Diagnostics.Debug.WriteLine("polysInPoints.Count: "+ polysInPoints.Count);
            foreach (List<int> poly in polysInPoints)
            {
                System.Diagnostics.Debug.WriteLine("poly.Count: " + poly.Count);
                Centroid centroid = new Centroid(PointDim);
                List<byte[]> points = new List<byte[]>();
                foreach (int p in poly)
                {
                    points.Add(_points[p]);
                }
                byte[] sample = ClusteringUtilities.MeanOf(points, PointDim);
                centroid.CopyValuesFrom(sample);
                _clusters.Add(centroid.ID, new Cluster(_points, _distance, centroid));
            }
        }

        /// <summary>
        /// Initialize empty clusters with centroid values randomly selected from the pixels of the loaded input image.
        /// </summary>
        /// <param name="clusterCount">Number of clusters to initialize.</param>
        protected void InitEmptyClustersFromRandomImagePoints(uint clusterCount)
        {
            _clusters = new Dictionary<uint, Cluster>();
            byte[][] randomPoints = Model.ClusteringUtilities.PickRandom(_random, _points, (int)clusterCount);
            for (uint i = 0; i < clusterCount; i++)
            {
                Centroid centroid = new Centroid(PointDim);
                centroid.CopyValuesFrom(randomPoints[(int)i]);
                _clusters.Add(centroid.ID, new Cluster(_points, _distance, centroid));
            } 
        }

        /// <summary>
        /// Removes all ("invalid") points from the clusters and reassigns them to their now corresponding cluster.
        /// </summary>
        /// <exception cref="NoClustersException">Thrown if the number of clusters is 0, so the points cannot be reassigned.</exception>
        /// <remarks>Some algorithms may produce 0 clusters during the execution, e.g. if the input parameters are </remarks>
        /// <seealso cref="AssignPointsToClusters"/>
        protected void ReassignPointsToClusters()
        {
            if (ClusterNum == 0) throw new NoClustersException("Cannot reassign points as there are 0 clusters.");
            ClearAllClusterPoints();
            AssignPointsToClusters();
        }

        /// <summary>
        /// Assigns all points to their corresponding cluster.
        /// </summary>
        /// <remarks>Does not clear the current assignment, should only be used when the points were not assigned beforehand.</remarks>
        /// <seealso cref="ReassignPointsToClusters"/>
        protected void AssignPointsToClusters()
        {
            for (uint pointInd = 0; pointInd < _points.Length; ++pointInd)
            {
                AddPointToClosestCluster(pointInd);
            }
        }

        private void ClearAllClusterPoints()
        {
            foreach (Cluster cluster in _clusters.Values)
            {
                cluster.ClearPoints();
            }
        }

        private void AddPointToClosestCluster(uint pointInd)
        {
            Centroid closestCentroid = ClosestCentroidTo(pointInd);
            _clusters[closestCentroid.ID].AddPoint(pointInd);
        }

        protected Centroid ClosestCentroidTo(uint pointInd)
        {
            System.Diagnostics.Debug.Assert(ClusterNum > 0);

            Centroid res = new Centroid(PointDim);
            float minDist = float.MaxValue;
            foreach (Cluster cluster in _clusters.Values)
            {
                Centroid centroid = cluster.Centroid;
                float dist = _distance.Calculate(centroid.Values, _points[pointInd]);
                if (dist < minDist)
                {
                    minDist = dist;
                    res = centroid;
                }
            }
            return res;
        }

        /// <summary>
        /// Sets each centroid to the mean of the points currently contained in their cluster.
        /// </summary>
        protected void UpdateCentroids()
        {
            foreach (Cluster cluster in _clusters.Values)
            {
                cluster.SetCentroidToMean();
            }
        }
        #endregion

        #region Methods for getting the results
        /// <summary>
        /// Converts the current cluster-point assignment to an array representation.
        /// </summary>
        /// <returns>The corresponding cluster value (equally distributed byte) of each input pixel.</returns>
        protected byte[] GetResultInByteArray()
        {
            byte[] res = new byte[_points.Length];
            if (ClusterNum > 1)
            {
                GetEquallyDistributedResultIn(res);
            }
            return res;
        }

        private void GetEquallyDistributedResultIn(byte[] result)
        {
            byte currentClusterVal = 0;
            byte clusterValStride = (byte)(byte.MaxValue / (ClusterNum - 1));

            foreach (Cluster cluster in _clusters.Values)
            {
                foreach (uint pointInd in cluster.PointIndices)
                {
                    result[pointInd] = currentClusterVal;
                }
                currentClusterVal += clusterValStride;
            }
        }
        #endregion

        #region Methods for evaluating results
        /// <summary>
        /// The sum of SSEs of each cluster.
        /// </summary>
        protected float TotalSSE()
        {
            float res = 0.0F;
            foreach (Cluster cluster in _clusters.Values)
            {
                res += cluster.SSE();
            }
            return res;
        }
        #endregion
    }
}

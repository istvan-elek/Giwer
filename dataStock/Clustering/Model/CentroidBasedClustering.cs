using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Giwer.dataStock.Clustering.Model
{
    public abstract partial class CentroidBasedClustering : IClustering
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

        #region Fields and properties
        protected Dictionary<uint, Cluster> _clusters;
        protected ImagePoint[] _points;

        /// <summary>
        /// The current number of clusters.
        /// </summary>
        public int ClusterNum => _clusters.Count;
        protected int PointDim { get; set; }

        private PointLoader _pointLoader;

        private static uint _clusterIDGen = 0;
        private static readonly Random _random = new Random();

        private CancellationTokenSource _cancTokenSource;
        protected CancellationToken CancellationToken { get; private set; }
        #endregion

        #region Constructors
        protected CentroidBasedClustering(GeoImageData gImgData, int[] includedBands, uint maxIter, uint maxClusterNum) 
            : this(maxIter, maxClusterNum)
        {
            if (includedBands.Length == 0 || includedBands.Length > gImgData.Nbands)
                throw new ArgumentOutOfRangeException(nameof(includedBands), "Array length out of range predefined by the GeoImageData.");

            _pointLoader = new GeoImageDataPointLoader(gImgData, includedBands);
        }

        protected CentroidBasedClustering(byte[] band, uint maxIter, uint maxClusterNum) 
            : this(maxIter, maxClusterNum)
        {
            _pointLoader = new OneBandPointLoader(band);
        }

        private CentroidBasedClustering(uint maxIter, uint maxClusterNum)
        {
            if (maxIter < MaxIterMinVal || maxIter > MaxIterMaxVal)
                throw new ArgumentOutOfRangeException(nameof(maxIter), "Value is out of the predefined range.");

            if (maxClusterNum < MaxClusterNumMinVal || maxClusterNum > MaxClusterNumMaxVal)
                throw new ArgumentOutOfRangeException(nameof(maxClusterNum), "Value is out of the predefined range.");

            MaxIter = maxIter;
            MaxClusterNum = maxClusterNum;
        }
        #endregion

        #region Methods for the handling of execution
        public event EventHandler<ClusteringStartedEventArgs> ExecutionStarted;
        public event EventHandler<ClusteringProgressEventArgs> ExecutionProgressUpdated;

        protected void OnExecutionStarted()
        {
            IsInProgress = true;
            ExecutionStarted?.Invoke(this, new ClusteringStartedEventArgs(MaxIter));
        }

        protected void OnExecutionProgressUpdated(uint currentIter)
        {
            ExecutionProgressUpdated?.Invoke(this, new ClusteringProgressEventArgs(currentIter));
        }

        /// <summary>
        /// Describes whether the main execution task is currently running.
        /// </summary>
        public bool IsInProgress { get; protected set; }

        public async Task<byte[]> ExecuteAsync()
        {
            _cancTokenSource = new CancellationTokenSource();
            CancellationToken = _cancTokenSource.Token;

            var executionTask = Task.Run(() =>
            {
                try
                {
                    OnExecutionStarted();
                    LoadPoints();
                    CancellationToken.ThrowIfCancellationRequested();
                    return Execute();
                }
                finally
                {
                    IsInProgress = false;
                }
            }, CancellationToken);
            return await executionTask;
        }

        /// <summary>
        /// Executes the main logic of the specific clustering algorithm.
        /// </summary>
        /// <returns>The corresponding cluster value (byte) of each input pixel.</returns>
        protected abstract byte[] Execute();

        /// <summary>
        /// Requests the cancellation of the whole async clustering execution task.
        /// </summary>
        public void CancelExecution()
        {
            if (IsInProgress)
            { 
                _cancTokenSource.Cancel();
            }
        }
        #endregion

        #region Methods for loading the clusters
        protected void LoadPoints()
        {
            _points = _pointLoader.LoadPoints();
            PointDim = _pointLoader.PointDim;
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
                CentroidPoint centroid = new CentroidPoint(PointDim);
                centroid.FillWithRandomValues();
                _clusters.Add(centroid.ID, new Cluster(centroid));
            }
        }

        /// <summary>
        /// Initialize empty clusters with centroid values randomly selected from the pixels of the loaded input image.
        /// </summary>
        /// <param name="clusterCount">Number of clusters to initialize.</param>
        protected void InitEmptyClustersFromRandomImagePoints(uint clusterCount)
        {
            _clusters = new Dictionary<uint, Cluster>();
            List<Point> randomPoints = PickRandomImagePoints(_random, (int)clusterCount);
            for (uint i = 0; i < clusterCount; i++)
            {
                CentroidPoint centroid = new CentroidPoint(PointDim);
                centroid.CopyValuesFrom(randomPoints[(int)i]);
                _clusters.Add(centroid.ID, new Cluster(centroid));
            } 
        }

        private List<Point> PickRandomImagePoints(Random rand, int numberOfPicks) // based on Richard Durstenfeld's Fisher-Yates shuffle 
        {
            List<Point> selected = new List<Point>();

            int pointCount = _points.Length;
            var availableKeys = Enumerable.Range(0, pointCount).ToList();
            int maxKeyInd = pointCount - 1;
            int picksRemaining = Math.Min(numberOfPicks, pointCount);
            while (picksRemaining > 0)
            {
                int randKeyInd = rand.Next(0, maxKeyInd);
                int randInd = availableKeys[randKeyInd];
                availableKeys[randKeyInd] = availableKeys[maxKeyInd];
                selected.Add(_points[randInd]);
                maxKeyInd--;
                picksRemaining--;
            }

            return selected;
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
            foreach (ImagePoint point in _points)
            {
                AddPointToClosestCluster(point);
            }
        }

        private void ClearAllClusterPoints()
        {
            foreach (Cluster cluster in _clusters.Values)
            {
                cluster.ClearPoints();
            }
        }

        private void AddPointToClosestCluster(ImagePoint point)
        {
            CentroidPoint closestCentroid = ClosestCentroidTo(point);
            _clusters[closestCentroid.ID].AddPoint(point);
        }

        protected CentroidPoint ClosestCentroidTo(Point point)
        {
            System.Diagnostics.Debug.Assert(ClusterNum > 0);

            CentroidPoint res = new CentroidPoint(PointDim);
            float minDist = float.MaxValue;
            foreach (Cluster cluster in _clusters.Values)
            {
                CentroidPoint centroid = cluster.Centroid;
                float dist = Point.SquaredEuclDist(centroid, point);
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

        private byte[] GetEquallyDistributedResultIn(byte[] result)
        {
            byte currentClusterVal = 0;
            byte clusterValStride = (byte)(byte.MaxValue / (ClusterNum - 1));

            foreach (Cluster cluster in _clusters.Values)
            {
                foreach (ImagePoint point in cluster)
                {
                    result[point.Index] = currentClusterVal;
                }
                currentClusterVal += clusterValStride;
            }

            return result;
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

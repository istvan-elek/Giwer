using Giwer.dataStock.Clustering.Model.Loader;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Giwer.dataStock.Clustering.Model.Supervised.RandomForest
{
    public class RandomForestTrainer : ISupervisedTrainer
    {
        #region Constants
        public const int TreeCountMinVal = 1;
        public const int TreeCountMaxVal = 1_000;
        public const int TreeCountDefaultVal = 100;

        public const int BandCountPerSplitMinVal = 0;
        public const int BandCountPerSplitMaxVal = 256;
        public const int BandCountPerSplitDefaultVal = 0;

        public const int MaxTreeHeightMinVal = 2;
        public const int MaxTreeHeightMaxVal = 10_000;
        public const int MaxTreeHeightDefaultVal = 2_000;

        public const int MinNodeSizeMinVal = 1;
        public const int MinNodeSizeMaxVal = 1_000;
        public const int MinNodeSizeDefaultVal = 1;

        public const float BootstrappingRatioMinVal = 0.01F;
        public const float BootstrappingRatioMaxVal = 2.0F;
        public const float BootstrappingRatioDefaultVal = 1.0F;

        public const bool IsParallelDefaultVal = true;
        #endregion

        #region Input parameters
        /// <summary>
        /// The number of decision trees in the forest.
        /// </summary>
        public int TreeCount { get; private set; }
        /// <summary>
        /// Number of bands to use in each tree in each split. When set to zero, sqrt(total number of features) will be used.
        /// </summary>
        public int BandCountPerSplit { get; private set; }
        /// <summary>
        /// Maximum height of each tree in the forest.
        /// </summary>
        public int MaxTreeHeight { get; private set; }
        /// <summary>
        /// Minimum size of the nodes in each tree. 
        /// </summary>
        public int MinNodeSize { get; private set; }
        /// <summary>
        /// The ratio of observations bootstrapped (sampled with replacement) for each tree.  
        /// </summary>
        public float BootstrappingRatio { get; private set; }
        /// <summary>
        /// The value that determines whether the training runs in parallel or not. Parallel execution is usually faster but requires more memory.
        /// </summary>
        public bool IsParallel { get; private set; }
        #endregion

        #region Members
        private Random _random;
        private IProgress<ClusteringProgress> _progress;
        private CancellationToken _cancellationToken;
        #endregion

        #region Constructors
        public RandomForestTrainer(
            int treeCount = TreeCountDefaultVal,
            int bandCountPerSplit = BandCountPerSplitDefaultVal,
            int maxTreeHeight = MaxTreeHeightDefaultVal,
            int minNodeSize = MinNodeSizeDefaultVal,
            float bootstrappingRatio = BootstrappingRatioDefaultVal,
            bool isParallel = IsParallelDefaultVal)
        {
            if (treeCount < TreeCountMinVal || treeCount > TreeCountMaxVal)
                throw new ArgumentOutOfRangeException(nameof(treeCount), "Value is out of the predefined range.");

            if (bandCountPerSplit < BandCountPerSplitMinVal || bandCountPerSplit > BandCountPerSplitMaxVal)
                throw new ArgumentOutOfRangeException(nameof(bandCountPerSplit), "Value is out of the predefined range.");

            if (maxTreeHeight < MaxTreeHeightMinVal || maxTreeHeight > MaxTreeHeightMaxVal)
                throw new ArgumentOutOfRangeException(nameof(maxTreeHeight), "Value is out of the predefined range.");

            if (minNodeSize < MinNodeSizeMinVal || minNodeSize > MinNodeSizeMaxVal)
                throw new ArgumentOutOfRangeException(nameof(minNodeSize), "Value is out of the predefined range.");

            if (bootstrappingRatio < BootstrappingRatioMinVal || bootstrappingRatio > BootstrappingRatioMaxVal)
                throw new ArgumentOutOfRangeException(nameof(bootstrappingRatio), "Value is out of the predefined range.");

            TreeCount = treeCount;
            BandCountPerSplit = bandCountPerSplit;
            MaxTreeHeight = maxTreeHeight;
            MinNodeSize = minNodeSize;
            BootstrappingRatio = bootstrappingRatio;
            IsParallel = isParallel;

            _random = new Random();
        }
        #endregion

        #region Methods related to the training procedure
        public async Task<ISupervisedModel> TrainAsync(GeoImageData image, int[] includedBands, GeoImageData clustering, int clusteringBand,
                                                        IProgress<ClusteringProgress> progress, CancellationToken cancellationToken)
        {
            _progress = progress;
            _cancellationToken = cancellationToken;
            return await Task.Run(() => Train(image, includedBands, clustering, clusteringBand));
        }

        private RandomForestModel Train(GeoImageData image, int[] includedBands, GeoImageData clustering, int clusteringBand)
        {
            ValidateInputImages(image, clustering);
            HandleBandCountPerSplitValue(includedBands.Length);

            _progress.Report(ClusteringProgress.Initializing(TreeCount));

            var imageLoader = new GeoImageLoader(image, includedBands);
            byte[][] points = imageLoader.LoadJaggedBands();

            var targetLoader = new GeoImageLoader(clustering, clusteringBand);
            byte[] targets = targetLoader.LoadPoints(); //RandomForestUtilities.LoadPoints(clustering, clusteringBand);

            return TrainForestModel(points, targets, includedBands.Length);
        }

        private void ValidateInputImages(GeoImageData image, GeoImageData clustering)
        {
            int imagePixelCount = image.Ncols * image.Nrows;
            int clusteringPixelCount = clustering.Ncols * clustering.Nrows;

            if (imagePixelCount != clusteringPixelCount)
                throw new ArgumentException("The pixel counts of the input image and the clustering do not match.");
        }

        private void HandleBandCountPerSplitValue(int totalBandCount)
        {
            ValidateBandCountPerSplit(totalBandCount);
            SetBandCountPerSplitToDefault(totalBandCount);
        }

        private void ValidateBandCountPerSplit(int totalBandCount)
        {
            if (BandCountPerSplit > totalBandCount)
                throw new ArgumentException("The number of bands used in each split can't be more than the total number of included bands.");
        }

        private void SetBandCountPerSplitToDefault(int totalBandCount)
        {
            if (BandCountPerSplit == 0)
            {
                BandCountPerSplit = (int)Math.Sqrt(totalBandCount);
            }
        }

        private RandomForestModel TrainForestModel(byte[][] points, byte[] targets, int bandCount)
        {
            if (IsParallel)
            {
                return GetModelInParallel(points, targets, bandCount);
            }
            else
            {
                return GetModel(points, targets, bandCount);
            }
        }

        private RandomForestModel GetModelInParallel(byte[][] points, byte[] targets, int bandCount)
        {
            Random[] randoms = GetDifferentRandoms();
            TreeModel[] treeModels = GetTreeModelsInParallel(points, targets, randoms);

            return new RandomForestModel(treeModels, bandCount);
        }

        private Random[] GetDifferentRandoms()
        {
            Random[] randoms = new Random[TreeCount];
            for (int i = 0; i < TreeCount; ++i)
            {
                randoms[i] = new Random(_random.Next());
            }
            return randoms;
        }

        private TreeModel[] GetTreeModelsInParallel(byte[][] points, byte[] targets, Random[] randoms)
        {
            TreeModel[] treeModels = new TreeModel[TreeCount];

            int treesTrainedCount = 0;
            var rangePartitioner = Partitioner.Create(0, TreeCount);

            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken = _cancellationToken;

            Parallel.ForEach(rangePartitioner, parallelOptions, range =>
            {
                for (int i = range.Item1; i < range.Item2; ++i)
                {
                    TreeTrainer trainer = new TreeTrainer(BandCountPerSplit, MaxTreeHeight, MinNodeSize, BootstrappingRatio, randoms[i]);
                    treeModels[i] = trainer.Train(points, targets, _cancellationToken);

                    Interlocked.Increment(ref treesTrainedCount);
                    _progress.Report(ClusteringProgress.StepTaken(treesTrainedCount));
                    parallelOptions.CancellationToken.ThrowIfCancellationRequested();
                }
            });

            return treeModels;
        }

        private RandomForestModel GetModel(byte[][] points, byte[] targets, int bandCount)
        {
            TreeModel[] treeModels = new TreeModel[TreeCount];

            TreeTrainer trainer = new TreeTrainer(BandCountPerSplit, MaxTreeHeight, MinNodeSize, BootstrappingRatio, new Random(_random.Next()));
            for (int i = 0; i < TreeCount; ++i)
            {
                treeModels[i] = trainer.Train(points, targets, _cancellationToken);

                _progress.Report(ClusteringProgress.StepTaken(i + 1));
            }

            return new RandomForestModel(treeModels, bandCount);
        }
        #endregion
    }
}

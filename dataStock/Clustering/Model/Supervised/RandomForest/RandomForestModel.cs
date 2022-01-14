using System;
using System.Collections.Concurrent;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;

namespace Giwer.dataStock.Clustering.Model.Supervised.RandomForest
{
    [Serializable]
    public class RandomForestModel : ISupervisedModel
    {
        private TreeModel[] _treeModels;

        [NonSerialized]
        private int _majorityCount;

        public int BandCount { get; private set; }

        public bool IsEmpty { get { return _treeModels == null || _treeModels.Length == 0; } }

        public static RandomForestModel EmptyModel()
        {
            return new RandomForestModel();
        }

        public RandomForestModel(TreeModel[] treeModels, int bandCount)
        {
            _treeModels = treeModels;
            BandCount = bandCount;

            SetMajorityCount();
        }

        private RandomForestModel()
        {
        }

        private void SetMajorityCount()
        {
            _majorityCount = _treeModels.Length / 2 + 1;
        }

        public byte[] Predict(byte[][] points, IProgress<ClusteringProgress> progress, CancellationToken cancellationToken)
        {
            if (IsEmpty)
            {
                return new byte[points.Length];
            }
            else
            {
                return PredictPoints(points, progress, cancellationToken);
            }
        }

        private byte[] PredictPoints(byte[][] points, IProgress<ClusteringProgress> progress, CancellationToken cancellationToken)
        {
            byte[] result = new byte[points.Length];

            int pointsPredictedCount = 0;
            int lastPercentage = 0;
            var rangePartitioner = Partitioner.Create(0, points.Length);

            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken = cancellationToken;

            Parallel.ForEach(rangePartitioner, parallelOptions, range =>
            {
                for (int i = range.Item1; i < range.Item2; ++i)
                {
                    result[i] = Predict(points[i]);

                    parallelOptions.CancellationToken.ThrowIfCancellationRequested();

                    Interlocked.Increment(ref pointsPredictedCount);
                    int percentage = (int)((float)pointsPredictedCount / points.Length * 100.0F);
                    if (percentage > lastPercentage)
                    {
                        Interlocked.Increment(ref lastPercentage);
                        progress.Report(ClusteringProgress.StepTaken(percentage));
                    }
                }
            });
            return result;
        }

        private byte Predict(byte[] point)
        {
            // TODO: could be byte[] if the number of trees was always less than 255
            int[] predictionCounts = new int[byte.MaxValue + 1];
            byte majorityPrediction = 0;
            int maxCount = 0;
            for (int i = 0; i < _treeModels.Length && maxCount < _majorityCount; ++i)
            {
                byte prediction = _treeModels[i].Predict(point);
                if (++predictionCounts[prediction] > maxCount)
                {
                    majorityPrediction = prediction;
                    maxCount = predictionCounts[prediction];
                }
            }

            return majorityPrediction;
        }


        public async Task SaveAsync(string fileName)
        {
            await Task.Run(() => Save(fileName));
        }

        public async Task LoadAsync(string fileName)
        {
            await Task.Run(() => Load(fileName));
        }

        private void Save(string fileName)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, this);
            }
        }

        private void Load(string fileName)
        {
            RandomForestModel loadedModel;

            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                loadedModel = (RandomForestModel)formatter.Deserialize(stream);
            }

            _treeModels = loadedModel._treeModels;
            BandCount = loadedModel.BandCount;
            SetMajorityCount();
        }
    }
}

namespace Giwer.dataStock.Clustering.Model
{
    public struct ClusteringProgress
    {
        public static ClusteringProgress Initializing(int maxValue)
        {
            return new ClusteringProgress(0, maxValue);
        }

        public static ClusteringProgress StepTaken(int value)
        {
            return new ClusteringProgress(value, 0);
        }

        public static ClusteringProgress Unbounded()
        {
            return new ClusteringProgress(-1, -1);
        }

        public int Value { get; private set; }
        public int MaxValue { get; private set; }

        public bool IsInitializing { get { return Value == 0; } }
        public bool IsUnbounded { get { return MaxValue == -1; } }

        private ClusteringProgress(int value, int maxValue)
        {
            Value = value;
            MaxValue = maxValue;
        }
    }
}

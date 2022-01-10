using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Giwer.dataStock.Clustering.Model.Supervised.RandomForest
{
    public class TreeTrainer
    {
        #region Parameters
        private int _bandCountPerSplit;
        private int _maxTreeHeight;
        private int _minNodeSize;
        private float _bootstrappingRatio;

        private byte[][] _points;
        private byte[] _targets;
        #endregion

        #region Properties and members
        private int BandCount { get { return _points.Length; } }

        private TreeBuilder _treeBuilder;

        private byte[] _distinctTargets;
        private int[] _currentIndices;
        private int[] _bestIndices;

        private int[] _targetCounts;
        private int[] _leftTargetCounts;
        private int[] _rightTargetCounts;

        // TODO: bucket sort vs. built in introsort?
        //private byte[] _currentBand;
        private List<int>[] _buckets;

        private Random _random;
        private CancellationToken _cancellationToken;
        #endregion

        #region Types
        private struct Interval
        {
            public int From { get; private set; }
            public int To { get; private set; }
            public int Length { get; private set; }

            public Interval(int from, int to)
            {
                From = from;
                To = to;
                Length = To - From;
            }
        }

        private struct NodeData
        {
            public TreeNode.Child Type { get; private set; }
            public int ParentIndex { get; private set; }
            public Interval ParentInterval { get; private set; }
            public int Height { get; private set; }

            public NodeData(TreeNode.Child type, int parentIndex, Interval parentInterval, int height)
            {
                Type = type;
                ParentIndex = parentIndex;
                ParentInterval = parentInterval;
                Height = height;
            }
        }
        #endregion

        #region Constructors
        public TreeTrainer(int bandCountPerSplit, int maxTreeHeight, int minNodeSize, float bootstrappingRatio,
                           Random random)
        {
            _bandCountPerSplit = bandCountPerSplit;
            _maxTreeHeight = maxTreeHeight;
            _minNodeSize = minNodeSize;
            _bootstrappingRatio = bootstrappingRatio;

            _random = random;
        }
        #endregion

        #region Methods responsible for the main training procedure
        public TreeModel Train(byte[][] points, byte[] targets, CancellationToken cancellationToken)
        {
            _targets = targets;
            _points = points;
            _cancellationToken = cancellationToken;

            int pointCount = _targets.Length;
            int bootstrapPointCount = (int)(pointCount * _bootstrappingRatio);

            InitMembers(bootstrapPointCount);

            BootstrapAggregateIndices(pointCount, bootstrapPointCount);

            return GetNodes();
        }

        private void InitMembers(int bootstrapPointCount)
        {
            _treeBuilder = new TreeBuilder();

            _distinctTargets = _targets.Distinct().ToArray();
            byte maxTarget = _distinctTargets.Max();
            _targetCounts = new int[maxTarget + 1];
            _leftTargetCounts = new int[maxTarget + 1];
            _rightTargetCounts = new int[maxTarget + 1];

            InitSortingBuckets();
            //InitSortingBand(bootstrapPointCount);

            _bestIndices = new int[bootstrapPointCount];
        }

        private void InitSortingBuckets()
        {
            _buckets = new List<int>[byte.MaxValue + 1];

            for (int i = 0; i < _buckets.Length; i++)
            {
                _buckets[i] = new List<int>();
            }
        }

        /*private void InitSortingBand(int count)
        {
            _currentBand = new byte[count];
        }*/

        private void BootstrapAggregateIndices(int pointCount, int bootstrapPointCount)
        {
            _currentIndices = ClusteringUtilities.PickFromRangeWithReplacement(_random, 0, pointCount, bootstrapPointCount);
        }

        private TreeModel GetNodes()
        {
            Stack<NodeData> nodes = new Stack<NodeData>();
            NodeData node = new NodeData(TreeNode.Child.NONE, 0, new Interval(0, _currentIndices.Length), 0);
            nodes.Push(node);

            while (nodes.Count > 0)
            {
                _cancellationToken.ThrowIfCancellationRequested();

                node = nodes.Pop();

                if (node.Height > _maxTreeHeight)
                {
                    _treeBuilder.SetAsLeaf(node.ParentIndex);
                }
                else
                {
                    (byte value, int band, int splitRightMostInd) = GetNodeValues(node.ParentInterval);

                    if (band == -1)
                    {
                        _treeBuilder.AddLeaf(value, band, node.ParentIndex, node.Type);
                    }
                    else
                    {
                        int currentInd = _treeBuilder.AddNode(value, band, node.ParentIndex, node.Type);

                        nodes.Push(new NodeData(TreeNode.Child.RIGHT, currentInd, new Interval(splitRightMostInd + 1, node.ParentInterval.To), node.Height + 1));
                        nodes.Push(new NodeData(TreeNode.Child.LEFT, currentInd, new Interval(node.ParentInterval.From, splitRightMostInd + 1), node.Height + 1));
                    }
                }
            }

            return _treeBuilder.GetResult();
        }
        #endregion

        #region Methods for getting the values of the current node
        // returns the feature and value of the node and the rightmost index corresponding the left child node in the sorted band, if the feature is -1 then it is a leaf node
        private (byte, int, int) GetNodeValues(Interval intv)
        {
            int[] usedBands = ClusteringUtilities.PickFromRangeWithoutReplacement(_random, 0, BandCount, _bandCountPerSplit);
            (int band, int rightMostInd) = GetBestSplit(intv, usedBands);

            if (band == -1) // could not split the node, it is a leaf
                return (GetMaxCountTarget(), -1, -1);
            else
                return (_points[band][_currentIndices[rightMostInd]], band, rightMostInd);
        }

        private byte GetMaxCountTarget()
        {
            int maxCount = 0;
            byte maxTarget = 0;
            foreach (byte target in _distinctTargets)
            {
                if (_targetCounts[target] > maxCount)
                {
                    maxCount = _targetCounts[target];
                    maxTarget = target;
                }
            }
            return maxTarget;
        }
        #endregion

        #region Methods for getting the best split for the current points
        private (int, int) GetBestSplit(Interval intv, int[] bandInds)
        {
            GetTargetCounts(intv);

            if (AreAllTargetsTheSame())
                return (-1, -1);

            float minGini = 1.0F;
            int minInd = -1;
            int minBand = -1;

            foreach (int bandInd in bandInds)
            {
                float bandMinGini = minGini;
                int bandMinInd = minInd;

                SortCurrentIndicesWith(intv, bandInd);
                ResetSplitTargetCounts();

                int skipped = SkipSmallSplits(intv);

                int splitRightMostInd = intv.From + skipped;
                byte prevVal = _points[bandInd][_currentIndices[splitRightMostInd]];
                int to = intv.To - _minNodeSize;
                for (; splitRightMostInd < to; ++splitRightMostInd)
                {
                    _leftTargetCounts[_targets[_currentIndices[splitRightMostInd]]]++;
                    _rightTargetCounts[_targets[_currentIndices[splitRightMostInd]]]--;

                    byte nextVal = _points[bandInd][_currentIndices[splitRightMostInd + 1]];
                    if (prevVal != nextVal)
                    {
                        prevVal = nextVal;

                        int leftTotalCount = splitRightMostInd - intv.From + 1;
                        int rightTotalCount = intv.Length - leftTotalCount;
                        float gini = GiniImpurityOfCurrentSplit(leftTotalCount, rightTotalCount);

                        if (gini < bandMinGini)
                        {
                            bandMinGini = gini;
                            bandMinInd = splitRightMostInd;
                        }
                    }
                }
                if (bandMinGini < minGini)
                {
                    minGini = bandMinGini;
                    minBand = bandInd;
                    minInd = bandMinInd;
                    Array.Copy(_currentIndices, intv.From, _bestIndices, intv.From, intv.Length);
                }
            }

            Array.Copy(_bestIndices, intv.From, _currentIndices, intv.From, intv.Length);
            return (minBand, minInd);
        }

        private void GetTargetCounts(Interval intv)
        {
            Array.Clear(_targetCounts, 0, _targetCounts.Length);
            for (int i = intv.From; i < intv.To; ++i)
            {
                byte ind = _targets[_currentIndices[i]];
                _targetCounts[ind]++;
            }
        }

        private bool AreAllTargetsTheSame()
        {
            int numberOfDifferentTargets = 0;
            foreach (byte target in _distinctTargets)
            {
                if (_targetCounts[target] != 0)
                {
                    numberOfDifferentTargets++;
                    if (numberOfDifferentTargets > 1)
                        return false;
                }
            }
            return true;
        }

        // sort the current indices (limited by the interval) based on their corresponding point values
        private void SortCurrentIndicesWith(Interval intv, int bandInd)
        {
            //IndexedCopyOfInterval(_currentIndices, _points[bandInd], intv, _currentBand);
            //Array.Sort(_currentBand, _currentIndices, intv.From, intv.Length);
            BucketSortIndices(intv, bandInd);
        }

        private void IndexedCopyOfInterval(int[] indices, byte[] source, Interval interval, byte[] destination)
        {
            for (int i = interval.From; i < interval.To; i++)
            {
                int index = indices[i];
                destination[i] = source[index];
            }
        }

        private void BucketSortIndices(Interval intv, int band)
        {
            for (int i = 0; i < _buckets.Length; i++)
            {
                _buckets[i].Clear();
            }

            for (int i = intv.From; i < intv.To; i++)
            {
                _buckets[_points[band][_currentIndices[i]]].Add(_currentIndices[i]);
            }

            int k = intv.From;
            for (int i = 0; i < _buckets.Length; i++)
            {
                for (int j = 0; j < _buckets[i].Count; j++)
                {
                    _currentIndices[k] = _buckets[i][j];
                    k++;
                }
            }
        }

        private void ResetSplitTargetCounts()
        {
            Array.Clear(_leftTargetCounts, 0, _leftTargetCounts.Length);
            Array.Copy(_targetCounts, _rightTargetCounts, _targetCounts.Length);
        }

        private int SkipSmallSplits(Interval intv)
        {
            int skipCount = _minNodeSize - 1;
            for (int i = intv.From; i < intv.From + skipCount; ++i)
            {
                _leftTargetCounts[_targets[_currentIndices[i]]]++;
                _rightTargetCounts[_targets[_currentIndices[i]]]--;
            }
            return skipCount;
        }

        private float GiniImpurityOfCurrentSplit(int leftTotalCount, int rightTotalCount)
        {
            float leftGini = GiniImpurity(_leftTargetCounts, leftTotalCount);
            float rightGini = GiniImpurity(_rightTargetCounts, rightTotalCount);

            int totalTargetCount = leftTotalCount + rightTotalCount;
            float weightedSum = (leftTotalCount * leftGini + rightTotalCount * rightGini) / totalTargetCount;
            return weightedSum;
        }

        private float GiniImpurity(int[] targetCounts, int totalTargetCount)
        {
            float targetSqSum = 0.0F;
            foreach (var target in _distinctTargets)
            {
                targetSqSum += targetCounts[target] * targetCounts[target];
            }
            return 1.0F - (targetSqSum / (totalTargetCount * totalTargetCount));
        }
        #endregion
    }
}

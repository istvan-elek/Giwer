using System;

namespace Giwer.dataStock.Clustering.Model.Supervised.RandomForest
{
    [Serializable]
    public struct TreeNode
    {
        public enum Child { LEFT, RIGHT, NONE };

        public byte Value { get; private set; }
        public int Feature { get; private set; }
        public int LeftChild { get; private set; }
        public int RightChild { get; private set; }

        public TreeNode(byte value, int feature, int left, int right)
        {
            Value = value;
            Feature = feature;
            LeftChild = left;
            RightChild = right;
        }

        public bool IsLeaf { get { return !HasLeftChild && !HasRightChild; } }
        public bool HasLeftChild { get { return LeftChild != 0; } }
        public bool HasRightChild { get { return RightChild != 0; } }

    }
}

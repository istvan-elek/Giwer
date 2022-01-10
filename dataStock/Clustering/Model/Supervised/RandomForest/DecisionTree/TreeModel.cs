using System;
using System.Collections.Generic;

namespace Giwer.dataStock.Clustering.Model.Supervised.RandomForest
{
    [Serializable]
    public class TreeModel
    {
        private TreeNode[] _tree;

        public TreeModel(List<TreeNode> tree)
        {
            _tree = tree.ToArray();
        }

        public byte Predict(byte[] point)
        {
            TreeNode node = _tree[0];

            while (!node.IsLeaf)
            {
                if (point[node.Feature] <= node.Value)
                {
                    node = _tree[node.LeftChild];
                }
                else
                {
                    node = _tree[node.RightChild];
                }
            }

            return node.Value;
        }
    }
}


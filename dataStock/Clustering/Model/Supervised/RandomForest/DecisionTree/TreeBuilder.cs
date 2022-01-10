using System.Collections.Generic;

namespace Giwer.dataStock.Clustering.Model.Supervised.RandomForest
{
    public class TreeBuilder
    {
        private List<TreeNode> _tree;

        public TreeBuilder()
        {
            _tree = new List<TreeNode>();
        }

        public TreeModel GetResult()
        {
            return new TreeModel(_tree);
        }

        public void SetAsLeaf(int parentIndex)
        {
            TreeNode parent = _tree[parentIndex];
            if (!parent.IsLeaf)
                _tree[parentIndex] = new TreeNode(parent.Value, parent.Feature, 0, 0);
        }

        public void AddLeaf(byte value, int feature, int parentIndex, TreeNode.Child type)
        {
            Add(value, feature, 0, 0, parentIndex, type);
        }

        public int AddNode(byte value, int feature, int parentIndex, TreeNode.Child type)
        {
            return Add(value, feature, -1, -1, parentIndex, type);
        }

        private int Add(byte value, int feature, int left, int right, int parentIndex, TreeNode.Child type)
        {
            int currentInd = _tree.Count;
            _tree.Add(new TreeNode(value, feature, left, right));
            UpdateParent(parentIndex, type, currentInd);
            return currentInd;
        }

        private void UpdateParent(int parentIndex, TreeNode.Child type, int newIndex)
        {
            TreeNode parent = _tree[parentIndex];
            switch (type)
            {
                case TreeNode.Child.LEFT: _tree[parentIndex] = new TreeNode(parent.Value, parent.Feature, newIndex, parent.RightChild); break;
                case TreeNode.Child.RIGHT: _tree[parentIndex] = new TreeNode(parent.Value, parent.Feature, parent.LeftChild, newIndex); break;
            }
        }
    }
}

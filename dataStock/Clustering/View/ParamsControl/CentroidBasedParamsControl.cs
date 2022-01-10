namespace Giwer.dataStock.Clustering.View
{
    public partial class CentroidBasedParamsControl : ClusteringParamsControl
    {
        public override bool IsFilled { get { return true; } }

        public CentroidBasedParamsControl()
        {
            InitializeComponent();
            InitInputValues();
        }

        private void InitInputValues()
        {
            numMaxIter.Minimum = Model.CentroidBased.CentroidBasedClustering.MaxIterMinVal;
            numMaxIter.Maximum = Model.CentroidBased.CentroidBasedClustering.MaxIterMaxVal;
            numMaxIter.Value = Model.CentroidBased.CentroidBasedClustering.MaxIterDefaultVal;

            numMaxClust.Minimum = Model.CentroidBased.CentroidBasedClustering.MaxClusterNumMinVal;
            numMaxClust.Maximum = Model.CentroidBased.CentroidBasedClustering.MaxClusterNumMaxVal;
            numMaxClust.Value = Model.CentroidBased.CentroidBasedClustering.MaxClusterNumDefaultVal;
        }

        public uint MaxIter { get { return (uint)numMaxIter.Value; } }

        public uint MaxClust { get { return (uint)numMaxClust.Value; } }

    }
}

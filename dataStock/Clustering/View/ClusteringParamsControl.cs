using System.Windows.Forms;

namespace Giwer.dataStock.Clustering.View
{
    public partial class ClusteringParamsControl : UserControl
    {
        public ClusteringParamsControl()
        {
            InitializeComponent();
            InitInputValues();
        }

        private void InitInputValues()
        {
            numMaxIter.Minimum = Model.CentroidBasedClustering.MaxIterMinVal;
            numMaxIter.Maximum = Model.CentroidBasedClustering.MaxIterMaxVal;
            numMaxIter.Value = Model.CentroidBasedClustering.MaxIterDefaultVal;

            numMaxClust.Minimum = Model.CentroidBasedClustering.MaxClusterNumMinVal;
            numMaxClust.Maximum = Model.CentroidBasedClustering.MaxClusterNumMaxVal;
            numMaxClust.Value = Model.CentroidBasedClustering.MaxClusterNumDefaultVal;
        }

        public uint MaxIter { get { return (uint)numMaxIter.Value; } }

        public uint MaxClust { get { return (uint)numMaxClust.Value; } }

    }
}

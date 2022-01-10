namespace Giwer.dataStock.Clustering.View
{
    public partial class IsodataParamsControl : ClusteringParamsControl
    {
        public IsodataParamsControl()
        {
            InitializeComponent();
            InitInputValues();
        }

        private void InitInputValues()
        {
            numInitClusterNum.Minimum = Model.IsodataClustering.InitClusterNumMinVal;
            numInitClusterNum.Maximum = Model.IsodataClustering.InitClusterNumMaxVal;
            numInitClusterNum.Value = Model.IsodataClustering.InitClusterNumDefaultVal;

            numMinClusterSize.Minimum = Model.IsodataClustering.MinClusterSizeMinVal;
            numMinClusterSize.Maximum = Model.IsodataClustering.MinClusterSizeMaxVal;
            numMinClusterSize.Value = Model.IsodataClustering.MinClusterSizeDefaultVal;

            numSDLimit.Minimum = (decimal)Model.IsodataClustering.SDLimitMinVal;
            numSDLimit.Maximum = (decimal)Model.IsodataClustering.SDLimitMaxVal;
            numSDLimit.Value = (decimal)Model.IsodataClustering.SDLimitDefaultVal;

            numMinCentroidDist.Minimum = (decimal)Model.IsodataClustering.MinCentroidDistMinVal;
            numMinCentroidDist.Maximum = (decimal)Model.IsodataClustering.MinCentroidDistMaxVal;
            numMinCentroidDist.Value = (decimal)Model.IsodataClustering.MinCentroidDistDefaultVal;

            numMaxMergePerIter.Minimum = Model.IsodataClustering.MaxMergePerIterMinVal;
            numMaxMergePerIter.Maximum = Model.IsodataClustering.MaxMergePerIterMaxVal;
            numMaxMergePerIter.Value = Model.IsodataClustering.MaxMergePerIterDefaultVal;
        }

        public uint InitClusterNum { get { return (uint)numInitClusterNum.Value; } }
        public uint MinClusterSize { get { return (uint)numMinClusterSize.Value; } }
        public float SDLimit { get { return (float)numSDLimit.Value; } }
        public float MinCentroidDist { get { return (float)numMinCentroidDist.Value; } }
        public uint MaxMergePerIter { get { return (uint)numMaxMergePerIter.Value; } }

        private void numMaxClust_ValueChanged(object sender, System.EventArgs e)
        {
            numInitClusterNum.Maximum = numMaxClust.Value;
        }

    }
}

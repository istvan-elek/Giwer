namespace Giwer.dataStock.Clustering.View
{
    public partial class IsodataParamsControl : CentroidBasedParamsControl
    {
        public IsodataParamsControl()
        {
            InitializeComponent();
            InitInputValues();
        }

        private void InitInputValues()
        {
            numInitClusterNum.Minimum = Model.CentroidBased.IsodataClustering.InitClusterNumMinVal;
            numInitClusterNum.Maximum = Model.CentroidBased.IsodataClustering.InitClusterNumMaxVal;
            numInitClusterNum.Value = Model.CentroidBased.IsodataClustering.InitClusterNumDefaultVal;

            numMinClusterSize.Minimum = Model.CentroidBased.IsodataClustering.MinClusterSizeMinVal;
            numMinClusterSize.Maximum = Model.CentroidBased.IsodataClustering.MinClusterSizeMaxVal;
            numMinClusterSize.Value = Model.CentroidBased.IsodataClustering.MinClusterSizeDefaultVal;

            numSDLimit.Minimum = (decimal)Model.CentroidBased.IsodataClustering.SDLimitMinVal;
            numSDLimit.Maximum = (decimal)Model.CentroidBased.IsodataClustering.SDLimitMaxVal;
            numSDLimit.Value = (decimal)Model.CentroidBased.IsodataClustering.SDLimitDefaultVal;

            numMinCentroidDist.Minimum = (decimal)Model.CentroidBased.IsodataClustering.MinCentroidDistMinVal;
            numMinCentroidDist.Maximum = (decimal)Model.CentroidBased.IsodataClustering.MinCentroidDistMaxVal;
            numMinCentroidDist.Value = (decimal)Model.CentroidBased.IsodataClustering.MinCentroidDistDefaultVal;

            numMaxMergePerIter.Minimum = Model.CentroidBased.IsodataClustering.MaxMergePerIterMinVal;
            numMaxMergePerIter.Maximum = Model.CentroidBased.IsodataClustering.MaxMergePerIterMaxVal;
            numMaxMergePerIter.Value = Model.CentroidBased.IsodataClustering.MaxMergePerIterDefaultVal;
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

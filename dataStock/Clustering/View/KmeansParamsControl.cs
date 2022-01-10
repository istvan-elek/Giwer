namespace Giwer.dataStock.Clustering.View
{
    public partial class KmeansParamsControl : ClusteringParamsControl
    {

        public KmeansParamsControl()
        {
            InitializeComponent();
            InitInputValues();
        }

        private void InitInputValues()
        {
            numChangeThreshold.Minimum = (decimal)Model.KmeansClustering.ChangeThresholdMinVal;
            numChangeThreshold.Maximum = (decimal)Model.KmeansClustering.ChangeThresholdMaxVal;
            numChangeThreshold.Value = (decimal)Model.KmeansClustering.ChangeThresholdDefaultVal;

            numMinClust.Minimum = Model.KmeansClustering.MinClusterNumMinVal;
            numMinClust.Maximum = Model.KmeansClustering.MinClusterNumMaxVal;
            numMinClust.Value = Model.KmeansClustering.MinClusterNumDefaultVal;
        }

        public float ChangeThreshold { get { return (float)numChangeThreshold.Value; } }
        public float ChangeElbowThreshold { get { return (float)numChangeElbow.Value; } }
        public uint MinClust { get { return (uint)numMinClust.Value; } }

        private void numMaxClust_ValueChanged(object sender, System.EventArgs e)
        {
            numMinClust.Maximum = numMaxClust.Value;
        }

    }
}

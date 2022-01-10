namespace Giwer.dataStock.Clustering.View
{
    public partial class KmeansParamsControl : CentroidBasedParamsControl
    {

        public KmeansParamsControl()
        {
            InitializeComponent();
            InitInputValues();
        }

        private void InitInputValues()
        {
            numChangeThreshold.Minimum = (decimal)Model.CentroidBased.KmeansClustering.ChangeThresholdMinVal;
            numChangeThreshold.Maximum = (decimal)Model.CentroidBased.KmeansClustering.ChangeThresholdMaxVal;
            numChangeThreshold.Value = (decimal)Model.CentroidBased.KmeansClustering.ChangeThresholdDefaultVal;

            numMinClust.Minimum = Model.CentroidBased.KmeansClustering.MinClusterNumMinVal;
            numMinClust.Maximum = Model.CentroidBased.KmeansClustering.MinClusterNumMaxVal;
            numMinClust.Value = Model.CentroidBased.KmeansClustering.MinClusterNumDefaultVal;
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

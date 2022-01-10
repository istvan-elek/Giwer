using System;
using System.ComponentModel;
using System.Windows.Forms;

using Giwer.dataStock.Clustering.Model;
using Giwer.dataStock.Clustering.Model.CentroidBased;
using Giwer.dataStock.Clustering.Model.Supervised;

namespace Giwer.dataStock.Clustering.View
{
    public partial class ClusteringMethodSelectorControl : UserControl
    {
        private class ClusteringMethod
        {
            public ClusteringMethod(Method method, string displayName, ClusteringParamsControl clusteringParamsCtrl) : base()
            {
                UsedMethod = method;
                DisplayName = displayName;
                Params = clusteringParamsCtrl;
            }
            public Method UsedMethod { get; }
            public string DisplayName { get; }
            public bool AreAllInputsFilled { get { return Params.IsFilled; } }

            private ClusteringParamsControl Params { get; }

            public void ShowParams(bool state)
            {
                Params.Enabled = state;
                Params.Visible = state;
            }

            public IClustering GetClustering()
            {
                switch (UsedMethod)
                {
                    case Method.KMEANS:
                        var kp = Params as KmeansParamsControl;
                        return new KmeansClustering(kp.MaxIter,
                            kp.ChangeThreshold, kp.MinClust, kp.MaxClust, kp.ChangeElbowThreshold);

                    case Method.KMEANSMULTI:
                        var kpm = Params as KmeansParamsControl;
                        return new KmeansClusteringMultiThread(kpm.MaxIter,
                            kpm.ChangeThreshold, kpm.MinClust, kpm.MaxClust, kpm.ChangeElbowThreshold);

                    case Method.ISODATA:
                        var ip = Params as IsodataParamsControl;
                        return new IsodataClustering(ip.MaxIter,
                            ip.InitClusterNum, ip.MaxClust, ip.MinClusterSize, ip.SDLimit, ip.MinCentroidDist, ip.MaxMergePerIter);

                    case Method.RANDOMFOREST:
                        var rfp = Params as RandomForestParamsControl;
                        return new SupervisedClustering(rfp.Model);

                    case Method.KMEANSMANUAL:
                        var km = Params as ManualClusterSelectControl;
                        return new ManualKmeansClustering(km.MaxIter, km.ChangeThreshold, km.SamplePointIndexes, km.isPoly, km.SamplePolyInPointIndexes);

                    default: return null;
                }
            }
        }


        public event EventHandler SelectionStateChangedEvent;
        public IClustering SelectedClustering { get { return SelectedClusteringMethod.GetClustering(); } }
        public Method SelectedMethod { get { return SelectedClusteringMethod.UsedMethod; } }
        public bool IsMethodReady { get { return SelectedClusteringMethod.AreAllInputsFilled; } }

        private BindingList<ClusteringMethod> _clusteringMethods;

        public ClusteringMethodSelectorControl()
        {
            InitializeComponent();

            _clusteringMethods = new BindingList<ClusteringMethod>();
            SetupComboBoxMethods();
        }

        private void SetupComboBoxMethods()
        {
            comboBox.DisplayMember = "DisplayName";
            comboBox.ValueMember = "UsedMethod";
            comboBox.DataSource = _clusteringMethods;
        }

        public void AddMethod(Method method, string displayName, ClusteringParamsControl usrCtrlParams)
        {
            _clusteringMethods.Add(new ClusteringMethod(method, displayName, usrCtrlParams));
            SelectionChanged();
        }

        private ClusteringMethod SelectedClusteringMethod { get { return (ClusteringMethod)comboBox.SelectedItem; } }

        private void SelectionChanged()
        {
            HideAll();
            SelectedClusteringMethod.ShowParams(true);
        }

        private void HideAll()
        {
            foreach (var cm in _clusteringMethods)
            {
                cm.ShowParams(false);
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectionChanged();
            OnSelectionStateChanged();
        }

        private void OnSelectionStateChanged()
        {
            SelectionStateChangedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}


using System.Windows.Forms;

namespace Giwer.dataStock.Clustering.View
{
    public partial class ClusteringParamsControl : UserControl
    {
        public virtual bool IsFilled { get; }

        public ClusteringParamsControl()
        {
            InitializeComponent();
        }
    }
}

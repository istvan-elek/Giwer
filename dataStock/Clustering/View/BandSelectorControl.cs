using System;
using System.Windows.Forms;

namespace Giwer.dataStock.Clustering.View
{
    public partial class BandSelectorControl : UserControl
    {
        public BandSelectorControl()
        {
            InitializeComponent();
            ChangeButtonState(false);
        }

        public int SelectionCount { get { return chkListBands.CheckedItems.Count; } }

        public event EventHandler StateChangedEvent;

        public bool IsFilled 
        { 
            get 
            {
                if (HasSelectionCountRequirement)
                    return SelectionCount == RequiredSelectionCount;
                else
                    return SelectionCount > 0;
            } 
        }
        public int[] SelectedBands
        {
            get
            {
                int[] bands = new int[SelectionCount];
                chkListBands.CheckedItems.CopyTo(bands, 0);
                return bands;
            }
        }
        public int RequiredSelectionCount { get; set; }
        public bool HasSelectionCountRequirement { get { return RequiredSelectionCount != 0; } }

        public void Init(int bandCount)
        {
            chkListBands.Items.Clear();
            for (int i = 0; i < bandCount; i++)
            {
                chkListBands.Items.Add(i);
                chkListBands.SetItemChecked(i, true);
            }

            RequiredSelectionCount = 0;
            ChangeButtonState(bandCount > 0);

            OnStateChanged();
        }

        private void ChangeButtonState(bool state)
        {
            btnDeselectAllBands.Enabled = state;
            btnSelectAllBands.Enabled = state;
        }

        private void chkListBands_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnStateChanged();
        }

        private void btnSelectAllBands_Click(object sender, EventArgs e)
        {
            SelectAll();
        }
        private void btnDeselectAllBands_Click(object sender, EventArgs e)
        {
            DeselectAll();
        }

        private void SelectAll()
        {
            for (int i = 0; i < chkListBands.Items.Count; i++)
            {
                chkListBands.SetItemChecked(i, true);
            }
            OnStateChanged();
        }

        private void DeselectAll()
        {
            foreach (int checkedInd in chkListBands.CheckedIndices)
            {
                chkListBands.SetItemChecked(checkedInd, false);
            }
            OnStateChanged();
        }

        private void OnStateChanged()
        {
            StateChangedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}

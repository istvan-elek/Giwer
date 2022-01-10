using System;
using System.IO;
using System.Windows.Forms;
using Giwer.dataStock.Clustering.Model.Supervised;
using Giwer.dataStock.Clustering.Model.Supervised.RandomForest;

namespace Giwer.dataStock.Clustering.View
{
    public partial class RandomForestParamsControl : ClusteringParamsControl
    {
        public event EventHandler ModelStateChangedEvent;

        public override bool IsFilled { get { return HasModel; } }

        public ISupervisedModel Model { get; private set; }
        public int RequiredBandCount { get { return HasModel ? Model.BandCount : 0; } }
 
        private bool HasModel { get { return Model != null; } }

        public RandomForestParamsControl()
        {
            InitializeComponent();
            ModelStateChanged("None");
        }

        private void btnNewModel_Click(object sender, EventArgs e)
        {
            var trainingForm = new RandomForestTrainingForm
            {
                StartPosition = FormStartPosition.CenterParent
            };

            if (trainingForm.ShowDialog() == DialogResult.OK)
            {
                Model = trainingForm.Model;
                ModelStateChanged("Unsaved Model");
            }
        }

        private void ModelStateChanged(string modelName)
        {
            labelCurrentModel.Text = $"Current Model: {modelName}";
            if (HasModel)
                SetControlStates(true, $"This model requires exactly {RequiredBandCount} band(s) to be included!");
            else
                SetControlStates(true);
            OnModelStateChanged();
        }

        private void OnModelStateChanged()
        {
            ModelStateChangedEvent?.Invoke(this, EventArgs.Empty);
        }

        private void btnSaveModel_Click(object sender, EventArgs e)
        {
            if (HasModel)
            {
                using (SaveFileDialog fileDialog = new SaveFileDialog())
                {
                    fileDialog.Filter = "Binary file|*.bin";

                    if (fileDialog.ShowDialog() == DialogResult.OK)
                    {
                        SaveModel(fileDialog.FileName);
                    }
                }
            }
        }

        private async void SaveModel(string fileName)
        {
            SetControlStates(false, "Saving model...");

            await Model.SaveAsync(fileName);

            ModelStateChanged(Path.GetFileName(fileName));
        }

        private void btnLoadModel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Binary file|*.bin";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadModel(fileDialog.FileName, fileDialog.SafeFileName);
                }
            }
        }

        private async void LoadModel(string fileName, string safeFileName)
        {
            RemoveModel();
            SetControlStates(false, "Loading model...");

            Model = RandomForestModel.EmptyModel();
            await Model.LoadAsync(fileName);

            ModelStateChanged(safeFileName);
        }

        private void RemoveModel()
        {
            Model = null;
            ModelStateChanged("None");
        }

        private void ShowWaitCursor(bool state)
        {
            UseWaitCursor = state;
            Cursor.Position = Cursor.Position; // forces the cursor update
        }

        private void SetControlStates(bool enabled, string hint = "")
        {
            SetButtonStates(enabled);
            SetSelectionHint(hint);
        }

        private void SetButtonStates(bool enabled)
        {
            ShowWaitCursor(!enabled);
            btnNewModel.Enabled = enabled;
            btnSaveModel.Enabled = enabled && HasModel;
            btnLoadModel.Enabled = enabled;
        }

        private void SetSelectionHint(string text)
        {
            labelSelectionHint.Visible = !string.IsNullOrEmpty(text);
            labelSelectionHint.Text = text;
        }
    }
}

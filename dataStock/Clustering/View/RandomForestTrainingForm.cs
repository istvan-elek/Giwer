using Giwer.dataStock.Clustering.Model;
using Giwer.dataStock.Clustering.Model.Supervised;
using Giwer.dataStock.Clustering.Model.Supervised.RandomForest;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Giwer.dataStock.Clustering.View
{
    public partial class RandomForestTrainingForm : Form
    {
        #region Properties and members
        public ISupervisedModel Model { get; private set; }

        private GeoImageData _trainingImage;
        private GeoImageData _clusteringImage;

        private CancellationTokenSource _cancellationTokenSource;
        private bool IsTrainingInProgress { get; set; }

        private bool AreAllInputsFilled { get { return IsTrainingImageInputFilled && IsClusteringImageInputFilled; } }
        private bool IsTrainingImageInputFilled { get { return _trainingImage != null && bandSelectorControl.IsFilled; } }
        private bool IsClusteringImageInputFilled { get { return _clusteringImage != null && comboBoxClusteringBand.Items != null; } }

        private int SelectedClusteringBand { get { return (int)comboBoxClusteringBand.SelectedItem; } }
        #endregion

        #region Constructors
        public RandomForestTrainingForm()
        {
            InitializeComponent();

            InitTrainingParameterValues();
            InitTraining();
        }

        private void InitTraining()
        {
            bandSelectorControl.StateChangedEvent += HandleBandSelectorStateChangedEvent;

            comboBoxClusteringBand.Enabled = false;
            IsTrainingInProgress = false;
            ProgressStateChanged();
        }
        #endregion

        #region Training parameters
        private void InitTrainingParameterValues()
        {
            numTreeCount.Minimum = RandomForestTrainer.TreeCountMinVal;
            numTreeCount.Maximum = RandomForestTrainer.TreeCountMaxVal;
            numTreeCount.Value = RandomForestTrainer.TreeCountDefaultVal;

            numMinNodeSize.Minimum = RandomForestTrainer.MinNodeSizeMinVal;
            numMinNodeSize.Maximum = RandomForestTrainer.MinNodeSizeMaxVal;
            numMinNodeSize.Value = RandomForestTrainer.MinNodeSizeDefaultVal;

            numMaxTreeHeight.Minimum = RandomForestTrainer.MaxTreeHeightMinVal;
            numMaxTreeHeight.Maximum = RandomForestTrainer.MaxTreeHeightMaxVal;
            numMaxTreeHeight.Value = RandomForestTrainer.MaxTreeHeightDefaultVal;

            numBandCountPerSplit.Minimum = RandomForestTrainer.BandCountPerSplitMinVal;
            numBandCountPerSplit.Maximum = RandomForestTrainer.BandCountPerSplitMaxVal;
            numBandCountPerSplit.Value = RandomForestTrainer.BandCountPerSplitDefaultVal;

            numBootstrappingRatio.Minimum = (decimal)RandomForestTrainer.BootstrappingRatioMinVal;
            numBootstrappingRatio.Maximum = (decimal)RandomForestTrainer.BootstrappingRatioMaxVal;
            numBootstrappingRatio.Value = (decimal)RandomForestTrainer.BootstrappingRatioDefaultVal;

            chkBoxIsParallel.Checked = RandomForestTrainer.IsParallelDefaultVal;
        }

        public int TreeCount { get { return (int)numTreeCount.Value; } }
        public int MinNodeSize { get { return (int)numMinNodeSize.Value; } }
        public int MaxTreeHeight { get { return (int)numMaxTreeHeight.Value; } }
        public int BandCountPerSplit { get { return (int)numBandCountPerSplit.Value; } }
        public float BootstrappingRatio { get { return (float)numBootstrappingRatio.Value; } }
        public bool IsParallel { get { return chkBoxIsParallel.Checked; } }
        #endregion

        #region Methods handling image selection
        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Giwer header file|*.gwh";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    _trainingImage = new GeoImageData { FileName = fileDialog.FileName };
                    TrainingImageSelected(fileDialog.SafeFileName);
                }
            }
        }

        private void TrainingImageSelected(string name)
        {
            labelSelectedImage.Text = $"Selected: {name}";
            bandSelectorControl.Init(_trainingImage.Nbands);

            TrainStateChanged();
        }

        private void HandleBandSelectorStateChangedEvent(object sender, EventArgs e)
        {
            BandCountPerSplitChanged();
            TrainStateChanged();
        }

        private void BandCountPerSplitChanged()
        {
            numBandCountPerSplit.Maximum = bandSelectorControl.SelectionCount;
            numBandCountPerSplit.TotalBands = bandSelectorControl.SelectionCount;
        }


        #endregion

        #region Methods handling the clustering image selection
        private void btnSelectClustering_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Giwer header file|*.gwh";

                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    _clusteringImage = new GeoImageData { FileName = fileDialog.FileName };
                    ClusteringImageSelected(fileDialog.SafeFileName);
                }
            }
        }

        private void ClusteringImageSelected(string name)
        {
            labelSelectedClustering.Text = $"Selected: {name}";
            InitComboBoxClusteringBand(_clusteringImage.Nbands);

            TrainStateChanged();
        }

        private void InitComboBoxClusteringBand(int bandCount)
        {
            comboBoxClusteringBand.Enabled = true;
            comboBoxClusteringBand.Items.Clear();
            comboBoxClusteringBand.Items.AddRange(Enumerable.Range(0, bandCount).Select(i => (object)i).ToArray());
            comboBoxClusteringBand.SelectedIndex = 0;
        }
        #endregion

        #region Methods handling the training procedure
        private void TrainStateChanged()
        {
            if (IsTrainingInProgress)
            {
                btnTrain.Text = "Cancel";
                btnTrain.Enabled = true;
            }
            else
            {
                btnTrain.Text = "Train Model and Apply";
                btnTrain.Enabled = AreAllInputsFilled;
            }
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            if (IsTrainingInProgress)
            {
                ConfirmExecutionInterruption();
            }
            else
            {
                ISupervisedTrainer trainer = new RandomForestTrainer(TreeCount, BandCountPerSplit, MaxTreeHeight, MinNodeSize,
                                                                      BootstrappingRatio, IsParallel);
                TryTrainingAsync(trainer);
            }
        }

        private async void TryTrainingAsync(ISupervisedTrainer trainer)
        {
            try
            {
                StartProgress();
                Model = await GetModel(trainer);
                EndProgress();
                AcceptResult();
            }
            catch (ArgumentException)
            {
                EndProgress();
                ShowPixelCountErrorMessage();
            }
            catch (OperationCanceledException)
            {
                InterruptionInProgress(false);
                EndProgress();
            }
        }

        private Task<ISupervisedModel> GetModel(ISupervisedTrainer trainer)
        {
            Progress<ClusteringProgress> progress = new Progress<ClusteringProgress>(ReportProgress);

            return trainer.TrainAsync(_trainingImage, bandSelectorControl.SelectedBands, _clusteringImage, SelectedClusteringBand,
                                      progress, _cancellationTokenSource.Token);
        }

        private void ShowPixelCountErrorMessage()
        {
            MessageBox.Show("The number of pixels in the selected image and clustering do not match. " +
                            "Try selecting two corresponding images!",
                            "Training error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        private void AcceptResult()
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        #region Methods handling the tracking of the progress of the training process
        private void StartProgress()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            ChangeInProgressState(true);
        }

        private void EndProgress()
        {
            _cancellationTokenSource.Dispose();
            ChangeInProgressState(false);
        }

        private void ChangeInProgressState(bool inProgress)
        {
            IsTrainingInProgress = inProgress;
            ProgressStateChanged();
        }

        private void ProgressStateChanged()
        {
            toolStripProgressBar.Visible = IsTrainingInProgress;
            toolStripStatusLabel.Visible = IsTrainingInProgress;

            TrainStateChanged();

            groupBoxImage.Enabled = !IsTrainingInProgress;
            groupBoxClustering.Enabled = !IsTrainingInProgress;
            groupBoxTrainingParameters.Enabled = !IsTrainingInProgress;
        }

        private void ReportProgress(ClusteringProgress progress)
        {
            UpdateProgressBar(progress);
            UpdateStatusLabel(progress);
        }

        private void UpdateProgressBar(ClusteringProgress progress)
        {
            if (progress.IsInitializing)
            {
                toolStripProgressBar.Value = 0;
                toolStripProgressBar.Maximum = progress.MaxValue;
            }
            else
            {
                toolStripProgressBar.Value = progress.Value;
            }
        }

        private void UpdateStatusLabel(ClusteringProgress progress)
        {
            if (progress.IsInitializing)
                toolStripStatusLabel.Text = "Initializing...";
            else
                toolStripStatusLabel.Text = $"{progress.Value} tree(s) trained...";
        }
        #endregion

        #region Methods handling the interruption of the training process
        private void RandomForestTrainingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool executionInterrupted = RequestExecutionInterruption();
            e.Cancel = !executionInterrupted;
        }

        private bool RequestExecutionInterruption()
        {
            if (IsTrainingInProgress)
            {
                bool interrupted = ConfirmExecutionInterruption();
                return interrupted;
            }
            else
                return true;
        }

        private bool ConfirmExecutionInterruption()
        {
            bool confirmed = AskToConfirmTrainingInterruption();
            if (confirmed && IsTrainingInProgress)
            {
                InterruptionInProgress(true);
                _cancellationTokenSource.Cancel();
            }
            return confirmed;
        }

        private void InterruptionInProgress(bool state)
        {
            UseWaitCursor = state;
            foreach (Control control in Controls)
            {
                control.Enabled = !state;
            }
        }

        private bool AskToConfirmTrainingInterruption()
        {
            return MessageBox.Show("Do you want to interrupt the computation?",
                                   "Cancel Training",
                                   MessageBoxButtons.YesNo) == DialogResult.Yes;
        }
        #endregion
    }
}

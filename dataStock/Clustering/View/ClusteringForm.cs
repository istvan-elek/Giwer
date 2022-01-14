using Giwer.dataStock.Clustering.Model;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Giwer.dataStock.Clustering.View
{
    public enum Method { KMEANS, ISODATA, KMEANSMULTI, RANDOMFOREST, KMEANSMANUAL }

    public partial class ClusteringForm : Form
    {
        #region Fields
        private GeoImageData _gImgData;
        private byte[] _currentBand;
        private Int32[] _colorPalette;
        private int[] _defaultColorPalette;
        private IClustering _clustering;

        private CancellationTokenSource _cancellationTokenSource;
        #endregion

        #region Properties
        public byte[] Result { get; private set; }

        private bool IsResultReady { get { return Result != null; } }
        private bool IsClusteringInProgress { get; set; }

        private bool IsCurrentBandAvailable { get { return _currentBand != null; } }
        private bool IsCurrentBandSelected { get { return radioBtnCurrentBand.Checked; } }

        private bool AreAllInputsFilled
        {
            get
            {
                return (bandSelectorControl.IsFilled || IsCurrentBandSelected) && clusteringMethodSelector.IsMethodReady;
            }
        }
        #endregion

        #region Constructors
        public ClusteringForm(GeoImageData gImgData, byte[] currentBand = null)
        {
            InitializeComponent();
            DialogResult = DialogResult.None;

            _gImgData = gImgData;
            _currentBand = currentBand;

            InitControls();
            IsClusteringInProgress = false;
        }
        #endregion

        #region Methods initializing controls
        private void InitControls()
        {
            imgWindow.Hide();
            toolStripProgressBar.Visible = false;
            btnApplyResult.Enabled = false;

            InitColorPalettes();
            InitMethods();
            InitRandomForestParamsControl();
            InitBandSelector(_gImgData.Nbands);
            InitBandRadioButtons();
        }

        private void InitColorPalettes()
        {
            string[] fileEntries = Directory.GetFiles(Application.StartupPath, "*.cp");
            foreach (string item in fileEntries)
            {
                cmbColorPalettes.Items.Add(Path.GetFileNameWithoutExtension(item.ToLower()));
            }
            cmbColorPalettes.SelectedItem = "default";
        }

        private void InitMethods()
        {
            clusteringMethodSelector.SelectionStateChangedEvent += HandleMethodSelectionStateChangedEvents;
            clusteringMethodSelector.AddMethod(Method.KMEANS, "K-Means", usrCtrlKmeansParams);
            clusteringMethodSelector.AddMethod(Method.KMEANSMULTI, "K-Means (Multi threaded)", usrCtrlKmeansParams);
            clusteringMethodSelector.AddMethod(Method.KMEANSMANUAL, "K-Means (Manual)", manualClusterSelectControl1);
            manualClusterSelectControl1.init(imgWindow);
            clusteringMethodSelector.AddMethod(Method.ISODATA, "ISODATA", usrCtrlIsodataParams);
            clusteringMethodSelector.AddMethod(Method.RANDOMFOREST, "Random Forest", usrCtrlRandomForestParams);
        }

        private void HandleMethodSelectionStateChangedEvents(Object sender, EventArgs e)
        {
            RequiredBandCountChanged();
            CurrentBandSelectorStateChanged();
            ComputableStateChanged();
            AutoManualChanged();
        }

        private void RequiredBandCountChanged()
        {
            if (clusteringMethodSelector.SelectedMethod == Method.RANDOMFOREST)
                bandSelectorControl.RequiredSelectionCount = usrCtrlRandomForestParams.RequiredBandCount;
            else
                bandSelectorControl.RequiredSelectionCount = 0;
        }

        private void InitRandomForestParamsControl()
        {
            usrCtrlRandomForestParams.ModelStateChangedEvent += HandleRFStateChangedEvents;
        }

        private void HandleRFStateChangedEvents(Object sender, EventArgs e)
        {
            RequiredBandCountChanged();
            CurrentBandSelectorStateChanged();
            ComputableStateChanged();
        }

        private void InitBandSelector(int nBands)
        {
            bandSelectorControl.StateChangedEvent += HandleBandSelectionStateChangedEvents;
            bandSelectorControl.Init(nBands);
        }

        private void HandleBandSelectionStateChangedEvents(Object sender, EventArgs e)
        {
            ComputableStateChanged();
        }

        private void InitBandRadioButtons()
        {
            CurrentBandSelectorStateChanged();
            CurrentGwhBandsSelected(true);
        }

        private void CurrentBandSelectorStateChanged()
        {
            radioBtnCurrentBand.Enabled = IsCurrentBandAvailable && bandSelectorControl.RequiredSelectionCount < 2;
            if (radioBtnCurrentBand.Enabled == false)
                CurrentGwhBandsSelected(true);
        }
        #endregion

        #region Methods for band selection
        public bool SelectCurrentBand()
        {
            bool selectable = IsCurrentBandAvailable;
            if (selectable)
                CurrentGwhBandsSelected(false);
            return selectable;
        }
        private void radioBtnCurrentBand_Click(object sender, EventArgs e)
        {
            CurrentGwhBandsSelected(false);
        }

        private void radioBtnCurrentGwh_Click(object sender, EventArgs e)
        {
            CurrentGwhBandsSelected(true);
        }

        private void CurrentGwhBandsSelected(bool state)
        {
            radioBtnCurrentBand.Checked = !state;
            radioBtnCurrentGwh.Checked = state;

            CurrentGwhControlsStateChanged(state);
        }

        private void CurrentGwhControlsStateChanged(bool state)
        {
            bandSelectorControl.Enabled = state;
            ComputableStateChanged();
        }
        #endregion

        #region Methods for color palette selection
        private void cmbColorPalettes_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSelectedColorPalette();
            ShowClusteringResult();
        }

        private void LoadSelectedColorPalette()
        {
            _colorPalette = loadColorPalette(Application.StartupPath + "\\" + cmbColorPalettes.SelectedItem + ".cp");
            System.Diagnostics.Debug.WriteLine(Application.StartupPath + "\\" + cmbColorPalettes.SelectedItem + ".cp");
        }

        private Int32[] loadColorPalette(string fileName) // from frmDataStock
        {
            Int32[] cp = new Int32[256];
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    sr.ReadLine();
                    for (int i = 0; i < 256; i++)
                    {
                        string line = sr.ReadLine();
                        Int32 col = Convert.ToInt32(line.Split(';')[1]);
                        cp[i] = col;
                    }
                }
            }
            return cp;
        }
        #endregion

        #region Methods controlling the initiation of the clustering
        private void ComputableStateChanged()
        {
            if (!IsClusteringInProgress)
            {
                btnCompute.Text = "Compute Clustering";
                btnCompute.Enabled = AreAllInputsFilled;
            }
            else
            {
                btnCompute.Text = "Cancel";
                btnCompute.Enabled = true;
            }
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            if (clusteringMethodSelector.SelectedMethod == Method.KMEANSMANUAL)
            {
                manualClusterSelectControl1.saveCP();
                manualClusterSelectControl1.saveLUT();
            }
            if (!IsClusteringInProgress)
            {
                InitClustering();
                TryClustering();
            }
            else
            {
                RequestExecutionInterruption();
            }
        }

        private void InitClustering()
        {
            _clustering = clusteringMethodSelector.SelectedClustering;
        }
        #endregion

        #region Methods obtaining and handling the clustering results
        private async void TryClustering()
        {
            try
            {
                StartProgress();
                Result = await ExecuteClustering();
                ShowDoneStatus(_clustering.ClusterNum);
            }
            catch (Exception ex) when (
                ex is OperationCanceledException
                || ex is System.Threading.Tasks.TaskCanceledException
            )
            {
                InterruptionInProgress(false);
                ShowErrorStatus();
            }

            catch (NoClustersException)
            {
                ShowNoClustersErrorMessage();
                ShowErrorStatus();
            }
            finally
            {
                EndProgress();
                ShowClusteringResult();
            }
        }

        private System.Threading.Tasks.Task<byte[]> ExecuteClustering()
        {
            Progress<ClusteringProgress> progress = new Progress<ClusteringProgress>(ReportProgress);

            if (IsCurrentBandSelected)
            {
                return _clustering.ExecuteAsync(_currentBand, progress, _cancellationTokenSource.Token);
            }
            else
            {
                return _clustering.ExecuteAsync(_gImgData, bandSelectorControl.SelectedBands, progress, _cancellationTokenSource.Token);
            }
        }
        private void ShowDoneStatus(int clusterNumber)
        {
            toolStripStatusLabel.Text = "Done.";
            toolStripStatusLabelResult.Text = $"Number of clusters found: {clusterNumber}";
        }

        private void ShowErrorStatus()
        {
            toolStripStatusLabel.Text = "Cancelled.";
            toolStripStatusLabelResult.Text = "";
        }

        private void ShowClusteringResult()
        {

            if (Result == null)
            {
                imgWindow.Hide();
            }
            else
            {
                imgWindow.DrawImage(_gImgData, Result, _colorPalette);
                imgWindow.Show();
            }
        }

        private void ResultReadyStateChanged()
        {
            if (!IsClusteringInProgress)
                btnApplyResult.Enabled = IsResultReady;
            else
                btnApplyResult.Enabled = false;
        }

        private void ShowNoClustersErrorMessage()
        {
            MessageBox.Show("The calculation ended up with zero clusters. Try setting a lower minimum cluster size!",
                            "Clustering error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
        #endregion

        #region Methods handling the tracking of progress
        private void StartProgress()
        {
            IsClusteringInProgress = true;
            _cancellationTokenSource = new CancellationTokenSource();
            toolStripStatusLabelResult.Text = "";
            ProgressStateChanged();
        }

        private void EndProgress()
        {
            IsClusteringInProgress = false;
            _cancellationTokenSource.Dispose();
            ProgressStateChanged();
        }

        private void ReportProgress(ClusteringProgress progress)
        {
            if (progress.IsInitializing)
            {
                toolStripStatusLabel.Text = "Initializing...";
                SetProgressBarToBlocks(progress.MaxValue);
            }
            else if (!progress.IsUnbounded)
            {
                toolStripStatusLabel.Text = $"Step {progress.Value} complete...";
                toolStripProgressBar.Value = progress.Value;
            }
            else
            {
                toolStripStatusLabel.Text = "Clustering in progress...";
                SetProgressBarToMarquee();
            }

        }

        private void SetProgressBarToBlocks(int maxProgress)
        {
            toolStripProgressBar.Style = ProgressBarStyle.Blocks;
            toolStripProgressBar.Maximum = maxProgress;
            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Step = 10;
        }

        private void SetProgressBarToMarquee()
        {
            toolStripProgressBar.Style = ProgressBarStyle.Marquee;
            toolStripProgressBar.Maximum = 50;
            toolStripProgressBar.Value = 0;
            toolStripProgressBar.Step = 5;
        }

        private void ProgressStateChanged()
        {
            toolStripProgressBar.Visible = IsClusteringInProgress;

            groupBoxMethodParams.Enabled = !IsClusteringInProgress;
            groupBoxInclBands.Enabled = !IsClusteringInProgress;
            clusteringMethodSelector.Enabled = !IsClusteringInProgress;
            labelMethod.Enabled = !IsClusteringInProgress;
            ComputableStateChanged();
            ResultReadyStateChanged();
        }
        #endregion

        #region Methods handling the interruption of the clustering
        private void ClusteringForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool executionInterrupted = RequestExecutionInterruption();
            e.Cancel = !executionInterrupted;
        }

        private bool RequestExecutionInterruption()
        {
            if (IsClusteringInProgress)
            {
                bool interrupted = ConfirmExecutionInterruption();
                return interrupted;
            }
            else
                return true;
        }

        private bool ConfirmExecutionInterruption()
        {
            bool confirmed = AskToConfirmExecutionInterruption();
            if (confirmed && IsClusteringInProgress)
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


        private bool AskToConfirmExecutionInterruption()
        {
            return MessageBox.Show("Do you want to interrupt the computation?",
                                   "Cancel Computation",
                                   MessageBoxButtons.YesNo) == DialogResult.Yes;
        }
        #endregion

        #region Methods for persisting results
        private void btnApplyResult_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        #endregion

        private void AutoManualChanged()
        {
            if (_defaultColorPalette == null)
            {
                _defaultColorPalette = loadColorPalette(Application.StartupPath + "\\default.cp");
            }

            if (clusteringMethodSelector.SelectedMethod != Method.KMEANSMANUAL)
            {
                manualClusterSelectControl1.Hide();
                imgWindow.Hide();
                labelColorPalettes.Visible = true;
                cmbColorPalettes.Visible = true;
            }
            else
            {
                _colorPalette = loadColorPalette(Application.StartupPath + "\\manualClustering.cp");
                labelColorPalettes.Visible = false;
                cmbColorPalettes.Visible = false;
                manualClusterSelectControl1.Show();
                GeoImageTools gImgTools = new GeoImageTools(_gImgData);
                byte[] firstBand = gImgTools.getOneBandBytes(0);
                imgWindow.DrawImage(_gImgData, firstBand, _defaultColorPalette);
                imgWindow.Show();
            }

        }
    }
}

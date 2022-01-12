using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

using Giwer.dataStock.Clustering.View;

namespace Giwer.dataStock
{
    // The frmDataStock creates the GUI and handles the events

    public partial class frmDataStock : Form
    {
        #region global variables
        GeoImageData GeoImage;
        GeoImageTools GTools;
        byte[] currentBand;
        float[,] elevation;
        dtm ddm;
        byte[] undoBand;
        frmConfig conf;
        public string GiwerDataFolder = "";
        string JpgDataFolder="";
        string TifDataFolder = "";
        string BilDataFolder = "";
        string D3DataFolder = "";
        string ProjectFolder = "";
        string WorkflowFolder = "";
        Project project = new Project();
        Int32[] colorpal=new int[256];
        ImageWindow imw = new ImageWindow();
        #endregion

        #region dataStock construct and init
        public frmDataStock() // constructor of dataStock. It sets form settings, and reads config.cfg file which contains data folders
        {
            InitializeComponent();
            this.Location = Properties.Settings.Default.StartLocation;
            this.Size = Properties.Settings.Default.FormSize;
            this.WindowState = Properties.Settings.Default.WindowState;
            splitContainer1.SplitterDistance = Properties.Settings.Default.SplitterDistance;
            toolStripDron.Visible = false;
            tabLayers.Visible = true;
            if (!Properties.Settings.Default.OnOffHeader)
            {
                splitContainer1.Panel1Collapsed = true;
                tsOnOffHeader.BackColor = Color.LightGray;
                tsOnOffHeader.ToolTipText = "Header and layer list ON";
                tabLayers.Visible = false;
            }
            else
            {
                splitContainer1.Panel1Collapsed = false;
                tsOnOffHeader.BackColor = DefaultBackColor;
                tsOnOffHeader.ToolTipText = "Header and layer list OFF";
                tabLayers.Visible = true;
            }
            Boolean b = Properties.Settings.Default.OnOffDronTools;
            toolStripDron.Visible = b;

            conf = new frmConfig();
            if (conf.config.Count != 0)
            {
                try
                {
                    JpgDataFolder = conf.config["JpgDataFolder"];
                    TifDataFolder = conf.config["TifDataFolder"];
                    BilDataFolder = conf.config["BilDataFolder"];
                    GiwerDataFolder = conf.config["GiwerDataFolder"];
                    D3DataFolder = conf.config["3DDataFolder"];
                    ProjectFolder = conf.config["ProjectFolder"];
                    WorkflowFolder = conf.config["WorkflowFolder"];
                }
                catch (Exception e)
                {
                    MessageBox.Show("Config file may contain improper data, or it is damaged. " + e.Message + ". Try to recover the 'config.cfg' file", "Improper data",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //frmConfig cnffile = new frmConfig();
                    conf.config.Clear();
                    //conf.readConfig(Application.StartupPath + @"\config_default.cfg");
                    JpgDataFolder = "";
                    TifDataFolder = "";
                    BilDataFolder = "";
                    GiwerDataFolder = "";
                    D3DataFolder = "";
                    ProjectFolder = "";
                    WorkflowFolder = "";
                }

                this.splitContainer1.Panel2.Controls.Add(imw);
                imw.Dock = DockStyle.Fill;
                imw.BackColor = Color.White;
                imw.Visible = false;
                imw.BringToFront();
            }
            setControls(GeoImageData.fTypes.UNKOWN, false);
            loadAvailableColorPalettes();
            tsButtonLut.Enabled = true;
            multibandProcessesToolStripMenuItem.Enabled = true; ///*******************************
        }
        #endregion

        #region color_palette_and_lookup_table

        private void tscmbColorPalette_SelectedIndexChanged(object sender, EventArgs e) // changes the color palette
        {
            colorpal = loadColorPalette(Application.StartupPath + "\\" + tscmbColorPalette.SelectedItem + ".cp");
            if (GeoImage != null)
            {
                imw.DrawImage(GeoImage, currentBand, colorpal);
                imw.Enabled = true;
            }

        }

        void loadAvailableColorPalettes() // loads available color palettes
        {
            tscmbColorPalette.Items.Clear();
            string[] fileEntries = Directory.GetFiles(Application.StartupPath, "*.cp");
            foreach (string item in fileEntries)
            {
                tscmbColorPalette.Items.Add(Path.GetFileNameWithoutExtension(item.ToLower()));
            }
            tscmbColorPalette.SelectedItem = "default";
        }

        Int32[] loadColorPalette(string fileName) // loads a color palette
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

        private void lookupTableToolStripMenuItem_Click(object sender, EventArgs e) // handles lookup table (még nem teljes)
        {
            frmLookUpTables lupTab = new frmLookUpTables();
            if (lupTab.ShowDialog() == DialogResult.OK)
            {
                loadAvailableColorPalettes();
            }
        }
        #endregion

        #region controls' setup
        void setControls(GeoImageData.fTypes type, Boolean OnOff) // sets controls' enable property
        {
            switch (type)
            {
                case GeoImageData.fTypes.BSQ:
                    multibandProcessesToolStripMenuItem.Enabled = false;
                    convertToGiwerFormatToolStripMenuItem.Enabled = OnOff;
                    simpleProcessesToolStripMenuItem.Enabled = false;
                    tsShowHisto.Enabled = OnOff;
                    tsHistoEqualisation.Enabled = OnOff;
                    tsUndo.Enabled = OnOff;
                    tsMedian.Enabled = false;
                    tsLaplace.Enabled = false;
                    tsHighPass.Enabled = false;
                    tsLowPass.Enabled = false;
                    tsVectorise.Enabled = false;
                    tsThersholding.Enabled = false;
                    tsRGB.Enabled = OnOff;
                    tsMedian.Enabled = false;
                    tsLaplace.Enabled = false;
                    tsHighPass.Enabled = false;
                    bttnSpectrum.Enabled = false;
                    tsLowPass.Enabled = false;
                    tsVectorise.Enabled = false;
                    tsThersholding.Enabled = false;
                    tsbttnGauss.Enabled = false;
                    tsBttnGThLV.Enabled = false;
                    saveResultAsABitmapToolStripMenuItem.Enabled = false;
                    saveResultAsGwrFileToolStripMenuItem.Enabled = false;
                    tsNDVI.Enabled = false;
                    tsPca.Enabled = false;
                    alignMultiBandsToolStripMenuItem.Enabled = false;
                    tsCrossPl.Enabled = false;
                    bttnRasterCalc.Enabled = false;
                    tsCluster.Enabled = false;
                    tsBttnRecordStart.Enabled = false;
                    tsBttnRecordStop.Enabled = false;
                    break;
                case GeoImageData.fTypes.BIL:
                    multibandProcessesToolStripMenuItem.Enabled = false;
                    convertToGiwerFormatToolStripMenuItem.Enabled = OnOff;
                    simpleProcessesToolStripMenuItem.Enabled = false;
                    tsShowHisto.Enabled = OnOff;
                    tsHistoEqualisation.Enabled = OnOff;
                    tsUndo.Enabled = OnOff;
                    tsMedian.Enabled = false;
                    tsLaplace.Enabled = false;
                    tsHighPass.Enabled = false;
                    tsLowPass.Enabled = false;
                    tsVectorise.Enabled = false;
                    tsThersholding.Enabled = false;
                    tsRGB.Enabled = OnOff;
                    bttnSpectrum.Enabled = false;
                    tsMedian.Enabled = false;
                    tsLaplace.Enabled = false;
                    tsHighPass.Enabled = false;
                    tsLowPass.Enabled = false;
                    tsVectorise.Enabled = false;
                    tsThersholding.Enabled = false;
                    tsbttnGauss.Enabled = false;
                    tsBttnGThLV.Enabled = false;
                    saveResultAsABitmapToolStripMenuItem.Enabled = false;
                    saveResultAsGwrFileToolStripMenuItem.Enabled = false;
                    tsNDVI.Enabled = false;
                    tsPca.Enabled = false;
                    alignMultiBandsToolStripMenuItem.Enabled = false;
                    tsCrossPl.Enabled = false;
                    bttnRasterCalc.Enabled = false;
                    tsCluster.Enabled = false;
                    tsBttnRecordStart.Enabled = false;
                    tsBttnRecordStop.Enabled = false;
                    break;
                case GeoImageData.fTypes.ENVI:
                    multibandProcessesToolStripMenuItem.Enabled = false;
                    convertToGiwerFormatToolStripMenuItem.Enabled = OnOff;
                    simpleProcessesToolStripMenuItem.Enabled = false;
                    tsShowHisto.Enabled = OnOff;
                    tsHistoEqualisation.Enabled = OnOff;
                    tsUndo.Enabled = OnOff;
                    tsMedian.Enabled = false;
                    tsLaplace.Enabled = false;
                    tsHighPass.Enabled = false;
                    tsLowPass.Enabled = false;
                    bttnSpectrum.Enabled = false;
                    tsVectorise.Enabled = false;
                    tsThersholding.Enabled = false;
                    tsCluster.Enabled = false;
                    tsBttnRecordStart.Enabled = false;
                    tsBttnRecordStop.Enabled = false;
                    alignMultiBandsToolStripMenuItem.Enabled = false;
                    break;
                case GeoImageData.fTypes.GWH:
                    multibandProcessesToolStripMenuItem.Enabled = OnOff;
                    tsCrossPl.Enabled = OnOff;
                    tsNDVI.Enabled = OnOff;
                    tsPca.Enabled = OnOff;
                    //tsButtonLut.Enabled = OnOff;
                    convertToGiwerFormatToolStripMenuItem.Enabled = false;
                    simpleProcessesToolStripMenuItem.Enabled = OnOff;
                    tsShowHisto.Enabled = OnOff;
                    tsHistoEqualisation.Enabled = OnOff;
                    tsUndo.Enabled = OnOff;
                    tsMedian.Enabled = OnOff;
                    tsLaplace.Enabled = OnOff;
                    tsHighPass.Enabled = OnOff;
                    tsLowPass.Enabled = OnOff;
                    tsVectorise.Enabled = OnOff;
                    tsThersholding.Enabled = OnOff;
                    tsbttnGauss.Enabled = OnOff;
                    tsBttnGThLV.Enabled = OnOff;
                    bttnSpectrum.Enabled = OnOff;
                    saveResultAsABitmapToolStripMenuItem.Enabled = OnOff;
                    saveResultAsGwrFileToolStripMenuItem.Enabled = OnOff;
                    bttnRasterCalc.Enabled = OnOff;
                    tsRGB.Enabled = OnOff;
                    tsCluster.Enabled = OnOff;
                    tsBttnRecordStart.Enabled = OnOff;
                    tsBttnRecordStop.Enabled = false;
                    bttnBandAligner.Enabled = OnOff;
                    alignMultiBandsToolStripMenuItem.Enabled = OnOff;
                    tsExport.Enabled = OnOff;
                    break;
                case GeoImageData.fTypes.JPG:
                    multibandProcessesToolStripMenuItem.Enabled = false;
                    convertToGiwerFormatToolStripMenuItem.Enabled = OnOff;
                    simpleProcessesToolStripMenuItem.Enabled = false;
                    tsRGB.Enabled = false;
                    tsUndo.Enabled = false;
                    tsMedian.Enabled = false;
                    tsLaplace.Enabled = false;
                    tsHighPass.Enabled = false;
                    tsLowPass.Enabled = false;
                    tsVectorise.Enabled = false;
                    tsThersholding.Enabled = false;
                    tsShowHisto.Enabled = false;
                    tsHistoEqualisation.Enabled = false;
                    tsCluster.Enabled = false;
                    bttnSpectrum.Enabled = false;
                    tsBttnRecordStart.Enabled = false;
                    tsBttnRecordStop.Enabled = false;
                    bttnBandAligner.Enabled = OnOff;
                    alignMultiBandsToolStripMenuItem.Enabled = OnOff;
                    break;
                case GeoImageData.fTypes.TIF:
                    multibandProcessesToolStripMenuItem.Enabled = false;
                    convertToGiwerFormatToolStripMenuItem.Enabled = OnOff;
                    simpleProcessesToolStripMenuItem.Enabled = false;
                    tsRGB.Enabled = false;
                    tsUndo.Enabled = false;
                    tsMedian.Enabled = false;
                    tsLaplace.Enabled = false;
                    tsHighPass.Enabled = false;
                    tsLowPass.Enabled = false;
                    tsVectorise.Enabled = false;
                    tsThersholding.Enabled = false;
                    tsShowHisto.Enabled = false;
                    tsHistoEqualisation.Enabled = false;
                    tsCluster.Enabled = false;
                    bttnSpectrum.Enabled = false;
                    tsBttnRecordStart.Enabled = false;
                    tsBttnRecordStop.Enabled = false;
                    bttnBandAligner.Enabled = OnOff;
                    alignMultiBandsToolStripMenuItem.Enabled = OnOff;
                    break;
                case GeoImageData.fTypes.UNKOWN:
                    multibandProcessesToolStripMenuItem.Enabled = false;
                    convertToGiwerFormatToolStripMenuItem.Enabled = false;
                    simpleProcessesToolStripMenuItem.Enabled = false;
                    tsRGB.Enabled = false;
                    tsShowHisto.Enabled = false;
                    tsHistoEqualisation.Enabled = false;
                    tsUndo.Enabled = false;
                    tsMedian.Enabled = false;
                    tsLaplace.Enabled = false;
                    tsHighPass.Enabled = false;
                    tsLowPass.Enabled = false;
                    tsVectorise.Enabled = false;
                    tsThersholding.Enabled = false;
                    tsbttnGauss.Enabled = false;
                    tsBttnGThLV.Enabled = false;
                    saveResultAsABitmapToolStripMenuItem.Enabled = false;
                    saveResultAsGwrFileToolStripMenuItem.Enabled = false;
                    tsNDVI.Enabled = false;
                    tsPca.Enabled = false;
                    bttnSpectrum.Enabled = false;
                    tsCrossPl.Enabled = false;
                    bttnRasterCalc.Enabled = false;
                    tsCluster.Enabled = false;
                    tsBttnRecordStart.Enabled = false;
                    tsBttnRecordStop.Enabled = false;
                    bttnBandAligner.Enabled = false;
                    alignMultiBandsToolStripMenuItem.Enabled = false;
                    tsExport.Enabled = false;
                    break;
                case GeoImageData.fTypes.DDM:
                    multibandProcessesToolStripMenuItem.Enabled = OnOff;
                    convertToGiwerFormatToolStripMenuItem.Enabled = OnOff;
                    simpleProcessesToolStripMenuItem.Enabled = OnOff;
                    tsRGB.Enabled = OnOff;
                    tsUndo.Enabled = OnOff;
                    tsMedian.Enabled = OnOff;
                    tsLaplace.Enabled = OnOff;
                    tsHighPass.Enabled = OnOff;
                    tsLowPass.Enabled = OnOff;
                    tsVectorise.Enabled = OnOff;
                    tsThersholding.Enabled = OnOff;
                    tsShowHisto.Enabled = OnOff;
                    tsHistoEqualisation.Enabled = OnOff;
                    tsCluster.Enabled = OnOff;
                    tsBttnRecordStart.Enabled = false;
                    tsBttnRecordStop.Enabled = false;
                    bttnBandAligner.Enabled = OnOff;
                    alignMultiBandsToolStripMenuItem.Enabled = OnOff;
                    break;
            }
        }
        #endregion

        #region open_image_files
        private void openBILToolStripMenuItem_Click(object sender, EventArgs e)  // opens a bil file
        {
            OpenFileDialog of = new OpenFileDialog();
            of.InitialDirectory = BilDataFolder;
            of.Filter = "BIL, BSQ, CUE files|*.bil;*.bsq;*.cue";
            of.Multiselect = true;
            if (of.ShowDialog() == DialogResult.OK)
            {
                toolStripLayer.Enabled = true;
                setControls(GeoImageData.fTypes.UNKOWN, false);
                GeoImage = new GeoImageData();
                GeoImage.FileName = of.FileName;
                //settbEXIF(GeoImage.FileType);
                TreeNode actualTreenode = new TreeNode();
                foreach (string item in of.FileNames)
                {
                    actualTreenode = LayerViewer.Nodes.Add(Path.GetFileName(item));
                    actualTreenode.Tag = item; // of.FileName;
                    fillBands(actualTreenode);
                }
                //TreeNode actualTreenode = LayerViewer.Nodes.Add(Path.GetFileName(of.FileName));
                //actualTreenode.Tag = of.FileName;
                //fillBands(actualTreenode);
                GTools = new GeoImageTools(GeoImage);
                printPars("bil");
                BilDataFolder = Path.GetDirectoryName(of.FileName);
                setControls(GeoImage.FileType, true);
                if (project.ProjectFileName !="") saveProjectAsToolStripMenuItem.Enabled = true;
            }
        }


        private void open3DDataFileToolStripMenuItem_Click(object sender, EventArgs e)  // opens and display 3D data (recently only for hungarian DDM file form)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.InitialDirectory = D3DataFolder;
            of.Filter = "Elevation files (ddm, img)| *.ddm";
            of.Multiselect = true;
            if (of.ShowDialog() == DialogResult.OK)
            {
                toolStripLayer.Enabled = true;
                if (Path.GetExtension(of.FileName).ToLower() == ".ddm")
                {
                    setControls(GeoImageData.fTypes.UNKOWN, false);
                    GeoImage = new GeoImageData();
                    GeoImage.FileName = of.FileName;
                    TreeNode actualTreenode = new TreeNode();
                    foreach (string item in of.FileNames)
                    {
                        actualTreenode = LayerViewer.Nodes.Add(Path.GetFileName(item));
                        actualTreenode.Tag = item; // of.FileName;
                        fillBands(actualTreenode);
                    }
                    //TreeNode actualTreenode = LayerViewer.Nodes.Add(Path.GetFileName(of.FileName));
                    //actualTreenode.Tag = of.FileName;
                    //fillBands(actualTreenode);
                    GTools = new GeoImageTools(GeoImage);
                    printPars("3d");
                    D3DataFolder = Path.GetDirectoryName(of.FileName);
                    setControls(GeoImageData.fTypes.DDM,false);
                    if (project.ProjectFileName != "") saveProjectAsToolStripMenuItem.Enabled = true;
                    dtm ddm = new dtm();
                    ddm.FileName = of.FileName;
                    elevation = ddm.dem;
                }
                D3DataFolder = Path.GetDirectoryName(of.FileName);
            }
        }


        private void openGiwerFormatFileToolStripMenuItem_Click(object sender, EventArgs e)  // opens a gwr file
        {
            OpenFileDialog of = new OpenFileDialog();
            of.InitialDirectory = GiwerDataFolder;
            of.Filter = "Giwer header file|*.gwh";
            of.Multiselect = true;
            if (of.ShowDialog() == DialogResult.OK)
            {
                toolStripLayer.Enabled = true;
                setControls(GeoImageData.fTypes.UNKOWN, false);
                GeoImage = new GeoImageData();
                GeoImage.FileName = of.FileName;
                //settbEXIF(GeoImage.FileType);
                //GTools = new GeoImageTools(GeoImage);
                TreeNode actualTreenode = new TreeNode();
                foreach (string item in of.FileNames)
                {
                    actualTreenode = LayerViewer.Nodes.Add(Path.GetFileName(item));
                    actualTreenode.Tag = item; // of.FileName;
                    fillBands(actualTreenode);
                }
                //TreeNode actualTreenode = LayerViewer.Nodes.Add(Path.GetFileName(of.FileName));
                //actualTreenode.Tag = of.FileName;
                //fillBands(actualTreenode);
                GiwerDataFolder = Path.GetDirectoryName(of.FileName);
                printPars("gwr");
                setControls(GeoImage.FileType, false);
                if (project.ProjectFileName == "")
                {
                    saveProjectFileToolStripMenuItem.Enabled = false;
                    saveProjectAsToolStripMenuItem.Enabled = true;
                }
                else
                {
                    saveProjectFileToolStripMenuItem.Enabled = true;
                    saveProjectAsToolStripMenuItem.Enabled = true;
                }

            }
        }

        private void openJPG24DppOnlyToolStripMenuItem_Click(object sender, EventArgs e)  //opens a jpeg file
        {
            OpenFileDialog of = new OpenFileDialog();
            of.InitialDirectory = JpgDataFolder;
            of.Filter = "JPG files|*.jpg;*.jpeg";
            of.Multiselect = true;
            if (of.ShowDialog() == DialogResult.OK)
            {
                setControls(GeoImageData.fTypes.UNKOWN, false);
                GeoImage = new GeoImageData();
                GeoImage.FileName = of.FileNames[0];
                //settbEXIF(GeoImage.FileType);
                TreeNode actualTreenode = new TreeNode();
                foreach (string item in of.FileNames)
                {
                    actualTreenode = LayerViewer.Nodes.Add(Path.GetFileName(item));
                    actualTreenode.Tag = item; // of.FileName;
                    fillBands(actualTreenode);
                }
                //TreeNode actualTreenode = LayerViewer.Nodes.Add(Path.GetFileName(of.FileName));
                //actualTreenode.Tag = of.FileName;
                //fillBands(actualTreenode);
                GTools = new GeoImageTools(GeoImage);
                imw.LoadImageFromFile(GeoImage.FileName);
                imw.Show();
                imw.Enabled = false;
                printPars("jpg");
                setControls(GeoImage.FileType, false);
                if (project.ProjectFileName != "") saveProjectAsToolStripMenuItem.Enabled = true;
                JpgDataFolder = Path.GetDirectoryName(of.FileName);
                //string[] exif = GeoImage.getExifData(of.FileName);
                //printExif(exif);
                toolStripLayer.Enabled = true;
            }
        }

        private void openTIFToolStripMenuItem_Click(object sender, EventArgs e) // opens a tiff file
        {
            OpenFileDialog of = new OpenFileDialog();
            of.InitialDirectory = TifDataFolder;
            of.Filter = "TIF files|*.tif;*.tiff";
            of.Multiselect = true;
            if (of.ShowDialog() == DialogResult.OK)
            {
                toolStripLayer.Enabled = true;
                this.Cursor = Cursors.WaitCursor;
                setControls(GeoImageData.fTypes.UNKOWN, false);
                GeoImage = new GeoImageData();
                GeoImage.FileName = of.FileName;
                //settbEXIF(GeoImage.FileType);
                TreeNode actualTreenode = new TreeNode();
                foreach (string item in of.FileNames)
                {
                    actualTreenode = LayerViewer.Nodes.Add(Path.GetFileName(item));
                    actualTreenode.Tag = item; // of.FileName;
                    fillBands(actualTreenode);
                }
                //TreeNode actualTreenode = LayerViewer.Nodes.Add(Path.GetFileName(GeoImage.FileName));
                //actualTreenode.Tag = GeoImage.FileName;
                //fillBands(actualTreenode);
                printPars("tif");
                //string[] exif = GeoImage.getExifData(GeoImage.FileName);
                setControls(GeoImage.FileType, true);
                if (project.ProjectFileName != "") saveProjectAsToolStripMenuItem.Enabled = true;
                TifDataFolder = Path.GetDirectoryName(GeoImage.FileName);
                if (GeoImage.Nbands > 3)
                {
                    MessageBox.Show("This image has more than 3 bands. It cannot be displayed as an RGB image." + "Convert it to gwr format to go.", "Too many bands for display", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    imw.LoadImageFromFile(GeoImage.FileName);
                    imw.Show();
                }
                imw.Enabled = false;
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region print_image_parameters
        void printExif(string[] exifData) // prints exif data of the current image
        {
            tbEXIF.Text = "";
            foreach (string item in exifData)
            {
                tbEXIF.AppendText(item + Environment.NewLine);
            }
        }
        void printPars(string flag) // prints geoimage parameters (header) to the header textbox
        {
            tbHeader.Text = "";
            foreach (var prop in GeoImage.GetType().GetProperties())
            {
                if (prop.Name.ToLower() != "wavelength")
                {
                    tbHeader.AppendText(prop.Name + ": " + prop.GetValue(GeoImage) + Environment.NewLine);
                }
                else 
                {
                    if (GeoImage.Wavelength != null)
                    {
                        tbHeader.AppendText(prop.Name + ": " + String.Join(",", GeoImage.Wavelength) + Environment.NewLine);
                    }
                }
            }
        }
        #endregion

        #region histogram
        private void drawHistogramToolStripMenuItem1_Click(object sender, EventArgs e) // activates Histogram menu, i.e. open Histogram form, where you can set up min and max values interactively       
        {
            Histogram3 hist = new Histogram3(currentBand, Path.GetFileName(GeoImage.FileName));  //imageFileName);
            if (hist.ShowDialog() == DialogResult.OK)
            {
                undoBand = currentBand;
                //hist.Show();
                this.Cursor = Cursors.WaitCursor;
                currentBand = hist.HistogramEqualization(currentBand, hist.IntMin, hist.IntMax);
                //iw.loadImage(GTools.convertOneBandBytesto8bitBitmap(currentBand,GeoImage.Ncols, GeoImage.Nrows, colorpal));
                imw.DrawImage(GeoImage, currentBand, colorpal);
                this.Cursor = Cursors.Default;
                GC.Collect();
            }
        }


        private void histogramEqualizationToolStripMenuItem_Click(object sender, EventArgs e) // activates histogram equalisation (automatic)
        {
            this.Cursor = Cursors.WaitCursor;
            undoBand = currentBand;
            Histogram3 hist = new Histogram3();
            currentBand = hist.HistogramEqualization(currentBand);
            //iw.loadImage(GTools.convertOneBandBytesto8bitBitmap(currentBand,GeoImage.Ncols,GeoImage.Nrows,colorpal));
            imw.DrawImage(GeoImage, currentBand, colorpal);
            this.Cursor = Cursors.Default;
            GC.Collect();
        }
        #endregion

        #region toolstrip buttons' and menus' event handlers
        private void bttnDronTools_Click(object sender, EventArgs e)
        {
            toolStripDron.Visible = !toolStripDron.Visible;
        }

        private void bttnBandAligner_Click(object sender, EventArgs e)
        {
            frmBandAlign bandAligner = new frmBandAlign(GeoImage);
            bandAligner.ShowDialog();
        }

        private void bttnMoviePlayer_Click(object sender, EventArgs e) // if there are movies recorded by drons you can play them
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "(mp3, wav, mp4, mov, wmv, mpg) | *.mp3; *.wav; *.mp4; *.mov; *.wmv; *.mpg";
            if (of.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    System.Diagnostics.Process.Start("wmplayer.exe", of.FileName);
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Windows Media Player is not found." + ee.Message, "Error on media playing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void rasterCalculatorToolStripMenuItem_Click(object sender, EventArgs e)  // activates raster calculator
        {
            undoBand = currentBand;
            frmRasterCalculator rasCalc = new frmRasterCalculator(currentBand);
            rasCalc.ShowDialog();
            if (rasCalc.DialogResult == DialogResult.OK)
            {
                GeoImageTools gtools = new GeoImageTools(GeoImage);
                currentBand = rasCalc.byOut;
                imw.DrawImage(GeoImage, currentBand, colorpal);
            }
        }
        private void createRGBToolStripMenuItem1_Click(object sender, EventArgs e)  // activate RGB creation form
        {
            this.Cursor = Cursors.WaitCursor;
            RGBViewer rgbView = new RGBViewer(GeoImage, GiwerDataFolder);
            if (GeoImage.Nbands > 1) { rgbView.Show(); }
            this.Cursor = Cursors.Default;
        }

        private void nDVIToolStripMenuItem_Click(object sender, EventArgs e) // activates the NDVI form, and compute NDVI values
        {
            frmNDVI showNDVI = new frmNDVI(GeoImage, GiwerDataFolder);
            showNDVI.Show();
        }

        private void aRVIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sAVIToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsUndo_Click(object sender, EventArgs e) // recoveres data to the original state
        {
            if (undoBand == null) { return; }
            currentBand = undoBand;
            imw.DrawImage(GeoImage, currentBand, colorpal);
        }

        private void crossPlotToolStripMenuItem_Click(object sender, EventArgs e) // activates the cross-plot drawing form
        {
            CrossPlot cp = new CrossPlot(GeoImage);
            cp.ShowDialog();
            if (cp.DialogResult == DialogResult.OK)
            {
                if (cp.chkDisplayInNewWindow.Checked)
                {
                    GeoImageTools gt = new GeoImageTools();
                    gt.displayBandOnNewForm(0, GeoImage, cp.band1, colorpal);
                }
                else
                {
                    undoBand = currentBand;
                    currentBand = cp.band1;
                    imw.DrawImage(GeoImage, currentBand, colorpal);
                }
            }
        }

        private void pCAToolStripMenuItem_Click(object sender, EventArgs e)  // activates PCA 
        {
            frmPCA pca = new frmPCA(GeoImage, GiwerDataFolder);
            pca.ShowDialog();
            if (pca.DialogResult == DialogResult.OK)
            {
                undoBand = currentBand;
                currentBand = pca.PCN;
                imw.DrawImage(GeoImage, currentBand, colorpal);
                setControls(GeoImage.FileType, true); //, 0);
            }
        }

        private void thresholdingToolStripMenuItem_Click(object sender, EventArgs e) //activates thresholding form
        {
            undoBand = currentBand;
            frmKernel Kern = new frmKernel("threshold", currentBand);
            if (Kern.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                Filter threshold = new Filter();
                currentBand = threshold.Thresholding(currentBand, GeoImage.Ncols, GeoImage.Nrows, Kern.threshold);
                imw.DrawImage(GeoImage, currentBand, colorpal);
                this.Cursor = Cursors.Default;
            }
        }

        private void vectorizingToolStripMenuItem_Click(object sender, EventArgs e)  //activates vectorizing for the current band
        {
            undoBand = currentBand;
            Filter Filt = new Filter();
            this.Cursor = Cursors.WaitCursor;
            currentBand = Filt.vectorize(currentBand, GeoImage.Ncols, GeoImage.Nrows);
            imw.DrawImage(GeoImage, currentBand, colorpal);
            this.Cursor = Cursors.Default;
        }

        private void tsBttnGThLV_Click(object sender, EventArgs e)  //activates the vectorizing function chain
        {
            undoBand = currentBand;
            Filter Filt = new Filter();
            frmKernel kernGauss = new frmKernel("gauss");
            if (kernGauss.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                currentBand = Filt.ConvolSingleBand(kernGauss.Kernel, currentBand, GeoImage.Ncols, GeoImage.Nrows);
                Histogram3 his = new Histogram3(currentBand, "histo");
                currentBand = his.HistogramEqualization(currentBand);
                frmKernel KernThres = new frmKernel("threshold", currentBand);
                if (KernThres.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;
                    undoBand = currentBand;
                    currentBand = Filt.Thresholding(currentBand, GeoImage.Ncols, GeoImage.Nrows, KernThres.threshold);
                    currentBand = Filt.LaplaceOneBand(currentBand, GeoImage.Ncols, GeoImage.Nrows);
                    currentBand = Filt.vectorize(currentBand, GeoImage.Ncols, GeoImage.Nrows);
                    imw.DrawImage(GeoImage, currentBand, colorpal);
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void spectrumAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSpectrumBank spBank = new frmSpectrumBank();
            spBank.ShowDialog();
        }

        private void segmentationToolStripMenuItem_Click(object sender, EventArgs e)  // activates segmentation based on histogram
        {

            //frmSegmenting segm = new frmSegmenting(currentBand);
            //if (segm.ShowDialog()==DialogResult.OK)
            //{
            //    undoBand = currentBand;
            //    GeoImageTools gtools = new GeoImageTools(GeoImage);
            //    currentBand = segm.segmentedImage;
            //}
        }
        #endregion

        #region conversion functions
        private void convertSelectedFilesToGiwerFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Image files (tif, jpg, bil, bsq)|*.tif;*.jpg;*.bil;*.bsq";
            of.Multiselect = true;
            if (of.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                tsPbar.Minimum = 0;
                tsPbar.Maximum = of.FileNames.Length - 1;
                tsPbar.Visible = true;
                tsPbar.Step = 1;
                foreach (string fil in of.FileNames)
                {
                    tsPbar.PerformStep();
                    GeoImageData geoimda = new GeoImageData();
                    geoimda.FileName = fil;
                    convertImage2gwr(geoimda);
                }
            }
            this.Cursor = Cursors.Default;
            tsPbar.Visible = false;
            MessageBox.Show("Conversion completed successfully", "Conversion succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void convertImage2gwr(GeoImageData gimda) // converts an image to gwr format
        {
            GTools = new GeoImageTools(gimda);
            this.Cursor = Cursors.WaitCursor;
            string newDirName = GiwerDataFolder + "\\" + Path.GetFileNameWithoutExtension(gimda.FileName);
            System.IO.Directory.CreateDirectory(newDirName);
            tsPbar.Value = 0;
            tsPbar.Minimum = 0;
            tsPbar.Maximum = gimda.Nbands;
            tsPbar.Step = 1;
            tsPbar.Visible = true;
            for (int i = 0; i < gimda.Nbands; i++)
            {
                tsPbar.PerformStep();
                byte[] curBand = GTools.getOneBandBytes(i);
                if (gimda.FileType == GeoImageData.fTypes.BIL || gimda.FileType == GeoImageData.fTypes.BSQ || gimda.FileType == GeoImageData.fTypes.ENVI)
                {
                    int j = i;
                    GTools.convertByteArray2GiwerFormat(curBand, newDirName + "\\" + j + ".gwr");
                }
                if (gimda.FileType == GeoImageData.fTypes.TIF )
                {
                    GTools.convertByteArray2GiwerFormat(curBand, newDirName + "\\" + i + ".gwr");
                }
                if (gimda.FileType == GeoImageData.fTypes.JPG)
                {
                    int j = gimda.Nbands - i - 1;
                    GTools.convertByteArray2GiwerFormat(curBand, newDirName + "\\" + j + ".gwr");
                }
                if (gimda.FileType == GeoImageData.fTypes.DDM)
                {
                    int j = gimda.Nbands - 1;
                    GTools.convertByteArray2GiwerFormat(curBand, newDirName + "\\" + i + ".gwr");
                }
            }
            gimda.Nbits = 8;
            gimda.BytesPerPixel = gimda.Nbands;
            GTools.saveHeader2Giwer(newDirName + ".gwh");
            tsPbar.Visible = false;
        }


        private void convertToGiwerFormatToolStripMenuItem_Click(object sender, EventArgs e)  // calls the convert function, which converts the current image to giwer format
        {
            this.Cursor = Cursors.WaitCursor;
            convertImage2gwr(GeoImage);
            this.Cursor = Cursors.Default;
            //tsPbar.Visible = false;
            //tsPbar.Minimum = 0;
            //tsPbar.Value = 0;
            MessageBox.Show("'" + Path.GetFileName(GeoImage.FileName) + "' conversion succeeded into " + GiwerDataFolder);
        }

        private void mergeMultipleImageToGwrFormatToolStripMenuItem_Click(object sender, EventArgs e)  // converts and merges individual tif or jpeg files containing only one band per file into one multiband gwr file 
        {
            GeoImageData geoimda = new GeoImageData();
            GeoImageTools gt = new GeoImageTools(geoimda);
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "TIF, JPG|*.tif;*.jpg";
            of.Multiselect = true;

            if (of.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                tsPbar.Visible = true;
                tsPbar.Value = 0;
                tsPbar.Maximum = of.FileNames.Length;
                Application.DoEvents();
                for (int k = 0; k < of.FileNames.Length; k++)
                {
                    tsPbar.PerformStep();
                    geoimda.FileName = of.FileNames[k];
                    string newDirName = GiwerDataFolder + "\\" + Path.GetFileNameWithoutExtension(geoimda.FileName);
                    System.IO.Directory.CreateDirectory(newDirName);
                    currentBand = gt.getOneBandBytes(0);
                    convertImage2gwr(geoimda);
                    geoimda.Nbands = 1; // of.FileNames.Length;
                    gt.saveHeader2Giwer(newDirName + ".gwh");
                }
                string fname = Path.GetFileNameWithoutExtension(of.FileName).Substring(0, Path.GetFileNameWithoutExtension(of.FileName).Length - 2);
                string newDirName2 = GiwerDataFolder + "\\" + Path.GetFileNameWithoutExtension(fname);
                // itt előbb még ki kell küszöbölni a szín sávok eltolódását
                GeoImageData geoimOut = new GeoImageData();
                geoimOut = geoimda;
                geoimda.Nbands = of.FileNames.Length;
                gt.saveHeader2Giwer(newDirName2 + ".gwh");
                mergeGwrFiles(of.FileNames, fname, newDirName2);
                this.Cursor = Cursors.Default;
                MessageBox.Show("Conversion completed");
                tsPbar.Value = 0;
                tsPbar.Visible = false;
            }
        }

        void mergeGwrFiles(string[] fnames, string newname, string newDname)
        {
            System.IO.Directory.CreateDirectory(newDname);
            for (int i = 0; i < fnames.Length; i++)
            {
                string nf = GiwerDataFolder + "\\" + Path.GetFileNameWithoutExtension(fnames[i]);
                File.Copy(nf + "\\0.gwr", GiwerDataFolder + "\\" + newname + "\\" + i + ".gwr", true);
                deleteSourceFiles(nf, Path.GetFileNameWithoutExtension(fnames[i]) + ".gwh");
            }
        }

        private void convertEachMultipleImageToGwrFormatToolStripMenuItem_Click(object sender, EventArgs e) // converts individual tif or jpeg files containing only one band per file into gwr file (as many files ans many gwr files)
        {
            GeoImageData geoimda = new GeoImageData();
            GeoImageTools gt = new GeoImageTools(geoimda);
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "TIF, JPG|*.tif;*.jpg";
            of.Multiselect = true;

            Application.DoEvents();
            if (of.ShowDialog() == DialogResult.OK)
            {
                tsPbar.Value = 0;
                tsPbar.Visible = true;
                this.Cursor = Cursors.WaitCursor;
                tsPbar.Maximum = of.FileNames.Length;
                string fname = of.FileNames[0];
                string newDirName = GiwerDataFolder + "\\" + Path.GetFileNameWithoutExtension(fname);
                System.IO.Directory.CreateDirectory(newDirName);
                for (int k = 0; k < of.FileNames.Length; k++)
                {
                    tsPbar.PerformStep();
                    geoimda.FileName = of.FileNames[k];
                    currentBand = gt.getOneBandBytes(0);
                    convertImage2gwr(geoimda);
                }
                geoimda.Nbands = 1;
                gt.saveHeader2Giwer(newDirName + ".gwh");
                this.Cursor = Cursors.Default;
                tsPbar.Visible = false;
                tsPbar.Value = 0;
                MessageBox.Show("Conversion completed");
            }
        }

        void deleteSourceFiles(string dirName, string fname)
        {
            var dir = new DirectoryInfo(@dirName);
            dir.Delete(true);
            File.Delete(GiwerDataFolder + "\\" + fname);
        }

        #endregion

        #region filters

        private void medianFilterToolStripMenuItem_Click(object sender, EventArgs e) // calls median filter function applied to a current giwer file
        {
            int kernelSize;
            undoBand = currentBand;
            Filter mediFilt = new Filter();
            frmKernel Kern = new frmKernel("median");
            if (Kern.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                kernelSize = Kern.kernelLength;
                currentBand = mediFilt.MedianFilterOneBand(currentBand, kernelSize, GeoImage.Ncols, GeoImage.Nrows);
                imw.DrawImage(GeoImage, currentBand, colorpal);
            }
            this.Cursor = Cursors.Default;
        }



        private void gaussSmoothingToolStripMenuItem_Click(object sender, EventArgs e) // calls gauss smoothing filter function applied to a current giwer file
        {
            frmKernel Kern = new frmKernel("gauss");
            if (Kern.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                Filter GaussFilt = new Filter();
                GeoImageTools gito = new GeoImageTools(GeoImage);
                double[,] kernel = GaussFilt.lowPassKernelGauss(Kern.kernelLength);
                undoBand = currentBand;
                currentBand = GaussFilt.ConvolSingleBand(kernel, currentBand, GeoImage.Ncols, GeoImage.Nrows);
                imw.DrawImage(GeoImage, currentBand, colorpal);
                this.Cursor = Cursors.Default;
            }
        }

        private void highpassFilterToolStripMenuItem_Click(object sender, EventArgs e) // activates high pass filter with gauss kernel
        {
            frmKernel GaussKern = new frmKernel("gauss");
            if (GaussKern.ShowDialog() == DialogResult.OK)
            {
                undoBand = currentBand;
                this.Cursor = Cursors.WaitCursor;
                Filter filt = new Filter();
                byte[] byteOrig = currentBand;
                byte[] byteSmoothed = filt.ConvolSingleBand(GaussKern.Kernel, currentBand, GeoImage.Ncols, GeoImage.Nrows);
                GeoImageTools gtools = new GeoImageTools(GeoImage);
                currentBand = gtools.combine2Images(GeoImageTools.OperationType.Minus, byteOrig, byteSmoothed);
                imw.DrawImage(GeoImage, currentBand, colorpal);
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region header functions
        private void tsOnOffHeader_Click(object sender, EventArgs e)  // switches on and off the header visibility
        {
            splitContainer1.Panel1Collapsed = !splitContainer1.Panel1Collapsed;
            if (splitContainer1.Panel1Collapsed)
            {
                tabLayers.Visible = false;
                tsOnOffHeader.BackColor = Color.LightGray;
                tsOnOffHeader.ToolTipText = "Header and layer list ON";
            }
            else
            {
                tabLayers.Visible = true;
                tsOnOffHeader.BackColor = DefaultBackColor;
                tsOnOffHeader.ToolTipText = "Header and layer list OFF";
            }
        }

        private void tbHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (GeoImage.FileType != GeoImageData.fTypes.GWH) { return; }
            if (e.Button == MouseButtons.Right)
            {
                EditHeader editgwHead = new EditHeader(GeoImage);
                editgwHead.ShowDialog();
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmnHeaderEdit.Close();
        }
        #endregion

        #region save result
        void saveResultAsGwrFileToolStripMenuItem_Click(object sender, EventArgs e)  // saves result into giwer format
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Giwer header|*.gwh";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                GeoImageTools gitu = new GeoImageTools(GeoImage);
                frmTextInput tbInput = new frmTextInput("Comment");
                tbInput.ShowDialog();
                string desc = tbInput.inpuText;
                gitu.saveHeader2Giwer(sf.FileName);
                gitu.saveOneBandResultAsGiwerFormat(sf.FileName, currentBand, desc);
                MessageBox.Show("'" + Path.GetFileName(sf.FileName) + "' saved successfuly");
            }
        }

        private void saveResultAsABitmapToolStripMenuItem_Click(object sender, EventArgs e)  // saves result as a bitmap file (tif, jpg)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Png files|*.png|Jpg files|*.jpg|Tif files|*.tif";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                Image bmpSave = imw.GetImage();
                string ext = Path.GetExtension(sf.FileName);
                if (ext.ToLower() == ".jpg")
                {
                    bmpSave.Save(sf.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                if (ext.ToLower() == ".tif")
                {
                    bmpSave.Save(sf.FileName, System.Drawing.Imaging.ImageFormat.Tiff);
                }
                if (ext.ToLower() == ".png")
                {
                    bmpSave.Save(sf.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }
        #endregion

        #region separete_color_bands
        private void getRedBandToolStripMenuItem_Click(object sender, EventArgs e) // gets and displays red band
        {
            undoBand = currentBand;
            GeoImageTools gito = new GeoImageTools(GeoImage);
            //iw.InitImage(gito.getAnRGBBand(0));
            //iw.Visible = true;
        }

        private void getGreenBandToolStripMenuItem_Click(object sender, EventArgs e)// gets and displays green band
        {
            undoBand = currentBand;
            GeoImageTools gito = new GeoImageTools(GeoImage);
            //iw.InitImage(gito.getAnRGBBand(1));
            //iw.Visible = true;
        }

        private void getBlueBandToolStripMenuItem_Click(object sender, EventArgs e)// gets and displays blue band
        {
            undoBand = currentBand;
            GeoImageTools gito = new GeoImageTools(GeoImage);
            //iw.InitImage(gito.getAnRGBBand(2));
            //iw.Visible = true;
        }
        #endregion

        #region image_conversions

        private void convertJpgToTif24bppRgbMenuItem_Click(object sender, EventArgs e) //activates conversion function from jpeg with any color depth to 24 bits jpeg
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Jpg|*.jpg";
            of.Multiselect = true;
            if (of.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                foreach (string item in of.FileNames)
                {
                    string fn = item;
                    GeoImageTools gmt = new GeoImageTools();
                    gmt.convertImageFromJpg2Tif(fn);
                    GC.Collect();
                }
                this.Cursor = Cursors.Default;
                MessageBox.Show("Conversion succeeded");
            }
        }

        private void convertTif2JpgMenuItem_Click(object sender, EventArgs e)  // activates tif converter to jpg
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "tif | *.tif";
            of.Multiselect = true;
            if (of.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                foreach (string item in of.FileNames)
                {
                    string fn = item;
                    GeoImageTools gmt = new GeoImageTools();
                    gmt.convertImageFromTif2Jpg(fn);
                    GC.Collect();
                }
                this.Cursor = Cursors.Default;
                MessageBox.Show("Conversion succeeded");
            }
        }

        private void tiffConvert48to24ToolStripMenuItem_Click(object sender, EventArgs e) // converts 48 bits tiff files to 24 bits
        {
            OpenFileDialog of = new OpenFileDialog();
            of.InitialDirectory = TifDataFolder;
            of.Filter = "Tif files | *.tif;*.tiff";
            of.Multiselect = true;
            if (of.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                foreach (string item in of.FileNames)
                {
                    string fn = item;
                    GeoImageTools gmt = new GeoImageTools();
                    gmt.convertImageFromTif48ToTif24(fn);
                }
                this.Cursor = Cursors.Default;
                MessageBox.Show("Conversion succeeded");
            }
        }

        private void convertJpg48BitsTo24BitsToolStripMenuItem_Click(object sender, EventArgs e) // converts 48 bits jpeg files to 24 bits
        {
            OpenFileDialog of = new OpenFileDialog();
            of.InitialDirectory = JpgDataFolder;
            of.Filter = "Jpg files | *.jpg;*.jpeg";
            of.Multiselect = true;
            if (of.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                foreach (string item in of.FileNames)
                {
                    string fn = item;
                    GeoImageTools gmt = new GeoImageTools();
                    gmt.convertImageFromJpg48ToJpg24(fn);
                }
                this.Cursor = Cursors.Default;
                MessageBox.Show("Conversion succeeded");
            }
        }
        #endregion

        #region layers viewer functions

        private void displayThisBandInANewWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedBand = (int)LayerViewer.Tag;
            GeoImageTools gt = new GeoImageTools(GeoImage);
            currentBand = gt.getOneBandBytes(selectedBand);
            gt.displayBandOnNewForm(selectedBand, GeoImage, currentBand, colorpal);
        }

        private void tsbttnClearLayerList_Click(object sender, EventArgs e) // clear layer list treeview
        {
            LayerViewer.Nodes.Clear();
            toolStripLayer.Enabled = false;
            setControls(GeoImageData.fTypes.GWH, false);
            imw.Clear(GeoImage);
            imw.pbCompas.Visible = false;
            project.initProject();
            tbHeader.Text = "";
            tbEXIF.Text = "";
            saveProjectFileToolStripMenuItem.Enabled = false;
            tbProjDesc.Text = "";
            project.ProjectFileName = "";
            tslblFileName.Text = "";
            this.Text = "Data stock";
        }

        private void tsbttnExpandList_Click(object sender, EventArgs e)  // expands layer treeview
        {
            LayerViewer.ExpandAll();
        }

        private void tsbttnCollapsList_Click(object sender, EventArgs e) // collapses layer treeview
        {
            LayerViewer.CollapseAll();
        }

        void fillBands(TreeNode tnode)  // fills 'layerViewer' TreeViewer with band names
        {
            for (int i = 0; i < GeoImage.Nbands; i++)
            {
                LayerViewer.SelectedNode = tnode;
                tnode.Nodes.Add("Band_" + i.ToString());
            }
        }

        private void mnuRemove_Click(object sender, EventArgs e) // removes the selected item from the LayerViewer list
        {
            LayerViewer.SelectedNode.Remove();
            imw.Clear(GeoImage);
            if (LayerViewer.Nodes.Count == 0) { saveProjectFileToolStripMenuItem.Enabled = false; toolStripLayer.Enabled = false; }
        }

        private void LayerViewer_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)  // selects an item from the LayerViewer list
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode parent = e.Node.Parent;
                TreeNode removingNode = new TreeNode();
                if (parent == null)
                {
                    LayerViewer.SelectedNode = LayerViewer.Nodes[e.Node.Index];
                    removingNode = LayerViewer.Nodes[e.Node.Index];
                    cmnRemove.Items[0].Text = "Click here to REMOVE the file '" + removingNode.Text + "' from the list";
                    cmnRemove.Show(LayerViewer, new Point(e.X + 20, e.Y));
                }
                else
                {
                    GeoImage.FileName = LayerViewer.Nodes[parent.Index].Tag.ToString();
                    cmnDisplay.Items[0].Text = "Click here to display this band '" + e.Node.Index + "' in new window";
                    LayerViewer.Tag = e.Node.Index;
                    cmnDisplay.Show(LayerViewer, new Point(e.X + 20, e.Y));
                }
            }
        }

        private void LayerViewer_AfterSelect(object sender, TreeViewEventArgs e)  // it happens if a LayerViewer item is clicked
        {
            saveProjectFileToolStripMenuItem.Enabled = true;
            toolStripLayer.Enabled = true;

            TreeNode parent = e.Node.Parent;
            if (parent != null)  // if a sub node is clicked
            {
                GeoImage.FileName = LayerViewer.Nodes[parent.Index].Tag.ToString();
                tslblFileName.Text = "File: " + Path.GetFileName(GeoImage.FileName);
                if (GeoImage.FileType != GeoImageData.fTypes.GWH && GeoImage.FileType != GeoImageData.fTypes.BIL && GeoImage.FileType != GeoImageData.fTypes.BSQ && GeoImage.FileType != GeoImageData.fTypes.ENVI && GeoImage.FileType != GeoImageData.fTypes.DDM) // if ftype = TIF or JPG
                {
                    setControls(GeoImage.FileType, true);
                }
                else // if ftype = GWH or BIL, BSQ or DDM
                {
                    int selectedBand = LayerViewer.SelectedNode.Index;
                    this.Cursor = Cursors.WaitCursor;
                    GeoImageTools GTools = new GeoImageTools(GeoImage);
                    currentBand = GTools.getOneBandBytes(selectedBand);
                    if (GeoImage.FileType == GeoImageData.fTypes.GWH) imw.tsbttnSpectrum.Enabled = true;
                    else imw.tsbttnSpectrum.Enabled = false;
                    imw.Visible = true;
                    setControls(GeoImage.FileType, true);

                    if (GeoImage.FileType == GeoImageData.fTypes.DDM)  // DDM file
                    {
                        setControls(GeoImage.FileType, false);  // DDM egyelőre nem konvertálható gwr.be
                        ddm = new dtm();
                        ddm.FileName = GeoImage.FileName;
                        GeoImageTools gimt = new GeoImageTools(GeoImage);
                        currentBand = gimt.convertDDM2ByteArrayforDisplay(ddm, GeoImage);
                        imw.Clear(GeoImage);
                        imw.DrawImageDDM(GeoImage, currentBand, elevation, colorpal);
                        imw.Enabled = true;
                        imw.Show();
                    }
                    else  // 
                    {
                        imw.Show();
                        imw.Clear(GeoImage);
                        imw.DrawImage(GeoImage, currentBand, colorpal);
                        imw.Enabled = true;
                    }
                    printPars("3d");
                    this.Cursor = Cursors.Default;
                }
            }
            else   // if a main node is clicked
            {
                GeoImage.FileName = LayerViewer.Nodes[e.Node.Index].Tag.ToString();
                tslblFileName.Text = "File: " + Path.GetFileName(GeoImage.FileName);
                setControls(GeoImageData.fTypes.UNKOWN, true);  //setControls(GeoImage.FileType, true);
                imw.Clear(GeoImage);
                //imw.Visible = false;
                printPars("");
                settbDronEXIF(GeoImage.FileType);
                //settbEXIF(GeoImage.FileType);
                currentBand = null;
                if (GeoImage.FileType == GeoImageData.fTypes.JPG || GeoImage.FileType == GeoImageData.fTypes.TIF)
                {
                    if (GeoImage.Nbands == 3 || GeoImage.Nbands == 1)
                    {
                        imw.LoadImageFromFile(GeoImage.FileName);
                        imw.Visible = true;
                        imw.Enabled = false;
                    }
                }
            }
        }
        #endregion

        #region delete gwr format images
        private void deleteImageToolStripMenuItem_Click(object sender, EventArgs e) // deletes a selected giwer format file (both gwh and gwr files)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Multiselect = true;
            of.Filter = "Giwer files|*.gwh";
            if (of.ShowDialog() == DialogResult.OK)
            {
                foreach(string item in of.FileNames)
                {
                    string FolderName = Path.GetDirectoryName(item) + "\\" + Path.GetFileNameWithoutExtension(item);
                    File.Delete(item);
                    var dir = new DirectoryInfo(FolderName);
                    dir.Delete(true);
                }
            MessageBox.Show("The files was successfuly deleted");
            }
        }
        #endregion

        #region clustering
        private void ClusteringToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Histogram3 hst = new Histogram3();
            this.Cursor = Cursors.WaitCursor;
            segmentationEdge seg1 = new segmentationEdge(GeoImage);
            undoBand = currentBand;
            byte[] bnd = new byte[currentBand.Length];
            Filter fil = new Filter();
            currentBand = hst.HistogramEqualization(currentBand);
            currentBand = fil.MedianFilterOneBand(currentBand, 7, GeoImage.Ncols, GeoImage.Nrows);
            bnd = seg1.computeBoundaries(currentBand);
            currentBand = bnd;
            imw.Show();
            imw.Clear(GeoImage);
            imw.DrawImage(GeoImage, currentBand, colorpal);
            imw.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        private void clusteringToolStripMenuItem1_Click(object sender, EventArgs e)  // activates clustering
        {
            ClusteringForm clustForm = initClusteringForm();

            clustForm.SelectCurrentBand();
            clustForm.ShowDialog();

            handleClusteringFormResults(clustForm);
        }

        private void clusteringToolStripMenuItem_Click(object sender, EventArgs e) // activates clustering
        {
            ClusteringForm clustForm = initClusteringForm();

            clustForm.ShowDialog();

            handleClusteringFormResults(clustForm);
        }

        private ClusteringForm initClusteringForm() // initializes the clustering form
        {
            ClusteringForm clustForm;
            if (undoBand == null || undoBand == currentBand)
                clustForm = new ClusteringForm(GeoImage);
            else
                clustForm = new ClusteringForm(GeoImage, currentBand);
            return clustForm;
        }

        private void handleClusteringFormResults(ClusteringForm clustForm) // activates clustering
        {
            if (clustForm.DialogResult == DialogResult.OK)
            {
                undoBand = currentBand;
                currentBand = clustForm.Result;
                imw.DrawImage(GeoImage, currentBand, colorpal);
                setControls(GeoImage.FileType, true);
            }
        }
        #endregion

        #region combine_images
        private void combineCurrentImageWithToolStripMenuItem_Click_1(object sender, EventArgs e) // combine two images:  band0 with any other image file's band_0
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Giwer file|*.gwh";
            if (of.ShowDialog() == DialogResult.OK)
            {
                undoBand = currentBand;
                byte[] fileToCombine = new byte[currentBand.Length];
                GeoImageTools gtools = new GeoImageTools(GeoImage);
                string fname = Path.GetDirectoryName(of.FileName) + "\\" + Path.GetFileNameWithoutExtension(of.FileName) + "\\0.gwr";
                fileToCombine = gtools.readGwrFile(fname);
                inputBox ib = new inputBox("Set type of operation in the image combination");
                if (ib.ShowDialog() == DialogResult.OK)
                {
                    currentBand = gtools.combine2Images((GeoImageTools.OperationType)ib.operationType, currentBand, fileToCombine);
                    imw.Show();
                    imw.Clear(GeoImage);
                    imw.DrawImage(GeoImage, currentBand, colorpal);
                    imw.Enabled = true;
                }
            }
        }

        private void combineCurrentBandWithAnOtherToolStripMenuItem_Click(object sender, EventArgs e) // combine two images: current band with an other band
        {
            frmCombineImages combi = new frmCombineImages(GeoImage);
            if (combi.ShowDialog() == DialogResult.OK)
            {
                undoBand = currentBand;
                byte[] fileToCombine1 = new byte[currentBand.Length];
                byte[] fileToCombine2 = new byte[currentBand.Length];
                GeoImageTools gtools = new GeoImageTools(GeoImage);
                string fname1 = combi.filename1;
                string fname2 = combi.filename2;
                fileToCombine1 = gtools.readGwrFile(fname1);
                fileToCombine2 = gtools.readGwrFile(fname2);
                currentBand = gtools.combine2Images((GeoImageTools.OperationType)combi.operationType, fileToCombine1, fileToCombine2);
                imw.Show();
                imw.Clear(GeoImage);
                imw.DrawImage(GeoImage, currentBand, colorpal);
                imw.Enabled = true;
            }
        }

        private void combineCurrentImageWithToolStripMenuItem_Click(object sender, EventArgs e) // combines the current band with any other band
        {
            undoBand = currentBand;
            //OpenFileDialog of = new OpenFileDialog();
            //of.Filter = "Giwer file|*.gwh";
            //if (of.ShowDialog()==DialogResult.OK)
            //{
            //    byte[] fileToCombine = new byte[currentBand.Length];
            //    GeoImageTools gtools = new GeoImageTools(GeoImage);
            //    string fname = Path.GetDirectoryName(of.FileName) + "\\" + Path.GetFileNameWithoutExtension(of.FileName) + "\\0.gwr";
            //    fileToCombine = gtools.readGwrFile(fname);
            //    currentBand = gtools.combine2Images(GeoImageTools.OperationType.Plus, currentBand, fileToCombine);
            //    iw.InitImage(gtools.convertOneBandBytesto8bitBitmap(currentBand));
            //    iw.Visible = true;
            //}
        }
        #endregion

        #region derivative_filters

        private void laplacefilterToolStripMenuItem_Click(object sender, EventArgs e)  // calls laplace filter function applied to a current giwer file
        {
            undoBand = currentBand;
            this.Cursor = Cursors.WaitCursor;
            Filter LaplFilt = new Filter();
            currentBand = LaplFilt.LaplaceOneBand(currentBand, GeoImage.Ncols, GeoImage.Nrows);
            imw.DrawImage(GeoImage, currentBand, colorpal);
            this.Cursor = Cursors.Default;
        }

        private void derivateToolStripMenuItem_Click(object sender, EventArgs e)  // makes derivative of the current band
        {
            undoBand = currentBand;
            StatMath deriv = new StatMath(GeoImage);
            currentBand = deriv.derivatives(currentBand);
            imw.Show();
            imw.Clear(GeoImage);
            imw.DrawImage(GeoImage, currentBand, colorpal);
            imw.Enabled = true;
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)  // activates sobel filter
        {
            undoBand = currentBand;
            Filter sobel = new Filter();
            currentBand = sobel.Sobel(currentBand,GeoImage.Ncols,GeoImage.Nrows);
            imw.Show();
            imw.Clear(GeoImage);
            imw.DrawImage(GeoImage, currentBand, colorpal);
            imw.Enabled = true;
        }

        private void prewittToolStripMenuItem_Click(object sender, EventArgs e) // activates prewitt filter
        {
            undoBand = currentBand;
            Filter prewitt = new Filter();
            currentBand = prewitt.Prewitt(currentBand, GeoImage.Ncols, GeoImage.Nrows);
            imw.Show();
            imw.Clear(GeoImage);
            imw.DrawImage(GeoImage, currentBand, colorpal);
            imw.Enabled = true;
        }
        #endregion

        #region project_file
        private void openProjectFileToolStripMenuItem_Click(object sender, EventArgs e) //open a project file
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Project files|*.proj";
            of.InitialDirectory = ProjectFolder;
            if (of.ShowDialog()==DialogResult.OK)
            {
                project.initProject();
                GeoImage = new GeoImageData();
                readProjectFile(of.FileName);
                createSimpleWorkflowToolStripMenuItem.Enabled = true;
                saveProjectAsToolStripMenuItem.Enabled = true;
                this.Text = "Data stock --> " + Path.GetFileName(project.ProjectFileName);
                ProjectFolder = Path.GetDirectoryName(of.FileName);
            }
        }

        void readProjectFile(string fileName) // reads a project file
        {
            try
            {
                project.ProjectFileName = fileName;
                tbProjDesc.Text = project.ProjectDescription;
                foreach(string item in project.FileNames)
                {
                    TreeNode actualTreenode = LayerViewer.Nodes.Add(Path.GetFileName(item));
                    LayerViewer.Nodes[actualTreenode.Index].Tag = item;
                    actualTreenode.Tag = item;
                    GeoImage.FileName = item;
                    fillBands(actualTreenode);
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Trouble with '" + fileName + " 'project file");
            }
        }


        private void saveProjectAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfproj = new SaveFileDialog();
            sfproj.Filter = "Project file|*.proj";
            if (sfproj.ShowDialog() == DialogResult.OK)
            {
                project.ProjectDescription = tbProjDesc.Text;
                saveProjectFile(sfproj.FileName);
                project.ProjectFileName = sfproj.FileName;
                this.Text = "Data stock --> " + Path.GetFileName(sfproj.FileName);
            }
        }


        private void saveProjectFileToolStripMenuItem_Click(object sender, EventArgs e) // saves a project file
        {
            project.ProjectDescription = tbProjDesc.Text;
            saveProjectFile(project.ProjectFileName);
        }


        void saveProjectFile(string fileName) // saves project data to a project file
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        sw.WriteLine("#Description:");
                        sw.WriteLine(project.ProjectDescription);
                        sw.WriteLine("#Files:");
                        for (int i = 0; i < LayerViewer.Nodes.Count; i++)
                        {
                            sw.WriteLine(LayerViewer.Nodes[i].Tag);
                        }
                        sw.WriteLine("#Config_data:");
                        foreach (KeyValuePair<string, string> line in conf.config)
                        {
                            sw.WriteLine(line.Key + ", " + line.Value);
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error in writing project file (for instance concurent access");
                }
            }
        }
        #endregion

        #region workflow
        private void runWorkflowBuilderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string WorkflowBuilderPath = Application.StartupPath + @"\workflowBuilder.exe";
            if (File.Exists(WorkflowBuilderPath)) System.Diagnostics.Process.Start(WorkflowBuilderPath);
            else MessageBox.Show("Workflow Builder executable not found.", "Giwer", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void mnuLoadEditWorkflowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Workflows (wkf)|*.wkf";
            of.InitialDirectory = WorkflowFolder;
            if (of.ShowDialog()==DialogResult.OK)
            {
                frmSimpleWorkflow wf = new frmSimpleWorkflow(of.FileName);
                wf.Show();
                WorkflowFolder = Path.GetDirectoryName(of.FileName);
            }
        }

        private void createWorkflowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (project.ProjectFileName != null)
            {
                frmSimpleWorkflow simpleWorkFl = new frmSimpleWorkflow(project.ProjectFileName);
                simpleWorkFl.Show();
            }
            else System.Windows.Forms.MessageBox.Show("There is no project file"); return;
            //GeoImageTools gt = new GeoImageTools();
            //gt.displayBandOnNewForm(GeoImage, currentBand, colorpal);
        }
        #endregion

        #region export
        private void exportToBILToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "BIL format|*.bil";
            sf.InitialDirectory = BilDataFolder;
            if (sf.ShowDialog()==DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                GeoImageTools gimsave = new GeoImageTools(GeoImage);
                gimsave.save2BILformat(sf.FileName);
                this.Cursor = Cursors.Default;
            }
        }


        private void exportToBSQToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "BSQ format|*.bsq";
            sf.InitialDirectory = BilDataFolder;
            if (sf.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                GeoImageTools gimsave = new GeoImageTools(GeoImage);
                gimsave.save2BSQformat(sf.FileName);
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

        #region this close and load
        private void frmDataStock_FormClosed(object sender, FormClosedEventArgs e)  // when form is closed the settings and config parameters are saved
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                Properties.Settings.Default["StartLocation"] = this.Location;
                Properties.Settings.Default["WindowState"] = this.WindowState;
                if (this.WindowState == FormWindowState.Normal) Properties.Settings.Default["FormSize"] = this.Size;
                Properties.Settings.Default["SplitterDistance"] = splitContainer1.SplitterDistance;
                Properties.Settings.Default["OnOffHeader"] = tabLayers.Visible;
                Properties.Settings.Default["OnOffDronTools"] = toolStripDron.Visible;
                Properties.Settings.Default.Save();
            }
            conf.config["BilDataFolder"] = BilDataFolder;
            conf.config["JpgDataFolder"] = JpgDataFolder;
            conf.config["TifDataFolder"] = TifDataFolder;
            conf.config["GiwerDataFolder"] = GiwerDataFolder;
            conf.config["3DDataFolder"] = D3DataFolder;
            conf.config["ProjectFolder"] = ProjectFolder;
            conf.config["WorkflowFolder"] = WorkflowFolder;
            conf.saveConfig();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) // exit application
        {
            Application.Exit();
        }

        private void frmDataStock_Load(object sender, EventArgs e) // ez most nem csinál semmit, csak teszt célt szolgált
        {
            //this.WindowState = FormWindowState.Maximized;
            //GeoImage = new GeoImageData();
            //GeoImage.FileName = @"C:\Users\Elek István\Documents\data\gwr\11.gwh";
            //currentBand = File.ReadAllBytes(@"C:\Users\Elek István\Documents\data\gwr\11\0.gwr");
            //ImageDisplay iDis = new ImageDisplay(currentBand, GeoImage);
            //iDis.Dock = DockStyle.Fill;
            //this.splitContainer1.Panel2.Controls.Add(iDis);

            //Histogram3 h = new Histogram3();
            ////Histogram3 h = new Histogram3(currentBand, GeoImage.FileName);
            ////h.ShowDialog();
            ////byte[] hihi = h.reHisto;
            ////Filter fi = new Filter();
            ////float[] ker = new float[] { 1.5F, 1.9F, 3, 1.9F, 1.5F };
            //////byte[] b = fi.OneDimensionalConvolution(hihi, ker);
            ////byte[] b = fi.OneDimensionalMedian(hihi, 25);
            ////h.drawDiagram(b, "mn", 0, 255);
            ////h.ShowDialog();
            //Segmentation seg = new Segmentation(currentBand);
            //byte[] b = seg.histo; //seg.DiffOneDimension(b, 4);
            //h.drawDiagram(b, "mn", 0, 255);
            //h.ShowDialog();
            //Application.Exit();

            //----------------------------------------------------------------------------
            //Matrix<double> A = DenseMatrix.OfArray(new double[,] { { 1.0, 2.0, 3.0 }, { 4.0, 5.0, 6.0 }, { 7.0, 8.0, 9.0 } });
            //Evd<double> eigen = A.Evd();
            //Matrix<double> eigenvectors = eigen.EigenVectors;
            //Vector<Complex> eigenvalues = eigen.EigenValues;
            //-----------------------------------------------------------------------------
        }
        #endregion




        void settbDronEXIF(GeoImageData.fTypes ftp) // parses a geoimage file exif data from tif and jpg files
        {
            if (GeoImage.FileType == GeoImageData.fTypes.TIF || GeoImage.FileType == GeoImageData.fTypes.JPG)
            {
                string[] exif = GeoImage.getExifData(GeoImage.FileName);
                printExif(exif);
            }
            //if (GeoImage.FileType == GeoImageData.fTypes.GWH || GeoImage.FileType == GeoImageData.fTypes.BIL || GeoImage.FileType == GeoImageData.fTypes.UNKOWN) { tbEXIF.Text = ""; }
        }

        void settbEXIF(GeoImageData.fTypes ftp)
        {
            if (GeoImage.FileType == GeoImageData.fTypes.TIF || GeoImage.FileType == GeoImageData.fTypes.JPG) { string[] exif = GeoImage.getExifData(GeoImage.FileName); printExif(exif); }
            if (GeoImage.FileType == GeoImageData.fTypes.GWH || GeoImage.FileType == GeoImageData.fTypes.BIL || GeoImage.FileType == GeoImageData.fTypes.UNKOWN) { tbEXIF.Text = ""; }
        }


        private void reloadConfigDataToolStripMenuItem_Click(object sender, EventArgs e) // reload config data
        {
            frmConfig conf = new frmConfig();
            JpgDataFolder = conf.config["JpgDataFolder"];
            TifDataFolder = conf.config["TifDataFolder"];
            BilDataFolder = conf.config["BilDataFolder"];
            GiwerDataFolder = conf.config["GiwerDataFolder"];
            D3DataFolder = conf.config["3DDataFolder"];
            ProjectFolder = conf.config["ProjectFolder"];
            WorkflowFolder = conf.config["WorkflowFolder"];
        }


        void upSampling(string fileName) // ez a thermal sávot fogja átmintavételezni a többi kép méretére
        {

        }









        /*void saveMethods2File()
{
    Type myType = (typeof(GeoImageTools));
    MethodInfo[] geoToolsNames = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
    myType = (typeof(GeoImageData));
    MethodInfo[] geoDataNames = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
    myType = (typeof(Filter));
    MethodInfo[] geoFilterNames = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
    myType = (typeof(GeoMultiBandMethods));
    MethodInfo[] geoMultibandNames = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
    myType = (typeof(StatMath));
    MethodInfo[] statMathNames = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
    myType = (typeof(dtm));
    MethodInfo[] dtmNames = myType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

    using (FileStream fs = new FileStream(Application.StartupPath + @"\gwr.fnc", FileMode.Create, FileAccess.Write))
    {
        string spaceline = new string('-', 60);
        using (StreamWriter sw = new StreamWriter(fs))
        {
            string head = "Methods of GeoImageTools " + spaceline.Substring("Methods of GeoImageTools ".Length);
            sw.WriteLine(head);
            for (int i = 0; i < geoToolsNames.Length; i++)
            {
                string s = geoToolsNames[i].ToString();
                sw.WriteLine(s);
            }
            head = "Methods of GeoImageData " + spaceline.Substring("Methods of GeoImageData ".Length);
            sw.WriteLine(head);
            for (int i = 0; i < geoDataNames.Length; i++)
            {
                string s = geoDataNames[i].ToString();
                sw.WriteLine(s);
            }
            head = "Methods of Filter " + spaceline.Substring("Methods of Filter ".Length);
            sw.WriteLine(head);
            for (int i = 0; i < geoFilterNames.Length; i++)
            {
                string s = geoFilterNames[i].ToString();
                sw.WriteLine(s);
            }
            head = "Methods of geoMultiBand " + spaceline.Substring("Methods of geoMultiBand ".Length);
            sw.WriteLine(head);
            for (int i = 0; i < geoMultibandNames.Length; i++)
            {
                string s = geoMultibandNames[i].ToString();
                sw.WriteLine(s);
            }
            head = "Methods of StatMath " + spaceline.Substring("Methods of StatMath ".Length);
            sw.WriteLine(head);
            for (int i = 0; i < statMathNames.Length; i++)
            {
                string s = statMathNames[i].ToString();
                sw.WriteLine(s);
            }
            head = "Methods of Digital terrain " + spaceline.Substring("Methods of digital terrain".Length);
            sw.WriteLine(head);
            for (int i = 0; i < dtmNames.Length; i++)
            {
                string s = dtmNames[i].ToString();
                sw.WriteLine(s);
            }
        }
    }
}*/
    }
}

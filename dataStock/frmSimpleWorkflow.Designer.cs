
namespace Giwer.dataStock
{
    partial class frmSimpleWorkflow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSimpleWorkflow));
            this.grpGiwersFuncs = new System.Windows.Forms.GroupBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.bn = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbGroups = new System.Windows.Forms.ToolStripComboBox();
            this.grpProjectData = new System.Windows.Forms.GroupBox();
            this.tbProjData = new System.Windows.Forms.TextBox();
            this.tabProjdata = new System.Windows.Forms.TabControl();
            this.tabGiwerFunctions = new System.Windows.Forms.TabPage();
            this.lblDesc = new System.Windows.Forms.Label();
            this.tabProjektData = new System.Windows.Forms.TabPage();
            this.tabViewWorkflow = new System.Windows.Forms.TabPage();
            this.tbWorkflowData = new System.Windows.Forms.TextBox();
            this.tabEditWorkflow = new System.Windows.Forms.TabPage();
            this.pg = new System.Windows.Forms.PropertyGrid();
            this.grpSelectedFunctions = new System.Windows.Forms.GroupBox();
            this.bttnSaveWorkflow = new System.Windows.Forms.Button();
            this.bttnCreateWorkflow = new System.Windows.Forms.Button();
            this.bttnDown = new System.Windows.Forms.Button();
            this.bttnUp = new System.Windows.Forms.Button();
            this.bttnRunProcess = new System.Windows.Forms.Button();
            this.bttnCancel = new System.Windows.Forms.Button();
            this.bttnClearSelectedItem = new System.Windows.Forms.Button();
            this.bttnClearList = new System.Windows.Forms.Button();
            this.lstSelectedFunctions = new System.Windows.Forms.ListBox();
            this.contextMenuAdd = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToSelectedFunctionsListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.grpGiwersFuncs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bn)).BeginInit();
            this.bn.SuspendLayout();
            this.grpProjectData.SuspendLayout();
            this.tabProjdata.SuspendLayout();
            this.tabGiwerFunctions.SuspendLayout();
            this.tabProjektData.SuspendLayout();
            this.tabViewWorkflow.SuspendLayout();
            this.tabEditWorkflow.SuspendLayout();
            this.grpSelectedFunctions.SuspendLayout();
            this.contextMenuAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpGiwersFuncs
            // 
            this.grpGiwersFuncs.Controls.Add(this.dgv);
            this.grpGiwersFuncs.Controls.Add(this.bn);
            this.grpGiwersFuncs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGiwersFuncs.Location = new System.Drawing.Point(3, 3);
            this.grpGiwersFuncs.Name = "grpGiwersFuncs";
            this.grpGiwersFuncs.Size = new System.Drawing.Size(351, 547);
            this.grpGiwersFuncs.TabIndex = 2;
            this.grpGiwersFuncs.TabStop = false;
            this.grpGiwersFuncs.Text = "All Giwer\'s functions";
            // 
            // dgv
            // 
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(3, 41);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(345, 503);
            this.dgv.TabIndex = 1;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            this.dgv.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseClick);
            // 
            // bn
            // 
            this.bn.AddNewItem = null;
            this.bn.CountItem = this.bindingNavigatorCountItem;
            this.bn.DeleteItem = null;
            this.bn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.cmbGroups});
            this.bn.Location = new System.Drawing.Point(3, 16);
            this.bn.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bn.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bn.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bn.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bn.Name = "bn";
            this.bn.PositionItem = this.bindingNavigatorPositionItem;
            this.bn.Size = new System.Drawing.Size(345, 25);
            this.bn.TabIndex = 2;
            this.bn.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // cmbGroups
            // 
            this.cmbGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroups.Items.AddRange(new object[] {
            "All functions",
            "GeoImageData functions",
            "GeoImageTools functions",
            "GeoMultiBandMethods functions",
            "Filter functions",
            "StatMath functions",
            "Cluster functions",
            "Display functions"});
            this.cmbGroups.Name = "cmbGroups";
            this.cmbGroups.Size = new System.Drawing.Size(121, 25);
            this.cmbGroups.SelectedIndexChanged += new System.EventHandler(this.cmbGroups_SelectedIndexChanged);
            // 
            // grpProjectData
            // 
            this.grpProjectData.Controls.Add(this.tbProjData);
            this.grpProjectData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpProjectData.Location = new System.Drawing.Point(3, 3);
            this.grpProjectData.Name = "grpProjectData";
            this.grpProjectData.Size = new System.Drawing.Size(351, 547);
            this.grpProjectData.TabIndex = 3;
            this.grpProjectData.TabStop = false;
            this.grpProjectData.Text = "Project data";
            // 
            // tbProjData
            // 
            this.tbProjData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbProjData.Location = new System.Drawing.Point(3, 16);
            this.tbProjData.Multiline = true;
            this.tbProjData.Name = "tbProjData";
            this.tbProjData.ReadOnly = true;
            this.tbProjData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbProjData.Size = new System.Drawing.Size(345, 528);
            this.tbProjData.TabIndex = 0;
            // 
            // tabProjdata
            // 
            this.tabProjdata.Controls.Add(this.tabGiwerFunctions);
            this.tabProjdata.Controls.Add(this.tabProjektData);
            this.tabProjdata.Controls.Add(this.tabViewWorkflow);
            this.tabProjdata.Controls.Add(this.tabEditWorkflow);
            this.tabProjdata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabProjdata.HotTrack = true;
            this.tabProjdata.Location = new System.Drawing.Point(0, 0);
            this.tabProjdata.Name = "tabProjdata";
            this.tabProjdata.SelectedIndex = 0;
            this.tabProjdata.Size = new System.Drawing.Size(365, 579);
            this.tabProjdata.TabIndex = 4;
            // 
            // tabGiwerFunctions
            // 
            this.tabGiwerFunctions.Controls.Add(this.lblDesc);
            this.tabGiwerFunctions.Controls.Add(this.grpGiwersFuncs);
            this.tabGiwerFunctions.Location = new System.Drawing.Point(4, 22);
            this.tabGiwerFunctions.Name = "tabGiwerFunctions";
            this.tabGiwerFunctions.Padding = new System.Windows.Forms.Padding(3);
            this.tabGiwerFunctions.Size = new System.Drawing.Size(357, 553);
            this.tabGiwerFunctions.TabIndex = 1;
            this.tabGiwerFunctions.Text = "Giwer\'s function";
            this.tabGiwerFunctions.UseVisualStyleBackColor = true;
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.BackColor = System.Drawing.Color.Black;
            this.lblDesc.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblDesc.ForeColor = System.Drawing.Color.White;
            this.lblDesc.Location = new System.Drawing.Point(425, 84);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(46, 16);
            this.lblDesc.TabIndex = 5;
            this.lblDesc.Text = "label1";
            this.lblDesc.Visible = false;
            // 
            // tabProjektData
            // 
            this.tabProjektData.CausesValidation = false;
            this.tabProjektData.Controls.Add(this.grpProjectData);
            this.tabProjektData.Location = new System.Drawing.Point(4, 22);
            this.tabProjektData.Name = "tabProjektData";
            this.tabProjektData.Padding = new System.Windows.Forms.Padding(3);
            this.tabProjektData.Size = new System.Drawing.Size(357, 553);
            this.tabProjektData.TabIndex = 0;
            this.tabProjektData.Text = "Project data";
            this.tabProjektData.UseVisualStyleBackColor = true;
            // 
            // tabViewWorkflow
            // 
            this.tabViewWorkflow.Controls.Add(this.tbWorkflowData);
            this.tabViewWorkflow.Location = new System.Drawing.Point(4, 22);
            this.tabViewWorkflow.Name = "tabViewWorkflow";
            this.tabViewWorkflow.Size = new System.Drawing.Size(357, 553);
            this.tabViewWorkflow.TabIndex = 2;
            this.tabViewWorkflow.Text = " View workflow";
            this.tabViewWorkflow.UseVisualStyleBackColor = true;
            // 
            // tbWorkflowData
            // 
            this.tbWorkflowData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbWorkflowData.Location = new System.Drawing.Point(0, 0);
            this.tbWorkflowData.Multiline = true;
            this.tbWorkflowData.Name = "tbWorkflowData";
            this.tbWorkflowData.ReadOnly = true;
            this.tbWorkflowData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbWorkflowData.Size = new System.Drawing.Size(357, 553);
            this.tbWorkflowData.TabIndex = 0;
            // 
            // tabEditWorkflow
            // 
            this.tabEditWorkflow.Controls.Add(this.pg);
            this.tabEditWorkflow.Location = new System.Drawing.Point(4, 22);
            this.tabEditWorkflow.Name = "tabEditWorkflow";
            this.tabEditWorkflow.Size = new System.Drawing.Size(357, 553);
            this.tabEditWorkflow.TabIndex = 3;
            this.tabEditWorkflow.Text = "Edit workflow data";
            this.tabEditWorkflow.UseVisualStyleBackColor = true;
            // 
            // pg
            // 
            this.pg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pg.Location = new System.Drawing.Point(0, 0);
            this.pg.Name = "pg";
            this.pg.Size = new System.Drawing.Size(357, 553);
            this.pg.TabIndex = 0;
            // 
            // grpSelectedFunctions
            // 
            this.grpSelectedFunctions.Controls.Add(this.bttnSaveWorkflow);
            this.grpSelectedFunctions.Controls.Add(this.bttnCreateWorkflow);
            this.grpSelectedFunctions.Controls.Add(this.bttnDown);
            this.grpSelectedFunctions.Controls.Add(this.bttnUp);
            this.grpSelectedFunctions.Controls.Add(this.bttnRunProcess);
            this.grpSelectedFunctions.Controls.Add(this.bttnCancel);
            this.grpSelectedFunctions.Controls.Add(this.bttnClearSelectedItem);
            this.grpSelectedFunctions.Controls.Add(this.bttnClearList);
            this.grpSelectedFunctions.Controls.Add(this.lstSelectedFunctions);
            this.grpSelectedFunctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSelectedFunctions.Location = new System.Drawing.Point(0, 0);
            this.grpSelectedFunctions.Name = "grpSelectedFunctions";
            this.grpSelectedFunctions.Size = new System.Drawing.Size(359, 579);
            this.grpSelectedFunctions.TabIndex = 6;
            this.grpSelectedFunctions.TabStop = false;
            this.grpSelectedFunctions.Text = "Selected functions";
            // 
            // bttnSaveWorkflow
            // 
            this.bttnSaveWorkflow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnSaveWorkflow.Location = new System.Drawing.Point(230, 525);
            this.bttnSaveWorkflow.Name = "bttnSaveWorkflow";
            this.bttnSaveWorkflow.Size = new System.Drawing.Size(93, 39);
            this.bttnSaveWorkflow.TabIndex = 11;
            this.bttnSaveWorkflow.Text = "Save workflow";
            this.bttnSaveWorkflow.UseVisualStyleBackColor = true;
            this.bttnSaveWorkflow.Click += new System.EventHandler(this.bttnSaveWorkflow_Click);
            // 
            // bttnCreateWorkflow
            // 
            this.bttnCreateWorkflow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttnCreateWorkflow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bttnCreateWorkflow.Location = new System.Drawing.Point(103, 525);
            this.bttnCreateWorkflow.Name = "bttnCreateWorkflow";
            this.bttnCreateWorkflow.Size = new System.Drawing.Size(99, 39);
            this.bttnCreateWorkflow.TabIndex = 10;
            this.bttnCreateWorkflow.Text = "Create workflow";
            this.bttnCreateWorkflow.UseVisualStyleBackColor = true;
            this.bttnCreateWorkflow.Click += new System.EventHandler(this.bttnCreateWorkflow_Click);
            // 
            // bttnDown
            // 
            this.bttnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnDown.Enabled = false;
            this.bttnDown.Image = ((System.Drawing.Image)(resources.GetObject("bttnDown.Image")));
            this.bttnDown.Location = new System.Drawing.Point(237, 188);
            this.bttnDown.Name = "bttnDown";
            this.bttnDown.Size = new System.Drawing.Size(38, 41);
            this.bttnDown.TabIndex = 8;
            this.bttnDown.UseVisualStyleBackColor = true;
            this.bttnDown.Click += new System.EventHandler(this.bttnDown_Click);
            // 
            // bttnUp
            // 
            this.bttnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnUp.Enabled = false;
            this.bttnUp.Image = ((System.Drawing.Image)(resources.GetObject("bttnUp.Image")));
            this.bttnUp.Location = new System.Drawing.Point(235, 128);
            this.bttnUp.Name = "bttnUp";
            this.bttnUp.Size = new System.Drawing.Size(40, 41);
            this.bttnUp.TabIndex = 9;
            this.bttnUp.UseVisualStyleBackColor = true;
            this.bttnUp.Click += new System.EventHandler(this.bttnUp_Click);
            // 
            // bttnRunProcess
            // 
            this.bttnRunProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnRunProcess.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bttnRunProcess.Location = new System.Drawing.Point(235, 393);
            this.bttnRunProcess.Name = "bttnRunProcess";
            this.bttnRunProcess.Size = new System.Drawing.Size(112, 71);
            this.bttnRunProcess.TabIndex = 3;
            this.bttnRunProcess.Text = "Run process";
            this.bttnRunProcess.UseVisualStyleBackColor = true;
            // 
            // bttnCancel
            // 
            this.bttnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bttnCancel.Location = new System.Drawing.Point(6, 533);
            this.bttnCancel.Name = "bttnCancel";
            this.bttnCancel.Size = new System.Drawing.Size(75, 23);
            this.bttnCancel.TabIndex = 7;
            this.bttnCancel.Text = "Cancel";
            this.bttnCancel.UseVisualStyleBackColor = true;
            this.bttnCancel.Click += new System.EventHandler(this.bttnCancel_Click);
            // 
            // bttnClearSelectedItem
            // 
            this.bttnClearSelectedItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnClearSelectedItem.Enabled = false;
            this.bttnClearSelectedItem.Location = new System.Drawing.Point(235, 63);
            this.bttnClearSelectedItem.Name = "bttnClearSelectedItem";
            this.bttnClearSelectedItem.Size = new System.Drawing.Size(77, 36);
            this.bttnClearSelectedItem.TabIndex = 2;
            this.bttnClearSelectedItem.Text = "Clear selected item";
            this.bttnClearSelectedItem.UseVisualStyleBackColor = true;
            this.bttnClearSelectedItem.Click += new System.EventHandler(this.bttnClearSelectedItem_Click);
            // 
            // bttnClearList
            // 
            this.bttnClearList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnClearList.Location = new System.Drawing.Point(237, 25);
            this.bttnClearList.Name = "bttnClearList";
            this.bttnClearList.Size = new System.Drawing.Size(75, 23);
            this.bttnClearList.TabIndex = 1;
            this.bttnClearList.Text = "Clear list";
            this.bttnClearList.UseVisualStyleBackColor = true;
            this.bttnClearList.Click += new System.EventHandler(this.bttnClearList_Click);
            // 
            // lstSelectedFunctions
            // 
            this.lstSelectedFunctions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSelectedFunctions.FormattingEnabled = true;
            this.lstSelectedFunctions.Location = new System.Drawing.Point(6, 27);
            this.lstSelectedFunctions.Name = "lstSelectedFunctions";
            this.lstSelectedFunctions.Size = new System.Drawing.Size(208, 485);
            this.lstSelectedFunctions.TabIndex = 0;
            this.lstSelectedFunctions.SelectedIndexChanged += new System.EventHandler(this.lstSelectedFunctions_SelectedIndexChanged);
            // 
            // contextMenuAdd
            // 
            this.contextMenuAdd.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToSelectedFunctionsListToolStripMenuItem,
            this.cancelToolStripMenuItem});
            this.contextMenuAdd.Name = "contextMenuAdd";
            this.contextMenuAdd.Size = new System.Drawing.Size(228, 48);
            // 
            // addToSelectedFunctionsListToolStripMenuItem
            // 
            this.addToSelectedFunctionsListToolStripMenuItem.Name = "addToSelectedFunctionsListToolStripMenuItem";
            this.addToSelectedFunctionsListToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.addToSelectedFunctionsListToolStripMenuItem.Text = "Add to selected functions list";
            this.addToSelectedFunctionsListToolStripMenuItem.Click += new System.EventHandler(this.addToSelectedFunctionsListToolStripMenuItem_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.cancelToolStripMenuItem.Text = "Cancel";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabProjdata);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grpSelectedFunctions);
            this.splitContainer1.Size = new System.Drawing.Size(728, 579);
            this.splitContainer1.SplitterDistance = 365;
            this.splitContainer1.TabIndex = 7;
            // 
            // frmSimpleWorkflow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 579);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSimpleWorkflow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple Workflow for projects";
            this.grpGiwersFuncs.ResumeLayout(false);
            this.grpGiwersFuncs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bn)).EndInit();
            this.bn.ResumeLayout(false);
            this.bn.PerformLayout();
            this.grpProjectData.ResumeLayout(false);
            this.grpProjectData.PerformLayout();
            this.tabProjdata.ResumeLayout(false);
            this.tabGiwerFunctions.ResumeLayout(false);
            this.tabGiwerFunctions.PerformLayout();
            this.tabProjektData.ResumeLayout(false);
            this.tabViewWorkflow.ResumeLayout(false);
            this.tabViewWorkflow.PerformLayout();
            this.tabEditWorkflow.ResumeLayout(false);
            this.grpSelectedFunctions.ResumeLayout(false);
            this.contextMenuAdd.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpGiwersFuncs;
        private System.Windows.Forms.GroupBox grpProjectData;
        private System.Windows.Forms.TextBox tbProjData;
        private System.Windows.Forms.TabControl tabProjdata;
        private System.Windows.Forms.TabPage tabProjektData;
        private System.Windows.Forms.TabPage tabGiwerFunctions;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.GroupBox grpSelectedFunctions;
        private System.Windows.Forms.ListBox lstSelectedFunctions;
        private System.Windows.Forms.Button bttnRunProcess;
        private System.Windows.Forms.Button bttnCancel;
        private System.Windows.Forms.Button bttnClearSelectedItem;
        private System.Windows.Forms.Button bttnClearList;
        private System.Windows.Forms.ContextMenuStrip contextMenuAdd;
        private System.Windows.Forms.ToolStripMenuItem addToSelectedFunctionsListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.Button bttnDown;
        private System.Windows.Forms.Button bttnUp;
        private System.Windows.Forms.Button bttnCreateWorkflow;
        private System.Windows.Forms.BindingNavigator bn;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripComboBox cmbGroups;
        private System.Windows.Forms.TabPage tabViewWorkflow;
        private System.Windows.Forms.TextBox tbWorkflowData;
        private System.Windows.Forms.Button bttnSaveWorkflow;
        private System.Windows.Forms.TabPage tabEditWorkflow;
        private System.Windows.Forms.PropertyGrid pg;
    }
}
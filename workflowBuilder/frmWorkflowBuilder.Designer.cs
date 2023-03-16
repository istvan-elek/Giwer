namespace Giwer.workflowBuilder
{
    partial class WorkflowBuilder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WorkflowBuilder));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createWorkflowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadWorkflowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWorkflowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteWorkflowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstSelectedOperations = new System.Windows.Forms.ListBox();
            this.lstAvailableOperations = new System.Windows.Forms.ListBox();
            this.grpBoxMetadata = new System.Windows.Forms.GroupBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.grpBoxOperations = new System.Windows.Forms.GroupBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.bttnViewProject = new System.Windows.Forms.ToolStripButton();
            this.bttnViewFunctionsDesc = new System.Windows.Forms.ToolStripButton();
            this.progressWorkflow = new System.Windows.Forms.ProgressBar();
            this.tbResultAppendix = new System.Windows.Forms.TextBox();
            this.chkSave = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bttnMinus = new System.Windows.Forms.ToolStripButton();
            this.bttnUp = new System.Windows.Forms.ToolStripButton();
            this.bttnDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bttnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bttnRun = new System.Windows.Forms.ToolStripButton();
            this.btnAddOperation = new System.Windows.Forms.Button();
            this.grpBoxParams = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslProjFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlParams = new System.Windows.Forms.Panel();
            this.mainMenu.SuspendLayout();
            this.grpBoxMetadata.SuspendLayout();
            this.grpBoxOperations.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.grpBoxParams.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.mainMenu.Size = new System.Drawing.Size(574, 24);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createWorkflowToolStripMenuItem,
            this.loadWorkflowToolStripMenuItem,
            this.saveWorkflowToolStripMenuItem,
            this.deleteWorkflowToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // createWorkflowToolStripMenuItem
            // 
            this.createWorkflowToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("createWorkflowToolStripMenuItem.Image")));
            this.createWorkflowToolStripMenuItem.Name = "createWorkflowToolStripMenuItem";
            this.createWorkflowToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.createWorkflowToolStripMenuItem.Text = "New workflow";
            this.createWorkflowToolStripMenuItem.Click += new System.EventHandler(this.createWorkflowToolStripMenuItem_Click);
            // 
            // loadWorkflowToolStripMenuItem
            // 
            this.loadWorkflowToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadWorkflowToolStripMenuItem.Image")));
            this.loadWorkflowToolStripMenuItem.Name = "loadWorkflowToolStripMenuItem";
            this.loadWorkflowToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.loadWorkflowToolStripMenuItem.Text = "Load workflow";
            this.loadWorkflowToolStripMenuItem.Click += new System.EventHandler(this.loadWorkflowToolStripMenuItem_Click);
            // 
            // saveWorkflowToolStripMenuItem
            // 
            this.saveWorkflowToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveWorkflowToolStripMenuItem.Image")));
            this.saveWorkflowToolStripMenuItem.Name = "saveWorkflowToolStripMenuItem";
            this.saveWorkflowToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.saveWorkflowToolStripMenuItem.Text = "Save workflow";
            this.saveWorkflowToolStripMenuItem.Click += new System.EventHandler(this.bttnSave_Click);
            // 
            // deleteWorkflowToolStripMenuItem
            // 
            this.deleteWorkflowToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteWorkflowToolStripMenuItem.Image")));
            this.deleteWorkflowToolStripMenuItem.Name = "deleteWorkflowToolStripMenuItem";
            this.deleteWorkflowToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.deleteWorkflowToolStripMenuItem.Text = "Delete workflow";
            this.deleteWorkflowToolStripMenuItem.Click += new System.EventHandler(this.deleteWorkflowToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(156, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // lstSelectedOperations
            // 
            this.lstSelectedOperations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstSelectedOperations.Enabled = false;
            this.lstSelectedOperations.FormattingEnabled = true;
            this.lstSelectedOperations.HorizontalScrollbar = true;
            this.lstSelectedOperations.Location = new System.Drawing.Point(289, 17);
            this.lstSelectedOperations.Margin = new System.Windows.Forms.Padding(2);
            this.lstSelectedOperations.Name = "lstSelectedOperations";
            this.lstSelectedOperations.Size = new System.Drawing.Size(247, 186);
            this.lstSelectedOperations.TabIndex = 5;
            this.lstSelectedOperations.SelectedIndexChanged += new System.EventHandler(this.lstSelectedOperations_SelectedIndexChanged);
            // 
            // lstAvailableOperations
            // 
            this.lstAvailableOperations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstAvailableOperations.FormattingEnabled = true;
            this.lstAvailableOperations.HorizontalScrollbar = true;
            this.lstAvailableOperations.Location = new System.Drawing.Point(39, 17);
            this.lstAvailableOperations.Margin = new System.Windows.Forms.Padding(2);
            this.lstAvailableOperations.Name = "lstAvailableOperations";
            this.lstAvailableOperations.Size = new System.Drawing.Size(204, 186);
            this.lstAvailableOperations.Sorted = true;
            this.lstAvailableOperations.TabIndex = 6;
            this.lstAvailableOperations.DoubleClick += new System.EventHandler(this.btnAddOperation_Click);
            // 
            // grpBoxMetadata
            // 
            this.grpBoxMetadata.Controls.Add(this.tbDescription);
            this.grpBoxMetadata.Controls.Add(this.label1);
            this.grpBoxMetadata.Controls.Add(this.tbxName);
            this.grpBoxMetadata.Controls.Add(this.lblName);
            this.grpBoxMetadata.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBoxMetadata.Location = new System.Drawing.Point(0, 24);
            this.grpBoxMetadata.Margin = new System.Windows.Forms.Padding(2);
            this.grpBoxMetadata.Name = "grpBoxMetadata";
            this.grpBoxMetadata.Padding = new System.Windows.Forms.Padding(2);
            this.grpBoxMetadata.Size = new System.Drawing.Size(574, 58);
            this.grpBoxMetadata.TabIndex = 7;
            this.grpBoxMetadata.TabStop = false;
            this.grpBoxMetadata.Text = "Metadata";
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDescription.Location = new System.Drawing.Point(301, 8);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(261, 47);
            this.tbDescription.TabIndex = 3;
            this.tbDescription.TextChanged += new System.EventHandler(this.tbDescription_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(232, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Description:";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(87, 22);
            this.tbxName.Margin = new System.Windows.Forms.Padding(2);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(144, 20);
            this.tbxName.TabIndex = 1;
            this.tbxName.TextChanged += new System.EventHandler(this.tbxName_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(4, 24);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(84, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Workflow name:";
            // 
            // grpBoxOperations
            // 
            this.grpBoxOperations.BackColor = System.Drawing.SystemColors.Control;
            this.grpBoxOperations.Controls.Add(this.toolStrip2);
            this.grpBoxOperations.Controls.Add(this.progressWorkflow);
            this.grpBoxOperations.Controls.Add(this.tbResultAppendix);
            this.grpBoxOperations.Controls.Add(this.chkSave);
            this.grpBoxOperations.Controls.Add(this.toolStrip1);
            this.grpBoxOperations.Controls.Add(this.btnAddOperation);
            this.grpBoxOperations.Controls.Add(this.lstSelectedOperations);
            this.grpBoxOperations.Controls.Add(this.lstAvailableOperations);
            this.grpBoxOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxOperations.Location = new System.Drawing.Point(0, 82);
            this.grpBoxOperations.Margin = new System.Windows.Forms.Padding(2);
            this.grpBoxOperations.Name = "grpBoxOperations";
            this.grpBoxOperations.Padding = new System.Windows.Forms.Padding(2);
            this.grpBoxOperations.Size = new System.Drawing.Size(574, 252);
            this.grpBoxOperations.TabIndex = 8;
            this.grpBoxOperations.TabStop = false;
            this.grpBoxOperations.Text = "Operations";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bttnViewProject,
            this.bttnViewFunctionsDesc});
            this.toolStrip2.Location = new System.Drawing.Point(2, 15);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(24, 235);
            this.toolStrip2.TabIndex = 16;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // bttnViewProject
            // 
            this.bttnViewProject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnViewProject.Image = ((System.Drawing.Image)(resources.GetObject("bttnViewProject.Image")));
            this.bttnViewProject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnViewProject.Name = "bttnViewProject";
            this.bttnViewProject.Size = new System.Drawing.Size(21, 20);
            this.bttnViewProject.Text = "toolStripButton1";
            this.bttnViewProject.ToolTipText = "View project files";
            this.bttnViewProject.Click += new System.EventHandler(this.bttnViewProject_Click);
            // 
            // bttnViewFunctionsDesc
            // 
            this.bttnViewFunctionsDesc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnViewFunctionsDesc.Image = ((System.Drawing.Image)(resources.GetObject("bttnViewFunctionsDesc.Image")));
            this.bttnViewFunctionsDesc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnViewFunctionsDesc.Name = "bttnViewFunctionsDesc";
            this.bttnViewFunctionsDesc.Size = new System.Drawing.Size(21, 20);
            this.bttnViewFunctionsDesc.Text = "toolStripButton2";
            this.bttnViewFunctionsDesc.ToolTipText = "View functions\' description";
            this.bttnViewFunctionsDesc.Click += new System.EventHandler(this.bttnViewFunctionsDesc_Click);
            // 
            // progressWorkflow
            // 
            this.progressWorkflow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressWorkflow.Location = new System.Drawing.Point(46, 225);
            this.progressWorkflow.Name = "progressWorkflow";
            this.progressWorkflow.Size = new System.Drawing.Size(144, 14);
            this.progressWorkflow.Step = 1;
            this.progressWorkflow.TabIndex = 15;
            this.progressWorkflow.Visible = false;
            // 
            // tbResultAppendix
            // 
            this.tbResultAppendix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbResultAppendix.Location = new System.Drawing.Point(481, 225);
            this.tbResultAppendix.Name = "tbResultAppendix";
            this.tbResultAppendix.Size = new System.Drawing.Size(88, 20);
            this.tbResultAppendix.TabIndex = 14;
            this.tbResultAppendix.Text = "_res";
            // 
            // chkSave
            // 
            this.chkSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSave.AutoSize = true;
            this.chkSave.Checked = true;
            this.chkSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSave.Location = new System.Drawing.Point(207, 227);
            this.chkSave.Name = "chkSave";
            this.chkSave.Size = new System.Drawing.Size(277, 17);
            this.chkSave.TabIndex = 10;
            this.chkSave.Text = "Save final result in file name + the following appendix:";
            this.chkSave.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bttnMinus,
            this.bttnUp,
            this.bttnDown,
            this.toolStripSeparator2,
            this.bttnSave,
            this.toolStripSeparator3,
            this.bttnRun});
            this.toolStrip1.Location = new System.Drawing.Point(548, 15);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(24, 235);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bttnMinus
            // 
            this.bttnMinus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnMinus.Image = ((System.Drawing.Image)(resources.GetObject("bttnMinus.Image")));
            this.bttnMinus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnMinus.Name = "bttnMinus";
            this.bttnMinus.Size = new System.Drawing.Size(21, 20);
            this.bttnMinus.Text = "Remove item from list";
            this.bttnMinus.Click += new System.EventHandler(this.btnRemoveOperation_Click);
            // 
            // bttnUp
            // 
            this.bttnUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnUp.Image = ((System.Drawing.Image)(resources.GetObject("bttnUp.Image")));
            this.bttnUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnUp.Name = "bttnUp";
            this.bttnUp.Size = new System.Drawing.Size(21, 20);
            this.bttnUp.Text = "Move up";
            this.bttnUp.Click += new System.EventHandler(this.btnUpOperation_Click);
            // 
            // bttnDown
            // 
            this.bttnDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnDown.Image = ((System.Drawing.Image)(resources.GetObject("bttnDown.Image")));
            this.bttnDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnDown.Name = "bttnDown";
            this.bttnDown.Size = new System.Drawing.Size(21, 20);
            this.bttnDown.Text = "Move down";
            this.bttnDown.Click += new System.EventHandler(this.btnDownOperation_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(21, 6);
            // 
            // bttnSave
            // 
            this.bttnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnSave.Enabled = false;
            this.bttnSave.Image = ((System.Drawing.Image)(resources.GetObject("bttnSave.Image")));
            this.bttnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnSave.Name = "bttnSave";
            this.bttnSave.Size = new System.Drawing.Size(21, 20);
            this.bttnSave.Text = "Save workflow";
            this.bttnSave.Click += new System.EventHandler(this.bttnSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(21, 6);
            // 
            // bttnRun
            // 
            this.bttnRun.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnRun.Enabled = false;
            this.bttnRun.Image = ((System.Drawing.Image)(resources.GetObject("bttnRun.Image")));
            this.bttnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnRun.Name = "bttnRun";
            this.bttnRun.Size = new System.Drawing.Size(21, 20);
            this.bttnRun.Text = "Run workflow";
            this.bttnRun.Click += new System.EventHandler(this.bttnRun_Click);
            // 
            // btnAddOperation
            // 
            this.btnAddOperation.Image = ((System.Drawing.Image)(resources.GetObject("btnAddOperation.Image")));
            this.btnAddOperation.Location = new System.Drawing.Point(257, 17);
            this.btnAddOperation.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddOperation.Name = "btnAddOperation";
            this.btnAddOperation.Size = new System.Drawing.Size(20, 20);
            this.btnAddOperation.TabIndex = 7;
            this.btnAddOperation.UseVisualStyleBackColor = true;
            this.btnAddOperation.Click += new System.EventHandler(this.btnAddOperation_Click);
            // 
            // grpBoxParams
            // 
            this.grpBoxParams.Controls.Add(this.statusStrip1);
            this.grpBoxParams.Controls.Add(this.pnlParams);
            this.grpBoxParams.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpBoxParams.Location = new System.Drawing.Point(0, 334);
            this.grpBoxParams.Margin = new System.Windows.Forms.Padding(2);
            this.grpBoxParams.Name = "grpBoxParams";
            this.grpBoxParams.Padding = new System.Windows.Forms.Padding(2);
            this.grpBoxParams.Size = new System.Drawing.Size(574, 185);
            this.grpBoxParams.TabIndex = 9;
            this.grpBoxParams.TabStop = false;
            this.grpBoxParams.Text = "Parameters";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslProjFile});
            this.statusStrip1.Location = new System.Drawing.Point(2, 161);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(570, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslProjFile
            // 
            this.tslProjFile.Name = "tslProjFile";
            this.tslProjFile.Size = new System.Drawing.Size(0, 17);
            // 
            // pnlParams
            // 
            this.pnlParams.AutoScroll = true;
            this.pnlParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlParams.Location = new System.Drawing.Point(2, 15);
            this.pnlParams.Margin = new System.Windows.Forms.Padding(2);
            this.pnlParams.Name = "pnlParams";
            this.pnlParams.Size = new System.Drawing.Size(570, 168);
            this.pnlParams.TabIndex = 0;
            // 
            // WorkflowBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 519);
            this.Controls.Add(this.grpBoxOperations);
            this.Controls.Add(this.grpBoxParams);
            this.Controls.Add(this.grpBoxMetadata);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(590, 452);
            this.Name = "WorkflowBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Workflow Builder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WorkflowBuilder_FormClosed);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.grpBoxMetadata.ResumeLayout(false);
            this.grpBoxMetadata.PerformLayout();
            this.grpBoxOperations.ResumeLayout(false);
            this.grpBoxOperations.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.grpBoxParams.ResumeLayout(false);
            this.grpBoxParams.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ListBox lstSelectedOperations;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ListBox lstAvailableOperations;
        private System.Windows.Forms.ToolStripMenuItem createWorkflowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadWorkflowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteWorkflowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox grpBoxMetadata;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.GroupBox grpBoxOperations;
        private System.Windows.Forms.Button btnAddOperation;
        private System.Windows.Forms.GroupBox grpBoxParams;
        private System.Windows.Forms.Panel pnlParams;
        private System.Windows.Forms.ToolStripMenuItem saveWorkflowToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bttnMinus;
        private System.Windows.Forms.ToolStripButton bttnUp;
        private System.Windows.Forms.ToolStripButton bttnDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton bttnRun;
        private System.Windows.Forms.ToolStripButton bttnSave;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TextBox tbResultAppendix;
        private System.Windows.Forms.CheckBox chkSave;
        private System.Windows.Forms.ProgressBar progressWorkflow;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton bttnViewProject;
        private System.Windows.Forms.ToolStripButton bttnViewFunctionsDesc;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslProjFile;
    }
}


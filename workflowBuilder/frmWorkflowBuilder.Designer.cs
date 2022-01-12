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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bttnMinus = new System.Windows.Forms.ToolStripButton();
            this.bttnUp = new System.Windows.Forms.ToolStripButton();
            this.bttnDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bttnRun = new System.Windows.Forms.ToolStripButton();
            this.bttnSave = new System.Windows.Forms.ToolStripButton();
            this.btnAddOperation = new System.Windows.Forms.Button();
            this.grpBoxParams = new System.Windows.Forms.GroupBox();
            this.pnlParams = new System.Windows.Forms.Panel();
            this.mainMenu.SuspendLayout();
            this.grpBoxMetadata.SuspendLayout();
            this.grpBoxOperations.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.grpBoxParams.SuspendLayout();
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
            this.createWorkflowToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.createWorkflowToolStripMenuItem.Text = "Create new workflow";
            this.createWorkflowToolStripMenuItem.Click += new System.EventHandler(this.createWorkflowToolStripMenuItem_Click);
            // 
            // loadWorkflowToolStripMenuItem
            // 
            this.loadWorkflowToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadWorkflowToolStripMenuItem.Image")));
            this.loadWorkflowToolStripMenuItem.Name = "loadWorkflowToolStripMenuItem";
            this.loadWorkflowToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.loadWorkflowToolStripMenuItem.Text = "Load workflow";
            this.loadWorkflowToolStripMenuItem.Click += new System.EventHandler(this.loadWorkflowToolStripMenuItem_Click);
            // 
            // saveWorkflowToolStripMenuItem
            // 
            this.saveWorkflowToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveWorkflowToolStripMenuItem.Image")));
            this.saveWorkflowToolStripMenuItem.Name = "saveWorkflowToolStripMenuItem";
            this.saveWorkflowToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.saveWorkflowToolStripMenuItem.Text = "Save workflow";
            this.saveWorkflowToolStripMenuItem.Click += new System.EventHandler(this.bttnSave_Click);
            // 
            // deleteWorkflowToolStripMenuItem
            // 
            this.deleteWorkflowToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteWorkflowToolStripMenuItem.Image")));
            this.deleteWorkflowToolStripMenuItem.Name = "deleteWorkflowToolStripMenuItem";
            this.deleteWorkflowToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.deleteWorkflowToolStripMenuItem.Text = "Delete workflow";
            this.deleteWorkflowToolStripMenuItem.Click += new System.EventHandler(this.deleteWorkflowToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
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
            this.lstSelectedOperations.Size = new System.Drawing.Size(247, 316);
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
            this.lstAvailableOperations.Location = new System.Drawing.Point(4, 17);
            this.lstAvailableOperations.Margin = new System.Windows.Forms.Padding(2);
            this.lstAvailableOperations.Name = "lstAvailableOperations";
            this.lstAvailableOperations.Size = new System.Drawing.Size(239, 316);
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
            this.tbxName.Location = new System.Drawing.Point(46, 24);
            this.tbxName.Margin = new System.Windows.Forms.Padding(2);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(152, 20);
            this.tbxName.TabIndex = 1;
            this.tbxName.TextChanged += new System.EventHandler(this.tbxName_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(4, 24);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name:";
            // 
            // grpBoxOperations
            // 
            this.grpBoxOperations.BackColor = System.Drawing.SystemColors.Control;
            this.grpBoxOperations.Controls.Add(this.toolStrip1);
            this.grpBoxOperations.Controls.Add(this.btnAddOperation);
            this.grpBoxOperations.Controls.Add(this.lstSelectedOperations);
            this.grpBoxOperations.Controls.Add(this.lstAvailableOperations);
            this.grpBoxOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxOperations.Location = new System.Drawing.Point(0, 82);
            this.grpBoxOperations.Margin = new System.Windows.Forms.Padding(2);
            this.grpBoxOperations.Name = "grpBoxOperations";
            this.grpBoxOperations.Padding = new System.Windows.Forms.Padding(2);
            this.grpBoxOperations.Size = new System.Drawing.Size(574, 359);
            this.grpBoxOperations.TabIndex = 8;
            this.grpBoxOperations.TabStop = false;
            this.grpBoxOperations.Text = "Operations";
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
            this.bttnRun,
            this.bttnSave});
            this.toolStrip1.Location = new System.Drawing.Point(548, 15);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(24, 342);
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
            this.grpBoxParams.Controls.Add(this.pnlParams);
            this.grpBoxParams.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpBoxParams.Location = new System.Drawing.Point(0, 441);
            this.grpBoxParams.Margin = new System.Windows.Forms.Padding(2);
            this.grpBoxParams.Name = "grpBoxParams";
            this.grpBoxParams.Padding = new System.Windows.Forms.Padding(2);
            this.grpBoxParams.Size = new System.Drawing.Size(574, 131);
            this.grpBoxParams.TabIndex = 9;
            this.grpBoxParams.TabStop = false;
            this.grpBoxParams.Text = "Parameters";
            // 
            // pnlParams
            // 
            this.pnlParams.AutoScroll = true;
            this.pnlParams.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlParams.Location = new System.Drawing.Point(2, 15);
            this.pnlParams.Margin = new System.Windows.Forms.Padding(2);
            this.pnlParams.Name = "pnlParams";
            this.pnlParams.Size = new System.Drawing.Size(570, 114);
            this.pnlParams.TabIndex = 0;
            // 
            // WorkflowBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 572);
            this.Controls.Add(this.grpBoxOperations);
            this.Controls.Add(this.grpBoxParams);
            this.Controls.Add(this.grpBoxMetadata);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
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
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.grpBoxParams.ResumeLayout(false);
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
    }
}


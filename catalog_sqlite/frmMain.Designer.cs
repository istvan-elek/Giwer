namespace catalog
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bn = new System.Windows.Forms.BindingNavigator(this.components);
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bttnFolderTree = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblCursorPos = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bttnAddFolderContent = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.bttnImageViewer = new System.Windows.Forms.ToolStripButton();
            this.bttnDisplayEXIF = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.bttnDisplayReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.tspb = new System.Windows.Forms.ToolStripProgressBar();
            this.bttnQuery = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.bttnSelectAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.bttnViewOnMap = new System.Windows.Forms.ToolStripButton();
            this.tbSqlCommand = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.dbConnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.CreateNewCatalogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.CatalogResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imglist = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bn)).BeginInit();
            this.bn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(726, 363);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_CellMouseClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellValueChanged);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_RowHeaderMouseClick);
            // 
            // bn
            // 
            this.bn.AddNewItem = null;
            this.bn.BindingSource = this.bs;
            this.bn.CountItem = this.toolStripLabel1;
            this.bn.CountItemFormat = "cursor position:";
            this.bn.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bn.Enabled = false;
            this.bn.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bttnFolderTree,
            this.toolStripSeparator5,
            this.toolStripButton3,
            this.toolStripButton4,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.lblCursorPos,
            this.toolStripSeparator2,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripSeparator3,
            this.bindingNavigatorAddNewItem,
            this.bttnAddFolderContent,
            this.toolStripSeparator4,
            this.bindingNavigatorDeleteItem,
            this.toolStripSeparator6,
            this.toolStripSeparator7,
            this.bttnImageViewer,
            this.bttnDisplayEXIF,
            this.toolStripSeparator8,
            this.bttnDisplayReport,
            this.toolStripSeparator10,
            this.tspb,
            this.bttnQuery,
            this.toolStripSeparator9,
            this.bttnSelectAll,
            this.toolStripSeparator11,
            this.bttnViewOnMap});
            this.bn.Location = new System.Drawing.Point(0, 24);
            this.bn.MoveFirstItem = this.toolStripButton3;
            this.bn.MoveLastItem = this.toolStripButton6;
            this.bn.MoveNextItem = this.toolStripButton5;
            this.bn.MovePreviousItem = this.toolStripButton4;
            this.bn.Name = "bn";
            this.bn.PositionItem = null;
            this.bn.Size = new System.Drawing.Size(726, 27);
            this.bn.TabIndex = 2;
            this.bn.Text = "bindingNavigator1";
            // 
            // bs
            // 
            this.bs.PositionChanged += new System.EventHandler(this.bs_PositionChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(89, 24);
            this.toolStripLabel1.Text = "cursor position:";
            this.toolStripLabel1.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Enabled = false;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorDeleteItem.Text = "Delete selected image from catalog";
            this.bindingNavigatorDeleteItem.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bindingNavigatorDeleteItem_MouseDown);
            // 
            // bttnFolderTree
            // 
            this.bttnFolderTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnFolderTree.Image = ((System.Drawing.Image)(resources.GetObject("bttnFolderTree.Image")));
            this.bttnFolderTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnFolderTree.Name = "bttnFolderTree";
            this.bttnFolderTree.Size = new System.Drawing.Size(24, 24);
            this.bttnFolderTree.Text = "Open folder tree";
            this.bttnFolderTree.Click += new System.EventHandler(this.bttnFolderTree_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.RightToLeftAutoMirrorImage = true;
            this.toolStripButton3.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton3.Text = "Move to start";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.RightToLeftAutoMirrorImage = true;
            this.toolStripButton4.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton4.Text = "Move previous";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // lblCursorPos
            // 
            this.lblCursorPos.Name = "lblCursorPos";
            this.lblCursorPos.Size = new System.Drawing.Size(13, 24);
            this.lblCursorPos.Text = "1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.RightToLeftAutoMirrorImage = true;
            this.toolStripButton5.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton5.Text = "Move next";
            this.toolStripButton5.Click += new System.EventHandler(this.bindingNavigatorMoveNextItem_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.RightToLeftAutoMirrorImage = true;
            this.toolStripButton6.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton6.Text = "Move to end";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorAddNewItem.Text = "Add new images to catalog";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);
            // 
            // bttnAddFolderContent
            // 
            this.bttnAddFolderContent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnAddFolderContent.Image = ((System.Drawing.Image)(resources.GetObject("bttnAddFolderContent.Image")));
            this.bttnAddFolderContent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnAddFolderContent.Name = "bttnAddFolderContent";
            this.bttnAddFolderContent.Size = new System.Drawing.Size(24, 24);
            this.bttnAddFolderContent.Text = "Add folder content to catalog";
            this.bttnAddFolderContent.Click += new System.EventHandler(this.bttnAddFolderContent_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 27);
            // 
            // bttnImageViewer
            // 
            this.bttnImageViewer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnImageViewer.Enabled = false;
            this.bttnImageViewer.Image = ((System.Drawing.Image)(resources.GetObject("bttnImageViewer.Image")));
            this.bttnImageViewer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnImageViewer.Name = "bttnImageViewer";
            this.bttnImageViewer.Size = new System.Drawing.Size(24, 24);
            this.bttnImageViewer.Text = "Image viewer";
            this.bttnImageViewer.Click += new System.EventHandler(this.bttnImageViewer_Click);
            // 
            // bttnDisplayEXIF
            // 
            this.bttnDisplayEXIF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnDisplayEXIF.Enabled = false;
            this.bttnDisplayEXIF.Image = ((System.Drawing.Image)(resources.GetObject("bttnDisplayEXIF.Image")));
            this.bttnDisplayEXIF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnDisplayEXIF.Name = "bttnDisplayEXIF";
            this.bttnDisplayEXIF.Size = new System.Drawing.Size(24, 24);
            this.bttnDisplayEXIF.Text = "Display EXIF data";
            this.bttnDisplayEXIF.Click += new System.EventHandler(this.bttnDisplayEXIF_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 27);
            // 
            // bttnDisplayReport
            // 
            this.bttnDisplayReport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnDisplayReport.Enabled = false;
            this.bttnDisplayReport.Image = ((System.Drawing.Image)(resources.GetObject("bttnDisplayReport.Image")));
            this.bttnDisplayReport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnDisplayReport.Name = "bttnDisplayReport";
            this.bttnDisplayReport.Size = new System.Drawing.Size(24, 24);
            this.bttnDisplayReport.Text = "Display report file";
            this.bttnDisplayReport.Click += new System.EventHandler(this.bttnDisplayReport_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 27);
            // 
            // tspb
            // 
            this.tspb.AutoSize = false;
            this.tspb.Name = "tspb";
            this.tspb.Size = new System.Drawing.Size(100, 16);
            this.tspb.Step = 1;
            this.tspb.Visible = false;
            // 
            // bttnQuery
            // 
            this.bttnQuery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnQuery.Enabled = false;
            this.bttnQuery.Image = ((System.Drawing.Image)(resources.GetObject("bttnQuery.Image")));
            this.bttnQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnQuery.Name = "bttnQuery";
            this.bttnQuery.Size = new System.Drawing.Size(24, 24);
            this.bttnQuery.Text = "Query editor";
            this.bttnQuery.Click += new System.EventHandler(this.bttnQuery_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 27);
            // 
            // bttnSelectAll
            // 
            this.bttnSelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.bttnSelectAll.Enabled = false;
            this.bttnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("bttnSelectAll.Image")));
            this.bttnSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnSelectAll.Name = "bttnSelectAll";
            this.bttnSelectAll.Size = new System.Drawing.Size(57, 24);
            this.bttnSelectAll.Text = "Select all";
            this.bttnSelectAll.ToolTipText = "Left click: SELECT ALL FROM DB,  Right click: SELECT ALL ROWS";
            this.bttnSelectAll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bttnSelectAll_MouseDown);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 27);
            // 
            // bttnViewOnMap
            // 
            this.bttnViewOnMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnViewOnMap.Image = ((System.Drawing.Image)(resources.GetObject("bttnViewOnMap.Image")));
            this.bttnViewOnMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnViewOnMap.Name = "bttnViewOnMap";
            this.bttnViewOnMap.Size = new System.Drawing.Size(24, 24);
            this.bttnViewOnMap.Text = "View selected on map";
            this.bttnViewOnMap.Click += new System.EventHandler(this.bttnViewOnMap_Click);
            // 
            // tbSqlCommand
            // 
            this.tbSqlCommand.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbSqlCommand.Location = new System.Drawing.Point(0, 51);
            this.tbSqlCommand.Margin = new System.Windows.Forms.Padding(2);
            this.tbSqlCommand.Name = "tbSqlCommand";
            this.tbSqlCommand.Size = new System.Drawing.Size(726, 20);
            this.tbSqlCommand.TabIndex = 4;
            this.tbSqlCommand.Visible = false;
            this.tbSqlCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSqlCommand_KeyDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuConnect});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(726, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuConnect
            // 
            this.mnuConnect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dbConnectToolStripMenuItem,
            this.toolStripMenuItem1,
            this.CreateNewCatalogToolStripMenuItem,
            this.toolStripMenuItem2,
            this.CatalogResetToolStripMenuItem});
            this.mnuConnect.Name = "mnuConnect";
            this.mnuConnect.Size = new System.Drawing.Size(60, 20);
            this.mnuConnect.Text = "Catalog";
            // 
            // dbConnectToolStripMenuItem
            // 
            this.dbConnectToolStripMenuItem.Name = "dbConnectToolStripMenuItem";
            this.dbConnectToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.dbConnectToolStripMenuItem.Text = "Open";
            this.dbConnectToolStripMenuItem.Click += new System.EventHandler(this.dbConnectToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(172, 6);
            // 
            // CreateNewCatalogToolStripMenuItem
            // 
            this.CreateNewCatalogToolStripMenuItem.Name = "CreateNewCatalogToolStripMenuItem";
            this.CreateNewCatalogToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.CreateNewCatalogToolStripMenuItem.Text = "Create new catalog";
            this.CreateNewCatalogToolStripMenuItem.Click += new System.EventHandler(this.CreateNewCatalogToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(172, 6);
            // 
            // CatalogResetToolStripMenuItem
            // 
            this.CatalogResetToolStripMenuItem.Name = "CatalogResetToolStripMenuItem";
            this.CatalogResetToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.CatalogResetToolStripMenuItem.Text = "Erase catalog file";
            this.CatalogResetToolStripMenuItem.Click += new System.EventHandler(this.EraseCatalogToolStripMenuItem_Click);
            // 
            // imglist
            // 
            this.imglist.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist.ImageStream")));
            this.imglist.TransparentColor = System.Drawing.Color.Transparent;
            this.imglist.Images.SetKeyName(0, "sheet.png");
            this.imglist.Images.SetKeyName(1, "sheet2.png");
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 434);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tbSqlCommand);
            this.Controls.Add(this.bn);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Catalog";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bn)).EndInit();
            this.bn.ResumeLayout(false);
            this.bn.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.BindingNavigator bn;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bttnFolderTree;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton bttnAddFolderContent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton bttnImageViewer;
        private System.Windows.Forms.ToolStripButton bttnDisplayEXIF;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.TextBox tbSqlCommand;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuConnect;
        private System.Windows.Forms.ToolStripMenuItem dbConnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CreateNewCatalogToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem CatalogResetToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar tspb;
        private System.Windows.Forms.ToolStripButton bttnQuery;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripButton bttnSelectAll;
        private System.Windows.Forms.ToolStripButton bttnDisplayReport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ImageList imglist;
        private System.Windows.Forms.ToolStripLabel lblCursorPos;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripButton bttnViewOnMap;
    }
}



namespace Giwer.dataStock
{
    partial class frmSpectrumBank
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSpectrumBank));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbttnOpenSpectrumBank = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbttnCreateNewBankCollection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreateNewBank = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteSelectedRecord = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddNewSpectrum = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteSpectrumRow = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tstbSql = new System.Windows.Forms.ToolStripTextBox();
            this.dgvBank = new System.Windows.Forms.DataGridView();
            this.tabControlBank = new System.Windows.Forms.TabControl();
            this.Banks = new System.Windows.Forms.TabPage();
            this.Spectrums = new System.Windows.Forms.TabPage();
            this.dgvSpectrum = new System.Windows.Forms.DataGridView();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslblBankFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBank)).BeginInit();
            this.tabControlBank.SuspendLayout();
            this.Banks.SuspendLayout();
            this.Spectrums.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpectrum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbttnOpenSpectrumBank,
            this.toolStripSeparator1,
            this.tsbttnCreateNewBankCollection,
            this.toolStripSeparator2,
            this.btnCreateNewBank,
            this.btnDeleteSelectedRecord,
            this.toolStripSeparator4,
            this.btnAddNewSpectrum,
            this.btnDeleteSpectrumRow,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.tstbSql});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(649, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbttnOpenSpectrumBank
            // 
            this.tsbttnOpenSpectrumBank.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbttnOpenSpectrumBank.Image = ((System.Drawing.Image)(resources.GetObject("tsbttnOpenSpectrumBank.Image")));
            this.tsbttnOpenSpectrumBank.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbttnOpenSpectrumBank.Name = "tsbttnOpenSpectrumBank";
            this.tsbttnOpenSpectrumBank.Size = new System.Drawing.Size(23, 22);
            this.tsbttnOpenSpectrumBank.Text = "Open spectrum bank";
            this.tsbttnOpenSpectrumBank.Click += new System.EventHandler(this.tsbttnOpenSpectrumBank_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbttnCreateNewBankCollection
            // 
            this.tsbttnCreateNewBankCollection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbttnCreateNewBankCollection.Image = ((System.Drawing.Image)(resources.GetObject("tsbttnCreateNewBankCollection.Image")));
            this.tsbttnCreateNewBankCollection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbttnCreateNewBankCollection.Name = "tsbttnCreateNewBankCollection";
            this.tsbttnCreateNewBankCollection.Size = new System.Drawing.Size(23, 22);
            this.tsbttnCreateNewBankCollection.Text = "Create new spectrum bank collection as an Sqlite file";
            this.tsbttnCreateNewBankCollection.Click += new System.EventHandler(this.tsbttnCreateNewBankCollectionFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCreateNewBank
            // 
            this.btnCreateNewBank.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCreateNewBank.Enabled = false;
            this.btnCreateNewBank.Image = ((System.Drawing.Image)(resources.GetObject("btnCreateNewBank.Image")));
            this.btnCreateNewBank.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateNewBank.Name = "btnCreateNewBank";
            this.btnCreateNewBank.Size = new System.Drawing.Size(23, 22);
            this.btnCreateNewBank.Text = "Create new bank (table)";
            this.btnCreateNewBank.Click += new System.EventHandler(this.tsbttnCreateNewBank_Click);
            // 
            // btnDeleteSelectedRecord
            // 
            this.btnDeleteSelectedRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteSelectedRecord.Enabled = false;
            this.btnDeleteSelectedRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteSelectedRecord.Image")));
            this.btnDeleteSelectedRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteSelectedRecord.Name = "btnDeleteSelectedRecord";
            this.btnDeleteSelectedRecord.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteSelectedRecord.Text = "Delete selected bank record";
            this.btnDeleteSelectedRecord.Click += new System.EventHandler(this.btnDeleteRecord_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAddNewSpectrum
            // 
            this.btnAddNewSpectrum.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddNewSpectrum.Enabled = false;
            this.btnAddNewSpectrum.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewSpectrum.Image")));
            this.btnAddNewSpectrum.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNewSpectrum.Name = "btnAddNewSpectrum";
            this.btnAddNewSpectrum.Size = new System.Drawing.Size(23, 22);
            this.btnAddNewSpectrum.Text = "Add new spectrum";
            this.btnAddNewSpectrum.Visible = false;
            this.btnAddNewSpectrum.Click += new System.EventHandler(this.btnCreateNewSpectrum_Click);
            // 
            // btnDeleteSpectrumRow
            // 
            this.btnDeleteSpectrumRow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteSpectrumRow.Enabled = false;
            this.btnDeleteSpectrumRow.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteSpectrumRow.Image")));
            this.btnDeleteSpectrumRow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteSpectrumRow.Name = "btnDeleteSpectrumRow";
            this.btnDeleteSpectrumRow.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteSpectrumRow.Text = "Delete selected spektrum row";
            this.btnDeleteSpectrumRow.Visible = false;
            this.btnDeleteSpectrumRow.Click += new System.EventHandler(this.btnDeleteSpectrumRow_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(93, 22);
            this.toolStripLabel1.Text = "  Sql command: ";
            // 
            // tstbSql
            // 
            this.tstbSql.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tstbSql.Name = "tstbSql";
            this.tstbSql.Size = new System.Drawing.Size(350, 25);
            this.tstbSql.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tstbSql_KeyDown);
            // 
            // dgvBank
            // 
            this.dgvBank.AllowUserToAddRows = false;
            this.dgvBank.AllowUserToDeleteRows = false;
            this.dgvBank.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvBank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBank.Location = new System.Drawing.Point(3, 3);
            this.dgvBank.Name = "dgvBank";
            this.dgvBank.Size = new System.Drawing.Size(635, 328);
            this.dgvBank.TabIndex = 1;
            this.dgvBank.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBank_CellMouseClick);
            this.dgvBank.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBank_CellValueChanged);
            this.dgvBank.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvBank_RowHeaderMouseClick);
            // 
            // tabControlBank
            // 
            this.tabControlBank.Controls.Add(this.Banks);
            this.tabControlBank.Controls.Add(this.Spectrums);
            this.tabControlBank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlBank.Location = new System.Drawing.Point(0, 25);
            this.tabControlBank.Name = "tabControlBank";
            this.tabControlBank.SelectedIndex = 0;
            this.tabControlBank.Size = new System.Drawing.Size(649, 360);
            this.tabControlBank.TabIndex = 2;
            this.tabControlBank.SelectedIndexChanged += new System.EventHandler(this.tabControlBank_SelectedIndexChanged);
            // 
            // Banks
            // 
            this.Banks.Controls.Add(this.dgvBank);
            this.Banks.Location = new System.Drawing.Point(4, 22);
            this.Banks.Name = "Banks";
            this.Banks.Padding = new System.Windows.Forms.Padding(3);
            this.Banks.Size = new System.Drawing.Size(641, 334);
            this.Banks.TabIndex = 0;
            this.Banks.Text = "Banks";
            this.Banks.UseVisualStyleBackColor = true;
            // 
            // Spectrums
            // 
            this.Spectrums.Controls.Add(this.dgvSpectrum);
            this.Spectrums.Controls.Add(this.bindingNavigator1);
            this.Spectrums.Location = new System.Drawing.Point(4, 22);
            this.Spectrums.Name = "Spectrums";
            this.Spectrums.Padding = new System.Windows.Forms.Padding(3);
            this.Spectrums.Size = new System.Drawing.Size(641, 334);
            this.Spectrums.TabIndex = 1;
            this.Spectrums.Text = "Spectrums";
            this.Spectrums.UseVisualStyleBackColor = true;
            // 
            // dgvSpectrum
            // 
            this.dgvSpectrum.AllowUserToAddRows = false;
            this.dgvSpectrum.AllowUserToDeleteRows = false;
            this.dgvSpectrum.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvSpectrum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSpectrum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSpectrum.Location = new System.Drawing.Point(3, 28);
            this.dgvSpectrum.Name = "dgvSpectrum";
            this.dgvSpectrum.Size = new System.Drawing.Size(635, 303);
            this.dgvSpectrum.TabIndex = 0;
            this.dgvSpectrum.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSpectrum_CellMouseClick);
            this.dgvSpectrum.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSpectrum_RowHeaderMouseClick);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.toolStripButton1});
            this.bindingNavigator1.Location = new System.Drawing.Point(3, 3);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(635, 25);
            this.bindingNavigator1.TabIndex = 1;
            this.bindingNavigator1.Text = "bindingNavigator1";
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
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslblBankFile});
            this.statusStrip1.Location = new System.Drawing.Point(0, 385);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(649, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslblBankFile
            // 
            this.tslblBankFile.Name = "tslblBankFile";
            this.tslblBankFile.Size = new System.Drawing.Size(118, 17);
            this.tslblBankFile.Text = "toolStripStatusLabel1";
            // 
            // frmSpectrumBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 407);
            this.Controls.Add(this.tabControlBank);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSpectrumBank";
            this.Text = "Spectrum bank editor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSpectrumBank_FormClosed);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBank)).EndInit();
            this.tabControlBank.ResumeLayout(false);
            this.Banks.ResumeLayout(false);
            this.Spectrums.ResumeLayout(false);
            this.Spectrums.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpectrum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbttnOpenSpectrumBank;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbttnCreateNewBankCollection;
        private System.Windows.Forms.DataGridView dgvBank;
        private System.Windows.Forms.ToolStripButton btnCreateNewBank;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnDeleteSelectedRecord;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.TabControl tabControlBank;
        private System.Windows.Forms.TabPage Banks;
        private System.Windows.Forms.TabPage Spectrums;
        private System.Windows.Forms.DataGridView dgvSpectrum;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslblBankFile;
        private System.Windows.Forms.ToolStripButton btnAddNewSpectrum;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnDeleteSpectrumRow;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tstbSql;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}
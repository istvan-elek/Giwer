namespace Giwer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.bttnHelp = new System.Windows.Forms.Button();
            this.bttnDataStock = new System.Windows.Forms.Button();
            this.bttnGiwerPlant = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bttnCatalog = new System.Windows.Forms.Button();
            this.bttnConfig = new System.Windows.Forms.Button();
            this.bttnAbout = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bttnHelp
            // 
            this.bttnHelp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bttnHelp.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.bttnHelp.FlatAppearance.BorderSize = 0;
            this.bttnHelp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.bttnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnHelp.Image = ((System.Drawing.Image)(resources.GetObject("bttnHelp.Image")));
            this.bttnHelp.Location = new System.Drawing.Point(17, 464);
            this.bttnHelp.Name = "bttnHelp";
            this.bttnHelp.Size = new System.Drawing.Size(89, 87);
            this.bttnHelp.TabIndex = 0;
            this.bttnHelp.Text = "Help";
            this.bttnHelp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bttnHelp.UseVisualStyleBackColor = true;
            this.bttnHelp.Click += new System.EventHandler(this.bttnHelp_Click);
            // 
            // bttnDataStock
            // 
            this.bttnDataStock.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.bttnDataStock.FlatAppearance.BorderSize = 0;
            this.bttnDataStock.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.bttnDataStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnDataStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bttnDataStock.Image = ((System.Drawing.Image)(resources.GetObject("bttnDataStock.Image")));
            this.bttnDataStock.Location = new System.Drawing.Point(6, 19);
            this.bttnDataStock.Name = "bttnDataStock";
            this.bttnDataStock.Size = new System.Drawing.Size(97, 100);
            this.bttnDataStock.TabIndex = 2;
            this.bttnDataStock.Text = "Data stock";
            this.bttnDataStock.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bttnDataStock.UseVisualStyleBackColor = true;
            this.bttnDataStock.Click += new System.EventHandler(this.dataStock_Click);
            // 
            // bttnGiwerPlant
            // 
            this.bttnGiwerPlant.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.bttnGiwerPlant.FlatAppearance.BorderSize = 0;
            this.bttnGiwerPlant.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.bttnGiwerPlant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnGiwerPlant.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bttnGiwerPlant.Image = ((System.Drawing.Image)(resources.GetObject("bttnGiwerPlant.Image")));
            this.bttnGiwerPlant.Location = new System.Drawing.Point(6, 235);
            this.bttnGiwerPlant.Name = "bttnGiwerPlant";
            this.bttnGiwerPlant.Size = new System.Drawing.Size(97, 100);
            this.bttnGiwerPlant.TabIndex = 3;
            this.bttnGiwerPlant.Text = "Workflow builder";
            this.bttnGiwerPlant.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bttnGiwerPlant.UseVisualStyleBackColor = true;
            this.bttnGiwerPlant.Click += new System.EventHandler(this.ProjectBuilder_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bttnCatalog);
            this.groupBox1.Controls.Add(this.bttnDataStock);
            this.groupBox1.Controls.Add(this.bttnGiwerPlant);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(109, 347);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Giwer components";
            // 
            // bttnCatalog
            // 
            this.bttnCatalog.FlatAppearance.BorderSize = 0;
            this.bttnCatalog.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.bttnCatalog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnCatalog.Image = ((System.Drawing.Image)(resources.GetObject("bttnCatalog.Image")));
            this.bttnCatalog.Location = new System.Drawing.Point(3, 125);
            this.bttnCatalog.Name = "bttnCatalog";
            this.bttnCatalog.Size = new System.Drawing.Size(100, 104);
            this.bttnCatalog.TabIndex = 6;
            this.bttnCatalog.Text = "Catalog";
            this.bttnCatalog.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bttnCatalog.UseVisualStyleBackColor = true;
            this.bttnCatalog.Click += new System.EventHandler(this.bttnCatalog_Click);
            // 
            // bttnConfig
            // 
            this.bttnConfig.BackColor = System.Drawing.SystemColors.Control;
            this.bttnConfig.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.bttnConfig.FlatAppearance.BorderSize = 0;
            this.bttnConfig.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.bttnConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnConfig.Image = ((System.Drawing.Image)(resources.GetObject("bttnConfig.Image")));
            this.bttnConfig.Location = new System.Drawing.Point(18, 366);
            this.bttnConfig.Margin = new System.Windows.Forms.Padding(2);
            this.bttnConfig.Name = "bttnConfig";
            this.bttnConfig.Size = new System.Drawing.Size(88, 83);
            this.bttnConfig.TabIndex = 5;
            this.bttnConfig.Text = "Config";
            this.bttnConfig.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bttnConfig.UseVisualStyleBackColor = false;
            this.bttnConfig.Click += new System.EventHandler(this.bttnConfig_Click);
            // 
            // bttnAbout
            // 
            this.bttnAbout.AutoSize = true;
            this.bttnAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bttnAbout.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.bttnAbout.FlatAppearance.BorderSize = 0;
            this.bttnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.bttnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnAbout.Image = ((System.Drawing.Image)(resources.GetObject("bttnAbout.Image")));
            this.bttnAbout.Location = new System.Drawing.Point(14, 557);
            this.bttnAbout.Name = "bttnAbout";
            this.bttnAbout.Size = new System.Drawing.Size(92, 80);
            this.bttnAbout.TabIndex = 1;
            this.bttnAbout.Text = "Info";
            this.bttnAbout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bttnAbout.UseVisualStyleBackColor = true;
            this.bttnAbout.Click += new System.EventHandler(this.bttnAbout_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(110, 649);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bttnConfig);
            this.Controls.Add(this.bttnAbout);
            this.Controls.Add(this.bttnHelp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttnHelp;
        private System.Windows.Forms.Button bttnDataStock;
        private System.Windows.Forms.Button bttnGiwerPlant;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bttnAbout;
        private System.Windows.Forms.Button bttnConfig;
        private System.Windows.Forms.Button bttnCatalog;
    }
}


﻿
namespace Giwer
{
    partial class frmHelp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHelp));
            this.bttndatastock = new System.Windows.Forms.Button();
            this.bttnCatalog = new System.Windows.Forms.Button();
            this.bttnDataStockTutor = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bttnWfGuide = new System.Windows.Forms.Button();
            this.bttnCatTutor = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bttnWfTutor = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bttndatastock
            // 
            this.bttndatastock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bttndatastock.Location = new System.Drawing.Point(11, 29);
            this.bttndatastock.Name = "bttndatastock";
            this.bttndatastock.Size = new System.Drawing.Size(134, 23);
            this.bttndatastock.TabIndex = 0;
            this.bttndatastock.Text = "DataStock\'s users\' guide";
            this.bttndatastock.UseVisualStyleBackColor = true;
            this.bttndatastock.Click += new System.EventHandler(this.bttndatastock_Click);
            // 
            // bttnCatalog
            // 
            this.bttnCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnCatalog.Location = new System.Drawing.Point(11, 58);
            this.bttnCatalog.Name = "bttnCatalog";
            this.bttnCatalog.Size = new System.Drawing.Size(134, 23);
            this.bttnCatalog.TabIndex = 1;
            this.bttnCatalog.Text = "Catalog\'s users\' guide";
            this.bttnCatalog.UseVisualStyleBackColor = true;
            this.bttnCatalog.Click += new System.EventHandler(this.bttnCatalog_Click);
            // 
            // bttnDataStockTutor
            // 
            this.bttnDataStockTutor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnDataStockTutor.Location = new System.Drawing.Point(11, 31);
            this.bttnDataStockTutor.Name = "bttnDataStockTutor";
            this.bttnDataStockTutor.Size = new System.Drawing.Size(134, 23);
            this.bttnDataStockTutor.TabIndex = 2;
            this.bttnDataStockTutor.Text = "DataStock\'s tutorial";
            this.bttnDataStockTutor.UseVisualStyleBackColor = true;
            this.bttnDataStockTutor.Click += new System.EventHandler(this.bttnDataStockTutor_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.bttnWfGuide);
            this.groupBox1.Controls.Add(this.bttndatastock);
            this.groupBox1.Controls.Add(this.bttnCatalog);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 126);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available users\' guides";
            // 
            // bttnWfGuide
            // 
            this.bttnWfGuide.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnWfGuide.Location = new System.Drawing.Point(11, 87);
            this.bttnWfGuide.Name = "bttnWfGuide";
            this.bttnWfGuide.Size = new System.Drawing.Size(134, 23);
            this.bttnWfGuide.TabIndex = 2;
            this.bttnWfGuide.Text = "Workflow editor\'s users\' guide";
            this.bttnWfGuide.UseVisualStyleBackColor = true;
            this.bttnWfGuide.Click += new System.EventHandler(this.bttnWfGuide_Click);
            // 
            // bttnCatTutor
            // 
            this.bttnCatTutor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnCatTutor.Location = new System.Drawing.Point(11, 60);
            this.bttnCatTutor.Name = "bttnCatTutor";
            this.bttnCatTutor.Size = new System.Drawing.Size(134, 23);
            this.bttnCatTutor.TabIndex = 3;
            this.bttnCatTutor.Text = "Catalog\'s tutorial";
            this.bttnCatTutor.UseVisualStyleBackColor = true;
            this.bttnCatTutor.Click += new System.EventHandler(this.bttnCatTutor_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.bttnWfTutor);
            this.groupBox2.Controls.Add(this.bttnCatTutor);
            this.groupBox2.Controls.Add(this.bttnDataStockTutor);
            this.groupBox2.Location = new System.Drawing.Point(13, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(152, 118);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Available tutorials";
            // 
            // bttnWfTutor
            // 
            this.bttnWfTutor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bttnWfTutor.Location = new System.Drawing.Point(11, 89);
            this.bttnWfTutor.Name = "bttnWfTutor";
            this.bttnWfTutor.Size = new System.Drawing.Size(134, 23);
            this.bttnWfTutor.TabIndex = 4;
            this.bttnWfTutor.Text = "Workflow editor\'s tutorial";
            this.bttnWfTutor.UseVisualStyleBackColor = true;
            this.bttnWfTutor.Click += new System.EventHandler(this.bttnWfTutor_Click);
            // 
            // frmHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(175, 278);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHelp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Help";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bttndatastock;
        private System.Windows.Forms.Button bttnCatalog;
        private System.Windows.Forms.Button bttnDataStockTutor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bttnWfGuide;
        private System.Windows.Forms.Button bttnCatTutor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bttnWfTutor;
    }
}
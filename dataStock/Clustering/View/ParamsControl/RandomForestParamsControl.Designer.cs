namespace Giwer.dataStock.Clustering.View
{
    partial class RandomForestParamsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoadModel = new System.Windows.Forms.Button();
            this.btnSaveModel = new System.Windows.Forms.Button();
            this.btnNewModel = new System.Windows.Forms.Button();
            this.labelCurrentModel = new System.Windows.Forms.Label();
            this.labelSelectionHint = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLoadModel
            // 
            this.btnLoadModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadModel.Location = new System.Drawing.Point(3, 91);
            this.btnLoadModel.Name = "btnLoadModel";
            this.btnLoadModel.Size = new System.Drawing.Size(221, 23);
            this.btnLoadModel.TabIndex = 3;
            this.btnLoadModel.Text = "Load Model...";
            this.btnLoadModel.UseVisualStyleBackColor = true;
            this.btnLoadModel.Click += new System.EventHandler(this.btnLoadModel_Click);
            // 
            // btnSaveModel
            // 
            this.btnSaveModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveModel.Location = new System.Drawing.Point(3, 62);
            this.btnSaveModel.Name = "btnSaveModel";
            this.btnSaveModel.Size = new System.Drawing.Size(221, 23);
            this.btnSaveModel.TabIndex = 2;
            this.btnSaveModel.Text = "Save Current Model As...";
            this.btnSaveModel.UseVisualStyleBackColor = true;
            this.btnSaveModel.Click += new System.EventHandler(this.btnSaveModel_Click);
            // 
            // btnNewModel
            // 
            this.btnNewModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewModel.Location = new System.Drawing.Point(3, 33);
            this.btnNewModel.Name = "btnNewModel";
            this.btnNewModel.Size = new System.Drawing.Size(221, 23);
            this.btnNewModel.TabIndex = 1;
            this.btnNewModel.Text = "Train New Model...";
            this.btnNewModel.UseVisualStyleBackColor = true;
            this.btnNewModel.Click += new System.EventHandler(this.btnNewModel_Click);
            // 
            // labelCurrentModel
            // 
            this.labelCurrentModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCurrentModel.AutoEllipsis = true;
            this.labelCurrentModel.Location = new System.Drawing.Point(3, 10);
            this.labelCurrentModel.Name = "labelCurrentModel";
            this.labelCurrentModel.Size = new System.Drawing.Size(221, 13);
            this.labelCurrentModel.TabIndex = 0;
            this.labelCurrentModel.Text = "Current Model: None";
            this.labelCurrentModel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSelectionHint
            // 
            this.labelSelectionHint.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSelectionHint.Location = new System.Drawing.Point(3, 124);
            this.labelSelectionHint.Name = "labelSelectionHint";
            this.labelSelectionHint.Size = new System.Drawing.Size(221, 28);
            this.labelSelectionHint.TabIndex = 4;
            this.labelSelectionHint.Text = "This model requires exactly 0 band(s) to be included!";
            this.labelSelectionHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RandomForestParamsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelSelectionHint);
            this.Controls.Add(this.labelCurrentModel);
            this.Controls.Add(this.btnNewModel);
            this.Controls.Add(this.btnSaveModel);
            this.Controls.Add(this.btnLoadModel);
            this.Name = "RandomForestParamsControl";
            this.Size = new System.Drawing.Size(227, 163);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnLoadModel;
        private System.Windows.Forms.Button btnSaveModel;
        private System.Windows.Forms.Button btnNewModel;
        private System.Windows.Forms.Label labelCurrentModel;
        private System.Windows.Forms.Label labelSelectionHint;
    }
}

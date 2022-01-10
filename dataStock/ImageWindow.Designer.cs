namespace Giwer
{
    partial class ImageWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageWindow));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bttnPlus = new System.Windows.Forms.ToolStripButton();
            this.bttnMinus = new System.Windows.Forms.ToolStripButton();
            this.bttnZoomFull = new System.Windows.Forms.ToolStripButton();
            this.tslbl = new System.Windows.Forms.ToolStripLabel();
            this.tslblImageSize = new System.Windows.Forms.ToolStripLabel();
            this.tslblCursorPos = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(591, 443);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bttnPlus,
            this.bttnMinus,
            this.bttnZoomFull,
            this.tslbl,
            this.tslblImageSize,
            this.tslblCursorPos});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(591, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bttnPlus
            // 
            this.bttnPlus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnPlus.Image = ((System.Drawing.Image)(resources.GetObject("bttnPlus.Image")));
            this.bttnPlus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnPlus.Name = "bttnPlus";
            this.bttnPlus.Size = new System.Drawing.Size(24, 24);
            this.bttnPlus.Text = "Zoom in";
            this.bttnPlus.Click += new System.EventHandler(this.bttnPlus_Click);
            // 
            // bttnMinus
            // 
            this.bttnMinus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnMinus.Image = ((System.Drawing.Image)(resources.GetObject("bttnMinus.Image")));
            this.bttnMinus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnMinus.Name = "bttnMinus";
            this.bttnMinus.Size = new System.Drawing.Size(24, 24);
            this.bttnMinus.Text = "Zoom out";
            this.bttnMinus.Click += new System.EventHandler(this.bttnMinus_Click);
            // 
            // bttnZoomFull
            // 
            this.bttnZoomFull.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnZoomFull.Image = ((System.Drawing.Image)(resources.GetObject("bttnZoomFull.Image")));
            this.bttnZoomFull.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnZoomFull.Name = "bttnZoomFull";
            this.bttnZoomFull.Size = new System.Drawing.Size(24, 24);
            this.bttnZoomFull.Text = "Zoom to extent";
            this.bttnZoomFull.Click += new System.EventHandler(this.bttnZoomFull_Click);
            // 
            // tslbl
            // 
            this.tslbl.Name = "tslbl";
            this.tslbl.Size = new System.Drawing.Size(0, 24);
            // 
            // tslblImageSize
            // 
            this.tslblImageSize.Name = "tslblImageSize";
            this.tslblImageSize.Size = new System.Drawing.Size(0, 24);
            // 
            // tslblCursorPos
            // 
            this.tslblCursorPos.Name = "tslblCursorPos";
            this.tslblCursorPos.Size = new System.Drawing.Size(0, 24);
            // 
            // ImageWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ImageWindow";
            this.Size = new System.Drawing.Size(591, 470);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bttnPlus;
        private System.Windows.Forms.ToolStripButton bttnMinus;
        private System.Windows.Forms.ToolStripButton bttnZoomFull;
        private System.Windows.Forms.ToolStripLabel tslbl;
        private System.Windows.Forms.ToolStripLabel tslblImageSize;
        private System.Windows.Forms.ToolStripLabel tslblCursorPos;
    }
}

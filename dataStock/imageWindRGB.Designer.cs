namespace Giwer.dataStock
{
    partial class ImageWindRGB
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bttnPlus = new System.Windows.Forms.ToolStripButton();
            this.bttnMinus = new System.Windows.Forms.ToolStripButton();
            this.bttnPan = new System.Windows.Forms.ToolStripButton();
            this.bttnZoomFull = new System.Windows.Forms.ToolStripButton();
            this.lblCursorPosition = new System.Windows.Forms.ToolStripLabel();
            this.pb = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bttnPlus,
            this.bttnMinus,
            this.bttnPan,
            this.bttnZoomFull,
            this.lblCursorPosition});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(470, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bttnPlus
            // 
            this.bttnPlus.Checked = true;
            this.bttnPlus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bttnPlus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnPlus.Image = ((System.Drawing.Image)(resources.GetObject("bttnPlus.Image")));
            this.bttnPlus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnPlus.Name = "bttnPlus";
            this.bttnPlus.Size = new System.Drawing.Size(24, 24);
            this.bttnPlus.Text = "Zoom in mode";
            this.bttnPlus.Click += new System.EventHandler(this.BttnPlus_Click);
            // 
            // bttnMinus
            // 
            this.bttnMinus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnMinus.Image = ((System.Drawing.Image)(resources.GetObject("bttnMinus.Image")));
            this.bttnMinus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnMinus.Name = "bttnMinus";
            this.bttnMinus.Size = new System.Drawing.Size(24, 24);
            this.bttnMinus.Text = "Zooming out";
            this.bttnMinus.Click += new System.EventHandler(this.BttnMinus_Click);
            // 
            // bttnPan
            // 
            this.bttnPan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnPan.Enabled = false;
            this.bttnPan.Image = ((System.Drawing.Image)(resources.GetObject("bttnPan.Image")));
            this.bttnPan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnPan.Name = "bttnPan";
            this.bttnPan.Size = new System.Drawing.Size(24, 24);
            this.bttnPan.Text = "Pan mode";
            this.bttnPan.Click += new System.EventHandler(this.BttnPan_Click);
            // 
            // bttnZoomFull
            // 
            this.bttnZoomFull.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bttnZoomFull.Image = ((System.Drawing.Image)(resources.GetObject("bttnZoomFull.Image")));
            this.bttnZoomFull.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bttnZoomFull.Name = "bttnZoomFull";
            this.bttnZoomFull.Size = new System.Drawing.Size(24, 24);
            this.bttnZoomFull.Text = "Zooming to extent";
            this.bttnZoomFull.Click += new System.EventHandler(this.BttnZoomFull_Click);
            // 
            // lblCursorPosition
            // 
            this.lblCursorPosition.Name = "lblCursorPosition";
            this.lblCursorPosition.Size = new System.Drawing.Size(0, 24);
            // 
            // pb
            // 
            this.pb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb.Location = new System.Drawing.Point(0, 0);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(470, 390);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb.TabIndex = 3;
            this.pb.TabStop = false;
            this.pb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pb_MouseDown);
            this.pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pb_MouseMove);
            this.pb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pb_MouseUp);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pb);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(470, 390);
            this.panel1.TabIndex = 4;
            // 
            // ImageWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Name = "ImageWindow";
            this.Size = new System.Drawing.Size(470, 417);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bttnMinus;
        private System.Windows.Forms.ToolStripButton bttnZoomFull;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripLabel lblCursorPosition;
        private System.Windows.Forms.ToolStripButton bttnPlus;
        private System.Windows.Forms.ToolStripButton bttnPan;
    }
}

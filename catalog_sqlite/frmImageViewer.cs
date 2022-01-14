using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace catalog
{
    public partial class frmImageViewer : Form
    {
        public frmImageViewer(string fn)
        {
            InitializeComponent();
            pb.Image = Image.FromFile(fn);
            this.Text = Path.GetFileName(fn);
        }

        public void loadImage(string filename)
        {
            if (filename == "\\") return;
            pb.Image = Image.FromFile(filename);
            this.Text = Path.GetFileName(filename);

        }

        private void pb_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pb.Dock = DockStyle.None;
                pb.SizeMode = PictureBoxSizeMode.AutoSize;
                this.AutoScroll = true;
            }
            else
            {
                pb.Dock = DockStyle.Fill;
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                this.AutoScroll = false;
            }
        }

        private void frmImageViewer_FormClosed(object sender, FormClosedEventArgs e)
        {
            pb.Image = null;
            pb.Dispose();
            this.Dispose();
        }
    }
}

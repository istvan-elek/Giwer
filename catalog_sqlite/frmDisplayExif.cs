using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace catalog
{
    public partial class frmDisplayExif : Form
    {
        string destination_folder;
        public frmDisplayExif(string fname)
        {
            InitializeComponent();
            destination_folder = Properties.Settings.Default.destinationFolder;
            loadExif(fname);
        }

        public frmDisplayExif()
        {
            InitializeComponent();
        }

        public void loadExif(string fname)
        {
            if (fname == "\\") return;
            this.Text = Path.GetFileName(fname);
            string[] exif = getExifData(fname);
            lstExif.Items.Clear();
            lstExif.Items.AddRange(exif);
            lstExif.Sorted = true;
        }


        public string[] getExifData(string file)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = "exiftool.exe";
            proc.StartInfo.WorkingDirectory = Path.GetDirectoryName(file);
            proc.StartInfo.Arguments = Path.GetFileName(file);
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            string ex = proc.StandardOutput.ReadToEnd();
            string[] exi = ex.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            List<string> l = new List<string>();
            for (int i = 0; i < exi.Length; i++)
            {
                if (exi[i] != "") l.Add(exi[i].Split(':')[0].Trim() + ";" + "\t" + exi[i].Split(':')[1]);
            }
            string[] exif = l.ToArray();
            return exif;
        }

    }
}

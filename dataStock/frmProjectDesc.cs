using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Giwer
{
    public partial class frmProjectDesc : Form
    {
        public frmProjectDesc()
        {
            InitializeComponent();
        }

        public void LoadProjectElements(string projFileName)
        {
            string [] Params = System.IO.File.ReadAllLines(projFileName);
            ParseParameters(Params);
            textBox1.Text= System.IO.File.ReadAllText(projFileName);
            textBox1.Select(0,0);
            tslblProjName.Text = "Project name: " + System.IO.Path.GetFileName(projFileName);
        }

        string _projectFileName;
        public string ProjectFileName
        {
            get { return _projectFileName; }
            set
            {
                _projectFileName = value;
            }
        }

        void ParseParameters(string[] pars)
        {

        }

        string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        string _file;
        public string File
        {
            get { return _file; }
            set { _file = value; }
        }

        GeoImageData.fTypes _type;
        public GeoImageData.fTypes Type
        {
            get { return _type; }
            set { _type = value; }
        }

        int _numberOfBands;
        public int NumberOfBands
        {
            get { return _numberOfBands; }
            set { _numberOfBands = value; }
        }


        public void saveProjectFile(ListBox lstFileName, List<string> lstFiles, List<Giwer.frmDataStock.fTypes> lstType, int numOfBands, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                for (int i=0; i< lstFileName.Items.Count; i++)
                {
                    sw.WriteLine("UpdatedAt:"  + DateTime.Now);
                    sw.WriteLine("FileName:" + lstFileName.Items[i]);
                    sw.WriteLine("File:" + lstFiles.ElementAt<string>(i));
                    //sw.WriteLine("Type:" + lstType.ElementAt<Giwer.frmDataStock.fTypes>(i));
                    sw.WriteLine("NumberOfBand:" + numOfBands);
                }
            }
        }
    }

}

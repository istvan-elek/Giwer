using System.Collections.Generic;
using System.IO;
using System;


namespace Giwer.dataStock
{
    public class Project
    {
#region properties
        string _projfilename ="";
        public string ProjectFileName
        {
            get { return _projfilename; }
            set { _projfilename = value; loadProjectFile(); }
        }

        List<string> _filenames = new List<string>();
        public List<string> FileNames
        {
            get { return _filenames; }
            set { _filenames = value; }
        }

        string _jpgdatafolder;
        public string JpgDataFolder
        {
            get { return _jpgdatafolder; }
            set { _jpgdatafolder = value; }
        }

        string _tifdatafolder;
        public string TifDataFolder
        {
            get { return _tifdatafolder; }
            set { _tifdatafolder = value; }
        }

        string _bildatafolder;
        public string BilDataFolder
        {
            get { return _bildatafolder; }
            set { _bildatafolder = value; }
        }

        string _giwerdatafolder;
        public string GiwerDataFolder
        {
            get { return _giwerdatafolder; }
            set { _giwerdatafolder = value; }
        }

        string _dtmDatafolder;
        public string DtmDataFolder
        {
            get { return _dtmDatafolder; }
            set { _dtmDatafolder = value; }
        }
        string _projectDescription;
        public string ProjectDescription
        {
            get { return _projectDescription; }
            set { _projectDescription = value; }
        }
#endregion

#region methods
        public void loadProjectFile()
        {
            string flag = "";
            int numln = 0;
            if (_projfilename == "") return;
            using (FileStream fs = new FileStream(_projfilename, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine().Trim();
                        if (line.Contains("#Description")) { flag = "description"; line = sr.ReadLine().Trim(); }
                        if (line.Contains("#Files")) { flag = "files"; line = sr.ReadLine().ToLower().Trim(); }
                        if (line.Contains("#Config")) { flag = "config"; line = sr.ReadLine().ToLower().Trim(); }

                        if (flag == "files")
                        {
                            _filenames.Add(line);
                        }

                        if (flag == "config")
                        {
                            if (line.ToLower().Split(',')[0] == "jpgdatafolder") _jpgdatafolder = line.Split(',')[1];
                            if (line.ToLower().Split(',')[0] == "tifdatafolder") _tifdatafolder = line.Split(',')[1];
                            if (line.ToLower().Split(',')[0] == "bildatafolder") _bildatafolder = line.Split(',')[1];
                            if (line.ToLower().Split(',')[0] == "giwerdatafolder") _giwerdatafolder = line.Split(',')[1];
                            if (line.ToLower().Split(',')[0] == "dtmdatafolder") _dtmDatafolder = line.Split(',')[1];
                        }

                        if (flag == "description")
                        {
                            if (numln > 0) _projectDescription += (Environment.NewLine + line); else _projectDescription += line;
                            numln++;
                        }
                    }
                }
            }
        }


        public void initProject()
        {
            _projfilename = "";
            _filenames.Clear();
            _projectDescription = "";
        }
#endregion

    }
}

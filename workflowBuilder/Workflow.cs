using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Giwer.workflowBuilder
{
    class Workflow
    {
        string _description;
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        List<string> _methods = new List<string>();
        public List<string> Methods
        {
            get { return _methods; }
            set { _methods = value; }
        }

        List<List<string>> _pars = new List<List<string>>();
        public List<List<string>> Pars
        {
            get { return _pars; }
            set { _pars = value; }
        }


        public void LoadWorkflowFile(string fileName)
        {
            string flag = "";
            int numln = 0;
            if (fileName == "") return;
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine().Trim();
                        if (line.Contains("#Description")) { flag = "description"; line = sr.ReadLine().Trim(); }
                        if (line.Contains("#Methods")) { flag = "methods"; line = sr.ReadLine().Trim(); }
                        if (flag == "methods")
                        {
                            List<string> lstPara = new List<string>();
                            int p = 0;
                            if (line != "")
                            {
                                _methods.Add(line);
                                p = Convert.ToInt16(line.Split(' ')[1].Trim('(').Trim(')'));
                                for (int i = 0; i < p; i++)
                                {
                                    string para = sr.ReadLine().Trim();
                                    lstPara.Add(para);
                                }
                                _pars.Add(lstPara);
                            }
                        }
                        if (flag == "description")
                        {
                            if (numln > 0) _description += (Environment.NewLine + line); else _description += line;
                            numln++;
                        }
                    }
                }
            }
        }

        public void saveWorkflowFile(string fname)
        {
            using (FileStream fs=new FileStream(fname,FileMode.Create,FileAccess.Write))
            {
                using (StreamWriter sw=new StreamWriter(fs))
                {
                    sw.WriteLine("#Description:" + Environment.NewLine + _description);
                    sw.WriteLine("#Methods:");
                    for (int i=0; i<_methods.Count; i++)
                    {
                        sw.WriteLine(_methods[i]);
                        foreach (var lsitem in _pars[i])
                        {
                            if (_pars[i].Count > 0)
                            {
                                if (lsitem != "-")
                                {
                                    string s = lsitem.ToString();
                                    sw.WriteLine(s);
                                }
                            }
                        }
                    }
                    sw.Flush();
                }
            }
        }


        public void initWorkflow()
        {
            _methods.Clear();
            _pars.Clear();
            _description = "";
        }
    }
}

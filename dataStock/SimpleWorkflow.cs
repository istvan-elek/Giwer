using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Giwer.dataStock
{
    [DefaultPropertyAttribute("NameOfWorkflow")]
    class SimpleWorkflow
    {
        Project proj = new Project();
        Boolean flagCreate = false;

        #region properties
        string _nameOfWorkflow;
        [CategoryAttribute("Workflow"), DescriptionAttribute("Name of wf")]
        public string NameOfWorkflow
        {
            get { return _nameOfWorkflow; }
            set
            {
                _nameOfWorkflow = value;
                if (!flagCreate) loadWorkflowFile();
                proj.ProjectFileName = this.NameOfProject;
            }
        }

        string _nameOfProject;
        [CategoryAttribute("Project"), DescriptionAttribute("Name of pr")]
        public string NameOfProject
        {
            get { return _nameOfProject; }
            set { _nameOfProject = value; }
        }


        List<string> _filenames = new List<string>();
        [CategoryAttribute("Project"), DescriptionAttribute("Files info")]
        public List<string> FileNames
        {
            get { return _filenames; }
            set { _filenames = value; }
        }


        List<string> _methodNames = new List<string>();
        [CategoryAttribute("Workflow"), DescriptionAttribute("Method info")]
        public List<string> MethodNames
        {
            get { return _methodNames; }
            set { _methodNames = value; }
        }


        string _workflowDescription;
        [CategoryAttribute("Workflow"), DescriptionAttribute("Workflow data description")]
        public string WorkflowDescription
        {
            get { return _workflowDescription; }
            set { _workflowDescription = value; }
        }
        #endregion


        #region methods

        [CategoryAttribute("Workflow methods"), DescriptionAttribute("Workflow methods **")]
        void loadWorkflowFile()
        {
            string flag = "";
            int numln = 0;
            using (FileStream fs = new FileStream(_nameOfWorkflow, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine().Trim();
                        //if (line.Contains("#Project_file:")) { flag = "project";   }
                        if (line.Contains("#Description:")) { flag = "description"; line = sr.ReadLine().Trim(); }
                        //if (line.Contains("#Files")) { flag = "files"; line = sr.ReadLine().ToLower().Trim(); }
                        if (line.Contains("#Methods")) { flag = "methods"; line = sr.ReadLine().ToLower().Trim(); }

                        if (flag == "files")
                        {
                            _filenames.Add(line);
                        }

                        if (flag == "description")
                        {
                            if (numln > 0) _workflowDescription += (Environment.NewLine + line); else _workflowDescription += line;
                            numln++;
                        }
                        if (flag == "methods")
                        {
                            _methodNames.Add(line);
                        }
                        if (flag == "project")
                        {
                            _nameOfProject = line.Split(' ')[1];
                        }
                    }
                }
            }
        }

        public void createWorkflow(string Workflowname, string projName, List<string> flist, List<string> methodList, string workflowDesc)
        {
            flagCreate = true;
            _nameOfWorkflow = Workflowname;
            _nameOfProject = projName;
            _filenames = flist;
            _workflowDescription = workflowDesc;
            _methodNames = methodList;
        }

        #endregion
    }
}

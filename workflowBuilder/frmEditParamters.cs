using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace Giwer.workflowBuilder
{

    public partial class frmEditParamters : Form
    {
        string methodName;
        public object[] parameters;
        TextBox[] ParValue;
        public frmEditParamters(string methodname)
        {
            InitializeComponent();
            methodName = methodname;
            createParametersGUI(methodname);
            //parseParameters(methodname);
        }

        void createParametersGUI(string methodName)
        {
            MethodInfo method = typeof(dataStock.Filter).GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance);
            object[] ob = new object[1];
            ob[0] = methodName;
            ParameterInfo[] pars = method.GetParameters();
            object[] parameterstypes = new object[pars.Length];
            for (int i = 0; i < parameterstypes.Length; i++) { parameterstypes[i] = pars[i].ParameterType; }
            Label[] ParName = new Label[parameterstypes.Length];
            ParValue = new TextBox[parameterstypes.Length];
            int marg = 10;
            for (int i = 0; i < parameterstypes.Length; i++)
            {
                ParName[i] = new Label();
                ParName[i].AutoSize = true;
                ParName[i].Text = pars[i].Name + ":";
                ParName[i].Location = new Point(marg, marg + i * 2 * ParName[i].Height);
                ParValue[i] = new TextBox();
                ParValue[i].Location = new Point(marg, 3 * marg + 2 * i * ParName[i].Height);
                ParValue[i].Width = this.ClientSize.Width - 2 * marg;
                ParValue[i].Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
            }
            this.Controls.AddRange(ParName);
            this.Controls.AddRange(ParValue);
        }

        void parseParameters(string methodname)
        {
            MethodInfo method = typeof(dataStock.Filter).GetMethod(methodName, BindingFlags.Public | BindingFlags.Instance);
            object[] ob = new object[1];
            ob[0] = methodName;
            ParameterInfo[] pars = method.GetParameters();
            object[] parameterstypes = new object[pars.Length];
            parameters = new object[pars.Length];
            for (int i = 0; i < pars.Length; i++)
            {
                if (pars[i].ParameterType.FullName == "System.String")
                {
                    parameters[i] = this.ParValue[i].Text;
                }
                if (pars[i].ParameterType.FullName == "System.Int32")
                {
                    parameters[i] = Convert.ToInt32(this.ParValue[i].Text);
                }
            }
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void bttnOK_Click(object sender, EventArgs e)
        {
            //parseParameters(methodName);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }




    }
}

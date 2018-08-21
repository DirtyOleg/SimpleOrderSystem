using BusinessLogicLayer;
using CommonUtilityLayer;
using CommonUtilityLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtEId.Text = string.Empty;
            txtPwd.Text = string.Empty;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtEId.Text);
            string pwd = MD5Helper.EncryptString(txtPwd.Text);
            EmployeeInfo emp = new EmployeeInfo() {
                EId = id,
                EPwd = pwd
            };

            EmployeeInfoBLL eiBLL = new EmployeeInfoBLL();
            if (eiBLL.EmployeeLogin(emp))
            {
                MainForm mainfrm = new MainForm();
                mainfrm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Input Infomation is not valid,\nor Employee do not exist", "Login Fail");
            }
        }
    }
}

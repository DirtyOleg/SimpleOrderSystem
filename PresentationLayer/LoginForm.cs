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
            Employee emp = new Employee() {
                EmployeeId = id,
                EmployeePwd = pwd
            };

            EmployeeBLL eiBLL = new EmployeeBLL();
            if (eiBLL.EmployeeLogin(emp))
            {
                MainForm mainfrm = new MainForm();

                //using Tag in MainForm to transit the Position information of the login employee
                //0 for manager, 1 for employee
                if (emp.EmployeePosition == "Manager")
                {
                    mainfrm.Tag = 0;
                }
                else
                {
                    mainfrm.Tag = 1;
                }

                mainfrm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login in failed, check your input", "Login Fail");
            }
        }
    }
}

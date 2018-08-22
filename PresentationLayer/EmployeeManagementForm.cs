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
    public partial class EmployeeManagementForm : Form
    {
        static EmployeeManagementForm frm = null;
        EmployeeInfoBLL eiBLL = new EmployeeInfoBLL();
        List<EmployeeInfo> empList = new List<EmployeeInfo>();

        private EmployeeManagementForm()
        {
            InitializeComponent();
        }

        public static EmployeeManagementForm GetForm()
        {
            if (frm == null)
            {
                frm = new EmployeeManagementForm();
            }

            return frm;
        }

        private void EmployeeManagementForm_Load(object sender, EventArgs e)
        {
            LoadEmployeeList();
        }

        private void LoadEmployeeList()
        {
            //disenble AutoGenerate for the datagrindview
            dgvEmployeeList.AutoGenerateColumns = false;
            empList = eiBLL.GetList();
            dgvEmployeeList.DataSource = empList;
        }

        private void ResetTxtBtn()
        {
            txtId.Text = "    Automatically Generate";
            txtName.Clear();
            txtPwd.Clear();
            btnAddorSave.Text = "Add";
            rbEmployee.Checked = true;
        }

        private void btnAddorSave_Click(object sender, EventArgs e)
        {
            bool isSuccess = false;
            EmployeeInfo emp = new EmployeeInfo()
            {
                EName = txtName.Text.Trim(),
                EPosition = rbManager.Checked ? "Manager" : "Employee",
            };

            if (btnAddorSave.Text.Trim().Equals("Add"))
            {
                //Add new employee
                emp.EPwd = MD5Helper.EncryptString(txtPwd.Text.Trim());

                if (eiBLL.AddNewEmployeeInfo(emp) != 0)
                {
                    MessageBox.Show($"Change to EmployeeInfo Table\nAdd Success", "Result");
                    isSuccess = true;
                }
            }
            else
            {
                //Update an existed employee infomation
                emp.EId = Convert.ToInt32(txtId.Text);

                //Check the comments in dgvEmployeeList_CellDoubleClick() for details
                if (txtPwd.Text.Equals("!L9%o^3*)G#"))
                {
                    //user do not change the password
                    emp.EPwd = string.Empty;
                }
                else
                {
                    //user change the password
                    emp.EPwd = MD5Helper.EncryptString(txtPwd.Text.Trim());
                }

                int id = eiBLL.UpdateEmployeeInfo(emp);//id for the employee whose infomation has successful update
                if (id != 0)
                {
                    MessageBox.Show($"Change to EmployeeInfo Table\nID:{id} UPDATE Success", "Result");
                    isSuccess = true;
                }
            }

            if (isSuccess)
            {
                //if operation success, reset all TextBox and Button
                ResetTxtBtn();
            }
            else
            {
                MessageBox.Show("Failed!! Check your input and try again", "Result");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (!txtId.Text.Equals("    Automatically Generate"))
            {
                EmployeeInfo emp = new EmployeeInfo()
                {
                    EId = Convert.ToInt32(txtId.Text)
                };

                int id = eiBLL.DeleteEmployeeInfo(emp);
                MessageBox.Show($"Change to EmployeeInfo Table\nID:{id} DELETE Success", "Result");
            }
            else
            {
                MessageBox.Show("Choose one employee to delete", "Error");
            }

            ResetTxtBtn();
        }

        private void dgvEmployeeList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvEmployeeList.Rows[e.RowIndex];

            txtId.Text = row.Cells["EId"].Value.ToString();
            txtName.Text = row.Cells["EName"].Value.ToString();
            if (row.Cells["EPosition"].Value.ToString() == "Employee")
            {
                rbEmployee.Checked = true;
            }
            else
            {
                rbManager.Checked = true;
            }
            //We need to check if the User changed the password for one employee
            //there are some way to do it
            //the most intuitive way is to query the selected employee's password from the database based on the ID of the selected employee, and using MD5 algorithm hash the text from the TextBox, and then compare those two string, if the user do not change the password, the result of the comparison should be true, or it will be false
            //But we do not want the extra select query, so we choose another way. The way we check if the user changed the password is that first we manual set the text value of the TextBox for the password to a wired string that 99.9% of people will never used, in this case, "!L%o^e*)G#" is chosen. After the user hit the "Save" button, we will compare the Text from the TextBox with "!L%o^e*)G#". If user changed the password, the result of this comparison is false, or if the result is true meaning the user do not changed the password

            txtPwd.Text = "!L9%o^3*)G#";
            btnAddorSave.Text = "Save";
        }

        private void txtPwd_MouseClick(object sender, MouseEventArgs e)
        {
            TextBox txtPwd = sender as TextBox;
            txtPwd.SelectAll();
            txtPwd.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetTxtBtn();
        }

        private void EmployeeManagementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }
    }
}

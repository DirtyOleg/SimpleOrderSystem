using BusinessLogicLayer;
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
    public partial class MemberManagementForm : Form
    {
        private static MemberManagementForm frm = null;
        MemberBLL mBLL = new MemberBLL();
        List<Member> mList;
        Dictionary<int, string> membershipDic;

        private MemberManagementForm()
        {
            InitializeComponent();
        }

        public static MemberManagementForm GetForm()
        {
            if (frm == null)
            {
                frm = new MemberManagementForm();
            }

            return frm;
        }

        private void MemberManagementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }

        private void MemberManagementForm_Load(object sender, EventArgs e)
        {
            dgvList.AutoGenerateColumns = false;
            RefreshData();
        }

        //Refresh both Datagridview and Dropdownlist
        private void RefreshData()
        {
            mList = mBLL.GetList();
            membershipDic = mBLL.GetDic();
            dgvList.DataSource = mList;
            ddlType.DataSource = membershipDic.Values.ToList();
            ddlType.SelectedIndex = 0;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            //ddlType.SelectedIndex = membershipDic.
            txtPhone.Text = row.Cells[3].Value.ToString();
            txtBalance.Text = row.Cells[4].Value.ToString();
            btnAddorSave.Text = "Update";

        }

        private void btnAddorSave_Click(object sender, EventArgs e)
        {
            if (txtBalance.Text == string.Empty || txtName.Text == string.Empty)
            {
                Console.WriteLine("Name or Balance cannot be empty");
                return;
            }

            Member m = new Member()
            {
                MemberName = txtName.Text.Trim(),
                MemberBalance = Convert.ToDecimal(txtBalance.Text.Trim()),
                MembershipType = membershipDic.Where(pair => pair.Value == ddlType.SelectedText).Select(pair => pair.Key).First()
            };


            if (btnAddorSave.Text.Trim() == "Add")
            {
                //Add new member

            }
            else
            {
                //Update existed member's information
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBalance.Text = string.Empty;
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtNameSearch.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtPhoneSearch.Text = string.Empty;
            ddlType.SelectedIndex = 0;
            btnAddorSave.Text = "Add";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}

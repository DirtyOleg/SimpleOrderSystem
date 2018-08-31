using BusinessLogicLayer;
using CommonUtilityLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        List<Member> memberList;
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
            mBLL.GetList(out memberList, out membershipDic);
            dgvList.DataSource = memberList;
            cbbMemberTitle.DataSource = membershipDic.Values.ToList();
            cbbMemberTitle.SelectedIndex = 0;
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvList.Rows[e.RowIndex];
            txtId.Text = row.Cells[0].Value.ToString();
            txtName.Text = row.Cells[1].Value.ToString();
            cbbMemberTitle.SelectedIndex = cbbMemberTitle.FindStringExact(row.Cells[2].Value.ToString());
            txtPhone.Text = row.Cells[3].Value.ToString();
            txtBalance.Text = row.Cells[4].Value.ToString();
            btnAddorSave.Text = "Update";
        }

        private void btnAddorSave_Click(object sender, EventArgs e)
        {
            if (txtBalance.Text == string.Empty || txtName.Text == string.Empty)
            {
                MessageBox.Show("Name or Balance cannot be empty");
                return;
            }

            Member m = new Member()
            {
                MemberName = txtName.Text.Trim(),
                MemberPhone = txtPhone.Text.Trim(),
                MemberBalance = Convert.ToDecimal(txtBalance.Text.Trim()),
                MembershipId = membershipDic.Where(pair => pair.Value == cbbMemberTitle.SelectedValue.ToString()).Select(pair => pair.Key).First()
            };

            bool isSuccess = false;

            if (btnAddorSave.Text.Trim() == "Add")
            {
                //Add new member
                int tmp = mBLL.AddMemberInfo(m);
                if (tmp != 0)
                {
                    isSuccess = true;
                    MessageBox.Show($"Changes made to Member Table\nOperation: Add New Member\nSuccess!", "Result");
                }
            }
            else
            {
                //Update existed member's information
                m.MemberId = Convert.ToInt32(txtId.Text.Trim());

                int id = mBLL.UpdateMemberInfo(m);
                if (id != 0)
                {
                    isSuccess = true;
                    MessageBox.Show($"Changes made to Member Table\nOperation: Update Member(ID:{id})'s Info\nSuccess!", "Result");
                }
            }

            if (isSuccess)
            {
                ResetTxtBtn();
                ResetSearchTxt();
                RefreshData();
            }
            else
            {
                MessageBox.Show("Operation Fail, check your input", "Error");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (btnAddorSave.Text == "Add")
            {
                MessageBox.Show("To Delete, first select one member", "Error");
                return;
            }

            Member m = new Member()
            {
                MemberId = Convert.ToInt32(txtId.Text.Trim())
            };

            int id = mBLL.DeleteMemberInfo(m);
            if (id != 0)
            {
                MessageBox.Show($"Changes Made to Membership Table\nDelete Membership Info with ID:{id}\nSuccess!", "Result");
                ResetTxtBtn();
                RefreshData();
            }
            else
            {
                MessageBox.Show("Operation Fail, Try it later", "Error");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetTxtBtn();
        }

        private void ResetTxtBtn()
        {
            txtBalance.Text = string.Empty;
            txtId.Text = "  Auto Generate";
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            cbbMemberTitle.SelectedIndex = 0;
            btnAddorSave.Text = "Add";
        }

        private void ResetSearchTxt()
        {
            txtSearchPhone.Text = string.Empty;
            txtSearchName.Text = string.Empty;
        }

        private void btnSearchReset_Click(object sender, EventArgs e)
        {
            ResetSearchTxt();
            RefreshData();
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            SearchMember();
        }

        private void txtSearchPhone_TextChanged(object sender, EventArgs e)
        {
            SearchMember();
        }

        private void SearchMember()
        {
            Member member = new Member()
            {
                MemberName = txtSearchName.Text.Trim(),
                MemberPhone = txtSearchPhone.Text.Trim()
            };

            List<int> idList = mBLL.SearchMemeberInfo(member);

            List<Member> searchedMembers = new List<Member>();
            foreach (int id in idList)
            {
                searchedMembers.Add(memberList.Where(m => m.MemberId == id).First());
            }

            dgvList.DataSource = searchedMembers;
        }
    }
}

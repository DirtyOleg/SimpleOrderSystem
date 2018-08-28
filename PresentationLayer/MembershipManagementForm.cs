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
    public partial class MembershipManagementForm : Form
    {
        MembershipBLL msBLL = new MembershipBLL();
        List<Membership> msList = new List<Membership>();
        static MembershipManagementForm frm = null;

        private MembershipManagementForm()
        {
            InitializeComponent();
        }

        public static MembershipManagementForm GetForm()
        {
            if (frm == null)
            {
                frm = new MembershipManagementForm();
            }

            return frm;
        }

        private void MembershipManagementForm_Load(object sender, EventArgs e)
        {
            dgvList.AutoGenerateColumns = false;
            RefreshDataGrindViewData();
        }

        private void RefreshDataGrindViewData()
        {
            msList = msBLL.GetList();
            dgvList.DataSource = msList;
        }

        private void MembershipManagementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            frm = null;
        }

        private void btnAddorUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDiscount.Text) || string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Input cannot be empty or white space");
                ResetTxtBtn();
                return;
            }

            Membership ms = new Membership()
            {
                DiscountType = Convert.ToDecimal(txtDiscount.Text),
                MembershipTitle = txtTitle.Text
            };

            bool isSuccess = false;

            if (btnAddorUpdate.Text.Trim() == "Add")
            {
                //Add new Membership
                if (msBLL.AddMembership(ms) != 0)
                {
                    MessageBox.Show($"Changes made to Membership Table\nOperation: Add New Membership\nSuccess!", "Result");
                    isSuccess = true;
                }
            }
            else
            {
                //Update information of an existed membership
                ms.MembershipId = Convert.ToInt32(txtId.Text);
                int id = msBLL.UpdateMembership(ms);

                if (id != 0)
                {
                    MessageBox.Show($"Changes made to Membership Table\nOperation: Update Membership Info with ID:{id}\nSuccess!", "Result");
                    isSuccess = true;
                }
            }

            if (isSuccess)
            {
                ResetTxtBtn();
                RefreshDataGrindViewData();
            }
            else
            {
                MessageBox.Show("Operation Fail, Check your input and Try again", "Error");
            }
        }

        private void ResetTxtBtn()
        {
            txtId.Text = "   Auto-Generate";
            txtTitle.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            btnAddorUpdate.Text = "Add";
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvList.Rows[e.RowIndex];

            txtId.Text = row.Cells[0].Value.ToString();
            txtTitle.Text = row.Cells[1].Value.ToString();
            txtDiscount.Text = row.Cells[2].Value.ToString();

            btnAddorUpdate.Text = "Update";
            txtTitle.Focus();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetTxtBtn();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Trim() == "Auto-Generate")
            {
                MessageBox.Show("Double click the Membership needed to delete", "Error");
                return;
            }

            Membership ms = new Membership()
            {
                MembershipId = Convert.ToInt32(txtId.Text)
            };

            int id = msBLL.DeleteMembership(ms);
            if (id != 0)
            {
                MessageBox.Show($"Changes Made to Membership Table\nDelete Membership Info with ID:{id}\nSuccess!", "Result");                
            }
            else
            {
                MessageBox.Show("Operatiom Fail, Try later");
            }

            RefreshDataGrindViewData();
            ResetTxtBtn();
        }
    }
}

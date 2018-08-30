﻿using System;
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
    public partial class MainForm : Form
    {


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Employee should not have the ability to modify Employee Info and Dish Info
            if (this.Tag.ToString() == "1")
            {
                menuManager.Visible = false;
            }
        }

        private void menuManager_DoubleClick(object sender, EventArgs e)
        {
            EmployeeManagementForm empManageFrm = EmployeeManagementForm.GetForm();
            empManageFrm.Show();
        }

        private void menuExit_DoubleClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuMembership_DoubleClick(object sender, EventArgs e)
        {
            MembershipManagementForm mmManageFrm = MembershipManagementForm.GetForm();
            mmManageFrm.Show();
        }

        private void menuMember_DoubleClick(object sender, EventArgs e)
        {
            MemberManagementForm frm = MemberManagementForm.GetForm();
            frm.Show();
        }
    }
}

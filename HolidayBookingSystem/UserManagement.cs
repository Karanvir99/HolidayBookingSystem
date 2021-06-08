using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;

namespace HolidayBookingSystem
{
    public partial class UserManagement : Form
    {
        readonly UserManagementOptions umo;
        readonly ValidationClass v;
        int indexRow;

        public UserManagement()
        {
            InitializeComponent();
            umo = new UserManagementOptions();
            v = new ValidationClass();

            umo.LoadData(dgvManagement);
            umo.DisplayDepartments(cmbDepartment);
            umo.DisplayRoles(cmbRole);
        }

        private void ClearInput()
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }

                if (c is ComboBox)
                {
                    c.Text = "";
                }
            }
        }

        private void ClearSelection()
        {
            dgvManagement.ClearSelection();
            dgvManagement.CurrentCell = null;
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            ClearInput();
            ClearSelection();
            lblNote.Visible = false;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            umo.AddUser(txtForename.Text, txtLastname.Text, txtAddress.Text, txtPhoneNumber.Text, txtUsername.Text, txtPassword.Text, cmbDepartment.SelectedValue, cmbRole.SelectedValue, dgvManagement);
            ClearInput();
            ClearSelection();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (v.CellSelectedValidation(dgvManagement) == true)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to update this employee?", "WARNING", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        umo.UpdateUser(txtForename.Text, txtLastname.Text, txtAddress.Text, txtPhoneNumber.Text, txtUsername.Text, txtPassword.Text, cmbDepartment.SelectedValue, cmbRole.SelectedValue, dgvManagement, indexRow);
                        break;
                }
            }
            ClearInput();
            ClearSelection();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (v.CellSelectedValidation(dgvManagement) == true)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to delete this employee?", "WARNING", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        umo.DeleteUser(dgvManagement, indexRow);
                        break;
                }
            }
            ClearInput();
            ClearSelection();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }

        private void DgvManagement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            indexRow = e.RowIndex;
            DataGridViewRow row = dgvManagement.Rows[indexRow];
            txtForename.Text = row.Cells[1].Value.ToString();
            txtLastname.Text = row.Cells[2].Value.ToString();
            txtAddress.Text = row.Cells[3].Value.ToString();
            txtPhoneNumber.Text = row.Cells[4].Value.ToString();
            txtUsername.Text = row.Cells[6].Value.ToString();
            txtPassword.Text = row.Cells[7].Value.ToString();
            cmbDepartment.Text = row.Cells[8].Value.ToString();
            cmbRole.Text = row.Cells[9].Value.ToString();
            lblNote.Visible = true;
        }

        private void DgvManagement_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearInput();
            ClearSelection();
            lblNote.Visible = false;
        }

        private void BtnHolidayRequests_Click(object sender, EventArgs e)
        {
            this.Hide();
            new OutstandingHolidayRequests().Show();
        }

        private void TxtSearchBar_TextChanged(object sender, EventArgs e)
        {
            umo.EmployeeFiltering(txtSearchBar.Text, dgvManagement);
        }

        private void BtnEMLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Login().Show();
        }
    }
}

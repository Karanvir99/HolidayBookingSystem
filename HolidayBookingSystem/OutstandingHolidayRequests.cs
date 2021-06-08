using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HolidayBookingSystem
{
    public partial class OutstandingHolidayRequests : Form
    {
        readonly OutstandingHolidayRequestsClass ohr;
        readonly ValidationClass v;
        int indexRow;

        public OutstandingHolidayRequests()
        {
            InitializeComponent();
            ohr = new OutstandingHolidayRequestsClass();
            v = new ValidationClass();

            ohr.OutstandingRequests(dgvHolidayRequests);
            calendarVisualisation1.Visible = false;
            dtpSearchbyDate.Value = DateTime.Now;
            lblConstraintFlag.Visible = false;
        }

        private void OutstandingHolidayRequests_Load(object sender, EventArgs e)
        {
            ClearSelection();
        }

        private void ClearSelection()
        {
            dgvHolidayRequests.ClearSelection();
            dgvHolidayRequests.CurrentCell = null;

            lblHolidayRequestID.Visible = false;
            lblUserID.Visible = false;
            lblForename.Visible = false;
            lblLastname.Visible = false;
            lblDepartmentID.Visible = false;
            lblRoleID.Visible = false;
            lblstartDate.Visible = false;
            lblendDate.Visible = false;
            btnApprove.Visible = false;
            btnReject.Visible = false;
            lblNote.Visible = false;
            lblHolidaysRemaining.Visible = false;
            lblConstraintMessage.Visible = false;
        }

        private void DgvHolidayRequests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            indexRow = e.RowIndex;
            DataGridViewRow row = dgvHolidayRequests.Rows[indexRow];
            lblHolidayRequestID.Text = row.Cells[0].Value.ToString();
            lblUserID.Text = row.Cells[1].Value.ToString();
            lblForename.Text = row.Cells[2].Value.ToString();
            lblLastname.Text = row.Cells[3].Value.ToString();
            lblDepartmentID.Text = row.Cells[4].Value.ToString();
            lblRoleID.Text = row.Cells[5].Value.ToString();
            lblstartDate.Text = row.Cells[6].Value.ToString();
            lblendDate.Text = row.Cells[7].Value.ToString();

            //Functionality C
            //Constraint checking for holiday entitlement
            constraintChecking1.HolidaysRemaining(int.Parse(lblUserID.Text), lblHolidaysRemaining);
            if (rdoOutstandingRequests.Checked == true && int.Parse(lblHolidaysRemaining.Text) == 0)
            {
                dgvHolidayRequests.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.DarkRed;
                dgvHolidayRequests.Rows[e.RowIndex].DefaultCellStyle.BackColor = ControlPaint.LightLight(Color.PaleVioletRed); 
                dgvHolidayRequests.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                lblConstraintMessage.Visible = true;
                lblConstraintMessage.Text = "Employee has exceeded the number of days of holiday entitlement!";
                btnApprove.Visible = false;
                btnReject.Visible = true;
            }
            else if (rdoOutstandingRequests.Checked == true)
            {
                //Constraint checking for head/deputy head on duty
                constraintChecking1.HeadorDeputyHead(int.Parse(lblUserID.Text), lblConstraintFlag);
                if (int.Parse(lblConstraintFlag.Text) == 1)
                {
                    dgvHolidayRequests.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.DarkRed;
                    dgvHolidayRequests.Rows[e.RowIndex].DefaultCellStyle.BackColor = ControlPaint.LightLight(Color.PaleVioletRed);
                    dgvHolidayRequests.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
                    lblConstraintMessage.Visible = true;
                    lblConstraintMessage.Text = "Head or the deputy head of the department must be on duty!";
                    btnApprove.Visible = false;
                    btnReject.Visible = true;
                }
                else
                {
                    lblConstraintMessage.Visible = false;
                    btnApprove.Visible = true;
                    btnReject.Visible = true;
                }
            }
            else
            {
                btnApprove.Visible = false;
                btnReject.Visible = false;
            }

            #region Holidays Remaining Count Color
            if (int.Parse(lblHolidaysRemaining.Text) == 0)
            {
                lblHolidaysRemaining.ForeColor = Color.DarkRed;
            }
            else
            {
                lblHolidaysRemaining.ForeColor = Color.Green;
            }
            #endregion

            //Functionality F - Parse selected StartDate and EndDate to DateTime, passing it in the method of the calendar visualisation component
            DateTime StartDate = DateTime.Parse(lblstartDate.Text);
            DateTime EndDate = DateTime.Parse(lblendDate.Text);
            lblstartDate.Text = StartDate.ToShortDateString();
            lblendDate.Text = EndDate.ToShortDateString();
            calendarVisualisation1.SelectedBooking(StartDate, EndDate);

            lblHolidayRequestID.Visible = true;
            lblUserID.Visible = true;
            lblForename.Visible = true;
            lblLastname.Visible = true;
            lblDepartmentID.Visible = true;
            lblRoleID.Visible = true;
            lblstartDate.Visible = true;
            lblendDate.Visible = true;
            lblNote.Visible = true;
            lblHolidaysRemaining.Visible = true;
        }

        private void BtnApprove_Click(object sender, EventArgs e)
        {
            if (v.CellSelectedStatusValidation(dgvHolidayRequests) == true)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to update employee status?", "WARNING", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        ohr.UpdateUserStatus("Approved", dgvHolidayRequests, indexRow);
                        break;
                }
            }
            ClearSelection();
        }

        private void BtnReject_Click(object sender, EventArgs e)
        {
            if (v.CellSelectedStatusValidation(dgvHolidayRequests) == true)
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to update employee status?", "WARNING", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        ohr.UpdateUserStatus("Rejected", dgvHolidayRequests, indexRow);
                        break;
                }
            }
            ClearSelection();
        }

        private void DgvHolidayRequests_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearSelection();
        }

        private void BtnOHRLogout_Click(object sender, EventArgs e)
        {
            Hide();
            new Login().Show();
        }

        private void BtnHolidayRequests_Click(object sender, EventArgs e)
        {
            Hide();
            new UserManagement().Show();
        }

        private void TxtSearchBar_TextChanged(object sender, EventArgs e)
        {
            ohr.EmployeeSearchFiltering(txtSearchBar.Text, rdoOutstandingRequests, rdoAllHolidayRequests, rdoApprovedRequests, dgvHolidayRequests);
        }

        private void BtnSearchbyDate_Click(object sender, EventArgs e)
        {
            ohr.EmployeeDateFiltering(dtpSearchbyDate, rdoAllHolidayRequests, dgvHolidayRequests);
        }

        private void BtnResetRecords_Click(object sender, EventArgs e)
        {
            ohr.AllHolidayRequests(dgvHolidayRequests);
            rdoAllHolidayRequests.Checked = true;
            ClearSelection();
        }

        private void RdoOutstandingRequests_CheckedChanged(object sender, EventArgs e)
        {
            calendarVisualisation1.Visible = false;
            ohr.OutstandingRequests(dgvHolidayRequests);
            ClearSelection();
        }

        private void RdoAllHolidayRequests_CheckedChanged(object sender, EventArgs e)
        {
            calendarVisualisation1.Visible = false;
            ohr.AllHolidayRequests(dgvHolidayRequests);
            ClearSelection();
        }

        private void RdoApprovedRequests_CheckedChanged(object sender, EventArgs e)
        {
            calendarVisualisation1.Visible = true;
            ohr.ApprovedRequests(dgvHolidayRequests);
            ClearSelection();
        }
    }
}


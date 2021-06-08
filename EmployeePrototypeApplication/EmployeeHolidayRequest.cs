using EmployeePrototypeApplication.SOAPServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeePrototypeApplication
{
    public partial class EmployeeHolidayRequest : Form
    {
        SOAPWebServiceSoapClient WebService;

        public EmployeeHolidayRequest()
        {
            InitializeComponent();
            WebService = new SOAPWebServiceSoapClient();

            lblUser.Text = EmployeeLogin.userID;
            DisplayRequests(EmployeeLogin.userID);
        }

        private void EmployeeHolidayRequest_Load(object sender, EventArgs e)
        {
            if (WebService.EmployeeName() != null)
            {
                lblEmployeeName.Text = WebService.EmployeeName();
            }

            if (WebService.EmployeeAddress() != null)
            {
                lblEmployeeAddress.Text = WebService.EmployeeAddress();
            }

            if (WebService.EmployeePhoneNumber() != null)
            {
                lblEmployeePhoneNumber.Text = WebService.EmployeePhoneNumber();
            }
        }

        public void DisplayRequests(string userid)
        {
            List<string> HolidayRequest = WebService.LoadData(EmployeeLogin.userID);

            dgvHolidayRequests.ColumnCount = 4;
            dgvHolidayRequests.Columns[0].Name = "Request ID";
            dgvHolidayRequests.Columns[1].Name = "Start Date";
            dgvHolidayRequests.Columns[2].Name = "End Date";
            dgvHolidayRequests.Columns[3].Name = "Status";

            foreach (var request in HolidayRequest)
            {
                string[] individual = request.Split('-');
                dgvHolidayRequests.Rows.Add(individual);
            }

            #region DataGridView Style
            dgvHolidayRequests.BackgroundColor = Color.LightSlateGray;

            //Hide Selection
            dgvHolidayRequests.RowsDefaultCellStyle.SelectionBackColor = Color.Silver;
            dgvHolidayRequests.RowsDefaultCellStyle.SelectionForeColor = Color.Black;

            //Font
            dgvHolidayRequests.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgvHolidayRequests.DefaultCellStyle.Font = new Font("Verdana", 8);

            //Header
            dgvHolidayRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvHolidayRequests.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHolidayRequests.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvHolidayRequests.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dgvHolidayRequests.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvHolidayRequests.EnableHeadersVisualStyles = false;
            dgvHolidayRequests.ColumnHeadersHeight = 25;

            //Row
            dgvHolidayRequests.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHolidayRequests.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHolidayRequests.DefaultCellStyle.BackColor = Color.Silver;
            dgvHolidayRequests.RowHeadersVisible = false;
            dgvHolidayRequests.GridColor = Color.Black;      

            foreach (DataGridViewColumn column in dgvHolidayRequests.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            #endregion
        }

        private void BtnSubmitHolidayRequest_Click(object sender, EventArgs e)
        {
            WebService.SubmitRequest(EmployeeLogin.userID, dtpStartDate.Value.Date, dtpEndDate.Value.Date);
            new EmployeeHolidayRequest().Show();
            Hide();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Hide();
            new EmployeeLogin().Show();
        }
    }
}



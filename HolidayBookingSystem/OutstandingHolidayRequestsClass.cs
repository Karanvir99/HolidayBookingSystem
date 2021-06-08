using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HolidayBookingSystem
{
    public class OutstandingHolidayRequestsClass
    {
        readonly DataClasses1DataContext db;
        ConstraintChecking cc;

        public OutstandingHolidayRequestsClass()
        {
            db = new DataClasses1DataContext();
            cc = new ConstraintChecking();
        }

        //Load Pending Requests (For rdoOustandingRequests)
        public void OutstandingRequests(DataGridView grid)
        {
            var PendingRequests = (from h in db.cpHolidayRequests
                                   where h.status == "Pending"
                                   select new { h.HolidayRequestID, h.UserID, h.cpUser.forename, h.cpUser.lastname, h.cpUser.DepartmentID, h.cpUser.RoleID, h.startDate, h.endDate, h.status });

            grid.DataSource = PendingRequests;
        }

        //Load All Holiday Requests (For rdoAllHolidayRequests)
        public void AllHolidayRequests(DataGridView grid)
        {
            var AllRequests = (from h in db.cpHolidayRequests
                               select new { h.HolidayRequestID, h.UserID, h.cpUser.forename, h.cpUser.lastname, h.cpUser.DepartmentID, h.cpUser.RoleID, h.startDate, h.endDate, h.status });

            grid.DataSource = AllRequests;
        }

        //Load Approved Requests (For rdoApprovedRequests)
        public void ApprovedRequests(DataGridView grid)
        {
            var ApprovedRequests = (from h in db.cpHolidayRequests
                                    where h.status == "Approved"
                                    select new { h.HolidayRequestID, h.UserID, h.cpUser.forename, h.cpUser.lastname, h.cpUser.DepartmentID, h.cpUser.RoleID, h.startDate, h.endDate, h.status });

            grid.DataSource = ApprovedRequests;
        }

        //SearchBar
        public void EmployeeSearchFiltering(string Searchbar, RadioButton OutstandingRequests, RadioButton AllHolidayRequests, RadioButton ApprovedRequests, DataGridView grid)
        {
            #region Outstanding Requests SearchBar
            //Filter Searchbar to pending requests if outstanding requests is checked
            if (OutstandingRequests.Checked == true)
            {
                var SearchValue = Searchbar.TrimStart();
                var SearchEmployeeQuery = (from f in db.cpHolidayRequests
                                           where (f.status == "Pending") && (f.cpUser.forename.StartsWith(SearchValue) || f.cpUser.lastname.StartsWith(SearchValue))
                                           select new { f.HolidayRequestID, f.UserID, f.cpUser.forename, f.cpUser.lastname, f.cpUser.DepartmentID, f.cpUser.RoleID, f.startDate, f.endDate, f.status });

                grid.DataSource = SearchEmployeeQuery;
            }
            #endregion

            #region All Requests SearchBar
            //Filter Searchbar to all requests if all holiday bookings is checked
            if (AllHolidayRequests.Checked == true)
            {
                var SearchValue = Searchbar.TrimStart();
                var SearchEmployeeQuery = (from f in db.cpHolidayRequests
                                           where f.cpUser.forename.StartsWith(SearchValue) || f.cpUser.lastname.StartsWith(SearchValue)
                                           select new { f.HolidayRequestID, f.UserID, f.cpUser.forename, f.cpUser.lastname, f.cpUser.DepartmentID, f.cpUser.RoleID, f.startDate, f.endDate, f.status });

                grid.DataSource = SearchEmployeeQuery;
            }
            #endregion

            #region Approved Requests SearchBar
            //Filter Searchbar to approved requests if on leave is checked
            if (ApprovedRequests.Checked == true)
            {
                var SearchValue = Searchbar.TrimStart();
                var SearchEmployeeQuery = (from f in db.cpHolidayRequests
                                           where (f.status == "Approved") && (f.cpUser.forename.StartsWith(SearchValue) || f.cpUser.lastname.StartsWith(SearchValue))
                                           select new { f.HolidayRequestID, f.UserID, f.cpUser.forename, f.cpUser.lastname, f.cpUser.DepartmentID, f.cpUser.RoleID, f.startDate, f.endDate, f.status });

                grid.DataSource = SearchEmployeeQuery;
            }
            #endregion
        }

        //Filter Record by Date
        public void EmployeeDateFiltering(DateTimePicker dateTimePicker, RadioButton AllHolidayRequests, DataGridView grid)
        {
            if (!string.IsNullOrEmpty(dateTimePicker.Text))
            {
                AllHolidayRequests.Checked = true;
                var SearchbyDateQuery = (from d in db.cpHolidayRequests
                                         where (d.status == "Approved" || d.status == "Rejected") && (d.startDate.Date <= dateTimePicker.Value.Date && d.endDate.Date >= dateTimePicker.Value.Date)
                                         select new { d.HolidayRequestID, d.UserID, d.cpUser.forename, d.cpUser.lastname, d.cpUser.DepartmentID, d.cpUser.RoleID, d.startDate, d.endDate, d.status });

                grid.DataSource = SearchbyDateQuery;
            }
        }

        //Update employee status to approved/rejected 
        public void UpdateUserStatus(string status, DataGridView grid, int indexRow)
        {
            int id = Convert.ToInt32(grid.Rows[indexRow].Cells[0].Value);

            var updateEmployeeStatusQuery = from employeeStatus in db.cpHolidayRequests
                                            where employeeStatus.HolidayRequestID == id
                                            select employeeStatus;

            foreach (cpHolidayRequest request in updateEmployeeStatusQuery)
            {
                if (status == "Approved")
                {
                    request.status = "Approved";
                }
                else if (status == "Rejected")
                {
                    request.status = "Rejected";
                }
            }
            try
            {
                db.SubmitChanges();
                MessageBox.Show("Employee status Successfully Updated!");
                OutstandingRequests(grid);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}



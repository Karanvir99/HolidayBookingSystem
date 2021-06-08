using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace HolidayBookingSystem
{
    public partial class ConstraintChecking : Component
    {
        readonly DataClasses1DataContext db;

        public ConstraintChecking()
        {
            InitializeComponent();
        }

        public ConstraintChecking(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            db = new DataClasses1DataContext();
        }

        //Functionality C

        //Holiday Entitlement constraint
        public void HolidaysRemaining(int employeeID, Label remainingCount)
        {
            //Declarations
            int holidaysRemaining = 30;
            int AdditionalDay = 0;
            int takenHolidays = 0;
            int taken1Day = 0;

            //Select employee joining date for holiday entitlement
            var entitledDays = (from a in db.cpUsers where a.UserID == employeeID select a.dateJoined).Single();

            //Check length of time the employee has been working from joining date to present day
            DateTime noTime = new DateTime(1, 1, 1);
            DateTime presentDay = DateTime.Now;
            DateTime dateJoined = entitledDays.Date;
            TimeSpan timeLength = presentDay - dateJoined;
            int years = (noTime + timeLength).Year - 1;

            //Select employee approved holidays to calculate holidays used
            var usedHolidays = (from a in db.cpHolidayRequests where ((a.UserID == employeeID && a.status == "Approved") && (a.startDate.Year == DateTime.Today.Year)) select a).ToList();

            //Add bonus day for the 5 years the employee worked at the company
            int count = 0;

            for (int i = 0; i < years; i++)
            {
                if (count == 5)
                {
                    count = 0;
                    AdditionalDay += 1;
                }
                count += 1;
            }

            //If employee has only taken 1 day off then count as 1
            foreach (var date in usedHolidays)
            {
                taken1Day = (date.endDate - date.startDate).Days;

                if (taken1Day == 0)
                {
                    taken1Day = 1;
                }
                takenHolidays = takenHolidays + taken1Day;
            }

            //Displays the holidays remaining in a label
            holidaysRemaining = (holidaysRemaining + AdditionalDay) - takenHolidays;
            remainingCount.Text = holidaysRemaining.ToString();

            //If holiday remaining exceeds 30 days then cap the count to 0 (prevents negative value)
            if (holidaysRemaining < 0)
            {
                remainingCount.Text = "0";
            }
        }

        //Head or Deputy Head on duty constraint
        public void HeadorDeputyHead(int employeeID, Label constraint)
        {
            //Declarations
            int constraintFlag = 0;
            DateTime startDate;
            DateTime endDate;
            int department = 0;
            int role;
            int role1 = 0;

            //Getting the employee ID
            var query = (from u in db.cpHolidayRequests
                         where u.UserID == employeeID
                         select u);

            //Getting details of the employee
            foreach (var data in query)
            {
                startDate = data.startDate;
                endDate = data.endDate;
                department = Convert.ToInt32(data.cpUser.DepartmentID);
                role = data.cpUser.RoleID;

                //Role ID of head and deputy head
                if (role == 2 || role == 3)
                {
                    if (role == 2)
                    {
                        role1 = 3;
                    }

                    if (role == 3)
                    {
                        role1 = 2;
                    }

                    //Gets role ID and start and end date of deputy head to detect for conflict with head
                    var query1 = (from u in db.cpHolidayRequests
                                  where (u.endDate >= startDate && endDate <= u.endDate) && (u.cpUser.RoleID == role1)
                                  select u);

                    foreach (var data1 in query1)
                    {
                        if (data1.cpUser.DepartmentID == department)
                        {
                            constraintFlag = 1;
                        }
                    }

                    //Gets role ID and start and end date of head to detect for conflict with deputy head
                    var query2 = (from u in db.cpHolidayRequests
                                  where (u.endDate >= startDate && endDate >= u.endDate) && (u.cpUser.RoleID == role1)
                                  select u);

                    foreach (var data1 in query2)
                    {
                        if (data1.cpUser.DepartmentID == department)
                        {
                            constraintFlag = 1;
                        }
                    }
                }
            }
            //Displays constraint result in label - 1 for broken constraint, 0 for no broken constraint
            constraint.Text = constraintFlag.ToString();
        }
    }
}

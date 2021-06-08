using HolidayBookingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace HolidayBookingOnlineSystem
{
    public class HolidayRequestSubmit
    {
        readonly DataClasses1DataContext db;
        readonly HolidayRequestDetails hrd;
        readonly Validation v;

        public HolidayRequestSubmit()
        {
            db = new DataClasses1DataContext();
            hrd = new HolidayRequestDetails();
            v = new Validation();
        }

        //Clear Calendar after Submitted Requested
        private void ClearCalendar(Calendar StartDate, Calendar EndDate)
        {
            StartDate.SelectedDates.Clear();
            EndDate.SelectedDates.Clear();
        }

        //Save Holiday Request to the Database
        public void SubmitHolidayRequest(Calendar StartDate, Calendar EndDate, Label validation, GridView grid)
        {
            if (v.CalenderSelectDateValidation(StartDate, EndDate, validation) && (v.CalendarCompareDateValidation(StartDate, EndDate, validation)))
            {
                cpHolidayRequest holidayRequest = new cpHolidayRequest
                {
                    UserID = int.Parse(HttpContext.Current.Session["UserID"].ToString()),
                    startDate = StartDate.SelectedDate,
                    endDate = EndDate.SelectedDate,
                    status = "Pending"
                };

                db.cpHolidayRequests.InsertOnSubmit(holidayRequest);
                ClearCalendar(StartDate, EndDate);
                validation.Text = "";
            }
            else
            {
                return;
            }
            try
            {
                db.SubmitChanges();
                HttpContext.Current.Response.Write("<script>alert('Holiday Requested!');</script>");
                hrd.LoadHolidayRequests(grid);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
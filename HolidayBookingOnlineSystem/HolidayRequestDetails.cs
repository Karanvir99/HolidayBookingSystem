using HolidayBookingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace HolidayBookingOnlineSystem
{
    public class HolidayRequestDetails
    {
        readonly DataClasses1DataContext db;
        readonly Validation v;

        public HolidayRequestDetails()
        {
            db = new DataClasses1DataContext();
            v = new Validation();
        }

        //Load Employee Details in Datagridview based on User Session
        public void LoadHolidayRequests(GridView grid)
        {
            var session = HttpContext.Current.Session["UserID"];

            var HolidayRequests = (from h in db.cpHolidayRequests
                                   where h.UserID.Equals(session)
                                   select new { h.HolidayRequestID, h.UserID, startDate = h.startDate.ToShortDateString(), endDate = h.endDate.ToShortDateString(), h.status });

            grid.DataSource = HolidayRequests;
            grid.DataBind();
        }

        //Bind Employee Details to labels based on User Session
        public void HolidayDetails(Label OutstandingHolidays, Label HolidaysApproved, Label HolidaysRejected)
        {
            var session = HttpContext.Current.Session["UserID"];

            var OutstandingHolidaysCount = (from u in db.cpHolidayRequests
                                            where u.UserID.Equals(session) && u.status == "Pending"
                                            select u).Count();
            #region OutstandingHolidays Day/Days
            if (OutstandingHolidaysCount == 1)
            {
                OutstandingHolidays.Text = OutstandingHolidaysCount.ToString() + " Holiday";
            }
            else
            {
                OutstandingHolidays.Text = OutstandingHolidaysCount.ToString() + " Holidays";
            }
            #endregion

            var ApprovedHolidaysCount = (from u in db.cpHolidayRequests
                                         where u.UserID.Equals(session) && u.status == "Approved"
                                         select u).Count();
            #region ApprovedHolidays Day/Days
            if (ApprovedHolidaysCount == 1)
            {
                HolidaysApproved.Text = ApprovedHolidaysCount.ToString() + " Holiday";
            }
            else
            {
                HolidaysApproved.Text = ApprovedHolidaysCount.ToString() + " Holidays";
            }
            #endregion

            var RejectedHolidaysCount = (from u in db.cpHolidayRequests
                                         where u.UserID.Equals(session) && u.status == "Rejected"
                                         select u).Count();
            #region RejectedHolidays Day/Days
            if (RejectedHolidaysCount == 1)
            {
                HolidaysRejected.Text = RejectedHolidaysCount.ToString() + " Holiday";
            }
            else
            {
                HolidaysRejected.Text = RejectedHolidaysCount.ToString() + " Holidays";
            }
            #endregion
        }
    }
}
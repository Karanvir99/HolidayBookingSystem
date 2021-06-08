using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using HolidayBookingSystem;

namespace HolidayBookingOnlineSystem
{
    public partial class HolidayRequestPage : System.Web.UI.Page
    {
        readonly HolidayRequestDetails hrd = new HolidayRequestDetails();
        readonly HolidayRequestSubmit hrs = new HolidayRequestSubmit();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblEmployeeName.Text = Session["EmployeeName"].ToString();
                lblEmployeeAddress.Text = Session["Address"].ToString();
                lblEmployeePhoneNumber.Text = Session["PhoneNumber"].ToString();

                hrd.LoadHolidayRequests(dgvHolidayRequests);
                hrd.HolidayDetails(lblPendingHolidays, lblApproved, lblRejected);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            hrs.SubmitHolidayRequest(cdrStartDate, cdrEndDate, lblValidation, dgvHolidayRequests);
            hrd.HolidayDetails(lblPendingHolidays, lblApproved, lblRejected);
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["UserID"] = null;
            Session["EmployeeName"] = null;
            Session["Address"] = null;
            Session["PhoneNumber"] = null;
            Response.Redirect("~/LoginEmployeePage.aspx");
        }
    }
}
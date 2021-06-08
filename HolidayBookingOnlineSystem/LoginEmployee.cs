using HolidayBookingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace HolidayBookingOnlineSystem
{
    public class LoginEmployee
    {
        DataClasses1DataContext db;

        //Employee login with sessions
        public void LoginValidation(string username, string password, Label validation)
        {
            db = new DataClasses1DataContext();

            var user = (from u in db.cpUsers
                        where u.username == username
                        select new { u.UserID, u.forename, u.lastname, u.password, u.admin, u.address, u.phoneNumber }).FirstOrDefault();

            if (user != null && user.password == password && user.admin == false)
            {
                HttpContext.Current.Session["UserID"] = user.UserID;
                HttpContext.Current.Session["EmployeeName"] = user.forename + " " + user.lastname;
                HttpContext.Current.Session["Address"] = user.address;
                HttpContext.Current.Session["PhoneNumber"] = user.phoneNumber;
                HttpContext.Current.Response.Redirect("~/HolidayRequestPage.aspx");
            }
            else if (username == "" || password == "")
            {
                validation.Text = "Please Check Your Username or Password!";
            }
            else
            {
                validation.Text = "Username/Password is Incorrect!";
            }
        }
    }
}
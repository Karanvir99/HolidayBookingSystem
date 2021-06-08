using EmployeePrototypeApplication;
using HolidayBookingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Windows.Forms;

namespace SOAP
{
    /// <summary>
    /// Summary description for SOAPWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SOAPWebService : System.Web.Services.WebService
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        //Login Validation
        [WebMethod (EnableSession = true)]
        public int LoginValidation(string username, string password)
        {
            int hideForm = 0;

            var user = (from u in db.cpUsers
                        where u.username == username
                        select u).FirstOrDefault();

            if (user != null && user.password == password && user.admin == false)
            {
                Session["Name"] = user.forename.ToString() + " " + user.lastname.ToString();
                Session["Address"] = user.address.ToString();
                Session["PhoneNumber"] = user.phoneNumber.ToString();
                hideForm = 1;
            }
            else if (username == "" || password == "")
            {
                MessageBox.Show("Please enter your Username and Password!");
            }
            else
            {
                MessageBox.Show("Username/Password is Incorrect!");
            }

            return hideForm;
        }

        //Sessions to pass the employee details
        //---------------------------------------------------------------------------//
        string name;

        [WebMethod(EnableSession = true)]

        public string EmployeeName()
        {
            if (Session["Name"] != null)
            {
                name = Session["Name"].ToString();
            }

            return name;
        }

        string address;

        [WebMethod(EnableSession = true)]

        public string EmployeeAddress()
        {
            if (Session["Address"] != null)
            {
                address = Session["Address"].ToString();
            }

            return address;
        }

        string PhoneNumber;

        [WebMethod(EnableSession = true)]

        public string EmployeePhoneNumber()
        {
            if (Session["PhoneNumber"] != null)
            {
                PhoneNumber = Session["PhoneNumber"].ToString();
            }

            return PhoneNumber;
        }
        //---------------------------------------------------------------------------//

        //Load employee holiday request details
        [WebMethod]
        public List<string> LoadData(string userid)
        {
            List<string> requests = new List<string>();
            var query = (from h in db.cpHolidayRequests
                         where h.UserID == int.Parse(userid)
                         select h);

            foreach (var hr in query)
            {
                string result = hr.HolidayRequestID.ToString() + "-" + hr.startDate.ToShortDateString() + "-" + hr.endDate.ToShortDateString() + "-" + hr.status;
                requests.Add(result);
            }

            return requests;
        }

        //Save employee holiday request to DB
        [WebMethod]
        public void SubmitRequest(string userid, DateTime StartDate, DateTime EndDate)
        {
            if (CalendarCompareDateValidation(StartDate, EndDate))
            {
                cpHolidayRequest holidayRequest = new cpHolidayRequest
                {
                    UserID = int.Parse(userid),
                    startDate = StartDate,
                    endDate = EndDate,
                    status = "Pending"
                };

                db.cpHolidayRequests.InsertOnSubmit(holidayRequest);
            }
            else
            {
                return;
            }
            try
            {
                db.SubmitChanges();
                MessageBox.Show("Holiday Requested!");
                LoadData(userid);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        //Calendar validation
        [WebMethod]
        public bool CalendarCompareDateValidation(DateTime StartDate, DateTime EndDate)
        {
            if (StartDate.Date > EndDate.Date)
            {
                MessageBox.Show("Selected Dates Invalid!");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}


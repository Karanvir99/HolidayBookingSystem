using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HolidayBookingOnlineSystem
{
    public partial class LoginEmployeePage : System.Web.UI.Page
    {
        readonly LoginEmployee lc = new LoginEmployee();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lc.LoginValidation(txtUsername.Text, txtPassword.Text, lblvalidation);
        }
    }
}


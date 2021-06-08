using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeePrototypeApplication.SOAPServiceReference;

namespace EmployeePrototypeApplication
{
    public partial class EmployeeLogin : Form
    {
        SOAPWebServiceSoapClient WebService;

        public static string userID;

        public EmployeeLogin()
        {
            InitializeComponent();
            WebService = new SOAPWebServiceSoapClient();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (WebService.LoginValidation(txtUsername.Text, txtPassword.Text) == 1)
            {
                userID = txtUsername.Text;
                EmployeeHolidayRequest nextForm = new EmployeeHolidayRequest();
                nextForm.Show();
                this.Hide();
            }

            WebService.LoginValidation(txtUsername.Text, txtPassword.Text);
        }
    }
}

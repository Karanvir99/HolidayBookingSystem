using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HolidayBookingSystem
{
    public class LoginClass
    {
        readonly DataClasses1DataContext db;
        public LoginClass()
        {
            db = new DataClasses1DataContext();
        }

        public void UserLogin(string username, string password, Form form, TextBox passwordTb)
        {
            var user = (from u in db.cpUsers
                        where u.username == username
                        select u).FirstOrDefault();

            if (user != null && user.password == password && user.admin == true)
            {
                form.Hide();
                new UserManagement().Show();
            }
            else if (username == "" || password == "")
            {
                MessageBox.Show("Please enter your Username and Password!");
            }
            else
            {
                MessageBox.Show("Username/Password is Incorrect!");
                passwordTb.Clear();
            }
        }
    }
}
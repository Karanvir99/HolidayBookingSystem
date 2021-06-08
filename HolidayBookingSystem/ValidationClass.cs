using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HolidayBookingSystem
{
    public class ValidationClass
    {
        DataClasses1DataContext db;
        public ValidationClass()
        {
            db = new DataClasses1DataContext();
        }

        //Empty Fields validation
        public bool InputValidation(string forename, string lastname, string address, string phoneNumber, string username, string password, object departmentID, object roleID)
        {
            if (forename == "" || lastname == "" || address == "" || phoneNumber == "" || username == "" || password == "" || departmentID == null || roleID == null)
            {
                MessageBox.Show("Please fill in the empty fields!");
                return false;
            }
            else
            {
                return true;
            }
        }

        //Exisiting employee validation
        public bool UserExistsValidation(string username)
        {
            var userExists = (from u in db.cpUsers
                              where u.username == username
                              select u).Any();

            if (!userExists)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Username Already Exists!");
                return false;
            }
        }

        //Select employee to update/delete validation
        public bool CellSelectedValidation(DataGridView grid)
        {
            if (grid.CurrentCell == null)
            {
                MessageBox.Show("Please select the employee you wish to update/delete!");
                return false;
            }
            else
            {
                return true;
            }
        }

        //Select employee to approve/reject validation
        public bool CellSelectedStatusValidation(DataGridView grid)
        {
            if (grid.CurrentCell == null)
            {
                MessageBox.Show("Please select the employee request you wish to approve/reject!");
                return false;
            }
            else
            {
                return true;
            }
        }

        //One head or deputy head validation
        public bool OneHeadorDeputyHead(object departmentID, object role)
        {
            int roleSelected = (int)role;
            var roleExists = (from u in db.cpUsers
                              where u.DepartmentID == (int)departmentID && u.RoleID == 2 || u.RoleID == 3
                              select u);

            if (roleExists != null)
            {
                if (roleSelected == 2 || roleSelected == 3)
                {
                    MessageBox.Show("Only one Head/Deputy Head Permitted for a Department!");
                    return false;
                }
            }
            return true;
        }
    }
}

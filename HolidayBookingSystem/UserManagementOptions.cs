using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HolidayBookingSystem
{
    public class UserManagementOptions
    {
        readonly DataClasses1DataContext db;
        readonly ValidationClass v;

        public UserManagementOptions()
        {
            db = new DataClasses1DataContext();
            v = new ValidationClass();
        }

        //Add new employee
        public void AddUser(string forename, string lastname, string address, string phoneNumber, string username, string password, object departmentID, object roleID, DataGridView grid)
        {
            if (v.InputValidation(forename, lastname, address, phoneNumber, username, password, departmentID, roleID))
            {
                if (v.UserExistsValidation(username))
                {
                    cpUser user = new cpUser
                    {
                        forename = forename,
                        lastname = lastname,
                        address = address,
                        phoneNumber = phoneNumber,
                        dateJoined = DateTime.Now,
                        username = username,
                        password = password,
                        DepartmentID = (int)departmentID,
                        RoleID = (int)roleID
                    };

                    if ((int)roleID == 1)
                    {
                        user.admin = true;
                    }
                    else
                    {
                        user.admin = false;
                    }

                    if (v.OneHeadorDeputyHead(departmentID, roleID))
                    {
                        db.cpUsers.InsertOnSubmit(user);
                    }
                    else
                    {
                        return;
                    }

                    try
                    {
                        db.SubmitChanges();
                        MessageBox.Show("Employee Successfully Saved!");
                        LoadData(grid);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex);
                        throw;
                    }
                }
            }
        }

        //Update employee details
        public void UpdateUser(string forename, string lastname, string address, string phoneNumber, string username, string password, object departmentID, object roleID, DataGridView grid, int indexRow)
        {
            if (v.InputValidation(forename, lastname, address, phoneNumber, username, password, departmentID, roleID))
            {
                int id = Convert.ToInt32(grid.Rows[indexRow].Cells[0].Value);

                var updateUserQuery = from user in db.cpUsers
                                      where user.UserID == id
                                      select user;

                foreach (cpUser user in updateUserQuery)
                {
                    user.forename = forename;
                    user.lastname = lastname;
                    user.address = address;
                    user.phoneNumber = phoneNumber;
                  
                    if (v.UserExistsValidation(username))
                    {
                        user.username = username;
                    }
                    user.password = password;
                    user.DepartmentID = (int)departmentID;
                    user.RoleID = (int)roleID;
                }

                try
                {
                    db.SubmitChanges();
                    MessageBox.Show("Employee Successfully Updated!");
                    LoadData(grid);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
        }

        //Delete employee details
        public void DeleteUser(DataGridView grid, int indexRow)
        {
            int id = Convert.ToInt32(grid.Rows[indexRow].Cells[0].Value);

            var deleteUserQuery = from user in db.cpUsers
                                  where user.UserID == id
                                  select user;

            foreach (var user in deleteUserQuery)
            {
                db.cpUsers.DeleteOnSubmit(user);
            }

            try
            {
                db.SubmitChanges();
                MessageBox.Show("Employee Successfully Deleted!");
                LoadData(grid);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                throw;
            }
        }

        //Load employee details
        public void LoadData(DataGridView grid)
        {
            var query = (from d in db.cpUsers
                         where d.admin == false
                         select new { d.UserID, d.forename, d.lastname, d.address, d.phoneNumber, d.dateJoined, d.username, d.password, d.cpDepartment.departmentName, d.cpRole.roleName });

            grid.DataSource = query;
        }

        //Departments Datasource
        public void DisplayDepartments(ComboBox department)
        {
            var displayDepartmentsQuery = from departmentName
                                          in db.cpDepartments
                                          select departmentName;

            department.DataSource = displayDepartmentsQuery;
            department.DisplayMember = "DepartmentName";
            department.ValueMember = "DepartmentID";
        }

        //Employee roles Datasource
        public void DisplayRoles(ComboBox role)
        {
            var displayRolesQuery = from roleName
                                    in db.cpRoles
                                    select roleName;

            role.DataSource = displayRolesQuery;
            role.DisplayMember = "RoleName";
            role.ValueMember = "RoleID";
        }

        //SearchBar
        public void EmployeeFiltering(string Searchbar, DataGridView grid)
        {
            var SearchValue = Searchbar.TrimStart();
            var searchEmployeeQuery = (from f in db.cpUsers
                                       where f.forename.StartsWith(SearchValue)
                                       select new { f.UserID, f.forename, f.lastname, f.address, f.phoneNumber, f.dateJoined, f.username, f.password, f.cpDepartment.departmentName, f.cpRole.roleName });

            grid.DataSource = searchEmployeeQuery;
        }
    }
}

using HolidayBookingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace HolidayBookingOnlineSystem
{
    public class Validation
    {
        DataClasses1DataContext db;

        public Validation()
        {
            db = new DataClasses1DataContext();
        }

        //Select Dates Validation
        public bool CalenderSelectDateValidation(Calendar StartDate, Calendar EndDate, Label validation)
        {
            if (StartDate.SelectedDate.Date == DateTime.MinValue || EndDate.SelectedDate.Date == DateTime.MinValue)
            {
                validation.Text = "Please select a Start Date and End Date!";
                return false;
            }
            else
            {
                return true;
            }
        }

        //Selected Dates Comparison Validation
        public bool CalendarCompareDateValidation(Calendar StartDate, Calendar EndDate, Label validation)
        {
            if (StartDate.SelectedDate.Date > EndDate.SelectedDate.Date)
            {
                validation.Text = "Selected Dates Invalid!";
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
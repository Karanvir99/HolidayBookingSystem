using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HolidayBookingSystem
{
    public partial class CalendarVisualisation : MonthCalendar
    {
        public CalendarVisualisation()
        {
            InitializeComponent();
        }

        public CalendarVisualisation(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        //Functionality F - Gets Selected Range of Dates from StartDate to EndDate, highighting the dates in the selection range to bold
        public DateTime[] SelectedBooking(DateTime StartDate, DateTime EndDate)
        {
            DateTime[] Absent = { StartDate, EndDate };
            SelectionRange = new SelectionRange(StartDate, EndDate);
            this.BoldedDates = Absent;
            return Absent;

        }
    }
}

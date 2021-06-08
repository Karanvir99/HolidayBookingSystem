using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HolidayBookingSystem
{
    public partial class PhoneNumber : TextBox
    {
        public PhoneNumber()
        {
            InitializeComponent();
        }

        public PhoneNumber(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        //Functionality B - Text length greater than 11 characters turns text red, else black
        protected override void OnTextChanged(EventArgs e)
        {
            if (Text.Length > 11)
            {
                ForeColor = Color.Red;
            }
            else
            {
                ForeColor = Color.Black;
            }
        }

        //TextBox onKeyPress
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) && (!char.IsControl(e.KeyChar))))
            {
                e.Handled = true;
            }
        }
    }
}

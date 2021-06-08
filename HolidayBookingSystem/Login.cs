﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HolidayBookingSystem
{
    public partial class Login : Form
    {
        LoginClass lc;
        public Login()
        {
            InitializeComponent();
            lc = new LoginClass();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            lc.UserLogin(txtUsername.Text, txtPassword.Text, this, txtPassword);
        }
    }
}

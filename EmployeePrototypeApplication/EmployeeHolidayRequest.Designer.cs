namespace EmployeePrototypeApplication
{
    partial class EmployeeHolidayRequest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblUsername = new System.Windows.Forms.Label();
            this.dgvHolidayRequests = new System.Windows.Forms.DataGridView();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.btnSubmitHolidayRequest = new System.Windows.Forms.Button();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.lblEmployeeAddress = new System.Windows.Forms.Label();
            this.lblEmployeePhoneNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHolidayRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblUsername.Location = new System.Drawing.Point(134, 104);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(90, 18);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            // 
            // dgvHolidayRequests
            // 
            this.dgvHolidayRequests.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHolidayRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHolidayRequests.Location = new System.Drawing.Point(12, 518);
            this.dgvHolidayRequests.Name = "dgvHolidayRequests";
            this.dgvHolidayRequests.Size = new System.Drawing.Size(345, 170);
            this.dgvHolidayRequests.TabIndex = 1;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Verdana", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(66, 31);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(233, 32);
            this.lblLogin.TabIndex = 9;
            this.lblLogin.Text = "Holiday Request";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblUser.Location = new System.Drawing.Point(139, 132);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(53, 13);
            this.lblUser.TabIndex = 12;
            this.lblUser.Text = "lblUser";
            // 
            // btnSubmitHolidayRequest
            // 
            this.btnSubmitHolidayRequest.BackColor = System.Drawing.Color.Black;
            this.btnSubmitHolidayRequest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmitHolidayRequest.FlatAppearance.BorderSize = 0;
            this.btnSubmitHolidayRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitHolidayRequest.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSubmitHolidayRequest.ForeColor = System.Drawing.Color.White;
            this.btnSubmitHolidayRequest.Location = new System.Drawing.Point(124, 468);
            this.btnSubmitHolidayRequest.Name = "btnSubmitHolidayRequest";
            this.btnSubmitHolidayRequest.Size = new System.Drawing.Size(116, 30);
            this.btnSubmitHolidayRequest.TabIndex = 15;
            this.btnSubmitHolidayRequest.Text = "Submit Request";
            this.btnSubmitHolidayRequest.UseVisualStyleBackColor = false;
            this.btnSubmitHolidayRequest.Click += new System.EventHandler(this.BtnSubmitHolidayRequest_Click);
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblStartDate.Location = new System.Drawing.Point(133, 276);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(93, 18);
            this.lblStartDate.TabIndex = 18;
            this.lblStartDate.Text = "Start Date";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblEndDate.Location = new System.Drawing.Point(139, 371);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(83, 18);
            this.lblEndDate.TabIndex = 19;
            this.lblEndDate.Text = "End Date";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(109, 301);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(141, 20);
            this.dtpStartDate.TabIndex = 20;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(109, 396);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(141, 20);
            this.dtpEndDate.TabIndex = 21;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.Black;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(292, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 30);
            this.btnLogout.TabIndex = 22;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblEmployeeName.Location = new System.Drawing.Point(134, 174);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(96, 13);
            this.lblEmployeeName.TabIndex = 27;
            this.lblEmployeeName.Text = "EmployeeName";
            // 
            // lblEmployeeAddress
            // 
            this.lblEmployeeAddress.AutoSize = true;
            this.lblEmployeeAddress.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblEmployeeAddress.Location = new System.Drawing.Point(134, 201);
            this.lblEmployeeAddress.Name = "lblEmployeeAddress";
            this.lblEmployeeAddress.Size = new System.Drawing.Size(109, 13);
            this.lblEmployeeAddress.TabIndex = 28;
            this.lblEmployeeAddress.Text = "EmployeeAddress";
            // 
            // lblEmployeePhoneNumber
            // 
            this.lblEmployeePhoneNumber.AutoSize = true;
            this.lblEmployeePhoneNumber.Font = new System.Drawing.Font("Verdana", 8.25F);
            this.lblEmployeePhoneNumber.Location = new System.Drawing.Point(134, 228);
            this.lblEmployeePhoneNumber.Name = "lblEmployeePhoneNumber";
            this.lblEmployeePhoneNumber.Size = new System.Drawing.Size(98, 13);
            this.lblEmployeePhoneNumber.TabIndex = 29;
            this.lblEmployeePhoneNumber.Text = "EmployeePhone";
            // 
            // EmployeeHolidayRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(369, 700);
            this.Controls.Add(this.lblEmployeePhoneNumber);
            this.Controls.Add(this.lblEmployeeAddress);
            this.Controls.Add(this.lblEmployeeName);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.btnSubmitHolidayRequest);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.dgvHolidayRequests);
            this.Controls.Add(this.lblUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmployeeHolidayRequest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EmployeeHolidayRequest";
            this.Load += new System.EventHandler(this.EmployeeHolidayRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHolidayRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.DataGridView dgvHolidayRequests;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnSubmitHolidayRequest;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.Label lblEmployeeAddress;
        private System.Windows.Forms.Label lblEmployeePhoneNumber;
    }
}
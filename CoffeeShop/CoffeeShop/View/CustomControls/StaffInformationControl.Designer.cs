namespace CoffeeShop.View.MainFrame
{
    partial class StaffInformationControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.dtpDob = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.txtStaffName = new Guna.UI2.WinForms.Guna2TextBox();
            this.rdoOther = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoFemale = new System.Windows.Forms.RadioButton();
            this.rdoMale = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.txtRole = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbChangePassword = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNewPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.panelChangePassword = new Guna.UI2.WinForms.Guna2Panel();
            this.checkBoxShowPassword = new System.Windows.Forms.CheckBox();
            this.lbErrorMessage = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtOldPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtConfirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.panelChangePassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(125)))), ((int)(((byte)(232)))));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(31, 302);
            this.btnImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(185, 34);
            this.btnImport.TabIndex = 57;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.BorderThickness = 1;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(51)))), ((int)(((byte)(25)))));
            this.btnCancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(944, 773);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(147, 36);
            this.btnCancel.TabIndex = 62;
            this.btnCancel.Text = "Cancel";
            // 
            // dtpDob
            // 
            this.dtpDob.Checked = true;
            this.dtpDob.FillColor = System.Drawing.Color.White;
            this.dtpDob.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDob.ForeColor = System.Drawing.Color.Black;
            this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDob.Location = new System.Drawing.Point(452, 356);
            this.dtpDob.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpDob.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDob.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDob.Name = "dtpDob";
            this.dtpDob.Size = new System.Drawing.Size(257, 46);
            this.dtpDob.TabIndex = 56;
            this.dtpDob.Value = new System.DateTime(2024, 10, 7, 11, 4, 24, 43);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.BorderRadius = 10;
            this.btnEdit.BorderThickness = 1;
            this.btnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(125)))), ((int)(((byte)(232)))));
            this.btnEdit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.Black;
            this.btnEdit.Location = new System.Drawing.Point(457, 773);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(139, 36);
            this.btnEdit.TabIndex = 60;
            this.btnEdit.Text = "Edit";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(206, 29);
            this.label9.TabIndex = 28;
            this.label9.Text = "Staff Information";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.BorderColor = System.Drawing.Color.Black;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(452, 246);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PlaceholderText = "Enter Email";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(947, 30);
            this.txtEmail.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtEmail.TabIndex = 52;
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.BorderColor = System.Drawing.Color.Black;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.DefaultText = "";
            this.txtPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhone.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.ForeColor = System.Drawing.Color.Black;
            this.txtPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhone.Location = new System.Drawing.Point(452, 167);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PasswordChar = '\0';
            this.txtPhone.PlaceholderText = "Enter Phone No";
            this.txtPhone.SelectedText = "";
            this.txtPhone.Size = new System.Drawing.Size(947, 30);
            this.txtPhone.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtPhone.TabIndex = 51;
            // 
            // picAvatar
            // 
            this.picAvatar.BackColor = System.Drawing.Color.LightGray;
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.ErrorImage = null;
            this.picAvatar.Location = new System.Drawing.Point(31, 68);
            this.picAvatar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(185, 235);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 37;
            this.picAvatar.TabStop = false;
            // 
            // txtStaffName
            // 
            this.txtStaffName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStaffName.BorderColor = System.Drawing.Color.Black;
            this.txtStaffName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtStaffName.DefaultText = "";
            this.txtStaffName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtStaffName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtStaffName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtStaffName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtStaffName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtStaffName.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStaffName.ForeColor = System.Drawing.Color.Black;
            this.txtStaffName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtStaffName.Location = new System.Drawing.Point(452, 84);
            this.txtStaffName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStaffName.Name = "txtStaffName";
            this.txtStaffName.PasswordChar = '\0';
            this.txtStaffName.PlaceholderText = "Enter Name\r\n";
            this.txtStaffName.SelectedText = "";
            this.txtStaffName.Size = new System.Drawing.Size(947, 30);
            this.txtStaffName.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.txtStaffName.TabIndex = 50;
            // 
            // rdoOther
            // 
            this.rdoOther.AutoSize = true;
            this.rdoOther.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoOther.Location = new System.Drawing.Point(944, 306);
            this.rdoOther.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoOther.Name = "rdoOther";
            this.rdoOther.Size = new System.Drawing.Size(70, 23);
            this.rdoOther.TabIndex = 55;
            this.rdoOther.TabStop = true;
            this.rdoOther.Text = "Other";
            this.rdoOther.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(276, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 24);
            this.label3.TabIndex = 24;
            this.label3.Text = "Name";
            // 
            // rdoFemale
            // 
            this.rdoFemale.AutoSize = true;
            this.rdoFemale.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoFemale.Location = new System.Drawing.Point(691, 308);
            this.rdoFemale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoFemale.Name = "rdoFemale";
            this.rdoFemale.Size = new System.Drawing.Size(83, 23);
            this.rdoFemale.TabIndex = 54;
            this.rdoFemale.TabStop = true;
            this.rdoFemale.Text = "Female";
            this.rdoFemale.UseVisualStyleBackColor = true;
            // 
            // rdoMale
            // 
            this.rdoMale.AutoSize = true;
            this.rdoMale.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoMale.Location = new System.Drawing.Point(452, 308);
            this.rdoMale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoMale.Name = "rdoMale";
            this.rdoMale.Size = new System.Drawing.Size(64, 23);
            this.rdoMale.TabIndex = 53;
            this.rdoMale.TabStop = true;
            this.rdoMale.Text = "Male";
            this.rdoMale.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(276, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 24);
            this.label8.TabIndex = 31;
            this.label8.Text = "Gender";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(276, 463);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 24);
            this.label7.TabIndex = 29;
            this.label7.Text = "Role";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(273, 372);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 24);
            this.label6.TabIndex = 27;
            this.label6.Text = "Date of Birth";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(276, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 24);
            this.label5.TabIndex = 26;
            this.label5.Text = "Phone";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(276, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 24);
            this.label4.TabIndex = 25;
            this.label4.Text = "Email";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.BorderRadius = 10;
            this.btnSave.BorderThickness = 1;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(125)))), ((int)(((byte)(232)))));
            this.btnSave.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(691, 773);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(139, 36);
            this.btnSave.TabIndex = 61;
            this.btnSave.Text = "Save";
            // 
            // txtRole
            // 
            this.txtRole.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRole.DefaultText = "";
            this.txtRole.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRole.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRole.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRole.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRole.Enabled = false;
            this.txtRole.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRole.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRole.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRole.Location = new System.Drawing.Point(452, 448);
            this.txtRole.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtRole.Name = "txtRole";
            this.txtRole.PasswordChar = '\0';
            this.txtRole.PlaceholderText = "";
            this.txtRole.SelectedText = "";
            this.txtRole.Size = new System.Drawing.Size(257, 36);
            this.txtRole.TabIndex = 56;
            // 
            // lbChangePassword
            // 
            this.lbChangePassword.AutoSize = true;
            this.lbChangePassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChangePassword.Location = new System.Drawing.Point(453, 510);
            this.lbChangePassword.Name = "lbChangePassword";
            this.lbChangePassword.Size = new System.Drawing.Size(171, 23);
            this.lbChangePassword.TabIndex = 29;
            this.lbChangePassword.Text = "Change Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 24);
            this.label1.TabIndex = 29;
            this.label1.Text = "Old Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 24);
            this.label2.TabIndex = 29;
            this.label2.Text = "New Password";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(19, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 24);
            this.label10.TabIndex = 29;
            this.label10.Text = "Confirm";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNewPassword.DefaultText = "";
            this.txtNewPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNewPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNewPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNewPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNewPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNewPassword.Location = new System.Drawing.Point(200, 95);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '●';
            this.txtNewPassword.PlaceholderText = "New Password";
            this.txtNewPassword.SelectedText = "";
            this.txtNewPassword.Size = new System.Drawing.Size(257, 30);
            this.txtNewPassword.TabIndex = 58;
            // 
            // panelChangePassword
            // 
            this.panelChangePassword.Controls.Add(this.checkBoxShowPassword);
            this.panelChangePassword.Controls.Add(this.lbErrorMessage);
            this.panelChangePassword.Controls.Add(this.label1);
            this.panelChangePassword.Controls.Add(this.txtOldPassword);
            this.panelChangePassword.Controls.Add(this.txtConfirmPassword);
            this.panelChangePassword.Controls.Add(this.txtNewPassword);
            this.panelChangePassword.Controls.Add(this.label2);
            this.panelChangePassword.Controls.Add(this.label10);
            this.panelChangePassword.Location = new System.Drawing.Point(257, 535);
            this.panelChangePassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelChangePassword.Name = "panelChangePassword";
            this.panelChangePassword.Size = new System.Drawing.Size(1112, 231);
            this.panelChangePassword.TabIndex = 61;
            this.panelChangePassword.Visible = false;
            // 
            // checkBoxShowPassword
            // 
            this.checkBoxShowPassword.AutoSize = true;
            this.checkBoxShowPassword.Location = new System.Drawing.Point(200, 190);
            this.checkBoxShowPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxShowPassword.Name = "checkBoxShowPassword";
            this.checkBoxShowPassword.Size = new System.Drawing.Size(125, 20);
            this.checkBoxShowPassword.TabIndex = 60;
            this.checkBoxShowPassword.Text = "Show Password";
            this.checkBoxShowPassword.UseVisualStyleBackColor = true;
            // 
            // lbErrorMessage
            // 
            this.lbErrorMessage.BackColor = System.Drawing.Color.Transparent;
            this.lbErrorMessage.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lbErrorMessage.Location = new System.Drawing.Point(195, 4);
            this.lbErrorMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbErrorMessage.Name = "lbErrorMessage";
            this.lbErrorMessage.Size = new System.Drawing.Size(3, 2);
            this.lbErrorMessage.TabIndex = 46;
            this.lbErrorMessage.Text = null;
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOldPassword.DefaultText = "";
            this.txtOldPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtOldPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtOldPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOldPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOldPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOldPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOldPassword.Location = new System.Drawing.Point(200, 38);
            this.txtOldPassword.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '●';
            this.txtOldPassword.PlaceholderText = "Old Password";
            this.txtOldPassword.SelectedText = "";
            this.txtOldPassword.Size = new System.Drawing.Size(257, 30);
            this.txtOldPassword.TabIndex = 57;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmPassword.DefaultText = "";
            this.txtConfirmPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtConfirmPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtConfirmPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmPassword.Location = new System.Drawing.Point(200, 151);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '●';
            this.txtConfirmPassword.PlaceholderText = "Confirm New Password";
            this.txtConfirmPassword.SelectedText = "";
            this.txtConfirmPassword.Size = new System.Drawing.Size(257, 30);
            this.txtConfirmPassword.TabIndex = 59;
            // 
            // StaffInformationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelChangePassword);
            this.Controls.Add(this.txtRole);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dtpDob);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.picAvatar);
            this.Controls.Add(this.txtStaffName);
            this.Controls.Add(this.rdoOther);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rdoFemale);
            this.Controls.Add(this.rdoMale);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbChangePassword);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "StaffInformationControl";
            this.Size = new System.Drawing.Size(1455, 850);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.panelChangePassword.ResumeLayout(false);
            this.panelChangePassword.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button btnImport;
        public Guna.UI2.WinForms.Guna2Button btnCancel;
        public Guna.UI2.WinForms.Guna2DateTimePicker dtpDob;
        public Guna.UI2.WinForms.Guna2Button btnEdit;
        public Guna.UI2.WinForms.Guna2TextBox txtEmail;
        public Guna.UI2.WinForms.Guna2TextBox txtPhone;
        public System.Windows.Forms.PictureBox picAvatar;
        public Guna.UI2.WinForms.Guna2TextBox txtStaffName;
        public System.Windows.Forms.RadioButton rdoOther;
        public System.Windows.Forms.RadioButton rdoFemale;
        public System.Windows.Forms.RadioButton rdoMale;
        public Guna.UI2.WinForms.Guna2Button btnSave;
        public Guna.UI2.WinForms.Guna2TextBox txtRole;
        public System.Windows.Forms.Label lbChangePassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        public Guna.UI2.WinForms.Guna2TextBox txtNewPassword;
        public Guna.UI2.WinForms.Guna2TextBox txtOldPassword;
        public Guna.UI2.WinForms.Guna2TextBox txtConfirmPassword;
        public Guna.UI2.WinForms.Guna2Panel panelChangePassword;
        public Guna.UI2.WinForms.Guna2HtmlLabel lbErrorMessage;
        public System.Windows.Forms.CheckBox checkBoxShowPassword;
    }
}

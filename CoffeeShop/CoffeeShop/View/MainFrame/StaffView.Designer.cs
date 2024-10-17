namespace CoffeeShop.View
{
    partial class StaffView
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabStaff = new System.Windows.Forms.TabControl();
			this.tabPageStaffList = new System.Windows.Forms.TabPage();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
			this.btnSearch = new Guna.UI2.WinForms.Guna2Button();
			this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
			this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
			this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
			this.dgvStaff = new System.Windows.Forms.DataGridView();
			this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDoB = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabPageStaffDetail = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnImport = new System.Windows.Forms.Button();
			this.btnClear = new Guna.UI2.WinForms.Guna2Button();
			this.dtpDob = new Guna.UI2.WinForms.Guna2DateTimePicker();
			this.btnSave = new Guna.UI2.WinForms.Guna2Button();
			this.cbRole = new Guna.UI2.WinForms.Guna2ComboBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnBack = new Guna.UI2.WinForms.Guna2Button();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.tabStaff.SuspendLayout();
			this.tabPageStaffList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).BeginInit();
			this.tabPageStaffDetail.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(233)))));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.pictureBox2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Margin = new System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(930, 50);
			this.panel1.TabIndex = 0;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = global::CoffeeShop.Properties.Resources.Staff;
			this.pictureBox2.Location = new System.Drawing.Point(15, 5);
			this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(32, 32);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 1;
			this.pictureBox2.TabStop = false;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(50, 10);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "Staff";
			// 
			// tabStaff
			// 
			this.tabStaff.Controls.Add(this.tabPageStaffList);
			this.tabStaff.Controls.Add(this.tabPageStaffDetail);
			this.tabStaff.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabStaff.Location = new System.Drawing.Point(0, 50);
			this.tabStaff.Margin = new System.Windows.Forms.Padding(2);
			this.tabStaff.Name = "tabStaff";
			this.tabStaff.SelectedIndex = 0;
			this.tabStaff.Size = new System.Drawing.Size(930, 592);
			this.tabStaff.TabIndex = 1;
			// 
			// tabPageStaffList
			// 
			this.tabPageStaffList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(250)))), ((int)(((byte)(246)))));
			this.tabPageStaffList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tabPageStaffList.Controls.Add(this.pictureBox3);
			this.tabPageStaffList.Controls.Add(this.txtSearch);
			this.tabPageStaffList.Controls.Add(this.btnSearch);
			this.tabPageStaffList.Controls.Add(this.btnAdd);
			this.tabPageStaffList.Controls.Add(this.btnEdit);
			this.tabPageStaffList.Controls.Add(this.btnDelete);
			this.tabPageStaffList.Controls.Add(this.dgvStaff);
			this.tabPageStaffList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tabPageStaffList.Location = new System.Drawing.Point(4, 22);
			this.tabPageStaffList.Margin = new System.Windows.Forms.Padding(2);
			this.tabPageStaffList.Name = "tabPageStaffList";
			this.tabPageStaffList.Padding = new System.Windows.Forms.Padding(2);
			this.tabPageStaffList.Size = new System.Drawing.Size(922, 566);
			this.tabPageStaffList.TabIndex = 0;
			this.tabPageStaffList.Text = "Staff List";
			// 
			// pictureBox3
			// 
			this.pictureBox3.Image = global::CoffeeShop.Properties.Resources.Search;
			this.pictureBox3.Location = new System.Drawing.Point(20, 37);
			this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(32, 23);
			this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox3.TabIndex = 11;
			this.pictureBox3.TabStop = false;
			// 
			// txtSearch
			// 
			this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearch.BorderColor = System.Drawing.Color.Black;
			this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtSearch.DefaultText = "";
			this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtSearch.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtSearch.Location = new System.Drawing.Point(70, 37);
			this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.PasswordChar = '\0';
			this.txtSearch.PlaceholderText = "Search Staff";
			this.txtSearch.SelectedText = "";
			this.txtSearch.Size = new System.Drawing.Size(609, 24);
			this.txtSearch.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
			this.txtSearch.TabIndex = 10;
			// 
			// btnSearch
			// 
			this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSearch.BorderRadius = 10;
			this.btnSearch.BorderThickness = 1;
			this.btnSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.btnSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.btnSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.btnSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.btnSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(167)))), ((int)(((byte)(38)))));
			this.btnSearch.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSearch.ForeColor = System.Drawing.Color.Black;
			this.btnSearch.Location = new System.Drawing.Point(742, 32);
			this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(86, 29);
			this.btnSearch.TabIndex = 9;
			this.btnSearch.Text = "Search";
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAdd.BorderRadius = 10;
			this.btnAdd.BorderThickness = 1;
			this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(230)))), ((int)(((byte)(118)))));
			this.btnAdd.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnAdd.ForeColor = System.Drawing.Color.Black;
			this.btnAdd.Location = new System.Drawing.Point(440, 515);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(86, 29);
			this.btnAdd.TabIndex = 8;
			this.btnAdd.Text = "Add";
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnEdit.BorderRadius = 10;
			this.btnEdit.BorderThickness = 1;
			this.btnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.btnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.btnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.btnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.btnEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(125)))), ((int)(((byte)(232)))));
			this.btnEdit.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEdit.ForeColor = System.Drawing.Color.Black;
			this.btnEdit.Location = new System.Drawing.Point(620, 515);
			this.btnEdit.Margin = new System.Windows.Forms.Padding(2);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(86, 29);
			this.btnEdit.TabIndex = 7;
			this.btnEdit.Text = "Edit";
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.BorderRadius = 10;
			this.btnDelete.BorderThickness = 1;
			this.btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.btnDelete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(51)))), ((int)(((byte)(25)))));
			this.btnDelete.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnDelete.ForeColor = System.Drawing.Color.Black;
			this.btnDelete.Location = new System.Drawing.Point(800, 515);
			this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(86, 29);
			this.btnDelete.TabIndex = 6;
			this.btnDelete.Text = "Delete";
			// 
			// dgvStaff
			// 
			this.dgvStaff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvStaff.BackgroundColor = System.Drawing.SystemColors.ControlLight;
			this.dgvStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvStaff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colName,
            this.colDoB,
            this.colPhone,
            this.colGender,
            this.colAddress,
            this.colRole});
			this.dgvStaff.Location = new System.Drawing.Point(10, 84);
			this.dgvStaff.Margin = new System.Windows.Forms.Padding(2);
			this.dgvStaff.Name = "dgvStaff";
			this.dgvStaff.ReadOnly = true;
			this.dgvStaff.RowHeadersWidth = 62;
			this.dgvStaff.RowTemplate.Height = 28;
			this.dgvStaff.Size = new System.Drawing.Size(908, 410);
			this.dgvStaff.TabIndex = 3;
			// 
			// colID
			// 
			this.colID.HeaderText = "Staff ID";
			this.colID.MinimumWidth = 8;
			this.colID.Name = "colID";
			this.colID.ReadOnly = true;
			this.colID.Width = 70;
			// 
			// colName
			// 
			this.colName.HeaderText = "Staff Name";
			this.colName.MinimumWidth = 8;
			this.colName.Name = "colName";
			this.colName.ReadOnly = true;
			this.colName.Width = 200;
			// 
			// colDoB
			// 
			this.colDoB.HeaderText = "Date of Birth";
			this.colDoB.MinimumWidth = 8;
			this.colDoB.Name = "colDoB";
			this.colDoB.ReadOnly = true;
			this.colDoB.Width = 150;
			// 
			// colPhone
			// 
			this.colPhone.HeaderText = "Phone";
			this.colPhone.MinimumWidth = 8;
			this.colPhone.Name = "colPhone";
			this.colPhone.ReadOnly = true;
			this.colPhone.Width = 170;
			// 
			// colGender
			// 
			this.colGender.HeaderText = "Gender";
			this.colGender.MinimumWidth = 8;
			this.colGender.Name = "colGender";
			this.colGender.ReadOnly = true;
			this.colGender.Width = 90;
			// 
			// colAddress
			// 
			this.colAddress.HeaderText = "Address";
			this.colAddress.MinimumWidth = 8;
			this.colAddress.Name = "colAddress";
			this.colAddress.ReadOnly = true;
			this.colAddress.Width = 220;
			// 
			// colRole
			// 
			this.colRole.HeaderText = "Role";
			this.colRole.MinimumWidth = 8;
			this.colRole.Name = "colRole";
			this.colRole.ReadOnly = true;
			this.colRole.Width = 200;
			// 
			// tabPageStaffDetail
			// 
			this.tabPageStaffDetail.BackColor = System.Drawing.Color.White;
			this.tabPageStaffDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tabPageStaffDetail.Controls.Add(this.panel2);
			this.tabPageStaffDetail.Controls.Add(this.groupBox1);
			this.tabPageStaffDetail.Location = new System.Drawing.Point(4, 22);
			this.tabPageStaffDetail.Margin = new System.Windows.Forms.Padding(2);
			this.tabPageStaffDetail.Name = "tabPageStaffDetail";
			this.tabPageStaffDetail.Padding = new System.Windows.Forms.Padding(2);
			this.tabPageStaffDetail.Size = new System.Drawing.Size(922, 566);
			this.tabPageStaffDetail.TabIndex = 1;
			this.tabPageStaffDetail.Text = "Staff Detail";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.btnImport);
			this.groupBox1.Controls.Add(this.btnClear);
			this.groupBox1.Controls.Add(this.dtpDob);
			this.groupBox1.Controls.Add(this.btnSave);
			this.groupBox1.Controls.Add(this.cbRole);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.txtAddress);
			this.groupBox1.Controls.Add(this.txtPhone);
			this.groupBox1.Controls.Add(this.picAvatar);
			this.groupBox1.Controls.Add(this.txtStaffName);
			this.groupBox1.Controls.Add(this.rdoOther);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.rdoFemale);
			this.groupBox1.Controls.Add(this.rdoMale);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(4, 3);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox1.Size = new System.Drawing.Size(906, 555);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			// 
			// btnImport
			// 
			this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(117)))), ((int)(((byte)(125)))), ((int)(((byte)(232)))));
			this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnImport.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnImport.Location = new System.Drawing.Point(46, 305);
			this.btnImport.Margin = new System.Windows.Forms.Padding(2);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(139, 28);
			this.btnImport.TabIndex = 23;
			this.btnImport.Text = "Import";
			this.btnImport.UseVisualStyleBackColor = false;
			// 
			// btnClear
			// 
			this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnClear.BorderRadius = 10;
			this.btnClear.BorderThickness = 1;
			this.btnClear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.btnClear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.btnClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.btnClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.btnClear.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(51)))), ((int)(((byte)(25)))));
			this.btnClear.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClear.ForeColor = System.Drawing.Color.Black;
			this.btnClear.Location = new System.Drawing.Point(142, 504);
			this.btnClear.Margin = new System.Windows.Forms.Padding(2);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(86, 29);
			this.btnClear.TabIndex = 10;
			this.btnClear.Text = "Clear";
			// 
			// dtpDob
			// 
			this.dtpDob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.dtpDob.Checked = true;
			this.dtpDob.FillColor = System.Drawing.Color.White;
			this.dtpDob.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Long;
			this.dtpDob.Location = new System.Drawing.Point(255, 496);
			this.dtpDob.Margin = new System.Windows.Forms.Padding(2);
			this.dtpDob.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.dtpDob.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.dtpDob.Name = "dtpDob";
			this.dtpDob.Size = new System.Drawing.Size(284, 37);
			this.dtpDob.TabIndex = 22;
			this.dtpDob.Value = new System.DateTime(2024, 10, 7, 11, 4, 24, 43);
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
			this.btnSave.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.ForeColor = System.Drawing.Color.Black;
			this.btnSave.Location = new System.Drawing.Point(19, 504);
			this.btnSave.Margin = new System.Windows.Forms.Padding(2);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(86, 29);
			this.btnSave.TabIndex = 9;
			this.btnSave.Text = "Save";
			// 
			// cbRole
			// 
			this.cbRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbRole.BackColor = System.Drawing.Color.Transparent;
			this.cbRole.BorderColor = System.Drawing.Color.Black;
			this.cbRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRole.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.cbRole.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.cbRole.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
			this.cbRole.ItemHeight = 30;
			this.cbRole.Location = new System.Drawing.Point(255, 393);
			this.cbRole.Margin = new System.Windows.Forms.Padding(2);
			this.cbRole.Name = "cbRole";
			this.cbRole.Size = new System.Drawing.Size(100, 36);
			this.cbRole.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
			this.cbRole.TabIndex = 10;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(42, 54);
			this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(163, 22);
			this.label9.TabIndex = 7;
			this.label9.Text = "Staff Information";
			// 
			// txtAddress
			// 
			this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAddress.BorderColor = System.Drawing.Color.Black;
			this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtAddress.DefaultText = "";
			this.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.txtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txtAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtAddress.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtAddress.Location = new System.Drawing.Point(255, 293);
			this.txtAddress.Margin = new System.Windows.Forms.Padding(2);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.PasswordChar = '\0';
			this.txtAddress.PlaceholderText = "Enter Address";
			this.txtAddress.SelectedText = "";
			this.txtAddress.Size = new System.Drawing.Size(600, 37);
			this.txtAddress.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
			this.txtAddress.TabIndex = 21;
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
			this.txtPhone.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtPhone.Location = new System.Drawing.Point(255, 191);
			this.txtPhone.Margin = new System.Windows.Forms.Padding(2);
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.PasswordChar = '\0';
			this.txtPhone.PlaceholderText = "Enter Phone No";
			this.txtPhone.SelectedText = "";
			this.txtPhone.Size = new System.Drawing.Size(600, 37);
			this.txtPhone.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
			this.txtPhone.TabIndex = 20;
			// 
			// picAvatar
			// 
			this.picAvatar.BackColor = System.Drawing.Color.LightGray;
			this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.picAvatar.ErrorImage = null;
			this.picAvatar.Location = new System.Drawing.Point(46, 115);
			this.picAvatar.Margin = new System.Windows.Forms.Padding(2);
			this.picAvatar.Name = "picAvatar";
			this.picAvatar.Size = new System.Drawing.Size(139, 191);
			this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picAvatar.TabIndex = 18;
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
			this.txtStaffName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtStaffName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txtStaffName.Location = new System.Drawing.Point(255, 101);
			this.txtStaffName.Margin = new System.Windows.Forms.Padding(2);
			this.txtStaffName.Name = "txtStaffName";
			this.txtStaffName.PasswordChar = '\0';
			this.txtStaffName.PlaceholderText = "Enter Name\r\n";
			this.txtStaffName.SelectedText = "";
			this.txtStaffName.Size = new System.Drawing.Size(600, 37);
			this.txtStaffName.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
			this.txtStaffName.TabIndex = 19;
			// 
			// rdoOther
			// 
			this.rdoOther.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.rdoOther.AutoSize = true;
			this.rdoOther.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdoOther.Location = new System.Drawing.Point(797, 401);
			this.rdoOther.Margin = new System.Windows.Forms.Padding(2);
			this.rdoOther.Name = "rdoOther";
			this.rdoOther.Size = new System.Drawing.Size(57, 20);
			this.rdoOther.TabIndex = 12;
			this.rdoOther.TabStop = true;
			this.rdoOther.Text = "Other";
			this.rdoOther.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(252, 70);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 18);
			this.label3.TabIndex = 0;
			this.label3.Text = "Name";
			// 
			// rdoFemale
			// 
			this.rdoFemale.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.rdoFemale.AutoSize = true;
			this.rdoFemale.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdoFemale.Location = new System.Drawing.Point(595, 401);
			this.rdoFemale.Margin = new System.Windows.Forms.Padding(2);
			this.rdoFemale.Name = "rdoFemale";
			this.rdoFemale.Size = new System.Drawing.Size(68, 20);
			this.rdoFemale.TabIndex = 11;
			this.rdoFemale.TabStop = true;
			this.rdoFemale.Text = "Female";
			this.rdoFemale.UseVisualStyleBackColor = true;
			// 
			// rdoMale
			// 
			this.rdoMale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.rdoMale.AutoSize = true;
			this.rdoMale.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rdoMale.Location = new System.Drawing.Point(400, 401);
			this.rdoMale.Margin = new System.Windows.Forms.Padding(2);
			this.rdoMale.Name = "rdoMale";
			this.rdoMale.Size = new System.Drawing.Size(53, 20);
			this.rdoMale.TabIndex = 10;
			this.rdoMale.TabStop = true;
			this.rdoMale.Text = "Male";
			this.rdoMale.UseVisualStyleBackColor = true;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(398, 364);
			this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(60, 18);
			this.label8.TabIndex = 9;
			this.label8.Text = "Gender";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(252, 364);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 18);
			this.label7.TabIndex = 8;
			this.label7.Text = "Role";
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(252, 459);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(95, 18);
			this.label6.TabIndex = 6;
			this.label6.Text = "Date of Birth";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(252, 162);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 18);
			this.label5.TabIndex = 4;
			this.label5.Text = "Phone";
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(252, 256);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(67, 18);
			this.label4.TabIndex = 2;
			this.label4.Text = "Address";
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(171)))), ((int)(((byte)(147)))));
			this.panel2.Controls.Add(this.btnBack);
			this.panel2.Location = new System.Drawing.Point(-1, -1);
			this.panel2.Margin = new System.Windows.Forms.Padding(2);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(920, 44);
			this.panel2.TabIndex = 24;
			// 
			// btnBack
			// 
			this.btnBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.btnBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.btnBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.btnBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.btnBack.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(171)))), ((int)(((byte)(147)))));
			this.btnBack.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnBack.ForeColor = System.Drawing.Color.Black;
			this.btnBack.Image = global::CoffeeShop.Properties.Resources.back;
			this.btnBack.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.btnBack.ImageSize = new System.Drawing.Size(25, 25);
			this.btnBack.Location = new System.Drawing.Point(28, 0);
			this.btnBack.Name = "btnBack";
			this.btnBack.PressedColor = System.Drawing.Color.Transparent;
			this.btnBack.Size = new System.Drawing.Size(89, 44);
			this.btnBack.TabIndex = 0;
			this.btnBack.Text = "Back";
			this.btnBack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// StaffView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(251)))), ((int)(((byte)(233)))));
			this.ClientSize = new System.Drawing.Size(930, 642);
			this.Controls.Add(this.tabStaff);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.Name = "StaffView";
			this.Text = "Staff";
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.tabStaff.ResumeLayout(false);
			this.tabPageStaffList.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvStaff)).EndInit();
			this.tabPageStaffDetail.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabStaff;
        private System.Windows.Forms.TabPage tabPageStaffList;
        private System.Windows.Forms.TabPage tabPageStaffDetail;
        private System.Windows.Forms.DataGridView dgvStaff;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoOther;
        private System.Windows.Forms.RadioButton rdoFemale;
        private System.Windows.Forms.RadioButton rdoMale;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDoB;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRole;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnDelete;
        private Guna.UI2.WinForms.Guna2Button btnSearch;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private Guna.UI2.WinForms.Guna2TextBox txtStaffName;
        private Guna.UI2.WinForms.Guna2ComboBox cbRole;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDob;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.Button btnImport;
		private System.Windows.Forms.Panel panel2;
		private Guna.UI2.WinForms.Guna2Button btnBack;
	}
}
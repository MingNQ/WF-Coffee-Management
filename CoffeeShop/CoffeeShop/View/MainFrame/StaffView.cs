using CoffeeShop.Model;
using CoffeeShop.Model.Common;
using CoffeeShop.Utilities;
using CoffeeShop.View.DialogForm;
using CoffeeShop.View.MainFrame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View
{
	public partial class StaffView : Form, IStaffView
    {
		#region Fields
		/// <summary>
		/// Instance for Staff
		/// </summary>
		private static StaffView instance;

        /// <summary>
        /// Check if edit
        /// </summary>
        private bool isEdit;

        /// <summary>
        /// Check if successful
        /// </summary>
        private bool isSuccessful;

        /// <summary>
        /// 
        /// </summary>
        private string staffID;

        /// <summary>
        /// 
        /// </summary>
        private Avatar avatar = new Avatar();

		#endregion

		#region Properties

		/// <summary>
		/// Check if edit
		/// </summary>
		public bool IsEdit
        {
            get => isEdit;
            set => isEdit = value;
        }

        /// <summary>
        /// Check if successful
        /// </summary>
        public bool IsSuccessful
		{
            get => isSuccessful; 
            set => isSuccessful = value; 
        }

        public string StaffID
        {
            get => staffID; 
            set => staffID = value; 
        }

        /// <summary>
        /// 
        /// </summary>
        public string StaffName 
        { 
            get => txtStaffName.Text; 
            set => txtStaffName.Text = value; 
        }

        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber 
        { 
            get => txtPhone.Text; 
            set => txtPhone.Text = value; 
        }

        /// <summary>
        /// 
        /// </summary>
        public string DateOfBirth 
        { 
            get => dtpDob.Text; 
            set => dtpDob.Text = value; 
        }

        /// <summary>
        /// 
        /// </summary>
        public string Email 
        { 
            get => txtEmail.Text; 
            set => txtEmail.Text = value; 
        }

        /// <summary>
        /// 
        /// </summary>
        public string StaffRole 
        { 
            get => cbRole.Text;
            set
            {
                if (value == "")
                {
                    cbRole.SelectedItem = null;
                }
                cbRole.Text = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Male 
        {
            get => rdoMale.Checked; 
            set => rdoMale.Checked = value; 
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Female 
        { 
            get => rdoFemale.Checked; 
            set => rdoFemale.Checked = value; 
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Other 
        { 
            get => rdoOther.Checked; 
            set => rdoOther.Checked = value; 
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsOpen 
        { 
            get => Application.OpenForms.OfType<StaffView>().Any(); 
        }
        
        /// <summary>
        /// Search value
        /// </summary>
        public string SearchValue 
        { 
            get => txtSearch.Text; 
        }

        /// <summary>
        /// 
        /// </summary>
        public Avatar Avatar 
        { 
            get => avatar;
            set 
            {
                avatar = value;

                if (avatar.ImageUrl != null)
                    picAvatar.ImageLocation = Path.Combine(Application.StartupPath, AppConst.IMAGE_SOURE_PATH, avatar.ImageUrl);
            }
        }

        #endregion

        #region Events

        public event EventHandler SearchEvent;
		public event EventHandler AddNewEvent;
		public event EventHandler EditEvent;
		public event EventHandler DeleteEvent;
		public event EventHandler SaveEvent;
		public event EventHandler ClearEvent;
		public event EventHandler BackToListEvent;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public StaffView()
        {
            InitializeComponent();
            InitializeDataGridView();
            InitializeComboBoxRole();
            AssociateAndRaiseEvents();
            tabStaff.TabPages.Remove(tabPageStaffDetail);
        }

        #region private fields

        /// <summary>
        /// Initialize data grid view
        /// </summary>
        private void InitializeDataGridView()
        {
            dgvStaff.AllowUserToAddRows = false;
            dgvStaff.AllowUserToResizeRows = false;
            dgvStaff.RowHeadersVisible = false;
            dgvStaff.AutoGenerateColumns = false;
            dgvStaff.MultiSelect = false;
            dgvStaff.ReadOnly = true;

            // Change color for header row
            dgvStaff.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 251, 233);
            dgvStaff.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold); // Kiểu chữ

            // ID
            DataGridViewTextBoxColumn colStaffId = new DataGridViewTextBoxColumn();
            colStaffId.HeaderText = "Staff ID";
            colStaffId.Width = 100;
            colStaffId.DataPropertyName = "StaffID";
            dgvStaff.Columns.Add(colStaffId);

            // Name
            DataGridViewTextBoxColumn colStaffName = new DataGridViewTextBoxColumn();
            colStaffName.HeaderText = "Staff Name";
            colStaffName.Width = 225;
            colStaffName.DataPropertyName = "StaffName";
            dgvStaff.Columns.Add(colStaffName);

            // Phone
            DataGridViewTextBoxColumn colPhone = new DataGridViewTextBoxColumn();
            colPhone.HeaderText = "Staff Phone";    
            colPhone.Width = 125;
            colPhone.DataPropertyName = "PhoneNumber";
            dgvStaff.Columns.Add(colPhone);

            // Date
            DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();
            colDate.HeaderText = "Date of Birth";
            colDate.Width = 140;
            colDate.DataPropertyName = "DateOfBirth";
            dgvStaff.Columns.Add(colDate);

            // Email
            DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
            colEmail.HeaderText = "Email";
            colEmail.Width = 270;
            colEmail.DataPropertyName = "Email";
            dgvStaff.Columns.Add(colEmail);

            // Role
            DataGridViewTextBoxColumn colRole = new DataGridViewTextBoxColumn();
            colRole.HeaderText = "Role";
            colRole.Width = 100;
            colRole.DataPropertyName = "Role";
            dgvStaff.Columns.Add(colRole);

            // Gender
            DataGridViewTextBoxColumn colGender = new DataGridViewTextBoxColumn();
            colGender.HeaderText = "Gender";
            colGender.Width = 80;
            colGender.DataPropertyName = "Gender";
            dgvStaff.Columns.Add(colGender);

            dgvStaff.CellFormatting += dgvStaff_CellFormatting;
        }

        /// <summary>
        /// Event change looks of data grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvStaff_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                if (e.RowIndex % 2 == 0) 
                {
                    dgvStaff.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                }
                else 
                {
                    dgvStaff.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        /// <summary>
        /// Associate And Raise Events
        /// </summary>
        private void AssociateAndRaiseEvents()
        {
            // Disable Button
            btnSave.Enabled = false;

            // Search
            btnSearch.Click += delegate 
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                SearchEvent?.Invoke(this, EventArgs.Empty); 
            };
            txtSearch.KeyDown += (s, e) =>
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                if (e.KeyCode == Keys.Enter)
                {
                    SearchEvent?.Invoke(this, EventArgs.Empty);
                }
            };           

            // Add
            btnAdd.Click += delegate
            {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabStaff.TabPages.Remove(tabPageStaffList);
                tabStaff.TabPages.Add(tabPageStaffDetail);
                tabPageStaffDetail.Text = "Add New Staff";
            };

            // Edit
            btnEdit.Enabled = false;
            btnEdit.Click += delegate
			{
                EditEvent?.Invoke(this, EventArgs.Empty);
				tabStaff.TabPages.Remove(tabPageStaffList);
				tabStaff.TabPages.Add(tabPageStaffDetail);
				tabPageStaffDetail.Text = "Edit Staff";
            };

            // Delete
            btnDelete.Enabled = false;
            btnDelete.Click += delegate
            {
                if (DialogMessageView.ShowMessage("warning", "Are you sure to delte the selected staff?") == DialogResult.OK)
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
            };

            // Save
            btnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);

                if (isSuccessful)
				{
					tabStaff.TabPages.Remove(tabPageStaffDetail);
					tabStaff.TabPages.Add(tabPageStaffList);
                    DialogMessageView.ShowMessage("success", IsEdit ? $"Successful Edit Staff: {StaffName}" : $"Successful Add New Staff: {StaffName}");
                }

                // Clear Field In Mode Edit/Add
                BackToListEvent?.Invoke(this, EventArgs.Empty);
                picAvatar.Image = null;
            };

            // Clear
            btnClear.Click += delegate
            {
                ClearEvent?.Invoke(this, EventArgs.Empty);
                picAvatar.Image = null;
            };

            // Back
            btnBack.Click += delegate
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;

                BackToListEvent?.Invoke(this, EventArgs.Empty);
				tabStaff.TabPages.Remove(tabPageStaffDetail);
				tabStaff.TabPages.Add(tabPageStaffList);
                picAvatar.Image = null;
			};

            // Data View
            dgvStaff.CellClick += delegate
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
            };

            dgvStaff.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    EditEvent?.Invoke(this, EventArgs.Empty);
                    tabStaff.TabPages.Remove(tabPageStaffList);
                    tabStaff.TabPages.Add(tabPageStaffDetail);
                    tabPageStaffDetail.Text = "Edit Staff";
                }
            };

            // Import Image
            btnImport.Click += LoadImage;
            picAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
		}

        /// <summary>
        /// Initialize ComboBox
        /// </summary>
        private void InitializeComboBoxRole()
        {
            cbRole.Items.Add("Quản lý");
            cbRole.Items.Add("Pha chế");
            cbRole.Items.Add("Phục vụ");
        }

        /// <summary>
        /// Import Image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadImage(object sender, EventArgs e)
        {
            // Open File Dialog
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Application.StartupPath;
                openFileDialog.Filter = "PNG File (*.png)|*.png|JPEG File (*.jpeg)|*.jpeg|JPG File(*.jpg)|*.jpg|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Combine Path to Save File
                    string sourceFilePath = openFileDialog.FileName;
                    string fileName = Path.GetFileName(sourceFilePath);
                    string destinationPath = Path.Combine(Application.StartupPath, AppConst.IMAGE_SOURE_PATH, fileName);
                    
                    if (Path.GetFullPath(sourceFilePath) != Path.GetFullPath(destinationPath))
                    {
                        File.Copy(sourceFilePath, destinationPath, true);
                    }

                    avatar.ImageUrl = Path.GetFileName(destinationPath);
                    picAvatar.ImageLocation = destinationPath;
                }
            }
        }

        /// <summary>
        /// Active Save Action
        /// </summary>
        private void ActiveActionSave(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

		#endregion

		#region public fields
		/// <summary>
		/// Get Instance for Staff
		/// </summary>
		/// <param name="parentContainer">Parent Container</param>
		/// <returns>Instance</returns>
		public static StaffView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new StaffView();
                instance.MdiParent = parentContainer;
                instance.Dock = DockStyle.Fill;
            } 
            else
            {
                if (instance.WindowState == FormWindowState.Minimized) 
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }

            return instance;
        }

        /// <summary>
        /// Get Data
        /// </summary>
        /// <param name="staffList"></param>
        public void SetLStaffListBindingSource(BindingSource staffList)
        {
            this.dgvStaff.DataSource = staffList;
        }
        #endregion       
    }
}

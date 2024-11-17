using CoffeeShop.Model.Common;
using CoffeeShop.Utilities;
using CoffeeShop.View.MainFrame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View
{
    public partial class CustomerView : Form, ICustomerView
    {
		#region Fields
		/// <summary>
		/// Instance for Customer
		/// </summary>
		private static CustomerView instance;

		/// <summary>
		/// Check if edit
		/// </summary>
		private bool isEdit;
		
		/// <summary>
		/// Check if successful
		/// </summary>
		private bool isSuccessful;

		private string customerID;
		#endregion

		#region Properties

		/// <summary>
		/// Check if edit
		/// </summary>
		public bool IsEdit { get => isEdit; set => isEdit = value; }

		/// <summary>
		/// Check if successful
		/// </summary>
		public bool IsSuccessful { get => isSuccessful; set => isSuccessful = value; }

        public string CustomerID 
        {
            get => customerID;
            set => customerID = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public string CustomerName
        {
            get => txtCustomerName.Text;
            set => txtCustomerName.Text = value;
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
        public string Email
        {
            get => txtEmail.Text;
            set => txtEmail.Text = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal Coupon
        {
            get => decimal.TryParse(cbCoupon.Text, out var result) ? result : 0;
            set => cbCoupon.Text = value.ToString();           
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Male
        {
            get => rbMale.Checked;
            set => rbMale.Checked = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Female
        {
            get => rbFemale.Checked;
            set => rbFemale.Checked = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Other
        {
            get => rbOther.Checked;
            set => rbOther.Checked = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsOpen
        {
            get => Application.OpenForms.OfType<CustomerView>().Any();
        }

        /// <summary>
        /// Search value
        /// </summary>
        public string SearchValue
        {
            get => txtSearch.Text;
        }
        #endregion

        #region Events
        public event EventHandler AddNewEvent;
		public event EventHandler EditEvent;
		public event EventHandler SearchEvent;
		public event EventHandler DeleteEvent;
		public event EventHandler SaveEvent;
		public event EventHandler ClearEvent;
		public event EventHandler BackToListEvent;
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public CustomerView()
        {
            InitializeComponent();
            InitializeDataGridView();
            InitializeComboBoxCoupon();
            AssociateAndRaiseViewEvents();
            tabCustomer.TabPages.Remove(tabPageCustomerDetail);
        }

        #region private fields

        /// <summary>
        /// Initialize data grid view
        /// </summary>
        private void InitializeDataGridView()
        {
            dgvCustomer.AllowUserToAddRows = false;
            dgvCustomer.AllowUserToResizeRows = false;
            dgvCustomer.RowHeadersVisible = false;
            dgvCustomer.AutoGenerateColumns = false;
            dgvCustomer.MultiSelect = false;
            dgvCustomer.ReadOnly = true;
            //dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Change color for header row
            dgvCustomer.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 251, 233);
            dgvCustomer.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold); // Kiểu chữ

            // ID
            DataGridViewTextBoxColumn colCustomerId = new DataGridViewTextBoxColumn();
            colCustomerId.HeaderText = "Customer ID";
            colCustomerId.Width = 150;
            colCustomerId.DataPropertyName = "CustomerID";
            dgvCustomer.Columns.Add(colCustomerId);

            // Name
            DataGridViewTextBoxColumn colCustomerName = new DataGridViewTextBoxColumn();
            colCustomerName.HeaderText = "Customer Name";
            colCustomerName.Width = 225;
            colCustomerName.DataPropertyName = "CustomerName";
            dgvCustomer.Columns.Add(colCustomerName);

            // Phone
            DataGridViewTextBoxColumn colPhone = new DataGridViewTextBoxColumn();
            colPhone.HeaderText = "Customer Phone";
            colPhone.Width = 175;
            colPhone.DataPropertyName = "CustomerPhone";
            dgvCustomer.Columns.Add(colPhone);

            // Email
            DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
            colEmail.HeaderText = "Email";
            colEmail.Width = 280;
            colEmail.DataPropertyName = "CustomerEmail";
            dgvCustomer.Columns.Add(colEmail);

            // Coupon
            DataGridViewTextBoxColumn colCoupon = new DataGridViewTextBoxColumn();
            colCoupon.HeaderText = "Coupon(%)";
            colCoupon.Width = 125;
            colCoupon.DataPropertyName = "Coupon";
            dgvCustomer.Columns.Add(colCoupon);

            // Gender
            DataGridViewTextBoxColumn colGender = new DataGridViewTextBoxColumn();
            colGender.HeaderText = "Gender";
            colGender.Width = 100;
            colGender.DataPropertyName = "Gender";
            dgvCustomer.Columns.Add(colGender);

            dgvCustomer.CellFormatting += dgvCustomer_CellFormatting;
        }

        /// <summary>
        /// Event change looks of data grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCustomer_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.RowIndex % 2 == 0)
                {
                    dgvCustomer.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                }
                else
                {
                    dgvCustomer.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        /// <summary>
        /// Asssociate And Raise Event
        /// </summary>
        private void AssociateAndRaiseViewEvents()
		{
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
                    e.SuppressKeyPress = true;
                }                                  
            };

            // Add
            btnAdd.Click += delegate
            {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabCustomer.TabPages.Remove(tabPageCustomerList);
                tabCustomer.TabPages.Add(tabPageCustomerDetail);
                tabPageCustomerDetail.Text = "Add New Customer";
            };

            // Edit
            btnEdit.Enabled = false;
            btnEdit.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabCustomer.TabPages.Remove(tabPageCustomerList);
                tabCustomer.TabPages.Add(tabPageCustomerDetail);
                tabPageCustomerDetail.Text = "Edit Customer";
            };

            // Delete
            btnDelete.Enabled = false;
            btnDelete.Click += delegate
            {
                if (MessageBox.Show("Are you sure to delete the selected customer?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
            };

            // Save
            btnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);

                if (isSuccessful)
                {
                    tabCustomer.TabPages.Remove(tabPageCustomerDetail);
                    tabCustomer.TabPages.Add(tabPageCustomerList);
                }
            };

            // Clear
            btnClear.Click += delegate
            {
                ClearEvent?.Invoke(this, EventArgs.Empty);
            };

            // Back
            btnBack.Click += delegate
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;

                BackToListEvent?.Invoke(this, EventArgs.Empty);
                tabCustomer.TabPages.Remove(tabPageCustomerDetail);
                tabCustomer.TabPages.Add(tabPageCustomerList);
            };

            // Data View
            dgvCustomer.CellClick += delegate
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
            };

            dgvCustomer.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0 && Generate.StaffRole == AppConst.ADMIN_ROLE)
                {
                    EditEvent?.Invoke(this, EventArgs.Empty);
                    tabCustomer.TabPages.Remove(tabPageCustomerList);
                    tabCustomer.TabPages.Add(tabPageCustomerDetail);
                    tabPageCustomerDetail.Text = "Edit Customer";
                }
            };

        }

        /// <summary>
        /// Initialize ComboBox
        /// </summary>
        private void InitializeComboBoxCoupon()
        {
            cbCoupon.Items.Add("10");
            cbCoupon.Items.Add("20");
            cbCoupon.Items.Add("30");
            cbCoupon.Items.Add("40");
            cbCoupon.Items.Add("50");           
        }

        /// <summary>
        /// Reset 
        /// </summary>
        private void ResetControls()
        {
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        /// <summary>
        /// Role Access
        /// </summary>
        private void RoleAccess()
        {
            if (Generate.StaffRole != AppConst.ADMIN_ROLE)
            {
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }
            else
            {
                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnDelete.Visible = true;
            }
        }

        #endregion

        #region public fields
        /// <summary>
        /// Get Instance for Customer
        /// </summary>
        /// <param name="parentContainer">Parent Container</param>
        /// <returns>Instance</returns>
        public static CustomerView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            { 
                instance = new CustomerView();
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
        /// <param name="customerList"></param>
        public void SetCustomerListBindingSource(BindingSource customerList)
        {
            this.dgvCustomer.DataSource = customerList;
        }

        /// <summary>
        /// Show Form
        /// </summary>
        public void ShowPage()
        {
            if (!tabCustomer.TabPages.Contains(tabPageCustomerList))
            {
                tabCustomer.TabPages.Clear();
                tabCustomer.TabPages.Add(tabPageCustomerList);
                BackToListEvent?.Invoke(this, EventArgs.Empty);
                ResetControls();
            }

            // Check Role
            RoleAccess();

            // Show
            this.Show();
        }
        #endregion
    }
}
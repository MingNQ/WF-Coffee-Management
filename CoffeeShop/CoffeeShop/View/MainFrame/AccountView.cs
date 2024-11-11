using CoffeeShop.View.MainFrame.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View.MainFrame
{
    public partial class AccountView : Form, IAccountView
    {
        #region Fields
        /// <summary>
        /// 
        /// </summary>
        private static AccountView instance;

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public bool IsOpen { get => Application.OpenForms.OfType<AccountView>().Any(); }

        /// <summary>
        /// 
        /// </summary>
        public string SearchValue { get => txtSearch.Text; set => txtSearch.Text = value; }

        #endregion

        #region Events
        public event EventHandler SearchEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler ActiveEvent;
        public event EventHandler DisableEvent;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public AccountView()
        {
            InitializeComponent();
            InitializeDataGridAccountList();
            AssociateAndRaiseNewEvents();

            // Disable Delete 
            btnDelete.Enabled = false;
        }

        #region private fields

        /// <summary>
        /// Initialize Data Grid Account
        /// </summary>
        private void InitializeDataGridAccountList()
        {
            dgvAccountList.AllowUserToResizeRows = false;
            dgvAccountList.RowHeadersVisible = false;
            dgvAccountList.AutoGenerateColumns = false;
            dgvAccountList.MultiSelect = false;
            dgvAccountList.ReadOnly = true;
            dgvAccountList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvAccountList.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 251, 233);
            dgvAccountList.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Header Font
            dgvAccountList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Center
            dgvAccountList.RowsDefaultCellStyle.Font = new Font("Arial", 11, FontStyle.Regular); // Row Font

            // ID
            DataGridViewTextBoxColumn colAccountID = new DataGridViewTextBoxColumn();
            colAccountID.HeaderText = "Account ID";
            colAccountID.FillWeight = 25;
            colAccountID.DataPropertyName = "AccountID";
            colAccountID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAccountList.Columns.Add(colAccountID);

            // Staff Name
            DataGridViewTextBoxColumn colStaffName = new DataGridViewTextBoxColumn();
            colStaffName.HeaderText = "Staff Name";
            colStaffName.FillWeight = 50;
            colStaffName.DataPropertyName = "StaffName";
            dgvAccountList.Columns.Add(colStaffName);

            // Username
            DataGridViewTextBoxColumn colUserName = new DataGridViewTextBoxColumn();
            colUserName.HeaderText = "User Name";
            colUserName.FillWeight = 50;
            colUserName.DataPropertyName = "UserName";
            dgvAccountList.Columns.Add(colUserName);

            // Active
            DataGridViewCheckBoxColumn chkActive = new DataGridViewCheckBoxColumn();
            chkActive.HeaderText = "Active";
            chkActive.FillWeight = 50;
            chkActive.DataPropertyName = "Active";
            chkActive.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvAccountList.Columns.Add(chkActive);

            dgvAccountList.CellFormatting += CellFormat;

            // Event
            dgvAccountList.CellClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                    btnDelete.Enabled = true;
            };
        }

        /// <summary>
        /// Format Row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellFormat(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvAccountList.Rows[e.RowIndex].DefaultCellStyle.BackColor = e.RowIndex % 2 == 0 ? Color.LightGray : Color.White;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void AssociateAndRaiseNewEvents()
        {
            // Search
            btnSearch.Click += delegate 
            { 
                btnDelete.Enabled = false;
                SearchEvent?.Invoke(this, EventArgs.Empty); 
            };
            txtSearch.KeyDown += (s, e) =>
            {
                btnDelete.Enabled = false;
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };

            // Active
            btnActive.Click += delegate { ActiveEvent?.Invoke(this, EventArgs.Empty); };

            // Disable
            btnDisable.Click += delegate { DisableEvent?.Invoke(this, EventArgs.Empty); };

            // Delete
            btnDelete.Click += delegate { DeleteEvent?.Invoke(this, EventArgs.Empty); };

        }

        #endregion

        #region public fields

        /// <summary>
        /// Get Instance
        /// </summary>
        /// <param name="parentContainer"></param>
        /// <returns></returns>
        public static AccountView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new AccountView();
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
        /// Set binding source
        /// </summary>
        /// <param name="source"></param>
        public void SetAccountListBindingSource(BindingSource source)
        {
            dgvAccountList.DataSource = source;
        }

        #endregion
    }
}

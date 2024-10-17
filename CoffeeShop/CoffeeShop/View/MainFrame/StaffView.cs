using CoffeeShop.View.MainFrame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

		#endregion

		#region Properties

		/// <summary>
		/// Check if edit
		/// </summary>
		public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }

        /// <summary>
        /// Check if successful
        /// </summary>
        public bool IsSuccessful
		{
            get { return isSuccessful; }
            set { isSuccessful = value; }
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
            AssociateAndRaiseNewEvents();
            tabStaff.TabPages.Remove(tabPageStaffDetail);
        }

        #region private fields

        /// <summary>
        /// Associate And Raise New Event
        /// </summary>
        private void AssociateAndRaiseNewEvents()
        {
            // Search
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
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
                if (MessageBox.Show("Are you sure to delte the selected staff?", "Warning", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
                BackToListEvent?.Invoke(this, EventArgs.Empty);
				tabStaff.TabPages.Remove(tabPageStaffDetail);
				tabStaff.TabPages.Add(tabPageStaffList);
			};

            // Data View
            dgvStaff.CellClick += delegate
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
            };

            dgvStaff.CellDoubleClick += delegate
            {
				EditEvent?.Invoke(this, EventArgs.Empty);
				tabStaff.TabPages.Remove(tabPageStaffList);
				tabStaff.TabPages.Add(tabPageStaffDetail);
				tabPageStaffDetail.Text = "Edit Staff";
			};
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
        #endregion
	}
}

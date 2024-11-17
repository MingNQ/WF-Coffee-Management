using CoffeeShop.View.DialogForm;
using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShop.Utilities;

namespace CoffeeShop.View.MainFrame
{
	public partial class IngredientView : Form, IIngredientView
	{
		#region Fields
		/// <summary>
		/// Instance
		/// </summary>
		private static IngredientView instance;


		/// <summary>
		/// Check if is edit or add
		/// </summary>
		private bool isEdit;

        /// <summary>
        /// 
        /// </summary>
        private string ingredientID;

        #endregion

        #region Properties
        /// <summary>
        /// Check if is edit or add
        /// </summary>
        public bool IsEdit { get { return isEdit; } set { isEdit = value; } }

		public bool IsSuccessful { get { return isEdit; } set { isEdit = value; } }

		public string IngredientID { get => ingredientID; set => ingredientID = value; }

		public string IngredientName { get ; set ; }
        public string SearchValue { get => txtSearch.Text; set => txtSearch.Text = value; }

        public bool IsOpen => Application.OpenForms.OfType<IngredientView>().Any();
        #endregion

        #region Events
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler ShowEditDialog;
        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public IngredientView()
		{
			InitializeComponent();
            InitializeDataGridView();
            AssociateAndRaiseEvents();
        }

        #region private fiedls

        /// <summary>
        /// Initialize Data Grid View
        /// </summary>
        private void InitializeDataGridView()
        {
            dgvIngredient.AllowUserToAddRows = false;
            dgvIngredient.AllowUserToResizeRows = false;
            dgvIngredient.RowHeadersVisible = false;
            dgvIngredient.AutoGenerateColumns = false;
            dgvIngredient.MultiSelect = false;
            dgvIngredient.ReadOnly = true;
            dgvIngredient.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Change color for header row
            dgvIngredient.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 251, 233);
            dgvIngredient.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold); // Kiểu chữ
            dgvIngredient.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIngredient.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIngredient.DefaultCellStyle.Font = new Font("Arial", 10);

            // ID
            DataGridViewTextBoxColumn colIngredientId = new DataGridViewTextBoxColumn();
            colIngredientId.HeaderText = "Ingredient ID";
            colIngredientId.FillWeight = 40;
            colIngredientId.DataPropertyName = "IngredientID";
            dgvIngredient.Columns.Add(colIngredientId);

            // Name
            DataGridViewTextBoxColumn colIngredientName = new DataGridViewTextBoxColumn();
            colIngredientName.HeaderText = "Ingredient Name";
            colIngredientName.DataPropertyName = "IngredientName";
            dgvIngredient.Columns.Add(colIngredientName);

            dgvIngredient.CellFormatting += dgvIngredient_CellFormatting;
        }

        /// <summary>
        /// Event change looks of data grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvIngredient_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.RowIndex % 2 == 0)
                {
                    dgvIngredient.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                }
                else
                {
                    dgvIngredient.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        /// <summary>
        /// Associate And Raise Events
        /// </summary>
        private void AssociateAndRaiseEvents()
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
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };

            // Add
            btnAdd.Click += delegate
            {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                ShowEditDialog?.Invoke(this, EventArgs.Empty);
            };

            // Edit
            btnEdit.Enabled = false;
            btnEdit.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                ShowEditDialog?.Invoke(this, EventArgs.Empty);
            };

            // Delete
            btnDelete.Enabled = false;
            btnDelete.Click += delegate
            {
                if (MessageBox.Show("Are you sure to delte the selected ingredient?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
            };

            // Data View
            dgvIngredient.CellClick += delegate
            {
                btnDelete.Enabled = true;
                btnEdit.Enabled = true;
            };

            dgvIngredient.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0 && Generate.StaffRole == AppConst.ADMIN_ROLE)
                {
                    EditEvent?.Invoke(this, EventArgs.Empty);
                    ShowEditDialog?.Invoke(this, EventArgs.Empty);
                }
            };
        }

        #endregion

        #region public fields

        /// <summary>
        /// Get Instance
        /// </summary>
        /// <param name="parentContainer"></param>
        /// <returns>Instance</returns>
        public static IngredientView GetInstance(Form parentContainer)
		{
			if (instance == null || instance.IsDisposed)
			{
				instance = new IngredientView();
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
        /// 
        /// </summary>
        /// <param name="ingredientList"></param>
        public void SetLIngredientListBindingSource(BindingSource ingredientList)
        {
            this.dgvIngredient.DataSource = ingredientList;
        }

        /// <summary>
        /// Role Access
        /// </summary>
        public void RoleAccess()
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
    }
}
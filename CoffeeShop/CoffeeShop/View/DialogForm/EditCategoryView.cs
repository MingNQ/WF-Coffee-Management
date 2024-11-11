using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View.DialogCheckList
{
    public partial class EditCategoryView : Form, IEditCategoryView
    {

        #region Properties
        /// <summary>
        /// Setting Tittle 
        /// </summary>
        public string TittleHeader
        {
            get { return this.lbHeader.Text; }
            set { this.lbHeader.Text = value; }
        }
        #endregion
        /// <summary>
        /// Instance
        /// </summary>
        private static EditCategoryView instance;

        public event EventHandler SaveEvent;
        public event EventHandler CancleEvent;

        public EditCategoryView()
        {
            InitializeComponent();
            btnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                this.Close();
            };
            btnCancle.Click += delegate { this.Close(); };
            dgvIngredient.MultiSelect = true;
            dgvIngredient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            InitializeDataGridView();


        }

        private void InitializeDataGridView()
        {
            dgvIngredient.AllowUserToAddRows = false;
            dgvIngredient.AllowUserToResizeRows = false;
            dgvIngredient.RowHeadersVisible = false;
            dgvIngredient.AutoGenerateColumns = false;
            dgvIngredient.MultiSelect = true;
            dgvIngredient.ReadOnly = true;

            dgvIngredient.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 251, 233);
            dgvIngredient.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);
            dgvIngredient.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIngredient.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIngredient.DefaultCellStyle.Font = new Font("Arial", 10);

            // Thêm cột CheckBox để chọn
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Select";         
            checkBoxColumn.Name = "SelectColumn";
            dgvIngredient.Columns.Add(checkBoxColumn);

            // Thêm cột IngredientID
            DataGridViewTextBoxColumn colIngredientID = new DataGridViewTextBoxColumn();
            colIngredientID.HeaderText = "IngredientID";
            colIngredientID.Width = 100;
            colIngredientID.DataPropertyName = "IngredientID";
            dgvIngredient.Columns.Add(colIngredientID);

            // Thêm cột IngredientName
            DataGridViewTextBoxColumn colIngredientName = new DataGridViewTextBoxColumn();
            colIngredientName.HeaderText = "IngredientName";
            colIngredientName.Width = 170;
            colIngredientName.DataPropertyName = "IngredientName";
            dgvIngredient.Columns.Add(colIngredientName);
        }

            /// <summary>
            /// Get instance
            /// </summary>
            /// <returns>instance</returns>
            public static EditCategoryView GetInstance()
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new EditCategoryView();
                }
                else
                {
                    if (instance.WindowState == FormWindowState.Minimized)
                        instance.WindowState = FormWindowState.Normal;
                    instance.BringToFront();
                }

                return instance;
            }
        

		#region Methods

		/// <summary>
		/// Show As Dialog
		/// </summary>
		void IEditCategoryView.ShowDialog()
		{
            ShowDialog();
		}

        public void SetItemListBindingSource(BindingSource itemList)
        {
            dgvIngredient.DataSource = itemList;
        }
        public List<IngredientModel> SelectedIngredients => dgvIngredient.SelectedRows.Cast<DataGridViewRow>().Select(row => row.DataBoundItem as IngredientModel).ToList();

        #endregion

        #region Events
        #endregion

        private void dgvIngredient_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
       

        public void SelectIngredientsInDataGridView(List<IngredientModel> selectedIngredients)
        {
            foreach (DataGridViewRow row in dgvIngredient.Rows)
            {
                string ingredientID = row.Cells["IngredientName"].Value.ToString();
                bool isSelected = selectedIngredients.Any(i => i.IngredientID == ingredientID);
                row.Cells["SelectColumn"].Value = isSelected;
            }
        }
    }
}

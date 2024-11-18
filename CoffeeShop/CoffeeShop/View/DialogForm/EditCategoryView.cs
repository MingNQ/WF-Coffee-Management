using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.View.DialogForm;
using System.Windows.Forms;

namespace CoffeeShop.View.DialogCheckList
{
    public partial class EditCategoryView : Form, IEditCategoryView
    {
        #region Fields

        /// <summary>
        /// Instance
        /// </summary>
        private static EditCategoryView instance;

        #endregion

        #region Properties
        /// <summary>
        /// Setting Tittle 
        /// </summary>
        public string TittleHeader
        {
            get { return this.lbHeader.Text; }
            set { this.lbHeader.Text = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<IngredientModel> SelectedIngredients
        {
            get
            {
                var selectedIngredients = new List<IngredientModel>();

                selectedIngredients = dgvIngredient.Rows.Cast<DataGridViewRow>().
                                                    Where(row => Convert.ToBoolean(row.Cells["SelectColumn"].Value) == true).
                                                    Select(row => row.DataBoundItem as IngredientModel).ToList();

                return selectedIngredients;
            }
        }

        #endregion

        #region Events
        public event EventHandler SaveEvent;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public EditCategoryView()
        {
            InitializeComponent();
            btnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                this.Close();
                DialogMessageView.ShowMessage("success", "Successful Add Ingredient");
            };
            btnCancle.Click += delegate { this.Close(); };
            InitializeDataGridView();
        }

        #region private fields

        /// <summary>
        /// 
        /// </summary>
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
            dgvIngredient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

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

            dgvIngredient.CellFormatting += CellFomat;
            dgvIngredient.CellClick += CellClick;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvIngredient.Columns[e.ColumnIndex].Name != "SelectColumn")
                {
                    DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)dgvIngredient.Rows[e.RowIndex].Cells["SelectColumn"];
                    bool isChecked = (bool)(checkBoxCell.Value ?? false);
                    checkBoxCell.Value = !isChecked;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CellFomat(object sender, DataGridViewCellFormattingEventArgs e)
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

        #endregion

        #region public fields

        /// <summary>
        /// Show As Dialog
        /// </summary>
        void IEditCategoryView.ShowDialog()
		{
            ShowDialog();
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemList"></param>
        public void SetItemListBindingSource(BindingSource itemList)
        {
            dgvIngredient.DataSource = itemList;
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
        #endregion
    }
}

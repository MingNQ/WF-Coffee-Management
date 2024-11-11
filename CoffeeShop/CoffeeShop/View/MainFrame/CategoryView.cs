using CoffeeShop.Model;
using CoffeeShop.View.DialogCheckList;
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


namespace CoffeeShop.View.MainFrame
{
	public partial class CategoryView : Form, ICategoryView
	{
		#region Fields
		private static CategoryView instance;
		private bool isEdit;

		#endregion
		private string message;
		private bool isSuccessful;
		#region Properties
		/// <summary>
		/// Check if is edit or add
		/// </summary>
		public bool IsEdit { 
			get { return isEdit; } 
			set { isEdit = value; } 
		}

        public string ItemID { 
			get => txtItemID.Text; 
			set => txtItemID.Text = value; }
        public int CategoryID {
            get => (int)cboCategoryID.SelectedValue;
            set => cboCategoryID.SelectedItem = value;
        }
        public string ItemName { 
			get => txtItemName.Text; 
			set => txtItemName.Text = value; }
        public float Cost { 
			get => float.Parse(txtPrice.Text); 
			set => txtPrice.Text = value.ToString(); }
        public string SearchValue {
			get => txtSearch.Text; 
			set => txtSearch.Text = value; }
        public bool IsSuccessful { 
			get => isSuccessful; 
			set => isSuccessful = value; }
        public string Message { 
			get => message; 
			set => message = value; }
        private List<IngredientModel> _ingredients;
        public List<IngredientModel> ingredients {
            get => _ingredients;
            set => _ingredients = value; }
        public bool IsOpen { get => Application.OpenForms.OfType<StaffView>().Any(); }
        #endregion
        public CategoryView()
		{
			InitializeComponent();
            tabControl_Food.TabPages.Remove(tabPage2);
            tabControl_Food.TabPages.Remove(tabPage3);
            AssociateAndRaiseEvents();
            InitializeDataGridView();          
        }

        private void InitializeDataGridView()
        {
            dgvItem.AllowUserToAddRows = false;
            dgvItem.AllowUserToResizeRows = false;
            dgvItem.RowHeadersVisible = false;
            dgvItem.AutoGenerateColumns = false;
            dgvItem.MultiSelect = false;
            dgvItem.ReadOnly = true;

            // Change color for header row
            dgvItem.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 251, 233);
            dgvItem.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold); // Kiểu chữ
            dgvItem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvItem.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvItem.DefaultCellStyle.Font = new Font("Arial", 10);

            // ID
            DataGridViewTextBoxColumn colItemID = new DataGridViewTextBoxColumn();
            colItemID.HeaderText = "Item ID";
            colItemID.Width = 200;
            colItemID.DataPropertyName = "ItemID";
            dgvItem.Columns.Add(colItemID);

            // categoryID
            DataGridViewTextBoxColumn colCateogryID = new DataGridViewTextBoxColumn();
            colCateogryID.HeaderText = "Category ID";
            colCateogryID.Width = 150;
            colCateogryID.DataPropertyName = "CategoryID";
            dgvItem.Columns.Add(colCateogryID);

            // name
            DataGridViewTextBoxColumn colItemName = new DataGridViewTextBoxColumn();
            colItemName.HeaderText = "Item Name";
            colItemName.Width = 290;
            colItemName.DataPropertyName = "ItemName";
            dgvItem.Columns.Add(colItemName);

            // cost
            DataGridViewTextBoxColumn colCost = new DataGridViewTextBoxColumn();
            colCost.HeaderText = "Cost ";
            colCost.Width = 180;
            colCost.DataPropertyName = "Cost";
            dgvItem.Columns.Add(colCost);
        }
        private void AssociateAndRaiseEvents()
		{
            btnAdd_Ingredient.Click += delegate
            {
                ShowIngredientCheckList?.Invoke(this, EventArgs.Empty);
            };

            //dki su kien cho nut View-Drink
            btnDrinkView.Click += delegate
            {
                lblCategory.Text = "Category / Drink";
                ViewDrinkEvent?.Invoke(this, EventArgs.Empty);
                tabControl_Food.TabPages.Remove(tabPage1);
                tabControl_Food.TabPages.Add(tabPage2);
                txtSearch.Text = "";
            };

            btnViewFood.Click += delegate
            {
                lblCategory.Text = "Category / Food";
                ViewFoodEvent?.Invoke(this, EventArgs.Empty);
                tabControl_Food.TabPages.Remove(tabPage1);
                tabControl_Food.TabPages.Add(tabPage2);
                txtSearch.Text = "";
            };

            //Search
            btnSearch.Click += delegate
            {
                SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SearchEvent?.Invoke(this, EventArgs.Empty);
                }
            };

            //Add new
            btnAdd.Click += delegate
            {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabControl_Food.TabPages.Remove(tabPage1);
                tabControl_Food.TabPages.Remove(tabPage2);
                tabControl_Food.TabPages.Add(tabPage3);
                lblItemDeatil.Text = "Add New Item";
                txtItemID.Enabled = false;
            };

            //Edit
            btnEdit.Enabled = false;
            btnEdit.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl_Food.TabPages.Remove(tabPage1);
                tabControl_Food.TabPages.Remove(tabPage2);
                tabControl_Food.TabPages.Add(tabPage3);
                lblItemDeatil.Text = "Edit Item";
                txtItemID.Enabled = false;
            };

            //Delete
            btnDelete.Enabled = false;
            btnDelete.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected item?", "Warning",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };

            //Save changes
            btnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    tabControl_Food.TabPages.Remove(tabPage3);
                    tabControl_Food.TabPages.Add(tabPage2);
                }
                MessageBox.Show(Message);
            };

            //Cancel
            btnCancel.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl_Food.TabPages.Remove(tabPage3);
                tabControl_Food.TabPages.Add(tabPage2);
            };

            //BackCategory
            btnBackCategory.Click += delegate
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                lblCategory.Text = "Category";
                tabControl_Food.TabPages.Remove(tabPage2);
                if (!tabControl_Food.TabPages.Contains(tabPage1))
                {
                    tabControl_Food.TabPages.Add(tabPage1);
                }
            };
            //Back List
            btnBackToList.Click += delegate
            {
                // Xóa tabPage1 và tabPage3 khỏi tabControl1
                tabControl_Food.TabPages.Remove(tabPage1);
                tabControl_Food.TabPages.Remove(tabPage3);

                // Thêm lại tabPage2 vào tabControl1 nếu nó chưa có
                if (!tabControl_Food.TabPages.Contains(tabPage2))
                {
                    tabControl_Food.TabPages.Add(tabPage2);
                }
            };

            dgvItem.CellClick += delegate
             {
                 btnDelete.Enabled = true;
                 btnEdit.Enabled = true;
             };
            dgvItem.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    EditEvent?.Invoke(this, EventArgs.Empty);
                    tabControl_Food.TabPages.Remove(tabPage1);
                    tabControl_Food.TabPages.Remove(tabPage2);
                    tabControl_Food.TabPages.Add(tabPage3);
                    lblItemDeatil.Text = "Edit Staff";
                }
            };

            this.Controls.Add(tabControl_Food);
        }

        public static CategoryView GetInstance(Form parentContainer)
		{
			if (instance == null || instance.IsDisposed)
			{
				instance = new CategoryView();
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

        public void SetItemListBindingSource(BindingSource itemList)
        {
			dgvItem.DataSource = itemList;
        }

		public void LoadCategories(List<CategoryModel> categories)
		{
            cboCategoryID.DataSource = null;
            cboCategoryID.DataSource = categories;
            cboCategoryID.DisplayMember = "CategoryName";
            cboCategoryID.ValueMember = "CategoryID";
		}


        public event EventHandler ShowIngredientCheckList;

		public event EventHandler ViewFoodEvent;
		public event EventHandler ViewDrinkEvent;

		public event EventHandler AddNewEvent;
        public event EventHandler SearchEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        public event EventHandler BackToListEvent;
        public event EventHandler BackToCategoryEvent;

        public event EventHandler Add_IngredientEvent;

        private void dgvItem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.RowIndex % 2 == 0)
                {
                    dgvItem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                }
                else
                {
                    dgvItem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        public void UpdateIngredientList(List<IngredientModel> ingredients)
        {
            lsbIngredient.Items.Clear();
            this.ingredients = ingredients.OrderBy(i => i.IngredientID).ToList();
            foreach (var item in ingredients)
            {
                lsbIngredient.Items.Add($"{item.IngredientID} - {item.IngredientName}");
            }
        }

        public List<string> GetSelectedIngredientIDs()
        {
            var ingredientIDs = new List<string>();
            foreach (var item in lsbIngredient.Items)
            {              
                var parts = item.ToString().Split('-');
                if (parts.Length > 0)
                {
                    ingredientIDs.Add(parts[0].Trim());
                }
            }
            return ingredientIDs;
        }

    }
}

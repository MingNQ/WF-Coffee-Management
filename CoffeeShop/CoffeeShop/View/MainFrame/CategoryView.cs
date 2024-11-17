using CoffeeShop.Model;
using CoffeeShop.Utilities;
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
        /// <summary>
        /// 
        /// </summary>
        private static CategoryView instance;

        /// <summary>
        /// 
        /// </summary>
		private bool isEdit;

        /// <summary>
        /// 
        /// </summary>
        private string message;

        /// <summary>
        /// 
        /// </summary>
        private bool isSuccessful;

        /// <summary>
        /// 
        /// </summary>
        private List<IngredientModel> ingredients = new List<IngredientModel>();

        #endregion

        #region Properties
        /// <summary>
        /// Check if is edit or add
        /// </summary>
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ItemID
        {
            get => txtItemID.Text;
            set => txtItemID.Text = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public int CategoryID
        {
            get => !isEdit ? (int)cbCategory.SelectedValue : int.Parse(txtCategory.Text);
            set
            {
                txtCategory.Text = value.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ItemName
        {
            get => txtItemName.Text;
            set => txtItemName.Text = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public float Cost
        {
            get => float.Parse(txtPrice.Text);
            set => txtPrice.Text = value.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        public string SearchValue
        {
            get => txtSearch.Text;
            set => txtSearch.Text = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSuccessful
        {
            get => isSuccessful;
            set => isSuccessful = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Message
        {
            get => message;
            set => message = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public List<IngredientModel> Ingredients 
        { 
            get => ingredients; 
            set => ingredients = value; 
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsOpen { get => Application.OpenForms.OfType<CategoryView>().Any(); }

        #endregion

        #region Events
        public event EventHandler ShowIngredientCheckList;
        public event EventHandler ViewFoodEvent;
        public event EventHandler ViewDrinkEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler SearchEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;
        public event EventHandler BackEvent;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public CategoryView()
        {
            InitializeComponent();
            AssociateAndRaiseEvents();
            InitializeDataGridView();
            RoleAccess();
        }

        #region private fields

        /// <summary>
        /// Initialize Data Grid View Looks
        /// </summary>
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

        /// <summary>
        /// Associate And Raise Events
        /// </summary>
        private void AssociateAndRaiseEvents()
        {
            txtItemID.Enabled = false;
            txtCategory.Enabled = false;

            //dki su kien cho nut View-Drink
            btnDrinkView.Click += delegate
            {
                lblCategory.Text = "Category / Drink";
                ViewDrinkEvent?.Invoke(this, EventArgs.Empty);
                tabControlCategory.TabPages.Remove(tabCategory);
                tabControlCategory.TabPages.Add(tabCategoryList);
                txtSearch.Text = "";
            };

            btnViewFood.Click += delegate
            {
                lblCategory.Text = "Category / Food";
                ViewFoodEvent?.Invoke(this, EventArgs.Empty);
                tabControlCategory.TabPages.Remove(tabCategory);
                tabControlCategory.TabPages.Add(tabCategoryList);
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
                tabControlCategory.TabPages.Remove(tabCategory);
                tabControlCategory.TabPages.Remove(tabCategoryList);
                tabControlCategory.TabPages.Add(tabCategoryDetail);
                lblItemDeatil.Text = "Add New Item";
                ShowControl(false);
            };

            //Edit
            btnEdit.Enabled = false;
            btnEdit.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControlCategory.TabPages.Remove(tabCategory);
                tabControlCategory.TabPages.Remove(tabCategoryList);
                tabControlCategory.TabPages.Add(tabCategoryDetail);
                lblItemDeatil.Text = "Edit Item";
                ShowControl(true);
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
                }
                MessageBox.Show(Message);
            };

            //Save changes
            btnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    tabControlCategory.TabPages.Remove(tabCategoryDetail);
                    tabControlCategory.TabPages.Add(tabCategoryList);
                    lsbIngredient.Items.Clear();
                }
                MessageBox.Show(Message);
            };

            //Cancel
            btnCancel.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControlCategory.TabPages.Remove(tabCategoryDetail);
                tabControlCategory.TabPages.Add(tabCategoryList);

            };

            //BackCategory
            btnBackCategory.Click += delegate
            {
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
                lblCategory.Text = "Category";
                tabControlCategory.TabPages.Remove(tabCategoryList);
                if (!tabControlCategory.TabPages.Contains(tabCategory))
                {
                    tabControlCategory.TabPages.Add(tabCategory);
                }
                lsbIngredient.Items.Clear();
            };

            //Back List
            btnBackToList.Click += delegate
            {
                BackEvent?.Invoke(this, EventArgs.Empty);
                // Xóa tabPage1 và tabPage3 khỏi tabControl1
                tabControlCategory.TabPages.Remove(tabCategory);
                tabControlCategory.TabPages.Remove(tabCategoryDetail);

                // Thêm lại tabPage2 vào tabControl1 nếu nó chưa có
                if (!tabControlCategory.TabPages.Contains(tabCategoryList))
                {
                    tabControlCategory.TabPages.Add(tabCategoryList);
                }
                lsbIngredient.Items.Clear();
            };

            // Add ingredient
            btnAdd_Ingredient.Click += delegate
            {
                ShowIngredientCheckList?.Invoke(this, EventArgs.Empty);
            };

            dgvItem.CellClick += delegate
            {
                 btnDelete.Enabled = true;
                 btnEdit.Enabled = true;
            };

            // Edit Category When DoubleClick
            dgvItem.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0 && Generate.StaffRole == AppConst.ADMIN_ROLE)
                {
                    EditEvent?.Invoke(this, EventArgs.Empty);
                    tabControlCategory.TabPages.Remove(tabCategory);
                    tabControlCategory.TabPages.Remove(tabCategoryList);
                    tabControlCategory.TabPages.Add(tabCategoryDetail);
                    lblItemDeatil.Text = "Edit Item";
                }
            };

            lsbIngredient.MouseDoubleClick += MouseClickEvent;

            this.Controls.Add(tabControlCategory);
        }

        /// <summary>
        /// Delete Ingredient When DoubleClick Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MouseClickEvent(object sender, MouseEventArgs e)
        {
            if (lsbIngredient.SelectedItem != null)
            {
                var selectedItem = lsbIngredient.SelectedItem;
                var itemName = selectedItem.ToString().Split('-').Last().Trim();

                if (MessageBox.Show($"Are you sure to DELETE item \"{selectedItem}\"", "Warning", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    lsbIngredient.Items.Remove(selectedItem);
                    ingredients.Remove(ingredients.Where(i => i.IngredientName == itemName).FirstOrDefault());
                    MessageBox.Show($"Deleted {selectedItem}");
                }
            }
        }

        /// <summary>
        /// Cell Format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Show Control
        /// </summary>
        /// <param name="isEdit"></param>
        private void ShowControl(bool isEdit)
        {
            txtCategory.Visible = isEdit;
            cbCategory.Visible = !isEdit;
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
        }

        #endregion

        #region public fields

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parentContainer"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemList"></param>
        public void SetItemListBindingSource(BindingSource itemList)
        {
            dgvItem.DataSource = itemList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categories"></param>
        public void LoadCategories(List<CategoryModel> categories)
        {
            cbCategory.DataSource = categories;
            cbCategory.ValueMember = "CategoryID";
            cbCategory.DisplayMember = "CategoryName";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ingredients"></param>
        public void UpdateIngredientList(List<IngredientModel> ingredients)
        {
            foreach (var item in ingredients)
            {
                if (!this.ingredients.Any(i => i.IngredientID == item.IngredientID))
                {
                    lsbIngredient.Items.Add($"{item.IngredientID} - {item.IngredientName}");
                    this.ingredients.Add(item);
                }
            }

            this.ingredients = this.ingredients.OrderBy(i => i.IngredientID).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        public void ShowPage()
        {
            if (!tabControlCategory.TabPages.Contains(tabCategory))
            {
                tabControlCategory.TabPages.Add(tabCategory);
                BackEvent?.Invoke(this, EventArgs.Empty);
                lsbIngredient.Items.Clear();
            }
            tabControlCategory.TabPages.Remove(tabCategoryList);
            tabControlCategory.TabPages.Remove(tabCategoryDetail);
            this.Show();
        }

        #endregion
    }
}

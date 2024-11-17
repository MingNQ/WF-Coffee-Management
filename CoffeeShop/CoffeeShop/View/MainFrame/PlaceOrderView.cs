using CoffeeShop.Model;
using CoffeeShop.Utilities;
using CoffeeShop.View.CustomControls;
using CoffeeShop.View.DialogForm;
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
    public partial class PlaceOrderView : Form, IPlaceOrderView
    {
        #region Fields

        /// <summary>
        /// Instance
        /// </summary>
        private static PlaceOrderView instance;

        /// <summary>
        /// 
        /// </summary>
        private string itemID;

        /// <summary>
        /// 
        /// </summary>
        private bool isSuccessful;

        /// <summary>
        /// 
        /// </summary>
        private bool isEdit;

        #endregion

        #region Properties

        /// <summary>
        /// Floor Number
        /// </summary>
        public int FloorNo 
        { 
            get { return int.Parse(lblFloor.Text.Substring(lblFloor.Text.Length - 1)); }
            set { lblFloor.Text = "Floor: " + value; } 
        }

        /// <summary>
        /// Form is open
        /// </summary>
        public bool IsOpen 
        {
            get => Application.OpenForms.OfType<PlaceOrderView>().Any();
        }

        /// <summary>
        /// 
        /// </summary>
        public string TableNo 
        { 
            get
            {
                return lbTableNo.Text.Substring(7);
            }
            set
            {
                lbTableNo.Text = "Table: " + value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string StaffName 
        { 
            get
            {
                return lbStaff.Text.Substring(7);
            }
            set
            {
                lbStaff.Text = "Staff: " + value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string OrderID 
        { 
            get 
            {
                return lbOrder.Text.Substring(7);
            }
            set
            {
                lbOrder.Text = "Order: " + value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ItemName 
        { 
            get { return cbbItemName.Text; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Quantity 
        { 
            get { return Convert.ToInt32(numQuantity.Value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public float Price 
        { 
            get { return float.Parse(txtPrice.Text); }
        }

        /// <summary>
        /// 
        /// </summary>
        public float Total 
        {
            get { return float.Parse(txtTotal.Text); }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Description 
        {
            get { return rTxtDescription.Text; }
            set {  rTxtDescription.Text = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int NumberPeople 
        { 
            get { return Convert.ToInt32(numPeople.Value); }
            set { numPeople.Value = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ItemID 
        { 
            get { return cbbItemName.SelectedValue.ToString(); }
            set { }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSuccessful
        {
            get { return isSuccessful; }
            set { isSuccessful = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsEdit 
        {
            get { return isEdit; }
            set { isEdit = value; }
        }

        #endregion

        #region Events
        public event EventHandler DisplayPage;
        public event EventHandler DisplayPreviousPage;
        public event EventHandler DisplayNextPage;
        public event EventHandler OrderEvent;
        public event EventHandler SelectedCategoryChangeEvent;
        public event EventHandler SelectedItemChangeEvent;
        public event EventHandler AddToCartEvent;
        public event EventHandler RemoveEvent;
        public event EventHandler RemoveAllEvent;
        public event EventHandler ReduceEvent;
        public event EventHandler CompleteOrderEvent;
        public event EventHandler BackEvent;
        public event EventHandler PayEvent;
        public event EventHandler PrintEvent;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public PlaceOrderView()
        {
            InitializeComponent();
            InitializeDataGridView();
            InitiateAndRaiseEvents();
            tabPlaceOrder.TabPages.Remove(tabPageOrder);
        }

        #region private fields

        /// <summary>
        /// Initialize Data Grid View
        /// </summary>
        private void InitializeDataGridView()
        {
            dgvOrder.AllowUserToAddRows = false;
            dgvOrder.AllowUserToResizeRows = false;
            dgvOrder.RowHeadersVisible = false;
            dgvOrder.AutoGenerateColumns = false;
            dgvOrder.MultiSelect = false;
            dgvOrder.ReadOnly = true;
            dgvOrder.EnableHeadersVisualStyles = false;
            dgvOrder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrder.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Change color for header row
            dgvOrder.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Regular);
            dgvOrder.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 14, FontStyle.Bold); // Kiểu chữ
            dgvOrder.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(168, 140, 118);
            dgvOrder.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(168, 140, 118);

            // Item Name
            DataGridViewTextBoxColumn colItemName = new DataGridViewTextBoxColumn();
            colItemName.HeaderText = "Item Name";
            colItemName.DataPropertyName = "ItemName";
            dgvOrder.Columns.Add(colItemName);

            // Item Price
            DataGridViewTextBoxColumn colItemPrice = new DataGridViewTextBoxColumn();
            colItemPrice.HeaderText = "Unit Price";
            colItemPrice.DataPropertyName = "UnitPrice";
            dgvOrder.Columns.Add(colItemPrice);

            // Item Price
            DataGridViewTextBoxColumn colItemQuantity = new DataGridViewTextBoxColumn();
            colItemQuantity.HeaderText = "Quantity";
            colItemQuantity.DataPropertyName = "Quantity";
            dgvOrder.Columns.Add(colItemQuantity);

            // Total Price
            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
            colTotal.HeaderText = "Total";
            colTotal.DataPropertyName = "Total";
            dgvOrder.Columns.Add(colTotal);

            // Total Price
            DataGridViewTextBoxColumn colDescription = new DataGridViewTextBoxColumn();
            colDescription.HeaderText = "Description";
            colDescription.DataPropertyName = "Description";
            dgvOrder.Columns.Add(colDescription);
        }

        /// <summary>
        /// Initiate And Raise Events
        /// </summary>
        private void InitiateAndRaiseEvents()
        {
            ResetControl();

            // Initialize Table
            tabPageTableOrder.Text = "Select Table";
            tabPageOrder.Text = "Order";

            // Pagination table order
            this.Load += delegate { DisplayPage?.Invoke(this, EventArgs.Empty); };
            btnPrevious.Click += delegate { DisplayPreviousPage?.Invoke(this, EventArgs.Empty); };
            btnNext.Click += delegate { DisplayNextPage?.Invoke(this, EventArgs.Empty); };

            // Back
            btnBack.Click += delegate
            {
                BackEvent?.Invoke(this, EventArgs.Empty);
                tabPlaceOrder.TabPages.Remove(tabPageOrder);
                tabPlaceOrder.TabPages.Add(tabPageTableOrder);
                ResetControl();
            };

            // List Category Event
            cbbCategory.SelectedIndexChanged += delegate 
            {
                numQuantity.Value = 0;
                txtTotal.Text = "";
                SelectedCategoryChangeEvent?.Invoke(this, EventArgs.Empty);
            };
            cbbItemName.SelectedIndexChanged += delegate 
            {
                numQuantity.Value = 0;
                txtTotal.Text = "";
                SelectedItemChangeEvent?.Invoke(this, EventArgs.Empty); 
            };

            // Calculate Cost
            numQuantity.ValueChanged += CalculateTotalPrice;

            // Add to Cart
            btnAddToCart.Click += delegate 
            { 
                if (numQuantity.Value <= 0)
                {
                    DialogMessageView.ShowMessage("information", "Please Select Quantity!");
                    return;
                }

                AddToCartEvent?.Invoke(this, EventArgs.Empty);
                btnPrint.Enabled = true;
                btnPay.Enabled = true;
            };

            // Data Grid View
            dgvOrder.CellClick +=  delegate { btnRemove.Enabled = true; btnReduce.Enabled = true; };
            dgvOrder.CellDoubleClick += (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    RemoveEvent?.Invoke(this, EventArgs.Empty);
                }
            };

            // Remove 
            btnRemove.Click += delegate 
            {
                RemoveEvent?.Invoke(this, EventArgs.Empty); 
            };

            // Reduce
            btnReduce.Click += delegate
            {
                ReduceEvent?.Invoke(this, EventArgs.Empty);
            };

            // Remove All
            btnRemoveAll.Click += delegate
            {
                RemoveAllEvent?.Invoke(this, EventArgs.Empty);
            };

            // Complete Order
            btnCompleteOrder.Click += delegate
            {
                CompleteOrderEvent?.Invoke(this, EventArgs.Empty);

                if (isSuccessful)
                {
                    // Return select
                    BackEvent?.Invoke(this, EventArgs.Empty);
                    tabPlaceOrder.TabPages.Remove(tabPageOrder);
                    tabPlaceOrder.TabPages.Add(tabPageTableOrder);
                    ResetControl();

                    DialogMessageView.ShowMessage("success", $"Success Order! ID: {OrderID}, Table {TableNo}");
                }
            };

            // Print 
            btnPrint.Click += delegate { PrintEvent?.Invoke(this, EventArgs.Empty); };

            // Pay
            btnPay.Click += delegate { PayEvent?.Invoke(this, EventArgs.Empty); };
        }

        /// <summary>
        /// Reset
        /// </summary>
        private void ResetControl()
        {
            // Initialize Button
            btnRemove.Enabled = false;
            btnReduce.Enabled = false;
            btnPay.Enabled = false;
            btnPrint.Enabled = false;

            // Initialize Text
            txtPrice.Enabled = false;
            txtTotal.Enabled = false;
        }

        /// <summary>
        /// Calculate Total Price
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateTotalPrice(object sender, EventArgs e)
        {
            float unitPrice = float.Parse(txtPrice.Text);
            int quantity = Convert.ToInt32(numQuantity.Value);

            txtTotal.Text = String.Format("{0:N0}", unitPrice * quantity);
        }

        #endregion

        #region public fields

        /// <summary>
        /// Get Instance
        /// </summary>
        /// <param name="parentContainer"></param>
        /// <returns></returns>
        public static PlaceOrderView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PlaceOrderView();
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
        /// Update Flow Panel Table View
        /// </summary>
        public void UpdateTableView(IEnumerable<TableOrder> floor)
        {
            flowPnlTableOrder.Controls.Clear();
            var emptyTables = floor.Count(t => t.Status == AppConst.TABLE_AVAILABLE);
            lblEmpty.Text = $"Empty: {emptyTables}/{floor.Count()}";

            foreach (var table in floor)
            {
                var tmp = new TableOrderControl()
                {
                    TableID = table.TableID,
                    Status = table.Status,
                };
                tmp.ClickEvent += (s, e) =>
                {
                    tabPlaceOrder.TabPages.Remove(tabPageTableOrder);
                    tabPlaceOrder.TabPages.Add(tabPageOrder);
                    TableNo = tmp.TableID;
                    StaffName = Generate.StaffName;

                    // Check table status
                    if (tmp.Status == AppConst.TABLE_AVAILABLE)
                    {
                        OrderID = Generate.GenerateID("O");
                        isEdit = false;
                    }
                    else
                    {
                        btnPrint.Enabled = true;
                        btnPay.Enabled = true;
                        isEdit = true;
                    }
                    OrderEvent?.Invoke(this, EventArgs.Empty);
                };

                flowPnlTableOrder.Controls.Add(tmp);
            }
        }

        /// <summary>
        /// Get Category List
        /// </summary>
        /// <param name="categories"></param>
        public void GetListCategoy(IEnumerable<CategoryModel> categories)
        {
            cbbCategory.DataSource = categories;
            cbbCategory.ValueMember = "CategoryID";
            cbbCategory.DisplayMember = "CategoryName";
        }

        /// <summary>
        /// Get Item List
        /// </summary>
        /// <param name="categories"></param>
        public void GetListItem(IEnumerable<ItemModel> items)
        {
            var listItemByCategory = items.Where(i => i.CategoryID == Convert.ToInt32(cbbCategory.SelectedValue)).ToList();
            cbbItemName.DataSource = listItemByCategory;
            cbbItemName.ValueMember = "ItemID";
            cbbItemName.DisplayMember = "ItemName";
        }

        /// <summary>
        /// Update Price when select Item
        /// </summary>
        public void UpdatePrice(IEnumerable<ItemModel> items)
        {
            var item = items.Where(i => i.ItemID == cbbItemName.SelectedValue.ToString()).FirstOrDefault();
            txtPrice.Text = item.Cost.ToString("N0");
        }

        /// <summary>
        /// Set List for Data grid view
        /// </summary>
        /// <param name="orderDetail"></param>
        public void SetListBindingSource(BindingSource orderDetail)
        {
            dgvOrder.DataSource = orderDetail;
        }

        /// <summary>
        /// Calculate Grand Total 
        /// </summary>
        public void CalculateGrandTotal(List<OrderDetailModel> orderDetails)
        {
            float sum = 0;

            orderDetails.ForEach(order =>
            {
                sum += order.Total;
            });

            lbGrandTotal.Text = sum.ToString("N0") + " VNĐ";
        }

        /// <summary>
        /// Disable Control
        /// </summary>
        public void DisableControl()
        {
            btnAddToCart.Enabled = false;
            btnReduce.Enabled = false;
            btnRemove.Enabled = false;
            btnRemoveAll.Enabled = false;
            btnCompleteOrder.Enabled = false;
        }

        /// <summary>
        /// Show Page
        /// </summary>
        public void ShowPage()
        {
            if (!tabPlaceOrder.TabPages.Contains(tabPageTableOrder))
            {
                tabPlaceOrder.TabPages.Clear();
                tabPlaceOrder.TabPages.Add(tabPageTableOrder);
                BackEvent?.Invoke(this, EventArgs.Empty);
            }

            // Show 
            this.Show();
        }
        #endregion
    }
}

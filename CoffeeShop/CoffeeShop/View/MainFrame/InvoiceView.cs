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
    public partial class InvoiceView : Form, IInvoiceView
    {
        #region Events
        public event EventHandler PrintEvent;
        public event EventHandler CancelEvent;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public InvoiceView()
        {
            InitializeComponent();
            InitializeAndRaiseEvent();
            InitializeDatagridview();
        }

        #region Private field
        /// <summary>
        /// Initialize Data Grid View
        /// </summary>
        private void InitializeDatagridview()
        {
            // Cấu hình DataGridView
            dgvInvoice.AllowUserToAddRows = false;
            dgvInvoice.AllowUserToResizeRows = false;
            dgvInvoice.AllowUserToResizeColumns = false;
            dgvInvoice.RowHeadersVisible = false;
            dgvInvoice.AutoGenerateColumns = false;
            dgvInvoice.MultiSelect = false;
            dgvInvoice.ReadOnly = true;
            dgvInvoice.EnableHeadersVisualStyles = false;
            dgvInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInvoice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Thay đổi màu cho tiêu đề
            dgvInvoice.DefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Regular);
            dgvInvoice.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold); // Kiểu chữ
            dgvInvoice.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(168, 140, 118);
            dgvInvoice.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(168, 140, 118);

            // Cột: Item Name
            DataGridViewTextBoxColumn colItemName = new DataGridViewTextBoxColumn();
            colItemName.HeaderText = "Item Name";
            colItemName.DataPropertyName = "ItemName";
            dgvInvoice.Columns.Add(colItemName);

            // Cột: Unit Price
            DataGridViewTextBoxColumn colItemPrice = new DataGridViewTextBoxColumn();
            colItemPrice.HeaderText = "Unit Price";
            colItemPrice.DataPropertyName = "UnitPrice";
            dgvInvoice.Columns.Add(colItemPrice);

            // Cột: Quantity
            DataGridViewTextBoxColumn colItemQuantity = new DataGridViewTextBoxColumn();
            colItemQuantity.HeaderText = "Quantity";
            colItemQuantity.DataPropertyName = "Quantity";
            dgvInvoice.Columns.Add(colItemQuantity);

            // Cột: Total Price
            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
            colTotal.HeaderText = "Total";
            colTotal.DataPropertyName = "Total";
            dgvInvoice.Columns.Add(colTotal);

            // Cột: Description
            DataGridViewTextBoxColumn colDescription = new DataGridViewTextBoxColumn();
            colDescription.HeaderText = "Des";
            colDescription.DataPropertyName = "Description";
            dgvInvoice.Columns.Add(colDescription);
        }

        /// <summary>
        /// Initialize and raise event
        /// </summary>
        private void InitializeAndRaiseEvent()
        {
            btnPrint.Click += delegate
            {
                PrintEvent?.Invoke(this, EventArgs.Empty);
            };
            btnCancel.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
            };
        }
        #endregion

        #region Public      
        #endregion
    }
}

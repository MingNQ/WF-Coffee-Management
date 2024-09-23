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
	public partial class MainView : Form, IMainView
    {
        /// <summary>
        /// Constructor for Main View
        /// </summary>
        public MainView()
        {
            InitializeComponent();
            
            // Add event to button
            btnDashboard.Click += delegate { ShowDashboardView?.Invoke(this, EventArgs.Empty); };
            btnPlaceOrder.Click += delegate { ShowPlaceOrderView?.Invoke(this, EventArgs.Empty); };
            btnCategory.Click += delegate { ShowCategoryView?.Invoke(this, EventArgs.Empty); };
            btnCustomer.Click += delegate { ShowCustomerView?.Invoke(this, EventArgs.Empty); };
            btnStaff.Click += delegate { ShowStaffView?.Invoke(this, EventArgs.Empty); };
        }

		#region Event
		public event EventHandler ShowDashboardView;
		public event EventHandler ShowPlaceOrderView;
		public event EventHandler ShowCategoryView;
		public event EventHandler ShowStaffView;
		public event EventHandler ShowCustomerView;
		#endregion

		private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem form con có đang mở không, nếu có thì đóng lại trước
            foreach (var form in MdiChildren)
            {
                form.Close();
            }

            PlaceOrder placeOrder = new PlaceOrder();
            placeOrder.MdiParent = this;
            placeOrder.Dock = DockStyle.Fill;
            placeOrder.Show();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                form.Close();
            }
            Category category = new Category();
            category.MdiParent = this;
            category.Dock = DockStyle.Fill;
            category.Show();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                form.Close();
            }
            Staff staff = new Staff();
            staff.MdiParent = this;
            staff.Dock = DockStyle.Fill;
            staff.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            foreach (var form in MdiChildren)
            {
                form.Close();
            }

            Customer customer = new Customer();
            customer.MdiParent = this;
            customer.Dock = DockStyle.Fill;
            customer.Show();
        }
    }
}

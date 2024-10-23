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
            btnIngredient.Click += delegate { ShowIngredientView?.Invoke(this, EventArgs.Empty); };
            btnPlaceOrder.Click += delegate { ShowMenuOrderView?.Invoke(this, EventArgs.Empty); };
        }

		#region Event
		public event EventHandler ShowDashboardView;
		public event EventHandler ShowPlaceOrderView;
		public event EventHandler ShowCategoryView;
		public event EventHandler ShowStaffView;
		public event EventHandler ShowCustomerView;
		public event EventHandler ShowIngredientView;
        public event EventHandler ShowMenuOrderView;
        #endregion
    }
}

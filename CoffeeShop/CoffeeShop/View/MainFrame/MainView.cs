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
        #region fields

        /// <summary>
        /// Dropdown menu is collapsed or not
        /// </summary>
        private bool isCollapsed;

        #endregion
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
            btnAccount.Click += delegate { ShowAccountView?.Invoke(this, EventArgs.Empty); };
            btnLogout.Click += delegate { LogoutEvent?.Invoke(this, EventArgs.Empty); };

            isCollapsed = true;
            timeDropDown.Tick += DropDownMenuAppear;
            btnSystem.Click += DropDownClick;
        }


        #region Event
        public event EventHandler ShowDashboardView;
		public event EventHandler ShowPlaceOrderView;
		public event EventHandler ShowCategoryView;
		public event EventHandler ShowStaffView;
		public event EventHandler ShowCustomerView;
		public event EventHandler ShowIngredientView;
        public event EventHandler ShowAccountView;
        public event EventHandler LogoutEvent;
        #endregion

        #region private fields
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DropDownMenuAppear(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                pnlSystemDrop.Height += 10;

                if (pnlSystemDrop.Size == pnlSystemDrop.MaximumSize)
                {
                    timeDropDown.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                pnlSystemDrop.Height -= 10;

                if (pnlSystemDrop.Size == pnlSystemDrop.MinimumSize)
                {
                    timeDropDown.Stop();
                    isCollapsed = true;
                }
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DropDownClick(object sender, EventArgs e)
        {
            timeDropDown.Start();
            timeDropDown.Interval = 10;
        }

        #endregion
    }
}

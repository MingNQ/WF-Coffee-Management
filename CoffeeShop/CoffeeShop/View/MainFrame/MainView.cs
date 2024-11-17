using CoffeeShop.Utilities;
using CoffeeShop.View.DialogForm;
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
        #region Fields

        /// <summary>
        /// Dropdown menu is collapsed or not
        /// </summary>
        private bool isCollapsed;
        private string staffID;

        #endregion

        #region Properties

        /// <summary>
        /// Get Username
        /// </summary>
        public string Username
        {
            get { return lbUsername.Text; }
            set { lbUsername.Text = value; }
        }
        
        /// <summary>
        /// Get Role
        /// </summary>
        public string Role
        {
            get { return lbRole.Text; }
            set { lbRole.Text = value; }
        }
        /// <summary>
        /// Get Staff ID 
        /// </summary>
        public string StaffID
        {
            get { return staffID; }
            set { staffID = value; }
        }

        #endregion

        #region Event
        public event EventHandler ShowDashboardView;
        public event EventHandler ShowPlaceOrderView;
        public event EventHandler ShowCategoryView;
        public event EventHandler ShowStaffView;
        public event EventHandler ShowCustomerView;
        public event EventHandler ShowIngredientView;
        public event EventHandler ShowAccountView;
        public event EventHandler ShowStaffDetailInformation;
        public event EventHandler LogoutEvent;
        #endregion

        /// <summary>
        /// Constructor for Main View
        /// </summary>
        public MainView()
        {
            InitializeComponent();
            RaiseEvents();
            btnLogout.Click += delegate { LogoutEvent?.Invoke(this, EventArgs.Empty); };
            btnExit.Click += delegate { LogoutEvent?.Invoke(this, EventArgs.Empty); };

            isCollapsed = true;
            timeDropDown.Tick += DropDownMenuAppear;
            btnSystem.Click += DropDownClick;
        }

        #region private fields

        /// <summary>
        /// Raise Event
        /// </summary>
        private void RaiseEvents()
        {
            // Add event to button
            btnDashboard.Click += delegate { ShowDashboardView?.Invoke(this, EventArgs.Empty); };
            btnPlaceOrder.Click += delegate { ShowPlaceOrderView?.Invoke(this, EventArgs.Empty); };
            btnCategory.Click += delegate { ShowCategoryView?.Invoke(this, EventArgs.Empty); };
            btnCustomer.Click += delegate 
            {
                // Role Access
                if (Generate.StaffRole != AppConst.ADMIN_ROLE)
                {
                    DialogMessageView.ShowMessage("warning", "You don't have permission to access this site!");
                    return;
                }
                ShowCustomerView?.Invoke(this, EventArgs.Empty); 
            };
            btnStaff.Click += delegate { ShowStaffView?.Invoke(this, EventArgs.Empty); };
            btnIngredient.Click += delegate { ShowIngredientView?.Invoke(this, EventArgs.Empty); };
            lbViewProfile.Click += delegate { ShowStaffDetailInformation?.Invoke(this, EventArgs.Empty); };
            btnAccount.Click += delegate { ShowAccountView?.Invoke(this, EventArgs.Empty); };
            btnAccount.Click += DropDownClick;
        }

        /// <summary>
        /// Show Menu
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
        /// Click to System Tab 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DropDownClick(object sender, EventArgs e)
        {
            // Role Access
            if (Generate.StaffRole != AppConst.ADMIN_ROLE)
            {
                DialogMessageView.ShowMessage("warning", "You don't have permission to access this site!");
                return;
            }
            timeDropDown.Start();
            timeDropDown.Interval = 10;
        }

        #endregion

        #region public fields
        #endregion
    }
}

using CoffeeShop.Utilities;
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
    public partial class DashboardView : Form, IDashboardView
	{
		#region Fields

		/// <summary>
		/// Instance for Dashboard view
		/// </summary>
		private static DashboardView instance;

        #endregion

        #region Properties
		/// <summary>
		/// Total Staff
		/// </summary>
        public int TotalStaff 
		{ 
			get { return Convert.ToInt32(lbTotalStaff.Text); }
			set { lbTotalStaff.Text = value.ToString(); }
		}

		/// <summary>
		/// Total Customer
		/// </summary>
        public int TotalCustomer 
		{
            get { return Convert.ToInt32(lbTotalCustomer.Text); }
            set { lbTotalCustomer.Text = value.ToString(); }
        }

		/// <summary>
		/// Today's Income
		/// </summary>
        public float Income 
		{
            get { return float.Parse(lbIncome.Text); }
            set { lbIncome.Text = value.ToString("N0") + "VNĐ"; }
        }

		/// <summary>
		/// Total Income
		/// </summary>
        public float TotalIncome 
		{
            get { return float.Parse(lbTotalIncome.Text); }
            set { lbTotalIncome.Text = value.ToString("N0") + "VNĐ"; }
        }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public DashboardView()
		{
			InitializeComponent();
		}

        #region private fields

        #endregion

        #region public fields
        /// <summary>
        /// Get Instance for Dashboard
        /// </summary>
        /// <param name="parentContainer">Parent Container</param>
        /// <returns>Instance</returns>
        public static DashboardView GetInstance(Form parentContainer)
		{
			if (instance == null || instance.IsDisposed)
			{
				instance = new DashboardView();
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
		/// Show Page
		/// </summary>
        public void ShowPage()
        {
			if (Generate.StaffRole != AppConst.ADMIN_ROLE)
			{
				pnlDashboard.Visible = false;
			}

			// Show
			this.Show();
        }
        #endregion
    }
}

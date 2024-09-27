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
    public partial class StaffView : Form, IStaffView
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public StaffView()
        {
            InitializeComponent();
        }

        #region private fields
        /// <summary>
        /// Instance for Staff
        /// </summary>
        private static StaffView instance;
		#endregion

		#region public fields
		/// <summary>
		/// Get Instance for Staff
		/// </summary>
		/// <param name="parentContainer">Parent Container</param>
		/// <returns>Instance</returns>
		public static StaffView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new StaffView();
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
		#endregion
	}
}

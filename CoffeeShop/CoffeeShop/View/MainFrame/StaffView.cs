﻿using CoffeeShop.View.MainFrame;
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void rdoMale_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

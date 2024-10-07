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
    public partial class CustomerView : Form, ICustomerView
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CustomerView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(tabPage2);
        }

        #region private fields
        /// <summary>
        /// Instance for Customer
        /// </summary>
        private static CustomerView instance;
		#endregion

		#region public fields
        /// <summary>
        /// Get Instance for Customer
        /// </summary>
        /// <param name="parentContainer">Parent Container</param>
        /// <returns>Instance</returns>
        public static CustomerView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            { 
                instance = new CustomerView();
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

        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;

        private void AssociateAndRaiseViewEvents()
        {

            //Add new
            btnAddNew.Click += delegate
            {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Add(tabPage2);

            };
            //Edit
            btnEdit.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Add(tabPage2);

            };


            tabControl1.Dock = DockStyle.Fill;
            this.Controls.Add(tabControl1);

            
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }
    }
   

}


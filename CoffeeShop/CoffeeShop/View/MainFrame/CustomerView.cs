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
		#region Fields

		/// <summary>
		/// Instance for Customer
		/// </summary>
		private static CustomerView instance;

		/// <summary>
		/// Check if edit
		/// </summary>
		private bool isEdit;
		
		/// <summary>
		/// Check if successful
		/// </summary>
		private bool isSuccessful;

		#endregion

		#region Properties

		/// <summary>
		/// Check if edit
		/// </summary>
		public bool IsEdit { get => isEdit; set => isEdit = value; }

		/// <summary>
		/// Check if successful
		/// </summary>
		public bool IsSuccessful { get => isSuccessful; set => isSuccessful = value; }

		#endregion

		#region Events
		public event EventHandler AddNewEvent;
		public event EventHandler EditEvent;
		public event EventHandler SearchEvent;
		public event EventHandler DeleteEvent;
		public event EventHandler SaveEvent;
		public event EventHandler ClearEvent;
		public event EventHandler BackToListEvent;
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public CustomerView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

		#region private fields

		/// <summary>
		/// Asssociate And Raise Event
		/// </summary>
		private void AssociateAndRaiseViewEvents()
		{

			//Add new
			btnAdd.Click += delegate
			{
				AddNewEvent?.Invoke(this, EventArgs.Empty);

			};

			//Edit
			btnEdit.Click += delegate
			{
				EditEvent?.Invoke(this, EventArgs.Empty);

			};

		}
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

	}
   

}


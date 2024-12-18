﻿using CoffeeShop.Model;
using CoffeeShop.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View.MainFrame
{
	public interface IStaffView
	{
        #region Fields - Properties
        string StaffID { get; set; }
		string StaffName { get; set; }
		string PhoneNumber { get; set; }
		string  DateOfBirth { get; set; }
        string Email { get; set; }
        string StaffRole { get; set; }
        bool Male { get; set; }
		bool Female { get; set; }
		bool Other { get; set; }
		Avatar Avatar { get; set; }
		string SearchValue { get; }

        bool IsEdit { get; set; }

		bool IsSuccessful { get; set; }

		bool IsOpen { get; }
        #endregion

        #region Events
        event EventHandler SearchEvent;
		event EventHandler AddNewEvent;
		event EventHandler EditEvent;
		event EventHandler DeleteEvent;
		event EventHandler SaveEvent;
		event EventHandler ClearEvent;
		event EventHandler BackToListEvent;
        #endregion

        #region Methods
        void ShowPage();
        void SetLStaffListBindingSource(BindingSource staffList);
        #endregion
    }
}

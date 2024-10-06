﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View.DialogForm
{
	public partial class EditIngredientView : Form, IEditIngredientView
	{
		public EditIngredientView()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Instance
		/// </summary>
		private static EditIngredientView instance;


		/// <summary>
		/// Get instance
		/// </summary>
		/// <returns>instance</returns>
		public static EditIngredientView GetInstance()
		{
			if (instance == null || instance.IsDisposed)
			{
				instance = new EditIngredientView();
			}
			else
			{
				if (instance.WindowState == FormWindowState.Minimized)
					instance.WindowState = FormWindowState.Normal;
				instance.BringToFront();
			}

			return instance;
		}

		#region Events
		#endregion
	}
}
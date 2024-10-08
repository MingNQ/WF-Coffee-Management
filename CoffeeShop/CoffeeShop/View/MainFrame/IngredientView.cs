using CoffeeShop.View.DialogForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View.MainFrame
{
	public partial class IngredientView : Form, IIngredientView
	{
		#region Fields
		/// <summary>
		/// Instance
		/// </summary>
		private static IngredientView instance;

		#endregion

		public IngredientView()
		{
			InitializeComponent();
			btnAdd.Click +=  delegate { ShowEditDialog?.Invoke(this, EventArgs.Empty); };
			btnEdit.Click +=  delegate { ShowEditDialog?.Invoke(this, EventArgs.Empty); };
		}

		#region public fields

		/// <summary>
		/// Get Instance
		/// </summary>
		/// <param name="parentContainer"></param>
		/// <returns>Instance</returns>
		public static IngredientView GetInstance(Form parentContainer)
		{
			if (instance == null || instance.IsDisposed)
			{
				instance = new IngredientView();
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

		#region Events
		/// <summary>
		/// Show Edit Dialog
		/// </summary>
		public event EventHandler ShowEditDialog;
		#endregion
	}
}

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
		/// <summary>
		/// Constructor
		/// </summary>
		public DashboardView()
		{
			InitializeComponent();
		}

		#region private fields
		/// <summary>
		/// Instance for Dashboard view
		/// </summary>
		private static DashboardView instance;

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
		#endregion
	}
}

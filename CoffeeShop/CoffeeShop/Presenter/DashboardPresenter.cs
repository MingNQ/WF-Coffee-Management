using CoffeeShop.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Presenter
{
	public class DashboardPresenter
	{
		#region Fields
		/// <summary>
		/// Interface Dashboard View
		/// </summary>
		private IDashboardView view;
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="view">View</param>
		public DashboardPresenter(IDashboardView view)
		{
			this.view = view;
			this.view.Show();
		}
	}
}

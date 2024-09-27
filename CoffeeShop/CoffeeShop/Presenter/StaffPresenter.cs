using CoffeeShop.View.MainFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Presenter
{
	public class StaffPresenter
	{
		#region Fields
		/// <summary>
		/// Interface Staff view
		/// </summary>
		private IStaffView staffView;
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="view">Staff view</param>
		public StaffPresenter(IStaffView view) 
		{
			this.staffView = view;

			// Display Staff view
			this.staffView.Show();
		}


	}
}

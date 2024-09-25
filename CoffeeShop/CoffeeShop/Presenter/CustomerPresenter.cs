using CoffeeShop.View.MainFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Presenter
{
	public class CustomerPresenter
	{
		#region Fiedls
		/// <summary>
		/// Customer View
		/// </summary>
		private ICustomerView customerView;
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="customerView">Customer View</param>
		public CustomerPresenter(ICustomerView customerView)
		{
			this.customerView = customerView;
			
			// Show the view
			this.customerView.Show();
		}
	}
}

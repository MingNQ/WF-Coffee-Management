using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.View
{
	public interface IMainView
	{
		#region Event
		event EventHandler ShowDashboardView;
		event EventHandler ShowPlaceOrderView;
		event EventHandler ShowCategoryView;
		event EventHandler ShowStaffView;
		event EventHandler ShowCustomerView;
		event EventHandler ShowIngredientView;
		#endregion
	}
}

using CoffeeShop.View;
using CoffeeShop.View.MainFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Presenter
{
    public class MainPresenter
    {
		#region Fields
        /// <summary>
        /// Interface Main View
        /// </summary>
		private IMainView mainView;

		#endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="view">View</param>
		public MainPresenter(IMainView view)
        {
            this.mainView = view;
            this.mainView.ShowDashboardView += ShowDashboardView;
            this.mainView.ShowStaffView += ShowStaffView;
			this.mainView.ShowCustomerView += ShowCustomerView;
			this.mainView.ShowCategoryView += ShowCategoryView;
			this.mainView.ShowIngredientView += ShowIngredientView;
        }


		#region private fields
		/// <summary>
		/// Event Show Dashboard view
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ShowDashboardView(object sender, EventArgs e)
		{
            IDashboardView view = DashboardView.GetInstance((MainView)mainView);
            new DashboardPresenter(view);
		}

		/// <summary>
		/// Event Show Staff view
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ShowStaffView(object sender, EventArgs e)
		{
			IStaffView view = StaffView.GetInstance((MainView)mainView);
			new StaffPresenter(view);
		}

		/// <summary>
		/// Event Show Customer View
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ShowCustomerView(object sender, EventArgs e)
		{
			ICustomerView view = CustomerView.GetInstance((MainView)mainView);
			new CustomerPresenter(view);
		}

		/// <summary>
		/// Event Show Ingredient View
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ShowIngredientView(object sender, EventArgs e)
		{
			IIngredientView view = IngredientView.GetInstance((MainView)mainView);
			new IngredientPresenter(view);
		}

		/// <summary>
		/// Event Show Category View
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ShowCategoryView(object sender, EventArgs e)
		{
			ICategoryView view = CategoryView.GetInstance((MainView)mainView);
			new CategoryPresenter(view);
		}
		#endregion
	}
}

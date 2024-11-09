using CoffeeShop._Repositories;
using CoffeeShop.Model.InterfaceModel;
using CoffeeShop.View;
using CoffeeShop.View.MainFrame;
using CoffeeShop.View.MainFrame.Interfaces;
using CoffeeShop.View.DialogForm;
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

		private readonly string sqlConnectionString;

		#endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="view">View</param>
		public MainPresenter(IMainView view, string sqlConnectionString)
        {
            this.mainView = view;
			this.sqlConnectionString = sqlConnectionString;
            this.mainView.ShowDashboardView += ShowDashboardView;
            this.mainView.ShowStaffView += ShowStaffView;
			this.mainView.ShowCustomerView += ShowCustomerView;
			this.mainView.ShowCategoryView += ShowCategoryView;
			this.mainView.ShowIngredientView += ShowIngredientView;
			this.mainView.ShowAccountView += ShowAccountView;
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
			IStaffRepository repository = new StaffRepository(sqlConnectionString);

			new StaffPresenter(view, repository);
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
			IEditIngredientView editIngredientView = new EditIngredientView();
            IIngredientRepository repository = new IngredientCategory(sqlConnectionString);
            new IngredientPresenter(view, repository);
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

		/// <summary>
		/// Event Show Account View
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void ShowAccountView(object sender, EventArgs e)
        {
			IAccountView view = AccountView.GetInstance((MainView)mainView);
			IAccountRepository repository = new AccountRepository(sqlConnectionString);

			new AccountPresenter(view, repository);
        }
        #endregion
    }
}

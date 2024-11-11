﻿using CoffeeShop._Repositories;
using CoffeeShop.Model.InterfaceModel;
using CoffeeShop.View;
using CoffeeShop.View.MainFrame;
using CoffeeShop.View.MainFrame.Interfaces;
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

		/// <summary>
		/// Connection String
		/// </summary>
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
			this.mainView.ShowStaffDetailInformation += ShowStaffDetailView;
			this.mainView.Show();
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
		/// <summary>
		///  Evnet Show Staff Detail View
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ShowStaffDetailView(object sender, EventArgs e)
		{
			IStaffDetailView view = StaffDetailView.GetInstance((MainView)mainView);
			IStaffRepository repository = new StaffRepository(sqlConnectionString);
			view.StaffId = mainView.StaffID;
			new StaffDetailPresenter(view,repository);
		}
        #endregion
    }
}

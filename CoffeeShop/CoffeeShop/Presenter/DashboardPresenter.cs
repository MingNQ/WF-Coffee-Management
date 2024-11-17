using CoffeeShop._Repositories.InterfaceModel;
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

		/// <summary>
		/// Repository
		/// </summary>
		private IDashboardRepository repository;
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="view">View</param>
		public DashboardPresenter(IDashboardView view, IDashboardRepository repository)
		{
			this.view = view;
			this.repository = repository;
			DisplayInformation();
            this.view.Show();
		}

        #region private fields
		
		/// <summary>
		/// Display Information
		/// </summary>
        private void DisplayInformation()
		{
			view.TotalStaff = repository.GetTotalStaff();
			view.TotalCustomer = repository.GetTotalCustomer();
			view.Income = repository.GetIncome(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
			view.TotalIncome = repository.GetIncome();
		}
        #endregion
    }
}

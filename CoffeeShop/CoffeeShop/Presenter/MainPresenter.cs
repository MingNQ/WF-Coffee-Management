using CoffeeShop.View;
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

		#endregion
	}
}

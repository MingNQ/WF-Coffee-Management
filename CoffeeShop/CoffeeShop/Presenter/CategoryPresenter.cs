using CoffeeShop.View.MainFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Presenter
{
	public class CategoryPresenter
	{
        #region Fields
        /// <summary>
        /// View
        /// </summary>		
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="view"></param>

        private ICategoryView categoryView;
		
		public CategoryPresenter(ICategoryView view)
		{
			this.categoryView = view;

			// Show Form
			this.categoryView.Show();

			//dki skien khi nhan nut View-Drink
			this.categoryView.ViewDrinkClicked += OnViewDrinkClicked;
		}

		private void OnViewDrinkClicked(object sender, EventArgs e)
		{
			this.categoryView.ShowDrinkDetails();
		}
	}
}

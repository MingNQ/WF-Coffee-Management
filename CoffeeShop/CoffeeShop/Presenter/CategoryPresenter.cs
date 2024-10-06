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
		private ICategoryView categoryView;
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="view"></param>
		public CategoryPresenter(ICategoryView view)
		{
			this.categoryView = view;

			// Show Form
			this.categoryView.Show();
		}
	}
}

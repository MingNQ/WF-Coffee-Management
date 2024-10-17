using CoffeeShop.View.DialogForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Presenter
{
	public class EditIngredientPresenter
	{
		/// <summary>
		/// View
		/// </summary>
		private IEditIngredientView editIngredientView;


		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="view">View</param>
		public EditIngredientPresenter(IEditIngredientView view)
		{
			this.editIngredientView = view;

			// Show Form
			this.editIngredientView.ShowDialog();
		}

	}
}

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
		private IEditIngredientView editIngredientView;

		public EditIngredientPresenter(IEditIngredientView view)
		{
			this.editIngredientView = view;

			// Show Form
			this.editIngredientView.Show();
		}

	}
}

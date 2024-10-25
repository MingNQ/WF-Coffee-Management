using CoffeeShop.View.DialogForm;
using CoffeeShop.View.MainFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Presenter
{
	public class IngredientPresenter
	{
		#region Fields
		/// <summary>
		/// View
		/// </summary>
		private IIngredientView ingredientView;
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="view">View</param>
		public IngredientPresenter(IIngredientView view)
		{
			this.ingredientView = view;

			if (!this.ingredientView.IsOpen)
            {
                this.ingredientView.ShowEditDialog += ShowEditDialog;
            }

            // Show form
            this.ingredientView.Show();
		}

		/// <summary>
		/// Show Edit Dialog
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ShowEditDialog(object sender, EventArgs e)
		{
			IEditIngredientView view = EditIngredientView.GetInstance();
			
			view.TittleHeader = this.ingredientView.IsEdit ? "Edit Ingredient" : "Add Ingredient";

			new EditIngredientPresenter(view);
		}
	}
}

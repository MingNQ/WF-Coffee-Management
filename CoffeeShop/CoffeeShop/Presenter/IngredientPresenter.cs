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
		private IIngredientView IngredientView;
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="view">View</param>
		public IngredientPresenter(IIngredientView view)
		{
			this.IngredientView = view;

			// Show form
			this.IngredientView.Show();

			this.IngredientView.ShowEditDialog += ShowEditDialog;
		}

		/// <summary>
		/// Show Edit Dialog
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ShowEditDialog(object sender, EventArgs e)
		{
			IEditIngredientView view = EditIngredientView.GetInstance();

			new EditIngredientPresenter(view);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.View.DialogForm
{
	public interface IEditIngredientView
	{
		string TittleHeader { get; set; }

		/// <summary>
		/// Hide Dialog
		/// </summary>
		void Hide();

		/// <summary>
		/// Show Diaglog
		/// </summary>
		void ShowDialog();
	}
}

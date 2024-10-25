using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.View.MainFrame
{
	public interface IIngredientView
	{
		/// <summary>
		/// 
		/// </summary>
		bool IsEdit { get; set; }

		/// <summary>
		/// 
		/// </summary>
		bool IsOpen { get; }

		/// <summary>
		/// Show Form
		/// </summary>
		void Show();

		#region Events
		event EventHandler ShowEditDialog;
		#endregion
	}
}

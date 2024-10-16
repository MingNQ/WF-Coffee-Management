using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.View.MainFrame
{
	public interface ICategoryView
	{
		/// <summary>
		/// Show form
		/// </summary>
		void Show();

		//them skien cho nut View-Drink
		event EventHandler ViewDrinkClicked;

		//phuong thuc de hien thi chi tiet do uong
		void ShowDrinkDetails();
	}
}

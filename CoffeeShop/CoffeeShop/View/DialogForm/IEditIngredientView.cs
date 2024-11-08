using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View.DialogForm
{
	public interface IEditIngredientView
	{
		string TittleHeader { get; set; }
		void Hide();
		void ShowDialog();

    }
}

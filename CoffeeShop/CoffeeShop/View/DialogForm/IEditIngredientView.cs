using CoffeeShop.Model;
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
        string Ingredientname { get; set; }
        string IngredientName { get; set; }

        event EventHandler SaveEvent;
        event EventHandler ClearEvent;


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

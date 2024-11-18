using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace CoffeeShop.View.MainFrame
{
	public interface IIngredientView
	{
        #region Fields - Properties
        string IngredientID { get; set; }
        string IngredientName { get; set; }
        string SearchValue { get; set;}
        bool IsSuccessful { get; set; }
        /// <summary>
        /// 
        /// </summary>
        bool IsEdit { get; set; }

		/// <summary>
		/// 
		/// </summary>
		bool IsOpen { get; }
        #endregion

        #region Events
        event EventHandler ShowEditDialog;
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;


        #endregion

        #region Methods
        /// <summary>
        /// Show Form
        /// </summary>
        void Show();
        void SetLIngredientListBindingSource(BindingSource ingredientList);
        void RoleAccess();
        #endregion
    }
}

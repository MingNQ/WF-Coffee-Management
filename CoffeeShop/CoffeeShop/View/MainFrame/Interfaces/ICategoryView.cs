using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View.MainFrame
{
	public interface ICategoryView
	{
        #region Fields
		string ItemID { get; set; }
		int CategoryID { get; set; }
		string ItemName { get; set; }
		float Cost { get; set; }

		string SearchValue { get; set; }
        bool IsEdit { get; set; }
		bool IsSuccessful { get; set; }
		string Message { get; set; }
        List<IngredientModel> ingredients { get; set; }

        #endregion
        /// <summary>
        /// Show Form
        /// </summary>
        void Show();
		void SetItemListBindingSource(BindingSource itemList);
        void LoadCategories(List<CategoryModel> categories);
        void UpdateIngredientList(List<IngredientModel> ingredients);
        List<string> GetSelectedIngredientIDs();

        #region Events
        event EventHandler ShowIngredientCheckList;

		//them skien cho nut View-Drink
		event EventHandler ViewDrinkEvent;
        event EventHandler ViewFoodEvent;

        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        event EventHandler Add_IngredientEvent;

        event EventHandler BackToListEvent;
        event EventHandler BackToCategoryEvent;
        
        #endregion
    }
}

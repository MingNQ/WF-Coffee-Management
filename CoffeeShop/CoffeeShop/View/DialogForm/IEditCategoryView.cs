using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View.DialogCheckList
{
    public interface IEditCategoryView
    {
        string TittleHeader { get; set; }
        void ShowDialog();
        void Hide();

        void SetItemListBindingSource(BindingSource itemList);
        List<IngredientModel> SelectedIngredients { get; }
        void SelectIngredientsInDataGridView(List<IngredientModel> selectedIngredients);
        event EventHandler SaveEvent;
        event EventHandler CancleEvent;
    }
}

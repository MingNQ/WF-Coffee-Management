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
        #region Fields - Properties
        List<IngredientModel> SelectedIngredients { get; }
        string TittleHeader { get; set; }
        #endregion

        #region Methods
        void ShowDialog();
        void Hide();
        void SetItemListBindingSource(BindingSource itemList);
        #endregion

        #region Events
        event EventHandler SaveEvent;
        #endregion
    }
}

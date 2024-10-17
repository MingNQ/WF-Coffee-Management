using CoffeeShop.View.DialogCheckList;
using CoffeeShop.View.MainFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Presenter
{
    public class CategoryPresenter
    {
        #region Fields
        /// <summary>
        /// View
        /// </summary>
        private ICategoryView categoryView;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="view">View</param>
        public CategoryPresenter(ICategoryView view)
        {
            this.categoryView = view;

            // Show form
            this.categoryView.Show();

            this.categoryView.ShowEditDialogCheckList += ShowEditDialogCheckList;
          
            //dki skien khi nhan nut View-Drink
            this.categoryView.ViewDrinkClicked += OnViewDrinkClicked;
        }

        /// <summary>
        /// Show Edit DialogCheckList
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowEditDialogCheckList(object sender, EventArgs e)
        {
            IEditCategoryView view = EditCategoryView.GetInstance();

            view.TittleHeader = this.categoryView.IsEdit ? "Edit Ingredient" : "Add Ingredient";

            new EditCategoryPresenter(view);
        }
      
        private void OnViewDrinkClicked(object sender, EventArgs e)
        {
          this.categoryView.ShowDrinkDetails();
        }
    }
}

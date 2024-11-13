using CoffeeShop.Model.InterfaceModel;
using CoffeeShop.Model;
using CoffeeShop.View.DialogCheckList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShop.View.MainFrame;

namespace CoffeeShop.Presenter
{
    public class EditCategoryPresenter
    {
        #region Fields
        /// <summary>
        /// 
        /// </summary>
        private ICategoryView categoryView;

        /// <summary>
        /// 
        /// </summary>
        private IEditCategoryView editCategoryView;

        /// <summary>
        /// 
        /// </summary>
        private IIngredientRepository repository;

        /// <summary>
        /// 
        /// </summary>
        private BindingSource ingredientBindingSource;

        /// <summary>
        /// 
        /// </summary>
        private IEnumerable<IngredientModel> ingredientList;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryView"></param>
        /// <param name="editCategoryView"></param>
        /// <param name="repository"></param>
        public EditCategoryPresenter(ICategoryView categoryView, IEditCategoryView editCategoryView, IIngredientRepository repository)
        {
            this.ingredientBindingSource = new BindingSource();

            this.categoryView = categoryView;
            this.editCategoryView = editCategoryView;
            this.repository = repository;
            

            this.editCategoryView.SetItemListBindingSource(ingredientBindingSource);

            this.editCategoryView.SaveEvent += SaveIngredient;
            LoadAllIngredient();


            // Show Form
            this.editCategoryView.ShowDialog();
        }

        #region private fields

        /// <summary>
        /// 
        /// </summary>
        private void LoadAllIngredient()
        {
            ingredientList = repository.GetAll();
            ingredientBindingSource.DataSource = ingredientList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveIngredient(object sender, EventArgs e)
        {
            var selectedIngredients = editCategoryView.SelectedIngredients;
            categoryView.UpdateIngredientList(selectedIngredients);

            // Dispose Event
            editCategoryView.SaveEvent -= SaveIngredient;
        }
        #endregion
    }
}

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
        private ICategoryView categoryView;
        private IEditCategoryView editCategoryView;
        private IIngredientRepository repository;
        private BindingSource ingredientBindingSource;
        private IEnumerable<IngredientModel> ingredientList;

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

        private void LoadAllIngredient()
        {
            ingredientList = repository.GetAll();
            ingredientBindingSource.DataSource = ingredientList;
        }

        

        private void SaveIngredient(object sender, EventArgs e)
        {
            var selectedIngredients = editCategoryView.SelectedIngredients;
            int selectedIngredientCount = selectedIngredients.Count;
            categoryView.UpdateIngredientList(selectedIngredients);
        }
    }
}

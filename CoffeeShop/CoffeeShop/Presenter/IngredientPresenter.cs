using CoffeeShop.View.DialogForm;
using CoffeeShop.View.MainFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CoffeeShop.Model;
using CoffeeShop.Model.InterfaceModel;
using System.Windows.Forms;
using CoffeeShop.View;

namespace CoffeeShop.Presenter
{
    public class IngredientPresenter
    {
        #region Fields
        /// <summary>
        /// View
        /// </summary>
        private IIngredientView ingredientView;

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

        /// <summary>
        /// 
        /// </summary>
        private IEditIngredientView editIngredientView;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="view">View</param>
        public IngredientPresenter(IIngredientView view, IIngredientRepository repository)
        {
            this.ingredientView = view;

            if (!this.ingredientView.IsOpen)
            {
                editIngredientView = EditIngredientView.GetInstance();
                this.ingredientView.ShowEditDialog += ShowEditDialog;

                this.ingredientBindingSource = new BindingSource();
                this.repository = repository;

                // Subcribe events
                this.ingredientView.AddNewEvent += AddNewEvent;
                this.ingredientView.EditEvent += EditEvent;
                this.ingredientView.DeleteEvent += DeleteEvent;
                this.ingredientView.SearchEvent += SearchEvent;

                this.ingredientView.SetLIngredientListBindingSource(ingredientBindingSource);

                LoadAllIngredient();
            }

            // Show form
            this.ingredientView.Show();
        }

        #region private fields

        private void LoadAllIngredient()
        {
            ingredientList = repository.GetAll();
            ingredientBindingSource.DataSource = ingredientList;
        }

        /// <summary>
        /// Add new ingredient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewEvent(object sender, EventArgs e)
        {
            ingredientView.IsEdit = false;
            editIngredientView.IngredientName = "";
        }

        /// <summary>
        /// Edit ingredient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditEvent(object sender, EventArgs e)
        {
            var ingredient = (IngredientModel)ingredientBindingSource.Current;

            ingredientView.IngredientID = ingredient.IngredientID;
            ingredientView.IngredientName = ingredient.IngredientName;
            ingredientView.IsEdit = true;

            editIngredientView.IngredientName = ingredient.IngredientName;
        }

        /// <summary>
        /// Search Ingredient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchEvent(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.ingredientView.SearchValue);

            if (!emptyValue)
            {
                ingredientList = repository.GetByValue(this.ingredientView.SearchValue);
            }
            else
            {
                ingredientList = repository.GetAll();
            }
            ingredientBindingSource.DataSource = ingredientList;
        }

        /// <summary>
        /// Delete ingredient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteEvent(object sender, EventArgs e)
        {
            try
            {
                var ingredient = (IngredientModel)ingredientBindingSource.Current;
                repository.Delete(ingredient.IngredientID);
                ingredientView.IsSuccessful = true;
                LoadAllIngredient();
                MessageBox.Show("Successul delete ingredient", "Notify", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch
            {
                ingredientView.IsSuccessful = false;

                MessageBox.Show("An error occured, could not delete this ingredient!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Show Edit Dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowEditDialog(object sender, EventArgs e)
        {
            editIngredientView.TittleHeader = this.ingredientView.IsEdit ? "Edit Ingredient" : "Add Ingredient";

            new EditIngredientPresenter(editIngredientView, ingredientView, repository);
            LoadAllIngredient();
        }

        #endregion
    }
}
using CoffeeShop.Model;
using CoffeeShop.Model.InterfaceModel;
using CoffeeShop.View.MainFrame;
using CoffeeShop.View.DialogForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using CoffeeShop.View.DialogCheckList;
using CoffeeShop.View;

namespace CoffeeShop.Presenter
{
    public class EditIngredientPresenter
    {
        #region Fields
     
        /// <summary>
        /// View
        /// </summary>
        private IEditIngredientView editIngredientView;

        /// <summary>
        /// 
        /// </summary>
        private IIngredientView ingredientView;

        /// <summary>
        /// 
        /// </summary>
        private IIngredientRepository repository;

        /// <summary>
        /// 
        /// </summary>
        private IEnumerable<IngredientModel> ingredientList;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="view">View</param>
        public EditIngredientPresenter(IEditIngredientView view, IIngredientView ingredientView, IIngredientRepository repository)
        {
            this.editIngredientView = view;
            this.ingredientView = ingredientView;
            this.repository = repository;

            this.editIngredientView.SaveEvent += SaveEvent;
            this.editIngredientView.ClearEvent += ClearEvent;
            this.editIngredientView.CloseEvent += CloseEvent;

            ingredientList = repository.GetAll();

            // Show Form
            this.editIngredientView.ShowDialog();
        }

        #region private fields

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearEvent(object sender, EventArgs e)
        {
            editIngredientView.IngredientName = "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveEvent(object sender, EventArgs e)
        {
            var ingredient = new IngredientModel();

            try
            {
                ingredient.IngredientID = ingredientView.IngredientID;
                ingredient.IngredientName = editIngredientView.IngredientName;
                new Common.ModelValidation().Validate(ingredient);

                if (ingredientView.IsEdit) // Edit model
                {
                    repository.Edit(ingredient);
                }
                else // Add new model
                {
                    // Generate ID
                    int id = Convert.ToInt32(ingredientList.Last().IngredientID.Substring(3)) + 1;
                    ingredient.IngredientID = "ING" + id.ToString("D3");

                    repository.Add(ingredient);
                }

                ingredientView.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                ingredientView.IsSuccessful = false;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Close event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseEvent(object sender, EventArgs e)
        {
            // Dispose Events
            editIngredientView.SaveEvent -= SaveEvent;
            editIngredientView.ClearEvent -= ClearEvent;
            editIngredientView.CloseEvent -= CloseEvent;
            editIngredientView.Close();
        }
        #endregion
    }
}
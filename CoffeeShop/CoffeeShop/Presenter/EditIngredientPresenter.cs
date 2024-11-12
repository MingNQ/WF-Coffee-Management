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
		/// <summary>
		/// View
		/// </summary>
		private IEditIngredientView editIngredientView;

        private IIngredientView ingredientView;

        private IIngredientRepository repository;

		private IEnumerable<IngredientModel> ingredientList;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="view">View</param>
        public EditIngredientPresenter(IEditIngredientView view,IIngredientView ingredientView, IIngredientRepository repository)
		{
			this.editIngredientView = view;
			this.ingredientView = ingredientView;
			this.repository = repository;

            this.editIngredientView.SaveEvent += SaveEvent;
            this.editIngredientView.ClearEvent += ClearEvent;

            ingredientList = repository.GetAll();

            // Show Form
            this.editIngredientView.ShowDialog();
		}

       private void ClearEvent(object sender, EventArgs e)
        {
            editIngredientView.IngredientName = "";
        }

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

    }
}

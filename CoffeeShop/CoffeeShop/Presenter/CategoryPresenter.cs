using CoffeeShop._Repositories;
using CoffeeShop.Model;
using CoffeeShop.Model.InterfaceModel;
using CoffeeShop.View.DialogCheckList;
using CoffeeShop.View.MainFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.Presenter
{
	public class CategoryPresenter
	{
		#region Fields
		/// <summary>
		/// View
		/// </summary>
		private ICategoryView categoryView;
        private IEditCategoryView editCategoryView;
		private ICategoryRepository repository;
        private IIngredientRepository ingredientRepository;
		private BindingSource itemsBindingSource;
		private IEnumerable<ItemModel> itemList;
        private enum ItemType { Drink, Food}
        private ItemType currentItemType;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="view">View</param>
        public CategoryPresenter(ICategoryView view, ICategoryRepository repository, IEditCategoryView editCategoryView, IIngredientRepository ingredientRepository)
		{
			this.itemsBindingSource = new BindingSource();

			this.categoryView = view;
            this.editCategoryView = editCategoryView;
			this.repository = repository;
            this.ingredientRepository = ingredientRepository;

            //Subscribe event handler methods to view events
            this.categoryView.ViewDrinkEvent += ViewDrink;
            this.categoryView.ViewFoodEvent += ViewFood;

			this.categoryView.SearchEvent += SearchItem;
            this.categoryView.AddNewEvent += AddNewItem;
            this.categoryView.EditEvent += LoadSelectedItemToEdit;
            this.categoryView.DeleteEvent += DeleteSelectedItem;

            this.categoryView.SaveEvent += SaveItem;
            this.categoryView.CancelEvent += CancelAction;

            this.categoryView.Add_IngredientEvent += AddIngredient;
            //Set items bindind source
            this.categoryView.SetItemListBindingSource(itemsBindingSource);
            
            // Show form
            this.categoryView.Show();

			this.categoryView.ShowIngredientCheckList += ShowIngredientCheckList;

		}

        private void AddIngredient(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ViewFood(object sender, EventArgs e)
        {
            currentItemType = ItemType.Food;
            LoadAllFoodList();
            LoadCategoryData();
        }

        private void ViewDrink(object sender, EventArgs e)
        {
            currentItemType = ItemType.Drink;
            LoadAllDrinkList();
            LoadCategoryData();
        }

        //Methods
        private void LoadAllFoodList()
        {
            itemList = repository.GetAllFoods();
            itemsBindingSource.DataSource = itemList;
        }

        private void LoadAllDrinkList()
        {
            itemList = repository.GetAllDrink();
            itemsBindingSource.DataSource = itemList;
        }
        public void LoadCategoryData()
        {
            var categories = new List<CategoryModel>();
            if (currentItemType == ItemType.Drink) {
                categories = repository.GetAllCategories(isDrink:true);       
            }
            else if(currentItemType == ItemType.Food)
            {
                categories = repository.GetAllCategories(isDrink: false);         
            }
            categoryView.LoadCategories(categories);
        }

        private void SearchItem(object sender, EventArgs e)
        {
            string searchValue = this.categoryView.SearchValue;
            if (!string.IsNullOrEmpty(searchValue))
            {
                if (currentItemType == ItemType.Drink)
                {
                    itemList = repository.GetByValue(searchValue, isDrink: true);
                }
                else if (currentItemType == ItemType.Food)
                {
                    itemList = repository.GetByValue(searchValue, isDrink: false);
                }
            }
            else
            {
                if (currentItemType == ItemType.Drink)
                {
                    itemList = repository.GetAllDrink();
                }
                else if (currentItemType == ItemType.Food)
                {
                    itemList = repository.GetAllFoods();
                }
            }
            itemsBindingSource.DataSource = itemList;
        }
        private void CleanviewFields()
        {
            categoryView.ItemID = "";
            categoryView.CategoryID = 1;
            categoryView.ItemName = "";
            categoryView.Cost = 0;

        }
        private void CancelAction(object sender, EventArgs e)
        {
            CleanviewFields();
        }

        private void SaveItem(object sender, EventArgs e)
        {
            var ingredientIDs = categoryView.GetSelectedIngredientIDs();
            var model = new ItemModel();           
            model.CategoryID = categoryView.CategoryID;
            model.ItemName = categoryView.ItemName;
            model.Cost = categoryView.Cost;

            try
            {
                new Common.ModelValidation().Validate(model);
                if (categoryView.IsEdit)
                {
                    model.ItemID = categoryView.ItemID;
                    var ItemIngredientIDs = repository.GetItemIngredients(model.ItemID);
                    var currentIngredientList = repository.GetIngredientsByItemID(model.ItemID);
                    var newIngredientList = categoryView.ingredients;
                    int currentNumber = currentIngredientList.Count();
                    int newNumber = newIngredientList.Count();
                    repository.EditItemIngredients(model.ItemID, ItemIngredientIDs, newIngredientList);
                    repository.Edit(model);
                    categoryView.Message = "Item edited successfully";
                }
                else
                {
                    model.ItemID = repository.GetItemID();
                    repository.Add(model);
                    repository.AddItemIngredients(model.ItemID, ingredientIDs);                  
                    categoryView.Message = "Item added successfully";
                }
                categoryView.IsSuccessful = true;
                if(currentItemType == ItemType.Food)
                {
                    LoadAllFoodList();
                    CleanviewFields();
                }
                else
                {
                    LoadAllDrinkList();
                    CleanviewFields();
                }


            }catch(Exception ex)
            {
                categoryView.IsSuccessful = false;
                categoryView.Message = ex.Message;
            }
        }
       

        private void DeleteSelectedItem(object sender, EventArgs e)
        {
            try
            {
                var ingredientIDs = categoryView.GetSelectedIngredientIDs();
                var item = (ItemModel)itemsBindingSource.Current;
                repository.DeleteItemIngredients(item.ItemID);
                repository.Delete(item.ItemID);
                categoryView.IsSuccessful = true;
                categoryView.Message = "Item deleted successfully";
                if (currentItemType == ItemType.Food)
                {
                    LoadAllFoodList();
                }
                else
                {
                    LoadAllDrinkList();
                }
            }catch(Exception ex)
            {
                categoryView.IsSuccessful = false;
                categoryView.Message = "An error ocurred, could not delete item";
            }
        }

        private void LoadSelectedItemToEdit(object sender, EventArgs e)
        {
            var item = (ItemModel)itemsBindingSource.Current;
            categoryView.ItemID = item.ItemID.ToString();
            categoryView.CategoryID = int.Parse(item.CategoryID.ToString());
            categoryView.ItemName = item.ItemName;
            categoryView.Cost = item.Cost;
            categoryView.UpdateIngredientList(repository.GetIngredientsByItemID(item.ItemID.ToString()));
            categoryView.IsEdit = true;
        }

        private void AddNewItem(object sender, EventArgs e)
        {
            categoryView.IsEdit = false;
            categoryView.ItemID = repository.GetItemID();
        }
        private void ShowIngredientCheckList(object sender, EventArgs e)
		{
			editCategoryView = EditCategoryView.GetInstance();
			editCategoryView.TittleHeader = this.categoryView.IsEdit ? "Edit Ingredient" : "Add Ingredient";      
			new EditCategoryPresenter(categoryView,editCategoryView, ingredientRepository);            
		}
	}
}

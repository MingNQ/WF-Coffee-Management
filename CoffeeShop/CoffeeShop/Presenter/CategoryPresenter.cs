using CoffeeShop._Repositories;
using CoffeeShop.Model;
using CoffeeShop.Model.InterfaceModel;
using CoffeeShop.View;
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

        /// <summary>
        /// 
        /// </summary>
        private IEditCategoryView editCategoryView;

        /// <summary>
        /// 
        /// </summary>
        private ICategoryRepository repository;

        /// <summary>
        /// 
        /// </summary>
        private IIngredientRepository ingredientRepository;

        /// <summary>
        /// 
        /// </summary>
        private BindingSource itemsBindingSource;

        /// <summary>
        /// 
        /// </summary>
        private IEnumerable<ItemModel> itemList;

        /// <summary>
        /// 
        /// </summary>
        private enum ItemType { Drink, Food }

        /// <summary>
        /// 
        /// </summary>
        private ItemType currentItemType;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="view">View</param>
        public CategoryPresenter(ICategoryView view, ICategoryRepository repository, IEditCategoryView editCategoryView, IIngredientRepository ingredientRepository)
        {

            this.categoryView = view;
            this.editCategoryView = editCategoryView;
            this.repository = repository;
            this.ingredientRepository = ingredientRepository;

            if (!categoryView.IsOpen)
            {
                this.itemsBindingSource = new BindingSource();

                //Subscribe event handler methods to view events
                this.categoryView.ViewDrinkEvent += ViewDrink;
                this.categoryView.ViewFoodEvent += ViewFood;
                this.categoryView.SearchEvent += SearchItem;
                this.categoryView.AddNewEvent += AddNewItem;
                this.categoryView.EditEvent += LoadSelectedItemToEdit;
                this.categoryView.DeleteEvent += DeleteSelectedItem;
                this.categoryView.BackEvent += BackToList;
                this.categoryView.SaveEvent += SaveItem;
                this.categoryView.CancelEvent += CancelAction;
                this.categoryView.ShowIngredientCheckList += ShowIngredientCheckList;
            }

            //Set items bindind source
            this.categoryView.SetItemListBindingSource(itemsBindingSource);
            // Show form
            this.categoryView.ShowPage();
        }

        #region private fields

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewFood(object sender, EventArgs e)
        {
            currentItemType = ItemType.Food;
            LoadAllFoodList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewDrink(object sender, EventArgs e)
        {
            currentItemType = ItemType.Drink;
            LoadAllDrinkList();
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadAllFoodList()
        {
            itemList = repository.GetAllFoods();
            itemsBindingSource.DataSource = itemList;
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadAllDrinkList()
        {
            itemList = repository.GetAllDrink();
            itemsBindingSource.DataSource = itemList;
        }

        /// <summary>
        /// 
        /// </summary>
        public void LoadCategoryData()
        {
            var categories = new List<CategoryModel>();
            if (currentItemType == ItemType.Drink)
            {
                categories = repository.GetAllCategories(isDrink: true);
            }
            else if (currentItemType == ItemType.Food)
            {
                categories = repository.GetAllCategories(isDrink: false);
            }
            categoryView.LoadCategories(categories);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 
        /// </summary>
        private void CleanViewFields()
        {
            categoryView.ItemID = "";
            categoryView.CategoryID = 1;
            categoryView.ItemName = "";
            categoryView.Cost = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelAction(object sender, EventArgs e)
        {
            CleanViewFields();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackToList(object sender, EventArgs e)
        {
            CleanViewFields();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    var newIngredientList = categoryView.Ingredients;
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
                if (currentItemType == ItemType.Food)
                {
                    LoadAllFoodList();
                    CleanViewFields();
                }
                else
                {
                    LoadAllDrinkList();
                    CleanViewFields();
                }
            }
            catch (Exception ex)
            {
                categoryView.IsSuccessful = false;
                categoryView.Message = ex.Message;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteSelectedItem(object sender, EventArgs e)
        {
            try
            {
                //var ingredientIDs = categoryView.GetSelectedIngredientIDs();
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
            }
            catch
            {
                categoryView.IsSuccessful = false;
                categoryView.Message = "An error ocurred, could not delete item";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadSelectedItemToEdit(object sender, EventArgs e)
        {
            var item = (ItemModel)itemsBindingSource.Current;
            categoryView.ItemID = item.ItemID.ToString();
            categoryView.CategoryID = item.CategoryID;
            categoryView.ItemName = item.ItemName;
            categoryView.Cost = item.Cost;
            categoryView.UpdateIngredientList(repository.GetIngredientsByItemID(item.ItemID.ToString()));
            categoryView.IsEdit = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewItem(object sender, EventArgs e)
        {
            LoadCategoryData();
            categoryView.IsEdit = false;
            categoryView.ItemID = repository.GetItemID();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowIngredientCheckList(object sender, EventArgs e)
        {
            editCategoryView = EditCategoryView.GetInstance();
            editCategoryView.TittleHeader = this.categoryView.IsEdit ? "Edit Ingredient" : "Add Ingredient";
            new EditCategoryPresenter(categoryView, editCategoryView, ingredientRepository);
        }

        #endregion
    }
}

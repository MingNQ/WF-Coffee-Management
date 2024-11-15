using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model.InterfaceModel
{
    public interface ICategoryRepository
    {
        void Add(ItemModel itemModel);
        void Edit(ItemModel itemModel);
        void Delete(string itemID);
        void AddItemIngredients(string itemID, List<string> ingredientIDs);
        void EditItemIngredients(string itemID, List<string> itemIngredientIDs, List<IngredientModel> newIngredientList);
        void DeleteItemIngredients(string itemID);

        IEnumerable<CategoryModel> GetAll();
        IEnumerable<ItemModel> GetAllItems();
        IEnumerable<ItemModel> GetAllFoods();
        IEnumerable<ItemModel> GetAllDrink();
        IEnumerable<ItemModel> GetByValue(string value, bool isDrink);
        List<CategoryModel> GetAllCategories(bool isDrink);
        List<IngredientModel> GetIngredientsByItemID(string itemID);
        List<string> GetItemIngredients(string itemID);
        string GetItemID();

    }
}

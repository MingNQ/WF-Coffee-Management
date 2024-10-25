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
        IEnumerable<ItemModel> GetAllFoods();
        IEnumerable<ItemModel> GetAllDrink();
        IEnumerable<ItemModel> GetByValue(string value);
    }
}

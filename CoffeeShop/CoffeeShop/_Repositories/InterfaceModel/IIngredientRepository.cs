using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model.InterfaceModel
{
    public interface IIngredientRepository
    {
        void Add(IngredientModel ingredientModel);
        void Edit(IngredientModel ingredientModel);
        void Delete(string ingredientID);
        IEnumerable<IngredientModel> GetAll();
        IEnumerable<IngredientModel> GetByValue(string value);
    }
}

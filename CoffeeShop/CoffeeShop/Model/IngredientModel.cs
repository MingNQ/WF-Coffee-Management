using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    public class IngredientModel
    {
        private string ingredientID;
        private string ingredientName;
        public string IngredientID { get => ingredientID; set => ingredientID = value; }
        public string IngredientName { get => ingredientName; set => ingredientName = value; }
    }
}

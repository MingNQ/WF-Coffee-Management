using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    public class Item
    {
        public string ItemID {  get; set; }
        public string ItemName { get; set; }

        public int CategoryID {  get; set; }

        public string ImagePath {  get; set; }

        public double Cost {  get; set; }
      

        public Item(string itemID, string itemName, int categoryID, string imagePath, double cost)
        {
            ItemID = itemID;
            ItemName = itemName;
            CategoryID = categoryID;
            ImagePath = imagePath;
            Cost = cost;
        }
    }
}

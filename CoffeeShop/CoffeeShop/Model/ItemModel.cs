using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    public class ItemModel
    {
        #region Fields
        private string itemID;
        private int categoryID;
        private string itemName;
        private float cost;
        #endregion

        #region Properties
        [DisplayName("ItemID")]
        public string ItemID { get => itemID; set => itemID = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }

        [DisplayName("Item Name")]
        [Required(ErrorMessage = "Item name is required")]
        //[RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can't contain number or special characters")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Item name must be between 5 and 100 characters")]
        public string ItemName { get => itemName; set => itemName = value; }

        [DisplayName("Cost")]
        [Required(ErrorMessage = "Cost is required")]
        [Range(0, float.MaxValue, ErrorMessage = "Cost must be a positive number")]
        public float Cost { get => cost; set => cost = value; }
        #endregion

        #region Navigation
        public virtual CategoryModel Category { get; set; }
        #endregion
    }
}

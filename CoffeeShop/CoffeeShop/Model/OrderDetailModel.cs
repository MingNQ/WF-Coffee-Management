using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.View
{
    public class OrderDetailModel
    {
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public string OrderDetailID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OrderID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string ItemID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int Quantity { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public float Total {  get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public float UnitPrice
        {
            get
            {
                return Item != null ? Item.Cost : 0;
            }
            set
            {
                Item.Cost = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ItemName
        {
            get
            {
                return Item != null ? Item.ItemName : "";
            }
            set
            {
                Item.ItemName = value;
            }
        }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public OrderDetailModel()
        {
            Order = new OrderModel();
            Item = new ItemModel();
        }

        #region Navigation
        public virtual OrderModel Order { get; set; }
        public virtual ItemModel Item { get; set; }
        #endregion
    }
}

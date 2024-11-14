using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    public class TableOrder
    {
        /// <summary>
        /// 
        /// </summary>
        public TableOrder()
        {
            Floor = new Floor();
        }

        /// <summary>
        /// 
        /// </summary>
        public string TableID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int Capacity { get; set; }

        // Navigation
        public virtual Floor Floor { get; set; }
    }
}

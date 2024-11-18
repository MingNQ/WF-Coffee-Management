using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    public class Floor
    {
        /// <summary>
        /// 
        /// </summary>
        public Floor() 
        {
            Tables = new List<TableOrder>();
        }

        /// <summary>
        /// 
        /// </summary>
        public string FloorId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int FloorNumber { get; set;}
        
        // Navigation
        public virtual IEnumerable<TableOrder> Tables { get; set; }
    }
}

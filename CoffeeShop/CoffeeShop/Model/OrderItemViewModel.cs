using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    public class OrderItemViewModel
    {
        public string ItemName {  get; set; }
        public int Quantity { get; set; }

        public float Cost {  get; set; }
        public float Total {  get; set; }

    }
}

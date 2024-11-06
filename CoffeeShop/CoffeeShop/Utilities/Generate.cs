using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Utilities
{
    public static class Generate
    {
        public static string GenerateID(string _base)
        {
            string id = "";

            switch (_base)
            {
                case "KH":
                case "NV":
                    id = _base + new Random().Next(1000).ToString("D3");
                    break;
            }

            return id;
        }
    }
}

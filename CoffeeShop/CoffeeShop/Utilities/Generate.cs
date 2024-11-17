using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Utilities
{
    public class Generate
    {
        /// <summary>
        /// Store Global Staff ID
        /// </summary>
        public static string StaffID = "";

        /// <summary>
        /// Store Global Staff Name
        /// </summary>
        public static string StaffName = "";

        /// <summary>
        /// Store Global Staff Role
        /// </summary>
        public static string StaffRole = "";

        /// <summary>
        /// Generate ID
        /// </summary>
        /// <param name="_base"></param>
        /// <returns></returns>
        public static string GenerateID(string _base)
        {
            string id = "";

            switch (_base)
            {
                case "OD":
                    id = _base + new Random().Next(100000).ToString("D5");
                    break;
                case "O":
                case "AVT":
                case "KH":
                case "NV":
                    id = _base + new Random().Next(1000).ToString("D3");
                    break;
            }

            return id;
        }
    }
}

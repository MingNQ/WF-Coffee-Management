using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    public class Account
    {
        public string AccountID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string StaffID { get; set; }
        public bool Active { get; set; }

        // Navigation
        public virtual StaffModel Staff { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    public class Account
    {
        #region Fields

        /// <summary>
        /// username field
        /// </summary>
        private string username;

        /// <summary>
        /// password field
        /// </summary>
        private string password;

        #endregion

        #region Properties
        
        /// <summary>
        /// Username
        /// </summary>
        public string Username { get { return username; } set { username = value; } }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get { return password; } set { password = value; } }

        #endregion
    }
}

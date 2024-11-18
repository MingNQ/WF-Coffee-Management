using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    public class Avatar
    {
        #region Properties
        /// <summary>
        /// ID
        /// </summary>
        public string AvatarID { get; set; }

        /// <summary>
        /// Staff ID
        /// </summary>
        public string StaffID { get; set; }
        
        /// <summary>
        /// Image File
        /// </summary>
        public string ImageUrl { get; set; }
        
        /// <summary>
        /// Model Navigation
        /// </summary>
        public virtual StaffModel Staff { get; set; }

        #endregion
    }
}

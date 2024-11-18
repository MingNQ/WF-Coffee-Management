using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    public class PaymentModel
    {
        #region Fields
        private string paymentID;
        private string paymentMethod;
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public string PaymentID 
        { 
            get { return paymentID; }
            set { paymentID = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public string PaymentMethod 
        {
            get { return paymentMethod; }
            set { paymentMethod = value; }
        }
        #endregion
    }
}

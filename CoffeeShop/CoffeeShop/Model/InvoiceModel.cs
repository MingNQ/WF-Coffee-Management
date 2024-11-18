using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    public class InvoiceModel
    {
        #region Field
        /// <summary>
        /// 
        /// </summary>
        private string invoiceID;
        /// <summary>
        /// 
        /// </summary>
        private string customerID;
        /// <summary>
        /// 
        /// </summary>
        private string paymentID;
        /// <summary>
        /// 
        /// </summary>
        private DateTime saleDate;
        /// <summary>
        /// 
        /// </summary>
        private string orderID;
        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public string InvoiceID
        {
            get { return invoiceID; }
            set { invoiceID = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomerID 
        { 
            get { return customerID; } 
            set { customerID = value; } 
        }
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
        public DateTime SaleDate
        {
            get { return saleDate; }

            set { saleDate = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public InvoiceModel()
        {
            Payment = new PaymentModel();
        }

        #region Navigation

        /// <summary>
        /// Navigation
        /// </summary>
        public virtual PaymentModel Payment { get; set; }
        #endregion
    }
}

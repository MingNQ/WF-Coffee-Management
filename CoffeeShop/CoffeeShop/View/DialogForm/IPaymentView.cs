using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View.DialogForm
{
    public interface IPaymentView
    {
        #region Fields - Properties

        /// <summary>
        /// 
        /// </summary>
        string CustomerID { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        string CustomerName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string CustomerPhone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string InvoiceID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        bool IsOpen { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string PaymentMethod { get; set; }

        #endregion

        #region Events
        event EventHandler SearchEvent;
        #endregion

        #region Methods
        void ShowDialog();
        void SetListBindingSource(BindingSource bindingSource);
        #endregion
    }
}

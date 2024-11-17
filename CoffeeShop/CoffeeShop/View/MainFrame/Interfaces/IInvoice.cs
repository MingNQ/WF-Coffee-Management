using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.View.MainFrame.Interfaces
{
    public interface IInvoice
    {
       
        #region Event
        event EventHandler PrintEvent;
        event EventHandler CancelEvent;

        #endregion
        #region Public Method
        #endregion
    }
}

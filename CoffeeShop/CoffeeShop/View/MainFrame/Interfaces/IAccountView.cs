using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View.MainFrame.Interfaces
{
    public interface IAccountView
    {
        #region Fields - Properties
        bool IsOpen { get; }
        string SearchValue { get; set; }
        #endregion

        #region Events
        event EventHandler SearchEvent;
        event EventHandler DeleteEvent;
        event EventHandler ActiveEvent;
        event EventHandler DisableEvent;
        #endregion

        #region Methods
        /// <summary>
        /// Show Form
        /// </summary>
        void Show();
        /// <summary>
        /// Set binding source
        /// </summary>
        /// <param name="source"></param>
        void SetAccountListBindingSource(BindingSource source);
        #endregion
    }
}

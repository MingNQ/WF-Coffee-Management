using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.View.MainFrame
{
    public interface ICategoryView
    {

        bool IsEdit { get; set; }

        /// <summary>
        /// Show Form
        /// </summary>
        void Show();

        #region Events
        event EventHandler ShowEditDialogCheckList;
        #endregion
    }
}

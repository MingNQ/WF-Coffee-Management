using CoffeeShop.View.MainFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Presenter
{
    internal class MenuOrderPresenter
    {
        #region Fiedls
        /// <summary>
        /// Menu Order View
        /// </summary>
        private IMenuOrderView menuOrderView;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="menuOrderView">Customer View</param>
        /// 

        public MenuOrderPresenter(IMenuOrderView view)
        {
            this.menuOrderView = view;

            // Show the view
            this.menuOrderView.Show();
        }
    }
}

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
        //phuong thuc de hien thi chi tiet do uong
        void ShowDrinkDetails();

        #region Events
        event EventHandler ShowEditDialogCheckList;
        //them skien cho nut View-Drink
        event EventHandler ViewDrinkClicked;
        #endregion
    }
}

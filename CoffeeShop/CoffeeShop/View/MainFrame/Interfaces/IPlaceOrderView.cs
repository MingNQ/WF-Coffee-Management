using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.View.MainFrame
{
	public interface IPlaceOrderView
	{
        #region Fields - Properties

        /// <summary>
        /// Floor Number
        /// </summary>
        int FloorNo { get; set; }

        /// <summary>
        /// Form Is Open
        /// </summary>
        bool IsOpen { get; }

        #endregion

        #region Events
        event EventHandler DisplayPage;
        event EventHandler DisplayPreviousPage;
        event EventHandler DisplayNextPage;
        event EventHandler OrderEvent;
        #endregion

        #region Methods
        /// <summary>
        /// Show Form
        /// </summary>
        void Show();

        /// <summary>
        /// Update Table View
        /// </summary>
        /// <param name="floor"></param>
        void UpdateTableView(IEnumerable<TableOrder> floor);
        #endregion
    }
}

using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View.MainFrame
{
	public interface IPlaceOrderView
	{
        #region Fields - Properties

        /// <summary>
        /// Edit or Add 
        /// </summary>
        bool IsEdit { get; set; }

        /// <summary>
        /// Successful 
        /// </summary>
        bool IsSuccessful { get; set; }

        /// <summary>
        /// Floor Number
        /// </summary>
        int FloorNo { get; set; }

        /// <summary>
        /// Form Is Open
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        /// 
        /// </summary>
        string TableNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string StaffName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string OrderID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string ItemID { get; }

        /// <summary>
        /// 
        /// </summary>
        string ItemName { get; }

        /// <summary>
        /// 
        /// </summary>
        int Quantity { get; }

        /// <summary>
        /// 
        /// </summary>
        float Price { get; }

        /// <summary>
        /// 
        /// </summary>
        float Total { get; }

        /// <summary>
        /// 
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        int NumberPeople { get; set; }
        string ReduceQuantity { get; }

        #endregion

        #region Events
        event EventHandler DisplayPage;
        event EventHandler DisplayPreviousPage;
        event EventHandler DisplayNextPage;
        event EventHandler OrderEvent;
        event EventHandler SelectedCategoryChangeEvent;
        event EventHandler SelectedItemChangeEvent;
        event EventHandler AddToCartEvent;
        event EventHandler RemoveEvent;
        event EventHandler RemoveAllEvent;
        event EventHandler ReduceEvent;
        event EventHandler CompleteOrderEvent;
        event EventHandler PayEvent;
        event EventHandler PrintEvent;
        event EventHandler BackEvent;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categories"></param>
        void GetListCategoy(IEnumerable<CategoryModel> categories);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        void GetListItem(IEnumerable<ItemModel> items);

        /// <summary>
        /// 
        /// </summary>
        void UpdatePrice(IEnumerable<ItemModel> items);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderdDetail"></param>
        void SetListBindingSource(BindingSource orderDetail);

        /// <summary>
        /// 
        /// </summary>
        void CalculateGrandTotal(List<OrderDetailModel> orderDetails);

        #endregion
    }
}

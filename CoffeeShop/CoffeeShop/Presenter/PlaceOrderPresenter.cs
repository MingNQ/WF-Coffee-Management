using CoffeeShop._Repositories.InterfaceModel;
using CoffeeShop.Model;
using CoffeeShop.Model.InterfaceModel;
using CoffeeShop.Utilities;
using CoffeeShop.View;
using CoffeeShop.View.DialogForm;
using CoffeeShop.View.MainFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.Presenter
{
    public class PlaceOrderPresenter
    {
        #region Fields
        
        /// <summary>
        /// View
        /// </summary>
        private IPlaceOrderView view;

        /// <summary>
        /// Repository
        /// </summary>
        private IPlaceOrderRepository repository;

        /// <summary>
        /// Category
        /// </summary>
        private ICategoryRepository category;

        /// <summary>
        /// Binding Source
        /// </summary>
        private BindingSource bindingSource;

        /// <summary>
        /// Number table in floor
        /// </summary>
        private IEnumerable<TableOrder> floor;

        /// <summary>
        /// Floors
        /// </summary>
        private IEnumerable<Floor> floors;

        /// <summary>
        /// 
        /// </summary>
        private List<OrderDetailModel> orderDetails = new List<OrderDetailModel>();

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_view"></param>
        /// <param name="_repository"></param>
        public PlaceOrderPresenter(IPlaceOrderView _view, IPlaceOrderRepository _repository, ICategoryRepository _category)
        {
            view = _view;

            // If not open  
            if (!view.IsOpen)
            {
                repository = _repository;
                category = _category;
                bindingSource = new BindingSource();

                view.FloorNo = 1;
                view.DisplayPage += DisplayPageEvent;
                view.DisplayPreviousPage += DisplayPreviousPageEvent;
                view.DisplayNextPage += DisplayNextPageEvent;
                view.OrderEvent += OrderEvent;
                view.SelectedCategoryChangeEvent += SelectedCategoryChangeEvent;
                view.SelectedItemChangeEvent += SelectedItemChangeEvent;
                view.AddToCartEvent += AddToCartEvent;
                view.RemoveEvent += RemoveEvent;
                view.SetListBindingSource(bindingSource);

                floors = repository.GetAllFloor();
            }

            // Show Form;
            view.Show();
        }

        #region private fields

        /// <summary>
        /// Display Next Page Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayNextPageEvent(object sender, EventArgs e)
        {
            if (view.FloorNo < floors.Count())
            {
                view.FloorNo++;
                floor = repository.GetTablesByFloor(CurrFloor(view.FloorNo));
                view.UpdateTableView(floor);
            }
        }

        /// <summary>
        /// Displaye Previous Page Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayPreviousPageEvent(object sender, EventArgs e)
        {
            if (view.FloorNo > 1)
            {
                view.FloorNo--;
                floor = repository.GetTablesByFloor(CurrFloor(view.FloorNo));
                view.UpdateTableView(floor);
            }
        }

        /// <summary>
        /// DisplAy Page Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayPageEvent(object sender, EventArgs e)
        {
            floor = repository.GetTablesByFloor(CurrFloor(view.FloorNo));
            view.UpdateTableView(floor);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderEvent(object sender, EventArgs e)
        {
            view.SelectedCategoryChangeEvent -= SelectedCategoryChangeEvent;
            view.SelectedItemChangeEvent -= SelectedItemChangeEvent;

            view.GetListCategoy(category.GetAll());
            view.GetListItem(category.GetAllItems());
            view.UpdatePrice(category.GetAllItems());

            view.SelectedCategoryChangeEvent += SelectedCategoryChangeEvent;
            view.SelectedItemChangeEvent += SelectedItemChangeEvent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedCategoryChangeEvent(object sender, EventArgs e)
        {
            view.GetListItem(category.GetAllItems());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedItemChangeEvent(object sender, EventArgs e)
        {
            view.UpdatePrice(category.GetAllItems());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddToCartEvent(object sender, EventArgs e)
        {
            var orderDetail = new OrderDetailModel()
            {
                OrderDetailID = Generate.GenerateID("OD"),
                OrderID = view.OrderID,
                ItemID = view.ItemID,
                Item = new ItemModel()
                {
                    ItemID = view.ItemID,
                    ItemName = view.ItemName,
                    Cost = view.Price
                },
                Quantity = view.Quantity,
                Total = view.Total,
                Description = view.Description,
            };

            // If Exist Add Quantity and Total
            bool isExit = false;
            orderDetails.ForEach(order =>
            {
                if (order.Item.ItemName == orderDetail.Item.ItemName)
                {
                    order.Quantity += orderDetail.Quantity;
                    order.Total += orderDetail.Total;
                    isExit = true;
                }
            });

            // If not exist add new
            if (!isExit)
            {
                orderDetails.Add(orderDetail);
            }

            bindingSource.DataSource = null;
            bindingSource.DataSource = orderDetails;
            view.CalculateGrandTotal(orderDetails);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveEvent(object sender, EventArgs e)
        {
            var order = (OrderDetailModel)bindingSource.Current;

            if (orderDetails.Remove(orderDetails.Where(o => o.ItemID == order.ItemID).FirstOrDefault()))
            {
                bindingSource.DataSource = null;
                bindingSource.DataSource = orderDetails;
                view.CalculateGrandTotal(orderDetails);

                DialogMessageView.ShowMessage("success", $"Remove {order.ItemName}!");
            }
            else
            {
                DialogMessageView.ShowMessage("information", $"Something went wrong. Can't remove {order.ItemName}!");
            }
        }

        /// <summary>
        /// Curr Floor
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        private string CurrFloor(int no)
        {
            return "Floor0" + no;
        }

        #endregion

        #region public fields
        #endregion
    }
}

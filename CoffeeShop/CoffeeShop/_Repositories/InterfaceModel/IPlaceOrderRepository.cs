using CoffeeShop.Model;
using CoffeeShop.Model.InterfaceModel;
using CoffeeShop.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop._Repositories.InterfaceModel
{
    public interface IPlaceOrderRepository : ITableRepository, IFloorRepository, IStaffRepository
    {
        void AddOrderDetail(List<OrderDetailModel> orderDetails);
        void AddOrder(OrderModel order);
        void UpdateTableStatus(string tableID, string status);
        void EditOrderDetail(List<OrderDetailModel> orderDetails);
        void DeleteOrderDetail(List<OrderDetailModel> orderDetails);
        void UpdateOrderDetail(OrderDetailModel orderDetail);
        IEnumerable<TableOrder> GetTablesByFloor(string id);
        List<OrderDetailModel> GetOrderDetails(string orderID);
        OrderModel GetOrder(string tableID);
    }
}

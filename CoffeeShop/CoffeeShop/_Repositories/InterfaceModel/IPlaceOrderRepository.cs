using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop._Repositories.InterfaceModel
{
    public interface IPlaceOrderRepository : ITableRepository, IFloorRepository
    {
        IEnumerable<TableOrder> GetTablesByFloor(string id);
    }
}

using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop._Repositories.InterfaceModel
{
    public interface IFloorRepository
    {
        IEnumerable<Floor> GetAllFloor();
        Floor GetFloorByID(string id);
    }
}

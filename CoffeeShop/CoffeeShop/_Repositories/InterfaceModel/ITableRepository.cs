using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop._Repositories.InterfaceModel
{
    public interface ITableRepository
    {
        void EditStatusTable(string id, string status);
        IEnumerable<TableOrder> GetAllTable();
        TableOrder GetTableByID(string id);
    }
}

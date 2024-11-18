using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop._Repositories.InterfaceModel
{
    public interface IDashboardRepository
    {
        int GetTotalStaff();
        int GetTotalCustomer();
        float GetIncome(int day = 1, int month = 1, int year = 1);
    }
}

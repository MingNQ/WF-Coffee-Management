using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model.InterfaceModel
{
    public interface IStaffRepository
    {
        void Add(StaffModel staffModel);
        void Edit(StaffModel staffModel);
        void Delete(string staffID);
        IEnumerable<StaffModel> GetAll();
        IEnumerable<StaffModel> GetByValue(string value);
    }
}

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
        void SaveAvatar(bool isEdit, StaffModel staff);
        IEnumerable<StaffModel> GetAll();
        IEnumerable<StaffModel> GetByValue(string value);
        Avatar GetStaffAvatar(string staffID = null, string avatarID = null);
    }
}

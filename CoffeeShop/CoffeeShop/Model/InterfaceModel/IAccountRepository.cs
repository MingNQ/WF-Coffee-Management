using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model.InterfaceModel
{
    public interface IAccountRepository
    {
        void Add(Account account);
        void Edit(Account account);
        void Delete(string accountID);
        IEnumerable<Account> GetAll();
        IEnumerable<Account> GetByValue(string value);
    }
}

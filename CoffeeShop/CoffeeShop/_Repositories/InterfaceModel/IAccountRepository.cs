﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model.InterfaceModel
{
    public interface IAccountRepository
    {
        void Edit(Account account);
        void Delete(string accountID);
        IEnumerable<Account> GetAll();
        IEnumerable<Account> GetByValue(string value);

        string GetPasswordByID(string id);

        void ChangePasswordByID(Account account);
    }
}

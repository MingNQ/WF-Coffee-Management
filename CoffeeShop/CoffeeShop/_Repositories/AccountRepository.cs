using CoffeeShop.Model;
using CoffeeShop.Model.InterfaceModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop._Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        public AccountRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(Account account)
        {
            throw new NotImplementedException();
        }

        public void Delete(string accountID)
        {
            throw new NotImplementedException();
        }

        public void Edit(Account account)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetAll()
        {
            var accountList = new List<Account>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select AccountID, Username, Password, Staff.StaffID, Active, StaffName" +
                    " from Account join Staff on Account.StaffID = Staff.StaffID";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Account account = new Account();
                        account.AccountID = reader[0].ToString();
                        account.Username = reader[1].ToString();
                        account.Password = reader[2].ToString();
                        account.StaffID = reader[3].ToString();
                        account.Active = Convert.ToBoolean(reader[4]);
                        account.Staff = new StaffModel
                        {
                            StaffID = account.StaffID,
                            StaffName = reader[5].ToString()
                        };
                        accountList.Add(account);
                    }
                }
            }

            return accountList;
        }

        public IEnumerable<Account> GetByValue(string value)
        {
            throw new NotImplementedException();
        }
    }
}

using CoffeeShop.Model;
using CoffeeShop.Model.InterfaceModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop._Repositories
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public AccountRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #region public fields
        /// <summary>
        /// Delete Account
        /// </summary>
        /// <param name="accountID"></param>
        public void Delete(string accountID)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"if exists (
		                                    select 1
		                                    from Account left join Staff on Account.StaffID = Staff.StaffID
		                                    where Staff.StaffID is null
	                                    )
                                        begin
                                            delete from Account where AccountID = @id
                                        end";
                command.Parameters.Add("@id", SqlDbType.NVarChar).Value = accountID;
                int rowAffected = command.ExecuteNonQuery();

                if (rowAffected <= 0)
                {
                    throw new Exception();
                }
            }
        }

        /// <summary>
        /// Edit Account
        /// </summary>
        /// <param name="account"></param>
        public void Edit(Account account)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"update Account 
                                        set Active = @active
                                        where AccountID = @id";
                command.Parameters.Add("@active", SqlDbType.Bit).Value = account.Active;
                command.Parameters.Add("@id", SqlDbType.NVarChar).Value = account.AccountID;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Get list account
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Account> GetAll()
        {
            var accountList = new List<Account>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select AccountID, Username, Password, Staff.StaffID, Active, StaffName, tRole" +
                    " from Account left join Staff on Account.StaffID = Staff.StaffID";
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
                            StaffName = reader[5].ToString(),
                            Role = reader[6].ToString(),
                        };
                        accountList.Add(account);
                    }
                }
            }

            return accountList;
        }

        /// <summary>
        /// Get list account by value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IEnumerable<Account> GetByValue(string value)
        {
            var accountList = new List<Account>();

            string accountID = value;
            string userName = value;
            string staffName = value;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select AccountID, Username, Password, Staff.StaffID, Active, StaffName" +
                    " from Account join Staff on Account.StaffID = Staff.StaffID" +
                    " where AccountID = @id or Username like '%'+@username+'%' or StaffName like '%'+@name+'%'";

                command.Parameters.Add("@id", SqlDbType.NVarChar).Value = accountID;
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = userName;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = staffName;
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
        #endregion
    }
}

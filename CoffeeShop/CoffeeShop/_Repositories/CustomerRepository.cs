using CoffeeShop.Model;
using CoffeeShop.Model.Common;
using CoffeeShop.Model.InterfaceModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop._Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public CustomerRepository(string connectionString) 
        {
            this.connectionString = connectionString;
        }

        #region public fields

        /// <summary>
        /// Add new customer
        /// </summary>
        /// <param name="customerModel"></param>
        public void Add(CustomerModel customerModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into Customer values (@CustomerID, @CustomerName, @PhoneNumber, @Email, @Coupon, @Gender)";

                command.Parameters.Add("@CustomerID", SqlDbType.NVarChar).Value = customerModel.CustomerID;
                command.Parameters.Add("@CustomerName", SqlDbType.NVarChar).Value = customerModel.CustomerName;
                command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = customerModel.CustomerPhone;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = customerModel.CustomerEmail;
                command.Parameters.Add("@Coupon", SqlDbType.Decimal).Value = customerModel.Coupon;
                command.Parameters.Add("@Gender", SqlDbType.Int).Value = customerModel.Gender;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Delete customer
        /// </summary>
        /// <param name="customerID"></param>
        public void Delete(string customerID)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "delete from Customer where CustomerID = @id";
                command.Parameters.Add("@id", SqlDbType.NVarChar).Value = customerID;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Edit customer
        /// </summary>
        /// <param name="customerModel"></param>
        public void Edit(CustomerModel customerModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"update Customer
                                        set CustomerName = @name, CustomerPhoneNumber = @phoneNumber, Email = @email, Discount = @coupon, Gender = @gender
                                        where CustomerID = @id";
                command.Parameters.Add("@id", SqlDbType.NVarChar).Value = customerModel.CustomerID;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = customerModel.CustomerName;
                command.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = customerModel.CustomerPhone;
                command.Parameters.Add("@email", SqlDbType.NVarChar).Value = customerModel.CustomerEmail;
                command.Parameters.Add("@coupon", SqlDbType.Decimal).Value = customerModel.Coupon;
                command.Parameters.Add("@gender", SqlDbType.Int).Value = customerModel.Gender;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Get list customer
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CustomerModel> GetAll()
        {
            var customerList = new List<CustomerModel>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from Customer";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var customerModel = new CustomerModel();
                        customerModel.CustomerID = reader[0].ToString();
                        customerModel.CustomerName = string.IsNullOrEmpty(reader[1].ToString()) ? "" : reader[1].ToString();
                        customerModel.CustomerPhone = string.IsNullOrEmpty(reader[2].ToString()) ? "" : reader[2].ToString();           
                        customerModel.CustomerEmail = string.IsNullOrEmpty(reader[3].ToString()) ? "" : reader[3].ToString();
                        customerModel.Coupon = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4);
                        customerModel.Gender = reader[5].ToString() == "" ? Gender.Other : (Gender)Int32.Parse(reader[5].ToString());
                        customerList.Add(customerModel);
                    }
                }
            }

            return customerList;
        }



        /// <summary>
        /// Get list customer by value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IEnumerable<CustomerModel> GetByValue(string value)
        {           
            var customerList = new List<CustomerModel>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;

                // Kiểm tra nếu value là số điện thoại
                if (int.TryParse(value, out int phoneNumber))
                {
                    // Tìm kiếm bằng số điện thoại
                    command.CommandText = "SELECT * FROM Customer WHERE CustomerPhoneNumber = @phone";
                    command.Parameters.Add("@phone", SqlDbType.Int).Value = phoneNumber;
                }
                else
                {
                    // Tìm kiếm bằng CustomerID hoặc CustomerName
                    command.CommandText = @"SELECT * 
                                    FROM Customer 
                                    WHERE CustomerID LIKE @id + '%' OR CustomerName LIKE '%' + @name + '%'";
                    command.Parameters.Add("@id", SqlDbType.NVarChar).Value = value;
                    command.Parameters.Add("@name", SqlDbType.NVarChar).Value = value;
                }

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var customerModel = new CustomerModel();
                        customerModel.CustomerID = reader[0].ToString();
                        customerModel.CustomerName = string.IsNullOrEmpty(reader[1].ToString()) ? "" : reader[1].ToString();
                        customerModel.CustomerPhone = string.IsNullOrEmpty(reader[2].ToString()) ? "" : reader[2].ToString();
                        customerModel.CustomerEmail = string.IsNullOrEmpty(reader[3].ToString()) ? "" : reader[3].ToString();
                        customerModel.Coupon = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4);
                        customerModel.Gender = reader[5].ToString() == "" ? Gender.Other : (Gender)Int32.Parse(reader[5].ToString());
                        customerList.Add(customerModel);
                    }
                }
            }

            return customerList;
        }
        #endregion
    }
}

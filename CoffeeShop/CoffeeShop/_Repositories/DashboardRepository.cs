using CoffeeShop._Repositories.InterfaceModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop._Repositories
{
    public class DashboardRepository : BaseRepository, IDashboardRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public DashboardRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #region public fields

        /// <summary>
        /// Income
        /// </summary>
        /// <returns></returns>
        public float GetIncome(int day, int month, int year)
        {
            float result = 0;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;

                if (day != 1 && month != 1 && year != 1)
                {
                    command.CommandText = @"select sum(Total) as Income
                                      from Invoice join OrderDetail on Invoice.OrderID = OrderDetail.OrderID
                                      where day(SaleDate) = @day and month(SaleDate) = @month and year(SaleDate) = @year
                                      group by InvoiceID";
                    command.Parameters.Add("day", System.Data.SqlDbType.Int).Value = day;
                    command.Parameters.Add("month", System.Data.SqlDbType.Int).Value = month;
                    command.Parameters.Add("year", System.Data.SqlDbType.Int).Value = year;
                }
                else
                {
                    command.CommandText = @"select sum(Total) as Income
                                      from Invoice join OrderDetail on Invoice.OrderID = OrderDetail.OrderID
                                      group by InvoiceID";
                }
                
                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        result += Convert.ToInt32(reader[0].ToString());
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Total Customer
        /// </summary>
        /// <returns></returns>
        public int GetTotalCustomer()
        {
            int result = 0;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select count(*) from Customer";
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = Convert.ToInt32(reader[0].ToString());
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Total Staff
        /// </summary>
        /// <returns></returns>
        public int GetTotalStaff()
        {
            int result = 0;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select count(*) from Staff";
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result = Convert.ToInt32(reader[0].ToString());
                    }
                }
            }

            return result;
        }
        #endregion
    }
}

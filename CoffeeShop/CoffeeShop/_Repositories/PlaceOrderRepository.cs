using CoffeeShop._Repositories.InterfaceModel;
using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;

namespace CoffeeShop._Repositories
{
    public class PlaceOrderRepository : BaseRepository, IPlaceOrderRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        public PlaceOrderRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #region public methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        public void EditStatusTable(string id, string status)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"update tTable
                                        set tStatus = '%'+@status+'%'
                                        where TableID = @id";
                command.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
                command.Parameters.Add("status", SqlDbType.NVarChar).Value = status;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Floor> GetAllFloor()
        {
            var result = new List<Floor>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"select *
                                        from tFloor";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var floor = new Floor();
                        floor.FloorId = reader[0].ToString();
                        floor.FloorNumber = Convert.ToInt32(reader[1].ToString());
                        result.Add(floor);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TableOrder> GetAllTable()
        {
            var result = new List<TableOrder>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"select TableID, FloorID, tStatus, Capacity
                                        from tTable";
                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var table = new TableOrder();
                        table.TableID = reader[0].ToString();
                        table.Floor.FloorId = reader[1].ToString();
                        table.Status = reader[2].ToString();
                        table.Capacity = Convert.ToInt32(reader[3].ToString());
                        result.Add(table);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Floor GetFloorByID(string id)
        {
            var result = new Floor();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"select *
                                        from tFloor
                                        where FloorID = @id";
                command.Parameters.Add("id", SqlDbType.NVarChar).Value = id;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        result.FloorId = reader[0].ToString();
                        result.FloorNumber = Convert.ToInt32(reader[1].ToString());
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TableOrder GetTableByID(string id)
        {
            var table = new TableOrder();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"select *
                                        from tTable
                                        where TableID = @id";
                command.Parameters.Add("id", SqlDbType.NVarChar).Value = id;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        table.TableID = reader[0].ToString();
                        table.Floor.FloorId = reader[1].ToString();
                        table.Status = reader[2].ToString();
                        table.Capacity = Convert.ToInt32(reader[3].ToString());
                    }
                }
            }

            return table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<TableOrder> GetTablesByFloor(string id)
        {
            var result = new List<TableOrder>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"select *
                                        from tTable
                                        where FloorID = @id";
                command.Parameters.Add("id", SqlDbType.NVarChar).Value = id;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var table = new TableOrder();
                        table.TableID = reader[0].ToString();
                        table.Floor.FloorId = reader[1].ToString();
                        table.Status = reader[2].ToString();
                        table.Capacity = Convert.ToInt32(reader[3].ToString());
                        result.Add(table);
                    }
                }
            }

            return result;
        }

        #endregion
    }
}

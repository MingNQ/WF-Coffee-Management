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
using CoffeeShop.View;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;
using CoffeeShop.Model.InterfaceModel;
using CoffeeShop.Model.Common;
using Xceed.Document.NET;

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

        /// <summary>
        /// Add Order Detail
        /// </summary>
        /// <param name="staffID"></param>
        /// <param name="orderDetail"></param>
        public void AddOrderDetail(List<OrderDetailModel> orderDetails)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"insert into OrderDetail values(@OrderDetailID, @OrderID, @ItemID, @Quantity, @Total, @Description)";
                
                foreach (var orderDetail in orderDetails)
                {
                    command.Parameters.Clear();
                    command.Parameters.Add("OrderDetailID", SqlDbType.NVarChar).Value = orderDetail.OrderDetailID;
                    command.Parameters.Add("OrderID", SqlDbType.NVarChar).Value = orderDetail.OrderID;
                    command.Parameters.Add("ItemID", SqlDbType.NVarChar).Value = orderDetail.Item.ItemID;
                    command.Parameters.Add("Quantity", SqlDbType.Int).Value = orderDetail.Quantity;
                    command.Parameters.Add("Total", SqlDbType.Float).Value = orderDetail.Total;
                    command.Parameters.Add("Description", SqlDbType.NVarChar).Value = orderDetail.Description;
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Add Order
        /// </summary>
        /// <param name="staffID"></param>
        /// <param name="order"></param>
        public void AddOrder(OrderModel order)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"insert into tOrder(OrderID, StaffID, TableID, NumberPeople) values(@OrderID, @StaffID, @TableID, @NumberPeople)";
                command.Parameters.Add("OrderID", SqlDbType.NVarChar).Value = order.OrderID;
                command.Parameters.Add("StaffID", SqlDbType.NVarChar).Value = order.StaffID;
                command.Parameters.Add("TableID", SqlDbType.NVarChar).Value = order.TableID;
                command.Parameters.Add("NumberPeople", SqlDbType.Int).Value = order.NumberPeople;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderID"></param>
        /// <param name="status"></param>
        public void UpdateOrderStatus(string orderID, string status)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"update tOrder 
                                        set Status = @status
                                        where OrderID = @orderID";
                command.Parameters.Add("status", SqlDbType.NVarChar).Value = status;
                command.Parameters.Add("orderID", SqlDbType.NVarChar).Value = orderID;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableID"></param>
        public void UpdateTableStatus(string tableID, string status)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"update tTable 
                                        set tStatus = @status
                                        where TableID = @tableID";
                command.Parameters.Add("status", SqlDbType.NVarChar).Value = status;
                command.Parameters.Add("tableID", SqlDbType.NVarChar).Value = tableID;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Edit Order Details
        /// </summary>
        /// <param name="orderDetails"></param>
        public void EditOrderDetail(List<OrderDetailModel> orderDetails)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                
                foreach (var orderDetail in orderDetails)
                {
                    command.CommandText = @"update OrderDetail 
                                            set ItemID = @itemID, Quantity = @quantity, Total = @total, Description = @description
                                            where OrderDetailID = @orderDetailID";
                    command.Parameters.Clear();
                    command.Parameters.Add("itemID", SqlDbType.NVarChar).Value = orderDetail.ItemID;
                    command.Parameters.Add("quantity", SqlDbType.Int).Value = orderDetail.Quantity;
                    command.Parameters.Add("total", SqlDbType.Float).Value = orderDetail.Total;
                    command.Parameters.Add("description", SqlDbType.NVarChar).Value = orderDetail.Description;
                    command.Parameters.Add("orderDetailID", SqlDbType.NVarChar).Value = orderDetail.OrderDetailID;
                    command.ExecuteNonQuery();
                }
            }
        }
        /// <summary>
        /// Delete Order Details
        /// </summary>
        /// <param name="orderDetails"></param>
        public void DeleteOrderDetail(List<OrderDetailModel> orderDetails)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;

                foreach (var orderDetail in orderDetails)
                {
                    command.CommandText = @"delete from OrderDetail 
                                            where OrderDetailID = @orderDetailID";
                    command.Parameters.Add("orderDetailID", SqlDbType.NVarChar).Value = orderDetail.OrderDetailID;
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public List<OrderDetailModel> GetOrderDetails(string orderID)
        {
            var result = new List<OrderDetailModel>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from OrderDetail where OrderID = @orderID";
                command.Parameters.Add("orderID", SqlDbType.NVarChar).Value = orderID;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var orderDetail = new OrderDetailModel()
                        {
                            OrderDetailID = reader[0].ToString(),
                            OrderID = orderID,
                            ItemID = reader[2].ToString(),
                            Item = new ItemModel()
                            {
                                ItemID = reader[2].ToString()
                            },
                            Quantity = Convert.ToInt32(reader[3].ToString()),
                            Total = Convert.ToInt32(reader[4].ToString()),
                            Description = reader[5] == null ? "" : reader[5].ToString(),
                        };
                        result.Add(orderDetail);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableID"></param>
        /// <returns></returns>
        public OrderModel GetOrder(string tableID)
        {
            var order = new OrderModel();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"select OrderID, StaffID, NumberPeople
                                          from tOrder join tTable on tOrder.TableID = tTable.TableID
                                          where tTable.TableID = @tableID and tOrder.Status = 'Pending'";
                command.Parameters.Add("tableID", SqlDbType.NVarChar).Value = tableID;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        order.OrderID = reader[0].ToString();
                        order.StaffID = reader[1].ToString();
                        order.TableID = tableID;
                        order.NumberPeople = Convert.ToInt32(reader[2].ToString());
                    }
                }
            }

            return order;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StaffModel GetStaffInformationByID(string id)
        {
            StaffModel staff = null;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT *
                    FROM Staff
                    WHERE StaffID = @id";
                command.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        staff = new StaffModel
                        {
                            StaffID = reader["StaffID"].ToString(),
                            StaffName = reader["StaffName"].ToString(),
                            PhoneNumber = reader["StaffPhoneNumber"]?.ToString() ?? "",
                            DateOfBirth = reader["DateOfBirth"] != DBNull.Value ? (DateTime)reader["DateOfBirth"] : DateTime.MinValue,
                            Email = reader["Email"].ToString(),
                            Role = reader["tRole"].ToString(),
                            Gender = reader["Gender"] != DBNull.Value && Convert.ToBoolean(reader["Gender"]) ? Model.Common.Gender.Male : Model.Common.Gender.Female
                        };
                    }
                }
            }
            return staff;
        }

        /// <summary>
        /// Get Information for Invoice 
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
        public List<OrderDetailModel> GetOrderDetailWithItems(string orderID)
        {         
            List<OrderDetailModel> list = new List<OrderDetailModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                                    SELECT 
                                        Item.ItemName,
                                        OrderDetail.Quantity,
                                        Item.Cost,
                                        OrderDetail.Total
                                    FROM 
                                        OrderDetail
                                    INNER JOIN 
                                        Item 
                                    ON 
                                        OrderDetail.ItemID = Item.ItemID
                                    WHERE 
                                        OrderDetail.OrderID = @OrderID";
                command.Parameters.Add("@OrderID",SqlDbType.NVarChar).Value = orderID;                
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {                        
                        list.Add(new OrderDetailModel
                        {
                            ItemName = reader["ItemName"].ToString(),
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            UnitPrice = Convert.ToSingle(reader["Cost"]),
                            Total = Convert.ToSingle(reader["Cost"])
                        });
                    }
                }
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CustomerModel> GetCustomers()
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
        /// 
        /// </summary>
        /// <param name="invoice"></param>
        public void AddInvoice(InvoiceModel invoice)
        {
            using (var connection = new SqlConnection(connectionString)) 
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                
                if (string.IsNullOrEmpty(invoice.CustomerID))
                {
                    command.CommandText = @"insert into Invoice(InvoiceID, PaymentID, SaleDate, OrderID) 
                                            values(@InvoiceID, @PaymentID, @SaleDate, @OrderID)";
                }
                else
                {
                    command.CommandText = @"insert into Invoice values(@InvoiceID, @CustomerID, @PaymentID, @SaleDate, @OrderID)";
                    command.Parameters.Add("CustomerID", SqlDbType.NVarChar).Value = invoice.CustomerID;
                }

                command.Parameters.Add("InvoiceID", SqlDbType.NVarChar).Value = invoice.InvoiceID;
                command.Parameters.Add("PaymentID", SqlDbType.NVarChar).Value = invoice.PaymentID;
                command.Parameters.Add("SaleDate", SqlDbType.Date).Value = invoice.SaleDate;
                command.Parameters.Add("OrderID", SqlDbType.NVarChar).Value = invoice.OrderID;
                command.ExecuteNonQuery();
            }
        }

        #endregion

        #region UnUse
        public void Add(StaffModel staffModel)
        {
            throw new NotImplementedException();
        }

        public void Edit(StaffModel staffModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(string staffID)
        {
            throw new NotImplementedException();
        }

        public void SaveAvatar(bool isEdit, StaffModel staff)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StaffModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StaffModel> GetByValue(string value)
        {
            throw new NotImplementedException();
        }

        public Avatar GetStaffAvatar(string staffID = null, string avatarID = null)
        {
            throw new NotImplementedException();
        }

        public void AddAccount(Account account)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

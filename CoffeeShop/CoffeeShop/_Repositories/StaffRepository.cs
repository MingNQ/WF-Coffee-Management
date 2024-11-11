using CoffeeShop.Model;
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
    public class StaffRepository : BaseRepository, IStaffRepository
    {

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public StaffRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #region public fields
        /// <summary>
        /// Add new Staff
        /// </summary>
        /// <param name="staffModel"></param>
        public void Add(StaffModel staffModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into Staff values (@StaffID, @StaffName, @PhoneNumber, @DateOfBirth, @Email, @Role, @Gender)";

                command.Parameters.Add("@StaffID", SqlDbType.NVarChar).Value = staffModel.StaffID;
                command.Parameters.Add("@StaffName", SqlDbType.NVarChar).Value = staffModel.StaffName;
                command.Parameters.Add("@PhoneNumber", SqlDbType.VarChar).Value = staffModel.PhoneNumber;
                command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime).Value = staffModel.DateOfBirth;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = staffModel.Email;
                command.Parameters.Add("@Role", SqlDbType.NVarChar).Value = staffModel.Role;
                command.Parameters.Add("@Gender", SqlDbType.Int).Value = staffModel.Gender;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Delete Staff 
        /// </summary>
        /// <param name="staffID"></param>
        public void Delete(string staffID)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "delete from Staff where StaffID = @id";
                command.Parameters.Add("@id", SqlDbType.NVarChar).Value = staffID;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Edit Staff
        /// </summary>
        /// <param name="staffModel"></param>
        public void Edit(StaffModel staffModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"update Staff
                                        set StaffName = @name, StaffPhoneNumber = @phoneNumber, DateOfBirth = @dateOfBirth, Email = @email, tRole = @role, Gender = @gender
                                        where StaffID = @id";
                command.Parameters.Add("@id", SqlDbType.NVarChar).Value = staffModel.StaffID;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = staffModel.StaffName;
                command.Parameters.Add("@phoneNumber", SqlDbType.VarChar).Value = staffModel.PhoneNumber;
                command.Parameters.Add("@dateOfBirth", SqlDbType.DateTime).Value = staffModel.DateOfBirth;
                command.Parameters.Add("@email", SqlDbType.NVarChar).Value = staffModel.Email;
                command.Parameters.Add("@role", SqlDbType.NVarChar).Value = staffModel.Role;
                command.Parameters.Add("@gender", SqlDbType.Int).Value = staffModel.Gender;
                command.ExecuteNonQuery();
            }

        }

        /// <summary>
        /// Get list staff
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StaffModel> GetAll()
        {
            var staffList = new List<StaffModel>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from Staff";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var staffModel = new StaffModel();
                        staffModel.StaffID = reader[0].ToString();
                        staffModel.StaffName = reader[1].ToString();
                        staffModel.PhoneNumber = string.IsNullOrEmpty(reader[2].ToString()) ? "" : reader[2].ToString();
                        staffModel.DateOfBirth = (DateTime)reader[3];
                        staffModel.Email = reader[4].ToString();
                        staffModel.Role = reader[5].ToString();
                        staffModel.Gender = Convert.ToBoolean(reader[6]) ? Model.Common.Gender.Male : Model.Common.Gender.Female;
                        staffList.Add(staffModel);
                    }
                }
            }

            return staffList;
        }

        /// <summary>
        /// Get list staff by value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IEnumerable<StaffModel> GetByValue(string value)
        {
            var staffList = new List<StaffModel>();

            string staffID = value;
            string staffName = value;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Select * 
                                        from Staff 
                                        where StaffID like @id+'%' or StaffName like '%'+@name+'%'";
                command.Parameters.Add("@id", SqlDbType.NVarChar).Value = staffID;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = staffName;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var staffModel = new StaffModel();
                        staffModel.StaffID = reader[0].ToString();
                        staffModel.StaffName = reader[1].ToString();
                        staffModel.PhoneNumber = string.IsNullOrEmpty(reader[2].ToString()) ? "" : reader[2].ToString();
                        staffModel.DateOfBirth = (DateTime)reader[3];
                        staffModel.Email = reader[4].ToString();
                        staffModel.Role = reader[5].ToString();
                        staffModel.Gender = Convert.ToBoolean(reader[6]) ? Model.Common.Gender.Male : Model.Common.Gender.Female;
                        staffList.Add(staffModel);
                    }
                }
            }

            return staffList;
        }

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
                        Console.WriteLine("Record found for ID: " + id);
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
                    else
                    {
                        Console.WriteLine("No record found for ID: " + id);
                    }
                }
            }
            return staff;
        }

        #endregion
    }
}

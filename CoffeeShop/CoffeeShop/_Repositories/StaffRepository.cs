﻿using CoffeeShop.Model;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="staffModel"></param>
        public void Add(StaffModel staffModel)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="staffID"></param>
        public void Delete(string staffID)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="staffModel"></param>
        public void Edit(StaffModel staffModel)
        {
        }

        /// <summary>
        /// 
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
                        staffModel.PhoneNumber = string.IsNullOrEmpty(reader[2].ToString()) ? 0 : (int)reader[2];
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
        /// 
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
                        staffModel.PhoneNumber = string.IsNullOrEmpty(reader[2].ToString()) ? 0 : (int)reader[2];
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
    }
}

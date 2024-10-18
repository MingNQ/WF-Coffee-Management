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
    public class StaffRepository : BaseRepository, IStaffRepository
    {
        public StaffRepository(string connectionString) 
        {
            this.connectionString = connectionString;
        }

        public void Add(StaffModel staffModel)
        {
        }

        public void Delete(StaffModel staffModel)
        {
        }

        public void Edit(StaffModel staffModel)
        {
        }

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

        public IEnumerable<StaffModel> GetByValue(string value)
        {
            var staffList = new List<StaffModel>();

            return staffList;
        }
    }
}

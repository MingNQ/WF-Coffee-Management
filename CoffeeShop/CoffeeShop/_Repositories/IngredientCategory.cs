using CoffeeShop.Model;
using CoffeeShop.Model.InterfaceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CoffeeShop._Repositories
{
    public class IngredientCategory : BaseRepository, IIngredientRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public IngredientCategory(string connectionString) 
        {
            this.connectionString = connectionString;
        }

        #region public fields

        /// <summary>
        /// Add new ingredient
        /// </summary>
        /// <param name="ingredientModel"></param>
        public void Add(IngredientModel ingredientModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into Ingredient values (@IngredientID, @IngredientName)";

                command.Parameters.Add("@IngredientID", SqlDbType.NVarChar).Value = ingredientModel.IngredientID;
                command.Parameters.Add("@IngredientName", SqlDbType.NVarChar).Value = ingredientModel.IngredientName;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Delete ingredient
        /// </summary>
        /// <param name="ingredientID"></param>
        public void Delete(string ingredientID)
        {

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "delete from Ingredient where IngredientID = @id";
                command.Parameters.Add("@id", SqlDbType.NVarChar).Value = ingredientID;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Edit ingredient
        /// </summary>
        /// <param name="ingredientModel"></param>
        public void Edit(IngredientModel ingredientModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"update Ingredient
                                        set IngredientName = @name
                                        where IngredientID = @id";
                command.Parameters.Add("@id", SqlDbType.NVarChar).Value = ingredientModel.IngredientID;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = ingredientModel.IngredientName;
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Get list ingredient
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IngredientModel> GetAll()
        {
            var ingredientList = new List<IngredientModel>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "select * from Ingredient";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ingredientModel = new IngredientModel();
                        ingredientModel.IngredientID = reader[0].ToString();
                        ingredientModel.IngredientName = reader[1].ToString();
                        ingredientList.Add(ingredientModel);
                    }
                }
            }

            return ingredientList;
        }

        /// <summary>
        /// Get list ingredient by value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IEnumerable<IngredientModel> GetByValue(string value)
        {
            var ingredientList = new List<IngredientModel>();

            string ingredientID = value;
            string ingredientName = value;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Select * 
                                        from Ingredient 
                                        where IngredientID like @id+'%' or IngredientName like '%'+@name+'%'";
                command.Parameters.Add("@id", SqlDbType.NVarChar).Value = ingredientID;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = ingredientName;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ingredientModel = new IngredientModel();
                        ingredientModel.IngredientID = reader[0].ToString();
                        ingredientModel.IngredientName = reader[1].ToString();
                        ingredientList.Add(ingredientModel);
                    }
                }
            }

            return ingredientList;
        }

        #endregion
    }
}

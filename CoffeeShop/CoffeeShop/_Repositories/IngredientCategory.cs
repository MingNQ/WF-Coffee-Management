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
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete ingredient
        /// </summary>
        /// <param name="ingredientID"></param>
        public void Delete(string ingredientID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edit ingredient
        /// </summary>
        /// <param name="ingredientModel"></param>
        public void Edit(IngredientModel ingredientModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get list ingredient
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IngredientModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<IngredientModel> GetAllIngredient()
        {
            var ingredientList = new List<IngredientModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from Ingredient";
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
                throw new NotImplementedException();
            }

        #endregion
    }
}

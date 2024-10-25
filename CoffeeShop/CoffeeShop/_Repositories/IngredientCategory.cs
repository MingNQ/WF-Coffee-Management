using CoffeeShop.Model;
using CoffeeShop.Model.InterfaceModel;
using System;
using System.Collections.Generic;
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

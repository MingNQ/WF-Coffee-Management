using CoffeeShop.Model;
using CoffeeShop.Model.InterfaceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop._Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public CategoryRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #region public fields

        /// <summary>
        /// Add new item
        /// </summary>
        /// <param name="itemModel"></param>
        public void Add(ItemModel itemModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete item
        /// </summary>
        /// <param name="itemID"></param>
        public void Delete(string itemID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edit item
        /// </summary>
        /// <param name="itemModel"></param>
        public void Edit(ItemModel itemModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get list drink
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ItemModel> GetAllDrink()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get list foods
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ItemModel> GetAllFoods()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get items by value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IEnumerable<ItemModel> GetByValue(string value)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

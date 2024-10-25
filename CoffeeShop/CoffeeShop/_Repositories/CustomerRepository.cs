using CoffeeShop.Model;
using CoffeeShop.Model.InterfaceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop._Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public CustomerRepository(string connectionString) 
        {
            this.connectionString = connectionString;
        }

        #region public fields

        /// <summary>
        /// Add new customer
        /// </summary>
        /// <param name="customerModel"></param>
        public void Add(CustomerModel customerModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete customer
        /// </summary>
        /// <param name="customerID"></param>
        public void Delete(string customerID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Edit customer
        /// </summary>
        /// <param name="customerModel"></param>
        public void Edit(CustomerModel customerModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get list customer
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CustomerModel> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get list customer by value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IEnumerable<CustomerModel> GetByValue(string value)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.View
{
	public interface IDashboardView
	{
        #region Fields - Properties
        /// <summary>
        /// Total Staff
        /// </summary>
        int TotalStaff {  get; set; }

        /// <summary>
        /// Total Customer
        /// </summary>
        int TotalCustomer { get; set; }

        /// <summary>
        /// Today's Income
        /// </summary>
        float Income { get; set; }

        /// <summary>
        /// Total Income
        /// </summary>
        float TotalIncome {  get; set; }
        #endregion

        #region Event
        #endregion

        // Updating...
        void Show();
    }
}

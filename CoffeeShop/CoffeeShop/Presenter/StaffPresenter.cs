using CoffeeShop.Model;
using CoffeeShop.Model.InterfaceModel;
using CoffeeShop.View.MainFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.Presenter
{
	public class StaffPresenter
	{
		#region Fields
		/// <summary>
		/// Interface Staff view
		/// </summary>
		private IStaffView staffView;

		private IStaffRepository repository;
		private BindingSource staffBindingSource;
		private IEnumerable<StaffModel> staffList;
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="view">Staff view</param>
		public StaffPresenter(IStaffView view, IStaffRepository repository)
		{
			this.staffBindingSource = new BindingSource();
			this.staffView = view;
			this.repository = repository;


			this.staffView.AddNewEvent += AddNewEvent;
			this.staffView.EditEvent += EditEvent;
			this.staffView.DeleteEvent += DeleteEvent;
			this.staffView.SaveEvent += SaveEvent;
			this.staffView.ClearEvent += ClearEvent;

			// Set Staff List binding source
			this.staffView.SetLPetListBindingSource(staffBindingSource);

			// Load Staff List
			LoadAllStaff();

            // Display Staff view
            this.staffView.Show();
        }



        #region private fields

        private void LoadAllStaff()
        {
			staffList = repository.GetAll();
			staffBindingSource.DataSource = staffList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewEvent(object sender, EventArgs e)
        {
        }


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void EditEvent(object sender, EventArgs e)
        {
        }


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void DeleteEvent(object sender, EventArgs e)
        {
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void SaveEvent(object sender, EventArgs e)
        {
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void ClearEvent(object sender, EventArgs e)
        {
        }



        #endregion
    }
}

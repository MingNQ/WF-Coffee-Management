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
			this.staffView.BackToListEvent += BackToListEvent;

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
			staffView.IsEdit = false;   
        }


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void EditEvent(object sender, EventArgs e)
        {
			var staff = (StaffModel)staffBindingSource.Current;

			staffView.StaffName = staff.StaffName;
			staffView.PhoneNumber = staff.PhoneNumber.ToString();
			staffView.DateOfBirth = staff.DateOfBirth.ToString();
			staffView.Email = staff.Email;
			staffView.StaffRole = staff.Role;
			staffView.Male = staff.Gender == Model.Common.Gender.Male;
			staffView.Female = staff.Gender == Model.Common.Gender.Female;
			staffView.Other = staff.Gender == Model.Common.Gender.Other;
            staffView.IsEdit = true;
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
			ClearFieldInformation();
        }

		/// <summary>
		/// Back to List view
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void BackToListEvent(object sender, EventArgs e)
        {
			ClearFieldInformation();
        }

        /// <summary>
        /// Clear Information
        /// </summary>
        private void ClearFieldInformation()
		{
            staffView.StaffName = "";
            staffView.PhoneNumber = "";
            staffView.DateOfBirth = "";
            staffView.Email = "";
            staffView.StaffRole = "";
            staffView.Male = false;
            staffView.Female = false;
            staffView.Other = false;
        }

        #endregion
    }
}

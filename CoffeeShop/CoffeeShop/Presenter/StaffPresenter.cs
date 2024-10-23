using CoffeeShop.Model;
using CoffeeShop.Model.InterfaceModel;
using CoffeeShop.View.MainFrame;
using System;
using System.Collections.Generic;
using System.Drawing;
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

		/// <summary>
		/// 
		/// </summary>
		private IStaffRepository repository;
		
		/// <summary>
		/// 
		/// </summary>
		private BindingSource staffBindingSource;
		
		/// <summary>
		/// 
		/// </summary>
		private IEnumerable<StaffModel> staffList;
		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="view">Staff view</param>
		public StaffPresenter(IStaffView view, IStaffRepository repository)
		{
			this.staffView = view;

            if (!staffView.IsOpen)
            {
                this.staffBindingSource = new BindingSource();
                this.repository = repository;

			    // Subcribe events
			    this.staffView.AddNewEvent += AddNewEvent;
			    this.staffView.EditEvent += EditEvent;
			    this.staffView.DeleteEvent += DeleteEvent;
                this.staffView.SearchEvent += SearchEvent;
                this.staffView.SaveEvent += SaveEvent;
			    this.staffView.ClearEvent += ClearEvent;
			    this.staffView.BackToListEvent += BackToListEvent;

                // Set Staff List binding source
                this.staffView.SetLPetListBindingSource(staffBindingSource);

                // Load Staff List
                LoadAllStaff();
            }

            // Display Staff view
            this.staffView.Show();
        }


        #region private fields

        /// <summary>
        /// Load staff list
        /// </summary>
        private void LoadAllStaff()
        {
			staffList = repository.GetAll();
			staffBindingSource.DataSource = staffList;
        }

        /// <summary>
        /// Add new staff
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewEvent(object sender, EventArgs e)
        {
			staffView.IsEdit = false;   
        }

		/// <summary>
		/// Edit staff
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void EditEvent(object sender, EventArgs e)
        {
			var staff = (StaffModel)staffBindingSource.Current;

            staffView.StaffID = staff.StaffID;
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
        /// Search Staff
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchEvent(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.staffView.SearchValue);

            if (!emptyValue)
            {
                staffList = repository.GetByValue(this.staffView.SearchValue);
            }
            else
            {
                staffList = repository.GetAll();
            }
            staffBindingSource.DataSource = staffList;
        }


        /// <summary>
        /// Delete staff
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteEvent(object sender, EventArgs e)
        {
            try
            {
                var staff = (StaffModel)staffBindingSource.Current;
                repository.Delete(staff.StaffID);
                staffView.IsSuccessful = true;
                LoadAllStaff();
                MessageBox.Show("Successul delete staff", "Notify", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch
            {
                staffView.IsSuccessful = false;

				MessageBox.Show("An error occured, could not delete this staff!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

		/// <summary>
		/// Save staff
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void SaveEvent(object sender, EventArgs e)
        {
            var staff = new StaffModel();
			
            try
            {
                staff.StaffID = staffView.StaffID;
                staff.StaffName = staffView.StaffName;
                staff.PhoneNumber = Convert.ToInt32(staffView.PhoneNumber);
                staff.DateOfBirth = DateTime.Parse(staffView.DateOfBirth);
                staff.Email = staffView.Email;
                staff.Role = staffView.StaffRole;
                staff.Gender = staffView.Male ? Model.Common.Gender.Male : (staffView.Female ? Model.Common.Gender.Female : Model.Common.Gender.Other);

                new Common.ModelValidation().Validate(staff);

                if (staffView.IsEdit) // Edit model
                {
                    repository.Edit(staff);
                }
                else // Add new model
                {
                    // Generate ID
                    int id = Convert.ToInt32(staffList.Last().StaffID.Substring(2)) + 1;
                    staff.StaffID = "NV" + id.ToString("D3");
                    
                    repository.Add(staff);
                }

                staffView.IsSuccessful = true;
                LoadAllStaff();
                ClearFieldInformation();
            }
            catch (Exception ex)
            {
                staffView.IsSuccessful = false;
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		/// <summary>
		/// Clear information
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void ClearEvent(object sender, EventArgs e)
        {
			if (staffView.IsEdit && 
				MessageBox.Show("Are you sure to clear all information? Information once cleared can't be recovered!", 
						"Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == 
				DialogResult.Yes
				)
			{
				ClearFieldInformation();
            }
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

        #region public fields
        #endregion
    }
}

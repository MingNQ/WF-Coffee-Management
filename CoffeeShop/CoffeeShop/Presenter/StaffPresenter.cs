using CoffeeShop.Model;
using CoffeeShop.Model.InterfaceModel;
using CoffeeShop.Utilities;
using CoffeeShop.View.DialogForm;
using CoffeeShop.View.MainFrame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
                this.staffView.SetLStaffListBindingSource(staffBindingSource);

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

            // Fill Information
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
            staffView.Avatar = repository.GetStaffAvatar(staff.StaffID);
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

                DialogMessageView.ShowMessage("success", "Successul delete staff");
            }
            catch
            {
                staffView.IsSuccessful = false;
                DialogMessageView.ShowMessage("error", "An error occured, could not delete this staff!");
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
                staff.PhoneNumber = staffView.PhoneNumber;
                staff.DateOfBirth = DateTime.Parse(staffView.DateOfBirth);
                staff.Email = staffView.Email;
                staff.Role = staffView.StaffRole;
                staff.Gender = staffView.Male ? Model.Common.Gender.Male : (staffView.Female ? Model.Common.Gender.Female : Model.Common.Gender.Other);
                staff.Avatar = new Avatar()
                {
                    AvatarID = staffView.Avatar.AvatarID,
                    StaffID = staffView.StaffID,
                    ImageUrl = staffView.Avatar.ImageUrl
                };

                if (staff.Avatar.AvatarID == null)
                {
                    // Generate Avatar ID
                    while (true)
                    {
                        string avatarID = Generate.GenerateID("AVT");
                        var account = repository.GetStaffAvatar(null, avatarID);

                        if (account.AvatarID == null)
                        {
                            staff.Avatar.AvatarID = avatarID;
                            break;
                        }
                    }
                }

                new Common.ModelValidation().Validate(staff);

                if (staffView.IsEdit) // Edit model
                {
                    repository.Edit(staff);
                }
                else // Add new model
                {
                    // Generate ID
                    while (true)
                    {
                        staff.StaffID = Generate.GenerateID("NV");

                        if (!StaffExist(staff.StaffID))
                        {
                            break;
                        }
                    }

                    repository.Add(staff);
                }

                if (staffView.Avatar.ImageUrl != null) 
                    repository.SaveAvatar(staffView.IsEdit, staff);
                
                staffView.IsSuccessful = true;
                LoadAllStaff();
            }
            catch (Exception ex)
            {
                staffView.IsSuccessful = false;

                DialogMessageView.ShowMessage("information", ex.Message);
            }
        }

        /// <summary>
        /// Clear information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearEvent(object sender, EventArgs e)
        {
            if (DialogMessageView.ShowMessage("warning", "Are you sure to clear all information? Information once cleared can't be recovered!") 
                == DialogResult.OK)
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

        /// <summary>
        /// Check Exist Staff
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool StaffExist(string id)
        {
            return staffList.Any(s => s.StaffID == id);
        }

        #endregion

        #region public fields
        #endregion
    }
}

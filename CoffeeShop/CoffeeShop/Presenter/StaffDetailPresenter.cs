using CoffeeShop.Model;
using CoffeeShop.Model.Common;
using CoffeeShop.Model.InterfaceModel;
using CoffeeShop.View.MainFrame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.Presenter
{
    internal class StaffDetailPresenter
    {
        #region Fields
        /// <summary>
        /// Interface StaffDetailView
        /// </summary>
        private IStaffDetailView staffDetailView;
        /// <summary>
        /// 
        /// </summary>
        private IStaffRepository Repository;
        /// <summary>
        /// 
        /// </summary>
        private IEnumerable<StaffModel> staffList;

        #endregion

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="view"></param>
        /// <param name="repository"></param>
        public StaffDetailPresenter(IStaffDetailView view,IStaffRepository repository)
        {
            Repository = repository;
            this.staffDetailView = view;
            this.staffDetailView.EditEvent += EditEvent;
            this.staffDetailView.CancelEvent += CancelEvent;
            this.staffDetailView.SaveEvent += SaveEvent;
            this.staffDetailView.ImportEvent += ImportEvent;
            LoadStaffDetails();
            this.staffDetailView.Show();
        }

        #region private fields
        /// <summary>
        /// Load Information Staff to Form
        /// </summary>
        private void LoadStaffDetails()
        {
            StaffModel staff = Repository.GetStaffInformationByID(staffDetailView.StaffId);
            if (staff != null)
            {
                if (staffDetailView != null && staffDetailView.StaffInformationControl != null)
                {
                    staffDetailView.StaffInformationControl.txtStaffName.Text = staff.StaffName.ToString();
                    staffDetailView.StaffInformationControl.txtEmail.Text = staff.Email ?? "";
                    staffDetailView.StaffInformationControl.txtPhone.Text = staff.PhoneNumber ?? "";
                    staffDetailView.StaffInformationControl.cbRole.Text = staff.Role ?? "";
                    staffDetailView.StaffInformationControl.dtpDob.Value = staff.DateOfBirth != DateTime.MinValue ? staff.DateOfBirth : DateTime.Now;
                    if (staff.Gender.ToString() == "Male")
                    {
                        staffDetailView.StaffInformationControl.rdoMale.Checked = true;
                    }
                    else if(staff.Gender.ToString() == "Female")
                    {
                        staffDetailView.StaffInformationControl.rdoFemale.Checked = true;
                    }
                    else
                    {
                        staffDetailView.StaffInformationControl.rdoOther.Checked = true;
                    }
                }
            }
        }
       
        /// <summary>
        /// Import Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>

        private void ImportEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Save Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveEvent(object sender, EventArgs e)
        {       
            StaffModel updatedStaff = new StaffModel
            {
                StaffID = staffDetailView.StaffId,
                StaffName = staffDetailView.StaffInformationControl.txtStaffName.Text,
                DateOfBirth = staffDetailView.StaffInformationControl.dtpDob.Value,
                PhoneNumber = staffDetailView.StaffInformationControl.txtPhone.Text,
                Email = staffDetailView.StaffInformationControl.txtEmail.Text,
                Role = staffDetailView.StaffInformationControl.cbRole.Text,
                Gender = staffDetailView.StaffInformationControl.rdoFemale.Checked ? Model.Common.Gender.Female:
                         staffDetailView.StaffInformationControl.rdoMale.Checked ? Model.Common.Gender.Male:
                         Model.Common.Gender.Other
            };
            new Common.ModelValidation().Validate(updatedStaff);
            if (staffDetailView.IsEdit)
            {
                Repository.Edit(updatedStaff);
            }
            LoadStaffDetails();
        }
        /// <summary>
        /// Cancel Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelEvent(object sender, EventArgs e)
        {
            staffDetailView.IsEdit = false;
            LoadStaffDetails();
        }
        /// <summary>
        /// Edit Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditEvent(object sender, EventArgs e)
        {
           staffDetailView.IsEdit = true;
        }
        #endregion

        #region Public Fields
        #endregion
    }
}

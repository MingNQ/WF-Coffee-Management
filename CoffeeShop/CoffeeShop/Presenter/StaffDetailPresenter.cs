using CoffeeShop._Repositories;
using CoffeeShop.Model;
using CoffeeShop.Model.Common;
using CoffeeShop.Model.InterfaceModel;
using CoffeeShop.View.MainFrame.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        private IStaffRepository repository;

        /// <summary>
        /// Repository Account
        /// </summary>
        private IAccountRepository accountRepository;

        #endregion

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="view"></param>
        /// <param name="repository"></param>
        public StaffDetailPresenter(IStaffDetailView view, IStaffRepository repository,IAccountRepository AccoungRepository)
        {
            this.repository = repository;
            this.accountRepository = AccoungRepository;
            this.staffDetailView = view;
            this.staffDetailView.EditEvent += EditEvent;
            this.staffDetailView.CancelEvent += CancelEvent;
            this.staffDetailView.SaveEvent += SaveEvent;
            this.staffDetailView.ImportEvent += ImportEvent;
            this.staffDetailView.ChangePasswordEvent += ChangePasswordEvent;
            this.staffDetailView.HideMessageEvent += HideMessageEvent;
            LoadStaffDetails();
            this.staffDetailView.Show();
        }

        #region private fields
        /// <summary>
        /// Load Information Staff to Form
        /// </summary>
        private void LoadStaffDetails()
        {
            StaffModel staff = repository.GetStaffInformationByID(staffDetailView.StaffId);
            if (staff != null)
            {
                if (staffDetailView != null && staffDetailView.StaffInformationControl != null)
                {
                    staffDetailView.StaffInformationControl.txtStaffName.Text = staff.StaffName.ToString();
                    staffDetailView.StaffInformationControl.txtEmail.Text = staff.Email ?? "";
                    staffDetailView.StaffInformationControl.txtPhone.Text = staff.PhoneNumber ?? "";
                    staffDetailView.StaffInformationControl.txtRole.Text = staff.Role ?? "";
                    staffDetailView.StaffInformationControl.dtpDob.Value = staff.DateOfBirth != DateTime.MinValue ? staff.DateOfBirth : DateTime.Now;
                    if (staff.Gender.ToString() == "Male")
                    {
                        staffDetailView.StaffInformationControl.rdoMale.Checked = true;
                    }
                    else if (staff.Gender.ToString() == "Female")
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
            if(staffDetailView.IsChangePass == false)
            {
                StaffModel updatedStaff = new StaffModel
                {
                    StaffID = staffDetailView.StaffId,
                    StaffName = staffDetailView.StaffInformationControl.txtStaffName.Text,
                    DateOfBirth = staffDetailView.StaffInformationControl.dtpDob.Value,
                    PhoneNumber = staffDetailView.StaffInformationControl.txtPhone.Text,
                    Email = staffDetailView.StaffInformationControl.txtEmail.Text,
                    Role = staffDetailView.StaffInformationControl.txtRole.Text,
                    Gender = staffDetailView.StaffInformationControl.rdoFemale.Checked ? Model.Common.Gender.Female :
                         staffDetailView.StaffInformationControl.rdoMale.Checked ? Model.Common.Gender.Male :
                         Model.Common.Gender.Other
                };
                new Common.ModelValidation().Validate(updatedStaff);
                if (staffDetailView.IsEdit)
                {
                    repository.Edit(updatedStaff);
                }
                staffDetailView.InitializeControl();
                LoadStaffDetails();
            }
            else
            {               
                if(staffDetailView.StaffInformationControl.txtOldPassword.Text == "")
                {
                    ErrorMessage("Old Password is required");
                }
                else
                {
                    if(staffDetailView.StaffInformationControl.txtNewPassword.Text == "")
                    {
                        ErrorMessage("New Password is required");
                    }
                    else
                    {
                        if(staffDetailView.StaffInformationControl.txtConfirmPassword.Text == "")
                        {
                            ErrorMessage("Confirm new password is required");
                        }
                        else
                        {
                            if (staffDetailView.StaffInformationControl.txtOldPassword.Text != accountRepository.GetPasswordByID(staffDetailView.StaffId))
                            {
                                ErrorMessage("Input Wrong Password");
                            }
                            else
                            {
                                if (staffDetailView.StaffInformationControl.txtNewPassword.Text != staffDetailView.StaffInformationControl.txtConfirmPassword.Text)
                                {
                                    ErrorMessage("Password does not match,please check again");
                                }
                                else
                                {
                                    StaffModel updatedStaff = new StaffModel
                                    {
                                        StaffID = staffDetailView.StaffId,
                                        StaffName = staffDetailView.StaffInformationControl.txtStaffName.Text,
                                        DateOfBirth = staffDetailView.StaffInformationControl.dtpDob.Value,
                                        PhoneNumber = staffDetailView.StaffInformationControl.txtPhone.Text,
                                        Email = staffDetailView.StaffInformationControl.txtEmail.Text,
                                        Role = staffDetailView.StaffInformationControl.txtRole.Text,
                                        Gender = staffDetailView.StaffInformationControl.rdoFemale.Checked ? Model.Common.Gender.Female :
                                                 staffDetailView.StaffInformationControl.rdoMale.Checked ? Model.Common.Gender.Male :
                                                 Model.Common.Gender.Other
                                    };
                                    new Common.ModelValidation().Validate(updatedStaff);
                                    Account updatedPassword = new Account
                                    {
                                        Password = staffDetailView.StaffInformationControl.txtNewPassword.Text,
                                        StaffID = staffDetailView.StaffId
                                    };
                                    if (staffDetailView.IsEdit)
                                    {
                                        repository.Edit(updatedStaff);
                                        accountRepository.ChangePasswordByID(updatedPassword);
                                        staffDetailView.InitializeControl();
                                        LoadStaffDetails();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Cancel Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelEvent(object sender, EventArgs e)
        {
            staffDetailView.IsEdit = false;
            staffDetailView.IsChangePass = false;
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
            staffDetailView.IsChangePass = false;
        }
        /// <summary>
        /// Change Password Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangePasswordEvent(object sender, EventArgs e)
        {
            staffDetailView.IsChangePass = true;
        }
        /// <summary>
        /// Hide Message Event 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void HideMessageEvent(object sender, EventArgs e)
        {
            this.staffDetailView.StaffInformationControl.lbErrorMessage.Text = "";
            this.staffDetailView.StaffInformationControl.txtOldPassword.BorderColor = Color.FromArgb(213, 218, 223);
            this.staffDetailView.StaffInformationControl.txtNewPassword.BorderColor = Color.FromArgb(213, 218, 223);
            this.staffDetailView.StaffInformationControl.txtConfirmPassword.BorderColor = Color.FromArgb(213, 218, 223);
            this.staffDetailView.StaffInformationControl.txtNewPassword.Text = "";
            this.staffDetailView.StaffInformationControl.txtOldPassword.Text = "";
            this.staffDetailView.StaffInformationControl.txtConfirmPassword.Text = "";
        }
        /// <summary>
        /// Error Message when change password
        /// </summary>
        /// <param name="message"></param>
        private void ErrorMessage(string message)
        {
            this.staffDetailView.StaffInformationControl.lbErrorMessage.Text = message;
            this.staffDetailView.StaffInformationControl.txtNewPassword.BorderColor = Color.Red;
            this.staffDetailView.StaffInformationControl.txtOldPassword.BorderColor= Color.Red;
            this.staffDetailView.StaffInformationControl.txtConfirmPassword.BorderColor= Color.Red;
        }
        #endregion

        #region Public Fields
        #endregion
    }
}

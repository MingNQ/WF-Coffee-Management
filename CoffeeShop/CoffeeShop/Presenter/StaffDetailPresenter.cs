using CoffeeShop.Model;
using CoffeeShop.Model.Common;
using CoffeeShop.Model.InterfaceModel;
using CoffeeShop.Utilities;
using CoffeeShop.View.MainFrame.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
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

        #endregion

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="view"></param>
        /// <param name="repository"></param>
        public StaffDetailPresenter(IStaffDetailView view, IStaffRepository repository)
        {
            this.staffDetailView = view;
            this.repository = repository;

            if (!staffDetailView.IsOpen)
            {
                this.staffDetailView.EditEvent += EditEvent;
                this.staffDetailView.CancelEvent += CancelEvent;
                this.staffDetailView.SaveEvent += SaveEvent;
                this.staffDetailView.ImportEvent += ImportEvent;
            }
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

                    // Get avatar
                    staffDetailView.StaffInformationControl.Avatar = repository.GetStaffAvatar(staffDetailView.StaffId).ImageUrl;
                    staffDetailView.HasAvatar = !string.IsNullOrEmpty(staffDetailView.StaffInformationControl.Avatar);
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
            // Open File Dialog
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Application.StartupPath;
                openFileDialog.Filter = "PNG File (*.png)|*.png|JPEG File (*.jpeg)|*.jpeg|JPG File(*.jpg)|*.jpg|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Combine Path to Save File
                    string sourceFilePath = openFileDialog.FileName;
                    string fileName = Path.GetFileName(sourceFilePath);
                    string destinationPath = Path.Combine(Application.StartupPath, AppConst.IMAGE_SOURE_PATH, fileName);

                    if (Path.GetFullPath(sourceFilePath) != Path.GetFullPath(destinationPath))
                    {
                        File.Copy(sourceFilePath, destinationPath, true);
                    }

                    // Update Avatar in StaffInformationControl
                    staffDetailView.StaffInformationControl.Avatar = destinationPath;

                    // Update Avatar in the database
                    var updatedStaff = repository.GetStaffInformationByID(staffDetailView.StaffId);
                    if (updatedStaff != null)
                    {
                        if (updatedStaff.Avatar == null)
                        {
                            // Add a new Avatar if it doesn't exist
                            updatedStaff.Avatar = new Avatar
                            {
                                AvatarID = Generate.GenerateID("AVT"),
                                StaffID = staffDetailView.StaffId,
                                ImageUrl = fileName
                            };
                        }
                        else
                        {
                            // Update existing Avatar
                            updatedStaff.Avatar.ImageUrl = fileName;
                        }

                        repository.Edit(updatedStaff);

                        // Update "Your Profile" UI immediately
                        UpdateProfileView(destinationPath);

                        MessageBox.Show("Avatar has been updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imagePath"></param>
        private void UpdateProfileView(string imagePath)
        {
            // Kiểm tra xem ảnh có tồn tại không
            if (File.Exists(imagePath))
            {
                // Gán lại ảnh cho PictureBox trong giao diện "Your Profile"         
                staffDetailView.StaffInformationControl.ProfilePicture.ImageLocation = imagePath;
            }
            else
            {
                MessageBox.Show("Image file not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                Role = staffDetailView.StaffInformationControl.txtRole.Text,
                Gender = staffDetailView.StaffInformationControl.rdoFemale.Checked ? Model.Common.Gender.Female :
                         staffDetailView.StaffInformationControl.rdoMale.Checked ? Model.Common.Gender.Male :
                         Model.Common.Gender.Other,
                Avatar = new Avatar
                {
                    AvatarID = Generate.GenerateID("AVT"),
                    StaffID = staffDetailView.StaffId,
                    ImageUrl = SaveAvatar(staffDetailView.StaffInformationControl.Avatar) // Lưu ảnh
                }
            };
            new Common.ModelValidation().Validate(updatedStaff);
            if (staffDetailView.IsEdit)
            {
                repository.Edit(updatedStaff);
                repository.SaveAvatar(staffDetailView.HasAvatar, updatedStaff);
            }
            LoadStaffDetails();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="avatarPath"></param>
        /// <returns></returns>
        private string SaveAvatar(string avatarPath)
        {
            if(!string.IsNullOrEmpty(avatarPath) && File.Exists(avatarPath))
            {
                string fileName = Path.GetFileName(avatarPath);
                string destinationPath = Path.Combine(Application.StartupPath, AppConst.IMAGE_SOURE_PATH, fileName);
                
                // Sao chép ảnh vào thư mục ứng dụng nếu chưa tồn tại
                if (!File.Exists(destinationPath))
                {
                    File.Copy(avatarPath, destinationPath, true);
                }
                return fileName; // Trả về tên file để lưu vào cơ sở dữ liệu
            }
            return null;// Nếu không có ảnh thì trả về null
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

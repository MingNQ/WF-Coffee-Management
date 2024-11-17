using CoffeeShop._Repositories;
using CoffeeShop.Model;
using CoffeeShop.Model.Common;
using CoffeeShop.Model.InterfaceModel;
using CoffeeShop.Utilities;
using System.IO;
using CoffeeShop.Presenter.Common;
using CoffeeShop.View.DialogForm;
using CoffeeShop.View.MainFrame.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            this.staffDetailView = view;
            if (!staffDetailView.IsOpen)
            {
              
                this.repository = repository;
                this.accountRepository = AccoungRepository;
                //gán các sự kiện từ view với các phương thức tương ứng
                this.staffDetailView.EditEvent += EditEvent;
                this.staffDetailView.CancelEvent += CancelEvent;
                this.staffDetailView.SaveEvent += SaveEvent;
                this.staffDetailView.ImportEvent += ImportEvent;
                this.staffDetailView.ChangePasswordEvent += ChangePasswordEvent;
                this.staffDetailView.HideMessageEvent += HideMessageEvent;
                this.staffDetailView.ShowPasswordEvent += ShowPasswordEvent;

                LoadStaffDetails();  //Tải thông tin nhân viên lên giao diện
            }
            this.staffDetailView.Show();  //hiển thị giao diện
        }

        #region private fields
        /// <summary>
        /// Load Information Staff to Form
        /// </summary>
        private void LoadStaffDetails()
        {
            StaffModel staff = repository.GetStaffInformationByID(staffDetailView.StaffId); //lấy thông tin nhân viên
            if (staff != null)
            {
                //nếu view và phần điều kiển thông tin nhân viên ko bị null
                if (staffDetailView != null && staffDetailView.StaffInformationControl != null)
                {
                    staffDetailView.StaffInformationControl.txtStaffName.Text = staff.StaffName.ToString();
                    // ?? "" : nếu trường này null thì thay bằng chuỗi rỗng ("") để hiển thị 
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

                    // Lấy đường dẫn ảnh đại diện của nhân viên từ cơ sở dữ liệu và gán vào điều khiển avatar 
                    staffDetailView.StaffInformationControl.Avatar = repository.GetStaffAvatar(staffDetailView.StaffId).ImageUrl;
                    // Xác định xem nhân viên có ảnh đại diện hay không
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
            using (OpenFileDialog openFileDialog = new OpenFileDialog()) //tạo hộp thoại mở file, cho phép ng dùng chọn 1 tệp từ máy tính 
            {
                openFileDialog.InitialDirectory = Application.StartupPath; //đường dẫn thư mục chứa file nơi ứng dụng chạy
                openFileDialog.Filter = "PNG File (*.png)|*.png|JPEG File (*.jpeg)|*.jpeg|JPG File(*.jpg)|*.jpg|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Combine Path to Save File
                    string sourceFilePath = openFileDialog.FileName; //đường dẫn đầy đủ của tệp mà ng dùng đã chọn
                    string fileName = Path.GetFileName(sourceFilePath); //lấy tên file từ đường dẫn đầy đủ (vd: avatar.png)
                    //tạo đường dẫn lưu trữ file mới trong thư mục của ứng dụng 
                    string destinationPath = Path.Combine(Application.StartupPath, AppConst.IMAGE_SOURE_PATH, fileName);

                    if (Path.GetFullPath(sourceFilePath) != Path.GetFullPath(destinationPath))
                    {
                        // sao chép file từ đường dẫn nguồn sang đường dẫn đích
                        // File.Copy(nguồn, đích, ghi đè file đích nếu file đã tồn tại)
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
                // Gán lại ảnh cho PictureBox trong giao diện         
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
            if(staffDetailView.IsChangePass == false)
            {
              try
                {
                    if (staffDetailView.IsChangePass == false)
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
                        staffDetailView.InitializeControl();
                        LoadStaffDetails();                        
                        DialogMessageView.ShowMessage("success", "Updated Successfully");
                    }
                }
                catch (ValidationException ex) // Lỗi validate
                {
                    DialogMessageView.ShowMessage("error", $"Validation Error: {ex.Message}");
                }
                catch (Exception ex) // Lỗi hệ thống chung
                {
                    DialogMessageView.ShowMessage("error", $"An error occurred: {ex.Message}");
                }
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
                            if (accountRepository.GetPasswordByID(staffDetailView.StaffId) != EncryptPassword.HashPassword(staffDetailView.StaffInformationControl.txtOldPassword.Text))
                            {
                                ErrorMessage("Input Wrong Old Password");
                            }
                            else
                            {
                                if (staffDetailView.StaffInformationControl.txtNewPassword.Text != staffDetailView.StaffInformationControl.txtConfirmPassword.Text)
                                {
                                    ErrorMessage("Password does not match,please check again");
                                }
                                else
                                {
                                    try
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
                                        Account updatedPassword = new Account
                                        {
                                            Password = EncryptPassword.HashPassword(staffDetailView.StaffInformationControl.txtNewPassword.Text),
                                            StaffID = staffDetailView.StaffId
                                        };
                                        if (staffDetailView.IsEdit)
                                        {                                            
                                            repository.Edit(updatedStaff);
                                            repository.SaveAvatar(staffDetailView.HasAvatar, updatedStaff);
                                            accountRepository.ChangePasswordByID(updatedPassword);                                            
                                            staffDetailView.InitializeControl();
                                            LoadStaffDetails();
                                        }                                        
                                        DialogMessageView.ShowMessage("success", "Updated Successfully");
                                    }
                                    catch (ValidationException ex) // Xử lý lỗi validate
                                    {
                                        DialogMessageView.ShowMessage("error", $"Validation Error: {ex.Message}");
                                    }                                    
                                    catch (Exception ex) // Lỗi hệ thống chung
                                    {
                                        DialogMessageView.ShowMessage("error", $"An unexpected error occurred: {ex.Message}");
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="avatarPath"></param>
        /// <returns></returns>
        private string SaveAvatar(string avatarPath)
        {
            if(!string.IsNullOrEmpty(avatarPath))
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
            staffDetailView.IsChangePass = false;
            InitializeHideMessage();
            staffDetailView.StaffInformationControl.checkBoxShowPassword.Checked = false;
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
            InitializeHideMessage();
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
       
        /// <summary>
        /// Show password when checkbox change 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void ShowPasswordEvent(object sender, EventArgs e)
        {
            if (staffDetailView.StaffInformationControl.checkBoxShowPassword.Checked)
            {
                staffDetailView.StaffInformationControl.txtOldPassword.PasswordChar = '\0';
                staffDetailView.StaffInformationControl.txtNewPassword.PasswordChar = '\0';
                staffDetailView.StaffInformationControl.txtConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                staffDetailView.StaffInformationControl.txtOldPassword.PasswordChar = '●';
                staffDetailView.StaffInformationControl.txtNewPassword.PasswordChar = '●';
                staffDetailView.StaffInformationControl.txtConfirmPassword.PasswordChar = '●';
            }
        }
        /// <summary>
        /// Initialize Hide Message 
        /// </summary>
        private void InitializeHideMessage()
        {
            this.staffDetailView.StaffInformationControl.lbErrorMessage.Text = "";
            this.staffDetailView.StaffInformationControl.txtOldPassword.BorderColor = Color.FromArgb(213, 218, 223);
            this.staffDetailView.StaffInformationControl.txtNewPassword.BorderColor = Color.FromArgb(213, 218, 223);
            this.staffDetailView.StaffInformationControl.txtConfirmPassword.BorderColor = Color.FromArgb(213, 218, 223);
            this.staffDetailView.StaffInformationControl.txtNewPassword.Text = "";
            this.staffDetailView.StaffInformationControl.txtOldPassword.Text = "";
            this.staffDetailView.StaffInformationControl.txtConfirmPassword.Text = "";
        }
        #endregion

        #region Public Fields
        #endregion
    }
}

using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShop.Utilities;
using System.IO;

namespace CoffeeShop.View.MainFrame
{
    public partial class StaffInformationControl : UserControl
    {
        #region Fields

        /// <summary>
        /// biến lưu đường dẫn đến file ảnh của nhân viên
        /// </summary>
        private string avatarPath;

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public string TxtStaffName
        {
            get { return txtStaffName.Text; } //lấy giá trị từ textbox
            set { txtStaffName.Text = value; } //gán giá trị vào textbox
        }
        /// <summary>
        /// 
        /// </summary>
        public string TxtPhone
        {
            get { return txtPhone.Text; }
            set { txtPhone.Text = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TxtEmail
        {
            get { return txtEmail.Text; }
            set { txtEmail.Text = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Male
        {
            get => rdoMale.Checked;
            set => rdoMale.Checked = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Female
        {
            get => rdoFemale.Checked;
            set => rdoFemale.Checked = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool RdoOther
        {
            get => rdoOther.Checked;
            set => rdoOther.Checked = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public string DateOfBirth
        {
            get => dtpDob.Text;
            set => dtpDob.Text = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public string StaffRole
        {
            get => txtRole.Text;
            set => txtRole.Text = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Avatar
        {
            get => avatarPath;  //trả về đường dẫn của ảnh đại diện
            set
            {
                avatarPath = value; //gán đường dẫn ảnh
                if(!string.IsNullOrEmpty(avatarPath))
                {
                    //nếu khác rỗng thì tải ảnh lên PictureBox từ đường dẫn được tạo bằng cách nối Application.StartupPath với đường dẫn của file ảnh
                    picAvatar.ImageLocation = Path.Combine(Application.StartupPath, AppConst.IMAGE_SOURCE_PATH, avatarPath);
                    picAvatar.SizeMode = PictureBoxSizeMode.StretchImage; //tuy chinh anh
                }
                else
                {
                    picAvatar.Image = null; //anh mac dinh neu co
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public PictureBox ProfilePicture
        {
            get { return picAvatar; }
        }

        #endregion

        /// <summary>
        /// Contructors
        /// </summary>
        public StaffInformationControl()
        {
            InitializeComponent();
        }

        #region Method
        // Method to add event

        //gán sự kiện click cho nút edit
        public void EditButtonClickHandler(EventHandler handler)
        {
            btnEdit.Click += handler;
        }
        //gán sk click cho nút Save
        public void SaveButtonClickHandler(EventHandler handler)
        {
            btnSave.Click += handler;
        }
        //gán sự kiện click cho nút cancel
        public void CancelButtonClickHandler(EventHandler handler)
        {
            btnCancel.Click += handler;
        }
        public void ChangePasswordButtonClickedHandler(EventHandler handler)
        {
             lbChangePassword.Click += handler;
        }
        #endregion      
    }
}

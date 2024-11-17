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
        private string avatarPath;

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public string TxtStaffName
        {
            get { return txtStaffName.Text; }
            set { txtStaffName.Text = value; }
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

        public string Avatar
        {
            get => avatarPath;
            set
            {
                avatarPath = value;
                if(!string.IsNullOrEmpty(avatarPath))
                {
                    picAvatar.ImageLocation = Path.Combine(Application.StartupPath, AppConst.IMAGE_SOURE_PATH, avatarPath);
                    picAvatar.SizeMode = PictureBoxSizeMode.StretchImage; //tuy chinh anh
                }
                else
                {
                    picAvatar.Image = null; //anh mac dinh neu co
                }
            }
        }

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
        public void EditButtonClickHandler(EventHandler handler)
        {
            btnEdit.Click += handler;
        }
        public void SaveButtonClickHandler(EventHandler handler)
        {
            btnSave.Click += handler;
        }
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

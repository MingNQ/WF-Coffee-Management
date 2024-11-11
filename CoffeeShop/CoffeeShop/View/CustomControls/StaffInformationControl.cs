using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View.MainFrame
{
    public partial class StaffInformationControl : UserControl
    {
        /// <summary>
        /// Contructors
        /// </summary>
        public StaffInformationControl()
        {
            InitializeComponent();
        }
       
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
            get => cbRole.Text;
            set => cbRole.Text = value;
        }
        #endregion

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
        public void ImportButtonClickHandler(EventHandler handler) 
        { 
            btnImport.Click += handler; 
        }
        public void CancelButtonClickHandler(EventHandler handler)
        {
            btnCancel.Click += handler;
        }
        public void ChangePasswordButtonClickedHandler(EventHandler handler)
        {
            btnChangePassword.Click += handler;
        }
        #endregion
    }
}

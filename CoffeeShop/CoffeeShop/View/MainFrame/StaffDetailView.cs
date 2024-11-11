using CoffeeShop.View.MainFrame.Interfaces;
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
    public partial class StaffDetailView : Form, IStaffDetailView
    {
        #region Fields
        private readonly StaffInformationControl staffInformationControl;

        /// <summary>
        /// Instance for Staff Detail Information
        /// </summary>
        private static StaffDetailView instance;

        /// <summary>
        /// Check if edit
        /// </summary>
        private bool isEdit;

        /// <summary>
        /// Check if Succesful
        /// </summary>
        private bool isSuccessful;

        /// <summary>
        /// 
        /// </summary>
        private string staffID;

        #endregion

        #region Properties
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value;}
        }
        public string StaffName 
        { 
            get => staffInformationControl.txtStaffName.Text;
            set => staffInformationControl.txtStaffName.Text = value;
        }

        public string PhoneNumber 
        {
            get => staffInformationControl.txtPhone.Text;
            set => staffInformationControl.txtPhone.Text = value;
        }
        public string DateOfBirth 
        {
            get => staffInformationControl.dtpDob.Text;
            set => staffInformationControl.dtpDob.Text = value;
        }
        public string Email 
        {
            get => staffInformationControl.txtEmail.Text; 
            set => staffInformationControl.txtEmail.Text = value;
        }
        public string StaffRole
        {
            get => staffInformationControl.cbRole.Text;
            set => staffInformationControl.cbRole.Text = value;
        }
        public bool Male 
        {
            get => staffInformationControl.rdoMale.Checked; 
            set => staffInformationControl.rdoMale.Checked = value;
        }
        public bool Female
        {
            get => staffInformationControl.rdoFemale.Checked;
            set => staffInformationControl.rdoFemale.Checked = value;
        }
        public bool Other
        {
            get => staffInformationControl.rdoOther.Checked;
            set => staffInformationControl.rdoOther.Checked = value;
        }
        public string StaffId 
        {
            get => staffID;
            set => staffID = value;
        }
        public bool IsSuccesful
        {
            get { return isSuccessful; }
            set { isSuccessful = value; }
        }

        public StaffInformationControl StaffInformationControl
        {
            get { return staffInformationControl; }
            //set { staffInformationControl = value; }
        }

        

        #endregion
        public StaffDetailView()
        {
            InitializeComponent();
            // Khởi tạo User Control 
            staffInformationControl = new StaffInformationControl();  
            this.Controls.Add(staffInformationControl);
            staffInformationControl.Dock = DockStyle.Fill;
            // Khởi tạo giá trị ban đầu của staffInformationControl
            staffInformationControl.btnSave.Enabled = false;
            staffInformationControl.btnCancel.Enabled = false;
            staffInformationControl.txtStaffName.Enabled = false;
            staffInformationControl.txtEmail.Enabled = false;
            staffInformationControl.txtPhone.Enabled = false;
            staffInformationControl.rdoFemale.Enabled = false;
            staffInformationControl.rdoMale.Enabled = false;
            staffInformationControl.rdoOther.Enabled = false;
            staffInformationControl.cbRole.Enabled = false;
            staffInformationControl.dtpDob.Enabled = false;
            // Đăng kí các sự kiện 
            AssociateAndRaiseEvents();
            // Khởi tạo giá trị Items của ComboBox
            InitializeComboBoxRole();
        }
        private void AssociateAndRaiseEvents()
        {
            staffInformationControl.btnEdit.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                staffInformationControl.btnEdit.Enabled = false;
                staffInformationControl.btnCancel.Enabled = true;
                staffInformationControl.btnSave.Enabled = true;
                staffInformationControl.btnImport.Enabled = true;
                staffInformationControl.txtStaffName.Enabled = true;
                staffInformationControl.txtEmail.Enabled = true;
                staffInformationControl.txtPhone.Enabled = true;
                staffInformationControl.rdoFemale.Enabled = true;
                staffInformationControl.rdoMale.Enabled = true;
                staffInformationControl.rdoOther.Enabled = true;
                staffInformationControl.cbRole.Enabled = true;
                staffInformationControl.dtpDob.Enabled = true;
            };
            staffInformationControl.btnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                staffInformationControl.btnEdit.Enabled = true;
                staffInformationControl.btnCancel.Enabled = false;
                staffInformationControl.btnSave.Enabled = false;
                staffInformationControl.btnImport.Enabled = false;
                staffInformationControl.txtStaffName.Enabled = false;
                staffInformationControl.txtEmail.Enabled = false;
                staffInformationControl.txtPhone.Enabled = false;
                staffInformationControl.rdoFemale.Enabled = false;
                staffInformationControl.rdoMale.Enabled = false;
                staffInformationControl.rdoOther.Enabled = false;
                staffInformationControl.cbRole.Enabled = false;
                staffInformationControl.dtpDob.Enabled = false;
            };
            staffInformationControl.btnCancel.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                staffInformationControl.btnEdit.Enabled = true;
                staffInformationControl.btnCancel.Enabled = false;
                staffInformationControl.btnSave.Enabled = false;
                staffInformationControl.btnImport.Enabled = false;
                staffInformationControl.txtStaffName.Enabled = false;
                staffInformationControl.txtEmail.Enabled = false;
                staffInformationControl.txtPhone.Enabled = false;
                staffInformationControl.rdoFemale.Enabled = false;
                staffInformationControl.rdoMale.Enabled = false;
                staffInformationControl.rdoOther.Enabled = false;
                staffInformationControl.cbRole.Enabled = false;
                staffInformationControl.dtpDob.Enabled = false;
            };
            staffInformationControl.btnImport.Click += delegate
            {
                ImportEvent?.Invoke(this, EventArgs.Empty);
            };
        }
        private void InitializeComboBoxRole()
        {
            staffInformationControl.cbRole.Items.Add("Quản Lý");
            staffInformationControl.cbRole.Items.Add("Pha chế");
            staffInformationControl.cbRole.Items.Add("Phục vụ");
        }
        #region public fields
        /// <summary>
        /// Get Instance for StaffDetailInformation
        /// </summary>
        /// <param name="parentContainer">Parent Container</param>
        /// <returns>Instance</returns>
        #endregion
        public static StaffDetailView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new StaffDetailView();
                instance.MdiParent = parentContainer;
                instance.Dock = DockStyle.Fill;
            }
            else
            {
                if(instance.WindowState == FormWindowState.Minimized)
                {
                    instance.WindowState = FormWindowState.Normal;
                }    
                instance.BringToFront();
            }
            return instance;
        }



        #region Event
        public event EventHandler ImportEvent;
        public event EventHandler EditEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;
        public event EventHandler ChangePasswordEvent;
        #endregion
    }
}

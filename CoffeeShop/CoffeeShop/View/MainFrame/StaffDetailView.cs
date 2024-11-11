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
        /// StaffID
        /// </summary>
        private string staffID;

        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value;}
        }
        /// <summary>
        /// 
        /// </summary>
        public string StaffName 
        { 
            get => staffInformationControl.txtStaffName.Text;
            set => staffInformationControl.txtStaffName.Text = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber 
        {
            get => staffInformationControl.txtPhone.Text;
            set => staffInformationControl.txtPhone.Text = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public string DateOfBirth 
        {
            get => staffInformationControl.dtpDob.Text;
            set => staffInformationControl.dtpDob.Text = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email 
        {
            get => staffInformationControl.txtEmail.Text; 
            set => staffInformationControl.txtEmail.Text = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public string StaffRole
        {
            get => staffInformationControl.cbRole.Text;
            set => staffInformationControl.cbRole.Text = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Male 
        {
            get => staffInformationControl.rdoMale.Checked; 
            set => staffInformationControl.rdoMale.Checked = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Female
        {
            get => staffInformationControl.rdoFemale.Checked;
            set => staffInformationControl.rdoFemale.Checked = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Other
        {
            get => staffInformationControl.rdoOther.Checked;
            set => staffInformationControl.rdoOther.Checked = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public string StaffId 
        {
            get => staffID;
            set => staffID = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsSuccesful
        {
            get { return isSuccessful; }
            set { isSuccessful = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public StaffInformationControl StaffInformationControl
        {
            get { return staffInformationControl; }
        }

        #endregion
        /// <summary>
        /// Constructor
        /// </summary>
        public StaffDetailView()
        {
            InitializeComponent();
            // Khởi tạo User Control 
            staffInformationControl = new StaffInformationControl();  
            this.Controls.Add(staffInformationControl);
            staffInformationControl.Dock = DockStyle.Fill;
            // Khởi tạo giá trị ban đầu của staffInformationControl
            InitializeControl();
            // Đăng kí các sự kiện 
            AssociateAndRaiseEvents();
            // Khởi tạo giá trị Items của ComboBox
            InitializeComboBoxRole();
        }
        #region Private Fields
        /// <summary>
        /// Initialize unit in Control
        /// </summary>
        private void InitializeControl()
        {
            staffInformationControl.btnEdit.Enabled = true;
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
        }
        /// <summary>
        /// Initialize unit when click Edit
        /// </summary>
        private void initializeAfterClickEdit()
        {
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
        }

        /// <summary>
        /// Associate and Raise Event
        /// </summary>
        private void AssociateAndRaiseEvents()
        {
            staffInformationControl.btnEdit.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                initializeAfterClickEdit();
            };
            staffInformationControl.btnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                InitializeControl();
            };
            staffInformationControl.btnCancel.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                InitializeControl();
            };
            staffInformationControl.btnImport.Click += delegate
            {
                ImportEvent?.Invoke(this, EventArgs.Empty);
            };
        }
        /// <summary>
        /// Initialize Combobox Role
        /// </summary>
        private void InitializeComboBoxRole()
        {
            staffInformationControl.cbRole.Items.Add("Quản Lý");
            staffInformationControl.cbRole.Items.Add("Pha chế");
            staffInformationControl.cbRole.Items.Add("Phục vụ");
        }
        #endregion

        #region Public fields
        /// <summary>
        /// Get Instance for StaffDetailInformation
        /// </summary>
        /// <param name="parentContainer">Parent Container</param>
        /// <returns>Instance</returns>

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
        #endregion

        #region Event
        public event EventHandler ImportEvent;
        public event EventHandler EditEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;
        public event EventHandler ChangePasswordEvent;
        #endregion
    }
}

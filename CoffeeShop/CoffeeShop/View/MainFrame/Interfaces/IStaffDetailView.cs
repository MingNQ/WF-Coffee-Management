using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View.MainFrame.Interfaces
{
    public interface IStaffDetailView
    {
        #region Fields - Properties
        StaffInformationControl StaffInformationControl { get; }
        string StaffId { get; set; }
        string StaffName { get; set; }
        string PhoneNumber { get; set; }
        string DateOfBirth { get; set; }
        string Email { get; set; }
        string StaffRole { get; set; }
        bool Male { get; set; }
        bool Female { get; set; }
        bool Other { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccesful { get; set; }
        bool IsOpen { get; }
        bool HasAvatar { get; set; }
        bool IsChangePass { get; set; }
        #endregion

        #region Events
        event EventHandler ImportEvent;
        event EventHandler EditEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;
        event EventHandler ChangePasswordEvent;
        event EventHandler HideMessageEvent;
        event EventHandler ShowPasswordEvent;
        #endregion

        #region Methods
        void Show();
        void InitializeControl();
        #endregion
    }
}

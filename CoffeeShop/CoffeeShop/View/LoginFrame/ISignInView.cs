using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.View.LoginFrame
{
    public interface ISignInView
    {
        #region Properties - Fields
        Guna2TextBox TxtUsername { get; set; }
        Guna2TextBox TxtPassword { get; set; }

        string Message { get; set; }
        bool ShowPassword { get; set; }
        char PasswordChar { get; set; }

        #endregion

        #region Events

        event EventHandler LoginEvent;
        event EventHandler BackSignUpEvent;
        event EventHandler ShowPasswordEvent;
        event EventHandler HideMessage;

        #endregion

        void Show();
    }
}

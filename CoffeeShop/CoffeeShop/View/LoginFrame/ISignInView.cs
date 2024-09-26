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

        string Username { get; set; }
        string Password { get; set; }
        string Message { get; set; }
        bool ShowPassword { get; set; }
        char PasswordChar { get; set; }

        #endregion

        #region Events

        event EventHandler LoginEvent;
        event EventHandler SignUpEvent;
        event EventHandler ShowPasswordEvent;

        #endregion

        void Show();
    }
}

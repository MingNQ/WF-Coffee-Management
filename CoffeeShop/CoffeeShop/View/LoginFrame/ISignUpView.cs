using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.View.LoginFrame
{
    public interface ISignUpView
    {
        #region Fields - Property
        /// <summary>
        /// Username 
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Confirm Password to Check
        /// </summary>
        string ConfirmPassword { get; set; }

        /// <summary>
        /// Message for something...
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// If Password is show or nor
        /// </summary>
        bool ShowPassword { get; set; }

        /// <summary>
        /// Hidden Password by PasswordChar
        /// </summary>
        char PasswordChar { get; set; }

        #endregion

        #region Events

        event EventHandler SignUpEvent;
        event EventHandler ShowPasswordEvent;
        event EventHandler BackSignInEvent;

        #endregion

        /// <summary>
        /// Set Password char
        /// </summary>
        /// <param name="">passwordChar</param>
        void SetPasswordChar(char _passwordChar);

        /// <summary>
        /// Show Form
        /// </summary>
        void Show();
    }
}

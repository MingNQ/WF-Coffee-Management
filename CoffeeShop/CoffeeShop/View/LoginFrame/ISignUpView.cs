using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View.LoginFrame
{
    public interface ISignUpView
    {
        #region Fields - Property
        /// <summary>
        /// 
        /// </summary>
        Guna2TextBox TxtUsername { get; set; }

        /// <summary>
        /// 
        /// </summary>
        Guna2TextBox TxtPassword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        Guna2TextBox TxtConfirmPassword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        Guna2TextBox TxtEmail { get; set; }

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
        event EventHandler HideMessageEvent;

        #endregion

        #region Methods
        /// <summary>
        /// Set Password char
        /// </summary>
        /// <param name="">passwordChar</param>
        void SetPasswordChar(char _passwordChar);

        /// <summary>
        /// Show Form
        /// </summary>
        void Show();
        #endregion
    }
}

using CoffeeShop.View.LoginFrame;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View
{
    public partial class SignUp : Form, ISignUpView
    {
        #region Fields

        /// <summary>
        /// Initial PasswordChar
        /// </summary>
        private char passwordChar = '●';

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public SignUp()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            SetPasswordChar(passwordChar);
        }

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public Guna2TextBox TxtUsername { get => txtUsername; set => txtUsername = value; }

        /// <summary>
        /// 
        /// </summary>
        public Guna2TextBox TxtPassword { get => txtPassword; set => txtPassword = value; }

        /// <summary>
        /// 
        /// </summary>
        public Guna2TextBox TxtConfirmPassword { get => txtConfirmPassword; set => txtConfirmPassword = value; }

        /// <summary>
        /// 
        /// </summary>
        public Guna2TextBox TxtEmail { get => txtEmail; set => txtEmail = value; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get => lblMessage.Text; set => lblMessage.Text = value; }

        /// <summary>
        /// Is Show Password or not
        /// </summary>
        public bool ShowPassword { get => chkShowPassword.Checked; set => chkShowPassword.Checked = value; }

        /// <summary>
        /// Hidden password by PasswordChar
        /// </summary>
        public char PasswordChar { get => passwordChar; set => passwordChar = value; }

        #endregion

        #region Events
        /// <summary>
        /// Event when button SignUp Click
        /// </summary>
        public event EventHandler SignUpEvent;

        /// <summary>
        /// Event when checkbox ShowPassword is checkd
        /// </summary>
        public event EventHandler ShowPasswordEvent;

        /// <summary>
        /// Event Back to Sign In Form
        /// </summary>
        public event EventHandler BackSignInEvent;

        /// <summary>
        /// Event Hide message warning
        /// </summary>
        public event EventHandler HideMessageEvent;
        #endregion

        #region private fields

        /// <summary>
        /// Associate and Raise View Events
        /// </summary
        private void AssociateAndRaiseViewEvents()
        {
            // SignUp event
            btnSignUp.Click += delegate { SignUpEvent?.Invoke(this, EventArgs.Empty); };
            // If press key Enter when type password -> Login Event
            txtConfirmPassword.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SignUpEvent?.Invoke(this, EventArgs.Empty);
            };

            // When user typing hide warning message
            txtUsername.KeyDown += delegate { HideMessageEvent?.Invoke(this, EventArgs.Empty); };
            txtEmail.KeyDown += delegate { HideMessageEvent?.Invoke(this, EventArgs.Empty); };
            txtPassword.KeyDown += delegate { HideMessageEvent?.Invoke(this, EventArgs.Empty); };
            txtConfirmPassword.KeyDown += delegate { HideMessageEvent?.Invoke(this, EventArgs.Empty); };

            // SignUp Event
            btnSignIn.Click += delegate { BackSignInEvent?.Invoke(this, EventArgs.Empty); };

            // Show password Event
            chkShowPassword.CheckedChanged += delegate { ShowPasswordEvent?.Invoke(this, EventArgs.Empty); };
        }
        #endregion

        #region public fields

        /// <summary>
        /// Set PasswordChar for hidden
        /// </summary>
        /// <param name="_passwordChar">Password Char</param>
        public void SetPasswordChar(char _passwordChar)
        {
            txtPassword.PasswordChar = _passwordChar;
            txtConfirmPassword.PasswordChar = _passwordChar;
        }
        #endregion
    }
}

using CoffeeShop.View.LoginFrame;
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
        /// Using message for notify user
        /// </summary>
        private string message;

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
        /// Username
        /// </summary>
        public string Username { get => txtUsername.Text; set => txtUsername.Text = value; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get => txtEmail.Text; set => txtEmail.Text = value; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get => txtPassword.Text; set => txtPassword.Text = value; }

        /// <summary>
        /// Confirm password
        /// </summary>
        public string ConfirmPassword { get => txtConfirmPassword.Text; set => txtConfirmPassword.Text = value; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get => message; set => message = value; }

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

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
    public partial class SignIn : Form, ISignInView
    {
        #region Fields
        private string message;
        private char passwordChar;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public SignIn()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        #region Properties

        /// <summary>
        /// Username
        /// </summary>
        public string Username
        {
            get { return txtUsername.Text; }
            set { txtUsername.Text = value; }
        }

        /// <summary>
        /// Password
        /// </summary>
        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get { return message; } set { message = value; } }
        
        /// <summary>
        /// Is Checkbox ShowPassword or not
        /// </summary>
        public bool ShowPassword 
        { 
            get { return chkShowPassword.Checked; } 
            set { chkShowPassword.Checked = value; } 
        }

        /// <summary>
        /// PasswordChar Secure Password
        /// </summary>
        public char PasswordChar
        {
            get { return txtPassword.PasswordChar; }
            set { txtPassword.PasswordChar = value; }
        }

        #endregion

        #region Event

        public event EventHandler LoginEvent;
        public event EventHandler SignUpEvent;
        public event EventHandler ShowPasswordEvent;

        #endregion

        #region private fields

        /// <summary>
        /// Associate and Raise View Events
        /// </summary>
        private void AssociateAndRaiseViewEvents()
        {
            // Login event
            btnLogin.Click += delegate { LoginEvent?.Invoke(this, EventArgs.Empty); };
            // If press key Enter when type password -> Login Event
            txtPassword.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    LoginEvent?.Invoke(this, EventArgs.Empty);
            };

            // SignUp Event
            btnSignUp.Click += delegate { SignUpEvent?.Invoke(this, EventArgs.Empty); };

            // Show password Event
            chkShowPassword.CheckedChanged += delegate { ShowPasswordEvent?.Invoke(this, EventArgs.Empty); };
        }
        #endregion
    }
}

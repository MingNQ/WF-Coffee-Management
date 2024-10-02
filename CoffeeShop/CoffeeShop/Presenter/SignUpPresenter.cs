using CoffeeShop.View.LoginFrame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.Presenter
{
    public class SignUpPresenter
    {
        #region Fields
        
        /// <summary>
        /// Interface 
        /// </summary>
        private ISignUpView signUpView;
        
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="view">View</param>
        public SignUpPresenter(ISignUpView view)
        {
            this.signUpView = view;

            // Add event
            this.signUpView.SignUpEvent += SignUpAccount;
            this.signUpView.BackSignInEvent += SignInAccount;
            this.signUpView.ShowPasswordEvent += ShowPassword;
            this.signUpView.HideMessageEvent += HideMessage;

            // Show Form
            this.signUpView.Show();
        }

        #region private fields

        /// <summary>
        /// Sign Up Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignUpAccount(object sender, EventArgs e)
        {
            // TO-DO: Check not null
            // TO-DO: Connect Database to check User Account
            // TO-DO: Check if user is exist
            bool existUser = false;

            // Test
            if (!existUser)
            {
                // TO-DO: If user valid check password
                // TO-DO: Check valid email
                if (signUpView.TxtPassword.Text == signUpView.TxtConfirmPassword.Text 
                    && signUpView.TxtPassword.Text != "")
                {
                    MessageBox.Show("Sign Up Successful!");
                }
                else
                {
                    signUpView.TxtConfirmPassword.Text = "";
                    signUpView.TxtConfirmPassword.BorderColor = Color.Red;
                    signUpView.Message = "*Password may be incorrect.";
                }
            } 
            else
            {
                // TO-DO: If user is exist
                signUpView.TxtUsername.BorderColor = Color.Red;
            }
            
        }

        /// <summary>
        /// Back Form Sign In View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignInAccount(object sender, EventArgs e)
        {
            // TO-DO: Hide this Form and Show SignIn Form
        }

        /// <summary>
        /// Show password Checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowPassword(object sender, EventArgs e)
        {
            this.signUpView.PasswordChar = this.signUpView.ShowPassword ? '\0' : '●';
            this.signUpView.SetPasswordChar(this.signUpView.PasswordChar);
        }

        /// <summary>
        /// Hide Message Warning
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HideMessage(object sender, EventArgs e)
        {
            this.signUpView.TxtUsername.BorderColor = Color.FromArgb(213, 218, 223);
            this.signUpView.TxtEmail.BorderColor = Color.FromArgb(213, 218, 223);
            this.signUpView.TxtPassword.BorderColor = Color.FromArgb(213, 218, 223);
            this.signUpView.TxtConfirmPassword.BorderColor = Color.FromArgb(213, 218, 223);
        }
        #endregion

        #region public fields
        
        #endregion
    }
}

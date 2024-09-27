using CoffeeShop.View.LoginFrame;
using System;
using System.Collections.Generic;
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
            // TO-DO: Connect Database to check User Account
            // Test
            if (signUpView.Password == signUpView.ConfirmPassword)
            {
                MessageBox.Show("Sign Up Successful!");
            } 
            else
            {
                MessageBox.Show("Sign Up Fail! Please Try Again!");
                signUpView.Password = "";
                signUpView.ConfirmPassword = "";
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
        #endregion
    }
}

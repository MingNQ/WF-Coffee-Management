using CoffeeShop.View.LoginFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.Presenter
{
    public class SignInPresenter
    {
        #region Fields
        /// <summary>
        /// Sign in form view
        /// </summary>
        private ISignInView signInView;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="view">View</param>
        public SignInPresenter(ISignInView view)
        {
            this.signInView = view;

            // Add event
            this.signInView.LoginEvent += LoginAccount;
            this.signInView.SignUpEvent += SignUpAccount;
            this.signInView.ShowPasswordEvent += ShowPassword;

            // Show Form
            this.signInView.Show();
        }

        #region private fields

        /// <summary>
        /// Check Login Account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginAccount(object sender, EventArgs e)
        {
            // TO-DO: Connect database to check Account

            // Temporary: Check Account login
            if (this.signInView.Username != "admin" || this.signInView.Password != "123")
            {
                MessageBox.Show("Username or Password is incorrect! Please Try again!");
                this.signInView.Password = "";
                return;
            }
            MessageBox.Show("Login Successful!");
        }

        /// <summary>
        /// Show Sign Up Account Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignUpAccount(object sender, EventArgs e)
        {
            // TO-DO: SignUp event to open SignUp Form
        }

        /// <summary>
        /// If is Showpassword -> Show and vice versa 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowPassword(object sender, EventArgs e)
        {
            // '\0' meaning no hidden char -> Show
            this.signInView.PasswordChar = this.signInView.ShowPassword ? '\0' : '●';
        }
        #endregion
    }
}

using CoffeeShop._Repositories;
using CoffeeShop.Model;
using CoffeeShop.Model.InterfaceModel;
using CoffeeShop.Presenter.Common;
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
    public class SignInPresenter
    {
        #region Fields
        /// <summary>
        /// Sign in form view
        /// </summary>
        private ISignInView signInView;

        /// <summary>
        /// Connection String
        /// </summary>
        private readonly string sqlConnectionString;

        /// <summary>
        /// Account repository
        /// </summary>
        private IAccountRepository repository;

        /// <summary>
        /// Binding Source
        /// </summary>
        private BindingSource accountBindingSource;

        /// <summary>
        /// account list
        /// </summary>
        private IEnumerable<Account> accounts;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="view">View</param>
        public SignInPresenter(ISignInView view, string sqlConnectionString)
        {
            // Init
            this.signInView = view;
            this.sqlConnectionString = sqlConnectionString;
            this.repository = new AccountRepository(sqlConnectionString);
            this.accountBindingSource = new BindingSource();
            this.accounts = repository.GetAll();

            // Add event
            this.signInView.LoginEvent += LoginAccount;
            this.signInView.BackSignUpEvent += SignUpAccount;
            this.signInView.ShowPasswordEvent += ShowPassword;
            this.signInView.HideMessage += HideMessage;

            // Show Form
            this.signInView.Show();
        }

        #region private fields

        /// <summary>
        /// Check Login account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginAccount(object sender, EventArgs e)
        {
            // Connect database to check account
            var account = accounts.Where(a => a.Username == signInView.TxtUsername.Text
                                           && a.Password == EncryptPassword.HashPassword(signInView.TxtPassword.Text)).FirstOrDefault();

            // Check value is not null
            if (string.IsNullOrEmpty(signInView.TxtUsername.Text) ||
                string.IsNullOrEmpty(signInView.TxtPassword.Text))
            {
                signInView.Successful = false;
                SignInError("*Your username or password must not null!");
                return;
            }

            if (account != null)
            {
                if (!account.Active)
                {
                    signInView.Successful = false;
                    SignInError("*Your account is not active!");
                    return;
                }

                // Succesful
                signInView.Successful = true;
                signInView.Account = account;
                return;
            }

            // If Not Ok
            signInView.Successful = false;
            SignInError("*Your username or password may be incorrect!");
        }

        /// <summary>
        /// Show Sign Up account Form
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

        /// <summary>
        /// When user type hide warning message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HideMessage(object sender, EventArgs e)
        {
            this.signInView.Message = "";
            this.signInView.TxtUsername.BorderColor = Color.FromArgb(213, 218, 223);
            this.signInView.TxtPassword.BorderColor = Color.FromArgb(213, 218, 223);
            this.signInView.TxtPassword.Text = "";
        }

        /// <summary>
        /// Notify Error with Message
        /// </summary>
        /// <param name="message"></param>
        private void SignInError(string message)
        {
            this.signInView.Message = message;
            this.signInView.TxtUsername.BorderColor = Color.Red;
            this.signInView.TxtPassword.BorderColor = Color.Red;
        }
        #endregion
    }
}

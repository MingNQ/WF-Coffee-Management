using CoffeeShop.Utilities;
using CoffeeShop.View;
using CoffeeShop.View.DialogForm;
using CoffeeShop.View.LoginFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoffeeShop.Presenter
{
    public class PrimaryPresenter
    {
        #region Fields

        /// <summary>
        /// Connection String
        /// </summary>
        private readonly string connectionString;

        /// <summary>
        /// 
        /// </summary>
        private ISignInView signInView;

        /// <summary>
        /// 
        /// </summary>
        private IMainView mainView;

        #endregion

        #region Events
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public PrimaryPresenter(ISignInView signInView, IMainView mainView, string connectionString)
        {
            // Init
            this.signInView = signInView;
            this.mainView = mainView;
            this.connectionString = connectionString;

            // Show Sign In First
            new SignInPresenter(signInView, connectionString);

            // Raise Events
            this.signInView.LoginEvent += LoginEvent;
            this.mainView.LogoutEvent += LogoutEvent;
        }

        #region private fields

        /// <summary>
        /// If Login Successful Hide and Show Home View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginEvent(object sender, EventArgs e)
        {
            if (signInView.Successful)
            {
                signInView.Hide();

                // Get Username and Role
                Generate.StaffID = signInView.Account.Staff.StaffID;
                Generate.StaffName = signInView.Account.Staff.StaffName.Trim();
                Generate.StaffRole = signInView.Account.Staff.Role;

                new MainPresenter(mainView, connectionString);

                // Display
                mainView.Username = "Hello, " + Generate.StaffName.Split(' ').LastOrDefault() + "!";
                mainView.Role = Generate.StaffRole;
                mainView.StaffID = Generate.StaffID;
            }
        }

        /// <summary>
        /// Logout 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogoutEvent(object sender, EventArgs e)
        {
            if (DialogMessageView.ShowMessage("notify", "Are you sure to Exit?") == System.Windows.Forms.DialogResult.OK)
            {
                signInView.TxtPassword.Text = "";
                signInView.ShowPassword = false;
                signInView.Show();
                mainView.Hide();
            }
        }

        #endregion
    }
}

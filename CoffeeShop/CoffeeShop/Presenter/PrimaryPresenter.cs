using CoffeeShop.View;
using CoffeeShop.View.LoginFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                new MainPresenter(mainView, connectionString);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogoutEvent(object sender, EventArgs e)
        {
            signInView.Show();
            mainView.Hide();
        }

        #endregion
    }
}

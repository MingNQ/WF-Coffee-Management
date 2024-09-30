using CoffeeShop.Presenter;
using CoffeeShop.View;
using CoffeeShop.View.LoginFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IMainView mainView = new MainView();
            new MainPresenter(mainView);

            ISignInView signInView = new SignIn();
            new SignInPresenter(signInView);

            //ISignUpView signUpView = new SignUp();
            //new SignUpPresenter(signUpView);
            Application.Run((Form)signInView);
        }
    }
}

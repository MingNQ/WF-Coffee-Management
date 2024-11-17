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
            //string sqlConnectionString = "Data Source=DESKTOP-04URNFP;Initial Catalog=CoffeeDB;Integrated Security=True;Encrypt=False";
            //string sqlConnectionString = "Data Source=ITK-20221221TUA\\SQLEXPRESS;Initial Catalog=CoffeeDB;Integrated Security=True;Encrypt=False";
            string sqlConnectionString = "Data Source=HAIDEPZAI;Initial Catalog=CoffeeDB;Integrated Security=True";

            IMainView mainView = new MainView();
            ISignInView signInView = new SignIn();

            new PrimaryPresenter(signInView, mainView, sqlConnectionString);
            Application.Run((Form)signInView);
        }
    }
}

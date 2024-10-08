﻿using CoffeeShop.Presenter;
using CoffeeShop.View;
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
            Application.Run((Form)mainView);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.View.DialogCheckList
{
    public interface IEditCategoryView
    {
        string TittleHeader { get; set; }

        /// <summary>
        /// Show Diaglog
        /// </summary>
        void ShowDialog();

        /// <summary>
        /// Hide Dialog
        /// </summary>
        void Hide();

    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    public class CategoryModel
    {
        #region Fields
        private int categoryID;
        private string categoryName;
        #endregion

        #region Properties
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
        #endregion
    }
}
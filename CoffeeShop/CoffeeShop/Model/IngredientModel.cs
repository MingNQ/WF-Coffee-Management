﻿using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Model
{
    public class IngredientModel
    {
        #region Fields

        private string ingredientID;
        private string ingredientName;

        #endregion

        #region Properties 

        [DisplayName("Ingredient ID")]
        public string IngredientID { get { return ingredientID; } set { ingredientID = value; } }

        [DisplayName("Ingredient Name")]
        [Required(ErrorMessage = "Ingredient name is required")]
        [RegularExpression(@"^[\p{L}\s]+$", ErrorMessage = "Ingredient name can't contain number or special characters")]
        [StringLength(50)]
        public string IngredientName { get { return ingredientName; } set { ingredientName = value; } }

        #endregion
    }
}
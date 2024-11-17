using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View.DialogForm
{
	public interface IEditIngredientView
	{
        #region Fields - Properties
        string TittleHeader { get; set; }
        string IngredientName { get; set; }
        #endregion

        #region Events
        event EventHandler SaveEvent;
        event EventHandler ClearEvent;
        event EventHandler CloseEvent;
        #endregion

        #region Methods
        /// <summary>
        /// Hide Dialog
        /// </summary>
        void Hide();

        /// <summary>
        /// Show Diaglog
        /// </summary>
        void ShowDialog();

        /// <summary>
        /// Close Dialog
        /// </summary>
        void Close();
        #endregion
    }
}
using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View.DialogForm
{
	public partial class EditIngredientView : Form, IEditIngredientView
	{
		#region Properties
		/// <summary>
		/// Setting Tittle 
		/// </summary>
		public string TittleHeader
		{
			get { return this.lblHeader.Text; }
			set { this.lblHeader.Text = value; }
		}

        /// <summary>
        /// 
        /// </summary>
        public string IngredientName
        {
            get => txtIngredientName.Text;
            set => txtIngredientName.Text = value;
        }

        #endregion

        #region Events
        public event EventHandler SaveEvent;
        public event EventHandler ClearEvent;
        public event EventHandler CloseEvent;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public EditIngredientView()
		{
			InitializeComponent();
            btnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                CloseEvent?.Invoke(this, EventArgs.Empty);
            };

            btnClear.Click += delegate 
            {
                ClearEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        #region private fields
        /// <summary>
        /// Instance
        /// </summary>
        private static EditIngredientView instance;

        #endregion

        #region public fields

        /// <summary>
        /// Get instance
        /// </summary>
        /// <returns>instance</returns>
        public static EditIngredientView GetInstance()
		{
			if (instance == null || instance.IsDisposed)
			{
				instance = new EditIngredientView();
			}
			else
			{
				if (instance.WindowState == FormWindowState.Minimized)
					instance.WindowState = FormWindowState.Normal;
				instance.BringToFront();
			}

			return instance;
		}

		/// <summary>
		/// Show As Dialog 
		/// </summary>
		void IEditIngredientView.ShowDialog()
		{
			ShowDialog();
		}
        #endregion
    }
}
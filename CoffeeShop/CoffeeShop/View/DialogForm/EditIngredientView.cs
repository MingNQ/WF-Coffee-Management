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

        public string IngredientName
        {
            get => txtIngredientName.Text;
            set => txtIngredientName.Text = value;
        }

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
                this.Close();
            };

            btnClear.Click += delegate { this.Close(); };
        }

		/// <summary>
		/// Instance
		/// </summary>
		private static EditIngredientView instance;
   

        public event EventHandler SaveEvent;

		public event EventHandler ClearEvent;


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

        public void SetLIngredientListBindingSource(BindingSource ingredientList)
        {
            this.dgvIngredient.DataSource = ingredientList;
        }

        #region Events
        #endregion
    }
}

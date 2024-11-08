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

namespace CoffeeShop.View.DialogCheckList
{
    public partial class EditCategoryView : Form, IEditCategoryView
    {

        #region Properties
        /// <summary>
        /// Setting Tittle 
        /// </summary>
        public string TittleHeader
        {
            get { return this.lbHeader.Text; }
            set { this.lbHeader.Text = value; }
        }
        #endregion
        /// <summary>
        /// Instance
        /// </summary>
        private static EditCategoryView instance;

        public event EventHandler SaveEvent;
        public event EventHandler CancleEvent;

        public EditCategoryView()
        {
            InitializeComponent();
            btnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                this.Close();
            };
            btnCancle.Click += delegate { this.Close(); };
            dgvIngredient.MultiSelect = true;
            dgvIngredient.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }


        /// <summary>
        /// Get instance
        /// </summary>
        /// <returns>instance</returns>
        public static EditCategoryView GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new EditCategoryView();
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }

            return instance;
        }

		#region Methods

		/// <summary>
		/// Show As Dialog
		/// </summary>
		void IEditCategoryView.ShowDialog()
		{
            ShowDialog();
		}

        public void SetItemListBindingSource(BindingSource itemList)
        {
            dgvIngredient.DataSource = itemList;
        }
        public List<IngredientModel> SelectedIngredients => dgvIngredient.SelectedRows.Cast<DataGridViewRow>().Select(row => row.DataBoundItem as IngredientModel).ToList();

        #endregion

        #region Events
        #endregion
    }
}

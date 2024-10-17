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
        public EditCategoryView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Instance
        /// </summary>
        private static EditCategoryView instance;


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

        #region Events
        #endregion
    }
}

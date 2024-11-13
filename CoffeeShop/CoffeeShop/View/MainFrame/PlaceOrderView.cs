using CoffeeShop.View.CustomControls;
using CoffeeShop.View.MainFrame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View
{
    public partial class PlaceOrderView : Form, IPlaceOrderView
    {
        #region Fields

        /// <summary>
        /// Instance
        /// </summary>
        private static PlaceOrderView instance;
        
        /// <summary>
        /// Current Page
        /// </summary>
        private int currentPage = 1;
        
        /// <summary>
        /// Total of Pages
        /// </summary>
        private int totalPages;

        /// <summary>
        /// Page Current Size
        /// </summary>
        private int pageSize;

        /// <summary>
        /// Size Each Page
        /// </summary>
        private List<int> pageSizes = new List<int> { 6, 5, 2, 8 };

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public PlaceOrderView()
        {
            InitializeComponent();
            InitializeTableOrder();
        }

        #region private fields

        /// <summary>
        /// Initialize Table
        /// </summary>
        private void InitializeTableOrder()
        {
            totalPages = pageSizes.Count;
            btnPrevious.Click += DisplayPreviousPage;
            btnNext.Click += DisplayNextPage;
            currentPage = 1;
            DisplayPage(currentPage);
        }

        /// <summary>
        /// Display Page No
        /// </summary>
        /// <param name="page"></param>
        private void DisplayPage(int page)
        {
            // Clear previous page
            flowPnlTableOrder.Controls.Clear();

            // Take number of data
            pageSize = pageSizes[page - 1];
            for (int i = 0; i < pageSize; i++) 
            {
                flowPnlTableOrder.Controls.Add(new TableOrderControl());
            }
        }

        /// <summary>
        /// Display Next Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayNextPage(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                DisplayPage(currentPage);
            }
        }

        /// <summary>
        /// Display Previous Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayPreviousPage(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                DisplayPage(currentPage);
            }
        }

        #endregion

        #region public fields

        /// <summary>
        /// Get Instance
        /// </summary>
        /// <param name="parentContainer"></param>
        /// <returns></returns>
        public static PlaceOrderView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PlaceOrderView();
                instance.MdiParent = parentContainer;
                instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }

            return instance;
        }

        #endregion
    }
}

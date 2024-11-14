using CoffeeShop.Model;
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

        #endregion

        #region Properties

        /// <summary>
        /// Floor Number
        /// </summary>
        public int FloorNo 
        { 
            get { return int.Parse(lblFloor.Text.Substring(lblFloor.Text.Length - 1)); }
            set { lblFloor.Text = "Floor: " + value; } 
        }

        /// <summary>
        /// Form is open
        /// </summary>
        public bool IsOpen 
        {
            get => Application.OpenForms.OfType<PlaceOrderView>().Any();
        }

        #endregion

        #region Events
        public event EventHandler DisplayPage;
        public event EventHandler DisplayPreviousPage;
        public event EventHandler DisplayNextPage;
        public event EventHandler OrderEvent;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public PlaceOrderView()
        {
            InitializeComponent();
            InitiateAndRaiseEvents();
            tabPlaceOrder.TabPages.Remove(tabPageOrder);
        }

        #region private fields

        /// <summary>
        /// Initiate And Raise Events
        /// </summary>
        private void InitiateAndRaiseEvents()
        {
            // Initialize Table
            tabPageTableOrder.Text = "Select Table";
            tabPageOrder.Text = "Order";

            // Pagination table order
            this.Load += delegate { DisplayPage?.Invoke(this, EventArgs.Empty); };
            btnPrevious.Click += delegate { DisplayPreviousPage?.Invoke(this, EventArgs.Empty); };
            btnNext.Click += delegate { DisplayNextPage?.Invoke(this, EventArgs.Empty); };

            // Back
            btnBack.Click += (s, e) =>
            {
                tabPlaceOrder.TabPages.Remove(tabPageOrder);
                tabPlaceOrder.TabPages.Add(tabPageTableOrder);
            };
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

        /// <summary>
        /// Update Flow Panel Table View
        /// </summary>
        public void UpdateTableView(IEnumerable<TableOrder> floor)
        {
            flowPnlTableOrder.Controls.Clear();
            var emptyTables = floor.Count(t => t.Status == "Trống");
            lblEmpty.Text = $"Empty: {emptyTables}/{floor.Count()}";

            foreach (var table in floor)
            {
                var tmp = new TableOrderControl()
                {
                    TableID = table.TableID,
                    Status = table.Status,
                };
                tmp.ClickEvent += (s, e) =>
                {
                    tabPlaceOrder.TabPages.Remove(tabPageTableOrder);
                    tabPlaceOrder.TabPages.Add(tabPageOrder);
                    OrderEvent?.Invoke(this, EventArgs.Empty);
                };

                flowPnlTableOrder.Controls.Add(tmp);
            }
        }

        #endregion
    }
}

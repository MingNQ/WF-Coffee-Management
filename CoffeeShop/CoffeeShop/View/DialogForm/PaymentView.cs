using CoffeeShop.Model;
using CoffeeShop.Model.Common;
using CoffeeShop.Utilities;
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
    public partial class PaymentView : Form, IPaymentView
    {
        #region Fields

        /// <summary>
        /// 
        /// </summary>
        private static PaymentView instance;

        /// <summary>
        /// 
        /// </summary>
        private bool isOpen = true;

        /// <summary>
        /// 
        /// </summary>
        private string customerID;
        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public string InvoiceID 
        {
            get { return lbInvoice.Text.Substring(9); }
            set { lbInvoice.Text = "INVOICE: " + value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsOpen 
        {
            get { return isOpen; }
            set { isOpen = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CustomerID 
        { 
            get { return customerID; } 
            set { customerID = value; }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public string CustomerName 
        { 
            get { return txtCustomerName.Text; } 
            set { txtCustomerName.Text = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string CustomerPhone 
        { 
            get { return txtSearch.Text; } 
            set { txtSearch.Text = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PaymentMethod 
        { 
            get { return cbPaymentMethod.Text; } 
            set { cbPaymentMethod.Text = value; } 
        }

        #endregion

        #region Events
        public event EventHandler SearchEvent;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public PaymentView()
        {
            InitializeComponent();
            InitiateAndRaiseEvents();
        }

        #region private fields

        /// <summary>
        /// 
        /// </summary>
        private void InitiateAndRaiseEvents()
        {
            // Close Form and Go to Invoice
            btnNext.Click += (s, e) => 
            { 
                if (cbPaymentMethod.Text == "")
                {
                    DialogMessageView.ShowMessage("notify", "Please select payment method");
                    return;
                }
                this.Close(); 
                isOpen = true; 
            };
            // Close Form
            btnCancel.Click += (s, e) => { this.Close(); isOpen = false; };
            // Search 
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };

            cbPaymentMethod.Items.Add(PaymentMethods.Cash);
            cbPaymentMethod.Items.Add(PaymentMethods.QR);
        }

        #endregion

        #region public fields

        /// <summary>
        /// Get Instance
        /// </summary>
        /// <returns></returns>
        public static PaymentView GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new PaymentView();
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
        /// 
        /// </summary>
        void IPaymentView.ShowDialog()
        {
            InvoiceID = Generate.GenerateID("INV");

            this.ShowDialog();
        }

        public void SetListBindingSource(BindingSource bindingSource)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

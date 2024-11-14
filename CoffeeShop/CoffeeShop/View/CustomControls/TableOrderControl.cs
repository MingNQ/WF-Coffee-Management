using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View.CustomControls
{
    public partial class TableOrderControl : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public string TableID
        {
            get { return lblTableNo.Text; }
            set { lblTableNo.Text = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Status
        {
            get { return lblStatus.Text; }
            set 
            { 
                lblStatus.Text = value; 
                
                BackColor = lblStatus.Text == "Trống" ? Color.FromArgb(168, 140, 118) : Color.Gray;
            }
        }

        public event EventHandler ClickEvent;

        /// <summary>
        /// 
        /// </summary>
        public TableOrderControl()
        {
            InitializeComponent();
            lblTableNo.Click += delegate { ClickEvent?.Invoke(this, EventArgs.Empty); };
            lblStatus.Click += delegate { ClickEvent?.Invoke(this, EventArgs.Empty); };
        }

    }
}

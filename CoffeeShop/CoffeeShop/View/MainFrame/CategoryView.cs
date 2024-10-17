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
    public partial class CategoryView : Form, ICategoryView
    {
		public event EventHandler ViewDrinkClicked;

        public CategoryView()
        {
            InitializeComponent();

			//dki su kien cho nut View-Drink
			btnDrinkView.Click += (s, e) => ViewDrinkClicked?.Invoke(this, EventArgs.Empty);
        }

		public void ShowDrinkDetails()
		{
			//pnlCategory.Visible = false;
			pnlCategoryDrink.Visible = true;
			pnlCategoryDrink.BringToFront();
			lblCategory.Text = "Category / Drink";
		}

		/// <summary>
		/// Instance
		/// </summary>
        private static CategoryView instance;


		/// <summary>
		/// Get Instance
		/// </summary>
		/// <param name="parentContainer"></param>
		/// <returns>Instance</returns>

        public static CategoryView GetInstance(Form parentContainer)
        {
			if (instance == null || instance.IsDisposed)
			{
				instance = new CategoryView();
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

    }
}

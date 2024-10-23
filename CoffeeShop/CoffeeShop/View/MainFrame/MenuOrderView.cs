using CoffeeShop.Model;
using CoffeeShop.View.DialogForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View.MainFrame
{
    public partial class MenuOrderView : Form,IMenuOrderView
    {
        DataProcessor database = new DataProcessor();
        public MenuOrderView()
        {
            InitializeComponent();
            Product CoffeeCoconut = new Product("Coffee Coconut",35000);
            Product MilkCoffee = new Product("Milk Coffee", 25000);
            Product Americano = new Product("Americano", 20000);
            Product EggCoffee = new Product("Egg Coffee", 35000);
            Product CoffeeLatte = new Product("Coffee Latte", 30000);

            products.Add(btn_CfCoconut, CoffeeCoconut);
            products.Add(btn_CfAmericano, Americano);
            products.Add(btn_CfEgg, EggCoffee);
            products.Add(btn_CfLatte,CoffeeLatte);
            products.Add(btn_CfMilk, MilkCoffee);

            productCheckmarks.Add(btn_CfCoconut,Tick);
            productCheckmarks.Add(btn_CfMilk, Tick1);
            productCheckmarks.Add(btn_CfAmericano, Tick2);
            productCheckmarks.Add(btn_CfEgg, Tick3);
            productCheckmarks.Add(btn_CfLatte, Tick4);
        }
        /// <summary>
		/// Instance
		/// </summary>
        private static MenuOrderView instance;
        int count = 0;
        Dictionary<Button,Product> products = new Dictionary<Button, Product>();
        Dictionary<Button,PictureBox> productCheckmarks = new Dictionary<Button,PictureBox>();


        /// <summary>
        /// Get Instance
        /// </summary>
        /// <param name="parentContainer"></param>
        /// <returns>Instance</returns>

        public static MenuOrderView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new MenuOrderView();
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

        
        private void btn_Item_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;

          
            if (products.ContainsKey(clickedButton))
            {
                Product selectedProduct = products[clickedButton];
                string productName = selectedProduct.Name;
                int price = selectedProduct.Price;

                ItemDetail detailForm = new ItemDetail(productName, price);
                detailForm.ShowDialog();

                if (detailForm.isConfirmed)
                {
                    if(productCheckmarks.ContainsKey(clickedButton))
                    {
                        productCheckmarks[clickedButton].Visible = true;

                        DataTable data = database.ReadData("select * from OrderTemporary");
                        CountTest.Text = data.Rows.Count.ToString();
                    }    
                }
                else
                {
                    productCheckmarks[clickedButton].Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Product not found");
            }
        }

        private void Cart_Click(object sender, EventArgs e)
        {
            PlaceOrderView placeOrderView = new PlaceOrderView();
            placeOrderView.Show();
        }
    }
}

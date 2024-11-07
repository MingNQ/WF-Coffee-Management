using CoffeeShop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View.DialogForm
{
    public partial class ItemDetail : Form
    {
        DataProcessor database = new DataProcessor();
        public bool isConfirmed { get; set; } = false;
        public ItemDetail(string productName,double price,string imagePath)
        {
            InitializeComponent();
            txt_Ten.Text = productName;
            txt_Gia.Text = price.ToString();
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string projectPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(basePath).FullName).FullName).FullName;
            string fullPath = Path.Combine(projectPath, "Assets", "Menu", imagePath);
            Pib_Item.Image = Image.FromFile(fullPath);
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            
            if(txt_SoLuong.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần nhập số lượng");
                txt_SoLuong.Focus();
            }
            else
            {
                database.ChangeData("insert into OrderTemporary(ItemName,Price,Quantity,Demand) values(N'"
                    + txt_Ten.Text + "',N'" + txt_Gia.Text + "',N'" + txt_SoLuong.Text + "',N'" +txt_YeuCau.Text + "')");               
                Close();
                isConfirmed = true;
            }
           
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

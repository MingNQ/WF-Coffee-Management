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
    public partial class ItemDetail : Form
    {
        DataProcessor database = new DataProcessor();
        public bool isConfirmed { get; set; } = false;
        public ItemDetail(string productName,int price)
        {
            InitializeComponent();
            txt_Ten.Text = productName;
            txt_Gia.Text = price.ToString();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            isConfirmed = true;
            if(txt_SoLuong.Text.Length == 0)
            {
                MessageBox.Show("Bạn cần nhập số lượng");
                txt_SoLuong.Focus();
            }
            else
            {
                database.ChangeData("insert into OrderTemporary(ItemName,Price,Quantity,Demand) values(N'"
                    + txt_Ten.Text + "',N'" + txt_Gia.Text + "',N'" + txt_SoLuong.Text + "',N'" +txt_YeuCau.Text + "')");
            }
            Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

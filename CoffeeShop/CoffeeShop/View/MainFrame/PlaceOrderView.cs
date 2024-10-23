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

namespace CoffeeShop.View
{
    public partial class PlaceOrderView : Form
    {
        DataProcessor database = new DataProcessor();
        private string selectedItemName;
        public PlaceOrderView()
        {
            InitializeComponent();
        }

        private void PlaceOrderView_Load(object sender, EventArgs e)
        {
            LoadData();
            dgv_Item.Columns[0].HeaderText = "Tên Sản Phẩm";
            dgv_Item.Columns[1].HeaderText = "Giá";
            dgv_Item.Columns[2].HeaderText = "Số lượng";
            dgv_Item.Columns[3].HeaderText = "Yêu cầu thêm";
            dgv_Item.Columns[4].HeaderText = "Tổng tiền";

            foreach (DataGridViewColumn column in dgv_Item.Columns)
            {
                column.Width = 150;
            }
            CopyDataToListBox();
        }
        private void LoadData()
        {
            DataTable data = database.ReadData("select * from OrderTemporary");
            dgv_Item.DataSource = data;
        }

        private void dgv_Item_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >=0)
            {
                selectedItemName = dgv_Item.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();               
            }           
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if(selectedItemName != null)
            {
                if (MessageBox.Show("Bạn có muốn xóa món " + selectedItemName + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    database.ChangeData("delete from OrderTemporary where ItemName = N'" + selectedItemName + "'");
                    MessageBox.Show("Bạn đã xóa thành công");
                    dgv_Item.DataSource = database.ReadData("select * from OrderTemporary");

                   
                }
            }
            else
            {
                MessageBox.Show("Bạn cần chọn tên sản phẩm muốn xóa");
            }
        }
        private void CopyDataToListBox()
        {
            listbox_Item.Items.Clear();

            foreach(DataGridViewRow row in dgv_Item.Rows)
            {
                if(!row.IsNewRow)
                {
                    string itemName = row.Cells[0].Value.ToString();
                    string quantity = row.Cells[2].Value.ToString();
                    string request = row.Cells[3].Value.ToString();

                    string DetailItems = itemName + " " + quantity + " " + request;

                    listbox_Item.Items.Add(DetailItems);
                }    
            }    
        }

        private void btn_Pay_Click(object sender, EventArgs e)
        {
            
        }
    }
}

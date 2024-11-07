using CoffeeShop.Model;
using CoffeeShop.View.DialogForm;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View.MainFrame
{
    public partial class MenuOrderView : Form, IMenuOrderView
    {
        DataProcessor database = new DataProcessor();
        public MenuOrderView()
        {
            InitializeComponent();        
        }
        /// <summary>
		/// Instance
		/// </summary>
        private static MenuOrderView instance;
        int count = 0;
        Dictionary<Guna2Button, Item> products = new Dictionary<Guna2Button, Item>();
        Dictionary<Guna2Button, PictureBox> productCheckmarks = new Dictionary<Guna2Button, PictureBox>();
        Dictionary<string, List<Panel>> categoryPanel = new Dictionary<string, List<Panel>>();


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

        private void MenuOrderView_Load_1(object sender, EventArgs e)
        {
            loadProductFromDatabase();
            addValueToComboBox();
            PlaceOrderView_Load();
        }


        private void btn_Item_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = sender as Guna2Button;


            if (products.ContainsKey(clickedButton))
            {
                Item selectedProduct = products[clickedButton];
                string productName = selectedProduct.ItemName;
                double price = selectedProduct.Cost;
                string Path = selectedProduct.ImagePath;

                ItemDetail detailForm = new ItemDetail(productName, price,Path);
                detailForm.ShowDialog();

                if (detailForm.isConfirmed)
                {
                    if (productCheckmarks.ContainsKey(clickedButton))
                    {
                        productCheckmarks[clickedButton].Visible = true;
                        DataTable data = database.ReadData("select * from OrderTemporary");
                        lb_Count.Text = data.Rows.Count.ToString();
                    }
                }
                else
                {
                    productCheckmarks[clickedButton].Visible = false;
                }
            }
        }

        private void Cart_Click(object sender, EventArgs e)
        {
            tabControl_Menu.SelectedTab = tabPage_OrderPlace;
            LoadData();
            CopyDataToListBox();
            TinhTongTien();
        }
       

       
        public void loadProductFromDatabase()
        {
            string connectionString = "Data Source=LAPTOP-Q4FCEV17\\SQLEXPRESS;Initial Catalog=BTL_QLCOFFEE;Integrated Security=True;";
            string query = "Select Item.ItemID, Item.ItemName, Item.CategoryID, Item.Cost, Item.ImagePath, Category.CategoryName from Item join Category on Item.CategoryID = Category.CategoryID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string ItemName = reader["ItemName"].ToString();
                    double ItemCost = (double)reader["Cost"];
                    string ImagePath = reader["ImagePath"].ToString();
                    string ItemID = reader["ItemID"].ToString();
                    int CategoryID = (int)reader["CategoryID"];
                    string CategoryName = reader["CategoryName"].ToString();


                    // Xử lí đường dẫn

                    string basePath = AppDomain.CurrentDomain.BaseDirectory;
                    string projectPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(basePath).FullName).FullName).FullName;
                    string fullPath = Path.Combine(projectPath,"Assets","Menu",ImagePath);

                    

                    string tickPath = "checked.png";
                    string tickFullPath = Path.Combine(projectPath, "Assets", "Icons", tickPath);

                    Item product = new Item(ItemID, ItemName, CategoryID, ImagePath, ItemCost);

                    // Tạo Panel cho từng sản phẩm
                    Panel panelProduct = new Panel();
                    panelProduct.Size = new Size(170, 160);
                    panelProduct.BorderStyle = BorderStyle.FixedSingle;
                    panelProduct.BackColor = Color.Transparent;
                    panelProduct.Visible = true;

                    // Tạo picture box cho hình ảnh của sản phẩm
                    Guna2PictureBox pictureBoxProduct = new Guna2PictureBox();
                    pictureBoxProduct.Size = new Size(166, 117);
                    pictureBoxProduct.Location = new Point(2, 3);
                    pictureBoxProduct.Image = Image.FromFile(fullPath);
                    pictureBoxProduct.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBoxProduct.BorderRadius = 10;

                    // Tạo button cho sản phẩm
                    Guna2Button buttonProduct = new Guna2Button();
                    buttonProduct.Text = ItemName;
                    buttonProduct.TextAlign = HorizontalAlignment.Center;
                    buttonProduct.Font = new Font("Arial", 12);
                    buttonProduct.ForeColor = Color.White;
                    buttonProduct.Location = new Point(20, 124);
                    buttonProduct.BackColor = Color.Transparent;
                    buttonProduct.FillColor = Color.Transparent;
                    buttonProduct.ForeColor = Color.Black;
                    buttonProduct.Size = new Size(134, 23);
                    buttonProduct.Click += btn_Item_Click;

                    // Tạo các picturebox giấu tích
                    Guna2PictureBox pictureBoxTick = new Guna2PictureBox();
                    pictureBoxTick.Size = new Size(30, 30);
                    pictureBoxTick.Location = new Point(138, 3);
                    pictureBoxTick.Image = Image.FromFile(tickFullPath);
                    pictureBoxTick.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBoxTick.BackColor = Color.FromArgb(50, 186, 124);
                    pictureBoxTick.Visible =false;
                    pictureBoxTick.BringToFront();

                    // Kiểm tra nếu danh mục đã tồn tại trong Dictionary
                    if (!categoryPanel.ContainsKey(CategoryName))
                    {
                        // Nếu chưa tồn tại thì tạo một danh sách mới và thêm Panel vào danh sách
                        categoryPanel[CategoryName] = new List<Panel>();
                    }

                    // Thêm Panel vào List<Panel> của danh mục
                    categoryPanel[CategoryName].Add(panelProduct);

                    // Thêm các control vào panel
                    panelProduct.Controls.Add(pictureBoxTick);
                    panelProduct.Controls.Add(buttonProduct);
                    panelProduct.Controls.Add(pictureBoxProduct);

                    // Thêm sản phẩm và tick mark vào các từ điển products và productCheckmarks
                    products.Add(buttonProduct, product);
                    productCheckmarks.Add(buttonProduct, pictureBoxTick);

                    // Thêm Panel vào FlowLayoutPanel để hiển thị
                    flowLayOut_Menu.Controls.Add(panelProduct);
                }
                reader.Close();
            }
        }

        private void addValueToComboBox()
        {
            string connectionString = "Data Source=LAPTOP-Q4FCEV17\\SQLEXPRESS;Initial Catalog=BTL_QLCOFFEE;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT CategoryName FROM Category";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string categoryName = reader["CategoryName"].ToString();
                        cbb_Category.Items.Add(categoryName);
                    }
                }
            }
        }

        
       
        private void cbb_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = cbb_Category.SelectedItem.ToString();

            flowLayOut_Menu.Controls.Clear();


            if (categoryPanel.ContainsKey(selectedCategory))
            {
                List<Panel> selectedPanels = categoryPanel[selectedCategory];


                flowLayOut_Menu.Controls.Clear();

                // Kiểm tra danh sách Panel có tồn tại và có các control bên trong không
                if (selectedPanels != null && selectedPanels.Count > 0)
                {
                    foreach (Panel selectedPanel in selectedPanels)
                    {
                        if (selectedPanel.Controls.Count > 0)
                        {
                            flowLayOut_Menu.Controls.Add(selectedPanel);
                            selectedPanel.Visible = true;
                            selectedPanel.BringToFront();
                        }
                    }
                }

            }
        }


        // Xử lí sự kiện cho tab page 2 
       
        private string selectedItemName;
       

        private void PlaceOrderView_Load()
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
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                selectedItemName = dgv_Item.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
        }

        private void btn_Remove_Click(object sender, EventArgs e)
        {
            if (selectedItemName != null)
            {
                if (MessageBox.Show("Bạn có muốn xóa món " + selectedItemName + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                { 
                    if (dgv_Item.SelectedRows.Count > 0)
                    {
                        int selectedIndex = dgv_Item.SelectedRows[1].Index;
                        dgv_Item.Rows.RemoveAt(selectedIndex);
                    }
                    database.ChangeData("delete from OrderTemporary where ItemName = N'" + selectedItemName + "'");
                    MessageBox.Show("Bạn đã xóa thành công");
                    dgv_Item.DataSource = database.ReadData("select * from OrderTemporary");                 
                }
            }
            else
            {
                MessageBox.Show("Bạn cần chọn tên sản phẩm muốn xóa");
            }
            CopyDataToListBox();
            TinhTongTien();
        }
        


        private void CopyDataToListBox()
        {
            listbox_Item.Items.Clear();

            foreach (DataGridViewRow row in dgv_Item.Rows)
            {
                if (row.Cells["ItemName"].Value != null)
                {
                    string itemName = row.Cells["ItemName"].Value.ToString();
                    string quantity = row.Cells["Quantity"].Value.ToString();
                    string demand = row.Cells["Demand"].Value.ToString();

                    listbox_Item.Items.Add($"{itemName} * {quantity} {demand}");
                }    
            }
        }
        private void TinhTongTien()
        {
            int totalSum = 0;
            foreach(DataGridViewRow row in dgv_Item.Rows)
            {
                if (row.IsNewRow) continue;

                int itemTotal;
                if (int.TryParse(row.Cells["Total"].Value.ToString() , out itemTotal))
                {
                    totalSum += itemTotal;
                }
            }    
            lb_Tong.Text = totalSum.ToString();
        }
       
        private void btn_Add_Click(object sender, EventArgs e)
        {
            tabControl_Menu.SelectedTab = tabPage_Menu;
        }

        private void btn_PrintInvoice_Click(object sender, EventArgs e)
        {

        }
    }
}

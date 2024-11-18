using CoffeeShop._Repositories;
using CoffeeShop._Repositories.InterfaceModel;
using CoffeeShop.Model;
using CoffeeShop.Model.InterfaceModel;
using CoffeeShop.Utilities;
using CoffeeShop.View;
using CoffeeShop.View.DialogForm;
using CoffeeShop.View.MainFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Words.NET;
using Xceed.Document.NET;


namespace CoffeeShop.Presenter
{
    public class PlaceOrderPresenter
    {
        #region Fields
        
        /// <summary>
        /// View
        /// </summary>
        private IPlaceOrderView view;

        /// <summary>
        /// Repository
        /// </summary>
        private IPlaceOrderRepository repository;

        /// <summary>
        /// Category
        /// </summary>
        private ICategoryRepository category;

        /// <summary>
        /// Binding Source
        /// </summary>
        private BindingSource bindingSource;

        /// <summary>
        /// Number table in floor
        /// </summary>
        private IEnumerable<TableOrder> floor;

        /// <summary>
        /// Floors
        /// </summary>
        private IEnumerable<Floor> floors;

        /// <summary>
        /// 
        /// </summary>
        private List<OrderDetailModel> orderDetails = new List<OrderDetailModel>();

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_view"></param>
        /// <param name="_repository"></param>
        public PlaceOrderPresenter(IPlaceOrderView _view, IPlaceOrderRepository _repository, ICategoryRepository _category)
        {
            view = _view;

            // If not open  
            if (!view.IsOpen)
            {
                repository = _repository;
                category = _category;
                bindingSource = new BindingSource();

                view.FloorNo = 1;
                view.DisplayPage += DisplayPageEvent;
                view.DisplayPreviousPage += DisplayPreviousPageEvent;
                view.DisplayNextPage += DisplayNextPageEvent;
                view.OrderEvent += OrderEvent;
                view.SelectedCategoryChangeEvent += SelectedCategoryChangeEvent;
                view.SelectedItemChangeEvent += SelectedItemChangeEvent;
                view.AddToCartEvent += AddToCartEvent;
                view.RemoveEvent += RemoveEvent;
                view.ReduceEvent += ReduceEvent;
                view.RemoveAllEvent += RemoveAlEvent;
                view.CompleteOrderEvent += CompleteOrderEvent;
                view.PrintEvent += PrintEvent;
                view.PayEvent += PayEvent;
                view.BackEvent += BackEvent;
                view.SetListBindingSource(bindingSource);

                floors = repository.GetAllFloor();
            }

            // Show Form;
            view.Show();
        }

        #region private fields

        /// <summary>
        /// Display Next Page Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayNextPageEvent(object sender, EventArgs e)
        {
            if (view.FloorNo < floors.Count())
            {
                view.FloorNo++;
                floor = repository.GetTablesByFloor(CurrFloor(view.FloorNo));
                view.UpdateTableView(floor);
            }
        }

        /// <summary>
        /// Displaye Previous Page Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayPreviousPageEvent(object sender, EventArgs e)
        {
            if (view.FloorNo > 1)
            {
                view.FloorNo--;
                floor = repository.GetTablesByFloor(CurrFloor(view.FloorNo));
                view.UpdateTableView(floor);
            }
        }

        /// <summary>
        /// DisplAy Page Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayPageEvent(object sender, EventArgs e)
        {
            floor = repository.GetTablesByFloor(CurrFloor(view.FloorNo));
            view.UpdateTableView(floor);
        }

        /// <summary>
        /// Order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OrderEvent(object sender, EventArgs e)
        {
            view.SelectedCategoryChangeEvent -= SelectedCategoryChangeEvent;
            view.SelectedItemChangeEvent -= SelectedItemChangeEvent;

            view.GetListCategoy(category.GetAll());
            view.GetListItem(category.GetAllItems());
            view.UpdatePrice(category.GetAllItems());

            if (view.IsEdit)
            {
                OrderModel order = repository.GetOrder(view.TableNo);
                view.OrderID = order.OrderID;
                orderDetails = repository.GetOrderDetails(view.OrderID);
                view.NumberPeople = order.NumberPeople;
                view.StaffName = repository.GetStaffInformationByID(order.StaffID).StaffName;
                var items = category.GetAllItems();

                foreach (var item in orderDetails)
                {
                    item.Item = items.Where(i => i.ItemID == item.ItemID).FirstOrDefault();
                }

                UpdateData();
            }

            view.SelectedCategoryChangeEvent += SelectedCategoryChangeEvent;
            view.SelectedItemChangeEvent += SelectedItemChangeEvent;
        }

        /// <summary>
        /// Select Category Change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedCategoryChangeEvent(object sender, EventArgs e)
        {
            view.GetListItem(category.GetAllItems());
        }

        /// <summary>
        /// Select Item Change 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedItemChangeEvent(object sender, EventArgs e)
        {
            view.UpdatePrice(category.GetAllItems());
        }

        /// <summary>
        /// Add to cart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddToCartEvent(object sender, EventArgs e)
        {
            var orderDetail = new OrderDetailModel()
            {
                OrderDetailID = Generate.GenerateID("OD"),
                OrderID = view.OrderID,
                ItemID = view.ItemID,
                Item = new ItemModel()
                {
                    ItemID = view.ItemID,
                    ItemName = view.ItemName,
                    Cost = view.Price
                },
                Quantity = view.Quantity,
                Total = view.Total,
                Description = view.Description,
            };

            // If Exist Add Quantity and Total
            bool isExit = false;
            orderDetails.ForEach(order =>
            {
                if (order.Item.ItemName == orderDetail.Item.ItemName)
                {
                    order.Quantity += orderDetail.Quantity;
                    order.Total += orderDetail.Total;
                    isExit = true;
                }
            });

            // If not exist add new
            if (!isExit)
            {
                orderDetails.Add(orderDetail);
            }

            UpdateData();
        }

        /// <summary>
        /// Remove Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveEvent(object sender, EventArgs e)
        {
            var order = (OrderDetailModel)bindingSource.Current;

            if (orderDetails.Remove(orderDetails.Where(o => o.ItemID == order.ItemID).FirstOrDefault()))
            {
                UpdateData();

                DialogMessageView.ShowMessage("success", $"Remove {order.ItemName}!");
            }
            else
            {
                DialogMessageView.ShowMessage("information", $"Something went wrong. Can't remove {order.ItemName}!");
            }
        }

        /// <summary>
        /// Remove Items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveAlEvent(object sender, EventArgs e)
        {
            if (orderDetails.Count > 0 && DialogMessageView.ShowMessage("warning", "Are you sure to remove all items?") == DialogResult.OK)
            {
                orderDetails.Clear();
                UpdateData();
            }
        }

        /// <summary>
        /// Reduce Quantity Item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReduceEvent(object sender, EventArgs e)
        {
            // TO-DO: Reduce Quantity Item
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PayEvent(object sender, EventArgs e)
        {
            // TO-DO: Coding Pay
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintEvent(object sender, EventArgs e)
        {          
            Invoice invoiceView = new Invoice();              
            invoiceView.lbInvoiceID.Text = repository.GenerateInvoiceID();
            invoiceView.lbPeople.Text = view.NumberPeople.ToString();
            invoiceView.lbDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            invoiceView.lbIDTable.Text = view.TableNo.ToString();
            invoiceView.lbStaff.Text = view.StaffName.ToString();             
            invoiceView.lbOrderID.Text = view.OrderID.ToString();
            
            float totalSum = 0;
            foreach (var item in orderDetails)
            {
                totalSum = item.UnitPrice * item.Quantity;
            }
            invoiceView.lbTotal.Text = totalSum.ToString();
            invoiceView.dgvInvoice.DataSource = orderDetails;
            invoiceView.Show();

            invoiceView.btnCancel.Click += delegate
            {
                invoiceView.Close();
            };
            invoiceView.btnPrint.Click += delegate
            {
                string filePath = AppConst.INVOICE_SOURCE_PATH;
                DocX doc;
                if(System.IO.File.Exists(filePath))
                {
                    doc = DocX.Load(filePath);
                }
                else
                {
                    doc = DocX.Create(filePath);
                }                
                doc.InsertParagraph("Coffee Shop").FontSize(16).Bold().Alignment = Alignment.center;
                doc.InsertParagraph("Invoice").FontSize(14).Bold().Alignment = Alignment.center;
                doc.InsertParagraph("\n");

                    // Thêm thông tin hóa đơn
                    
                    // Line 1
                var paragraphTableID = doc.InsertParagraph();
                paragraphTableID.Append("                                                                               ");
                paragraphTableID.Append("Table ID: ").FontSize(12).Bold();                   
                paragraphTableID.Append(invoiceView.lbIDTable.Text);

                   
                    // Line 2
                var paragraphDateInvoiceID = doc.InsertParagraph();
                paragraphDateInvoiceID.Append("                                  ");
                paragraphDateInvoiceID.Append($"Date: ").Bold();
                paragraphDateInvoiceID.Append($"{invoiceView.lbDate.Text}");
                paragraphDateInvoiceID.Append("                                           ");
                paragraphDateInvoiceID.Append($"Invoice ID: ").Bold();
                paragraphDateInvoiceID.Append($"InvoiceID");
                paragraphDateInvoiceID.Append("\n");

                    // Line 3 
                var paragraphOrderPeople = doc.InsertParagraph();
                paragraphOrderPeople.Append("                                 ");
                paragraphOrderPeople.Append("Order ID: ").Bold();
                paragraphOrderPeople.Append($"{invoiceView.lbOrderID.Text}");
                paragraphOrderPeople.Append("                                                 ");
                paragraphOrderPeople.Append($"People: ").Bold();
                paragraphOrderPeople.Append($"{invoiceView.lbPeople.Text}");
                paragraphOrderPeople.Append("\n");

                    //Line 4
                var paragraphStaff = doc.InsertParagraph();
                paragraphStaff.Append("\t\t\t\t         ");
                paragraphStaff.Append("Staff:").Bold();
                paragraphStaff.Append($" {invoiceView.lbStaff.Text}");
                paragraphStaff.Append("\n");
                    
                    //Thêm bảng để lưu Order Detail
                var table = doc.AddTable(orderDetails.Count + 1,4);
                table.SetWidths(new float[] { 200, 200, 200, 200 });

                table.Rows[0].Cells[0].Paragraphs[0].Append("ItemName").Bold().Alignment = Alignment.center;
                table.Rows[0].Cells[1].Paragraphs[0].Append("Cost").Bold().Alignment = Alignment.center;
                table.Rows[0].Cells[2].Paragraphs[0].Append("Quantity").Bold().Alignment = Alignment.center;
                table.Rows[0].Cells[3].Paragraphs[0].Append("Total").Bold().Alignment = Alignment.center;
                for (int i = 0; i < orderDetails.Count; i++)
                {
                    table.Rows[i + 1].Cells[0].Paragraphs[0].Append(orderDetails[i].ItemName).Alignment = Alignment.left;
                    table.Rows[i + 1].Cells[1].Paragraphs[0].Append(orderDetails[i].Quantity.ToString()).Alignment = Alignment.center;
                    table.Rows[i + 1].Cells[2].Paragraphs[0].Append(orderDetails[i].UnitPrice.ToString()).Alignment = Alignment.center;
                    table.Rows[i + 1].Cells[3].Paragraphs[0].Append(orderDetails[i].Total.ToString()).Alignment = Alignment.center;
                }
                doc.InsertTable(table);
                var paragraphTotal = doc.InsertParagraph();
                paragraphTotal.Append("\t\t\t\t          \t\t\t\t");
                paragraphTotal.Append("Total:").Bold();
                paragraphTotal.Append($"{invoiceView.lbTotal.Text}");

                doc.InsertParagraph("\n\n\n\n");
                doc.InsertParagraph("Thank For Choosing Us").FontSize(16).Bold().Alignment = Alignment.center;
                doc.InsertParagraph("\n\n");

                doc.Save();
                DialogMessageView.ShowMessage("information", "Print Successful");
                                
                invoiceView.Close();
            };
            
        }

        /// <summary>
        /// Complete Order Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompleteOrderEvent(object sender, EventArgs e)
        {
            if (orderDetails.Count <= 0)
            {
                DialogMessageView.ShowMessage("information", "No item selected? Please order one!");
                return;
            }

            if (view.NumberPeople <= 0)
            {
                DialogMessageView.ShowMessage("information", "No people selected? Please select one!");
                return;
            }

            try
            {

                if (!view.IsEdit)
                {
                    OrderModel order = new OrderModel()
                    {
                        OrderID = view.OrderID,
                        StaffID = Generate.StaffID,
                        TableID = view.TableNo,
                        NumberPeople = view.NumberPeople,
                    };

                    repository.AddOrder(order);
                    repository.AddOrderDetail(orderDetails);
                    repository.UpdateTableStatus(view.TableNo, AppConst.TABLE_IN_USED);
                }
                else
                {
                    var oldOrderDetail = repository.GetOrderDetails(view.OrderID);

                    // Check what will delete
                    var deleteOrderDetails = oldOrderDetail.Where(o => !orderDetails.Any(n => n.OrderDetailID == o.OrderDetailID)).ToList();
                    
                    // Check what will add
                    var addOrderDetails = orderDetails.Where(n => !oldOrderDetail.Any(o => o.OrderDetailID == n.OrderDetailID)).ToList();   
                    
                    // Check what will update/edit
                    var updateOrderDetails = orderDetails.Where(n => oldOrderDetail.Any(o => o.OrderDetailID == n.OrderDetailID)).ToList();

                    repository.DeleteOrderDetail(deleteOrderDetails);
                    repository.AddOrderDetail(addOrderDetails);
                    repository.EditOrderDetail(updateOrderDetails);
                }

                floor = repository.GetTablesByFloor(CurrFloor(1));
                view.UpdateTableView(floor);
                view.IsSuccessful = true;
            }
            catch
            {
                DialogMessageView.ShowMessage("warning", "Something went wrong. Can't order. Please try again!");
            }
        }

        /// <summary>
        /// Back event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackEvent(object sender, EventArgs e)
        {
            view.NumberPeople = 0;
            orderDetails.Clear();
            UpdateData();
        }

        /// <summary>
        /// Curr Floor
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        private string CurrFloor(int no)
        {
            return "Floor0" + no;
        }

        /// <summary>
        /// Update Data 
        /// </summary>
        private void UpdateData()
        {
            view.Description = "";
            bindingSource.DataSource = null;
            bindingSource.DataSource = orderDetails;
            view.CalculateGrandTotal(orderDetails);
        }
        
        #endregion

        #region public fields
        #endregion
    }
}

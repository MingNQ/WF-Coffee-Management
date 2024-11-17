using CoffeeShop.Model;
using CoffeeShop.Model.InterfaceModel;
using CoffeeShop.View;
using CoffeeShop.View.MainFrame;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.View.DialogForm;
using System.Windows.Forms;

namespace CoffeeShop.Presenter
{
	public class CustomerPresenter
	{
		#region Fiedls
		/// <summary>
		/// Customer View
		/// </summary>
		private ICustomerView customerView;

        /// <summary>
		/// 
		/// </summary>
		private ICustomerRepository repository;

        /// <summary>
        /// 
        /// </summary>
        private BindingSource customerBindingSource;

        /// <summary>
        /// 
        /// </summary>
        private IEnumerable<CustomerModel> customerList;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="view">Customer View</param>
        public CustomerPresenter(ICustomerView view, ICustomerRepository repository)
		{
			this.customerView = view;

            if (!customerView.IsOpen)
            {
                this.customerBindingSource = new BindingSource();
                this.repository = repository;

                // Subcribe events
                this.customerView.AddNewEvent += AddNewEvent;
                this.customerView.EditEvent += EditEvent;
                this.customerView.DeleteEvent += DeleteEvent;
                this.customerView.SearchEvent += SearchEvent;
                this.customerView.SaveEvent += SaveEvent;
                this.customerView.ClearEvent += ClearEvent;
                this.customerView.BackToListEvent += BackToListEvent;

                // Set Staff List binding source
                this.customerView.SetCustomerListBindingSource(customerBindingSource);

                // Load Staff List
                LoadAllCustomer();
            }

            // Show the view
            this.customerView.Show();
		}

        #region private fields

        /// <summary>
        /// Load customer list
        /// </summary>
        private void LoadAllCustomer()
        {
            customerList = repository.GetAll();
            customerBindingSource.DataSource = customerList;
        }

        /// <summary>
        /// Add new customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewEvent(object sender, EventArgs e)
        {
            customerView.IsEdit = false;
        }

        /// <summary>
        /// Edit customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditEvent(object sender, EventArgs e)
        {
            var customer = (CustomerModel)customerBindingSource.Current;

            customerView.CustomerID = customer.CustomerID;
            customerView.CustomerName = customer.CustomerName;
            customerView.PhoneNumber = customer.CustomerPhone.ToString();
            customerView.Email = customer.CustomerEmail;
            customerView.Coupon = customer.Coupon;
            customerView.Male = customer.Gender == Model.Common.Gender.Male;
            customerView.Female = customer.Gender == Model.Common.Gender.Female;
            customerView.Other = customer.Gender == Model.Common.Gender.Other;
            customerView.IsEdit = true;
        }

        /// <summary>
        /// Search Customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchEvent(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.customerView.SearchValue);

            if (!emptyValue)
            {
                customerList = repository.GetByValue(this.customerView.SearchValue);
            }
            else
            {
                customerList = repository.GetAll();
            }
            customerBindingSource.DataSource = customerList;
        }


        /// <summary>
        /// Delete customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteEvent(object sender, EventArgs e)
        {
            try
            {   
                var staff = (CustomerModel)customerBindingSource.Current;
                repository.Delete(staff.CustomerID);
                customerView.IsSuccessful = true;
                LoadAllCustomer();
                DialogMessageView.ShowMessage("success", "Successul delete customer");
            }
            catch
            {
                customerView.IsSuccessful = false;

                DialogMessageView.ShowMessage("error", "An error occured, could not delete this customer!");
            }
        }

        /// <summary>
        /// Save customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveEvent(object sender, EventArgs e)
        {
            var customer = new CustomerModel();

            try
            {
                customer.CustomerID = customerView.CustomerID;
                customer.CustomerName = customerView.CustomerName;
                customer.CustomerPhone = customerView.PhoneNumber;
                customer.CustomerEmail = customerView.Email;
                customer.Coupon = customerView.Coupon;
                customer.Gender = customerView.Male ? Model.Common.Gender.Male : (customerView.Female ? Model.Common.Gender.Female : Model.Common.Gender.Other);

                new Common.ModelValidation().Validate(customer);

                if (customerView.IsEdit) // Edit model
                {
                    repository.Edit(customer);
                }
                else // Add new model
                {
                    // Generate ID
                    int id = Convert.ToInt32(customerList.Last().CustomerID.Substring(2)) + 1;
                    customer.CustomerID = "C" + id.ToString("D3");

                    repository.Add(customer);
                }

                customerView.IsSuccessful = true;
                LoadAllCustomer();
                ClearFieldInformation();
            }
            catch (Exception ex)
            {
                customerView.IsSuccessful = false;
                DialogMessageView.ShowMessage("information", ex.Message);
            }
        }

        /// <summary>
        /// Clear information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearEvent(object sender, EventArgs e)
        {
            if (customerView.IsEdit && DialogMessageView.ShowMessage("warning", "Are you sure to clear all information? Information once cleared can't be recovered!")== DialogResult.OK)
            {
                ClearFieldInformation();
            }
        }

        /// <summary>
        /// Back to List view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackToListEvent(object sender, EventArgs e)
        {
            ClearFieldInformation();
        }

        /// <summary>
        /// Clear Information
        /// </summary>
        private void ClearFieldInformation()
        {
            customerView.CustomerName = "";
            customerView.PhoneNumber = "";
            customerView.Email = "";
            customerView.Coupon = 0;
            customerView.Male = false;
            customerView.Female = false;
            customerView.Other = false;
        }

        #endregion
    }
}

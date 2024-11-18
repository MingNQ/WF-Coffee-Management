using CoffeeShop._Repositories.InterfaceModel;
using CoffeeShop.Model;
using CoffeeShop.View.DialogForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.Presenter
{
    public class PaymentPresenter
    {
        #region Fields
        /// <summary>
        /// Payment View
        /// </summary>
        private IPaymentView view;

        /// <summary>
        /// 
        /// </summary>
        private IPlaceOrderRepository repository;

        /// <summary>
        /// 
        /// </summary>
        private IEnumerable<CustomerModel> customerModels;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public PaymentPresenter(IPaymentView _view, IPlaceOrderRepository _repository)
        {
            view = _view;
            repository = _repository;
            customerModels = repository.GetCustomers();
            view.SearchEvent += SearchEvent;
            view.ShowDialog();
        }

        #region private fields
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchEvent(object sender, EventArgs e)
        {
            var customer = customerModels.Where(c => c.CustomerPhone == view.CustomerPhone).FirstOrDefault();
            if (customer != null)
            {
                view.CustomerName = customer.CustomerName;
                view.CustomerID = customer.CustomerID;
            }
            else
            {
                DialogMessageView.ShowMessage("notify", "Can't find Customer!");
                view.CustomerPhone = "";
            }
        }
        #endregion
    }
}

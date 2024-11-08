using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View.MainFrame
{
	public interface ICustomerView
	{
        // Properties
        string CustomerID { get; set; }
        string CustomerName { get; set; }
        string PhoneNumber { get; set; }
        string Email { get; set; }
        Decimal Coupon {  get; set; }
        bool Male { get; set; }
        bool Female { get; set; }
        bool Other { get; set; }

        string SearchValue { get; }

        bool IsEdit { get; set; }

        bool IsSuccessful { get; set; }

        bool IsOpen { get; }

        // Updating...
        void Show();

        void SetCustomerListBindingSource(BindingSource customerList);

        event EventHandler SearchEvent;
		event EventHandler AddNewEvent;
		event EventHandler EditEvent;
		event EventHandler DeleteEvent;
		event EventHandler SaveEvent;
		event EventHandler ClearEvent;
		event EventHandler BackToListEvent;
	}
}

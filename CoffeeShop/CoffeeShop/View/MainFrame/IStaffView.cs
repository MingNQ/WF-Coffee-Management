using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View.MainFrame
{
	public interface IStaffView
	{
		bool IsEdit { get; set; }

		bool IsSuccessful { get; set; }

		// Updating...
		void Show();

		void SetLPetListBindingSource(BindingSource staffList);

		event EventHandler SearchEvent;
		event EventHandler AddNewEvent;
		event EventHandler EditEvent;
		event EventHandler DeleteEvent;
		event EventHandler SaveEvent;
		event EventHandler ClearEvent;
		event EventHandler BackToListEvent;
	}
}

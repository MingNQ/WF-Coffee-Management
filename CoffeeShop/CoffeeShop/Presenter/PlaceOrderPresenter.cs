using CoffeeShop.View.MainFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Presenter
{
    public class PlaceOrderPresenter
    {
        IPlaceOrderView view;

        public PlaceOrderPresenter(IPlaceOrderView _view)
        {
            view = _view;
            view.Show();
        }
    }
}

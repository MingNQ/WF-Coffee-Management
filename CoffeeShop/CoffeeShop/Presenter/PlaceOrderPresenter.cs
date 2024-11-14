using CoffeeShop._Repositories.InterfaceModel;
using CoffeeShop.Model;
using CoffeeShop.View.MainFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="_view"></param>
        /// <param name="_repository"></param>
        public PlaceOrderPresenter(IPlaceOrderView _view, IPlaceOrderRepository _repository)
        {
            view = _view;

            // If not open  
            if (!view.IsOpen)
            {
                repository = _repository;
                bindingSource = new BindingSource();

                view.FloorNo = 1;
                view.DisplayPage += DisplayPageEvent;
                view.DisplayPreviousPage += DisplayPreviousPageEvent;
                view.DisplayNextPage += DisplayNextPageEvent;
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
        /// Curr Floor
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        private string CurrFloor(int no)
        {
            return "Floor0" + no;
        }

        #endregion

        #region public fields
        #endregion
    }
}

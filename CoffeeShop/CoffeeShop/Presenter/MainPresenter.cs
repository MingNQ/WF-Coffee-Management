using CoffeeShop._Repositories;
using CoffeeShop.Model.InterfaceModel;
using CoffeeShop.View;
using CoffeeShop.View.DialogCheckList;
using CoffeeShop.View.MainFrame;
using CoffeeShop.View.MainFrame.Interfaces;
using CoffeeShop.View.DialogForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop._Repositories.InterfaceModel;
using CoffeeShop.Utilities;

namespace CoffeeShop.Presenter
{
    public class MainPresenter
    {
        #region Fields
        /// <summary>
        /// Interface Main View
        /// </summary>
        private IMainView mainView;

        /// <summary>
        /// Connection String
        /// </summary>
        private readonly string sqlConnectionString;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="view">View</param>
        public MainPresenter(IMainView view, string sqlConnectionString)
        {
            this.mainView = view;
            this.sqlConnectionString = sqlConnectionString;

            if (!mainView.IsOpen)
            {
                this.mainView.ShowDashboardView += ShowDashboardView;
                this.mainView.ShowPlaceOrderView += ShowPlaceOrderView;
                this.mainView.ShowStaffView += ShowStaffView;
                this.mainView.ShowCustomerView += ShowCustomerView;
                this.mainView.ShowCategoryView += ShowCategoryView;
                this.mainView.ShowIngredientView += ShowIngredientView;
                this.mainView.ShowAccountView += ShowAccountView;
                this.mainView.ShowStaffDetailInformation += ShowStaffDetailView;
            }

            this.mainView.Show();
            InitializeView();
        }

        #region private fields

        /// <summary>
        /// Event Show Dashboard view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowDashboardView(object sender, EventArgs e)
        {
            IDashboardView view = DashboardView.GetInstance((MainView)mainView);
            IDashboardRepository repository = new DashboardRepository(sqlConnectionString);
            new DashboardPresenter(view, repository);
        }

        /// <summary>
        /// Event Show Staff view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowStaffView(object sender, EventArgs e)
        {
            IStaffView view = StaffView.GetInstance((MainView)mainView);
            IStaffRepository repository = new StaffRepository(sqlConnectionString);

            new StaffPresenter(view, repository);
        }

        /// <summary>
        /// Event Show Customer View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowCustomerView(object sender, EventArgs e)
        {
            ICustomerView view = CustomerView.GetInstance((MainView)mainView);
            ICustomerRepository repository = new CustomerRepository(sqlConnectionString);

            new CustomerPresenter(view, repository);
        }

        /// <summary>
        /// Event Show Ingredient View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowIngredientView(object sender, EventArgs e)
        {
            IIngredientView view = IngredientView.GetInstance((MainView)mainView);
            IIngredientRepository repository = new IngredientRepository(sqlConnectionString);
            new IngredientPresenter(view, repository);
        }

        /// <summary>
        /// Event Show Category View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowCategoryView(object sender, EventArgs e)
		{
			ICategoryView view = CategoryView.GetInstance((MainView)mainView);
			IEditCategoryView editCategoryView = new EditCategoryView();
			ICategoryRepository repository = new CategoryRepository(sqlConnectionString);
			IIngredientRepository ingredientRepository = new IngredientRepository(sqlConnectionString);
            new CategoryPresenter(view, repository, editCategoryView, ingredientRepository);
        }

        /// <summary>
        /// Event Show Account View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowAccountView(object sender, EventArgs e)
        {
            IAccountView view = AccountView.GetInstance((MainView)mainView);
            IAccountRepository repository = new AccountRepository(sqlConnectionString);
            new AccountPresenter(view, repository);
        }
        /// <summary>
        /// Event Show Staff Detail View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowStaffDetailView(object sender, EventArgs e)
        {
            IStaffDetailView view = StaffDetailView.GetInstance((MainView)mainView);
            IStaffRepository repository = new StaffRepository(sqlConnectionString);
            IAccountRepository accountRepository = new AccountRepository(sqlConnectionString);
            view.StaffId = mainView.StaffID;
            new StaffDetailPresenter(view, repository,accountRepository);
        }

        /// <summary>
        /// Event Show Place Order View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowPlaceOrderView(object sender, EventArgs e)
        {
            IPlaceOrderView view = PlaceOrderView.GetInstance((MainView)mainView);
            IPlaceOrderRepository repository = new PlaceOrderRepository(sqlConnectionString);
            ICategoryRepository category = new CategoryRepository(sqlConnectionString);

            new PlaceOrderPresenter(view, repository, category);
        }

        /// <summary>
        /// Initialize View
        /// </summary>
        private void InitializeView()
        {
            IDashboardView view = DashboardView.GetInstance((MainView)mainView);
            IDashboardRepository repository = new DashboardRepository(sqlConnectionString);
            new DashboardPresenter(view, repository);
        }
        #endregion

        #region public fields
        #endregion
    }
}

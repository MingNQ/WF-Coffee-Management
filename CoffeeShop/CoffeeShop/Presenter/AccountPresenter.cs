using CoffeeShop.Model;
using CoffeeShop.Model.InterfaceModel;
using CoffeeShop.View.MainFrame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.Presenter
{
    public class AccountPresenter
    {
        #region Fields
        /// <summary>
        /// View
        /// </summary>
        private IAccountView view;

        /// <summary>
        /// Repository
        /// </summary>
        private IAccountRepository repository;

        /// <summary>
        /// 
        /// </summary>
        private BindingSource accountBindingSource;

        /// <summary>
        /// 
        /// </summary>
        private IEnumerable<Account> accountList;

        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        public AccountPresenter(IAccountView view, IAccountRepository repository)
        {
            this.view = view;

            if (!this.view.IsOpen)
            {
                this.repository = repository;
                accountBindingSource = new BindingSource();
                this.view.SetAccountListBindingSource(accountBindingSource);
                LoadAccountList();
            }
            this.view.Show();
        }

        private void LoadAccountList()
        {
            accountList = repository.GetAll();
            accountBindingSource.DataSource = accountList.Select(a => new
            {
                a.AccountID,
                a.Username,
                a.Password,
                a.Active,
                StaffName = a.Staff.StaffName
            }).ToList();
        }
    }
}

using CoffeeShop.Model;
using CoffeeShop.Model.InterfaceModel;
using CoffeeShop.Presenter.Common;
using CoffeeShop.View;
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

                this.view.ActiveEvent += ActiveEvent;
                this.view.DisableEvent += DisableEvent;
                this.view.DeleteEvent += DeleteEvent;
                this.view.SearchEvent += SearchEvent;

                this.view.SetAccountListBindingSource(accountBindingSource);
                LoadAccountList();
            }
            this.view.Show();
        }

        /// <summary>
        /// Active Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActiveEvent(object sender, EventArgs e)
        {
            var accountUser = (AccountUser)accountBindingSource.Current;
            var account = new Account
            {
                AccountID = accountUser.AccountID,
                Active = accountUser.Active
            };

            // If is active return
            if (account.Active == true)
                return;

            try
            {
                account.Active = true;
                repository.Edit(account);
                LoadAccountList();
                MessageBox.Show($"Account ID {account.AccountID} is Activated", "Notify", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Edit Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisableEvent(object sender, EventArgs e)
        {
            var accountUser = (AccountUser)accountBindingSource.Current;
            var account = new Account
            {
                AccountID = accountUser.AccountID,
                Active = accountUser.Active
            };

            // If is not active return
            if (account.Active == false) 
                return;

            try
            {
                account.Active = false;
                repository.Edit(account);
                LoadAccountList();
                MessageBox.Show($"Account ID {account.AccountID} is Disabled", "Notify", MessageBoxButtons.OK);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Delete Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteEvent(object sender, EventArgs e)
        {
            try
            {
                var accountUser = (AccountUser)accountBindingSource.Current;
                repository.Delete(accountUser.AccountID);
                LoadAccountList();
                MessageBox.Show("Successul delete Account", "Notify", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch
            {
                MessageBox.Show("An error occured, Could not delete this Account because it's in used!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Search Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchEvent(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);

            if (!emptyValue)
            {
                accountList = repository.GetByValue(this.view.SearchValue);
            }
            else
            {
                accountList = repository.GetAll();
            }
            BindingSource();
        }

        /// <summary>
        /// Load Account List
        /// </summary>
        private void LoadAccountList()
        {
            accountList = repository.GetAll();
            BindingSource();
        }

        /// <summary>
        /// Binding data Source
        /// </summary>
        private void BindingSource()
        {
            accountBindingSource.DataSource = accountList.Select(a => new AccountUser
            {
                AccountID = a.AccountID,
                Username = a.Username,
                Password = EncryptPassword.HashPassword(a.Password),
                Active = a.Active,
                StaffName = a.Staff.StaffName
            });
        }
    }

    /// <summary>
    /// Class Store Account and User
    /// </summary>
    public class AccountUser
    {
        public string AccountID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public string StaffName {  get; set; } 
    }
}

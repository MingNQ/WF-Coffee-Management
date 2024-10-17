using CoffeeShop.View.DialogCheckList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Presenter
{
    public class EditCategoryPresenter
    {
        private IEditCategoryView editCategoryView;

        public EditCategoryPresenter(IEditCategoryView view)
        {
            this.editCategoryView = view;

            // Show Form
            this.editCategoryView.ShowDialog();
        }

    }
}

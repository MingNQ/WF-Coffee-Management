using CoffeeShop.View.DialogCheckList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CoffeeShop.View.MainFrame
{
    public partial class CategoryView : Form, ICategoryView
    {
        #region Fields
        /// <summary>
        /// Instance
        /// </summary>
        private static CategoryView instance;

        /// <summary>
        /// Check if is edit or add
        /// </summary>
        private bool isEdit;

        #endregion


        #region Properties
        /// <summary>
        /// Check if is edit or add
        /// </summary>
        public bool IsEdit { get { return isEdit; } set { isEdit = value; } }
        #endregion

        public CategoryView()
        {
            InitializeComponent();
            tabControl_Food.TabPages.Remove(tabPage2);
            tabControl_Food.TabPages.Remove(tabPage3);

            btnAdd_Ingredient.Click += delegate
            {
                ShowEditDialogCheckList?.Invoke(this, EventArgs.Empty);
            };
            btnViewFood.Click += delegate
            {
                ViewFoodEvent?.Invoke(this, EventArgs.Empty);
                tabControl_Food.TabPages.Remove(tabPage1);
                tabControl_Food.TabPages.Add(tabPage2);

            };

            btnAdd.Click += delegate
            {
                isEdit = false;
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabControl_Food.TabPages.Remove(tabPage1);
                tabControl_Food.TabPages.Remove(tabPage2);
                tabControl_Food.TabPages.Add(tabPage3);
            };

            btnEdit.Click += delegate
            {
                isEdit = true;
                EditNewEvent?.Invoke(this, EventArgs.Empty);
                tabControl_Food.TabPages.Remove(tabPage1);
                tabControl_Food.TabPages.Remove(tabPage2);
                tabControl_Food.TabPages.Add(tabPage3);
            };

            btnBack.Click += delegate
            {
                tabControl_Food.TabPages.Remove(tabPage2);
                if (!tabControl_Food.TabPages.Contains(tabPage1))
                {
                    tabControl_Food.TabPages.Add(tabPage1);
                }
            };

            btn_back.Click += delegate
            {
                // Xóa tabPage1 và tabPage3 khỏi tabControl1
                tabControl_Food.TabPages.Remove(tabPage1);
                tabControl_Food.TabPages.Remove(tabPage3);

                // Thêm lại tabPage2 vào tabControl1 nếu nó chưa có
                if (!tabControl_Food.TabPages.Contains(tabPage2))
                {
                    tabControl_Food.TabPages.Add(tabPage2);
                }
            };


            this.Controls.Add(tabControl_Food);


        }

		

        #region public fields

        /// <summary>
        /// Get Instance
        /// </summary>
        /// <param name="parentContainer"></param>
        /// <returns>Instance</returns>
        public static CategoryView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new CategoryView();
                instance.MdiParent = parentContainer;
                instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }

            return instance;
        }

        #endregion

        #region Events
        /// <summary>
        /// Show Edit Dialog
        /// </summary>
        public event EventHandler ShowEditDialogCheckList;
        #endregion


        public event EventHandler ViewFoodEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditNewEvent;
    }
}

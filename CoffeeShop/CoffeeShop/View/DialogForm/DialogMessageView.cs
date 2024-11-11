using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop.View.DialogForm
{
    public partial class DialogMessageView : Form
    {

        /// <summary>
        /// Constructor
        /// </summary>
        public DialogMessageView(string type, string message)
        {
            InitializeComponent();

            // Show
            MessageBox(type, message);

            // Raise Events
            btnPrimary.Click += CloseDialogEvent;
            btnSecondary.Click += CancelEvent; 
        }

        /// <summary>
        /// Cancel Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelEvent(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseDialogEvent(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Show Message
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        private void MessageBox(string type, string message)
        {
            lbMessage.Text = message;
            btnPrimary.Text = "Ok";
            btnSecondary.Text = "Cancel";
            btnSecondary.Visible = false;

            // Base path from Debug folder
            string basePath = @"..\..\Resources";
            string imagePath = "";

            switch (type.ToLower())
            {
                case "success":
                    imagePath = Path.Combine(Application.StartupPath, basePath, "successIcon.png");
                    btnPrimary.FillColor = Color.FromArgb(119, 204, 0);
                    break;
                case "warning":
                    imagePath = Path.Combine(Application.StartupPath, basePath, "warningIcon.png");
                    btnPrimary.FillColor = Color.FromArgb(255, 180, 0);
                    btnSecondary.Visible = true;
                    break;
                case "error":
                    imagePath = Path.Combine(Application.StartupPath, basePath, "errorIcon.png");
                    btnPrimary.FillColor = Color.FromArgb(224, 79, 95);
                    break;
                case "information":
                default:
                    imagePath = Path.Combine(Application.StartupPath, basePath, "informationIcon.png");
                    btnPrimary.FillColor = Color.FromArgb(33, 150, 243);
                    break;
            }

            picDialog.Size = new Size(50, 50);
            picDialog.SizeMode = PictureBoxSizeMode.StretchImage;
            picDialog.Image = Image.FromFile(imagePath);

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// Show Dialog
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public static DialogResult ShowMessage(string type, string message)
        {
            using (var dialog = new DialogMessageView(type, message))
            {
                return dialog.ShowDialog();
            }
        }
    }
}

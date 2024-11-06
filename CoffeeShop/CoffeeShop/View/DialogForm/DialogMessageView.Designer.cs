namespace CoffeeShop.View.DialogForm
{
    partial class DialogMessageView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.picDialog = new System.Windows.Forms.PictureBox();
            this.btnSecondary = new Guna.UI2.WinForms.Guna2Button();
            this.btnPrimary = new Guna.UI2.WinForms.Guna2Button();
            this.lbMessage = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDialog)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.picDialog);
            this.panel1.Controls.Add(this.btnSecondary);
            this.panel1.Controls.Add(this.btnPrimary);
            this.panel1.Controls.Add(this.lbMessage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 300);
            this.panel1.TabIndex = 5;
            // 
            // picDialog
            // 
            this.picDialog.Location = new System.Drawing.Point(222, 10);
            this.picDialog.Name = "picDialog";
            this.picDialog.Size = new System.Drawing.Size(50, 50);
            this.picDialog.TabIndex = 8;
            this.picDialog.TabStop = false;
            // 
            // btnSecondary
            // 
            this.btnSecondary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSecondary.BorderColor = System.Drawing.Color.DimGray;
            this.btnSecondary.BorderRadius = 20;
            this.btnSecondary.BorderThickness = 1;
            this.btnSecondary.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSecondary.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSecondary.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSecondary.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSecondary.FillColor = System.Drawing.Color.WhiteSmoke;
            this.btnSecondary.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSecondary.ForeColor = System.Drawing.Color.Black;
            this.btnSecondary.Location = new System.Drawing.Point(47, 243);
            this.btnSecondary.Name = "btnSecondary";
            this.btnSecondary.Size = new System.Drawing.Size(404, 45);
            this.btnSecondary.TabIndex = 7;
            this.btnSecondary.Text = "guna2Button2";
            // 
            // btnPrimary
            // 
            this.btnPrimary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrimary.BorderRadius = 20;
            this.btnPrimary.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrimary.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrimary.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrimary.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrimary.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrimary.ForeColor = System.Drawing.Color.White;
            this.btnPrimary.Location = new System.Drawing.Point(47, 183);
            this.btnPrimary.Name = "btnPrimary";
            this.btnPrimary.Size = new System.Drawing.Size(404, 45);
            this.btnPrimary.TabIndex = 6;
            this.btnPrimary.Text = "guna2Button1";
            // 
            // lbMessage
            // 
            this.lbMessage.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMessage.Location = new System.Drawing.Point(47, 80);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(400, 70);
            this.lbMessage.TabIndex = 5;
            this.lbMessage.Text = "label1";
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // DialogMessageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DialogMessageView";
            this.Text = "DialogMessageView";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDialog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picDialog;
        private Guna.UI2.WinForms.Guna2Button btnSecondary;
        private Guna.UI2.WinForms.Guna2Button btnPrimary;
        private System.Windows.Forms.Label lbMessage;
    }
}
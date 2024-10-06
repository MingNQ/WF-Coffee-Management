namespace CoffeeShop.View.MainFrame
{
	partial class IngredientView
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
			this.btnShowDialog = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnShowDialog
			// 
			this.btnShowDialog.Location = new System.Drawing.Point(315, 286);
			this.btnShowDialog.Name = "btnShowDialog";
			this.btnShowDialog.Size = new System.Drawing.Size(197, 23);
			this.btnShowDialog.TabIndex = 0;
			this.btnShowDialog.Text = "ShowDialog";
			this.btnShowDialog.UseVisualStyleBackColor = true;
			// 
			// IngredientView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.ClientSize = new System.Drawing.Size(930, 642);
			this.Controls.Add(this.btnShowDialog);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "IngredientView";
			this.Text = "IngredientView";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnShowDialog;
	}
}
namespace WinFormsApp.Forms
{
	partial class ProductsCustomForm
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
			btnSave = new Button();
			flpnlProducts = new FlowLayoutPanel();
			SuspendLayout();
			// 
			// btnSave
			// 
			btnSave.Location = new Point(12, 12);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(112, 34);
			btnSave.TabIndex = 3;
			btnSave.Text = "save";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnSave_Click;
			// 
			// flpnlProducts
			// 
			flpnlProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			flpnlProducts.AutoScroll = true;
			flpnlProducts.FlowDirection = FlowDirection.TopDown;
			flpnlProducts.Location = new Point(12, 52);
			flpnlProducts.Name = "flpnlProducts";
			flpnlProducts.Size = new Size(776, 386);
			flpnlProducts.TabIndex = 4;
			flpnlProducts.WrapContents = false;
			// 
			// ProductsCustomForm
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(flpnlProducts);
			Controls.Add(btnSave);
			Name = "ProductsCustomForm";
			Text = "ProductsForm";
			Load += ProductsDataGridForm_Load;
			ResumeLayout(false);
		}

		#endregion

		private Button btnSave;
		private FlowLayoutPanel flpnlProducts;
	}
}
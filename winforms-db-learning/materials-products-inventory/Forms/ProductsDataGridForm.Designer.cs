namespace WinFormsApp.Forms
{
	partial class ProductsDataGridForm
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
			dgvProducts = new DataGridView();
			((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
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
			btnSave.Click += this.btnSave_Click;
			// 
			// dgvProducts
			// 
			dgvProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvProducts.Location = new Point(12, 52);
			dgvProducts.Name = "dgvProducts";
			dgvProducts.RowHeadersWidth = 62;
			dgvProducts.Size = new Size(776, 386);
			dgvProducts.TabIndex = 2;
			// 
			// ProductsDataGridForm
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(btnSave);
			Controls.Add(dgvProducts);
			Name = "ProductsDataGridForm";
			Text = "ProductsForm";
			Load += ProductsDataGridForm_Load;
			((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Button btnSave;
		private DataGridView dgvProducts;
	}
}
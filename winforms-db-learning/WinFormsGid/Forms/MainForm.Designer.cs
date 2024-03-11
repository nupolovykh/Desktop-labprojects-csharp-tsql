namespace WinFormsApp
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			btnOpenMaterialDGForm = new Button();
			btnOpenProductsDGForm = new Button();
			btnOpenProductsCustomForm = new Button();
			SuspendLayout();
			// 
			// btnOpenMaterialDGForm
			// 
			btnOpenMaterialDGForm.Location = new Point(12, 12);
			btnOpenMaterialDGForm.Name = "btnOpenMaterialDGForm";
			btnOpenMaterialDGForm.Size = new Size(112, 112);
			btnOpenMaterialDGForm.TabIndex = 0;
			btnOpenMaterialDGForm.Text = "Materials DataGrid";
			btnOpenMaterialDGForm.UseVisualStyleBackColor = true;
			btnOpenMaterialDGForm.Click += btnOpenMaterialDGForm_Click;
			// 
			// btnOpenProductsDGForm
			// 
			btnOpenProductsDGForm.Location = new Point(130, 12);
			btnOpenProductsDGForm.Name = "btnOpenProductsDGForm";
			btnOpenProductsDGForm.Size = new Size(112, 112);
			btnOpenProductsDGForm.TabIndex = 1;
			btnOpenProductsDGForm.Text = "Products DataGrid";
			btnOpenProductsDGForm.UseVisualStyleBackColor = true;
			btnOpenProductsDGForm.Click += btnOpenProductsDGForm_Click;
			// 
			// btnOpenProductsCustomForm
			// 
			btnOpenProductsCustomForm.Location = new Point(130, 130);
			btnOpenProductsCustomForm.Name = "btnOpenProductsCustomForm";
			btnOpenProductsCustomForm.Size = new Size(112, 112);
			btnOpenProductsCustomForm.TabIndex = 2;
			btnOpenProductsCustomForm.Text = "Products Custom";
			btnOpenProductsCustomForm.UseVisualStyleBackColor = true;
			btnOpenProductsCustomForm.Click += btnOpenProductsCustomForm_Click;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(255, 256);
			Controls.Add(btnOpenProductsCustomForm);
			Controls.Add(btnOpenProductsDGForm);
			Controls.Add(btnOpenMaterialDGForm);
			Name = "MainForm";
			Text = "Main";
			ResumeLayout(false);
		}

		#endregion

		private Button btnOpenMaterialDGForm;
		private Button btnOpenProductsDGForm;
		private Button btnOpenProductsCustomForm;
	}
}

namespace WinFormsApp.Controls
{
	partial class ProductView
	{
		/// <summary> 
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			lblId = new Label();
			tbId = new TextBox();
			tbName = new TextBox();
			lblName = new Label();
			tbPrice = new TextBox();
			lblPrice = new Label();
			cbMaterial = new ComboBox();
			lblMaterial = new Label();
			SuspendLayout();
			// 
			// lblId
			// 
			lblId.AutoSize = true;
			lblId.Location = new Point(3, 0);
			lblId.Name = "lblId";
			lblId.Size = new Size(28, 25);
			lblId.TabIndex = 0;
			lblId.Text = "Id";
			// 
			// tbId
			// 
			tbId.Location = new Point(3, 28);
			tbId.Name = "tbId";
			tbId.Size = new Size(59, 31);
			tbId.TabIndex = 1;
			// 
			// tbName
			// 
			tbName.Location = new Point(68, 28);
			tbName.Name = "tbName";
			tbName.Size = new Size(264, 31);
			tbName.TabIndex = 3;
			// 
			// lblName
			// 
			lblName.AutoSize = true;
			lblName.Location = new Point(68, 0);
			lblName.Name = "lblName";
			lblName.Size = new Size(59, 25);
			lblName.TabIndex = 2;
			lblName.Text = "Name";
			// 
			// tbPrice
			// 
			tbPrice.Location = new Point(338, 28);
			tbPrice.Name = "tbPrice";
			tbPrice.Size = new Size(98, 31);
			tbPrice.TabIndex = 5;
			// 
			// lblPrice
			// 
			lblPrice.AutoSize = true;
			lblPrice.Location = new Point(338, 0);
			lblPrice.Name = "lblPrice";
			lblPrice.Size = new Size(49, 25);
			lblPrice.TabIndex = 4;
			lblPrice.Text = "Price";
			// 
			// cbMaterial
			// 
			cbMaterial.FormattingEnabled = true;
			cbMaterial.Location = new Point(84, 65);
			cbMaterial.Name = "cbMaterial";
			cbMaterial.Size = new Size(248, 33);
			cbMaterial.TabIndex = 6;
			// 
			// lblMaterial
			// 
			lblMaterial.AutoSize = true;
			lblMaterial.Location = new Point(3, 68);
			lblMaterial.Name = "lblMaterial";
			lblMaterial.Size = new Size(75, 25);
			lblMaterial.TabIndex = 7;
			lblMaterial.Text = "Material";
			// 
			// ProductView
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(lblMaterial);
			Controls.Add(cbMaterial);
			Controls.Add(tbPrice);
			Controls.Add(lblPrice);
			Controls.Add(tbName);
			Controls.Add(lblName);
			Controls.Add(tbId);
			Controls.Add(lblId);
			Name = "ProductView";
			Size = new Size(439, 105);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblId;
		private TextBox tbId;
		private TextBox tbName;
		private Label lblName;
		private TextBox tbPrice;
		private Label lblPrice;
		private ComboBox cbMaterial;
		private Label lblMaterial;
	}
}

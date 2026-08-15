namespace WinFormsApp.Forms
{
	partial class MaterialsDataGridForm
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
			dgvMaterials = new DataGridView();
			btnSave = new Button();
			((System.ComponentModel.ISupportInitialize)dgvMaterials).BeginInit();
			SuspendLayout();
			// 
			// dgvMaterials
			// 
			dgvMaterials.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dgvMaterials.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvMaterials.Location = new Point(12, 52);
			dgvMaterials.Name = "dgvMaterials";
			dgvMaterials.RowHeadersWidth = 62;
			dgvMaterials.Size = new Size(776, 386);
			dgvMaterials.TabIndex = 0;
			// 
			// btnSave
			// 
			btnSave.Location = new Point(12, 12);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(112, 34);
			btnSave.TabIndex = 1;
			btnSave.Text = "save";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += this.btnSave_Click;
			// 
			// MaterialsDataGridForm
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(btnSave);
			Controls.Add(dgvMaterials);
			Name = "MaterialsDataGridForm";
			Text = "MaterialsForm";
			Load += MaterialsDataGridForm_Load;
			((System.ComponentModel.ISupportInitialize)dgvMaterials).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private DataGridView dgvMaterials;
		private Button btnSave;
	}
}
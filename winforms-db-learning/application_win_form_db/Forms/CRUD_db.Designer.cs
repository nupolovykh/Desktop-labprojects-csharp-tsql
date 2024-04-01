namespace application_win_form_db
{
    partial class CRUD_db
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
			lbl_choose = new Label();
			cmbBx_tables = new ComboBox();
			dgv = new DataGridView();
			btn_retrn = new Button();
			btn_c = new Button();
			button_d = new Button();
			btn_sort_desc = new Button();
			btn_sort_asc = new Button();
			lbl_sort = new Label();
			cmbBx_columns = new ComboBox();
			lbl_search = new Label();
			txtBx_search = new TextBox();
			btn_save = new Button();
			rtn_cancel = new Button();
			btn_search = new Button();
			((ISupportInitialize)dgv).BeginInit();
			SuspendLayout();
			// 
			// lbl_choose
			// 
			lbl_choose.AutoSize = true;
			lbl_choose.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_choose.Location = new Point(945, 271);
			lbl_choose.Name = "lbl_choose";
			lbl_choose.Size = new Size(127, 19);
			lbl_choose.TabIndex = 10;
			lbl_choose.Text = "Choose the table";
			// 
			// cmbBx_tables
			// 
			cmbBx_tables.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			cmbBx_tables.FormattingEnabled = true;
			cmbBx_tables.Location = new Point(921, 294);
			cmbBx_tables.Margin = new Padding(3, 2, 3, 2);
			cmbBx_tables.Name = "cmbBx_tables";
			cmbBx_tables.Size = new Size(175, 27);
			cmbBx_tables.TabIndex = 9;
			cmbBx_tables.SelectedValueChanged += cmbBx_tables_SelectedValueChanged;
			// 
			// dgv
			// 
			dgv.BackgroundColor = SystemColors.Control;
			dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgv.Location = new Point(10, 9);
			dgv.Margin = new Padding(3, 2, 3, 2);
			dgv.Name = "dgv";
			dgv.RowHeadersWidth = 51;
			dgv.RowTemplate.Height = 29;
			dgv.Size = new Size(894, 578);
			dgv.TabIndex = 8;
			// 
			// btn_retrn
			// 
			btn_retrn.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btn_retrn.Location = new Point(921, 546);
			btn_retrn.Margin = new Padding(3, 2, 3, 2);
			btn_retrn.Name = "btn_retrn";
			btn_retrn.Size = new Size(175, 41);
			btn_retrn.TabIndex = 7;
			btn_retrn.Text = "Return to Main";
			btn_retrn.UseVisualStyleBackColor = true;
			btn_retrn.Click += btn_retrn_Click;
			// 
			// btn_c
			// 
			btn_c.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btn_c.Location = new Point(921, 325);
			btn_c.Margin = new Padding(3, 2, 3, 2);
			btn_c.Name = "btn_c";
			btn_c.Size = new Size(84, 38);
			btn_c.TabIndex = 11;
			btn_c.Text = "Create";
			btn_c.UseVisualStyleBackColor = true;
			btn_c.Click += btn_c_Click;
			// 
			// button_d
			// 
			button_d.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			button_d.Location = new Point(1011, 325);
			button_d.Margin = new Padding(3, 2, 3, 2);
			button_d.Name = "button_d";
			button_d.Size = new Size(85, 38);
			button_d.TabIndex = 13;
			button_d.Text = "Delete";
			button_d.UseVisualStyleBackColor = true;
			button_d.Click += btn_d_Click;
			// 
			// btn_sort_desc
			// 
			btn_sort_desc.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btn_sort_desc.Location = new Point(1011, 188);
			btn_sort_desc.Margin = new Padding(3, 2, 3, 2);
			btn_sort_desc.Name = "btn_sort_desc";
			btn_sort_desc.Size = new Size(85, 38);
			btn_sort_desc.TabIndex = 20;
			btn_sort_desc.Text = "DESC";
			btn_sort_desc.UseVisualStyleBackColor = true;
			btn_sort_desc.Click += btn_sort_desc_Click;
			// 
			// btn_sort_asc
			// 
			btn_sort_asc.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btn_sort_asc.Location = new Point(922, 188);
			btn_sort_asc.Margin = new Padding(3, 2, 3, 2);
			btn_sort_asc.Name = "btn_sort_asc";
			btn_sort_asc.Size = new Size(83, 38);
			btn_sort_asc.TabIndex = 19;
			btn_sort_asc.Text = "ASC";
			btn_sort_asc.UseVisualStyleBackColor = true;
			btn_sort_asc.Click += btn_sort_asc_Click;
			// 
			// lbl_sort
			// 
			lbl_sort.AutoSize = true;
			lbl_sort.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_sort.Location = new Point(945, 134);
			lbl_sort.Name = "lbl_sort";
			lbl_sort.Size = new Size(60, 19);
			lbl_sort.TabIndex = 18;
			lbl_sort.Text = "Sorting";
			// 
			// cmbBx_columns
			// 
			cmbBx_columns.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			cmbBx_columns.FormattingEnabled = true;
			cmbBx_columns.Location = new Point(921, 157);
			cmbBx_columns.Margin = new Padding(3, 2, 3, 2);
			cmbBx_columns.Name = "cmbBx_columns";
			cmbBx_columns.Size = new Size(175, 27);
			cmbBx_columns.TabIndex = 17;
			// 
			// lbl_search
			// 
			lbl_search.AutoSize = true;
			lbl_search.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_search.Location = new Point(945, 9);
			lbl_search.Name = "lbl_search";
			lbl_search.Size = new Size(56, 19);
			lbl_search.TabIndex = 16;
			lbl_search.Text = "Search";
			// 
			// txtBx_search
			// 
			txtBx_search.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			txtBx_search.Location = new Point(922, 31);
			txtBx_search.Margin = new Padding(3, 2, 3, 2);
			txtBx_search.Name = "txtBx_search";
			txtBx_search.Size = new Size(174, 27);
			txtBx_search.TabIndex = 15;
			// 
			// btn_save
			// 
			btn_save.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btn_save.Location = new Point(922, 367);
			btn_save.Margin = new Padding(3, 2, 3, 2);
			btn_save.Name = "btn_save";
			btn_save.Size = new Size(83, 38);
			btn_save.TabIndex = 21;
			btn_save.Text = "Save";
			btn_save.UseVisualStyleBackColor = true;
			btn_save.Click += btn_save_Click;
			// 
			// rtn_cancel
			// 
			rtn_cancel.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			rtn_cancel.Location = new Point(1011, 367);
			rtn_cancel.Margin = new Padding(3, 2, 3, 2);
			rtn_cancel.Name = "rtn_cancel";
			rtn_cancel.Size = new Size(85, 38);
			rtn_cancel.TabIndex = 22;
			rtn_cancel.Text = "Cancel";
			rtn_cancel.UseVisualStyleBackColor = true;
			rtn_cancel.Click += rtn_cancel_Click;
			// 
			// btn_search
			// 
			btn_search.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btn_search.Location = new Point(922, 62);
			btn_search.Margin = new Padding(3, 2, 3, 2);
			btn_search.Name = "btn_search";
			btn_search.Size = new Size(174, 38);
			btn_search.TabIndex = 23;
			btn_search.Text = "Search";
			btn_search.UseVisualStyleBackColor = true;
			btn_search.Click += btn_search_Click;
			// 
			// CRUD_db
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ButtonShadow;
			ClientSize = new Size(1108, 598);
			Controls.Add(btn_search);
			Controls.Add(rtn_cancel);
			Controls.Add(btn_save);
			Controls.Add(btn_sort_desc);
			Controls.Add(btn_sort_asc);
			Controls.Add(lbl_sort);
			Controls.Add(cmbBx_columns);
			Controls.Add(lbl_search);
			Controls.Add(txtBx_search);
			Controls.Add(button_d);
			Controls.Add(btn_c);
			Controls.Add(lbl_choose);
			Controls.Add(cmbBx_tables);
			Controls.Add(dgv);
			Controls.Add(btn_retrn);
			Margin = new Padding(3, 2, 3, 2);
			Name = "CRUD_db";
			Text = "CRUD_db";
			FormClosing += CRUD_db_FormClosing;
			((ISupportInitialize)dgv).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lbl_choose;
        private ComboBox cmbBx_tables;
        private DataGridView dgv;
        private Button btn_retrn;
        private Button btn_c;
        private Button button_d;
        private Button btn_sort_desc;
        private Button btn_sort_asc;
        private Label lbl_sort;
        private ComboBox cmbBx_columns;
        private Label lbl_search;
        private TextBox txtBx_search;
		private Button btn_save;
		private Button rtn_cancel;
		private Button btn_search;
	}
}
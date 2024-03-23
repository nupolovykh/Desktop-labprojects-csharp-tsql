namespace application_win_form_db
{
    partial class Main
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
			btn_anlytc = new Button();
			btn_crud_db = new Button();
			lbl_role1 = new Label();
			lbl_role2 = new Label();
			lbl_notes = new Label();
			btn_logOut = new Button();
			txtBx_notes = new TextBox();
			SuspendLayout();
			// 
			// btn_anlytc
			// 
			btn_anlytc.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btn_anlytc.Location = new Point(26, 138);
			btn_anlytc.Margin = new Padding(3, 2, 3, 2);
			btn_anlytc.Name = "btn_anlytc";
			btn_anlytc.Size = new Size(175, 56);
			btn_anlytc.TabIndex = 0;
			btn_anlytc.Text = "Analytics Page";
			btn_anlytc.UseVisualStyleBackColor = true;
			btn_anlytc.Click += btn_anlytc_Click;
			// 
			// btn_crud_db
			// 
			btn_crud_db.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btn_crud_db.Location = new Point(26, 69);
			btn_crud_db.Margin = new Padding(3, 2, 3, 2);
			btn_crud_db.Name = "btn_crud_db";
			btn_crud_db.Size = new Size(175, 56);
			btn_crud_db.TabIndex = 6;
			btn_crud_db.Text = "CRUD-db Page";
			btn_crud_db.UseVisualStyleBackColor = true;
			btn_crud_db.Click += btn_crud_db_Click;
			// 
			// lbl_role1
			// 
			lbl_role1.AutoSize = true;
			lbl_role1.Font = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_role1.Location = new Point(47, 9);
			lbl_role1.Name = "lbl_role1";
			lbl_role1.Size = new Size(130, 25);
			lbl_role1.TabIndex = 7;
			lbl_role1.Text = "Your Role is:";
			// 
			// lbl_role2
			// 
			lbl_role2.AutoSize = true;
			lbl_role2.Font = new Font("Tahoma", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_role2.Location = new Point(174, 9);
			lbl_role2.Name = "lbl_role2";
			lbl_role2.Size = new Size(62, 25);
			lbl_role2.TabIndex = 8;
			lbl_role2.Text = "xxxxx";
			// 
			// lbl_notes
			// 
			lbl_notes.AutoSize = true;
			lbl_notes.Font = new Font("Tahoma", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_notes.Location = new Point(607, 35);
			lbl_notes.Name = "lbl_notes";
			lbl_notes.Size = new Size(141, 23);
			lbl_notes.TabIndex = 10;
			lbl_notes.Text = "Your own notes";
			// 
			// btn_logOut
			// 
			btn_logOut.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btn_logOut.Location = new Point(26, 530);
			btn_logOut.Margin = new Padding(3, 2, 3, 2);
			btn_logOut.Name = "btn_logOut";
			btn_logOut.Size = new Size(175, 56);
			btn_logOut.TabIndex = 11;
			btn_logOut.Text = "Log Out";
			btn_logOut.UseVisualStyleBackColor = true;
			btn_logOut.Click += btn_logOut_Click;
			// 
			// txtBx_notes
			// 
			txtBx_notes.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
			txtBx_notes.Location = new Point(271, 69);
			txtBx_notes.Margin = new Padding(3, 2, 3, 2);
			txtBx_notes.Multiline = true;
			txtBx_notes.Name = "txtBx_notes";
			txtBx_notes.ScrollBars = ScrollBars.Vertical;
			txtBx_notes.Size = new Size(825, 517);
			txtBx_notes.TabIndex = 12;
			txtBx_notes.TextChanged += txtBx_notes_TextChanged;
			// 
			// Main
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ButtonShadow;
			ClientSize = new Size(1108, 598);
			Controls.Add(txtBx_notes);
			Controls.Add(btn_logOut);
			Controls.Add(lbl_notes);
			Controls.Add(lbl_role2);
			Controls.Add(lbl_role1);
			Controls.Add(btn_crud_db);
			Controls.Add(btn_anlytc);
			Margin = new Padding(3, 2, 3, 2);
			Name = "Main";
			Text = "Main";
			FormClosing += Main_FormClosing;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btn_anlytc;
        private Button btn_crud_db;
        private Label lbl_role1;
        private Label lbl_role2;
        private Label lbl_notes;
		private Button btn_logOut;
		private TextBox txtBx_notes;
	}
}
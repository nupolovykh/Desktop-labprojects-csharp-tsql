namespace application_win_form_db
{
    partial class Entrance
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
			btn_entrance = new Button();
			txtBx_db = new TextBox();
			textBox1 = new TextBox();
			textBox2 = new TextBox();
			lbl_desc_1 = new Label();
			label1 = new Label();
			label2 = new Label();
			SuspendLayout();
			// 
			// btn_entrance
			// 
			btn_entrance.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			btn_entrance.Location = new Point(244, 279);
			btn_entrance.Margin = new Padding(3, 2, 3, 2);
			btn_entrance.Name = "btn_entrance";
			btn_entrance.Size = new Size(175, 38);
			btn_entrance.TabIndex = 0;
			btn_entrance.Text = "Enter";
			btn_entrance.UseVisualStyleBackColor = true;
			// 
			// txtBx_db
			// 
			txtBx_db.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			txtBx_db.Location = new Point(164, 73);
			txtBx_db.Margin = new Padding(3, 2, 3, 2);
			txtBx_db.Name = "txtBx_db";
			txtBx_db.Size = new Size(335, 32);
			txtBx_db.TabIndex = 1;
			// 
			// textBox1
			// 
			textBox1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			textBox1.Location = new Point(164, 148);
			textBox1.Margin = new Padding(3, 2, 3, 2);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(335, 32);
			textBox1.TabIndex = 2;
			// 
			// textBox2
			// 
			textBox2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			textBox2.Location = new Point(164, 223);
			textBox2.Margin = new Padding(3, 2, 3, 2);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(335, 32);
			textBox2.TabIndex = 3;
			// 
			// lbl_desc_1
			// 
			lbl_desc_1.AutoSize = true;
			lbl_desc_1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_desc_1.Location = new Point(253, 47);
			lbl_desc_1.Name = "lbl_desc_1";
			lbl_desc_1.Size = new Size(157, 25);
			lbl_desc_1.TabIndex = 4;
			lbl_desc_1.Text = "Current database";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(250, 123);
			label1.Name = "label1";
			label1.Size = new Size(162, 25);
			label1.TabIndex = 5;
			label1.Text = "Inscribe you login";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
			label2.Location = new Point(234, 197);
			label2.Name = "label2";
			label2.Size = new Size(195, 25);
			label2.TabIndex = 6;
			label2.Text = "Inscribe the password";
			// 
			// Entrance
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(684, 361);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(lbl_desc_1);
			Controls.Add(textBox2);
			Controls.Add(textBox1);
			Controls.Add(txtBx_db);
			Controls.Add(btn_entrance);
			Margin = new Padding(3, 2, 3, 2);
			Name = "Entrance";
			Text = "Form1";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btn_entrance;
        private TextBox txtBx_db;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label lbl_desc_1;
        private Label label1;
        private Label label2;
    }
}
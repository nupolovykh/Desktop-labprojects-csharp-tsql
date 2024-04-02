namespace application_win_form_db
{
    partial class Analytics
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
			panel1 = new Panel();
			btn_retrn = new Button();
			cmbBx_date = new ComboBox();
			lbl_choose = new Label();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.Location = new Point(12, 11);
			panel1.Margin = new Padding(3, 2, 3, 2);
			panel1.Name = "panel1";
			panel1.Size = new Size(1084, 521);
			panel1.TabIndex = 0;
			// 
			// btn_retrn
			// 
			btn_retrn.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btn_retrn.Location = new Point(921, 546);
			btn_retrn.Margin = new Padding(3, 2, 3, 2);
			btn_retrn.Name = "btn_retrn";
			btn_retrn.Size = new Size(175, 41);
			btn_retrn.TabIndex = 2;
			btn_retrn.Text = "Return to Main";
			btn_retrn.UseVisualStyleBackColor = true;
			btn_retrn.Click += btn_retrn_Click;
			// 
			// cmbBx_date
			// 
			cmbBx_date.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			cmbBx_date.FormattingEnabled = true;
			cmbBx_date.Location = new Point(199, 553);
			cmbBx_date.Margin = new Padding(3, 2, 3, 2);
			cmbBx_date.Name = "cmbBx_date";
			cmbBx_date.Size = new Size(148, 27);
			cmbBx_date.TabIndex = 3;
			// 
			// lbl_choose
			// 
			lbl_choose.AutoSize = true;
			lbl_choose.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_choose.Location = new Point(12, 556);
			lbl_choose.Name = "lbl_choose";
			lbl_choose.Size = new Size(178, 19);
			lbl_choose.TabIndex = 4;
			lbl_choose.Text = "choose the time interval";
			// 
			// Analytics
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ButtonShadow;
			ClientSize = new Size(1108, 598);
			Controls.Add(lbl_choose);
			Controls.Add(cmbBx_date);
			Controls.Add(btn_retrn);
			Controls.Add(panel1);
			Margin = new Padding(3, 2, 3, 2);
			Name = "Analytics";
			Text = "Analytics";
			FormClosing += Analytics_FormClosing;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Panel panel1;
        private Button btn_retrn;
        private ComboBox cmbBx_date;
        private Label lbl_choose;
    }
}
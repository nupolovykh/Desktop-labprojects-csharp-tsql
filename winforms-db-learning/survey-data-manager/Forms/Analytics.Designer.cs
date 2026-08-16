using System.Windows.Forms.DataVisualization.Charting;

namespace MyWinFormsAppForDb
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
			btn_retrn = new Button();
			cmbBx_msrt = new ComboBox();
			lbl_choose = new Label();
			chrt_main = new Chart();
			((ISupportInitialize)chrt_main).BeginInit();
			SuspendLayout();
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
			// cmbBx_msrt
			// 
			cmbBx_msrt.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			cmbBx_msrt.FormattingEnabled = true;
			cmbBx_msrt.Location = new Point(149, 553);
			cmbBx_msrt.Margin = new Padding(3, 2, 3, 2);
			cmbBx_msrt.Name = "cmbBx_msrt";
			cmbBx_msrt.Size = new Size(281, 27);
			cmbBx_msrt.TabIndex = 3;
			cmbBx_msrt.SelectedValueChanged += cmbBx_msrt_SelectedValueChanged;
			// 
			// lbl_choose
			// 
			lbl_choose.AutoSize = true;
			lbl_choose.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point);
			lbl_choose.Location = new Point(12, 556);
			lbl_choose.Name = "lbl_choose";
			lbl_choose.Size = new Size(131, 19);
			lbl_choose.TabIndex = 4;
			lbl_choose.Text = "choose the picket";
			// 
			// chrt_main
			// 
			chrt_main.Location = new Point(12, 12);
			chrt_main.Name = "chrt_main";
			chrt_main.Size = new Size(1084, 529);
			chrt_main.TabIndex = 5;
			chrt_main.Text = "MainChart";
			// 
			// Analytics
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ButtonShadow;
			ClientSize = new Size(1108, 598);
			Controls.Add(chrt_main);
			Controls.Add(lbl_choose);
			Controls.Add(cmbBx_msrt);
			Controls.Add(btn_retrn);
			Margin = new Padding(3, 2, 3, 2);
			Name = "Analytics";
			Text = "Analytics";
			FormClosing += Analytics_FormClosing;
			((ISupportInitialize)chrt_main).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Button btn_retrn;
		private ComboBox cmbBx_msrt;
		private Label lbl_choose;
		private System.Windows.Forms.DataVisualization.Charting.Chart chrt_main;
	}
}
namespace Lab2
{
    partial class RegisterDialog
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
            lblPaswd = new Label();
            lblLog = new Label();
            txtBxPswd = new TextBox();
            txtBxLg = new TextBox();
            apl = new Button();
            lblRPswd = new Label();
            txtBxRPswd = new TextBox();
            SuspendLayout();
            // 
            // lblPaswd
            // 
            lblPaswd.AutoSize = true;
            lblPaswd.Location = new Point(216, 89);
            lblPaswd.Name = "lblPaswd";
            lblPaswd.Size = new Size(49, 15);
            lblPaswd.TabIndex = 9;
            lblPaswd.Text = "Пароль";
            // 
            // lblLog
            // 
            lblLog.AutoSize = true;
            lblLog.Location = new Point(216, 35);
            lblLog.Name = "lblLog";
            lblLog.Size = new Size(41, 15);
            lblLog.TabIndex = 8;
            lblLog.Text = "Логин";
            // 
            // txtBxPswd
            // 
            txtBxPswd.Location = new Point(136, 107);
            txtBxPswd.Name = "txtBxPswd";
            txtBxPswd.Size = new Size(220, 23);
            txtBxPswd.TabIndex = 7;
            // 
            // txtBxLg
            // 
            txtBxLg.Location = new Point(136, 53);
            txtBxLg.Name = "txtBxLg";
            txtBxLg.Size = new Size(220, 23);
            txtBxLg.TabIndex = 6;
            // 
            // apl
            // 
            apl.Location = new Point(191, 214);
            apl.Name = "apl";
            apl.Size = new Size(101, 38);
            apl.TabIndex = 5;
            apl.Text = "Применить";
            apl.UseVisualStyleBackColor = true;
            apl.Click += apl_Click;
            // 
            // lblRPswd
            // 
            lblRPswd.AutoSize = true;
            lblRPswd.Location = new Point(191, 147);
            lblRPswd.Name = "lblRPswd";
            lblRPswd.Size = new Size(109, 15);
            lblRPswd.TabIndex = 11;
            lblRPswd.Text = "Повторите пароль";
            // 
            // txtBxRPswd
            // 
            txtBxRPswd.Location = new Point(136, 165);
            txtBxRPswd.Name = "txtBxRPswd";
            txtBxRPswd.Size = new Size(220, 23);
            txtBxRPswd.TabIndex = 10;
            // 
            // RegisterDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 295);
            Controls.Add(lblRPswd);
            Controls.Add(txtBxRPswd);
            Controls.Add(lblPaswd);
            Controls.Add(lblLog);
            Controls.Add(txtBxPswd);
            Controls.Add(txtBxLg);
            Controls.Add(apl);
            Name = "RegisterDialog";
            Text = "RegisterDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPaswd;
        private Label lblLog;
        private TextBox txtBxPswd;
        private TextBox txtBxLg;
        private Button apl;
        private Label lblRPswd;
        private TextBox txtBxRPswd;
    }
}
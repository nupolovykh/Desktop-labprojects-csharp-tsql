namespace Lab2
{
    partial class LoginDialog
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
            apl = new Button();
            txtBxLg = new TextBox();
            txtBxPswd = new TextBox();
            lblLog = new Label();
            lblPswd = new Label();
            SuspendLayout();
            // 
            // apl
            // 
            apl.Location = new Point(176, 232);
            apl.Name = "apl";
            apl.Size = new Size(101, 38);
            apl.TabIndex = 0;
            apl.Text = "Применить";
            apl.UseVisualStyleBackColor = true;
            apl.Click += apl_Click;
            // 
            // txtBxLg
            // 
            txtBxLg.Location = new Point(125, 82);
            txtBxLg.Name = "txtBxLg";
            txtBxLg.Size = new Size(220, 23);
            txtBxLg.TabIndex = 1;
            // 
            // txtBxPswd
            // 
            txtBxPswd.Location = new Point(125, 154);
            txtBxPswd.Name = "txtBxPswd";
            txtBxPswd.Size = new Size(220, 23);
            txtBxPswd.TabIndex = 2;
            // 
            // lblLog
            // 
            lblLog.AutoSize = true;
            lblLog.Location = new Point(205, 64);
            lblLog.Name = "lblLog";
            lblLog.Size = new Size(41, 15);
            lblLog.TabIndex = 3;
            lblLog.Text = "Логин";
            // 
            // lblPswd
            // 
            lblPswd.AutoSize = true;
            lblPswd.Location = new Point(205, 136);
            lblPswd.Name = "lblPswd";
            lblPswd.Size = new Size(49, 15);
            lblPswd.TabIndex = 4;
            lblPswd.Text = "Пароль";
            // 
            // LoginDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 295);
            Controls.Add(lblPswd);
            Controls.Add(lblLog);
            Controls.Add(txtBxPswd);
            Controls.Add(txtBxLg);
            Controls.Add(apl);
            Name = "LoginDialog";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button apl;
        private TextBox txtBxLg;
        private TextBox txtBxPswd;
        private Label lblLog;
        private Label lblPswd;
    }
}
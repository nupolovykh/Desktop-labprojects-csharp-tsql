namespace WinFormsApp1
{
    partial class MyUserControl
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
            btnShowPsw = new Button();
            tbPsw = new TextBox();
            lblPsw = new Label();
            SuspendLayout();
            // 
            // btnShowPsw
            // 
            btnShowPsw.Anchor = AnchorStyles.Right;
            btnShowPsw.BackColor = SystemColors.Control;
            btnShowPsw.Location = new Point(188, 44);
            btnShowPsw.Name = "btnShowPsw";
            btnShowPsw.Size = new Size(24, 23);
            btnShowPsw.TabIndex = 0;
            btnShowPsw.Text = "👁";
            btnShowPsw.UseVisualStyleBackColor = false;
            btnShowPsw.Click += btnShowPsw_Click;
            // 
            // tbPsw
            // 
            tbPsw.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tbPsw.Location = new Point(34, 44);
            tbPsw.Name = "tbPsw";
            tbPsw.Size = new Size(148, 23);
            tbPsw.TabIndex = 1;
            // 
            // lblPsw
            // 
            lblPsw.AutoSize = true;
            lblPsw.Location = new Point(81, 26);
            lblPsw.Name = "lblPsw";
            lblPsw.Size = new Size(57, 15);
            lblPsw.TabIndex = 2;
            lblPsw.Text = "Password";
            // 
            // MyUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblPsw);
            Controls.Add(tbPsw);
            Controls.Add(btnShowPsw);
            MaximumSize = new Size(0, 68);
            MinimumSize = new Size(238, 98);
            Name = "MyUserControl";
            Size = new Size(238, 98);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnShowPsw;
        private TextBox tbPsw;
        private Label lblPsw;
    }
}

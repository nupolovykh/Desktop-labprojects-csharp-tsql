namespace Lab3.customControls
{
    partial class MaterialView
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
            tb_Name = new TextBox();
            tb_Id = new TextBox();
            lbl_Name = new Label();
            lbl_Id = new Label();
            btn_Link = new Button();
            SuspendLayout();
            // 
            // tb_Name
            // 
            tb_Name.Location = new Point(102, 36);
            tb_Name.Name = "tb_Name";
            tb_Name.Size = new Size(93, 23);
            tb_Name.TabIndex = 17;
            // 
            // tb_Id
            // 
            tb_Id.Location = new Point(18, 36);
            tb_Id.Name = "tb_Id";
            tb_Id.Size = new Size(53, 23);
            tb_Id.TabIndex = 16;
            // 
            // lbl_Name
            // 
            lbl_Name.AutoSize = true;
            lbl_Name.Location = new Point(126, 13);
            lbl_Name.Name = "lbl_Name";
            lbl_Name.Size = new Size(39, 15);
            lbl_Name.TabIndex = 15;
            lbl_Name.Text = "Name";
            // 
            // lbl_Id
            // 
            lbl_Id.AutoSize = true;
            lbl_Id.Location = new Point(36, 13);
            lbl_Id.Name = "lbl_Id";
            lbl_Id.Size = new Size(17, 15);
            lbl_Id.TabIndex = 14;
            lbl_Id.Text = "Id";
            // 
            // btn_Link
            // 
            btn_Link.Location = new Point(261, 20);
            btn_Link.Name = "btn_Link";
            btn_Link.Size = new Size(152, 39);
            btn_Link.TabIndex = 18;
            btn_Link.Text = "Link";
            btn_Link.UseVisualStyleBackColor = true;
            btn_Link.Click += btn_Link_Click;
            // 
            // MaterialView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_Link);
            Controls.Add(tb_Name);
            Controls.Add(tb_Id);
            Controls.Add(lbl_Name);
            Controls.Add(lbl_Id);
            Name = "MaterialView";
            Size = new Size(500, 71);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_Name;
        private TextBox tb_Id;
        private Label lbl_Name;
        private Label lbl_Id;
        private Button btn_Link;
    }
}

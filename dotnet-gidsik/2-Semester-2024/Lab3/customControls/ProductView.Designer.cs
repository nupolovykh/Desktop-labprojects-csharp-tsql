namespace Lab3.customControls
{
    partial class ProductView
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
            lbl_Material = new Label();
            tb_Price = new TextBox();
            tb_Name = new TextBox();
            tb_Id = new TextBox();
            lbl_Price = new Label();
            lbl_Name = new Label();
            lbl_Id = new Label();
            cmbox_Material = new ComboBox();
            SuspendLayout();
            // 
            // lbl_Material
            // 
            lbl_Material.AutoSize = true;
            lbl_Material.Location = new Point(390, 12);
            lbl_Material.Name = "lbl_Material";
            lbl_Material.Size = new Size(50, 15);
            lbl_Material.TabIndex = 15;
            lbl_Material.Text = "Material";
            // 
            // tb_Price
            // 
            tb_Price.Location = new Point(225, 35);
            tb_Price.Name = "tb_Price";
            tb_Price.Size = new Size(98, 23);
            tb_Price.TabIndex = 14;
            // 
            // tb_Name
            // 
            tb_Name.Location = new Point(108, 35);
            tb_Name.Name = "tb_Name";
            tb_Name.Size = new Size(93, 23);
            tb_Name.TabIndex = 13;
            // 
            // tb_Id
            // 
            tb_Id.Location = new Point(24, 35);
            tb_Id.Name = "tb_Id";
            tb_Id.Size = new Size(53, 23);
            tb_Id.TabIndex = 12;
            // 
            // lbl_Price
            // 
            lbl_Price.AutoSize = true;
            lbl_Price.Location = new Point(254, 12);
            lbl_Price.Name = "lbl_Price";
            lbl_Price.Size = new Size(33, 15);
            lbl_Price.TabIndex = 11;
            lbl_Price.Text = "Price";
            // 
            // lbl_Name
            // 
            lbl_Name.AutoSize = true;
            lbl_Name.Location = new Point(132, 12);
            lbl_Name.Name = "lbl_Name";
            lbl_Name.Size = new Size(39, 15);
            lbl_Name.TabIndex = 10;
            lbl_Name.Text = "Name";
            // 
            // lbl_Id
            // 
            lbl_Id.AutoSize = true;
            lbl_Id.Location = new Point(42, 12);
            lbl_Id.Name = "lbl_Id";
            lbl_Id.Size = new Size(17, 15);
            lbl_Id.TabIndex = 9;
            lbl_Id.Text = "Id";
            // 
            // cmbox_Material
            // 
            cmbox_Material.FormattingEnabled = true;
            cmbox_Material.Location = new Point(355, 35);
            cmbox_Material.Name = "cmbox_Material";
            cmbox_Material.Size = new Size(121, 23);
            cmbox_Material.TabIndex = 8;
            // 
            // ProductView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lbl_Material);
            Controls.Add(tb_Price);
            Controls.Add(tb_Name);
            Controls.Add(tb_Id);
            Controls.Add(lbl_Price);
            Controls.Add(lbl_Name);
            Controls.Add(lbl_Id);
            Controls.Add(cmbox_Material);
            Name = "ProductView";
            Size = new Size(500, 70);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Material;
        private TextBox tb_Price;
        private TextBox tb_Name;
        private TextBox tb_Id;
        private Label lbl_Price;
        private Label lbl_Name;
        private Label lbl_Id;
        private ComboBox cmbox_Material;
    }
}

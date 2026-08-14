namespace Lab3
{
    partial class Main
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
            btn_prdt = new Button();
            btn_mtrl = new Button();
            btn_somethg1 = new Button();
            btn_somethng2 = new Button();
            SuspendLayout();
            // 
            // btn_prdt
            // 
            btn_prdt.Location = new Point(46, 25);
            btn_prdt.Name = "btn_prdt";
            btn_prdt.Size = new Size(68, 58);
            btn_prdt.TabIndex = 0;
            btn_prdt.Text = "product dataGrid";
            btn_prdt.UseVisualStyleBackColor = true;
            btn_prdt.Click += btn_prdt_Click;
            // 
            // btn_mtrl
            // 
            btn_mtrl.Location = new Point(120, 25);
            btn_mtrl.Name = "btn_mtrl";
            btn_mtrl.Size = new Size(68, 58);
            btn_mtrl.TabIndex = 1;
            btn_mtrl.Text = "materials dataGrid";
            btn_mtrl.UseVisualStyleBackColor = true;
            btn_mtrl.Click += btn_mtrl_Click;
            // 
            // btn_somethg1
            // 
            btn_somethg1.Location = new Point(46, 89);
            btn_somethg1.Name = "btn_somethg1";
            btn_somethg1.Size = new Size(68, 58);
            btn_somethg1.TabIndex = 2;
            btn_somethg1.Text = "products custom";
            btn_somethg1.UseVisualStyleBackColor = true;
            btn_somethg1.Click += btn_somethg1_Click;
            // 
            // btn_somethng2
            // 
            btn_somethng2.Location = new Point(120, 89);
            btn_somethng2.Name = "btn_somethng2";
            btn_somethng2.Size = new Size(68, 58);
            btn_somethng2.TabIndex = 3;
            btn_somethng2.Text = "materials custom";
            btn_somethng2.UseVisualStyleBackColor = true;
            btn_somethng2.Click += btn_somethng2_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(241, 202);
            Controls.Add(btn_somethng2);
            Controls.Add(btn_somethg1);
            Controls.Add(btn_mtrl);
            Controls.Add(btn_prdt);
            Name = "Main";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_prdt;
        private Button btn_mtrl;
        private Button btn_somethg1;
        private Button btn_somethng2;
    }
}

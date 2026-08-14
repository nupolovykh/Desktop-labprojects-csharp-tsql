namespace Lab2
{
    partial class MainForm
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
            entc = new Button();
            rgst = new Button();
            SuspendLayout();
            // 
            // entc
            // 
            entc.Location = new Point(59, 47);
            entc.Name = "entc";
            entc.Size = new Size(150, 63);
            entc.TabIndex = 0;
            entc.Text = "Вход";
            entc.UseVisualStyleBackColor = true;
            entc.Click += entc_Click;
            // 
            // rgst
            // 
            rgst.Location = new Point(237, 47);
            rgst.Name = "rgst";
            rgst.Size = new Size(150, 63);
            rgst.TabIndex = 1;
            rgst.Text = "Регистрация";
            rgst.UseVisualStyleBackColor = true;
            rgst.Click += rgst_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 167);
            Controls.Add(rgst);
            Controls.Add(entc);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
        }

        #endregion

        private Button entc;
        private Button rgst;
    }
}
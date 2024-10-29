namespace Lab3.forms
{
    partial class CustomProductForm
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
            btn_save = new Button();
            flowLayoutPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // btn_save
            // 
            btn_save.Location = new Point(12, 12);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(68, 58);
            btn_save.TabIndex = 2;
            btn_save.Text = "save";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // flowLayoutPanel
            // 
            flowLayoutPanel.AutoScroll = true;
            flowLayoutPanel.Location = new Point(86, 12);
            flowLayoutPanel.Name = "flowLayoutPanel";
            flowLayoutPanel.Size = new Size(702, 426);
            flowLayoutPanel.TabIndex = 4;
            // 
            // CustomProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(flowLayoutPanel);
            Controls.Add(btn_save);
            Name = "CustomProductForm";
            Text = "CustomProductForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_save;
        private FlowLayoutPanel flowLayoutPanel;
    }
}
namespace WinFormsApp1
{
    partial class MyForm
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
            components = new System.ComponentModel.Container();
            myUserControl1 = new MyUserControl();
            MyComponent = new MyComponent(components);
            lblMyComponentText = new Label();
            btnOk = new Button();
            btnShowDialogForm = new Button();
            SuspendLayout();
            // 
            // myUserControl1
            // 
            myUserControl1.label = "Password";
            myUserControl1.Location = new Point(12, 24);
            myUserControl1.MaximumSize = new Size(0, 68);
            myUserControl1.MinimumSize = new Size(238, 98);
            myUserControl1.Name = "myUserControl1";
            myUserControl1.password = "";
            myUserControl1.Size = new Size(238, 98);
            myUserControl1.TabIndex = 0;
            // 
            // MyComponent
            // 
            MyComponent.Tick += MyComponent_Tick;
            // 
            // lblMyComponentText
            // 
            lblMyComponentText.AutoSize = true;
            lblMyComponentText.Location = new Point(12, 212);
            lblMyComponentText.Name = "lblMyComponentText";
            lblMyComponentText.Size = new Size(38, 15);
            lblMyComponentText.TabIndex = 1;
            lblMyComponentText.Text = "label1";
            // 
            // btnOk
            // 
            btnOk.Location = new Point(68, 108);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(139, 81);
            btnOk.TabIndex = 2;
            btnOk.Text = "ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // btnShowDialogForm
            // 
            btnShowDialogForm.Location = new Point(213, 108);
            btnShowDialogForm.Name = "btnShowDialogForm";
            btnShowDialogForm.Size = new Size(139, 81);
            btnShowDialogForm.TabIndex = 3;
            btnShowDialogForm.Text = "Show";
            btnShowDialogForm.UseVisualStyleBackColor = true;
            btnShowDialogForm.Click += btnShowDialogForm_Click;
            // 
            // MyForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 236);
            Controls.Add(btnShowDialogForm);
            Controls.Add(btnOk);
            Controls.Add(lblMyComponentText);
            Controls.Add(myUserControl1);
            Name = "MyForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MyUserControl myUserControl1;
        private MyComponent MyComponent;
        private Label lblMyComponentText;
        private Button btnOk;
        private Button btnShowDialogForm;
    }
}
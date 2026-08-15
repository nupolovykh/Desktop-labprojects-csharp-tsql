namespace WinFormsApp1
{
    partial class PersonRecordEditDialog
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
            txtBoxEditId = new TextBox();
            txtBoxEditName = new TextBox();
            txtBoxEditLN = new TextBox();
            txtBoxEditSN = new TextBox();
            txtBoxEditAge = new TextBox();
            lblEditId = new Label();
            lblEditFN = new Label();
            lblEditLN = new Label();
            lblEditSN = new Label();
            lblEditAge = new Label();
            btnSaving = new Button();
            SuspendLayout();
            // 
            // txtBoxEditId
            // 
            txtBoxEditId.Location = new Point(75, 35);
            txtBoxEditId.Name = "txtBoxEditId";
            txtBoxEditId.Size = new Size(129, 23);
            txtBoxEditId.TabIndex = 0;
            // 
            // txtBoxEditName
            // 
            txtBoxEditName.Location = new Point(75, 72);
            txtBoxEditName.Name = "txtBoxEditName";
            txtBoxEditName.Size = new Size(129, 23);
            txtBoxEditName.TabIndex = 1;
            // 
            // txtBoxEditLN
            // 
            txtBoxEditLN.Location = new Point(75, 112);
            txtBoxEditLN.Name = "txtBoxEditLN";
            txtBoxEditLN.Size = new Size(129, 23);
            txtBoxEditLN.TabIndex = 2;
            // 
            // txtBoxEditSN
            // 
            txtBoxEditSN.Location = new Point(75, 151);
            txtBoxEditSN.Name = "txtBoxEditSN";
            txtBoxEditSN.Size = new Size(129, 23);
            txtBoxEditSN.TabIndex = 3;
            // 
            // txtBoxEditAge
            // 
            txtBoxEditAge.Location = new Point(75, 188);
            txtBoxEditAge.Name = "txtBoxEditAge";
            txtBoxEditAge.Size = new Size(129, 23);
            txtBoxEditAge.TabIndex = 4;
            // 
            // lblEditId
            // 
            lblEditId.AutoSize = true;
            lblEditId.Location = new Point(9, 38);
            lblEditId.Name = "lblEditId";
            lblEditId.Size = new Size(17, 15);
            lblEditId.TabIndex = 5;
            lblEditId.Text = "Id";
            // 
            // lblEditFN
            // 
            lblEditFN.AutoSize = true;
            lblEditFN.Location = new Point(9, 75);
            lblEditFN.Name = "lblEditFN";
            lblEditFN.Size = new Size(39, 15);
            lblEditFN.TabIndex = 6;
            lblEditFN.Text = "Name";
            // 
            // lblEditLN
            // 
            lblEditLN.AutoSize = true;
            lblEditLN.Location = new Point(9, 112);
            lblEditLN.Name = "lblEditLN";
            lblEditLN.Size = new Size(60, 15);
            lblEditLN.TabIndex = 7;
            lblEditLN.Text = "LastName";
            // 
            // lblEditSN
            // 
            lblEditSN.AutoSize = true;
            lblEditSN.Location = new Point(9, 154);
            lblEditSN.Name = "lblEditSN";
            lblEditSN.Size = new Size(54, 15);
            lblEditSN.TabIndex = 8;
            lblEditSN.Text = "Surname";
            // 
            // lblEditAge
            // 
            lblEditAge.AutoSize = true;
            lblEditAge.Location = new Point(9, 191);
            lblEditAge.Name = "lblEditAge";
            lblEditAge.Size = new Size(28, 15);
            lblEditAge.TabIndex = 9;
            lblEditAge.Text = "Age";
            // 
            // btnSaving
            // 
            btnSaving.Location = new Point(108, 244);
            btnSaving.Name = "btnSaving";
            btnSaving.Size = new Size(125, 33);
            btnSaving.TabIndex = 10;
            btnSaving.Text = "Save Changes";
            btnSaving.UseVisualStyleBackColor = true;
            btnSaving.Click += btnSaving_Click;
            // 
            // PersonRecordEditDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(344, 298);
            Controls.Add(btnSaving);
            Controls.Add(lblEditAge);
            Controls.Add(lblEditSN);
            Controls.Add(lblEditLN);
            Controls.Add(lblEditFN);
            Controls.Add(lblEditId);
            Controls.Add(txtBoxEditAge);
            Controls.Add(txtBoxEditSN);
            Controls.Add(txtBoxEditLN);
            Controls.Add(txtBoxEditName);
            Controls.Add(txtBoxEditId);
            Name = "PersonRecordEditDialog";
            Text = "PersonRecordEditDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtBoxEditId;
        private TextBox txtBoxEditName;
        private TextBox txtBoxEditLN;
        private TextBox txtBoxEditSN;
        private TextBox txtBoxEditAge;
        private Label lblEditId;
        private Label lblEditFN;
        private Label lblEditLN;
        private Label lblEditSN;
        private Label lblEditAge;
        private Button btnSaving;
    }
}
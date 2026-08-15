namespace WinFormsApp1
{
    partial class PersonRecordUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblId = new Label();
            lblN = new Label();
            lblLN = new Label();
            lblSN = new Label();
            lblAge = new Label();
            txtBoxId = new TextBox();
            txtBoxName = new TextBox();
            txtBoxLN = new TextBox();
            txtBoxSN = new TextBox();
            txtBoxAge = new TextBox();
            btnEdit = new Button();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(32, 13);
            lblId.Name = "lblId";
            lblId.Size = new Size(17, 15);
            lblId.TabIndex = 0;
            lblId.Text = "Id";
            // 
            // lblN
            // 
            lblN.AutoSize = true;
            lblN.Location = new Point(111, 13);
            lblN.Name = "lblN";
            lblN.Size = new Size(39, 15);
            lblN.TabIndex = 1;
            lblN.Text = "Name";
            // 
            // lblLN
            // 
            lblLN.AutoSize = true;
            lblLN.Location = new Point(247, 13);
            lblLN.Name = "lblLN";
            lblLN.Size = new Size(63, 15);
            lblLN.TabIndex = 2;
            lblLN.Text = "Last Name";
            // 
            // lblSN
            // 
            lblSN.AutoSize = true;
            lblSN.Location = new Point(389, 13);
            lblSN.Name = "lblSN";
            lblSN.Size = new Size(54, 15);
            lblSN.TabIndex = 3;
            lblSN.Text = "Surname";
            // 
            // lblAge
            // 
            lblAge.AutoSize = true;
            lblAge.Location = new Point(515, 13);
            lblAge.Name = "lblAge";
            lblAge.Size = new Size(28, 15);
            lblAge.TabIndex = 4;
            lblAge.Text = "Age";
            // 
            // txtBoxId
            // 
            txtBoxId.Location = new Point(21, 35);
            txtBoxId.Name = "txtBoxId";
            txtBoxId.Size = new Size(28, 23);
            txtBoxId.TabIndex = 5;
            // 
            // txtBoxName
            // 
            txtBoxName.Location = new Point(55, 35);
            txtBoxName.Name = "txtBoxName";
            txtBoxName.Size = new Size(143, 23);
            txtBoxName.TabIndex = 6;
            // 
            // txtBoxLN
            // 
            txtBoxLN.Location = new Point(204, 35);
            txtBoxLN.Name = "txtBoxLN";
            txtBoxLN.Size = new Size(133, 23);
            txtBoxLN.TabIndex = 7;
            // 
            // txtBoxSN
            // 
            txtBoxSN.Location = new Point(343, 35);
            txtBoxSN.Name = "txtBoxSN";
            txtBoxSN.Size = new Size(137, 23);
            txtBoxSN.TabIndex = 8;
            // 
            // txtBoxAge
            // 
            txtBoxAge.Location = new Point(506, 35);
            txtBoxAge.Name = "txtBoxAge";
            txtBoxAge.Size = new Size(48, 23);
            txtBoxAge.TabIndex = 9;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(598, 13);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 10;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(598, 42);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // PersonRecordUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(txtBoxAge);
            Controls.Add(txtBoxSN);
            Controls.Add(txtBoxLN);
            Controls.Add(txtBoxName);
            Controls.Add(txtBoxId);
            Controls.Add(lblAge);
            Controls.Add(lblSN);
            Controls.Add(lblLN);
            Controls.Add(lblN);
            Controls.Add(lblId);
            Name = "PersonRecordUserControl";
            Size = new Size(700, 77);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblId;
        private Label lblN;
        private Label lblLN;
        private Label lblSN;
        private Label lblAge;
        private TextBox txtBoxId;
        private TextBox txtBoxName;
        private TextBox txtBoxLN;
        private TextBox txtBoxSN;
        private TextBox txtBoxAge;
        private Button btnEdit;
        private Button btnDelete;
    }
}

namespace WinFormsApp1
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
            dataStorage = new FlowLayoutPanel();
            btnAdd = new Button();
            lblSumOfAge = new Label();
            lblAmountOfEntries = new Label();
            SumOfAges = new Label();
            AmountOfEntries = new Label();
            SuspendLayout();
            // 
            // dataStorage
            // 
            dataStorage.BackColor = SystemColors.ActiveBorder;
            dataStorage.Location = new Point(29, 76);
            dataStorage.Name = "dataStorage";
            dataStorage.Size = new Size(739, 362);
            dataStorage.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(29, 24);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(136, 32);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblSumOfAge
            // 
            lblSumOfAge.AutoSize = true;
            lblSumOfAge.Location = new Point(327, 16);
            lblSumOfAge.Name = "lblSumOfAge";
            lblSumOfAge.Size = new Size(100, 15);
            lblSumOfAge.TabIndex = 2;
            lblSumOfAge.Text = "Sum of users age:";
            // 
            // lblAmountOfEntries
            // 
            lblAmountOfEntries.AutoSize = true;
            lblAmountOfEntries.Location = new Point(327, 41);
            lblAmountOfEntries.Name = "lblAmountOfEntries";
            lblAmountOfEntries.Size = new Size(106, 15);
            lblAmountOfEntries.TabIndex = 3;
            lblAmountOfEntries.Text = "Amount of Entries:";
            // 
            // SumOfAges
            // 
            SumOfAges.AutoSize = true;
            SumOfAges.Location = new Point(439, 16);
            SumOfAges.Name = "SumOfAges";
            SumOfAges.Size = new Size(13, 15);
            SumOfAges.TabIndex = 4;
            SumOfAges.Text = "0";
            // 
            // AmountOfEntries
            // 
            AmountOfEntries.AutoSize = true;
            AmountOfEntries.Location = new Point(439, 41);
            AmountOfEntries.Name = "AmountOfEntries";
            AmountOfEntries.Size = new Size(13, 15);
            AmountOfEntries.TabIndex = 5;
            AmountOfEntries.Text = "0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AmountOfEntries);
            Controls.Add(SumOfAges);
            Controls.Add(lblAmountOfEntries);
            Controls.Add(lblSumOfAge);
            Controls.Add(btnAdd);
            Controls.Add(dataStorage);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel dataStorage;
        private Button btnAdd;
        private Label lblSumOfAge;
        private Label lblAmountOfEntries;
        private Label SumOfAges;
        private Label AmountOfEntries;
    }
}
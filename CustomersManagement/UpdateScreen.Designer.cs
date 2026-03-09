namespace CustomersManagement
{
    partial class UpdateScreen
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
            saveButton = new Button();
            phoneInput = new TextBox();
            emailInput = new TextBox();
            lastNameInput = new TextBox();
            firstNameInput = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // saveButton
            // 
            saveButton.Location = new Point(319, 392);
            saveButton.Margin = new Padding(2, 2, 2, 2);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(111, 35);
            saveButton.TabIndex = 19;
            saveButton.Text = "SAVE";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // phoneInput
            // 
            phoneInput.Location = new Point(173, 284);
            phoneInput.Margin = new Padding(2, 2, 2, 2);
            phoneInput.Name = "phoneInput";
            phoneInput.Size = new Size(259, 31);
            phoneInput.TabIndex = 18;
            // 
            // emailInput
            // 
            emailInput.Location = new Point(173, 237);
            emailInput.Margin = new Padding(2, 2, 2, 2);
            emailInput.Name = "emailInput";
            emailInput.Size = new Size(259, 31);
            emailInput.TabIndex = 17;
            // 
            // lastNameInput
            // 
            lastNameInput.Location = new Point(173, 187);
            lastNameInput.Margin = new Padding(2, 2, 2, 2);
            lastNameInput.Name = "lastNameInput";
            lastNameInput.Size = new Size(259, 31);
            lastNameInput.TabIndex = 16;
            // 
            // firstNameInput
            // 
            firstNameInput.Location = new Point(173, 135);
            firstNameInput.Margin = new Padding(2, 2, 2, 2);
            firstNameInput.Name = "firstNameInput";
            firstNameInput.Size = new Size(259, 31);
            firstNameInput.TabIndex = 15;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(68, 284);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(62, 25);
            label5.TabIndex = 14;
            label5.Text = "Phone";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(68, 237);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(54, 25);
            label4.TabIndex = 13;
            label4.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(68, 187);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(90, 25);
            label3.TabIndex = 12;
            label3.Text = "LastName";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(68, 138);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(92, 25);
            label2.TabIndex = 11;
            label2.Text = "FirstName";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.1F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(58, 53);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(258, 40);
            label1.TabIndex = 10;
            label1.Text = "Update Customer";
            // 
            // UpdateScreen
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(515, 482);
            Controls.Add(saveButton);
            Controls.Add(phoneInput);
            Controls.Add(emailInput);
            Controls.Add(lastNameInput);
            Controls.Add(firstNameInput);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "UpdateScreen";
            Text = "UpdateScreen";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button saveButton;
        private TextBox phoneInput;
        private TextBox emailInput;
        private TextBox lastNameInput;
        private TextBox firstNameInput;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}
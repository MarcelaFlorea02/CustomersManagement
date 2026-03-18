namespace CustomersManagement
{
    partial class DashboardScreen
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
            label1 = new Label();
            addButton = new Button();
            deleteButton = new Button();
            updateButton = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20.1F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 192, 0);
            label1.Location = new Point(56, 30);
            label1.Name = "label1";
            label1.Size = new Size(378, 89);
            label1.TabIndex = 0;
            label1.Text = "Dashboard";
            // 
            // addButton
            // 
            addButton.BackColor = Color.FromArgb(192, 255, 192);
            addButton.Location = new Point(139, 331);
            addButton.Name = "addButton";
            addButton.Size = new Size(189, 57);
            addButton.TabIndex = 1;
            addButton.Text = "ADD";
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += addButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.BackColor = Color.Firebrick;
            deleteButton.Location = new Point(139, 522);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(189, 57);
            deleteButton.TabIndex = 2;
            deleteButton.Text = "DELETE";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += deleteButton_Click;
            // 
            // updateButton
            // 
            updateButton.BackColor = Color.FromArgb(255, 255, 128);
            updateButton.Location = new Point(139, 717);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(189, 57);
            updateButton.TabIndex = 3;
            updateButton.Text = "UPDATE";
            updateButton.UseVisualStyleBackColor = false;
            updateButton.Click += updateButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(534, 194);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 102;
            dataGridView1.Size = new Size(1117, 654);
            dataGridView1.TabIndex = 4;
            // 
            // DashboardScreen
            // 
            AutoScaleDimensions = new SizeF(17F, 41F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1748, 982);
            Controls.Add(dataGridView1);
            Controls.Add(updateButton);
            Controls.Add(deleteButton);
            Controls.Add(addButton);
            Controls.Add(label1);
            Name = "DashboardScreen";
            Text = "DashboardScreen";
            Load += DashboardScreen_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button addButton;
        private Button deleteButton;
        private Button updateButton;
        private DataGridView dataGridView1;
    }
}
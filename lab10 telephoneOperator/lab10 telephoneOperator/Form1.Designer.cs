namespace lab10_telephoneOperator
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DeleteEntry = new System.Windows.Forms.Button();
            this.ChangeEntry = new System.Windows.Forms.Button();
            this.addEntry = new System.Windows.Forms.Button();
            this.communicationComboBox = new System.Windows.Forms.ComboBox();
            this.CommunicationTextBox = new System.Windows.Forms.TextBox();
            this.communicationLabel = new System.Windows.Forms.Label();
            this.communicationWayLabel = new System.Windows.Forms.Label();
            this.lastnameTextBox = new System.Windows.Forms.TextBox();
            this.lastnameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.clientData = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.generateReport = new System.Windows.Forms.Button();
            this.updateTable = new System.Windows.Forms.Button();
            this.reportInformation = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientData)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1617, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DeleteEntry);
            this.tabPage2.Controls.Add(this.ChangeEntry);
            this.tabPage2.Controls.Add(this.addEntry);
            this.tabPage2.Controls.Add(this.communicationComboBox);
            this.tabPage2.Controls.Add(this.CommunicationTextBox);
            this.tabPage2.Controls.Add(this.communicationLabel);
            this.tabPage2.Controls.Add(this.communicationWayLabel);
            this.tabPage2.Controls.Add(this.lastnameTextBox);
            this.tabPage2.Controls.Add(this.lastnameLabel);
            this.tabPage2.Controls.Add(this.nameTextBox);
            this.tabPage2.Controls.Add(this.nameLabel);
            this.tabPage2.Controls.Add(this.surnameTextBox);
            this.tabPage2.Controls.Add(this.surnameLabel);
            this.tabPage2.Controls.Add(this.clientData);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1609, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "clientIfo";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // DeleteEntry
            // 
            this.DeleteEntry.Location = new System.Drawing.Point(173, 372);
            this.DeleteEntry.Name = "DeleteEntry";
            this.DeleteEntry.Size = new System.Drawing.Size(67, 44);
            this.DeleteEntry.TabIndex = 16;
            this.DeleteEntry.Text = "Удалить";
            this.DeleteEntry.UseVisualStyleBackColor = true;
            this.DeleteEntry.Click += new System.EventHandler(this.deleteEntry_Click);
            // 
            // ChangeEntry
            // 
            this.ChangeEntry.Location = new System.Drawing.Point(91, 372);
            this.ChangeEntry.Name = "ChangeEntry";
            this.ChangeEntry.Size = new System.Drawing.Size(67, 44);
            this.ChangeEntry.TabIndex = 15;
            this.ChangeEntry.Text = "Изменить";
            this.ChangeEntry.UseVisualStyleBackColor = true;
            this.ChangeEntry.Click += new System.EventHandler(this.button2_Click);
            // 
            // addEntry
            // 
            this.addEntry.Location = new System.Drawing.Point(6, 372);
            this.addEntry.Name = "addEntry";
            this.addEntry.Size = new System.Drawing.Size(67, 44);
            this.addEntry.TabIndex = 14;
            this.addEntry.Text = "Добавить";
            this.addEntry.UseVisualStyleBackColor = true;
            this.addEntry.Click += new System.EventHandler(this.addEntry_Click);
            // 
            // communicationComboBox
            // 
            this.communicationComboBox.FormattingEnabled = true;
            this.communicationComboBox.Location = new System.Drawing.Point(11, 172);
            this.communicationComboBox.Name = "communicationComboBox";
            this.communicationComboBox.Size = new System.Drawing.Size(229, 21);
            this.communicationComboBox.TabIndex = 13;
            this.communicationComboBox.SelectedIndexChanged += new System.EventHandler(this.communicationComboBox_SelectedIndexChanged);
            // 
            // CommunicationTextBox
            // 
            this.CommunicationTextBox.Location = new System.Drawing.Point(11, 222);
            this.CommunicationTextBox.Name = "CommunicationTextBox";
            this.CommunicationTextBox.Size = new System.Drawing.Size(229, 20);
            this.CommunicationTextBox.TabIndex = 12;
            // 
            // communicationLabel
            // 
            this.communicationLabel.AutoSize = true;
            this.communicationLabel.Location = new System.Drawing.Point(8, 206);
            this.communicationLabel.Name = "communicationLabel";
            this.communicationLabel.Size = new System.Drawing.Size(93, 13);
            this.communicationLabel.TabIndex = 11;
            this.communicationLabel.Text = "Номер телефона";
            // 
            // communicationWayLabel
            // 
            this.communicationWayLabel.AutoSize = true;
            this.communicationWayLabel.Location = new System.Drawing.Point(8, 156);
            this.communicationWayLabel.Name = "communicationWayLabel";
            this.communicationWayLabel.Size = new System.Drawing.Size(122, 13);
            this.communicationWayLabel.TabIndex = 9;
            this.communicationWayLabel.Text = "Способ коммуникации";
            // 
            // lastnameTextBox
            // 
            this.lastnameTextBox.Location = new System.Drawing.Point(11, 122);
            this.lastnameTextBox.Name = "lastnameTextBox";
            this.lastnameTextBox.Size = new System.Drawing.Size(229, 20);
            this.lastnameTextBox.TabIndex = 6;
            // 
            // lastnameLabel
            // 
            this.lastnameLabel.AutoSize = true;
            this.lastnameLabel.Location = new System.Drawing.Point(8, 106);
            this.lastnameLabel.Name = "lastnameLabel";
            this.lastnameLabel.Size = new System.Drawing.Size(54, 13);
            this.lastnameLabel.TabIndex = 5;
            this.lastnameLabel.Text = "Отчество";
            this.lastnameLabel.Click += new System.EventHandler(this.lastnameLabel_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(11, 71);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(229, 20);
            this.nameTextBox.TabIndex = 4;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(8, 55);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(29, 13);
            this.nameLabel.TabIndex = 3;
            this.nameLabel.Text = "Имя";
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Location = new System.Drawing.Point(11, 22);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(229, 20);
            this.surnameTextBox.TabIndex = 2;
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Location = new System.Drawing.Point(8, 6);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(56, 13);
            this.surnameLabel.TabIndex = 1;
            this.surnameLabel.Text = "Фамилия";
            // 
            // clientData
            // 
            this.clientData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientData.Location = new System.Drawing.Point(246, 6);
            this.clientData.Name = "clientData";
            this.clientData.Size = new System.Drawing.Size(1355, 412);
            this.clientData.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.generateReport);
            this.tabPage1.Controls.Add(this.updateTable);
            this.tabPage1.Controls.Add(this.reportInformation);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1609, 424);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Report";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // generateReport
            // 
            this.generateReport.Location = new System.Drawing.Point(8, 216);
            this.generateReport.Name = "generateReport";
            this.generateReport.Size = new System.Drawing.Size(270, 38);
            this.generateReport.TabIndex = 2;
            this.generateReport.Text = "Создать отчет";
            this.generateReport.UseVisualStyleBackColor = true;
            this.generateReport.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // updateTable
            // 
            this.updateTable.Location = new System.Drawing.Point(8, 121);
            this.updateTable.Name = "updateTable";
            this.updateTable.Size = new System.Drawing.Size(270, 38);
            this.updateTable.TabIndex = 1;
            this.updateTable.Text = "Обновить данные в таблице";
            this.updateTable.UseVisualStyleBackColor = true;
            this.updateTable.Click += new System.EventHandler(this.updateTable_Click);
            // 
            // reportInformation
            // 
            this.reportInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportInformation.Location = new System.Drawing.Point(284, 3);
            this.reportInformation.Name = "reportInformation";
            this.reportInformation.Size = new System.Drawing.Size(1317, 413);
            this.reportInformation.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(979, 424);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1617, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientData)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reportInformation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView clientData;
        private System.Windows.Forms.ComboBox communicationComboBox;
        private System.Windows.Forms.TextBox CommunicationTextBox;
        private System.Windows.Forms.Label communicationLabel;
        private System.Windows.Forms.Label communicationWayLabel;
        private System.Windows.Forms.TextBox lastnameTextBox;
        private System.Windows.Forms.Label lastnameLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.Button DeleteEntry;
        private System.Windows.Forms.Button ChangeEntry;
        private System.Windows.Forms.Button addEntry;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button generateReport;
        private System.Windows.Forms.Button updateTable;
        private System.Windows.Forms.DataGridView reportInformation;
    }
}


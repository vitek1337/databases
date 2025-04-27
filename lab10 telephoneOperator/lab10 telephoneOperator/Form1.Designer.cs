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
            this.clientInfo = new System.Windows.Forms.TabPage();
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
            this.Report = new System.Windows.Forms.TabPage();
            this.generateReport = new System.Windows.Forms.Button();
            this.updateTable = new System.Windows.Forms.Button();
            this.reportInformation = new System.Windows.Forms.DataGridView();
            this.service = new System.Windows.Forms.TabPage();
            this.contractForm = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.communicationComboBox2 = new System.Windows.Forms.ComboBox();
            this.phone2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lastnameTextBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nameTextBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.surnameTextBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.contractTable = new System.Windows.Forms.DataGridView();
            this.deletePlane = new System.Windows.Forms.Button();
            this.ChangePlane = new System.Windows.Forms.Button();
            this.addPlane = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.pricePerMonth = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.planCommentTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.planNameTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.planeGrid = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.planComboBox = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.planLong = new System.Windows.Forms.NumericUpDown();
            this.pricePerYear = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.clientInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientData)).BeginInit();
            this.Report.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportInformation)).BeginInit();
            this.service.SuspendLayout();
            this.contractForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contractTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planeGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planLong)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.clientInfo);
            this.tabControl1.Controls.Add(this.service);
            this.tabControl1.Controls.Add(this.contractForm);
            this.tabControl1.Controls.Add(this.Report);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1617, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // clientInfo
            // 
            this.clientInfo.Controls.Add(this.DeleteEntry);
            this.clientInfo.Controls.Add(this.ChangeEntry);
            this.clientInfo.Controls.Add(this.addEntry);
            this.clientInfo.Controls.Add(this.communicationComboBox);
            this.clientInfo.Controls.Add(this.CommunicationTextBox);
            this.clientInfo.Controls.Add(this.communicationLabel);
            this.clientInfo.Controls.Add(this.communicationWayLabel);
            this.clientInfo.Controls.Add(this.lastnameTextBox);
            this.clientInfo.Controls.Add(this.lastnameLabel);
            this.clientInfo.Controls.Add(this.nameTextBox);
            this.clientInfo.Controls.Add(this.nameLabel);
            this.clientInfo.Controls.Add(this.surnameTextBox);
            this.clientInfo.Controls.Add(this.surnameLabel);
            this.clientInfo.Controls.Add(this.clientData);
            this.clientInfo.Location = new System.Drawing.Point(4, 22);
            this.clientInfo.Name = "clientInfo";
            this.clientInfo.Padding = new System.Windows.Forms.Padding(3);
            this.clientInfo.Size = new System.Drawing.Size(1609, 424);
            this.clientInfo.TabIndex = 1;
            this.clientInfo.Text = "clientIfo";
            this.clientInfo.UseVisualStyleBackColor = true;
            this.clientInfo.Click += new System.EventHandler(this.tabPage2_Click);
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
            // Report
            // 
            this.Report.Controls.Add(this.generateReport);
            this.Report.Controls.Add(this.updateTable);
            this.Report.Controls.Add(this.reportInformation);
            this.Report.Location = new System.Drawing.Point(4, 22);
            this.Report.Name = "Report";
            this.Report.Size = new System.Drawing.Size(1609, 424);
            this.Report.TabIndex = 2;
            this.Report.Text = "Report";
            this.Report.UseVisualStyleBackColor = true;
            this.Report.Click += new System.EventHandler(this.tabPage1_Click);
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
            // service
            // 
            this.service.Controls.Add(this.planLong);
            this.service.Controls.Add(this.label12);
            this.service.Controls.Add(this.button7);
            this.service.Controls.Add(this.planComboBox);
            this.service.Controls.Add(this.label11);
            this.service.Controls.Add(this.button1);
            this.service.Controls.Add(this.button2);
            this.service.Controls.Add(this.button3);
            this.service.Controls.Add(this.communicationComboBox2);
            this.service.Controls.Add(this.phone2);
            this.service.Controls.Add(this.label1);
            this.service.Controls.Add(this.label2);
            this.service.Controls.Add(this.lastnameTextBox2);
            this.service.Controls.Add(this.label3);
            this.service.Controls.Add(this.nameTextBox2);
            this.service.Controls.Add(this.label4);
            this.service.Controls.Add(this.surnameTextBox2);
            this.service.Controls.Add(this.label5);
            this.service.Controls.Add(this.contractTable);
            this.service.Location = new System.Drawing.Point(4, 22);
            this.service.Name = "service";
            this.service.Size = new System.Drawing.Size(1609, 424);
            this.service.TabIndex = 3;
            this.service.Text = "tabPage3";
            this.service.UseVisualStyleBackColor = true;
            this.service.Click += new System.EventHandler(this.service_Click);
            // 
            // contractForm
            // 
            this.contractForm.Controls.Add(this.pricePerYear);
            this.contractForm.Controls.Add(this.deletePlane);
            this.contractForm.Controls.Add(this.ChangePlane);
            this.contractForm.Controls.Add(this.addPlane);
            this.contractForm.Controls.Add(this.label7);
            this.contractForm.Controls.Add(this.pricePerMonth);
            this.contractForm.Controls.Add(this.label8);
            this.contractForm.Controls.Add(this.planCommentTextBox);
            this.contractForm.Controls.Add(this.label9);
            this.contractForm.Controls.Add(this.planNameTextBox);
            this.contractForm.Controls.Add(this.label10);
            this.contractForm.Controls.Add(this.planeGrid);
            this.contractForm.Location = new System.Drawing.Point(4, 22);
            this.contractForm.Name = "contractForm";
            this.contractForm.Size = new System.Drawing.Size(1609, 424);
            this.contractForm.TabIndex = 4;
            this.contractForm.Text = "tabPage4";
            this.contractForm.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 372);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 44);
            this.button1.TabIndex = 30;
            this.button1.Text = "Удалить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(92, 372);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 44);
            this.button2.TabIndex = 29;
            this.button2.Text = "Изменить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_2);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(7, 372);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(67, 44);
            this.button3.TabIndex = 28;
            this.button3.Text = "Добавить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // communicationComboBox2
            // 
            this.communicationComboBox2.FormattingEnabled = true;
            this.communicationComboBox2.Location = new System.Drawing.Point(12, 172);
            this.communicationComboBox2.Name = "communicationComboBox2";
            this.communicationComboBox2.Size = new System.Drawing.Size(229, 21);
            this.communicationComboBox2.TabIndex = 27;
            this.communicationComboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // phone2
            // 
            this.phone2.Location = new System.Drawing.Point(12, 222);
            this.phone2.Name = "phone2";
            this.phone2.Size = new System.Drawing.Size(229, 20);
            this.phone2.TabIndex = 26;
            this.phone2.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Номер телефона";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Способ коммуникации";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lastnameTextBox2
            // 
            this.lastnameTextBox2.Location = new System.Drawing.Point(12, 122);
            this.lastnameTextBox2.Name = "lastnameTextBox2";
            this.lastnameTextBox2.Size = new System.Drawing.Size(229, 20);
            this.lastnameTextBox2.TabIndex = 23;
            this.lastnameTextBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Отчество";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // nameTextBox2
            // 
            this.nameTextBox2.Location = new System.Drawing.Point(12, 71);
            this.nameTextBox2.Name = "nameTextBox2";
            this.nameTextBox2.Size = new System.Drawing.Size(229, 20);
            this.nameTextBox2.TabIndex = 21;
            this.nameTextBox2.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Имя";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // surnameTextBox2
            // 
            this.surnameTextBox2.Location = new System.Drawing.Point(12, 22);
            this.surnameTextBox2.Name = "surnameTextBox2";
            this.surnameTextBox2.Size = new System.Drawing.Size(229, 20);
            this.surnameTextBox2.TabIndex = 19;
            this.surnameTextBox2.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Фамилия";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // contractTable
            // 
            this.contractTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contractTable.Location = new System.Drawing.Point(247, 6);
            this.contractTable.Name = "contractTable";
            this.contractTable.Size = new System.Drawing.Size(1355, 412);
            this.contractTable.TabIndex = 17;
            this.contractTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // deletePlane
            // 
            this.deletePlane.Location = new System.Drawing.Point(174, 372);
            this.deletePlane.Name = "deletePlane";
            this.deletePlane.Size = new System.Drawing.Size(67, 44);
            this.deletePlane.TabIndex = 30;
            this.deletePlane.Text = "Удалить";
            this.deletePlane.UseVisualStyleBackColor = true;
            this.deletePlane.Click += new System.EventHandler(this.button4_Click);
            // 
            // ChangePlane
            // 
            this.ChangePlane.Location = new System.Drawing.Point(92, 372);
            this.ChangePlane.Name = "ChangePlane";
            this.ChangePlane.Size = new System.Drawing.Size(67, 44);
            this.ChangePlane.TabIndex = 29;
            this.ChangePlane.Text = "Изменить";
            this.ChangePlane.UseVisualStyleBackColor = true;
            this.ChangePlane.Click += new System.EventHandler(this.button5_Click);
            // 
            // addPlane
            // 
            this.addPlane.Location = new System.Drawing.Point(7, 372);
            this.addPlane.Name = "addPlane";
            this.addPlane.Size = new System.Drawing.Size(67, 44);
            this.addPlane.TabIndex = 28;
            this.addPlane.Text = "Добавить";
            this.addPlane.UseVisualStyleBackColor = true;
            this.addPlane.Click += new System.EventHandler(this.button6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Стоимость тарифа (>12)";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // pricePerMonth
            // 
            this.pricePerMonth.Location = new System.Drawing.Point(12, 122);
            this.pricePerMonth.Name = "pricePerMonth";
            this.pricePerMonth.Size = new System.Drawing.Size(229, 20);
            this.pricePerMonth.TabIndex = 23;
            this.pricePerMonth.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(173, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Стоимость тарифа в месяц (<12)";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // planCommentTextBox
            // 
            this.planCommentTextBox.Location = new System.Drawing.Point(12, 71);
            this.planCommentTextBox.Name = "planCommentTextBox";
            this.planCommentTextBox.Size = new System.Drawing.Size(229, 20);
            this.planCommentTextBox.TabIndex = 21;
            this.planCommentTextBox.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Содержание тарифа";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // planNameTextBox
            // 
            this.planNameTextBox.Location = new System.Drawing.Point(12, 22);
            this.planNameTextBox.Name = "planNameTextBox";
            this.planNameTextBox.Size = new System.Drawing.Size(229, 20);
            this.planNameTextBox.TabIndex = 19;
            this.planNameTextBox.TextChanged += new System.EventHandler(this.textBox8_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Название тарифа";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // planeGrid
            // 
            this.planeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.planeGrid.Location = new System.Drawing.Point(247, 6);
            this.planeGrid.Name = "planeGrid";
            this.planeGrid.Size = new System.Drawing.Size(1355, 412);
            this.planeGrid.TabIndex = 17;
            this.planeGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 258);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Тариф";
            // 
            // planComboBox
            // 
            this.planComboBox.FormattingEnabled = true;
            this.planComboBox.Location = new System.Drawing.Point(12, 274);
            this.planComboBox.Name = "planComboBox";
            this.planComboBox.Size = new System.Drawing.Size(154, 21);
            this.planComboBox.TabIndex = 32;
            this.planComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(174, 274);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(67, 23);
            this.button7.TabIndex = 33;
            this.button7.Text = "info";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 309);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(135, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "Срок договора (месяцев)";
            // 
            // planLong
            // 
            this.planLong.Location = new System.Drawing.Point(12, 325);
            this.planLong.Name = "planLong";
            this.planLong.Size = new System.Drawing.Size(229, 20);
            this.planLong.TabIndex = 35;
            // 
            // pricePerYear
            // 
            this.pricePerYear.Location = new System.Drawing.Point(12, 181);
            this.pricePerYear.Name = "pricePerYear";
            this.pricePerYear.Size = new System.Drawing.Size(229, 20);
            this.pricePerYear.TabIndex = 31;
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
            this.clientInfo.ResumeLayout(false);
            this.clientInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientData)).EndInit();
            this.Report.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reportInformation)).EndInit();
            this.service.ResumeLayout(false);
            this.service.PerformLayout();
            this.contractForm.ResumeLayout(false);
            this.contractForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contractTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planeGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planLong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage clientInfo;
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
        private System.Windows.Forms.TabPage Report;
        private System.Windows.Forms.TabPage service;
        private System.Windows.Forms.Button generateReport;
        private System.Windows.Forms.Button updateTable;
        private System.Windows.Forms.DataGridView reportInformation;
        private System.Windows.Forms.TabPage contractForm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox communicationComboBox2;
        private System.Windows.Forms.TextBox phone2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lastnameTextBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameTextBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox surnameTextBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView contractTable;
        private System.Windows.Forms.Button deletePlane;
        private System.Windows.Forms.Button ChangePlane;
        private System.Windows.Forms.Button addPlane;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox pricePerMonth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox planCommentTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox planNameTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView planeGrid;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.ComboBox planComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown planLong;
        private System.Windows.Forms.TextBox pricePerYear;
    }
}


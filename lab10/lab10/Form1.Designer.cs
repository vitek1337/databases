namespace lab10
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.surnameTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.clientData = new System.Windows.Forms.DataGridView();
            this.surnameLabel = new System.Windows.Forms.Label();
            this.changeEntry = new System.Windows.Forms.Button();
            this.deleteEntry = new System.Windows.Forms.Button();
            this.addEntry = new System.Windows.Forms.Button();
            this.NameLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.lastnameTextBox = new System.Windows.Forms.TextBox();
            this.lastnameLabel = new System.Windows.Forms.Label();
            this.phoneNumbTextBox = new System.Windows.Forms.TextBox();
            this.phoneNumb = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientData)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.phoneNumbTextBox);
            this.tabPage1.Controls.Add(this.phoneNumb);
            this.tabPage1.Controls.Add(this.lastnameLabel);
            this.tabPage1.Controls.Add(this.lastnameTextBox);
            this.tabPage1.Controls.Add(this.nameTextBox);
            this.tabPage1.Controls.Add(this.NameLabel);
            this.tabPage1.Controls.Add(this.addEntry);
            this.tabPage1.Controls.Add(this.deleteEntry);
            this.tabPage1.Controls.Add(this.changeEntry);
            this.tabPage1.Controls.Add(this.surnameLabel);
            this.tabPage1.Controls.Add(this.clientData);
            this.tabPage1.Controls.Add(this.surnameTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // surnameTextBox
            // 
            this.surnameTextBox.Location = new System.Drawing.Point(6, 35);
            this.surnameTextBox.Name = "surnameTextBox";
            this.surnameTextBox.Size = new System.Drawing.Size(212, 20);
            this.surnameTextBox.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // clientData
            // 
            this.clientData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientData.Location = new System.Drawing.Point(224, 6);
            this.clientData.Name = "clientData";
            this.clientData.Size = new System.Drawing.Size(560, 410);
            this.clientData.TabIndex = 1;
            this.clientData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // surnameLabel
            // 
            this.surnameLabel.AutoSize = true;
            this.surnameLabel.Location = new System.Drawing.Point(8, 19);
            this.surnameLabel.Name = "surnameLabel";
            this.surnameLabel.Size = new System.Drawing.Size(56, 13);
            this.surnameLabel.TabIndex = 2;
            this.surnameLabel.Text = "Фамилия";
            // 
            // changeEntry
            // 
            this.changeEntry.Location = new System.Drawing.Point(82, 378);
            this.changeEntry.Name = "changeEntry";
            this.changeEntry.Size = new System.Drawing.Size(65, 38);
            this.changeEntry.TabIndex = 3;
            this.changeEntry.Text = "Изменить";
            this.changeEntry.UseVisualStyleBackColor = true;
            this.changeEntry.Click += new System.EventHandler(this.changeEntry_Click);
            // 
            // deleteEntry
            // 
            this.deleteEntry.Location = new System.Drawing.Point(153, 378);
            this.deleteEntry.Name = "deleteEntry";
            this.deleteEntry.Size = new System.Drawing.Size(65, 38);
            this.deleteEntry.TabIndex = 4;
            this.deleteEntry.Text = "Удалить";
            this.deleteEntry.UseVisualStyleBackColor = true;
            this.deleteEntry.Click += new System.EventHandler(this.deleteEntry_Click);
            // 
            // addEntry
            // 
            this.addEntry.Location = new System.Drawing.Point(11, 378);
            this.addEntry.Name = "addEntry";
            this.addEntry.Size = new System.Drawing.Size(65, 38);
            this.addEntry.TabIndex = 5;
            this.addEntry.Text = "Добавить";
            this.addEntry.UseVisualStyleBackColor = true;
            this.addEntry.Click += new System.EventHandler(this.addEntry_Click);
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(8, 67);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(29, 13);
            this.NameLabel.TabIndex = 6;
            this.NameLabel.Text = "Имя";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(6, 83);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(212, 20);
            this.nameTextBox.TabIndex = 7;
            // 
            // lastnameTextBox
            // 
            this.lastnameTextBox.Location = new System.Drawing.Point(6, 134);
            this.lastnameTextBox.Name = "lastnameTextBox";
            this.lastnameTextBox.Size = new System.Drawing.Size(212, 20);
            this.lastnameTextBox.TabIndex = 8;
            // 
            // lastnameLabel
            // 
            this.lastnameLabel.AutoSize = true;
            this.lastnameLabel.Location = new System.Drawing.Point(8, 118);
            this.lastnameLabel.Name = "lastnameLabel";
            this.lastnameLabel.Size = new System.Drawing.Size(54, 13);
            this.lastnameLabel.TabIndex = 9;
            this.lastnameLabel.Text = "Отчество";
            // 
            // phoneNumbTextBox
            // 
            this.phoneNumbTextBox.Location = new System.Drawing.Point(6, 182);
            this.phoneNumbTextBox.Name = "phoneNumbTextBox";
            this.phoneNumbTextBox.Size = new System.Drawing.Size(212, 20);
            this.phoneNumbTextBox.TabIndex = 11;
            // 
            // phoneNumb
            // 
            this.phoneNumb.AutoSize = true;
            this.phoneNumb.Location = new System.Drawing.Point(8, 166);
            this.phoneNumb.Name = "phoneNumb";
            this.phoneNumb.Size = new System.Drawing.Size(93, 13);
            this.phoneNumb.TabIndex = 10;
            this.phoneNumb.Text = "Номер телефона";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.clientData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox surnameTextBox;
        private System.Windows.Forms.Button changeEntry;
        private System.Windows.Forms.Label surnameLabel;
        private System.Windows.Forms.DataGridView clientData;
        private System.Windows.Forms.TextBox lastnameTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button addEntry;
        private System.Windows.Forms.Button deleteEntry;
        private System.Windows.Forms.TextBox phoneNumbTextBox;
        private System.Windows.Forms.Label phoneNumb;
        private System.Windows.Forms.Label lastnameLabel;
    }
}


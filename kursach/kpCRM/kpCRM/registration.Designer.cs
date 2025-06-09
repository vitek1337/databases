namespace kpCRM
{
    partial class registration
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
            this.SurnameTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.lastnameTextBox = new System.Windows.Forms.TextBox();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.passwordApprovingTextBox = new System.Windows.Forms.TextBox();
            this.divisionsComboBox = new System.Windows.Forms.ComboBox();
            this.positionsComboBox = new System.Windows.Forms.ComboBox();
            this.RegistrationLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.chooseRoleComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // SurnameTextBox
            // 
            this.SurnameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SurnameTextBox.Location = new System.Drawing.Point(43, 142);
            this.SurnameTextBox.Name = "SurnameTextBox";
            this.SurnameTextBox.Size = new System.Drawing.Size(174, 20);
            this.SurnameTextBox.TabIndex = 0;
            this.SurnameTextBox.Text = "фамилия";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.nameTextBox.Location = new System.Drawing.Point(43, 178);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(174, 20);
            this.nameTextBox.TabIndex = 1;
            this.nameTextBox.Text = "имя";
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // lastnameTextBox
            // 
            this.lastnameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lastnameTextBox.Location = new System.Drawing.Point(43, 216);
            this.lastnameTextBox.Name = "lastnameTextBox";
            this.lastnameTextBox.Size = new System.Drawing.Size(174, 20);
            this.lastnameTextBox.TabIndex = 2;
            this.lastnameTextBox.Text = "Отчество";
            // 
            // loginTextBox
            // 
            this.loginTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginTextBox.Location = new System.Drawing.Point(574, 142);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.loginTextBox.Size = new System.Drawing.Size(174, 20);
            this.loginTextBox.TabIndex = 3;
            this.loginTextBox.Text = "Введите логин";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passwordTextBox.Location = new System.Drawing.Point(574, 178);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(174, 20);
            this.passwordTextBox.TabIndex = 4;
            this.passwordTextBox.Text = "Введите пароль";
            // 
            // passwordApprovingTextBox
            // 
            this.passwordApprovingTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passwordApprovingTextBox.Location = new System.Drawing.Point(574, 216);
            this.passwordApprovingTextBox.Name = "passwordApprovingTextBox";
            this.passwordApprovingTextBox.Size = new System.Drawing.Size(174, 20);
            this.passwordApprovingTextBox.TabIndex = 5;
            this.passwordApprovingTextBox.Text = "Подтвердите пароль";
            // 
            // divisionsComboBox
            // 
            this.divisionsComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.divisionsComboBox.FormattingEnabled = true;
            this.divisionsComboBox.Location = new System.Drawing.Point(316, 141);
            this.divisionsComboBox.Name = "divisionsComboBox";
            this.divisionsComboBox.Size = new System.Drawing.Size(180, 21);
            this.divisionsComboBox.TabIndex = 6;
            this.divisionsComboBox.Text = "Выберите подразделение";
            this.divisionsComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // positionsComboBox
            // 
            this.positionsComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.positionsComboBox.FormattingEnabled = true;
            this.positionsComboBox.Location = new System.Drawing.Point(316, 178);
            this.positionsComboBox.Name = "positionsComboBox";
            this.positionsComboBox.Size = new System.Drawing.Size(180, 21);
            this.positionsComboBox.TabIndex = 7;
            this.positionsComboBox.Text = "Выберите должность";
            // 
            // RegistrationLabel
            // 
            this.RegistrationLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RegistrationLabel.AutoSize = true;
            this.RegistrationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistrationLabel.Location = new System.Drawing.Point(312, 32);
            this.RegistrationLabel.Name = "RegistrationLabel";
            this.RegistrationLabel.Size = new System.Drawing.Size(164, 29);
            this.RegistrationLabel.TabIndex = 8;
            this.RegistrationLabel.Text = "Регистрация";
            this.RegistrationLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(38, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 15);
            this.label1.TabIndex = 9;
            this.label1.Text = "Личная информация пользвателя";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(294, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(221, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Рабочая информация пользователя";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(640, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Данные аккаунта";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(43, 288);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(705, 34);
            this.button1.TabIndex = 12;
            this.button1.Text = "Зарегистрироваться";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(12, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 13;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // chooseRoleComboBox
            // 
            this.chooseRoleComboBox.FormattingEnabled = true;
            this.chooseRoleComboBox.Location = new System.Drawing.Point(316, 214);
            this.chooseRoleComboBox.Name = "chooseRoleComboBox";
            this.chooseRoleComboBox.Size = new System.Drawing.Size(180, 21);
            this.chooseRoleComboBox.TabIndex = 14;
            this.chooseRoleComboBox.Text = "Выберите вашу роль в компании";
            this.chooseRoleComboBox.SelectedIndexChanged += new System.EventHandler(this.chooseRoleComboBox_SelectedIndexChanged);
            // 
            // registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 368);
            this.Controls.Add(this.chooseRoleComboBox);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RegistrationLabel);
            this.Controls.Add(this.positionsComboBox);
            this.Controls.Add(this.divisionsComboBox);
            this.Controls.Add(this.passwordApprovingTextBox);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.loginTextBox);
            this.Controls.Add(this.lastnameTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.SurnameTextBox);
            this.Name = "registration";
            this.Text = "registration";
            this.Load += new System.EventHandler(this.registration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SurnameTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox lastnameTextBox;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox passwordApprovingTextBox;
        private System.Windows.Forms.ComboBox divisionsComboBox;
        private System.Windows.Forms.ComboBox positionsComboBox;
        private System.Windows.Forms.Label RegistrationLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.ComboBox chooseRoleComboBox;
    }
}
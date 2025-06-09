namespace kpCRM
{
    partial class fastQuerryForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.querryTextBox = new System.Windows.Forms.TextBox();
            this.querryLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(328, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Создать новый запрос";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // querryTextBox
            // 
            this.querryTextBox.Location = new System.Drawing.Point(2, 39);
            this.querryTextBox.Multiline = true;
            this.querryTextBox.Name = "querryTextBox";
            this.querryTextBox.Size = new System.Drawing.Size(327, 58);
            this.querryTextBox.TabIndex = 1;
            // 
            // querryLabel
            // 
            this.querryLabel.AutoSize = true;
            this.querryLabel.Location = new System.Drawing.Point(2, 20);
            this.querryLabel.Name = "querryLabel";
            this.querryLabel.Size = new System.Drawing.Size(88, 13);
            this.querryLabel.TabIndex = 2;
            this.querryLabel.Text = "Введите запрос";
            // 
            // fastQuerryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 135);
            this.Controls.Add(this.querryLabel);
            this.Controls.Add(this.querryTextBox);
            this.Controls.Add(this.button1);
            this.Name = "fastQuerryForm";
            this.Text = "Быстрый запрос к БД";
            this.Load += new System.EventHandler(this.fastQuerryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox querryTextBox;
        private System.Windows.Forms.Label querryLabel;
    }
}
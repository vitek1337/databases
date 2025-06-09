using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kpCRM
{
    public partial class login : Form
    {
        private loginServices services;
        public login()
        {
            services = new loginServices();
            InitializeComponent();
        }

        public userPanel userPanel
        {
            get => default;
            set
            {
            }
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            registration regForm = new registration();
            this.Hide();
            regForm.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int userId;

            loadDbServices loadDbServices = new loadDbServices();
            if (services.isApproved(loginTextBox.Text, passwordTextBox.Text) == true)
            {
                MessageBox.Show("Вход выполнен успешно");
                userPanel userForm = new userPanel(loadDbServices.getUserRole(loginTextBox.Text), loadDbServices.getUserId(loginTextBox.Text, loadDbServices.getUserRole(loginTextBox.Text)));
                userForm.ShowDialog();
                this.Close();
            }
            else MessageBox.Show("Аккаунта с такими данными не существует");
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}

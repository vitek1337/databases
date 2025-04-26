using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab10
{
    public partial class Form1 : Form
    {
        private SqlConnection connection;
        SqlDataAdapter adapter;
        BaseServices client;

        public Form1()
        {
            InitializeComponent();
            client = new BaseServices();
            initiateClient();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void initiateClient()
        {
            DataTable dt = new DataTable();
            adapter = client.dataToGrid();
            adapter.Fill(dt);
            clientData.DataSource = dt; 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addEntry_Click(object sender, EventArgs e)
        {
            client.addNewEntry(surnameTextBox.Text, nameTextBox.Text, lastnameTextBox.Text, phoneNumbTextBox.Text);
            initiateClient();
        }

        private void deleteEntry_Click(object sender, EventArgs e)
        {
            try {
                client.deleteEntry(getId());
                initiateClient();
                MessageBox.Show("Строка удалена успешно!");
            } catch { MessageBox.Show("Возникла ошибка при удалении строки"); }
        }

        private void changeEntry_Click(object sender, EventArgs e)
        {
            try
            {
                client.changeEntry(surnameTextBox.Text, nameTextBox.Text, lastnameTextBox.Text, phoneNumbTextBox.Text, getId());
                initiateClient();
                MessageBox.Show("Строка изменена успешно!");
            }
            catch { MessageBox.Show("Возникла ошибка при удалении строки"); }
        }

        public int getId()
        {
            return int.Parse(clientData.SelectedRows[0].Cells[0].Value.ToString());
        }
    }
}

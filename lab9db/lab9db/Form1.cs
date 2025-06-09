using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Configuration;
using System.Windows.Forms;
using System.Xml.Linq;

namespace lab9db
{
    public partial class Form1 : Form
    {
        private readonly string cfg = ConfigurationManager
                                        .ConnectionStrings["DefaultConnection"]
                                        .ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateDatabaseTable(textBox1.Text.Trim(), tableName.Text.Trim());
        }

        private void addColumn() {

            string sql = "use " + textBox1.Text + " alter table " + tableName.Text + " add " + ColName.Text + " " + colType.Text;
            try
            {
                using (SqlConnection connection = new SqlConnection(cfg))
                {
                    Console.WriteLine(sql);
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Новый столбец успешно создан");
                }
            }
            catch { MessageBox.Show("Возникла ошибка при создании столбца"); }
        }

        private void deleteColumn() {
            string sql = "use " + textBox1.Text + " alter table " + tableName.Text + " drop column " + ColName.Text;

            try { 
                using (SqlConnection connection = new SqlConnection(cfg))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Столбец успешно удален");
                }
            }
            catch { MessageBox.Show("Возникла ошибка при удалении столбца"); }
}

        private void CreateDatabaseTable(string dbName, string tableName)
        {
            if (string.IsNullOrWhiteSpace(dbName) || string.IsNullOrWhiteSpace(tableName))
            {
                MessageBox.Show("Введите имя базы данных и имя таблицы");
                return;
            }

            // Простая схема таблицы
            string sql = $@"
        USE [{dbName}];
        CREATE TABLE [{tableName}] (
            Id INT PRIMARY KEY IDENTITY(1,1),
        );
    ";

            try
            {
                using (SqlConnection connection = new SqlConnection(cfg))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Таблица [{tableName}] успешно создана в базе данных [{dbName}].");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании таблицы: " + ex.Message);
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            addColumn();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleteColumn();
        }
    }
}

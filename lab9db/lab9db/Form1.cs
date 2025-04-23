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
        // читаем вашу строку подключения
        private readonly string cfg = ConfigurationManager
                                        .ConnectionStrings["DefaultConnection"]
                                        .ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // для отладки покажем, к чему мы подключаемся
            MessageBox.Show(cfg, "ConnectionString");
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            CreateDatabase(textBox1.Text.Trim());
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

        private void CreateDatabase(string dbName)
        {
            if (string.IsNullOrWhiteSpace(dbName))
            {
                MessageBox.Show("Введите имя базы данных");
                return;
            }


            string sql = $@"
                IF NOT EXISTS (SELECT name 
                               FROM sys.databases 
                               WHERE name = @dbName)
                BEGIN
                   EXEC('CREATE DATABASE [' + @dbName + ']');
                END";

            using (SqlConnection connection = new SqlConnection(cfg))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@dbName", dbName);
                cmd.ExecuteNonQuery();
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

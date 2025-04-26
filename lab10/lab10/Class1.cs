using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab10
{
    internal class BaseServices
    {
        private String sql = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private SqlConnection connection;
        SqlDataAdapter adapter;
        private SqlCommand cmd;

        public BaseServices() {
            connection = new SqlConnection(sql);
        }

        public void addNewEntry(string surname, string name, string lastname, string phone)
        {
            if (surname != "" && name != "" && lastname != "" && phone != "")
            {
                cmd = new SqlCommand(
                    "insert into client (client_surname, client_name, client_lastname, phone_number) " +
                    "values (@surname, @name, @lastname, @phone)",
                    connection
                );

                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@lastname", lastname);
                cmd.Parameters.AddWithValue("@phone", phone);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void changeEntry(string surname, string name, string lastname, string phone, int selectedId)
        {   
            cmd = new SqlCommand(
                "update client set client_surname = @surname, client_name = @name," +
                " client_lastname=@lastname, phone_number=@phone where client_id = @id", connection
                );

            connection.Open();
            cmd.Parameters.AddWithValue("@surname", surname);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@lastname", lastname);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@id", selectedId);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void deleteEntry(int selectedId)
        {
                cmd = new SqlCommand("DELETE FROM client WHERE [client_id] = @id", connection);
                connection.Open();
                cmd.Parameters.AddWithValue("@id", selectedId);
                cmd.ExecuteNonQuery();
                connection.Close();
        }

        public SqlDataAdapter dataToGrid()
        {
            connection.Open();
            adapter = new SqlDataAdapter("select * from client", connection);
            connection.Close();
            return adapter;
        }
    }
}

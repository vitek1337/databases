using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab10_telephoneOperator
{
    internal class BaseServices
    {
        private String sql = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private SqlConnection connection;
        SqlDataAdapter adapter;
        private SqlCommand cmd;

        public BaseServices()
        {
            connection = new SqlConnection(sql);
        }

        public void addNewEntry(string surname, string name, string lastname, string communicationWay, string link)
        {
            if (surname != "" && name != "" && lastname != "" && link != "")
            {
                cmd = new SqlCommand(
                    "insert into client (clientSurname, clientName, clientLastname, communicationWay, communicationComment) " +
                    "values (@surname, @name, @lastname, @communicationWay, @communicationComment)",
                    connection
                );

                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@lastname", lastname);
                cmd.Parameters.AddWithValue("@communicationWay", communicationWay);
                cmd.Parameters.AddWithValue("@communicationComment", link);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void changeEntry(string surname, string name, string lastname, string communicationWay, string link, int selectedId)
        {
            cmd = new SqlCommand(
                "update client set clientSurname = @surname, clientName = @name," +
                " clientLastname=@lastname, communicationWay = @communicationWay, communicationComment = @communicationComment where clientId = @id", connection
                );

            connection.Open();
            cmd.Parameters.AddWithValue("@surname", surname);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@lastname", lastname);
            cmd.Parameters.AddWithValue("@communicationWay", communicationWay);
            cmd.Parameters.AddWithValue("@communicationComment", link);
            cmd.Parameters.AddWithValue("@id", selectedId);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void deleteEntry(int selectedId)
        {
            cmd = new SqlCommand("DELETE FROM client WHERE [clientId] = @id", connection);
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

        public SqlDataAdapter setReportData()
        {
            connection.Open();
            adapter = new SqlDataAdapter(
                "SELECT \r\n    c.clientId,\r\n    c.clientSurname,\r\n    c.clientName,\r\n    c.clientLastName,\r\n    c.communicationWay,\r\n    c.communicationComment,\r\n    COUNT(con.contractId) AS numberOfContracts,\r\n    SUM(pp.planPricePerMonth) AS totalSpent\r\nFROM client c\r\nLEFT JOIN contract con ON c.clientId = con.clientIdFk\r\nLEFT JOIN pricingPlans pp ON con.pricingPlanIdFk = pp.pricingPlanId\r\nGROUP BY \r\n    c.clientId, c.clientSurname, c.clientName, c.clientLastName, \r\n    c.communicationWay, c.communicationComment\r\n", connection
                );
            connection.Close();
            return adapter;
        }
    }
}

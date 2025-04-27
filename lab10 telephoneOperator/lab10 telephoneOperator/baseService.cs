using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
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

        public SqlDataAdapter setPlaneData()
        {
            connection.Open();
            adapter = new SqlDataAdapter("select * from pricingPlans", connection);
            connection.Close();
            return adapter;
        }

        public void addPlaneData(string planName, string planComment, int planPricePerMonth, int planPricePerYear)
        {
            connection.Open();
            cmd = new SqlCommand(
                "insert into pricingPlans (planName, planComment, planPricePerMonth, planPricePerYear) " +
                "values (@planName, @planComment, @planPricePerMonth, @planPricePerYear)", connection
            );
            cmd.Parameters.AddWithValue("@planName", planName);
            cmd.Parameters.AddWithValue("@planComment", planComment);
            cmd.Parameters.AddWithValue("@planPricePerMonth", planPricePerMonth);
            cmd.Parameters.AddWithValue("@planPricePerYear", planPricePerYear);

            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void changePlaneData(string planName, string planComment, int planPricePerMonth, int planPricePerYear, int planeId)
        {
            connection.Open();
            cmd = new SqlCommand(
                "update pricingPlans set planName = @planName, planComment = @planComment, planPricePerMonth = @planPricePerMonth, planPricePerYear = @planPricePerYear" +
                " where pricingPlanId = @planId",
                connection
                );
            cmd.Parameters.AddWithValue("@planName", planName);
            cmd.Parameters.AddWithValue("@planComment", planComment);
            cmd.Parameters.AddWithValue("@planPricePerMonth", planPricePerMonth);
            cmd.Parameters.AddWithValue("@planPricePerYear", planPricePerYear);
            cmd.Parameters.AddWithValue("@planId", planeId);

            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void deletePlaneData(int planId) {
            connection.Open();

            cmd = new SqlCommand("delete from pricingPlans where pricingPlanId = @planId", connection);
  
            cmd.Parameters.AddWithValue("@planId", planId);

            cmd.ExecuteNonQuery();  
            connection.Close();
        }

        public void setContractData(string surname, string name, string lastname, string communicationWay, string link, string rate, int rateLong)
        {
            if (surname != "" && name != "" && lastname != "" && link != "" && rate != "" && rateLong > 0)
            {
                connection.Open();
                cmd = new SqlCommand(
                    "if exists (select 1 from pricingPlans where planName = @rate)" +
                    " begin " +
                    " insert into client (clientSurname, clientName, clientLastname, communicationWay, communicationComment) values (@surname, @name, @lastname, @communicationWay, @communicationComment);"
                   +
                    " insert into contract (clientIdFk, pricingPlanIdFk, contractLong) values(SCOPE_IDENTITY(), (SELECT pricingPlanId FROM pricingPlans WHERE planName = @rate), @rateLong)" +
                    " end"
                    ,
                    connection
                );

                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@lastname", lastname);
                cmd.Parameters.AddWithValue("@communicationWay", communicationWay);
                cmd.Parameters.AddWithValue("@communicationComment", link);
                cmd.Parameters.AddWithValue("@rate", rate);
                cmd.Parameters.AddWithValue("@rateLong", rateLong);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void deleteContractData(int contractId)
        {
            cmd = new SqlCommand("DELETE FROM contract WHERE [contractId] = @id", connection);
            connection.Open();
            cmd.Parameters.AddWithValue("@id", contractId);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void changeContractData(string surname, string name, string lastname, string communicationWay, string link, string rate, int rateLong, int clientId, int contractId)
        {
            connection.Open();

            // Сначала обновляем клиента
            SqlCommand updateClientCmd = new SqlCommand(
                "UPDATE client SET clientSurname = @surname, clientName = @name, " +
                "clientLastname = @lastname, communicationWay = @communicationWay, " +
                "communicationComment = @communicationComment WHERE clientId = @cid", connection
            );
            updateClientCmd.Parameters.AddWithValue("@surname", surname);
            updateClientCmd.Parameters.AddWithValue("@name", name);
            updateClientCmd.Parameters.AddWithValue("@lastname", lastname);
            updateClientCmd.Parameters.AddWithValue("@communicationWay", communicationWay);
            updateClientCmd.Parameters.AddWithValue("@communicationComment", link);
            updateClientCmd.Parameters.AddWithValue("@cid", clientId);
            updateClientCmd.ExecuteNonQuery();

            // Потом обновляем контракт
            SqlCommand updateContractCmd = new SqlCommand(
                "UPDATE contract SET " +
                "clientIdFk = @cId, " +
                "pricingPlanIdFk = (SELECT pricingPlanId FROM pricingPlans WHERE planName = @rate), " +
                "contractLong = @rateLong " +
                "WHERE contractId = @contractId",
                connection
            );
            updateContractCmd.Parameters.AddWithValue("@cId", clientId);
            updateContractCmd.Parameters.AddWithValue("@rate", rate);
            updateContractCmd.Parameters.AddWithValue("@rateLong", rateLong);
            updateContractCmd.Parameters.AddWithValue("@contractId", contractId);

            updateContractCmd.ExecuteNonQuery();

            connection.Close();
        }

        public SqlDataAdapter setContractDataTable()
        {
            connection.Open();
            adapter = new SqlDataAdapter("SELECT * FROM client INNER JOIN contract ON client.clientId = contract.clientIdFk INNER JOIN pricingPlans ON pricingPlans.pricingPlanId = contract.pricingPlanIdFk;", connection);
            connection.Close();
            return adapter;
        }

        public List<string> fillPlansArray()
        {
            List<string> planNames = new List<string>();

            using (SqlConnection connection = new SqlConnection(sql))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT planName FROM pricingPlans", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        planNames.Add(reader.GetString(0));
                    }
                }
            }
            
            return planNames;
        }

        public SqlDataAdapter setReportData()
        {
            connection.Open();
            adapter = new SqlDataAdapter(
                "SELECT pricingPlans.planName AS PlanName, COUNT(DISTINCT contract.clientIdFk) AS ClientCount, " +
                "ISNULL(SUM((contract.contractLong / 12) * pricingPlans.planPricePerYear + " +
                "(contract.contractLong % 12) * pricingPlans.planPricePerMonth), 0) AS TotalRevenue " +
                "FROM pricingPlans " +
                "LEFT JOIN contract ON pricingPlans.pricingPlanId = contract.pricingPlanIdFk " +
                "GROUP BY pricingPlans.planName, pricingPlans.pricingPlanId " +
                "ORDER BY pricingPlans.pricingPlanId",
            connection
            );
            connection.Close();
            return adapter;
        }

        public SqlDataAdapter setWordReportData()
        {
            connection.Open();
            adapter = new SqlDataAdapter(
                "SELECT client.clientId, client.clientSurname, client.clientName, client.clientLastName, " +
                "SUM((contract.contractLong / 12) * pricingPlans.planPricePerYear + " +
                "(contract.contractLong % 12) * pricingPlans.planPricePerMonth) AS TotalSpent " +
                "FROM client " +
                "INNER JOIN contract ON client.clientId = contract.clientIdFk " +
                "INNER JOIN pricingPlans ON contract.pricingPlanIdFk = pricingPlans.pricingPlanId " +
                "GROUP BY client.clientId, client.clientSurname, client.clientName, client.clientLastName " +
                "HAVING SUM((contract.contractLong / 12) * pricingPlans.planPricePerYear + " +
                "(contract.contractLong % 12) * pricingPlans.planPricePerMonth) > 10000 " +
                "ORDER BY TotalSpent DESC", 
                connection)
                ;
            connection.Close();
            return adapter;
        }
    }
}

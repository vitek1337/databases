using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Word = Microsoft.Office.Interop.Word;


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

        public SqlDataAdapter LoadReportInfo()
        {
            string query = @"
        SELECT 
            c.clientSurname + ' ' + c.clientName + ' ' + c.clientLastName AS [ФИО клиента],
            c.communicationWay AS [Способ связи],
            p.planName AS [Название тарифа],
            p.planPricePerMonth AS [Цена/мес],
            p.planPricePerYear AS [Цена/год],
            ct.contractLong AS [Длительность (мес)],
            CAST('2024-01-01' AS DATE) AS [Дата заключения]
        FROM contract ct
        JOIN client c ON c.clientId = ct.clientIdFk
        JOIN pricingPlans p ON p.pricingPlanId = ct.pricingPlanIdFk";

            SqlConnection conn = new SqlConnection(sql);
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            return adapter;
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

        public SqlDataAdapter setReportData(int age)
        {
            string query = @"
                SELECT 
                    pricingPlans.planName AS [Название тарифа],
                    COUNT(DISTINCT contract.clientIdFk) AS [Число клиентов],
                    ISNULL(SUM(
                        (contract.contractLong / 12) * pricingPlans.planPricePerYear + 
                        (contract.contractLong % 12) * pricingPlans.planPricePerMonth
                    ), 0) AS [Общая прибыль]
                FROM pricingPlans
                LEFT JOIN contract ON pricingPlans.pricingPlanId = contract.pricingPlanIdFk
                LEFT JOIN client ON contract.clientIdFk = client.clientId
                WHERE client.age = @Age
                GROUP BY pricingPlans.planName, pricingPlans.pricingPlanId
                ORDER BY pricingPlans.pricingPlanId";

            // Открывать соединение вручную не нужно при использовании SqlDataAdapter
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Age", age);
            adapter.SelectCommand = command;

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

        private void ExportDataTableToWord(System.Data.DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта.");
                return;
            }

            var wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.Visible = true;

            var doc = wordApp.Documents.Add();
            var para = doc.Content.Paragraphs.Add();
            para.Range.Text = "Отчет по заключенным договорам";
            para.Range.InsertParagraphAfter();

            var table = doc.Tables.Add(doc.Bookmarks.get_Item("\\endofdoc").Range,
                                       dataTable.Rows.Count + 1, dataTable.Columns.Count);
            table.Borders.Enable = 1;

            // Заголовки
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                table.Cell(1, i + 1).Range.Text = dataTable.Columns[i].ColumnName;
                table.Cell(1, i + 1).Range.Bold = 1;
            }

            // Данные
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    table.Cell(i + 2, j + 1).Range.Text = dataTable.Rows[i][j]?.ToString();
                }
            }
        }

    }
}

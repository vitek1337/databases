using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace lab10_telephoneOperator
{
    public partial class Form1 : Form
    {
        private SqlConnection connection;
        SqlDataAdapter adapter;
        SqlDataAdapter adapter2;
        BaseServices client;

        List<string> communicationWay = new List<string>();

        public Form1()
        {
            InitializeComponent();
            communicationWay.Add("Номер телефона");
            communicationWay.Add("Меил");
            communicationWay.Add("Ссылка");
            fillComboBox();
            client = new BaseServices();
            initiateClient();
        }

        public void fillComboBox()
        {
            for (int i = 0; i < communicationWay.Count; i++)
            {
                communicationComboBox.Items.Add(communicationWay[i]);
            }
        }
        private void initiateClient()
        {
            DataTable dt = new DataTable();
            adapter = client.dataToGrid();
            adapter.Fill(dt);
            clientData.DataSource = dt;
            clientData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void updateReportTable()
        {
            DataTable dt = new DataTable();
            adapter2 = client.setReportData();
            adapter2.Fill(dt);
            reportInformation.DataSource = dt;
            reportInformation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void ExportExcel(DataGridView dataGrid)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();

            // создаем новый WorkBook
            Microsoft.Office.Interop.Excel.Workbook workbook = app.Workbooks.Add(Type.Missing);

            // новый ExcelSheet в workbook
            Microsoft.Office.Interop.Excel.Worksheet worksheet = null;
            app.Visible = true;
            worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
            worksheet = workbook.ActiveSheet;

            // задаем имя для worksheet
            worksheet.Name = "Exported from gridView";

            for (int i = 1; i < dataGrid.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGrid.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dataGrid.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGrid.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGrid.Rows[i].Cells[j].Value.ToString();
                }
            }

            // сохраняем
            string folderPath = @"C:\Output";

            if (!System.IO.Directory.Exists(folderPath))
            {
                System.IO.Directory.CreateDirectory(folderPath);
            }

            workbook.SaveAs(System.IO.Path.Combine(folderPath, "Output.xls"), Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            // закрываем подключение к excel
            app.Quit();
        }


        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void lastnameLabel_Click(object sender, EventArgs e)
        {

        }

        private void addEntry_Click(object sender, EventArgs e)
        {
            client.addNewEntry(surnameTextBox.Text, nameTextBox.Text, lastnameTextBox.Text, communicationComboBox.SelectedItem.ToString(), CommunicationTextBox.Text);
            initiateClient();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                client.changeEntry(surnameTextBox.Text, nameTextBox.Text, lastnameTextBox.Text, communicationComboBox.SelectedItem.ToString(), CommunicationTextBox.Text, getId());
                initiateClient();
                MessageBox.Show("Строка изменена успешно!");
            }
            catch { MessageBox.Show("Возникла ошибка при удалении строки"); }
        }

        private void deleteEntry_Click(object sender, EventArgs e)
        {
            try
            {
                client.deleteEntry(getId());
                initiateClient();
                MessageBox.Show("Строка удалена успешно!");
            }
            catch { MessageBox.Show("Возникла ошибка при удалении строки"); }
        }

        public int getId()
        {
            return int.Parse(clientData.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void communicationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (communicationComboBox.SelectedIndex == 0) communicationLabel.Text = "Номер телефона";
            else if (communicationComboBox.SelectedIndex == 1) communicationLabel.Text = "Меил";
            else if (communicationComboBox.SelectedIndex == 2) communicationLabel.Text = "Ссылка";
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ExportExcel(reportInformation);
        }

        private void updateTable_Click(object sender, EventArgs e)
        {
            updateReportTable();
        }
    }
}

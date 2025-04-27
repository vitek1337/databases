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
        SqlDataAdapter adapter3;
        SqlDataAdapter adapter4;
        BaseServices client;

        List<string> communicationWay = new List<string>();

        public Form1()
        {
            InitializeComponent();
            communicationWay.Add("Номер телефона");
            communicationWay.Add("Меил");
            communicationWay.Add("Ссылка");
            client = new BaseServices();
            initiateClient();
            updateContractTable();
            updatePlaneTable();
            fillComboBox();
        }

        public void fillComboBox()
        {

            List<string> planNames = client.fillPlansArray();
            for (int i = 0; i < communicationWay.Count; i++)
            {
                communicationComboBox.Items.Add(communicationWay[i]);
                communicationComboBox2.Items.Add(communicationWay[i]);
            }

            for (int i = 0; i < planNames.Count; i++)
            {
                planComboBox.Items.Add(planNames[i]);
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

        private void updateContractTable()
        {
            DataTable dt = new DataTable();
            adapter3 = client.setContractDataTable();
            adapter3.Fill(dt);
            contractTable.DataSource = dt;
            contractTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void updatePlaneTable()
        {
            DataTable dt = new DataTable();
            adapter4 = client.setPlaneData();
            adapter4.Fill(dt);
            planeGrid.DataSource = dt;
            planeGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        public int getIdClientFromContract()
        {
            return int.Parse(contractTable.SelectedRows[0].Cells[0].Value.ToString());
        }

        public int getIdContractId() {
            return int.Parse(contractTable.SelectedRows[0].Cells[6].Value.ToString());
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
    
            //try
            //{
                updateReportTable();
                MessageBox.Show("Строка изменена успешно!");
            //}
            //catch { MessageBox.Show("Возникла ошибка при изменнии строки"); }
            updateContractTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                client.deleteContractData(getIdContractId());
                MessageBox.Show("Строка удалена успешно!");
            }
            catch { MessageBox.Show("Возникла ошибка при удалении строки"); }
            updateContractTable();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            try
            {
                client.changeContractData(surnameTextBox2.Text, nameTextBox2.Text, lastnameTextBox2.Text, communicationComboBox2.SelectedItem.ToString(), phone2.Text, planComboBox.SelectedItem.ToString(), (int)planLong.Value, getIdClientFromContract(), getIdContractId());
                MessageBox.Show("Строка изменена успешно!");
            }
            catch { MessageBox.Show("Возникла ошибка при изменнии строки"); }
            updateContractTable();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                client.setContractData(surnameTextBox2.Text, nameTextBox2.Text, lastnameTextBox2.Text, communicationComboBox2.SelectedItem.ToString(), phone2.Text, planComboBox.SelectedItem.ToString(), (int) planLong.Value);
                MessageBox.Show("Запись добавлена успешно!");
            }
            catch { MessageBox.Show("Возникла ошибка при добавлении записи"); }
            updateContractTable();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                client.deletePlaneData(getPlanId());
                updatePlaneTable();
                MessageBox.Show("Запись Удалена успешно!");
            }
            catch { MessageBox.Show("Возникла ошибка при удалении записи!"); };
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try { 
                client.changePlaneData(planNameTextBox.Text, planCommentTextBox.Text, int.Parse(pricePerMonth.Text), int.Parse(pricePerYear.Text), getPlanId());
                updatePlaneTable();
                MessageBox.Show("Запись изменена успешно!");
            }
            catch { MessageBox.Show("Возникла ошибка при изменении записи!"); };
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                client.addPlaneData(planNameTextBox.Text, planCommentTextBox.Text, int.Parse(pricePerMonth.Text), int.Parse(pricePerYear.Text));
                updatePlaneTable();
                MessageBox.Show("Запись добавлена успешно!");
            }
            catch { MessageBox.Show("Запись добавлена успешно!"); };
        }

        private int getPlanId()
        {
            return int.Parse(planeGrid.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void service_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data; // Для DataTable
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel; // Псевдоним
using Word = Microsoft.Office.Interop.Word;   // Псевдоним
using System.IO;
using Xceed.Words.NET;
using Xceed.Document.NET;

namespace kpCRM
{
    public partial class userPanel : Form
    {
        private loadDbServices loadDbServices = new loadDbServices();
        private List<TabPage> hiddenTab;
        private SqlDataAdapter adapter;
        private string userType;
        private int orderer_id;
        private int executer_id;
        public int execution_id;
        private Dictionary<string, int> divisionNameToId;
        private Dictionary<string, int> positionNameToId;


        public userPanel(int userType, int userId)
        {
            InitializeComponent();
            hiddenTab = new List<TabPage>();

            if (userType == 0)
            {
                executer_id = userId;
                loadAdmin();
                loadTables();
                //догрузить для начальника\
                fillExecutionsData();
                fillExecutionCombo();
                updateExecutionData();
                loadExecuterInfo();
                filDivisionsCombo();
                fillPositionsCombo();
                HideTabAdmin();
                dataGridView4.CellFormatting += dataGridView4_CellFormatting;
                HideTabOrder();
                loadExecutions();
                loadOtchet();
            }
            else if (userType == 1)
            {
                orderer_id = userId;   
                loadAdmin();
                loadTables();
                //догрузить для начальника\
                fillExecutionsData();
                fillExecutionCombo();
                updateExecutionData();
                loadExecuterInfo();
                filDivisionsCombo();
                fillPositionsCombo();
                HideTabAdmin();
                hideExecutions();
                loadOtchet();
                dataGridView4.CellFormatting += dataGridView4_CellFormatting;
                dataGridView3.MultiSelect = true;
                dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else if (userType == 2)
            {
                orderer_id = userId;
                loadAdmin();
                loadTables();
                fillExecutionsData();
                fillExecutionCombo();
                updateExecutionData();
                loadExecuterInfo();
                filDivisionsCombo();
                fillPositionsCombo();
                fillUserTypeCombo();
                FillexecutionStatusCombo();
                hideExecutions();
                loadOtchet();
                dataGridView4.CellFormatting += dataGridView4_CellFormatting;
                dataGridView3.MultiSelect = true;
                dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            MessageBox.Show("" + executer_id);
            dataGridView3.SelectionChanged += dataGridView3_SelectionChanged;
            dataGridView5.SelectionChanged +=  dataGridView5_SelectionChanged;
        }

        public fastQuerryForm fastQuerryForm
        {
            get => default;
            set
            {
            }
        }

        internal loadDbServices loadDbServices1
        {
            get => default;
            set
            {
            }
        }

        public IdNameItem IdNameItem
        {
            get => default;
            set
            {
            }
        }

        public executionChangeForm executionChangeForm
        {
            get => default;
            set
            {
            }
        }

        public execution_items execution_items
        {
            get => default;
            set
            {
            }
        }

        public void ExportToExcel(int maxOverdueTasks = -1)
        {
            try
            {
                // Получаем данные
                DataTable dt = new DataTable();
                using (SqlDataAdapter adapter = loadDbServices.loadOtchet(maxOverdueTasks))
                {
                    adapter.Fill(dt);
                }

                // Создаем Excel приложение
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = true;
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.ActiveSheet;

                // Заголовки столбцов
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
                }

                // Данные
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString();
                    }
                }

                // Форматирование
                Excel.Range headerRange = worksheet.Range[
                    worksheet.Cells[1, 1],
                    worksheet.Cells[1, dt.Columns.Count]];

                headerRange.Font.Bold = true;
                headerRange.Interior.Color = Excel.XlRgbColor.rgbLightGray;

                // Автоподгонка столбцов
                worksheet.Columns.AutoFit();

                // Сохранение файла
                string fileName = $"Отчет_исполнители_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string fullPath = Path.Combine(desktopPath, fileName);

                workbook.SaveAs(fullPath);
                MessageBox.Show($"Отчет успешно сохранен: {fullPath}");

                // Закрытие
                workbook.Close();
                excelApp.Quit();

                // Освобождение ресурсов COM
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте в Excel: {ex.Message}");
            }
        }

        private void ExportExecutorsReportToWord(int maxOverdueTasks = -1)
        {
            try
            {
                // Получаем данные из базы
                DataTable dt = new DataTable();
                using (SqlDataAdapter adapter = loadDbServices.loadOtchet(maxOverdueTasks))
                {
                    adapter.Fill(dt);
                }

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Нет данных для экспорта.");
                    return;
                }

                // Создаем Word приложение
                var wordApp = new Microsoft.Office.Interop.Word.Application();
                wordApp.Visible = false; // можно включить true, если хочешь визуально

                var doc = wordApp.Documents.Add();

                // Заголовок
                var paraTitle = doc.Paragraphs.Add();
                paraTitle.Range.Text = "Отчет по исполнителям и задачам";
                paraTitle.Range.Font.Bold = 1;
                paraTitle.Range.Font.Size = 16;
                paraTitle.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                paraTitle.Range.InsertParagraphAfter();

                // Дата
                var paraDate = doc.Paragraphs.Add();
                paraDate.Range.Text = $"Дата формирования: {DateTime.Now:dd.MM.yyyy HH:mm}";
                paraDate.Range.Font.Italic = 1;
                paraDate.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                paraDate.Range.InsertParagraphAfter();

                // Таблица
                var table = doc.Tables.Add(doc.Bookmarks["\\endofdoc"].Range, dt.Rows.Count + 1, dt.Columns.Count);
                table.Borders.Enable = 1;

                // Заголовки
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    var cell = table.Cell(1, i + 1);
                    cell.Range.Text = dt.Columns[i].ColumnName;
                    cell.Range.Font.Bold = 1;
                    cell.Range.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                // Данные
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        var text = dt.Rows[i][j]?.ToString() ?? "";
                        var cell = table.Cell(i + 2, j + 1);
                        cell.Range.Text = text;

                        // Подсветка просроченных задач
                        if (dt.Columns[j].ColumnName == "Просроченные задачи" &&
                            int.TryParse(text, out int overdueCount) &&
                            overdueCount > 0)
                        {
                            cell.Range.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorRed;
                        }
                    }
                }

                // Сохранение на рабочий стол
                string fileName = $"Отчет_исполнители_{DateTime.Now:yyyyMMdd_HHmmss}.docx";
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);
                doc.SaveAs2(path);
                doc.Close();
                wordApp.Quit();

                MessageBox.Show($"Отчет успешно сохранен:\n{path}");
            }
            catch (System.Runtime.InteropServices.COMException comEx)
            {
                MessageBox.Show($"Ошибка при работе с Word:\n{comEx.Message}\n\n" +
                                "Убедитесь, что Microsoft Word установлен и работает корректно.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при экспорте:\n{ex.Message}");
            }
        }


        private void setUserId()
        {

        }

        private void loadOtchet()
        {
            adapter = loadDbServices.loadOtchet((int) numericUpDown1.Value);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView7.DataSource = dt;
            dataGridView7.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView3.SelectedRows[0];

                // Вызов вашей функции
                OnRowSelected(selectedRow);
            }
        }

        private void FillexecutionStatusCombo()
        {
            string[] taskStatuses = {
                "Новая",
                "В ожидании",
                "В работе",
                "На проверке",
                "Возвращена на доработку",
                "Завершена",
                "Отложена",
                "Отменена",
                "Провалена"
            };

            executionStatusComboBox.Items.AddRange(taskStatuses);
        }


        private void OnRowSelected(DataGridViewRow row)
        {
            // Пример: получить значение из колонки "id"
            int id = (int) row.Cells["executer_id"].Value;
            adapter = loadDbServices.loadExecutionForExecuterData(id);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView5.DataSource = dt;
            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.executer_id = id;
        }


        private void dataGridView5_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView5.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView5.SelectedRows[0];

                // Вызов вашей функции
                OnRowSelected5(selectedRow);
            }
        }

        private void OnRowSelected5(DataGridViewRow row)
        {
            try
            {
                // Пример: получить значение из колонки "id"
                int id = (int)row.Cells["execution_id"].Value;
                adapter = loadDbServices.loadExecutionForExecuterData(id);
                execution_id = id;
            }
            catch { }
        }

        private void filDivisionsCombo()
        {
            DataTable table = loadDbServices.fillDivisionsCombo();

            DataRow newRow = table.NewRow();
            newRow["division_name"] = "Все отделы";

            // Вставляем в начало (или в конец — через Add)
            table.Rows.InsertAt(newRow, 0);

            divisionsComboBox.DisplayMember = "division_name";
            divisionsComboBox.ValueMember = "division_name";
            divisionsComboBox.DataSource = table;
        }

        private void fillPositionsCombo()
        {
            DataTable table = loadDbServices.fillPositionsCombo();

            DataRow newRow = table.NewRow();
            newRow["position_name"] = "Любая должность";

            // Вставляем в начало (или в конец — через Add)
            table.Rows.InsertAt(newRow, 0);

            positionsComboBox.ValueMember = "position_name";
            positionsComboBox.DisplayMember = "position_name";
            positionsComboBox.DataSource = table;
        }

        private void fillUserTypeCombo()
        {
            userTypeCombo.Items.Add("Админ");
            userTypeCombo.Items.Add("Начальник");
            userTypeCombo.Items.Add("Рабочий");
        }

        private void fillExecutionChangeByDivision()
        {
            if (divisionsComboBox.SelectedValue != null) { 
                string division_name = divisionsComboBox.SelectedValue.ToString();
                if (division_name == "Все отделы") { adapter = loadDbServices.loadAllExecuters(); }
                else { 
                    adapter = loadDbServices.fillExecutionChangeByDivision(division_name); //загрузить всю таблицу поручений
                }

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView3.DataSource = dt;
                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void fillAdminPanelData()
        {
            this.userType = userTypeCombo.SelectedItem.ToString();
            switch (userType)
            {
                case "Админ": fillAdminsData(); break;
                case "Начальник": fillOrderer(); break;
                case "Рабочий": fillExecuter();  break;
            }
        }

        private void fillAdminsData() //загрузка данных админа (данные аккаунта + личные данные)
        {
            adapter = loadDbServices.loadAdminsLogin();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void fillOrderer() //загрузка данных начальника (данные аккаунта + личные данные)
        {
            adapter = loadDbServices.loadordererLogin();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void fillExecuter() //загрузка данных работника (данные аккаунта + личные данные)
        {
            adapter = loadDbServices.loadExecuterLogin(); //загрузить всю таблицу поручений
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void updateAdminLoginDataTable() //апдейт данных первой вкладки (доступно только админу)
        {
            loadDbServices db = new loadDbServices();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                int id = Convert.ToInt32(row.Cells["loginId"].Value);
                string login = Convert.ToString(row.Cells["login"].Value);
                string password = Convert.ToString(row.Cells["password"].Value);
                int loginApprove = Convert.ToInt32(row.Cells["loginApprove"].Value);
                string loginComment = Convert.ToString(row.Cells["loginComment"].Value);
                int userRole = Convert.ToInt32(row.Cells["userRole"].Value);
                db.updateRegLog(id, login, password, loginApprove, loginComment, userRole);

                switch (userType)
                {
                    case "Админ":
                        {
                            int loginIdFk = Convert.ToInt32(row.Cells["admin_id"].Value);
                            string executer_surname = Convert.ToString(row.Cells["admin_surname"].Value);
                            string employee_name = Convert.ToString(row.Cells["admin_name"].Value);
                            string employee_last_name = Convert.ToString(row.Cells["admin_lastname"].Value);
                            int division_id_fk = Convert.ToInt32(row.Cells["division_id"].Value);
                            int position_id_fk = Convert.ToInt32(row.Cells["position_id"].Value);
                            int login_id_fk = Convert.ToInt32(row.Cells["login_id_fk"].Value);

                            db.updateRegReq(loginIdFk, executer_surname, employee_name, employee_last_name, division_id_fk, position_id_fk, login_id_fk);
                            break;
                        }
                    case "Начальник":
                        {
                            int loginIdFk = Convert.ToInt32(row.Cells["orderer_id"].Value);
                            string employee_surname = Convert.ToString(row.Cells["orderer_surname"].Value);
                            string employee_name = Convert.ToString(row.Cells["orderer_name"].Value);
                            string employee_last_name = Convert.ToString(row.Cells["orderer_lastname"].Value);
                            int division_id_fk = Convert.ToInt32(row.Cells["division_id"].Value);
                            int position_id_fk = Convert.ToInt32(row.Cells["position_id"].Value);
                            int login_id_fk = Convert.ToInt32(row.Cells["loginIdFk"].Value);

                            int value = 0;

                            db.updateRegReq(loginIdFk, employee_surname, employee_name, employee_last_name, division_id_fk, position_id_fk, login_id_fk, value);
                            break;
                        }
                    case "Рабочий":
                        {
                            int loginIdFk = Convert.ToInt32(row.Cells["executer_id"].Value);
                            string executer_surname = Convert.ToString(row.Cells["executer_surname"].Value);
                            string employee_name = Convert.ToString(row.Cells["executer_name"].Value);
                            string employee_last_name = Convert.ToString(row.Cells["executer_last_name"].Value);
                            int division_id_fk = Convert.ToInt32(row.Cells["division_id_fk"].Value);
                            int position_id_fk = Convert.ToInt32(row.Cells["position_id_fk"].Value);
                            int execution_status_id_fk = Convert.ToInt32(row.Cells["execution_status_id_fk"].Value);
                            int execution_id_fk = Convert.ToInt32(row.Cells["execution_id_fk"].Value);
                            int login_id_fk = Convert.ToInt32(row.Cells["loginIdFl"].Value);

                            db.updateRegReq(loginIdFk, executer_surname, employee_name, employee_last_name, division_id_fk, position_id_fk, execution_status_id_fk, execution_id_fk, login_id_fk);
                            break;
                        }
                }
            }
        }


        private void updateOrdererLoginDataTable()
        {
            loadDbServices db = new loadDbServices();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                int id = Convert.ToInt32(row.Cells["loginId"].Value);
                string login = Convert.ToString(row.Cells["login"].Value);
                string password = Convert.ToString(row.Cells["password"].Value);
                int loginApprove = Convert.ToInt32(row.Cells["loginApprove"].Value);
                string loginComment = Convert.ToString(row.Cells["loginComment"].Value);
                int userRole = Convert.ToInt32(row.Cells["userRole"].Value);

                int loginIdFk = Convert.ToInt32(row.Cells["loginIdFk"].Value);
                string executer_surname = Convert.ToString(row.Cells["executer_surname"].Value);
                string employee_name = Convert.ToString(row.Cells["employee_name"].Value);
                string employee_last_name = Convert.ToString(row.Cells["employee_last_name"].Value);
                int division_id_fk = Convert.ToInt32(row.Cells["division_id_fk"].Value);
                int position_id_fk = Convert.ToInt32(row.Cells["position_id_fk"].Value);

                db.updateRegLog(id, login, password, loginApprove, loginComment, userRole);
                db.updateRegReq(loginIdFk, executer_surname, employee_name, employee_last_name, division_id_fk, position_id_fk);
            }
        }

        private void updateExecuterLoginDataTable()
        {
            loadDbServices db = new loadDbServices();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                int id = Convert.ToInt32(row.Cells["loginId"].Value);
                string login = Convert.ToString(row.Cells["login"].Value);
                string password = Convert.ToString(row.Cells["password"].Value);
                int loginApprove = Convert.ToInt32(row.Cells["loginApprove"].Value);
                string loginComment = Convert.ToString(row.Cells["loginComment"].Value);
                int userRole = Convert.ToInt32(row.Cells["userRole"].Value);

                int loginIdFk = Convert.ToInt32(row.Cells["loginIdFk"].Value);
                string executer_surname = Convert.ToString(row.Cells["executer_surname"].Value);
                string employee_name = Convert.ToString(row.Cells["employee_name"].Value);
                string employee_last_name = Convert.ToString(row.Cells["employee_last_name"].Value);
                int division_id_fk = Convert.ToInt32(row.Cells["division_id_fk"].Value);
                int position_id_fk = Convert.ToInt32(row.Cells["position_id_fk"].Value);

                db.updateRegLog(id, login, password, loginApprove, loginComment, userRole);
                db.updateRegReq(loginIdFk, executer_surname, employee_name, employee_last_name, division_id_fk, position_id_fk);
            }
        }
        private void updateLoginDataTable()
        {
            loadDbServices db = new loadDbServices();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                int id = Convert.ToInt32(row.Cells["loginId"].Value);
                string login = Convert.ToString(row.Cells["login"].Value);
                string password = Convert.ToString(row.Cells["password"].Value);
                int loginApprove = Convert.ToInt32(row.Cells["loginApprove"].Value);
                string loginComment = Convert.ToString(row.Cells["loginComment"].Value);
                int userRole = Convert.ToInt32(row.Cells["userRole"].Value);


                int loginIdFk = Convert.ToInt32(row.Cells["loginIdFk"].Value);
                string executer_surname = Convert.ToString(row.Cells["executer_surname"].Value);
                string employee_name = Convert.ToString(row.Cells["employee_name"].Value);
                string employee_last_name = Convert.ToString(row.Cells["employee_last_name"].Value);
                int division_id_fk = Convert.ToInt32(row.Cells["division_id_fk"].Value);
                int position_id_fk = Convert.ToInt32(row.Cells["position_id_fk"].Value);

                db.updateRegLog(id, login, password, loginApprove, loginComment, userRole);
                db.updateRegReq(loginIdFk, executer_surname, employee_name, employee_last_name, division_id_fk, position_id_fk);
            }
        }

        private void fillExecutionChangeByPosition()
        {
            if (divisionsComboBox.SelectedValue != null && positionsComboBox.SelectedValue != null)
            {
                string division_name = divisionsComboBox.SelectedValue.ToString();
                string position_name = positionsComboBox.SelectedValue.ToString();
                if (division_name == "Все отделы" && position_name == "Любая должность") { adapter = loadDbServices.loadAllExecuters(); }
                else if (division_name != "Все отделы" && position_name == "Любая должность") { adapter = loadDbServices.fillExecutionChangeByDivision(division_name); }
                else if (division_name != "Все отделы" && position_name != "Любая должность") { adapter = loadDbServices.fillExecutionChengeByPosition(division_name, position_name); }
                else if (division_name == "Все отделы" && position_name != "Любая должность") 
                {
                    adapter = loadDbServices.fillExecutionChengeOnlyByPosition(position_name); //загрузить всю таблицу поручений
                }

                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView3.DataSource = dt;
                dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void updateExecutionData()
        {
            int selectedId = (int)executionTypeComboBox.SelectedValue;

            switch (selectedId)
            {
                case 0: { fillExecutionsData(); break; }
                case 1: { dataCloseToDeadline(); break; }
                case 2: { checkDeadline(); break; }
                case 3: { dataCloseToDeadline(); break; }
                default: { updateExecutionData(); break; }
            }
        }

        private void dataGridView4_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var row = dataGridView4.Rows[e.RowIndex];
            var cell = row.Cells["deadline"];

            if (cell.Value != null && DateTime.TryParse(cell.Value.ToString(), out DateTime deadline))
            {
                if (deadline < DateTime.Now)
                {
                    row.DefaultCellStyle.BackColor = Color.Red; 
                }
                else if ((deadline - DateTime.Now).TotalDays <= 3)
                {
                    row.DefaultCellStyle.BackColor = Color.Khaki;
                }
                else row.DefaultCellStyle.BackColor = Color.Green;
            }
        }

        private void currentTasks()
        {
            adapter = loadDbServices.loadGoodExecutions(); //загрузить всю таблицу поручений
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView4.DataSource = dt;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataCloseToDeadline()
        {
            adapter = loadDbServices.loadCloseToDeadlineExecutions(); //загрузить всю таблицу поручений
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView4.DataSource = dt;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void checkDeadline()
        {
            adapter = loadDbServices.loadExistsTasksData(); //загрузить всю таблицу поручений
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView4.DataSource = dt;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void fillExecutionCombo()
        {
            List<execution_items> items = new List<execution_items>{
                new execution_items { Id = 0, Name = "Вывести данные о всех работниках и их задачах" },
                new execution_items { Id = 2, Name = "Вывести данные о просроченных задачах" },
                new execution_items { Id = 3, Name = "Вывести данные о задачах, чей дедлайн скоро наступит" }
            };

            executionTypeComboBox.DisplayMember = "Name";
            executionTypeComboBox.ValueMember = "Id";
            executionTypeComboBox.DataSource = items;
        }

        private void HideTabOrder()
        {
            hiddenTab.Add(tabControl1.TabPages["ordererPage"]);
            hiddenTab.Add(tabControl1.TabPages["tabPage4"]);

            for (int i = 0; i < hiddenTab.Count; i++)
            {
                tabControl1.TabPages.Remove(hiddenTab[i]);
            }
        }

        private void HideTabAdmin()
        {
            hiddenTab.Add(tabControl1.TabPages["accsApprovingPage"]);
            hiddenTab.Add(tabControl1.TabPages["redactDBPage"]);

            for (int i = 0; i < hiddenTab.Count; i++) {
                tabControl1.TabPages.Remove(hiddenTab[i]);
            }
        }

        private void hideExecutions()
        {
            hiddenTab.Add(tabControl1.TabPages["tabPage5"]);

            for (int i = 0; i < hiddenTab.Count; i++)
            {
                tabControl1.TabPages.Remove(hiddenTab[i]);
            }
        }

        private void ShowTabAdmin()
        {
            for (int i = 0; i <  hiddenTab.Count; i++) { 
                if (!tabControl1.TabPages.Contains(hiddenTab[i]))
                    tabControl1.TabPages.Add(hiddenTab[i]);
            }
        }

        private void loadExecuter()
        {
            adapter = loadDbServices.loadExecuter("0");
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView6.DataSource = dt;
            dataGridView6.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void fillExecutionsData()
        {
            adapter = loadDbServices.loadExecutionData(); //загрузить всю таблицу поручений
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView4.DataSource = dt;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void updateAllTables() //апдейт для админа
        {
            loadDbServices loadDbServices = new loadDbServices();

            DataTable table = (DataTable)dataGridView2.DataSource;
            loadDbServices.updateChoosenTable(tablesComboBox.SelectedItem.ToString(), table);

            MessageBox.Show("обновлено");
        }

        public DataTable DataGridViewToDataTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible && column.Name != null)
                    dt.Columns.Add(column.Name, column.ValueType ?? typeof(string));
            }

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dr = dt.NewRow();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.OwningColumn.Visible)
                        {
                            dr[cell.OwningColumn.Name] = cell.Value ?? DBNull.Value;
                        }
                    }
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        private void loadChoosenTable()
        {
            string selectedTable = tablesComboBox.SelectedItem?.ToString();

            loadDbServices loadDbServices = new loadDbServices();

            adapter = loadDbServices.loadSelectedTable(selectedTable);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void loadTables()
        {
            loadDbServices loadDbServices = new loadDbServices();
            tablesComboBox.Items.AddRange(loadDbServices.getTablesName());
        }

        private void loadAdmin()
        {
            adapter = loadDbServices.loadAdmin();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void loadExecuterInfo()
        {
            adapter = loadDbServices.loadAllExecuters();
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView3.DataSource = dt;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void loadExecutions()
        {
            adapter = loadDbServices.loadExecutions(this.executer_id);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView6.DataSource = dt;
            dataGridView6.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            LoadReferenceData();
            changeonBtn1();
            updateAdminLoginDataTable();
            
        }

        private void LoadReferenceData()
        {
            var db = new loadDbServices();
            divisionNameToId = db.GetDivisionNameToId();
            positionNameToId = db.GetPositionNameToId();
        }

        private void changeonBtn1()
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Выберите строку в таблице.");
                return;
            }

            string selectedField = comboBox1.SelectedItem?.ToString();
            string valueToInsert = textBox1.Text;

            if (string.IsNullOrEmpty(selectedField))
            {
                MessageBox.Show("Выберите поле из списка.");
                return;
            }

            var column = dataGridView1.Columns
                .Cast<DataGridViewColumn>()
                .FirstOrDefault(col => col.HeaderText == selectedField);

            if (column == null)
            {
                MessageBox.Show("Столбец не найден.");
                return;
            }

            int columnIndex = column.Index;

            string valueFromComboBox = comboBox2.SelectedItem?.ToString();
            string finalValue = string.IsNullOrEmpty(valueFromComboBox) ? valueToInsert : valueFromComboBox;

            try
            {
                object convertedValue;

                // 🔄 Преобразование имени в ID через справочник
                if ((selectedField == "division_id" || selectedField == "division_id_fk") && divisionNameToId.TryGetValue(finalValue, out int divId))
                {
                    convertedValue = divId;
                }
                else if ((selectedField == "position_id" || selectedField == "position_id_fk") && positionNameToId.TryGetValue(finalValue, out int posId))
                {
                    convertedValue = posId;
                }
                else if (column.ValueType == typeof(int))
                {
                    if (!int.TryParse(finalValue, out int intValue))
                        throw new FormatException("Ожидается целое число.");
                    convertedValue = intValue;
                }
                else if (column.ValueType == typeof(double))
                {
                    if (!double.TryParse(finalValue, out double doubleValue))
                        throw new FormatException("Ожидается число с плавающей точкой.");
                    convertedValue = doubleValue;
                }
                else if (column.ValueType == typeof(bool))
                {
                    if (!bool.TryParse(finalValue, out bool boolValue))
                        throw new FormatException("Ожидается логическое значение (true/false).");
                    convertedValue = boolValue;
                }
                else if (column.ValueType == typeof(DateTime))
                {
                    if (!DateTime.TryParse(finalValue, out DateTime dateValue))
                        throw new FormatException("Ожидается дата в корректном формате.");
                    convertedValue = dateValue;
                }
                else
                {
                    convertedValue = finalValue;
                }

                dataGridView1.CurrentRow.Cells[columnIndex].Value = convertedValue;
            }
            catch (FormatException fex)
            {
                MessageBox.Show($"Ошибка формата: {fex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при вставке значения: {ex.Message}");
            }
        }




        private void tablesComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            loadChoosenTable();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateAllTables();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fastQuerryForm fastQuerryForm = new fastQuerryForm(this);

            fastQuerryForm.Show();
        }

        public void fillTableByQuerry(string cmd)
        {
            try { 
            loadDbServices loadDbServices = new loadDbServices();

            
            adapter = loadDbServices.fillDataTableQuerry(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            } catch(Exception ex) { MessageBox.Show("Ошибка: " + ex); }
        }

        private int createNewExecution(string execution_name, string execution_content, DateTime execution_issue_date, DateTime deadline, int orderer_id_fk, int execution_status_id_fk)//создание нового поручения
        {
            int exexution_id_fk = loadDbServices.createNewExecution(execution_name, execution_content, execution_issue_date, deadline, orderer_id_fk, execution_status_id_fk);
            return exexution_id_fk;
        }

        private int createNewExecutionStatus(string execution_status, string execution_comment, DateTime change_date)
        {
            int execution_status_id_fk = loadDbServices.createNewExecutionStatus(execution_status, execution_comment, change_date);
            return execution_status_id_fk;
        }

        private void createNewExecutionForExecuter(int execution_id_fk, int executer_id_fk, int execution_status_id_fk) //+айдишник в конце таблицы
        {
            loadDbServices.createExecutionForExecuters(execution_id_fk, executer_id_fk, execution_status_id_fk);
        }



        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void executionTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateExecutionData();
        }


        private void button7_Click(object sender, EventArgs e) //новое поручение
        {
            {
                string execution_name = executionNameTextBox.Text;
                string execution_content = executionContentTextBox.Text;
                DateTime dateTime = DateTime.Now; // текущая дата
                DateTime deadline = dateTimePicker1.Value.Date;

                if (executionStatusComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Выберите статус поручения.");
                    return;
                }

                string execution_status = executionStatusComboBox.SelectedItem.ToString();
                string execution_comment = executionCommentTextBox.Text;

                if (string.IsNullOrWhiteSpace(execution_name) || string.IsNullOrWhiteSpace(execution_content))
                {
                    MessageBox.Show("Пожалуйста, заполните все обязательные поля.");
                    return;
                }

                if (dataGridView3.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите хотя бы одного исполнителя.");
                    return;
                }

                try
                {
                    // Создаем статус и само поручение один раз
                    int execution_status_id_fk = createNewExecutionStatus(execution_status, execution_comment, dateTime);
                    int execution_id_fk = createNewExecution(execution_name, execution_content, dateTime, deadline, orderer_id, execution_status_id_fk);

                    // Привязываем поручение ко всем выбранным исполнителям
                    foreach (DataGridViewRow row in dataGridView3.SelectedRows)
                    {
                        if (row.Cells["executer_id"]?.Value != null)
                        {
                            int executer_id = Convert.ToInt32(row.Cells["executer_id"].Value);
                            createNewExecutionForExecuter(execution_id_fk, executer_id, execution_status_id_fk);
                        }
                    }

                    //updateExecutionTable(); // Раскомментировать, если нужно

                    MessageBox.Show("Поручение создано для выбранных исполнителей.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при создании поручения: " + ex.Message);
                }
            }
        }

        private void divisionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillExecutionChangeByDivision();
        }

        private void positionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillExecutionChangeByPosition();
        }

        private void userPanel_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillAdminPanelData();
            LoadColumnHeadersToComboBox();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkAllExecutionsButton_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadColumnHeadersToComboBox()
        {
            comboBox1.Items.Clear(); // Очищаем предыдущие элементы

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                comboBox1.Items.Add(column.HeaderText); // Добавляем заголовок столбца
            }
        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedField = comboBox1.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedField))
                return;

            var items = loadDbServices.LoadIdNameListByColumn(selectedField);

            comboBox2.DataSource = null;
            comboBox2.DisplayMember = "Name";
            comboBox2.ValueMember = "Id";
            comboBox2.DataSource = items;
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedField = comboBox1.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedField))
                return;

            /*var values = loadDbServices.GetNamesByField(selectedField);

            comboBox2.DataSource = null;
            comboBox2.DataSource = values; */
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dataGridView6.Rows[e.RowIndex].Cells["id"].Value);
                MessageBox.Show($"Выбран ID: {id}");
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            string execution_name = executionNameTextBox.Text;
            string execution_content = executionContentTextBox.Text;
            DateTime dateTime = DateTime.Now; // текущая дата
            DateTime deadline = dateTimePicker1.Value.Date;
            dataGridView3.MultiSelect = true;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (executionStatusComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите статус поручения.");
                return;
            }

            string execution_status = executionStatusComboBox.SelectedItem.ToString();
            string execution_comment = executionCommentTextBox.Text;

            if (string.IsNullOrWhiteSpace(execution_name) || string.IsNullOrWhiteSpace(execution_content))
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные поля.");
                return;
            }

            if (dataGridView3.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы одного исполнителя.");
                return;
            }

            try
            {
                // Создаем статус и само поручение один раз
                int execution_status_id_fk = createNewExecutionStatus(execution_status, execution_comment, dateTime);
                int execution_id_fk = createNewExecution(execution_name, execution_content, dateTime, deadline, orderer_id, execution_status_id_fk);

                // Привязываем поручение ко всем выбранным исполнителям
                foreach (DataGridViewRow row in dataGridView3.SelectedRows)
                {
                    if (row.Cells["executer_id"]?.Value != null)
                    {
                        int executer_id = Convert.ToInt32(row.Cells["executer_id"].Value);
                        createNewExecutionForExecuter(execution_id_fk, executer_id, execution_status_id_fk);
                    }
                }

                //updateExecutionTable(); // Раскомментировать, если нужно

                MessageBox.Show("Поручение создано для выбранных исполнителей.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании поручения: " + ex.Message);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            ExportToExcel((int) numericUpDown1.Value);
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            loadOtchet();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExportExecutorsReportToWord((int)numericUpDown1.Value);
        }

        private void updateStatus(int id)
        {
            loadDbServices.updateExecutionStatus(id);
        }
        private void button6_Click_1(object sender, EventArgs e)
        {
            
                if (dataGridView6.CurrentRow != null)
                {
                    int executionId = Convert.ToInt32(dataGridView6.CurrentRow.Cells["execution_id"].Value);

                    updateStatus(executionId);
                    MessageBox.Show("Задача отправлена на проверку");
                }
        }
    }

    public class execution_items
    { 
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
public class IdNameItem
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString() => Name;
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Text;
using System.Security.Policy;
using System.Xml.Serialization;
using Word = Microsoft.Office.Interop.Word;

namespace kpCRM
{
    internal class registrationServices : loadDbServices
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public int userId;
        public int userRole;
        public Dictionary<string, int> divisionNameToId = new Dictionary<string, int>();
        public Dictionary<string, int> positionNameToId = new Dictionary<string, int>();
        public void checkConnection()
        {
            Console.WriteLine(connectionString);
        }
        public bool registration(string login, string password, string surname, string name, string lastname, string division_name, string position_name, string roleName)
        {
            //использование функций для проверки -> если проверка прошла -> создать запрос на регистрацию админу 
            //вроде сделал надо потом проверить
            string querry = "";

            if (roleName == "Администратор")
            {
                querry = "insert into admins (admin_surname, admin_name, admin_lastname, division_id, position_id, login_id_fk)" +
                    "values(@surname, @name, @lastname, @division_id_fk, @position_id_fk, @login_id_FK)";
            }
            else if (roleName == "Начальник")
            {
                querry = "insert into orderer (orderer_surname, orderer_name, orderer_lastname, division_id, position_id, loginIdFk)" +
                    "values(@surname, @name, @lastname, @division_id_fk, @position_id_fk, @login_id_FK)";
            }
            else if (roleName == "Рабочий")
            {
                querry = "insert into executer (executer_surname, executer_name, executer_last_name, division_id_fk, position_id_fk, loginIdFl)" +
                        "values(@surname, @name, @lastname, @division_id_fk, @position_id_fk, @login_id_FK)";
            }

            if (checkLogin(login) == true)
            {
                return false;
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    int loginIdFk = getlastUserId(login, password);

                    if (loginIdFk == -1) return false;
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(querry, connection);

                    cmd.Parameters.AddWithValue("surname", surname);
                    cmd.Parameters.AddWithValue("name", name);
                    cmd.Parameters.AddWithValue("lastname", lastname);
                    cmd.Parameters.AddWithValue("division_id_fk", getDivisionId(division_name));
                    cmd.Parameters.AddWithValue("position_id_fk", getPositionId(position_name));
                    cmd.Parameters.AddWithValue("login_id_FK", loginIdFk);

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
        }

        /* private int CreateNewOrderer(string orderer_surname, string orderer_name, string orderer_lastname, string division_name, string position_name)
         {
             string querry = "insert into orderer (orderer_surname, orderer_name, orderer_last_name)"
         }*/

        public int getDivisionId(string division)
        {
            string query = @"select division_id from divisions where division_name = @division";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@division", division);

                try
                {
                    connection.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int divisionId))
                        return divisionId;
                    else
                        return -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при получении division_id: " + ex.Message);
                    return -1;
                }
            }
        }


        public int getPositionId(string position)
        {
            string query = @"select position_id from positions where position_name = @position";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@position", position);

                try
                {
                    connection.Open();
                    object result = cmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int positionId))
                        return positionId;
                    else
                        return -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при получении division_id: " + ex.Message);
                    return -1;
                }
            }
        }

        public int getlastUserId(string login, string password)
        {
            string query = @"
                insert into loginEmployees (login, password) values (@login, @password);
                SELECT SCOPE_IDENTITY();
            ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);

                try
                {
                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    int newLoginId = Convert.ToInt32(result);

                    MessageBox.Show($"Добавлен пользователь с ID: {newLoginId}");
                    return newLoginId;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                    return -1;
                }
            }
        }

        public bool checkLogin(string login)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("If exists (select 1 from loginEmployees where login = @login) select 1 else select 0", connection);
                cmd.Parameters.AddWithValue("@login", login);
                int exists = (int)cmd.ExecuteScalar();
                if (exists > 0) { return true; }
            }
            return false;
        }

        public bool checkPassword(string password)
        {
            //Запрос к бд -> Если нет совпадений -> return true
            return false;
        }
    }

    internal class dataReading : loadDbServices
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public List<string> GetDivisions()
        {
            List<string> divisions = new List<string>();
            string query = "SELECT division_name FROM divisions";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        divisions.Add(reader["division_name"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
                }
            }

            return divisions;
        }

        public List<string> getPositions()
        {
            List<string> divisions = new List<string>();
            string query = "SELECT position_name FROM positions";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        divisions.Add(reader["position_name"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
                }
            }

            return divisions;
        }

    }

    internal class loginServices : loadDbServices
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public static void allowToLog(string login, string password)
        {

        }

        public bool isApproved(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("if exists(select 1 from loginEmployees where loginApprove = 0 and login = @login) select 1 else select 0", connection);
                cmd.Parameters.AddWithValue("@login", login);
                int exists = (int)cmd.ExecuteScalar();

                if (exists == 1) return false; //переделать на коды (401 - нет подтверждения от админа)

                cmd = new SqlCommand("if exists(select 1 from loginEmployees where login = @login and password = @password) select 1 else select 0", connection);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                exists = (int)cmd.ExecuteScalar();

                if (exists == 0) return false; // (402 - не сходятся пароль и логин) и т.д.


            }
            return true;
        }
        public static bool checkLogin(string login)
        {
            return false;
        }

        public static bool checkPussword(string password)
        {
            return false;
        }

    }

    internal class loadDbServices
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private SqlDataAdapter adapter;
        public void loadUserInfo()
        {

        }

        public SqlDataAdapter loadExecutionForExecuterData(int executer_id) //загрузить информацию о всех задачах конкретного исполнителя
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"
                SELECT 
                    e.execution_id, 
                    e.execution_name, 
                    e.execution_content, 
                    e.execution_issue_date, 
                    e.deadline
                FROM 
                    execution e
                JOIN 
                    execution_for_executers efe 
                    ON e.execution_id = efe.execution_id_fk
                WHERE 
                    efe.executer_id_fk = @executer_id
            ";


            adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@executer_id", executer_id);
            return adapter;
        }

        public SqlDataAdapter loadExecuter(string executer_id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT executer_surname, executer_name, executer_last_name, execution_name, execution_content, deadline, execution_issue_date FROM executer " +
                "JOIN execution on execution.execution_id = executer.execution_id_fk where executer_id = @id";

            adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@id", executer_id);
            return adapter;
        }

        public SqlDataAdapter loadAllExecuters()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select executer.executer_id, executer.executer_surname, executer.executer_last_name, " +
                "divisions.division_name, positions.position_name from executer " +
                "join divisions on division_id = division_id_fk " +
                "join positions on position_id = position_id_fk";

            adapter = new SqlDataAdapter(query, connection);
            return adapter;
        }


        public DataTable fillDivisionsCombo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "select division_name from divisions";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }
        }

        public DataTable fillPositionsCombo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "select position_name from positions";

                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }
        }

        public string[] getTablesName()
        {
            List<string> tables = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Получаем список пользовательских таблиц (без представлений и системных)
                SqlCommand cmd = new SqlCommand(@"
                        SELECT TABLE_NAME 
                        FROM INFORMATION_SCHEMA.TABLES 
                        WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'dbo'
                        ORDER BY TABLE_NAME", connection
                    );

                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        string tableName = reader.GetString(0);
                        tables.Add(tableName);
                    }
                }
            }
            return tables.ToArray();
        }

        public SqlDataAdapter loadOtchet(int maxOverdueTasks = -1)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"
        -- Получаем ID статуса 'Выполнена'
        DECLARE @CompletedStatusId INT;
        SELECT @CompletedStatusId = execution_status_id 
        FROM [ordersExecutions].[dbo].[execution_status] 
        WHERE execution_status = 'Выполнена';
        
        -- Если статус 'Выполнена' не найден, используем 0 (не будет совпадений)
        IF @CompletedStatusId IS NULL SET @CompletedStatusId = 0;
        
        SELECT 
            e.executer_id AS [ID исполнителя],
            e.executer_surname AS [Фамилия],
            e.executer_name AS [Имя],
            e.executer_last_name AS [Отчество],
            COUNT(ex.execution_id) AS [Всего задач],
            SUM(CASE WHEN ex.deadline < GETDATE() AND 
                (ex.executiom_status_id_fk != @CompletedStatusId OR ex.executiom_status_id_fk IS NULL) 
                THEN 1 ELSE 0 END) AS [Просроченные задачи],
            SUM(CASE WHEN ex.deadline >= GETDATE() OR 
                ex.executiom_status_id_fk = @CompletedStatusId 
                THEN 1 ELSE 0 END) AS [Задачи в срок],
            CAST(SUM(CASE WHEN ex.deadline >= GETDATE() OR 
                ex.executiom_status_id_fk = @CompletedStatusId 
                THEN 1 ELSE 0 END) AS FLOAT) / NULLIF(COUNT(ex.execution_id), 0) * 100 AS [Процент выполнения в срок]
        FROM 
            [ordersExecutions].[dbo].[executer] e
        LEFT JOIN 
            [ordersExecutions].[dbo].[execution_for_executers] efe ON e.executer_id = efe.executer_id_fk
        LEFT JOIN 
            [ordersExecutions].[dbo].[execution] ex ON efe.execution_id_fk = ex.execution_id
        GROUP BY 
            e.executer_id,
            e.executer_surname,
            e.executer_name,
            e.executer_last_name
        HAVING 
            COUNT(ex.execution_id) > 0";

            // Добавляем фильтр по просроченным задачам если нужно
            if (maxOverdueTasks >= 0)
            {
                query += @"
            AND SUM(CASE WHEN ex.deadline < GETDATE() AND 
                (ex.executiom_status_id_fk != @CompletedStatusId OR ex.executiom_status_id_fk IS NULL) 
                THEN 1 ELSE 0 END) <= " + maxOverdueTasks;
            }

            query += @"
        ORDER BY 
            [Просроченные задачи] DESC, [Всего задач] DESC;";

            connection.Open();
            adapter = new SqlDataAdapter(query, connection);
            return adapter;
        }

        public void updateRegLog(int id, string login, string password, int loginApprove, string loginComment, int userRole)
        {
            string command = "update loginEmployees set login = @login, password = @password, loginApprove = @loginApprove," +
                " loginComment = @loginComment, userRole = @userRole where loginId = @id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(command, connection);
                cmd.Parameters.AddWithValue("@login", login);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@loginApprove", loginApprove);
                cmd.Parameters.AddWithValue("@loginComment", loginComment);
                cmd.Parameters.AddWithValue("@userRole", userRole);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public int getUserRole(string login)
        {
            string command = "select userRole from loginEmployees where login = @login";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(command, connection);
                cmd.Parameters.AddWithValue("@login", login);
                int userRole = (int)cmd.ExecuteScalar();
                connection.Close();

                return userRole;
            }
        }

        public int getUserId(string login, int userRole)
        {
            string command = "";
            switch (userRole)
            {
                case 0:
                    command = "select executer_id from executer join loginEmployees on loginEmployees.loginId = executer.loginIdFl where loginEmployees.login = @login";
                    break;
                case 1:
                    command = "select orderer_id from orderer join loginEmployees on loginEmployees.loginId = orderer.loginIdFk where loginEmployees.login = @login";
                    break;
                case 2: 
                    command = "select admin_id from admins join loginEmployees on loginEmployees.loginId = admins.login_id_fk where loginEmployees.login = @login";
                    break;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(command, connection);
                cmd.Parameters.AddWithValue("@login", login);
                int userId = (int)cmd.ExecuteScalar();
                connection.Close();

                return userId;
            }
        }

        public void updateRegReq(int loginIdFk, string executer_surname, string employee_name, string employee_last_name, int division_id_fk, int position_id_fk) //апдейт данных рега админа
        {
            string command = "update admins set admin_id = @loginIdFk, admin_surname = @executer_surname, " +
                "admin_name = @employee_name, admin_lastname = @employee_last_name, division_id_fk = @division_id_fk, position_id_fk = position_id_fk, login_id_fk = @login_id_fk where adminId = @loginIdFk";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(command, connection);
                cmd.Parameters.AddWithValue("@loginIdFk", loginIdFk);
                cmd.Parameters.AddWithValue("@executer_surname", executer_surname);
                cmd.Parameters.AddWithValue("@employee_name", employee_name);
                cmd.Parameters.AddWithValue("@employee_last_name", employee_last_name);
                cmd.Parameters.AddWithValue("@division_id_fk", division_id_fk);
                cmd.Parameters.AddWithValue("@position_id_fk", position_id_fk);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void updateRegReq(int loginIdFk, string executer_surname, string employee_name, string employee_last_name, int division_id_fk, int position_id_fk, int login_id_fk) //апдейт данных рега админа
        {
            string command = "update admins set admin_surname = @executer_surname, " +
                "admin_name = @employee_name, admin_lastname = @employee_last_name, division_id = @division_id_fk, position_id = @position_id_fk, login_id_fk = @login_id_fk where admin_id = @loginIdFk";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(command, connection);
                cmd.Parameters.AddWithValue("@admin_id", loginIdFk);
                cmd.Parameters.AddWithValue("@executer_surname", executer_surname);
                cmd.Parameters.AddWithValue("@employee_name", employee_name);
                cmd.Parameters.AddWithValue("@employee_last_name", employee_last_name);
                cmd.Parameters.AddWithValue("@division_id_fk", division_id_fk);
                cmd.Parameters.AddWithValue("@position_id_fk", position_id_fk);
                cmd.Parameters.AddWithValue("@login_id_fk", login_id_fk);
                cmd.Parameters.AddWithValue("@loginIdFk", loginIdFk);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<string> GetNamesByField(string fieldName)
        {
            List<string> names = new List<string>();
            string query = "";

            if (fieldName == "position_id")
                query = "SELECT position_name FROM positions";
            else if (fieldName == "division_id")
                query = "SELECT division_name FROM divisions";
            else
                return names; // Пустой список, если поле не подходит

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        names.Add(reader[0].ToString());
                    }
                }
            }

            return names;
        }


        public void updateRegReq(int loginIdFk, string executer_surname, string employee_name, string employee_last_name, int division_id_fk, int position_id_fk, int login_id_fk, int value) //апдейт данных рега начальника
        {
            string command = "update orderer set orderer_surname = @executer_surname, " +
                "orderer_name = @employee_name, orderer_lastname = @employee_last_name, division_id = @division_id_fk, position_id = @position_id_fk, loginIdFk = @login_id_fk where orderer_id = @orderer_id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(command, connection);
                cmd.Parameters.AddWithValue("@orderer_id", loginIdFk);
                cmd.Parameters.AddWithValue("@executer_surname", executer_surname);
                cmd.Parameters.AddWithValue("@employee_name", employee_name);
                cmd.Parameters.AddWithValue("@employee_last_name", employee_last_name);
                cmd.Parameters.AddWithValue("@division_id_fk", division_id_fk);
                cmd.Parameters.AddWithValue("@position_id_fk", position_id_fk);
                cmd.Parameters.AddWithValue("@login_id_fk", login_id_fk);

                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void updateRegReq(int loginIdFk, string executer_surname, string employee_name, string employee_last_name, int division_id_fk, int position_id_fk, int execution_status_id_fk, int execution_id_fk, int login_id_fk) //апдейт данных рега работника
        {
            string command = @"UPDATE executer 
                       SET executer_surname = @executer_surname,
                           executer_name = @employee_name,
                           executer_last_name = @employee_last_name,
                           division_id_fk = @division_id_fk,
                           position_id_fk = @position_id_fk,
                           execution_status_id_fk = @execution_status_id_fk,
                           execution_id_fk = @execution_id_fk,
                           loginIdFl = @login_id_fk
                       WHERE executer_id = @executer_id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(command, connection);
                cmd.Parameters.AddWithValue("@executer_id", loginIdFk);

                cmd.Parameters.AddWithValue("@executer_surname", executer_surname);
                cmd.Parameters.AddWithValue("@employee_name", employee_name);
                cmd.Parameters.AddWithValue("@employee_last_name", employee_last_name);
                cmd.Parameters.AddWithValue("@division_id_fk", division_id_fk);
                cmd.Parameters.AddWithValue("@position_id_fk", position_id_fk);
                cmd.Parameters.AddWithValue("@execution_status_id_fk", execution_status_id_fk);
                cmd.Parameters.AddWithValue("@execution_id_fk", execution_id_fk);
                cmd.Parameters.AddWithValue("@login_id_fk", login_id_fk);

                cmd.ExecuteNonQuery();
            }
        }

        public void updateChoosenTable(string tableName, DataTable table)
        {
            try
            {
                string cmd = $"select * from [{tableName}]";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd, connection);
                    SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                    adapter.Update(table);
                }
            }
            catch
            {
                //не придумал но пофиксил 
            }
        }

        public SqlDataAdapter loadSelectedTable(string tableName)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"SELECT * FROM [{tableName}]";
            connection.Open();

            adapter = new SqlDataAdapter(query, connection);
            return adapter;
        }


        public SqlDataAdapter loadAdmin()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from loginEmployees join registration_requests on loginEmployees.loginId = registration_requests.loginIdFk ";

            adapter = new SqlDataAdapter(query, connection);
            return adapter;
        }

        public SqlDataAdapter loadAdminsLogin()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from loginEmployees join admins on admins.login_id_fk = loginEmployees.loginId";

            adapter = new SqlDataAdapter(query, connection);
            return adapter;
        }

        public SqlDataAdapter loadordererLogin()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from loginEmployees join orderer on orderer.loginIdFk = loginEmployees.loginId";

            adapter = new SqlDataAdapter(query, connection);

            return adapter;
        }

        public SqlDataAdapter loadExecuterLogin()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from loginEmployees join executer on executer.[loginIdFl] = loginEmployees.loginId";

            adapter = new SqlDataAdapter(query, connection);
            return adapter;
        }


        public SqlDataAdapter loadOrderer()
        {
            SqlDataAdapter executerAdapter = new SqlDataAdapter();

            return executerAdapter;
        }

        public SqlDataAdapter fillDataTableQuerry(string cmd)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter(cmd, connection);
            return adapter;
        }

        public void updateDBQuerry(string cmd)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(cmd, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public SqlDataAdapter fillExecutionChangeByDivision(string division_name)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT executer.executer_id, executer.executer_surname, executer.executer_last_name, " +
                           "divisions.division_name, positions.position_name FROM executer " +
                           "JOIN divisions ON division_id = division_id_fk " +
                           "JOIN positions ON position_id = position_id_fk " +
                           "WHERE division_name = @divisionName";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@divisionName", division_name);
            return adapter;
        }

        public SqlDataAdapter fillExecutionChengeByPosition(string division_name, string position_name)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT executer.executer_id, executer.executer_surname, executer.executer_last_name, " +
                           "divisions.division_name, positions.position_name FROM executer " +
                           "JOIN divisions ON division_id = division_id_fk " +
                           "JOIN positions ON position_id = position_id_fk " +
                           "WHERE division_name = @division_name and position_name = @position_name";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@division_name", division_name);
            adapter.SelectCommand.Parameters.AddWithValue("@position_name", position_name);
            return adapter;
        }

        public SqlDataAdapter fillExecutionChengeOnlyByPosition(string position_name)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT executer.executer_id, executer.executer_surname, executer.executer_last_name, " +
                           "divisions.division_name, positions.position_name FROM executer " +
                           "JOIN divisions ON division_id = division_id_fk " +
                           "JOIN positions ON position_id = position_id_fk " +
                           "WHERE positions.position_name = @position_name";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@position_name", position_name);
            return adapter;
        }


        public SqlDataAdapter loadExecutionData() //combobox1
        {
            string cmd = "SELECT executer.executer_id, " +
                " executer.executer_surname,executer.executer_name, " +
                "executer.executer_last_name, " +
                "divisions.division_name,  " +
                "positions.position_name,  " +
                "execution.execution_name, " +
                " execution.execution_content," +
                " execution.execution_issue_date, " +
                "execution.deadline, " +
                "execution_status.execution_status, " +
                "execution_status.execution_comment " +
                "FROM executer " +
                " JOIN divisions ON executer.division_id_fk = divisions.division_id " +
                "JOIN positions ON executer.position_id_fk = positions.position_id " +
                "JOIN execution_for_executers ON executer.executer_id = execution_for_executers.executer_id_fk" +
                " JOIN execution ON execution.execution_id = execution_for_executers.execution_id_fk " +
                " JOIN execution_status ON execution_status.execution_status_id = execution_for_executers.executiom_status_id_fk "; //фио подразделение должность название задачи начало дедлайн статус ченж
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            adapter = new SqlDataAdapter(cmd, connection);

            return adapter;
        }

        public SqlDataAdapter loadExistsTasksData() //инфа просроченных задач
        {
            string cmd = "SELECT executer.executer_id, " +
                " executer.executer_surname,executer.executer_name, " +
                "executer.executer_last_name, " +
                "divisions.division_name,  " +
                "positions.position_name,  " +
                "execution.execution_name, " +
                " execution.execution_content," +
                " execution.execution_issue_date, " +
                "execution.deadline, " +
                "execution_status.execution_status, " +
                "execution_status.execution_comment " +
                "FROM executer " +
                " JOIN divisions ON executer.division_id_fk = divisions.division_id " +
                "JOIN positions ON executer.position_id_fk = positions.position_id " +
                "JOIN execution_for_executers ON executer.executer_id = execution_for_executers.executer_id_fk" +
                " JOIN execution ON execution.execution_id = execution_for_executers.execution_id_fk " +
                " JOIN execution_status ON execution_status.execution_status_id = execution_for_executers.executiom_status_id_fk " +
                "WHERE CAST(deadline AS DATE) < CAST(GETDATE() AS DATE) ";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            adapter = new SqlDataAdapter(cmd, connection);

            return adapter;
        }

        public SqlDataAdapter loadCloseToDeadlineExecutions() //10 дней до просрочки
        {
            string cmd = "SELECT executer.executer_id, " +
                " executer.executer_surname,executer.executer_name, " +
                "executer.executer_last_name, " +
                "divisions.division_name,  " +
                "positions.position_name,  " +
                "execution.execution_name, " +
                " execution.execution_content," +
                " execution.execution_issue_date, " +
                "execution.deadline, " +
                "execution_status.execution_status, " +
                "execution_status.execution_comment " +
                "FROM executer " +
                " JOIN divisions ON executer.division_id_fk = divisions.division_id " +
                "JOIN positions ON executer.position_id_fk = positions.position_id " +
                "JOIN execution_for_executers ON executer.executer_id = execution_for_executers.executer_id_fk" +
                " JOIN execution ON execution.execution_id = execution_for_executers.execution_id_fk " +
                " JOIN execution_status ON execution_status.execution_status_id = execution_for_executers.executiom_status_id_fk " +
                "WHERE CAST(deadline AS DATE) BETWEEN CAST(GETDATE() AS DATE) AND CAST(DATEADD(DAY, 10, GETDATE()) AS DATE);";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            adapter = new SqlDataAdapter(cmd, connection);

            return adapter;
        }

        public SqlDataAdapter loadGoodExecutions() //инфа о не просроченных тасках
        {
            string cmd = "SELECT executer.executer_id, " +
                " executer.executer_surname,executer.executer_name, " +
                "executer.executer_last_name, " +
                "divisions.division_name,  " +
                "positions.position_name,  " +
                "execution.execution_name, " +
                " execution.execution_content," +
                " execution.execution_issue_date, " +
                "execution.deadline, " +
                "execution_status.execution_status, " +
                "execution_status.execution_comment " +
                "FROM executer " +
                " JOIN divisions ON executer.division_id_fk = divisions.division_id " +
                "JOIN positions ON executer.position_id_fk = positions.position_id " +
                "JOIN execution_for_executers ON executer.executer_id = execution_for_executers.executer_id_fk" +
                " JOIN execution ON execution.execution_id = execution_for_executers.execution_id_fk " +
                " JOIN execution_status ON execution_status.execution_status_id = execution_for_executers.executiom_status_id_fk " +
                "WHERE CAST(deadline AS DATE) >= CAST(GETDATE() AS DATE) ";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            adapter = new SqlDataAdapter(cmd, connection);

            return adapter;
        }

        public int createNewExecutionStatus(string execution_status, string execution_comment, DateTime change_Date)
        {
            string query = @"
                insert into execution_status (execution_status, execution_comment, change_Date) values (@execution_status, @execution_comment, @change_Date);
                SELECT SCOPE_IDENTITY();
            ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@execution_status", execution_status);
                cmd.Parameters.AddWithValue("@execution_comment", execution_comment);
                cmd.Parameters.AddWithValue("@change_Date", change_Date);

                try
                {
                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    int newId = Convert.ToInt32(result);
                    return newId;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                    return -1;
                }
            }
        }

        

        public int createNewExecution(string execution_name, string execution_content, DateTime dateNow, DateTime deadline, int orderer_id_fk, int execution_status_id_fk)
        {
            string query = @"
                INSERT INTO execution (execution_name, execution_content, execution_issue_date, deadline, orderer_id_fk, executiom_status_id_fk)
                VALUES (@execution_name, @execution_content, @dateNow, @deadline, @orderer_id_fk, @execution_status_id_fk);
                SELECT SCOPE_IDENTITY();
            ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@execution_name", execution_name);
                cmd.Parameters.AddWithValue("@execution_content", execution_content);
                cmd.Parameters.AddWithValue("@dateNow", dateNow);
                cmd.Parameters.AddWithValue("@deadline", deadline);
                cmd.Parameters.AddWithValue("@orderer_id_fk", orderer_id_fk);
                cmd.Parameters.AddWithValue("@execution_status_id_fk", execution_status_id_fk);

                try
                {
                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                    return -1;
                }
            }
        }


        public void createExecutionForExecuters(int execution_id_fk, int executer_id_fk, int execution_status_id_fk)
        {
            string query = @"
                INSERT INTO execution_for_executers (execution_id_fk, executer_id_fk, executiom_status_id_fk)
                VALUES (@execution_id_fk, @executer_id_fk, @execution_status_id_fk);
            ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@execution_id_fk", execution_id_fk);
                cmd.Parameters.AddWithValue("@executer_id_fk", executer_id_fk);
                cmd.Parameters.AddWithValue("@execution_status_id_fk", execution_status_id_fk);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                   MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }


        public SqlDataAdapter updateExecutionTable()
        {

            return adapter;
        }

        public SqlDataAdapter loadExecutionsStatus()
        {
            string cmd = "";

            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            adapter = new SqlDataAdapter(cmd, connection);

            return adapter;
        }

        public List<IdNameItem> LoadIdNameListByColumn(string fieldName)
        {
            List<IdNameItem> result = new List<IdNameItem>();
            string query = "";
            string idField = "";
            string nameField = "";

            if (fieldName.Contains("position_id"))
            {
                query = "SELECT position_id, position_name FROM positions";
                idField = "position_id";
                nameField = "position_name";
            }
            else if (fieldName.Contains("division_id"))
            {
                query = "SELECT division_id, division_name FROM divisions";
                idField = "division_id";
                nameField = "division_name";
            }
            else
            {
                return result; // неподдерживаемое поле
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new IdNameItem
                    {
                        Id = Convert.ToInt32(reader[idField]),
                        Name = reader[nameField].ToString()
                    });
                }
            }

            return result;
        }

        public Dictionary<string, int> GetDivisionNameToId()
        {
            var dict = new Dictionary<string, int>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT division_id, division_name FROM divisions", conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        dict[name] = id;
                    }
                }
            }

            return dict;
        }

        public Dictionary<string, int> GetPositionNameToId()
        {
            var dict = new Dictionary<string, int>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT position_id, position_name FROM positions", conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        dict[name] = id;
                    }
                }
            }

            return dict;
        }

        public SqlDataAdapter loadExecutions(int executerId)
        {
            string cmd = "use ordersExecutions " +
                "select execution_id, execution_name, execution_content, execution_issue_date, deadline, orderer_surname, orderer_name, orderer_lastname " +
                "from execution join execution_for_executers on execution.execution_id = execution_for_executers.execution_id_fk " +
                "join orderer on orderer.orderer_id = execution.orderer_id_fk where executer_id_fk = @executerId";

            SqlConnection connection = new SqlConnection(connectionString);
            
            connection.Open();
            adapter = new SqlDataAdapter(cmd, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@executerId", executerId);

            return adapter;
        }

        public void updateExecutionStatus(int execution_id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(@"
                UPDATE execution_status
                SET execution_status = @newStatus
                WHERE execution_status_id = (
                    SELECT executiom_status_id_fk
                    FROM execution
                    WHERE execution_id = @id
                )", connection); cmd.Parameters.AddWithValue("@newStatus", "отправлено на проверку");
            cmd.Parameters.AddWithValue("@id", execution_id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}



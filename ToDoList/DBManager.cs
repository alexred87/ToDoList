using System.Data.SQLite;
using System.Data;
using System.IO;

namespace ToDoList
{
    //Класс для работы с базой данных
    static class DBManager
    {
        private static string connectionString = @"Data Source=Tasks.db; Version = 3;";

        private static DataTable table = new DataTable("tasks");

        public static void InitializeDatabase()
        {
            if (!File.Exists(@"Tasks.db"))
            {
                SQLiteConnection.CreateFile("Tasks.db");

                string createTasksTableQuery = @"                    
                        CREATE TABLE IF NOT EXISTS tasks (
                            id INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE,
                            date TEXT NOT NULL,
                            task TEXT NOT NULL,
                            commentary TEXT,
                            remind_time INTEGER NOT NULL,
                            status TEXT NOT NULL
                    );";

                ExecuteCommand(createTasksTableQuery);
            }
        }

        public static void AddTask(string dateTime, string task, int remindTime, string commentary, string status)
        {
            string addTaskQuery = "INSERT INTO tasks (date, task, commentary, remind_time, status) VALUES" +
                                    $"('{dateTime}', '{task}', '{commentary}', {remindTime},'{status}');";

            ExecuteCommand(addTaskQuery);
        }

        public static void ChangeTaskStatus(int id, string status)
        {
            string editTaskQuery = $"UPDATE tasks SET status ='{status}'"
                                    + $" WHERE id = {id}";

            ExecuteCommand(editTaskQuery);
        }

        public static void ChangeRemindtime(int id, int time)
        {
            string editTaskQuery = $"UPDATE tasks SET remind_time ={time}"
                                    + $" WHERE id = {id}";

            ExecuteCommand(editTaskQuery);
        }

        public static void EditTask(int id, string date, string task, string commentary, int min, string status)
        {
            string editTaskQuery = $"UPDATE tasks SET date = '{date}', task = '{task}',"
                                    + $"commentary = '{commentary}', remind_time = {min}, status = '{status}'"
                                    + $" WHERE id = {id}";

            ExecuteCommand(editTaskQuery);
        }

        public static void DeleteTask(int id)
        {
            string deleteTaskQuery = $"DELETE FROM tasks WHERE id = '{id}'";

            ExecuteCommand(deleteTaskQuery);
        }

        private static void ExecuteCommand(string query)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(query, connection);

                command.ExecuteNonQuery();
            }
        }

        public static DataTable GetData()
        {
            string query = @"SELECT id as ID, date as 'Дата и время', task as Задание, commentary as Комментарий,
                           remind_time as 'Напомнить за (минут)', '' as [Осталось времени], status as Статус FROM tasks";

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                SQLiteDataAdapter qLiteDataAdapter = new SQLiteDataAdapter(query, connection);

                table.Clear();

                qLiteDataAdapter.Fill(table);

                return table;
            }
        }
    }
}
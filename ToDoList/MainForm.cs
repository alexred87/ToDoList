using System;
using System.Windows.Forms;


namespace ToDoList
{
    //Класс для отображения списка всех заданий
    public partial class MainForm : Form
    {
        private TaskForm taskForm;

        private bool editMode;

        //показываает впервые ли загружены данные в DataGridView
        private bool firstUploadData; 

        public MainForm()
        {
            InitializeComponent();

            var data = DBManager.GetData();
            if (data == null)
            {
                MessageBox.Show($"Ошибка загрузки данных. Возможно повреждена база данных", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            dataGrid.DataSource = data;
            firstUploadData = true;

            //скрывается столбец с первичным ключом
            dataGrid.Columns["ID"].Visible = false;
            taskForm = new TaskForm();

            //подписка на событие сбора данных класса ФормаЗадания
            taskForm.DataCollected += MakeTask;

            timer.Start();
        }

        //метод собирает данные из Формы задания и в зависимости включен ли режим редактирования,
        //редактирует задание или создает новое
        private void MakeTask(string date, string task, string comment, int remindTime)
        {
            //если включен режим редактирования, редактируем выделенное задание
            if (editMode && dataGrid.SelectedRows.Count > 0)
            {
                var currentRow = dataGrid.SelectedRows[0];

                int id = GetID(currentRow);

                if (currentRow.Cells["Статус"].Value.ToString() == "Неактивно")
                    currentRow.Cells["Статус"].Value = "Активно";

                string status = currentRow.Cells["Статус"].Value.ToString();

                DBManager.EditTask(id, date, task, comment, remindTime, status);
                editMode = false;
            }

            //если режим редактирования выключен, то создаем новое задание
            else
            {
                DBManager.AddTask(date, task, remindTime, comment, "Активно");
            }

            //обновляем DataGridView
            dataGrid.DataSource = DBManager.GetData();
        }

        private void Add_btn_Click(object sender, EventArgs e)
        {
            editMode = false;

            taskForm.ShowDialog();
        }

        //заполение данными уже созданного задания Формы задания для редактирования задания
        private void FillTaskForm()
        {
            if (dataGrid.SelectedRows.Count > 0)
            {
                taskForm.DateTimePeeker.Value = DateTime.Parse(dataGrid.SelectedRows[0].Cells["Дата и время"].Value.ToString());
                taskForm.TaskDescription.Text = dataGrid.SelectedRows[0].Cells["Задание"].Value.ToString();

                taskForm.Commentary_rtb.AppendText(dataGrid.SelectedRows[0].Cells["Комментарий"].Value.ToString());
                taskForm.RemindMins.Value = decimal.Parse(dataGrid.SelectedRows[0].Cells["Напомнить за (минут)"].Value.ToString());

                editMode = true;
                taskForm.ShowDialog();
            }
        }

        private void EditTask_conMenu_Click(object sender, EventArgs e)
        {
            FillTaskForm();
        }

        private void RmvTask_conMenu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить задание?", "Удаление задания", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (dataGrid.SelectedRows.Count > 0 && result == DialogResult.OK)
            {
                int id = GetID(dataGrid.SelectedRows[0]);

                DBManager.DeleteTask(id);

                dataGrid.DataSource = DBManager.GetData();
            }  
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateDataGrid();
        }


        //метод для высчитывания времени до конца задания и выдачи напоминаний
        private void UpdateDataGrid()
        {
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                //создание переменных для удобства работы
                DataGridViewRow currentRow = dataGrid.Rows[i];

                int remindBeforeMinutes = int.Parse(currentRow.Cells["Напомнить за (минут)"].Value.ToString());

                DateTime taskTime = DateTime.Parse(currentRow.Cells["Дата и время"].Value.ToString());

                string task = currentRow.Cells["Задание"].Value.ToString();

                string comment = currentRow.Cells["Комментарий"].Value.ToString();


                //высчитывает разницу времени задания, указаного пользователем и времени в данный момент
                TimeSpan diff = taskTime.Subtract(DateTime.Now);

                //время, указанное пользователем для напоминания о задании в формате TimeSpan
                TimeSpan notifierTime = new TimeSpan(0, 0,remindBeforeMinutes,0, 0);

                //если заданию присвоен статус "Неактивно", с ним больше не работаем
                if (currentRow.Cells["Статус"].Value.ToString() == "Неактивно")
                    continue;

                //если время для задания вышло, меняем его статус на "Неактивно"
                //и выводим уведомление 
                if (diff <= TimeSpan.Zero)
                {
                    ChangeTaskStatus(currentRow);

                    //проверка загружены ли данные в момент запуска программы.
                    //Если задание стало неактивно до запуска программы, то им присваевается
                    //статус "Неактивно", а уведомление не выводится.
                    if (firstUploadData)
                    {
                        firstUploadData = false;
                        continue;
                    }

                    MessageBox.Show($"{task}. {comment}", "Напоминание", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    continue;
                }

                //подсчет времени, когда нужно напомнить пользователю о задании
                if (TimeSpan.Compare(diff, notifierTime) == -1 && remindBeforeMinutes != 0)
                {
                    ChangeRemindTime(currentRow);
                    MessageBox.Show($"До начала задания {task} осталось меньше {remindBeforeMinutes} минут",
                                "Напоминание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    continue;
                }

                //
                currentRow.Cells["Осталось времени"].Value = diff.ToString( @"dd\.hh\:mm\:ss");
            }
        }

        private void ChangeTaskStatus(DataGridViewRow currentRow)
        {
            int id = GetID(currentRow);

            DBManager.ChangeTaskStatus(id,"Неактивно");

            dataGrid.DataSource = DBManager.GetData();
        }

        //меняем значение "Напомнить до" на ноль, если уже появлялось уведомление
        private void ChangeRemindTime(DataGridViewRow row)
        {
            int id = GetID(row);
   
            DBManager.ChangeRemindtime(id, 0);

            dataGrid.DataSource = DBManager.GetData();
        }

        private int GetID(DataGridViewRow row)
        { 
            return int.Parse(row.Cells["ID"].Value.ToString());
        }


        //даем возможность пользователю изменять строку с заданием двойным кликом мыши по ней
        private void DataGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            FillTaskForm();
        }
    }
}
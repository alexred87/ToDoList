using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class TaskForm : Form
    {
        //создание события, срабатывающее, после нажания кнопки подтверждения 
        public event Action<string, string, string, int> DataCollected;

        public TaskForm()
        {
            InitializeComponent();
        }


        private void Cancel_btn_Click(object sender, EventArgs e)
        {
            ClearForm();
            Hide();
        }

        private void Confirm_btn_Click(object sender, EventArgs e)
        {
            //проверка на пустое поле
            if (taskDescription.Text == "")
            {
                MessageBox.Show("Поле Задание не может быть пустым.", 
                    "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            //проверка на указание неактуальных даты и времени
            if (dateTimePeeker.Value < DateTime.Now)
            {
                MessageBox.Show("Выбранные дата и время уже устарели.",
                    "Ошибка заполнения", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            //активация события
            DataCollected?.Invoke(dateTimePeeker.Value.ToString(), taskDescription.Text,
                                    commentary_rtb.Text, (int)remindMins.Value);
            ClearForm();
            Hide();
        }

        //Очистка данных и присвоение значений по-умолчанию
        private void ClearForm()
        {
            DateTimePeeker.Value = DateTime.Now;
            TaskDescription.Text = "";
            Commentary_rtb.Clear();
            RemindMins.Value = 5;   
        }
    }
}

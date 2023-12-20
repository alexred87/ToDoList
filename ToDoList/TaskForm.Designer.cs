
using System.Windows.Forms;

namespace ToDoList
{
    partial class TaskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.confirm_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.description = new System.Windows.Forms.GroupBox();
            this.taskDescription = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.commentary_rtb = new System.Windows.Forms.RichTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dateTimePeeker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.remindMins = new System.Windows.Forms.NumericUpDown();
            this.description.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.remindMins)).BeginInit();
            this.SuspendLayout();
            // 
            // confirm_btn
            // 
            this.confirm_btn.Location = new System.Drawing.Point(179, 265);
            this.confirm_btn.Name = "confirm_btn";
            this.confirm_btn.Size = new System.Drawing.Size(103, 36);
            this.confirm_btn.TabIndex = 2;
            this.confirm_btn.Text = "Подтвердить";
            this.confirm_btn.UseVisualStyleBackColor = true;
            this.confirm_btn.Click += new System.EventHandler(this.Confirm_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.Location = new System.Drawing.Point(291, 265);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(103, 36);
            this.cancel_btn.TabIndex = 3;
            this.cancel_btn.Text = "Отмена";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // description
            // 
            this.description.Controls.Add(this.taskDescription);
            this.description.Location = new System.Drawing.Point(13, 2);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(381, 53);
            this.description.TabIndex = 4;
            this.description.TabStop = false;
            this.description.Text = "Задание";
            // 
            // taskDescription
            // 
            this.taskDescription.Location = new System.Drawing.Point(6, 22);
            this.taskDescription.Name = "taskDescription";
            this.taskDescription.PlaceholderText = "Пример, Помыть посуду";
            this.taskDescription.Size = new System.Drawing.Size(368, 23);
            this.taskDescription.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.commentary_rtb);
            this.groupBox2.Location = new System.Drawing.Point(12, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 96);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Комментарий";
            // 
            // commentary_rtb
            // 
            this.commentary_rtb.Location = new System.Drawing.Point(7, 23);
            this.commentary_rtb.Name = "commentary_rtb";
            this.commentary_rtb.Size = new System.Drawing.Size(367, 67);
            this.commentary_rtb.TabIndex = 0;
            this.commentary_rtb.Text = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dateTimePeeker);
            this.groupBox3.Location = new System.Drawing.Point(13, 188);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(136, 47);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Дата и время начала";
            // 
            // dateTimePeeker
            // 
            this.dateTimePeeker.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            this.dateTimePeeker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePeeker.Location = new System.Drawing.Point(6, 18);
            this.dateTimePeeker.Name = "dateTimePeeker";
            this.dateTimePeeker.ShowUpDown = true;
            this.dateTimePeeker.Size = new System.Drawing.Size(124, 23);
            this.dateTimePeeker.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Напомнить за: (мин)";
            // 
            // remindMins
            // 
            this.remindMins.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.remindMins.Location = new System.Drawing.Point(348, 212);
            this.remindMins.Maximum = new decimal(new int[] {
            55,
            0,
            0,
            0});
            this.remindMins.Name = "remindMins";
            this.remindMins.Size = new System.Drawing.Size(38, 23);
            this.remindMins.TabIndex = 8;
            this.remindMins.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // TaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 313);
            this.Controls.Add(this.remindMins);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.description);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.confirm_btn);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(422, 352);
            this.MinimumSize = new System.Drawing.Size(422, 352);
            this.Name = "TaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Форма задания";
            this.description.ResumeLayout(false);
            this.description.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.remindMins)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button confirm_btn;
        private System.Windows.Forms.Button cancel_btn;
        private GroupBox description;
        private TextBox taskDescription;
        private GroupBox groupBox2;
        private RichTextBox commentary_rtb;
        private GroupBox groupBox3;
        private DateTimePicker dateTimePeeker;
        private Label label1;
        private NumericUpDown remindMins;

        public DateTimePicker DateTimePeeker { get => dateTimePeeker; set => dateTimePeeker = value; }
        public TextBox TaskDescription { get => taskDescription; set => taskDescription = value; }
        public RichTextBox Commentary_rtb { get => commentary_rtb; set => commentary_rtb = value; }
        public NumericUpDown RemindMins { get => remindMins; set => remindMins = value; }
    }
}
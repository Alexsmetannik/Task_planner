using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private TaskManager _manager;

        public Form1()
        {
            InitializeComponent();

            _manager = new TaskManager();
        }

        private void UpdateTable()
        {
            dataGridViewTasks.Rows.Clear();

            foreach (TaskEntry task in _manager.Tasks)
            {
                dataGridViewTasks.Rows.Add(task.IsDone, task.Name,
                    task.TaskDate.HasValue ? task.TaskDate.Value.ToShortDateString() : "",
                    task.IsOverdue);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _manager.ReadData("Date.txt");

            //   bindingSourceTasks.DataSource = _manager.Tasks;
            //   bindingSourceTasks.AllowNew = true;

            //   dataGridViewTasks.DataSource = bindingSourceTasks;
            UpdateTable();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _manager.SaveDate();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAdd addForm = new FormAdd();

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                TaskEntry task = new TaskEntry();
                task.Name = addForm.Name;
                task.TaskDate = (DateTime?)addForm.TaskDate;
                task.IsDone = addForm.IsDone;

                AddTask(task);
            }
        }
        private void AddTask(TaskEntry task)
        {
            _manager.AddTask(task);
            //   bindingSourceTasks.ResetBindings(false);
            UpdateTable();
        }

        private void checkBoxDone_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDone.Checked)
            {
                TaskFilterDone filter = new TaskFilterDone();
                _manager.Filter = filter;
                checkBoxOverdue.Checked = false;
            }
            else
            {
                if (!checkBoxDone.Checked)
                    _manager.Filter = null;
            }

            //   bindingSourceTasks.ResetBindings(false);
            UpdateTable();
        }

        private void checkBoxOverdue_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxOverdue.Checked)
            {
                TaskFilterOverdue filter = new TaskFilterOverdue();
                _manager.Filter = filter;
                checkBoxDone.Checked = false;
            }
            else
            {
                if (!checkBoxOverdue.Checked)
                    _manager.Filter = null;
            }

            //    bindingSourceTasks.ResetBindings(false);
            UpdateTable();
        }
    }
}

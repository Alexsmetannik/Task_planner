using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class TaskManager
    {
        private List<TaskEntry> _entries;
        private string _sourse;
        private ITaskFilter _filter;

        public TaskManager()
            {
                _entries = new List<TaskEntry>();
                _filter = null;
            }
        public TaskManager(string source)
            :this()
        {
            ReadData(source);
        }

        public ITaskFilter Filter
        {
            get
            {
                return _filter;
            }

            set
            {
                _filter = value;
            }
        }

        public bool ReadData(string source)
        {
            if (!File.Exists(source))
                return false;

            _sourse = source;

            StreamReader sr = new StreamReader(source);

            string line;
            while((line = sr.ReadLine()) != null)
                {
                string[] fields = line.Split('|');

                TaskEntry task = new TaskEntry();
                task.Name = fields[1];
                task.TaskDate = (fields[2] != "") ? (DateTime?)Convert.ToDateTime(fields[2]) : null;
                task.IsDone = (fields[0] == "1");

                AddTask(task);
                }

            sr.Close();

            return true;
        }

        public void AddTask(TaskEntry task)
        {
            _entries.Add(task);
        }

        public void SaveDate()
        {
            if (File.Exists(_sourse))
            {
                StreamWriter sw = new StreamWriter(_sourse, false);

                foreach (TaskEntry task in _entries)
                {
                    sw.WriteLine(string.Format("{0}|{1}|{2}",
                        task.IsDone ? "1" : "0",
                        task.Name,
                        task.TaskDate.HasValue ? task.TaskDate.Value.ToShortDateString() : ""));
                }

                sw.Close();
            }
        }
            

            public IEnumerable<TaskEntry> Tasks
        {
            get
            {

                foreach (TaskEntry task in _entries)
                { if (_filter != null && _filter.Filter(task))
                        yield return task;
                    else if (_filter == null)
                        yield return task;
                }
            }
        }
    }

    public interface ITaskFilter
    {
        bool Filter(TaskEntry task);
    }
    }


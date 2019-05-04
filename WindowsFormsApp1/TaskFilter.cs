using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class TaskFilterDone : ITaskFilter
    {
        public bool Filter(TaskEntry task)
        {
            return !task.IsDone;
        }
    }

    public class TaskFilterOverdue : ITaskFilter
    {
        public bool Filter(TaskEntry task)
        {
            return !task.IsOverdue;
        }
    }
}

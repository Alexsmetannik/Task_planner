using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
   public class TaskEntry
    {
        public string Name { get; set; }

        public DateTime? TaskDate { get; set; }

        public bool IsDone { get; set; }

        public bool IsOverdue
        {
            get
            {
                if (TaskDate.HasValue && !IsDone)
                    return (TaskDate.Value.Date < DateTime.Now.Date);
                else
                    return false;
            }
        }
    }

   
}

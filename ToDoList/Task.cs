using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    //class is saving to do tasks into a object
    class Task
    {
        private DateTime date;
        private string description;
        private PriorityUnit priority;

        //All of constractors
        public Task() : this(DateTime.Now, "Unknow", PriorityUnit.Important)
        {
        }
        
        public Task(DateTime date, string description, PriorityUnit priority)
        {
            this.date = date;
            this.description = description;
            this.priority = priority;
        }

        //All of properties
        public string Description
        {
            get { return description; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    description = value;
            }
        }
        
        public PriorityUnit PriorityUnit
        {
            get { return priority; }
            set
            {
                if (Enum.IsDefined(typeof(PriorityUnit), value))
                    priority = value;
            }
        }

        public override string ToString()
        {
            string textOut = string.Empty;
            textOut = string.Format("{0, -40} {1, 6:f2} {2, -6}", date, priority, description);
            return textOut;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{ //class is storing Task object inside the List
    class TaskManager
    {
        private List<Task> taskList;

        public TaskManager()
        {
            taskList = new List<Task>();
        }

        //returning Item at certain position
        public Task GetItem(int index)
        {
            if (!CheckIndex(index))
                return null;
            return taskList[index];
        }

        //returning number of Items in the list
        public int Count()
        {
            return taskList.Count;
        }

        //adding Item to the list
        public bool AddItem(Task itemIn)
        {
            bool ok = false;
            if (itemIn != null)
            {
                taskList.Add(itemIn);
                ok = true;
            }
            return ok;
        }
        //checiking if index is not out of range
        private bool CheckIndex(int index)
        {
            bool ok = false;
            if (index >= 0 && taskList.Count - 1 >= index)
                ok = true;
            return ok;
        }

        //changing Item in the list
        public bool ChangeItem(Task itemIn, int index)
        {
            if (CheckIndex(index))
            {
                taskList.RemoveAt(index);
                taskList.Insert(index, itemIn);
                return true;
            }
            return false;

        }

        //removing Item from the list
        public bool DeleteItem(int index)
        {
            if (CheckIndex(index))
            {
                taskList.RemoveAt(index);
                return true;
            }
            return false;
        }

        //putting ingrediens in the array of strings to later print them on the screen
        public string[] GetItemsInfoString()
        {
            string[] stringInfoTask = new string[taskList.Count];
            int i = 0;
            foreach (Task item in taskList)
            {
                stringInfoTask[i++] = item.ToString();
            }

            return stringInfoTask;
        }
    }
}
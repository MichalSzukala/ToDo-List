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
    //class is taking care of GUI and interaction with user
    public partial class MainForm : Form
    {
        TaskManager taskManager = new TaskManager();

        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            comboBoxPriority.Items.AddRange(Enum.GetNames(typeof(PriorityUnit)));
            comboBoxPriority.SelectedIndex = (int)PriorityUnit.Important;
            DisableButtons();
        }

        //is checking if all the imput is valid
        private bool ReadInput()
        {
            bool ok = true;

            if (!ReadDate())
                ok = false;
            else if (!ReadDescription())
                ok = false;
            
            return ok;
        }

        //is checking if date is valid
        private bool ReadDate()
        {
            bool ok = false;
            DateTime today = DateTime.Today.Date;
            if (dateTimePickerDate.Value < today)
                GiveMessage("You are not allowed to select older day than today!");
            else
                ok = true;
            return ok;
        }

        //is checking if user provide description
        private bool ReadDescription()
        {
            bool ok = false;
            string description = string.Empty;

            if (textBoxDescription.Text == string.Empty)
            {
                GiveMessage("You forget the description");
            }
            else
                ok = true;
            return ok;
        }

        //error message
        private void GiveMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //creats object of Task
        private Task SingleTask()
        {
            DateTime date = dateTimePickerDate.Value;
            string description = textBoxDescription.Text;
            PriorityUnit priority = (PriorityUnit)comboBoxPriority.SelectedIndex;

            Task singleTask = new Task(date, description, priority);

            return singleTask;
        }

        //printing shoping list and updating all the fields
        private void UpdateGUI()
        {
            DisableButtons();

            listBoxTasks.Items.Clear();
            listBoxTasks.Items.AddRange(taskManager.GetItemsInfoString());
            textBoxDescription.Clear();
        }

        //event handler for button Add
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (ReadInput())
            {
                Task singleTask = SingleTask();
                taskManager.AddItem(singleTask);
                UpdateGUI();
            }
        }

        //event handler for button Edit
        private void buttonChange_Click(object sender, EventArgs e)
        {
            int index = listBoxTasks.SelectedIndex;
            if (index >= 0 && ReadInput())
            {
                Task singleItem = SingleTask();
                taskManager.ChangeItem(singleItem, index);
                UpdateGUI();
            }
        }

        //event handler for button Delete
        private void buttonDelete_Click(object sender, EventArgs e)
        {

            int index = listBoxTasks.SelectedIndex;
            if (index >= 0)
            {
                DialogResult result = ConfirmationWindow("Do you really want to delete task?");
                if (result == DialogResult.OK)
                {
                    taskManager.DeleteItem(index);
                    UpdateGUI();
                }
                else
                {
                    listBoxTasks.SelectedIndex = -1;
                    UpdateGUI();
                }
            }
        }

    //Edit and Delete buttons are disable
    private void DisableButtons()
        {
            buttonChange.Enabled = false;
            buttonDelete.Enabled = false;
        }

        //Edit and Delete buttons are enable
        private void EnableButtons()
        {
            buttonChange.Enabled = true;
            buttonDelete.Enabled = true;
        }

        //event handler for listBox
        private void listBoxTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (taskManager.Count() == 0 || listBoxTasks.SelectedIndex >= 0)
                EnableButtons();
        }

        private DialogResult ConfirmationWindow(string message)
        {
            DialogResult result = MessageBox.Show(message, "Confirmation Window", MessageBoxButtons.OKCancel);
            return result;
            
        }
        
    }
}

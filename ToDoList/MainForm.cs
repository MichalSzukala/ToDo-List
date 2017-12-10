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
        TaskManager itemManager = new TaskManager();

        public MainForm()
        {
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            comboBoxPriority.Items.AddRange(Enum.GetNames(typeof(PriorityUnit)));
            comboBoxPriority.SelectedIndex = (int)PriorityUnit.Important;
        }











        

    }
}

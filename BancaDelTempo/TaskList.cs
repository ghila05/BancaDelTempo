using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BancaDelTempo
{
    public partial class TaskList : Form
    {
        public TaskList()
        {
            InitializeComponent();
        }
        bool first = true;
        List<Task> list;
        string path = @"task.json";
        private void TaskList_Load(object sender, EventArgs e)
        {
            list = new List<Task>();
            list = LoadTask();

            if (first)
            {
                listView1.View = View.Details;
                listView1.FullRowSelect = true;
                first = false;

                listView1.Columns.Add("STATO", 100);
                listView1.Columns.Add("ID RICHIEDENTE", 150); // fill listview 
                listView1.Columns.Add("TASK", 300);

            }

            fillist();


        }


        private void button4_Click(object sender, EventArgs e) // change state
        {
            string selectedid = listView1.SelectedItems[0].SubItems[1].Text; // selected task
            string selectedtask = listView1.SelectedItems[0].SubItems[2].Text; // selected task


            List<Task> Tasklist = LoadTask();

            for (int i = 0;i < Tasklist.Count;i++)
            {
                if (Tasklist[i].Id == selectedid && Tasklist[i].Prestazione == selectedtask)
                {
                    Tasklist[i].Todo = false; 
                }


            }

            string serialize = JsonConvert.SerializeObject(Tasklist, Formatting.Indented); // deserialize and write
            File.WriteAllText(path, serialize); //write the file with new info

            list = LoadTask();
            listView1.Items.Clear();
            fillist();
           

        }
        private List<Task> LoadTask()
        {
            string jsonContent = File.ReadAllText(path);
            List<Task> task = JsonConvert.DeserializeObject<List<Task>>(jsonContent);

            return task;


        }
        public void fillist()
        {
            ListViewItem campi;

            for (int i = 0; i < list.Count; i++)
            {

                campi = new ListViewItem(Convert.ToString(list[i].Todo));
                campi.SubItems.Add(list[i].Id);
                campi.SubItems.Add(list[i].Prestazione);
                listView1.Items.Add(campi);
                campi.BackColor = Color.LimeGreen;
            }
        }

    }
}

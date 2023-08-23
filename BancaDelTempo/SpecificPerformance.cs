using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Policy;
using System.CodeDom;

namespace BancaDelTempo
{
    public partial class SpecificPerformance : Form
    {
        public SpecificPerformance()
        {
            InitializeComponent();
        }
        string regexPattern = @"^[A-Z]{2}\d{2}$"; // validation of id
        Task t;

        string path = @"task.json";
        string userpath = @"user.json";
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Id richiedente")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Id richiedente";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Prestazione")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Prestazione";
                textBox1.ForeColor = Color.Gray;
            }
        }


        // end design part
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Id richiedente") { throw new Exception("Inserisci il richiedente"); }
            if (textBox1.Text == "Prestazione") { throw new Exception("Inserisci la prestazione che vuoi richiedere"); }
            if (Regex.IsMatch(textBox2.Text, regexPattern) == false)
            {
                throw new Exception("Id user non valido");
            }

            t = new Task(textBox2.Text.ToUpper(), textBox1.Text.ToUpper());
            if (Esiste(t.Id))
            {
                WriteTask(t);
                MessageBox.Show("La task è stata riportata correttamente");
            }
            else throw new Exception("L'id non è associato a nessun utente");

           
        }


        private void WriteTask(Task u)
        {
            string jsonContent = File.ReadAllText(path);
            List<Task> tasklist = JsonConvert.DeserializeObject<List<Task>>(jsonContent); // read and deserialize

            tasklist.Add(u); //add new task to the list 

            string serialize = JsonConvert.SerializeObject(tasklist, Formatting.Indented); // deserialize and write
            File.WriteAllText(path, serialize); //add new task to the file


        }

        public bool Esiste(string id)
        {
            bool esiste = false;
            string jsonContent = File.ReadAllText(userpath);
            List<Utente> userList = JsonConvert.DeserializeObject<List<Utente>>(jsonContent); // read and deserialize

            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].Id == id)
                {
                    esiste = true;
                }

            }
            return esiste;

        }





    }
}

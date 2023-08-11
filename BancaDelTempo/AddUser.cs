using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancaDelTempo
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        string path = @"C:\Users\nicol\OneDrive\Desktop\prova.json";


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Nome")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Nome";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Cognome")
            {
               
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Cognome";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Numero telefonico")
            {

                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {   
                textBox3.Text = "Numero telefonico";
                textBox3.ForeColor = Color.Gray;
            }
        }
        private void comboBox1_Enter(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Categoria")
            {

                comboBox1.Text = "";
                comboBox1.ForeColor = Color.Black;
            }
        }
        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                comboBox1.Text = "Categoria";
                comboBox1.ForeColor = Color.Gray;
            }
        }
        
         //end of the design part

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Nome") { throw new Exception("Inserisci il tuo Nome"); }
            if (textBox2.Text == "Cognome") { throw new Exception("Inserisci il tuo Cognome"); }
            if (textBox3.Text == "Numero telefonico") { throw new Exception("Inserisci il tuo Numero telefonico"); } //check 
            if (checkBox1.Checked == false) { throw new Exception("Accetta le informative sulla privacy"); }

            //Utente u = new Utente {Nome = textBox1.Text, Cognome = textBox2.Text, Tel = textBox3.Text}; 
            Utente u = new Utente(textBox1.Text,textBox2.Text,textBox3.Text, comboBox1.Text);

            MessageBox.Show($"nome: {u.Nome}");
            WriteUser(u);

        }

        private void WriteUser(Utente u) 
        {
            string jsonContent = File.ReadAllText(path);
            List<Utente> userList = JsonConvert.DeserializeObject<List<Utente>>(jsonContent); // read and deserialize

            userList.Add(u); //add new user 

            string serialize  = JsonConvert.SerializeObject(userList, Formatting.Indented); // deserialize and write
            File.WriteAllText(path, serialize);
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancaDelTempo
{
    public partial class TransferHours : Form
    {
        public TransferHours()
        {
            InitializeComponent();
        }
        string path = @"prova.json";
        string regexPattern = @"^[A-Z]{2}\d{2}$";
        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Id Mittente")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Id Mittente";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Id Destinatario")
            {

                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Id Destinatario";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Importo in h")
            {

                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Importo in h";
                textBox3.ForeColor = Color.Gray;
            }
        }

        //end of the design part
        private void button1_Click(object sender, EventArgs e) //pay button 
        {
            if (textBox1.Text == "Id Mittente") { throw new Exception("Inserisci il mittente"); }
            if (textBox2.Text == "Id Destinatario") { throw new Exception("Inserisci il destinatario"); }
            if (textBox3.Text == "Importo in h") { throw new Exception("Inserisci l'importo in euro"); }

            float hours = float.Parse(textBox3.Text);

            if (Regex.IsMatch(textBox1.Text, regexPattern) == false)
            {
                throw new Exception("Id mittente non valido");
            }
            if (Regex.IsMatch(textBox2.Text, regexPattern) == false)
            {
                throw new Exception("Id destinatario non valido");
            }

            Transfer(textBox1.Text.ToUpper(), textBox2.Text.ToUpper(), hours);

        }

        

        private void Transfer (string idM , string idD, float hours) // the id is used like iban 
        {
            int esiste=0;
            string jsonContent = File.ReadAllText(path);
            List<Utente> userList = JsonConvert.DeserializeObject<List<Utente>>(jsonContent); // read and deserialize

            for(int i = 0; i < userList.Count; i++)
            {
                if (userList[i].Id == idM) // search the sender
                {
                    userList[i].Debiti = userList[i].Debiti - hours; // substract the hours to the sender
                    esiste = esiste + 2;
                }
                if (userList[i].Id == idD) // search the recipient
                {
                    userList[i].Debiti = userList[i].Debiti + hours; // add the hours to the recipient
                    esiste--;
                }

            }

            if (esiste != 1) 
            {
                throw new Exception("pagamento non riuscito, mittente o destinatario inesistenti");
                return;
            }
            

            string serialize = JsonConvert.SerializeObject(userList, Formatting.Indented); // deserialize and write
            File.WriteAllText(path, serialize); //write the file with new info

        }
    }
 



}

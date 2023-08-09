using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Nome") { throw new Exception("Inserisci il tuo Nome"); }
            if (textBox2.Text == "Cognome") { throw new Exception("Inserisci il tuo Cognome"); }
            if (textBox3.Text == "Numero telefonico") { throw new Exception("Inserisci il tuo Numero telefonico"); }
            if (checkBox1.Checked == false) { throw new Exception("Accetta le informative sulla privacy"); }

            WriteUser();

        }

        private void WriteUser()
        {
            //scrittura su file del nuovo utente

        }

    }
}

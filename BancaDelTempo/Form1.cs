using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace BancaDelTempo
{
    public partial class GhilaBDT : Form
    {
        public GhilaBDT()
        {
            InitializeComponent();
        }
        Banca bdt;
        List<Utente> user; //lista di utenti della banca
        string path = @"C:\Users\nicol\OneDrive\Desktop\prova.json";
        bool first = true;
        private void Form1_Load(object sender, EventArgs e)
        {
            bdt = new Banca("123", "GhilaBank", "BG");
            user = LoadUser();


            for(int i=0; i<user.Count; i++)
            {
                bdt.AddUser(user[i]);   // aggiungo alla banca tutti gli utenti prova
            }

            if (first)//solo la prima volta che apro il programma popolo la listview
            {
                listView1.View = View.Details;
                listView1.FullRowSelect = true;
                first = false;

                listView1.Columns.Add("ID", 60);
                listView1.Columns.Add("NOME", 100);
                listView1.Columns.Add("COGNOME", 100);
                listView1.Columns.Add("TEL.", 180);
                listView1.Columns.Add("DEBITI IN H", 100);

            }

            ListViewItem campi;
            
            for (int i = 0; i < user.Count; i++)
            {
                campi = new ListViewItem(user[i].Id);
                campi.SubItems.Add(user[i].Nome);
                campi.SubItems.Add(user[i].Cognome);
                campi.SubItems.Add(user[i].Tel);
                campi.SubItems.Add(Convert.ToString(user[i].Debiti));
                listView1.Items.Add(campi);
                campi.BackColor = Color.LimeGreen;
            }

        }

        private List<Utente> LoadUser()
        {
            string jsonContent = File.ReadAllText(path);
            List<Utente> userList = JsonConvert.DeserializeObject<List<Utente>>(jsonContent);

            return userList;
        }

       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void OrdinaDebiti_Click(object sender, EventArgs e)
        {
       



        }

        private void AggUser_Click(object sender, EventArgs e)
        {
            AddUser user = new AddUser();
            user.ShowDialog();
        }
    }
}

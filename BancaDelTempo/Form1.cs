﻿using System;
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
        List<Utente> user; //list of user
        string path = @"user.json";
        bool first = true;
        private void Form1_Load(object sender, EventArgs e)
        {
            bdt = new Banca("123", "GhilaBank", "BG");
            user = LoadUser();
    

            for(int i=0; i<user.Count; i++)
            {
                bdt.AddUser(user[i]);   // aggiungo alla banca tutti gli utenti prova
            }

            if (first)//only the first time 
            {
                listView1.View = View.Details;
                listView1.FullRowSelect = true;
                first = false;

                listView1.Columns.Add("ID", 60);
                listView1.Columns.Add("NOME", 100);
                listView1.Columns.Add("COGNOME", 100);
                listView1.Columns.Add("TEL.", 180);
                listView1.Columns.Add("DEBITI IN H", 120);
                listView1.Columns.Add("CATEGORIA", 150);

            }

           
            fillist();

        }

        private List<Utente> LoadUser()
        {
            string jsonContent = File.ReadAllText(path);
            List<Utente> userList = JsonConvert.DeserializeObject<List<Utente>>(jsonContent);

            return userList;
        }
        public void fillist()
        {
            ListViewItem campi;

            for (int i = 0; i < user.Count; i++)
            {
             
                campi = new ListViewItem(user[i].Id);
                campi.SubItems.Add(user[i].Nome);
                campi.SubItems.Add(user[i].Cognome);
                campi.SubItems.Add(user[i].Tel);
                campi.SubItems.Add(Convert.ToString(user[i].Debiti));
                campi.SubItems.Add(user[i].Categoria);
                listView1.Items.Add(campi);
                campi.BackColor = Color.LimeGreen;
            }
        }

       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void OrdinaDebiti_Click(object sender, EventArgs e)
        {
       



        }

        private void AggUser_Click(object sender, EventArgs e) // add user
        {
            AddUser userr = new AddUser();
            userr.ShowDialog();
            user = LoadUser();
            listView1.Items.Clear();
            fillist();
        }

        private void button2_Click(object sender, EventArgs e) // transfer hours
        {
            TransferHours scambia = new TransferHours();
            scambia.ShowDialog();
            user = LoadUser();
            listView1.Items.Clear();
            fillist();

        }

        private void button1_Click(object sender, EventArgs e) // delete selected user
        {
            string selected = listView1.SelectedItems[0].SubItems[0].Text; // id of selected user

            string jsonContent = File.ReadAllText(path);
            List<Utente> userList = JsonConvert.DeserializeObject<List<Utente>>(jsonContent); // read and deserialize

            for(int i = 0; i < userList.Count; i++)
            {
                if (userList[i].Id == selected)
                {
                    userList.RemoveAt(i);
                }

            }
            string serialize = JsonConvert.SerializeObject(userList, Formatting.Indented); // deserialize and write
            File.WriteAllText(path, serialize); //write the file with new info


            user = LoadUser();
            listView1.Items.Clear();
            fillist();
        }

        private void button3_Click(object sender, EventArgs e)// offer, request specific performance
        {
            SpecificPerformance performance = new SpecificPerformance();
            performance.ShowDialog();



        }
    }
}

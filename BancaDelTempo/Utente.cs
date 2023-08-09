using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancaDelTempo
{
    public class Utente : IEquatable<Utente>, IComparable<Utente>
    {
        string id, nome, cognome, tel;
        float debiti = 0;

        public string Id { get; private set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Tel { get; set; }
        public float Debiti { get; set; }

        public Utente(string nome, string cognome, string tel, float debiti) {
            
            id = CreaId(nome, cognome, tel);

            this.nome = nome;
            this.cognome = cognome;
            this.tel = tel;
            this.debiti = debiti;
        }

        public Utente()
        {

        }
        private string CreaId(string nome, string cognome, string tel) {
            MessageBox.Show("sono dentro alla funzione");
            string id;
            id = nome.Substring(0,4);
            id = id + cognome.Substring(0, 3);
            id = id + tel.Substring(6, 3);
            return id;
        
        }

        public override string ToString()
        {
            return id + ";" + nome + ";" + cognome + ";" + tel + ";" + debiti;
        }

        public bool Equals(Utente p)
        {
            if (p == null) return false;
            if (this == p) return true;
            return (this.id == p.id);
        }

        public int CompareTo(Utente utente)
        {
            if (utente.debiti < this.debiti) return -1; 

            if (utente.debiti > this.debiti) return 1;

            return 0;
        }
        

    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancaDelTempo
{
    public class Utente : IEquatable<Utente>, IComparable<Utente>
    {
        string id, nome, cognome, tel, categoria;
        float debiti = 0;

        public string Id { get;  set; }
        public string Nome { get;  set; }
        public string Cognome { get;  set; }
        public string Tel { get;  set; }
        public float Debiti { get;  set; }
        public string Categoria { get;  set; } 

        public Utente(string id, string nome, string cognome, string tel, string categoria) {
            Id = id;    
            Nome = nome;
            Cognome = cognome;
            Tel = tel;
            Categoria = categoria;
            Debiti = 0;
        }

        public Utente()
        {
           
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

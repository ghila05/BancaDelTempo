using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaDelTempo
{
    public class Banca : IEquatable<Banca>
    {
        string nome, zona, id;

        public string Nome { get; set; }
        public string Zona { get; set; }
        public string Id { get; private set;}

        List<Utente>utenti = new List<Utente>();
        
        public Banca() { 
        
        }

        public Banca(string id, string nome, string zona) {
            id = Id;
            nome = Nome;
            this.zona = zona;
        }


        public override string ToString()
        {
            return nome + ";" + zona;
        }
        public bool Equals(Banca b) {
            if (b == null) return false;
            if (this == b) return true;
            return (this.id == b.id);
        }



        public void AddUser(Utente u)
        {
            utenti.Add(u);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancaDelTempo
{
    public class Task : IEquatable<Task>
    {
        string id, prestazione;


        public string Id { get; set; }
        public string Prestazione { get; set; }

        public Task() { }

        public Task(string id, string prestazione)
        {
            Id = id;
            Prestazione = prestazione;  
        }

        public bool Equals(Task p)
        {
            if (p == null) return false;
            if (this == p) return true;
            return (this.id == p.id);
        }


    }
}

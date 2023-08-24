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

        public bool Todo { get; set; }
        public string Id { get; set; }
        public string Prestazione { get; set; }

        public Task() { }

        public Task(bool todo, string id, string prestazione)
        {
            Todo = todo;
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

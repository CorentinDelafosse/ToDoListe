using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoListe.Models
{
    public class TodoEle
    {
        public string nom { get; set; }
        public string description { get; set; }
        public int checkbox { get; set; }

        public override string ToString()
        {
            return this.nom;
        }
    }
}

using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public partial class ListaObecnosci
    {
        public ListaObecnosci()
        {
            Obecnosc = new HashSet<Obecnosc>();
        }

        public int IdListy { get; set; }
        public int IdLekcji { get; set; }

        public virtual Lekcja IdLekcjiNavigation { get; set; }
        public virtual ICollection<Obecnosc> Obecnosc { get; set; }
    }
}

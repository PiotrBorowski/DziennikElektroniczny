using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public partial class Lekcja
    {
        public Lekcja()
        {
            ListaObecnosci = new HashSet<ListaObecnosci>();
        }

        public int IdLekcji { get; set; }
        public string Temat { get; set; }
        public DateTime Data { get; set; }
        public int IdProwadzacegoLekcje { get; set; }
        public int IdJednostkiLekcyjnej { get; set; }

        public virtual JednostkaLekcyjna IdJednostkiLekcyjnejNavigation { get; set; }
        public virtual Uzytkownik IdProwadzacegoLekcjeNavigation { get; set; }
        public virtual ICollection<ListaObecnosci> ListaObecnosci { get; set; }
    }
}

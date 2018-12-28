using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public partial class Przedmiot
    {
        public Przedmiot()
        {
            JednostkaLekcyjna = new HashSet<JednostkaLekcyjna>();
            Ocena = new HashSet<Ocena>();
        }

        public int IdPrzedmiotu { get; set; }
        public string Nazwa { get; set; }
        public int IdProwadzacego { get; set; }

        public virtual Uzytkownik IdProwadzacegoNavigation { get; set; }
        public virtual ICollection<JednostkaLekcyjna> JednostkaLekcyjna { get; set; }
        public virtual ICollection<Ocena> Ocena { get; set; }
    }
}

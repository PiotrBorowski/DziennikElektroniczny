using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public partial class JednostkaLekcyjna
    {
        public JednostkaLekcyjna()
        {
            Lekcja = new HashSet<Lekcja>();
        }

        public int IdJednostkiLekcyjnej { get; set; }
        public string DzienTygodnia { get; set; }
        public TimeSpan Godzina { get; set; }
        public string Sala { get; set; }
        public int IdPrzedmiotu { get; set; }
        public int IdPlanuLekcji { get; set; }

        public virtual PlanLekcji IdPlanuLekcjiNavigation { get; set; }
        public virtual Przedmiot IdPrzedmiotuNavigation { get; set; }
        public virtual ICollection<Lekcja> Lekcja { get; set; }
    }
}

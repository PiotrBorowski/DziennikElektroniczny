using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public partial class Ocena
    {
        public int IdOceny { get; set; }
        public double Wartosc { get; set; }
        public int IdPrzedmiotu { get; set; }
        public int IdKategoriiOceny { get; set; }
        public int IdUcznia { get; set; }

        public virtual KategoriaOceny IdKategoriiOcenyNavigation { get; set; }
        public virtual Przedmiot IdPrzedmiotuNavigation { get; set; }
        public virtual Uczen IdUczniaNavigation { get; set; }
    }
}

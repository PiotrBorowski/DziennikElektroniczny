using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public partial class Obecnosc
    {
        public int IdObecnosci { get; set; }
        public bool? CzyObecny { get; set; }
        public int IdListy { get; set; }
        public int IdUcznia { get; set; }

        public virtual ListaObecnosci IdListyNavigation { get; set; }
        public virtual Uczen IdUczniaNavigation { get; set; }
    }
}

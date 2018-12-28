using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public partial class Usprawiedliwienie
    {
        public int IdUsprawiedliwienie { get; set; }
        public string Tresc { get; set; }
        public DateTime Data { get; set; }
        public bool? CzyZatwierdzone { get; set; }
        public int IdRodzica { get; set; }
        public int IdWychowawcy { get; set; }

        public virtual Uzytkownik IdRodzicaNavigation { get; set; }
        public virtual Uzytkownik IdWychowawcyNavigation { get; set; }
    }
}

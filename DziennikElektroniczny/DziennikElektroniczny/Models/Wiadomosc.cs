using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public partial class Wiadomosc
    {
        public int IdWiadomosci { get; set; }
        public string Tresc { get; set; }
        public int IdNadawcy { get; set; }
        public int IdOdbiorcy { get; set; }

        public virtual Uzytkownik IdNadawcyNavigation { get; set; }
        public virtual Uzytkownik IdOdbiorcyNavigation { get; set; }
    }
}

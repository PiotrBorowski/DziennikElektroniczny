using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public partial class Uwaga
    {
        public int IdUwagi { get; set; }
        public string Tresc { get; set; }
        public int IdNauczyciela { get; set; }
        public int IdUcznia { get; set; }

        public virtual Uzytkownik IdNauczycielaNavigation { get; set; }
        public virtual Uczen IdUczniaNavigation { get; set; }
    }
}

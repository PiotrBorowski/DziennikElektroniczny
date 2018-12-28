using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public partial class Rola
    {
        public Rola()
        {
            Uzytkownik = new HashSet<Uzytkownik>();
        }

        public int IdRoli { get; set; }
        public string NazwaRoli { get; set; }

        public virtual ICollection<Uzytkownik> Uzytkownik { get; set; }
    }
}

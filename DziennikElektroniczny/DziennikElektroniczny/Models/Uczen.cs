using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public partial class Uczen
    {
        public Uczen()
        {
            Obecnosc = new HashSet<Obecnosc>();
            Ocena = new HashSet<Ocena>();
            Uwaga = new HashSet<Uwaga>();
        }

        public int IdUzytkownika { get; set; }
        public string Pesel { get; set; }
        public int IdRodzica { get; set; }
        public int IdKlasy { get; set; }

        public virtual Klasa IdKlasyNavigation { get; set; }
        public virtual Uzytkownik IdRodzicaNavigation { get; set; }
        public virtual Uzytkownik IdUzytkownikaNavigation { get; set; }
        public virtual ICollection<Obecnosc> Obecnosc { get; set; }
        public virtual ICollection<Ocena> Ocena { get; set; }
        public virtual ICollection<Uwaga> Uwaga { get; set; }
    }
}

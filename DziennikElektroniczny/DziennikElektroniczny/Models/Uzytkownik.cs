using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public partial class Uzytkownik
    {
        public Uzytkownik()
        {
            Klasa = new HashSet<Klasa>();
            Lekcja = new HashSet<Lekcja>();
            Przedmiot = new HashSet<Przedmiot>();
            UczenIdRodzicaNavigation = new HashSet<Uczen>();
            UsprawiedliwienieIdRodzicaNavigation = new HashSet<Usprawiedliwienie>();
            UsprawiedliwienieIdWychowawcyNavigation = new HashSet<Usprawiedliwienie>();
            Uwaga = new HashSet<Uwaga>();
            WiadomoscIdNadawcyNavigation = new HashSet<Wiadomosc>();
            WiadomoscIdOdbiorcyNavigation = new HashSet<Wiadomosc>();
        }

        public int IdUzytkownika { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NumerKontaktowy { get; set; }
        public int IdRoli { get; set; }

        public virtual Rola IdRoliNavigation { get; set; }
        public virtual Uczen UczenIdUzytkownikaNavigation { get; set; }
        public virtual ICollection<Klasa> Klasa { get; set; }
        public virtual ICollection<Lekcja> Lekcja { get; set; }
        public virtual ICollection<Przedmiot> Przedmiot { get; set; }
        public virtual ICollection<Uczen> UczenIdRodzicaNavigation { get; set; }
        public virtual ICollection<Usprawiedliwienie> UsprawiedliwienieIdRodzicaNavigation { get; set; }
        public virtual ICollection<Usprawiedliwienie> UsprawiedliwienieIdWychowawcyNavigation { get; set; }
        public virtual ICollection<Uwaga> Uwaga { get; set; }
        public virtual ICollection<Wiadomosc> WiadomoscIdNadawcyNavigation { get; set; }
        public virtual ICollection<Wiadomosc> WiadomoscIdOdbiorcyNavigation { get; set; }
    }
}

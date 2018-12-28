using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public partial class Klasa
    {
        public Klasa()
        {
            PlanLekcji = new HashSet<PlanLekcji>();
            Uczen = new HashSet<Uczen>();
        }

        public int IdKlasy { get; set; }
        public string Nazwa { get; set; }
        public string RokSzkolny { get; set; }
        public int IdWychowawcy { get; set; }

        public virtual Uzytkownik IdWychowawcyNavigation { get; set; }
        public virtual ICollection<PlanLekcji> PlanLekcji { get; set; }
        public virtual ICollection<Uczen> Uczen { get; set; }
    }
}

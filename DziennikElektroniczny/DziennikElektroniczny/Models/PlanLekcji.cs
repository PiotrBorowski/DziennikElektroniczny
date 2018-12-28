using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public partial class PlanLekcji
    {
        public PlanLekcji()
        {
            JednostkaLekcyjna = new HashSet<JednostkaLekcyjna>();
        }

        public int IdPlanuLekcji { get; set; }
        public int IdKlasy { get; set; }

        public virtual Klasa IdKlasyNavigation { get; set; }
        public virtual ICollection<JednostkaLekcyjna> JednostkaLekcyjna { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace DziennikElektroniczny.Models
{
    public partial class KategoriaOceny
    {
        public KategoriaOceny()
        {
            Ocena = new HashSet<Ocena>();
        }

        public int IdKategoriiOceny { get; set; }
        public string Nazwa { get; set; }
        public int Waga { get; set; }

        public virtual ICollection<Ocena> Ocena { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DziennikElektroniczny.DTO
{
    public class AddUczenDTO
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NumerKontaktowy { get; set; }
        public int IdRoli => 4;
        public string Pesel { get; set; }
        public int IdRodzica { get; set; }
        public int IdKlasy { get; set; }
    }
}

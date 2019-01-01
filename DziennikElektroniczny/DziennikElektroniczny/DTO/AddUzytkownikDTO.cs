using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DziennikElektroniczny.DTO
{
    public class AddUzytkownikDTO
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string NumerKontaktowy { get; set; }
        public int IdRoli { get; set; }
    }
}

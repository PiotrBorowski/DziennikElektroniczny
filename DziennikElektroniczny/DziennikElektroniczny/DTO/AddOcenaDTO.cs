using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DziennikElektroniczny.DTO
{
    public class AddOcenaDTO
    {
        public double Wartosc { get; set; }
        public int IdPrzedmiotu { get; set; }
        public int IdKategoriiOceny { get; set; }
        public int IdUcznia { get; set; }
    }
}

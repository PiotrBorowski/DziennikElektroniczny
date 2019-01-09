using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DziennikElektroniczny.DTO
{
    public class AddJednostkaLekcyjnaDTO
    {
        public string DzienTygodnia { get; set; }
        public TimeSpan Godzina { get; set; }
        public string Sala { get; set; }
        public int IdPrzedmiotu { get; set; }
        public int IdPlanuLekcji { get; set; }
    }
}

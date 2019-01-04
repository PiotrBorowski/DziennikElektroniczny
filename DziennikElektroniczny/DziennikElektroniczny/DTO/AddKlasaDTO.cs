using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DziennikElektroniczny.DTO
{
    public class AddKlasaDTO
    {
        public string Nazwa { get; set; }
        public string RokSzkolny { get; set; }
        public int IdWychowawcy { get; set; }
    }
}

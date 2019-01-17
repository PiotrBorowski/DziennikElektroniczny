using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DziennikElektroniczny.DTO
{
    public class AddUsprawiedliwienieDTO
    {
        public string Tresc { get; set; }
        public DateTime Data { get; set; }
        public int IdWychowawcy { get; set; }
        public int IdRodzica { get; set; }
    }
}

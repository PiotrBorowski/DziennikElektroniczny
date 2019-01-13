using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DziennikElektroniczny.DTO
{
    public class SendWiadomoscDTO
    {
        public string Tresc { get; set; }
        public int IdNadawcy { get; set; }
        public int IdOdbiorcy { get; set; }
    }
}

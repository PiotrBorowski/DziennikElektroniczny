using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DziennikElektroniczny.DTO
{
    public class AddUwagaDTO
    {
        public string Tresc { get; set; }
        public int IdNauczyciela { get; set; }
        public int IdUcznia { get; set; }
    }
}

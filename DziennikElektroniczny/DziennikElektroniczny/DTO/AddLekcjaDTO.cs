using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DziennikElektroniczny.DTO
{
    public class AddLekcjaDTO
    {
        public string Temat { get; set; }
        public DateTime Data { get; set; }
        public int IdProwadzacegoLekcje { get; set; }
        public int IdJednostkiLekcyjnej { get; set; }
    }
}

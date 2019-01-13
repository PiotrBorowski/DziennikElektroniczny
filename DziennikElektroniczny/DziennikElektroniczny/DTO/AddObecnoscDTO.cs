using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DziennikElektroniczny.DTO
{
    public class AddObecnoscDTO
    {
        public bool? CzyObecny { get; set; }
        public int IdListy { get; set; }
        public int IdUcznia { get; set; }
    }
}

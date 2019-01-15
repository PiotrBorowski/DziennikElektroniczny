using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DziennikElektroniczny.ViewModels
{
    public class ObecnoscViewModel
    {
        public bool? CzyObecny { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Godzina { get; set; }
    }
}

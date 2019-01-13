using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DziennikElektroniczny.ViewModels
{
    public class JednostkaLekcyjnaViewModel
    {
        public string DzienTygodnia { get; set; }
        public TimeSpan Godzina { get; set; }
        public string Sala { get; set; }
        public string Przedmiot { get; set; }
    }
}

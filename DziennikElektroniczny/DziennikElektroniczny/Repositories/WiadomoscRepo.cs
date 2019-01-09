using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.Repositories
{
    public class WiadomoscRepo : GenericRepository<DziennikElektronicznyContext, Wiadomosc>
    {
        public WiadomoscRepo(DziennikElektronicznyContext context) : base(context)
        {
        }
    }
}

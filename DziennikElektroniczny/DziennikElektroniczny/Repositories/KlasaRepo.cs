using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.Repositories
{
    public class KlasaRepo : GenericRepository<DziennikElektronicznyContext, Klasa>
    {
        public KlasaRepo(DziennikElektronicznyContext context) : base(context)
        {
        }
    }
}

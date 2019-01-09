using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.Repositories
{
    public class ObecnoscRepo : GenericRepository<DziennikElektronicznyContext, Obecnosc>
    {
        public ObecnoscRepo(DziennikElektronicznyContext context) : base(context)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.Repositories
{
    public class OcenaRepo : GenericRepository<DziennikElektronicznyContext, Ocena>
    {
        public OcenaRepo(DziennikElektronicznyContext context) : base(context)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.Repositories
{
    public class UczenRepo : GenericRepository<DziennikElektronicznyContext, Uczen>
    {
        public UczenRepo(DziennikElektronicznyContext context) : base(context)
        {
        }
    }
}

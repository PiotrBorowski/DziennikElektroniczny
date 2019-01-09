using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.Repositories
{
    public class UwagaRepo : GenericRepository<DziennikElektronicznyContext, Uwaga>
    {
        public UwagaRepo(DziennikElektronicznyContext context) : base(context)
        {
        }
    }
}

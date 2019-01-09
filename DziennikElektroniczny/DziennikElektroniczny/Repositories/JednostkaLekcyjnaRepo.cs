using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.Repositories
{
    public class JednostkaLekcyjnaRepo : GenericRepository<DziennikElektronicznyContext, JednostkaLekcyjna>
    {
        public JednostkaLekcyjnaRepo(DziennikElektronicznyContext context) : base(context)
        {
        }
    }
}

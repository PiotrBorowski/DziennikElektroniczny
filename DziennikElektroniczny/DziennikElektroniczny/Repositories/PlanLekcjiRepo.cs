using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.Repositories
{
    public class PlanLekcjiRepo : GenericRepository<DziennikElektronicznyContext,PlanLekcji>
    {
        public PlanLekcjiRepo(DziennikElektronicznyContext context) : base(context)
        {
        }
    }
}

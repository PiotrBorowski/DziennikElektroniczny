using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.Repositories
{
    public class PrzedmiotRepo : GenericRepository<DziennikElektronicznyContext, Przedmiot>
    {
        public PrzedmiotRepo(DziennikElektronicznyContext context) : base(context)
        {
        }
    }
}

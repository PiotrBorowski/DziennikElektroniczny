﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.Repositories
{
    public class ListaObecnosciRepo : GenericRepository<DziennikElektronicznyContext, ListaObecnosci>
    {
        public ListaObecnosciRepo(DziennikElektronicznyContext context) : base(context)
        {
        }
    }
}

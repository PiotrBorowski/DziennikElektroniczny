﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.Repositories
{
    public class UsprawiedliwienieRepo : GenericRepository<DziennikElektronicznyContext, Usprawiedliwienie>
    {
        public UsprawiedliwienieRepo(DziennikElektronicznyContext context) : base(context)
        {
        }
    }
}
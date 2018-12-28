using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikElektroniczny.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DziennikElektroniczny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private DziennikElektronicznyContext _context;

        public StudentController(DziennikElektronicznyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Uczen> GetStudents()
        {
            return _context.Uczen.ToList();
        }
    }
}
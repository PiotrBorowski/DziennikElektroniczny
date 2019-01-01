using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DziennikElektroniczny.DTO;
using DziennikElektroniczny.Models;
using DziennikElektroniczny.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DziennikElektroniczny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private GenericRepository<DziennikElektronicznyContext, Uzytkownik> _repo;
        private IMapper _mapper;

        public AdminController(GenericRepository<DziennikElektronicznyContext, Uzytkownik> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("Users")]
        public List<Uzytkownik> GetAllUzytkownik()
        {
            return _repo.GetAll().ToList();
        }

        [HttpPost]
        public IActionResult AddUzytkownik(AddUzytkownikDTO addDto)
        {          
            _repo.Add(_mapper.Map<Uzytkownik>(addDto));
            return Ok();
        }
    }
}
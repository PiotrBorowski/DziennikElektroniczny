using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DziennikElektroniczny.DTO;
using DziennikElektroniczny.Models;
using DziennikElektroniczny.Repositories;
using DziennikElektroniczny.Services.AdminService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DziennikElektroniczny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("Uzytkownicy")]
        public List<Uzytkownik> GetAllUzytkownik()
        {
            return _adminService.GetAllUzytkownik();
        }

        [HttpGet("Klasy")]
        public List<Klasa> GetAllKlasa()
        {
            return _adminService.GetAllKlasa();
        }

        [HttpPost("dodajUzytkownika")]
        public IActionResult AddUzytkownik(AddUzytkownikDTO addDto)
        {          
            _adminService.AddUzytkownik(addDto);
            return Ok();
        }

        [HttpPost("dodajKlase")]
        public IActionResult AddKlasa(AddKlasaDTO addDto)
        {
            _adminService.AddKlasa(addDto);
            return Ok();
        }

        [HttpPost("dodajUcznia")]
        public IActionResult AddUczen(AddUczenDTO addDto)
        {
            _adminService.AddUczen(addDto);
            return Ok();
        }

        [HttpPost("dodajPrzedmiot")]
        public IActionResult AddSubject(AddPrzedmiotDTO addDto)
        {
            _adminService.AddPrzedmiot(addDto);
            return Ok();
        }

        [HttpPost("dodajJednostkeLekcyjna")]
        public IActionResult AddSubject(AddJednostkaLekcyjnaDTO addDto)
        {
            _adminService.AddJednostkaLekcyjna(addDto);
            return Ok();
        }
    }
}
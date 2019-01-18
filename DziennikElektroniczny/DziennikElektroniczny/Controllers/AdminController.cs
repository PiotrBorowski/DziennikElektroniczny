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
            return _adminService.GetAllUsers();
        }

        [HttpGet("Klasy")]
        public List<Klasa> GetAllKlasa()
        {
            return _adminService.GetAllClasses();
        }

        [HttpPost("dodajUzytkownika")]
        public IActionResult AddUzytkownik(AddUzytkownikDTO addDto)
        {
            try
            {
                _adminService.AddUser(addDto);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPost("dodajKlase")]
        public IActionResult AddKlasa(AddKlasaDTO addDto)
        {
            try
            {
                _adminService.AddClass(addDto);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("dodajUcznia")]
        public IActionResult AddUczen(AddUczenDTO addDto)
        {
            try
            {
                _adminService.AddStudent(addDto);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("dodajPrzedmiot")]
        public IActionResult AddSubject(AddPrzedmiotDTO addDto)
        {
            try
            {
                _adminService.AddSubject(addDto);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpPost("dodajJednostkeLekcyjna")]
        public IActionResult AddSubject(AddJednostkaLekcyjnaDTO addDto)
        {
            try
            {
                _adminService.AddSubjectUnit(addDto);
                return Ok();
            }
            catch
            {
                return BadRequest();

            }
        }
    }
}
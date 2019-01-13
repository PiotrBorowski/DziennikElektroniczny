using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikElektroniczny.DTO;
using DziennikElektroniczny.Models;
using DziennikElektroniczny.Services.UserService;
using DziennikElektroniczny.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DziennikElektroniczny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("WiadomosciWyslane")]
        public List<Wiadomosc> GetMessagesSend(int id)
        {
            return _userService.GetMessagesSend(id);
        }

        [HttpGet("WiadomosciOdebrane")]
        public List<Wiadomosc> GetMessagesOdebrane(int id)
        {
            return _userService.GetMessagesReceived(id);
        }

        [HttpGet("Oceny")]
        public List<OcenaViewModel> GetGrades(int id)
        {
            return _userService.GetGradeList(id);
        }

        [HttpGet("PlanLekcji")]
        public List<JednostkaLekcyjnaViewModel> GetLessonList(int id)
        {
            return _userService.GetJednostkaLekcyjnaList(id);
        }

        [HttpGet("Uwagi")]
        public List<Uwaga> GetSchoolNotes(int id)
        {
            return _userService.GetSchoolNotes(id);
        }

        [HttpGet("Obecnosci")]
        public List<Obecnosc> GetPresenceList(int id)
        {
            return _userService.GetSchoolPresenceList(id);
        }

        [HttpPost("dodajWiadomosc")]
        public IActionResult SendMessage(SendWiadomoscDTO addDto)
        {
            addDto.IdNadawcy = 2;
            _userService.SendMessage(addDto);
            return Ok();
        }
    }
}
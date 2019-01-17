using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikElektroniczny.DTO;
using DziennikElektroniczny.Models;
using DziennikElektroniczny.Services.TeacherService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DziennikElektroniczny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet("obecnoscUczniowie")]
        public List<Uzytkownik> GetStudents(int lessonId)
        {
            return _teacherService.GetAllStudentsPerLesson(lessonId);
        }

        [HttpGet("usprawiedliwienia")]
        public List<Usprawiedliwienie> GetExcuses(int parentId)
        {
            return _teacherService.GetAllExcusesPerParent(parentId);
        }

        [HttpPost("dodajOcene")]
        public IActionResult AddGrade(AddOcenaDTO addDto)
        {
            _teacherService.AddGrade(addDto);
            return Ok();
        }

        [HttpPost("dodajUwage")]
        public IActionResult AddSchoolNote(AddUwagaDTO addDto)
        {
            addDto.IdNauczyciela = 6;
            _teacherService.AddSchoolNote(addDto);
            return Ok();
        }

        [HttpPost("dodajLekcje")]
        public IActionResult AddLesson(AddLekcjaDTO addDto)
        {
            _teacherService.AddLesson(addDto);
            return Ok();
        }

        [HttpPost("dodajObecnosc")]
        public IActionResult AddSchoolPresence(AddObecnoscDTO addDto)
        {
            _teacherService.AddPresenceList(addDto);
            return Ok();
        }

        [HttpPost("akceptujUsprawiedliwienie")]
        public IActionResult AcceptExcuse(int id)
        {
            _teacherService.AcceptExcuse(id);
            return Ok();
        }

        [HttpPost("odrzucUsprawiedliwienie")]
        public IActionResult DiscardExcuse(int id)
        {
            _teacherService.DiscardExcuse(id);
            return Ok();
        }
    }
}
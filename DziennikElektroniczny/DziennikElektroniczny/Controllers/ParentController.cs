using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikElektroniczny.DTO;
using DziennikElektroniczny.Services.ParentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DziennikElektroniczny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private IParentService _parentService;

        public ParentController(IParentService parentService)
        {
            _parentService = parentService;
        }

        [HttpPost("dodajUsprawiedliwienie")]
        public IActionResult AddExcuse(AddUsprawiedliwienieDTO addDto)
        {
            addDto.IdRodzica = 3;
            _parentService.AddExcuse(addDto);
            return Ok();
        }
    }
}
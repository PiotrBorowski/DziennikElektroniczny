using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikElektroniczny.DTO;

namespace DziennikElektroniczny.Services.TeacherService
{
    public interface ITeacherService
    {
        void AddOcena(AddOcenaDTO addDto);
        void AddUwaga(AddUwagaDTO addDto);
        void AddLekcja(AddLekcjaDTO addDto);
        void AddObecnoscList(AddObecnoscDTO addDto);
    }
}

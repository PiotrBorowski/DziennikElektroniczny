using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikElektroniczny.DTO;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.Services.TeacherService
{
    public interface ITeacherService
    {
        void AddGrade(AddOcenaDTO addDto);
        void AddSchoolNote(AddUwagaDTO addDto);
        void AddLesson(AddLekcjaDTO addDto);
        void AddPresenceList(AddObecnoscDTO addDto);
        List<Uzytkownik> GetAllStudentsPerLesson(int id);
        List<Usprawiedliwienie> GetAllExcusesPerParent(int id);
        void AcceptExcuse(int id);
        void DiscardExcuse(int id);
    }
}

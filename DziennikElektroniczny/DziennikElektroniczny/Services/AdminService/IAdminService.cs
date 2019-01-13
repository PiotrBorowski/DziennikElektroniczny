using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikElektroniczny.DTO;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.Services.AdminService
{
    public interface IAdminService
    {
        List<Uzytkownik> GetAllUsers();
        List<Klasa> GetAllClasses();
        void AddUser(AddUzytkownikDTO addDto);
        void AddClass(AddKlasaDTO addDto);
        void AddStudent(AddUczenDTO addDto);
        void AddSubject(AddPrzedmiotDTO addDto);
        void AddSubjectUnit(AddJednostkaLekcyjnaDTO addDto);
    }
}

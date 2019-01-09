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
        List<Uzytkownik> GetAllUzytkownik();
        List<Klasa> GetAllKlasa();
        void AddUzytkownik(AddUzytkownikDTO addDto);
        void AddKlasa(AddKlasaDTO addDto);
        void AddUczen(AddUczenDTO addDto);
        void AddPrzedmiot(AddPrzedmiotDTO addDto);
        void AddJednostkaLekcyjna(AddJednostkaLekcyjnaDTO addDto);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DziennikElektroniczny.DTO;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.Automapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AddUzytkownikDTO,Uzytkownik>();
            CreateMap<AddKlasaDTO,Klasa >();
            CreateMap<AddUczenDTO, Uczen>();
            CreateMap<AddUczenDTO, Uzytkownik>();
            //CreateMap<, >();
        }
    }
}

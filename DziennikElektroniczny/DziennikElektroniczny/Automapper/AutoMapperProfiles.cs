using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DziennikElektroniczny.DTO;
using DziennikElektroniczny.Models;
using DziennikElektroniczny.ViewModels;

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
            CreateMap<AddPrzedmiotDTO, Przedmiot>();
            CreateMap<SendWiadomoscDTO, Wiadomosc>();
            CreateMap<JednostkaLekcyjna, JednostkaLekcyjnaViewModel>();
            CreateMap<AddOcenaDTO, Ocena>();
            CreateMap<AddObecnoscDTO, Obecnosc>();
            CreateMap<AddUwagaDTO, Uwaga>();
            CreateMap<AddLekcjaDTO, Lekcja>();
            CreateMap<AddUsprawiedliwienieDTO, Usprawiedliwienie>();
            CreateMap<AddJednostkaLekcyjnaDTO, JednostkaLekcyjna>();

            //CreateMap<, >();
        }
    }
}

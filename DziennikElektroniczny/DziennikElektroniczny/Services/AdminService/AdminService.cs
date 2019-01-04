using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DziennikElektroniczny.DTO;
using DziennikElektroniczny.Models;
using DziennikElektroniczny.Repositories;

namespace DziennikElektroniczny.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private GenericRepository<DziennikElektronicznyContext, Uzytkownik> _uzytkownikRepo;
        private GenericRepository<DziennikElektronicznyContext, Klasa> _klasaRepo;
        private GenericRepository<DziennikElektronicznyContext, Uczen> _uczenRepo;
        private IMapper _mapper;



        public AdminService
            (
            GenericRepository<DziennikElektronicznyContext, Uzytkownik> uzytkownikRepo,
            GenericRepository<DziennikElektronicznyContext, Klasa> klasaRepo,
            GenericRepository<DziennikElektronicznyContext, Uczen> uczenRepo,
            IMapper mapper

            )
        {
            _uzytkownikRepo = uzytkownikRepo;
            _klasaRepo = klasaRepo;
            _uczenRepo = uczenRepo;
            _mapper = mapper;
        }

        public List<Uzytkownik> GetAllUzytkownik()
        {
            return _uzytkownikRepo.GetAll().ToList();
        }

        public List<Klasa> GetAllKlasa()
        {
            return _klasaRepo.GetAll().ToList();
        }

        public void AddUzytkownik(AddUzytkownikDTO addDto)
        {
            _uzytkownikRepo.Add(_mapper.Map<Uzytkownik>(addDto));
        }

        public void AddKlasa(AddKlasaDTO addDto)
        {
            _klasaRepo.Add(_mapper.Map<Klasa>(addDto));
        }

        public void AddUczen(AddUczenDTO addDto)
        {
            _uzytkownikRepo.Add(_mapper.Map<Uzytkownik>(addDto));
            var uzytkownik = _uzytkownikRepo.GetAll().Last();
            var uczen = _mapper.Map<Uczen>(addDto);
            uczen.IdUzytkownika = uzytkownik.IdUzytkownika;
            _uczenRepo.Add(uczen);
        }
    }
}

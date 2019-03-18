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
        private IGenericRepository<Uzytkownik> _uzytkownikRepo;
        private IGenericRepository<Klasa> _klasaRepo;
        private IGenericRepository<Uczen> _uczenRepo;
        private IMapper _mapper;
        private IGenericRepository<PlanLekcji> _planLekcjiRepo;
        private IGenericRepository<Przedmiot> _przedmiotRepo;
        private IGenericRepository<JednostkaLekcyjna> _jednostkaLekcyjnaRepo;


        public AdminService
            (
            IGenericRepository<Uzytkownik> uzytkownikRepo,
            IGenericRepository< Klasa> klasaRepo,
            IGenericRepository<Uczen> uczenRepo,
            IGenericRepository<PlanLekcji> planLekcjiRepo,
            IGenericRepository<Przedmiot> przedmiotRepo,
            IGenericRepository<JednostkaLekcyjna> jednostkaLekcyjnaRepo,



            IMapper mapper

            )
        {
            _uzytkownikRepo = uzytkownikRepo;
            _klasaRepo = klasaRepo;
            _uczenRepo = uczenRepo;
            _planLekcjiRepo = planLekcjiRepo;
            _przedmiotRepo = przedmiotRepo;
            _jednostkaLekcyjnaRepo = jednostkaLekcyjnaRepo;
            _mapper = mapper;
        }

        public List<Uzytkownik> GetAllUsers()
        {
            return _uzytkownikRepo.GetAll().ToList();
        }

        public List<Klasa> GetAllClasses()
        {
            return _klasaRepo.GetAll().ToList();
        }

        public void AddUser(AddUzytkownikDTO addDto)
        {
            _uzytkownikRepo.Add(_mapper.Map<Uzytkownik>(addDto));
        }

        public void AddClass(AddKlasaDTO addDto)
        {
            _klasaRepo.Add(_mapper.Map<Klasa>(addDto));
            _planLekcjiRepo.Add(new PlanLekcji{IdKlasy = _klasaRepo.GetAll().Last().IdKlasy});
        }

        public void AddStudent(AddUczenDTO addDto)
        {
            _uzytkownikRepo.Add(_mapper.Map<Uzytkownik>(addDto));
            var uzytkownik = _uzytkownikRepo.GetAll().Last();
            var uczen = _mapper.Map<Uczen>(addDto);
            uczen.IdUzytkownika = uzytkownik.IdUzytkownika;
            _uczenRepo.Add(uczen);
        }

        public void AddSubject(AddPrzedmiotDTO addDto)
        {
            _przedmiotRepo.Add(_mapper.Map<Przedmiot>(addDto));
        }

        public void AddSubjectUnit(AddJednostkaLekcyjnaDTO addDto)
        {
            _jednostkaLekcyjnaRepo.Add(_mapper.Map<JednostkaLekcyjna>(addDto));
        }
    }
}

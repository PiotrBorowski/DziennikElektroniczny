using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DziennikElektroniczny.DTO;
using DziennikElektroniczny.Models;
using DziennikElektroniczny.Repositories;

namespace DziennikElektroniczny.Services.TeacherService
{
    public class TeacherService : ITeacherService
    {
        private GenericRepository<DziennikElektronicznyContext, Ocena> _ocenaRepo;
        private GenericRepository<DziennikElektronicznyContext, Uwaga> _uwagaRepo;
        private GenericRepository<DziennikElektronicznyContext, Lekcja> _lekcjaRepo;
        private GenericRepository<DziennikElektronicznyContext, Obecnosc> _obecnoscRepo;
        private GenericRepository<DziennikElektronicznyContext, ListaObecnosci> _listaObecnosciRepo;


        private IMapper _mapper;

        public TeacherService(
            GenericRepository<DziennikElektronicznyContext, Ocena> ocenaRepo,
            GenericRepository<DziennikElektronicznyContext, Uwaga> uwagaRepo,
         GenericRepository<DziennikElektronicznyContext, Lekcja> lekcjaRepo,
        GenericRepository<DziennikElektronicznyContext, Obecnosc> obecnoscRepo,
         GenericRepository<DziennikElektronicznyContext, ListaObecnosci> listaObecnosciRepo,
        IMapper mapper)
        {
            _ocenaRepo = ocenaRepo;
            _uwagaRepo = uwagaRepo;
            _lekcjaRepo = lekcjaRepo;
            _obecnoscRepo = obecnoscRepo;
            _listaObecnosciRepo = listaObecnosciRepo;
            _mapper = mapper;
        }

        public void AddGrade(AddOcenaDTO addDto)
        {
            _ocenaRepo.Add(_mapper.Map<Ocena>(addDto));
        }

        public void AddSchoolNote(AddUwagaDTO addDto)
        {
            _uwagaRepo.Add(_mapper.Map<Uwaga>(addDto));
        }

        public void AddLesson(AddLekcjaDTO addDto)
        {
            _lekcjaRepo.Add(_mapper.Map<Lekcja>(addDto));
            _listaObecnosciRepo.Add(new ListaObecnosci
            {
                IdLekcji = _lekcjaRepo.GetAll().Last().IdLekcji
            });
        }

        public void AddPresenceList(AddObecnoscDTO addDto)
        {
            _obecnoscRepo.Add(_mapper.Map<Obecnosc>(addDto));
        }
    }
}

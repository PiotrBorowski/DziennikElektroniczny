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
        private GenericRepository<DziennikElektronicznyContext, PlanLekcji> _planLekcjiRepo;
        private GenericRepository<DziennikElektronicznyContext, Klasa> _klasaRepo;
        private GenericRepository<DziennikElektronicznyContext, JednostkaLekcyjna> _jednostkaLekcyjnaRepo;
        private GenericRepository<DziennikElektronicznyContext, Uzytkownik> _uzytkownikRepo;
        private GenericRepository<DziennikElektronicznyContext, Uczen> _uczenRepo;
        private GenericRepository<DziennikElektronicznyContext, Usprawiedliwienie> _usprawiedliwienieRepo;





        private IMapper _mapper;

        public TeacherService(GenericRepository<DziennikElektronicznyContext, Ocena> ocenaRepo,
            GenericRepository<DziennikElektronicznyContext, Uwaga> uwagaRepo,
            GenericRepository<DziennikElektronicznyContext, Lekcja> lekcjaRepo,
            GenericRepository<DziennikElektronicznyContext, Obecnosc> obecnoscRepo,
            GenericRepository<DziennikElektronicznyContext, ListaObecnosci> listaObecnosciRepo,
            GenericRepository<DziennikElektronicznyContext, PlanLekcji> planLekcjiRepo,
            GenericRepository<DziennikElektronicznyContext, Klasa> klasaRepo,
            GenericRepository<DziennikElektronicznyContext, JednostkaLekcyjna> jednostkaLekcyjnaRepo,
            GenericRepository<DziennikElektronicznyContext, Uzytkownik> uzytkownikRepo,
            GenericRepository<DziennikElektronicznyContext, Uczen> uczenRepo,
            IMapper mapper, GenericRepository<DziennikElektronicznyContext, Usprawiedliwienie> usprawiedliwienieRepo)
        {
            _ocenaRepo = ocenaRepo;
            _uwagaRepo = uwagaRepo;
            _lekcjaRepo = lekcjaRepo;
            _obecnoscRepo = obecnoscRepo;
            _listaObecnosciRepo = listaObecnosciRepo;
            _planLekcjiRepo = planLekcjiRepo;
            _klasaRepo = klasaRepo;
            _jednostkaLekcyjnaRepo = jednostkaLekcyjnaRepo;
            _uzytkownikRepo = uzytkownikRepo;
            _uczenRepo = uczenRepo;
            _usprawiedliwienieRepo = usprawiedliwienieRepo;
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

        public List<Uzytkownik> GetAllStudentsPerLesson(int id)
        {
            var lesson = _lekcjaRepo.FindBy(x => x.IdLekcji == id).Single();

            var subjectUnit = _jednostkaLekcyjnaRepo.FindBy(x => x.IdJednostkiLekcyjnej == lesson.IdJednostkiLekcyjnej)
                .Single();

            var plan = _planLekcjiRepo.FindBy(x => x.IdPlanuLekcji == subjectUnit.IdPlanuLekcji).Single();

            var schoolClass = _klasaRepo.FindBy(x => x.IdKlasy == plan.IdKlasy).Single();

            var students = _uczenRepo.FindBy(x => x.IdKlasy == schoolClass.IdKlasy);

            //List<Uzytkownik> users = new List<Uzytkownik>();
            //foreach (var student in students)
            //{
            //    users.Add(_uzytkownikRepo.FindBy(x => x.IdUzytkownika == student.IdUzytkownika).Single());
            //}

            return students.Select(x => x.IdUzytkownikaNavigation).ToList();
        }

        public List<Usprawiedliwienie> GetAllExcusesPerParent(int id)
        {
            return _usprawiedliwienieRepo.FindBy(x => x.IdRodzica == id).ToList();
        }

        public void AcceptExcuse(int id)
        {
            var excuse = _usprawiedliwienieRepo.FindBy(x => x.IdUsprawiedliwienie == id).FirstOrDefault();
            excuse.CzyZatwierdzone = true;
            _usprawiedliwienieRepo.Edit(excuse);
        }

        public void DiscardExcuse(int id)
        {
            var excuse = _usprawiedliwienieRepo.FindBy(x => x.IdUsprawiedliwienie == id).FirstOrDefault();
            excuse.CzyZatwierdzone = false;
            _usprawiedliwienieRepo.Edit(excuse);
        }
    }
}

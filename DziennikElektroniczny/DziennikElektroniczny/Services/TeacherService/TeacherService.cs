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
        private IGenericRepository< Ocena> _ocenaRepo;
        private IGenericRepository< Uwaga> _uwagaRepo;
        private IGenericRepository< Lekcja> _lekcjaRepo;
        private IGenericRepository< Obecnosc> _obecnoscRepo;
        private IGenericRepository< ListaObecnosci> _listaObecnosciRepo;
        private IGenericRepository< PlanLekcji> _planLekcjiRepo;
        private IGenericRepository< Klasa> _klasaRepo;
        private IGenericRepository< JednostkaLekcyjna> _jednostkaLekcyjnaRepo;
        private IGenericRepository< Uzytkownik> _uzytkownikRepo;
        private IGenericRepository< Uczen> _uczenRepo;
        private IGenericRepository< Usprawiedliwienie> _usprawiedliwienieRepo;





        private IMapper _mapper;

        public TeacherService(IGenericRepository< Ocena> ocenaRepo,
            IGenericRepository< Uwaga> uwagaRepo,
            IGenericRepository< Lekcja> lekcjaRepo,
            IGenericRepository< Obecnosc> obecnoscRepo,
            IGenericRepository< ListaObecnosci> listaObecnosciRepo,
            IGenericRepository< PlanLekcji> planLekcjiRepo,
            IGenericRepository< Klasa> klasaRepo,
            IGenericRepository< JednostkaLekcyjna> jednostkaLekcyjnaRepo,
            IGenericRepository< Uzytkownik> uzytkownikRepo,
            IGenericRepository< Uczen> uczenRepo,
            IMapper mapper, IGenericRepository< Usprawiedliwienie> usprawiedliwienieRepo)
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

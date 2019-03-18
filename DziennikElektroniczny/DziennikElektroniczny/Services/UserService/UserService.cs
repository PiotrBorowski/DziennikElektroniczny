using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using AutoMapper;
using DziennikElektroniczny.DTO;
using DziennikElektroniczny.Models;
using DziennikElektroniczny.Repositories;
using DziennikElektroniczny.ViewModels;

namespace DziennikElektroniczny.Services.UserService
{
    public class UserService : IUserService
    {
        private IGenericRepository<Wiadomosc> _wiadomoscRepo;
        private IGenericRepository<Uwaga> _uwagaRepo;
        private IGenericRepository<Lekcja> _lekcjaRepo;
        private IGenericRepository<Obecnosc> _obecnoscRepo;
        private IGenericRepository<ListaObecnosci> _listaObecnosciRepo;
        private IGenericRepository<Ocena> _ocenaRepo;
        private IGenericRepository<JednostkaLekcyjna> _jednostkaLekcyjnaRepo;
        private IGenericRepository<Uczen> _uczenRepo;
        private IGenericRepository<PlanLekcji> _planLekcjiRepo;
        private IGenericRepository<Przedmiot> _przedmiotRepo;
        private IMapper _mapper;



        public UserService
            (
            IGenericRepository<Wiadomosc> wiadomoscRepo,
            IGenericRepository<Uwaga> uwagaRepo,
            IGenericRepository<Ocena> ocenaRepo,
            IGenericRepository<JednostkaLekcyjna> jednostkaLekcyjnaRepo,
            IGenericRepository<Uczen> uczenRepo,
            IGenericRepository<PlanLekcji> planLekcjiRepo,
            IGenericRepository<Przedmiot> przedmiotRepo,
            IGenericRepository<Lekcja> lekcjaRepo,
            IGenericRepository<Obecnosc> obecnoscRepo,
            IGenericRepository<ListaObecnosci> listaObecnosciRepo,
        IMapper mapper

            )
        {
            _wiadomoscRepo = wiadomoscRepo;
            _uwagaRepo = uwagaRepo;
            _obecnoscRepo = obecnoscRepo;
            _ocenaRepo = ocenaRepo;
            _jednostkaLekcyjnaRepo = jednostkaLekcyjnaRepo;
            _uczenRepo = uczenRepo;
            _planLekcjiRepo = planLekcjiRepo;
            _przedmiotRepo = przedmiotRepo;
            _lekcjaRepo = lekcjaRepo;
            _listaObecnosciRepo = listaObecnosciRepo;
            _mapper = mapper;
        }

        public List<Wiadomosc> GetMessagesSend(int userId)
        {
            return _wiadomoscRepo.GetAll().Where(x => x.IdNadawcy == userId).ToList();
        }

        public List<Wiadomosc> GetMessagesReceived(int userId)
        {
            return _wiadomoscRepo.GetAll().Where(x => x.IdOdbiorcy == userId).ToList();
        }

        public List<Uwaga> GetSchoolNotes(int userId)
        {
            return _uwagaRepo.GetAll().Where(x => x.IdUcznia == userId).ToList();
        }

        public List<ObecnoscViewModel> GetSchoolPresenceList(int userId)
        {
            var presences = _obecnoscRepo.GetAll().Where(x => x.IdUcznia == userId).ToList();

            List<ObecnoscViewModel> viewModels = new List<ObecnoscViewModel>();
            foreach (var item in presences)
            {
                var presenceList = _listaObecnosciRepo.FindBy(l => l.IdListy == item.IdListy).First();

                var lesson = _lekcjaRepo.FindBy(lekcja =>                   
                   presenceList.IdLekcji == lekcja.IdLekcji).First();
              

                var hour = _jednostkaLekcyjnaRepo.FindBy(j => j.IdJednostkiLekcyjnej == lesson.IdJednostkiLekcyjnej)
                    .First().Godzina;

                viewModels.Add(new ObecnoscViewModel
                {
                    CzyObecny = item.CzyObecny,
                    Data = lesson.Data,
                    Godzina = hour
                });
            }

            return viewModels;
        }

        public List<OcenaViewModel> GetGradeList(int userId)
        {
            var ocenaList = _ocenaRepo.GetAll().Where(x => x.IdUcznia == userId).ToList();

            var ocenaViewModelList = ocenaList.Select(x => new OcenaViewModel
            {
                Przedmiot = _przedmiotRepo.FindBy(y => y.IdPrzedmiotu == x.IdPrzedmiotu).First().Nazwa,
                KategoriaOceny = x.IdKategoriiOceny,
                Wartosc = x.Wartosc
            }).ToList();

            return ocenaViewModelList;
        }

        public List<JednostkaLekcyjnaViewModel> GetJednostkaLekcyjnaList(int userId)
        {
            var classId = _uczenRepo.FindBy(x => x.IdUzytkownika == userId).First().IdKlasy;
            var lessonListId = _planLekcjiRepo.FindBy(x => x.IdKlasy == classId).First().IdPlanuLekcji;

            var lessonList = _jednostkaLekcyjnaRepo.GetAll().Where(x => x.IdPlanuLekcji == lessonListId).ToList();

            var viewModel = lessonList.Select(x =>
                new JednostkaLekcyjnaViewModel
                {
                    Przedmiot = _przedmiotRepo.FindBy(p => p.IdPrzedmiotu == x.IdPrzedmiotu).First().Nazwa,
                    Godzina = x.Godzina,
                    DzienTygodnia = x.DzienTygodnia,
                    Sala = x.Sala
                }).ToList();

            return viewModel;
        }

        public void SendMessage(SendWiadomoscDTO addDto)
        {
            _wiadomoscRepo.Add(_mapper.Map<Wiadomosc>(addDto));
        }
    }
}

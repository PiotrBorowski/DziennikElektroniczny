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
        private GenericRepository<DziennikElektronicznyContext, Wiadomosc> _wiadomoscRepo;
        private GenericRepository<DziennikElektronicznyContext, Uwaga> _uwagaRepo;
        private GenericRepository<DziennikElektronicznyContext, Obecnosc> _obecnoscRepo;
        private GenericRepository<DziennikElektronicznyContext, Ocena> _ocenaRepo;
        private GenericRepository<DziennikElektronicznyContext, JednostkaLekcyjna> _jednostkaLekcyjnaRepo;
        private GenericRepository<DziennikElektronicznyContext, Uczen> _uczenRepo;
        private GenericRepository<DziennikElektronicznyContext, PlanLekcji> _planLekcjiRepo;
        private GenericRepository<DziennikElektronicznyContext, Przedmiot> _przedmiotRepo;
        private IMapper _mapper;



        public UserService
            (
            GenericRepository<DziennikElektronicznyContext,Wiadomosc> wiadomoscRepo,
            GenericRepository<DziennikElektronicznyContext, Uwaga> uwagaRepo,
            GenericRepository<DziennikElektronicznyContext, Obecnosc> obecnoscRepo,
            GenericRepository<DziennikElektronicznyContext, Ocena> ocenaRepo,
            GenericRepository<DziennikElektronicznyContext, JednostkaLekcyjna> jednostkaLekcyjnaRepo,
            GenericRepository<DziennikElektronicznyContext, Uczen> uczenRepo,
            GenericRepository<DziennikElektronicznyContext, PlanLekcji> planLekcjiRepo,
            GenericRepository<DziennikElektronicznyContext, Przedmiot> przedmiotRepo,
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

        public List<Obecnosc> GetSchoolPresenceList(int userId)
        {
            return _obecnoscRepo.GetAll().Where(x => x.IdUcznia == userId).ToList();
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

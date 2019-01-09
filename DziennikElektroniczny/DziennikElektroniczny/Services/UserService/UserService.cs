using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using DziennikElektroniczny.Models;
using DziennikElektroniczny.Repositories;

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



        public UserService
            (
            GenericRepository<DziennikElektronicznyContext,Wiadomosc> wiadomoscRepo,
            GenericRepository<DziennikElektronicznyContext, Uwaga> uwagaRepo,
            GenericRepository<DziennikElektronicznyContext, Obecnosc> obecnoscRepo,
            GenericRepository<DziennikElektronicznyContext, Ocena> ocenaRepo,
            GenericRepository<DziennikElektronicznyContext, JednostkaLekcyjna> jednostkaLekcyjnaRepo,
            GenericRepository<DziennikElektronicznyContext, Uczen> uczenRepo,
            GenericRepository<DziennikElektronicznyContext, PlanLekcji> planLekcjiRepo


            )
        {
            _wiadomoscRepo = wiadomoscRepo;
            _uwagaRepo = uwagaRepo;
            _obecnoscRepo = obecnoscRepo;
            _ocenaRepo = ocenaRepo;
            _jednostkaLekcyjnaRepo = jednostkaLekcyjnaRepo;
            _uczenRepo = uczenRepo;
            _planLekcjiRepo = planLekcjiRepo;
        }

        public List<Wiadomosc> GetMessages(int userId)
        {
            return _wiadomoscRepo.GetAll().Where(x => x.IdNadawcy == userId || x.IdOdbiorcy == userId).ToList();
        }

        public List<Uwaga> GetSchoolNotes(int userId)
        {
            return _uwagaRepo.GetAll().Where(x => x.IdUcznia == userId).ToList();
        }

        public List<Obecnosc> GetSchoolPresenceList(int userId)
        {
            return _obecnoscRepo.GetAll().Where(x => x.IdUcznia == userId).ToList();
        }

        public List<Ocena> GetGradeList(int userId)
        {
            return _ocenaRepo.GetAll().Where(x => x.IdUcznia == userId).ToList();
        }

        public List<JednostkaLekcyjna> GetJednostkaLekcyjnaList(int userId)
        {
            var classId = _uczenRepo.FindBy(x => x.IdUzytkownika == userId).First().IdKlasy;
            var lessonListId = _planLekcjiRepo.FindBy(x => x.IdKlasy == classId).First().IdPlanuLekcji;
            return _jednostkaLekcyjnaRepo.GetAll().Where(x => x.IdPlanuLekcji == lessonListId).ToList();
        }
    }
}

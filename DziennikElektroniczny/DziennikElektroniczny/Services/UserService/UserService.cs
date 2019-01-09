using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.Services.UserService
{
    public class UserService : IUserService
    {
        public List<Wiadomosc> GetMessages(int userId)
        {
            throw new NotImplementedException();
        }

        public List<Uwaga> GetSchoolNotes(int userId)
        {
            throw new NotImplementedException();
        }

        public List<Obecnosc> GetSchoolPresenceList(int userId)
        {
            throw new NotImplementedException();
        }

        public List<Ocena> GetGradeList(int userId)
        {
            throw new NotImplementedException();
        }

        public List<JednostkaLekcyjna> GetJednostkaLekcyjnaList(int userId)
        {
            throw new NotImplementedException();
        }
    }
}

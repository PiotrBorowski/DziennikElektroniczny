﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DziennikElektroniczny.Models;

namespace DziennikElektroniczny.Services.UserService
{
    interface IUserService
    {
        List<Wiadomosc> GetMessages(int userId);
        List<Uwaga> GetSchoolNotes(int userId);
        List<Obecnosc> GetSchoolPresenceList(int userId);
        List<Ocena> GetGradeList(int userId);
        List<JednostkaLekcyjna> GetJednostkaLekcyjnaList(int userId);

    }
}

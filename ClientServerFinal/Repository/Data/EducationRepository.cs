﻿using Server.Data;
using Server.Models;
using Server.Repository;
using Server.Repository.Contracts;

namespace ClientServerFinal.Repository.Data
{
    public class EducationRepository : GeneralRepository<Education, int, MyContext>, IEducationRepository
    {
        public EducationRepository(MyContext context) : base(context)
        {
        }
    }
}

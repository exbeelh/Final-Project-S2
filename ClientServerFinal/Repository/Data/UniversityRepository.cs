using Server.Data;
using Server.Models;
using Server.Repository;
using Server.Repository.Contracts;

namespace ClientServerFinal.Repository.Data
{
    public class UniversityRepository : GeneralRepository<University, int, MyContext>, IUniversityRepository
    {
        public UniversityRepository(MyContext context) : base(context)
        {
        }
    }
}

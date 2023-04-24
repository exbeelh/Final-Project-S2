using ClientServerFinal.Data;
using ClientServerFinal.Models;
using ClientServerFinal.Repository;
using ClientServerFinal.Repository.Contracts;

namespace ClientServerFinal.Repository.Data
{
    public class EducationRepository : GeneralRepository<Education, int, MyContext>, IEducationRepository
    {
        public EducationRepository(MyContext context) : base(context)
        {
        }
    }
}

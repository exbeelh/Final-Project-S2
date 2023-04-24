using Server.Data;
using Server.Models;
using Server.Repository;
using Server.Repository.Contracts;

namespace Server.Repository.Data;

public class ProfilingRepository : GeneralRepository<Profiling, string, MyContext>, IProfilingRepository
{
    public ProfilingRepository(MyContext context) : base(context)
    {
    }
}

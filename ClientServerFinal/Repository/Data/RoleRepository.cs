using Server.Data;
using Server.Models;
using Server.Repository;
using Server.Repository.Contracts;

namespace Server.Repository.Data;

public class RoleRepository : GeneralRepository<Role, int, MyContext>, IRoleRepository
{
    public RoleRepository(MyContext context) : base(context)
    {
    }
}

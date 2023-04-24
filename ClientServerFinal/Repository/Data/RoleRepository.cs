using ClientServerFinal.Data;
using ClientServerFinal.Models;
using ClientServerFinal.Repository;
using ClientServerFinal.Repository.Contracts;

namespace ClientServerFinal.Repository.Data;

public class RoleRepository : GeneralRepository<Role, int, MyContext>, IRoleRepository
{
    public RoleRepository(MyContext context) : base(context)
    {
    }
}

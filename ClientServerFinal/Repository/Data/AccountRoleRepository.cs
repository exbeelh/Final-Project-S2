using Server.Data;
using Server.Models;
using Server.Repository;
using Server.Repository.Contracts;

namespace Server.Repository.Data;

public class AccountRoleRepository : GeneralRepository<AccountRole, int, MyContext>, IAccountRoleRepository
{
    public AccountRoleRepository(MyContext context) : base(context)
    {
    }
}

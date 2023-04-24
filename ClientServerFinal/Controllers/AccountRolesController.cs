using Microsoft.AspNetCore.Mvc;
using Server.Base;
using Server.Models;
using Server.Repository.Contracts;

namespace ClientServerFinal.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountRolesController : BaseController<IAccountRoleRepository, AccountRole, int>
    {
        public AccountRolesController(IAccountRoleRepository repository) : base(repository)
        {
        }
    }
}

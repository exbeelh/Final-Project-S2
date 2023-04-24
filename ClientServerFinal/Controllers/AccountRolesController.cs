using Microsoft.AspNetCore.Mvc;
using ClientServerFinal.Base;
using ClientServerFinal.Models;
using ClientServerFinal.Repository.Contracts;

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

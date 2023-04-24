using Microsoft.AspNetCore.Mvc;
using Server.Base;
using Server.Models;
using Server.Repository.Contracts;

namespace Server.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RolesController : BaseController<IRoleRepository, Role, int>
{
    public RolesController(IRoleRepository repository) : base(repository)
    {
    }
}

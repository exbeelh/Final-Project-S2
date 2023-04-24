using Microsoft.AspNetCore.Mvc;
using ClientServerFinal.Base;
using ClientServerFinal.Models;
using ClientServerFinal.Repository.Contracts;

namespace ClientServerFinal.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RolesController : BaseController<IRoleRepository, Role, int>
{
    public RolesController(IRoleRepository repository) : base(repository)
    {
    }
}

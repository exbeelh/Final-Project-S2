using Microsoft.AspNetCore.Mvc;
using Server.Repository.Contracts;
using Server.Models;
using Server.Base;
using Microsoft.AspNetCore.Authorization;

namespace Server.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize(Roles = "User")]
public class UniversitiesController : BaseController<IUniversityRepository, University, int>
{
    public UniversitiesController(IUniversityRepository repository) : base(repository)
    {
    }
}

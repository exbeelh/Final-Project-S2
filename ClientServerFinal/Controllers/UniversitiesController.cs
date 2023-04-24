using Microsoft.AspNetCore.Mvc;
using ClientServerFinal.Repository.Contracts;
using ClientServerFinal.Models;
using ClientServerFinal.Base;
using Microsoft.AspNetCore.Authorization;

namespace ClientServerFinal.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize(Roles = "User")]
public class UniversitiesController : BaseController<IUniversityRepository, University, int>
{
    public UniversitiesController(IUniversityRepository repository) : base(repository)
    {
    }
}

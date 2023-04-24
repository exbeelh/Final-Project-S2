using Microsoft.AspNetCore.Mvc;
using ClientServerFinal.Base;
using ClientServerFinal.Models;
using ClientServerFinal.Repository.Contracts;

namespace ClientServerFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilingsController : BaseController<IProfilingRepository, Profiling, string>
    {
        public ProfilingsController(IProfilingRepository repository) : base(repository)
        {
        }
    }
}

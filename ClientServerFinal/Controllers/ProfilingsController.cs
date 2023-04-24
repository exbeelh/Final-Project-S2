using Microsoft.AspNetCore.Mvc;
using Server.Base;
using Server.Models;
using Server.Repository.Contracts;

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

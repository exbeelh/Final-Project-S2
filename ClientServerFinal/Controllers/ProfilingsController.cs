using Microsoft.AspNetCore.Mvc;
using ClientServerFinal.Base;
using ClientServerFinal.Models;
using ClientServerFinal.Repository.Contracts;
using ClientServerFinal.ViewModels;
using System.Net;

namespace ClientServerFinal.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProfilingsController : BaseController<IProfilingRepository, Profiling, string>
    {
        public ProfilingsController(IProfilingRepository repository) : base(repository)
        {
        }

        [HttpGet("WorkPeriod")]
        public async Task<ActionResult<IEnumerable<EmployeeProfileVM>>> WorkPeriod()
        {
            try
            {
                var entity = await _repository.GetEmployeesByLengthOfWorkDescending();
                return Ok(new
                {
                    code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    data = entity
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        code = StatusCodes.Status500InternalServerError,
                        status = HttpStatusCode.InternalServerError.ToString(),
                        Errors = new
                        {
                            message = "Internal server error."
                        }
                    });
            }
        }

        [HttpGet("TotalByMajor")]
        public async Task<ActionResult<IEnumerable<EmployeeProfileVM>>> TotalByMajor()
        {
            try
            {
                var entity = await _repository.GetEmployeesTotalByMajorAndUniversity();
                return Ok(new
                {
                    code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    data = entity
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        code = StatusCodes.Status500InternalServerError,
                        status = HttpStatusCode.InternalServerError.ToString(),
                        Errors = new
                        {
                            message = "Internal server error."
                        }
                    });
            }
        }

        [HttpGet("AvgGPA/{year:int}")]
        public async Task<ActionResult<IEnumerable<EmployeeProfileVM>>> AvgByYear(int year)
        {
            try
            {
                var entity = await _repository.GetEmployeesAboveAvgGPAByMajorAndUniversity(year);
                return Ok(new
                {
                    code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    data = entity
                });

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        code = StatusCodes.Status500InternalServerError,
                        status = HttpStatusCode.InternalServerError.ToString(),
                        Errors = new
                        {
                            message = "Internal server error."
                        }
                    });
            }
        }
    }
}

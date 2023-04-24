﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ClientServerFinal.Base;
using ClientServerFinal.Models;
using ClientServerFinal.Repository.Contracts;
using System.Net;
using System.Security.Claims;

namespace ClientServerFinal.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController<IEmployeeRepository, Employee, string>
    {
        public EmployeesController(IEmployeeRepository repository) : base(repository)
        {
        }

        [Authorize]
        [HttpGet("Master")]
        public async Task<IActionResult> Master()
        {
            try
            {
                var email = User.FindFirst(ClaimTypes.Email)?.Value;

                var employeeData = await _repository.GetEmployeeDataByEmailAsync(email!);

                if (employeeData == null)
                {
                    return NotFound();
                }

                return Ok(new
                {
                    code = StatusCodes.Status200OK,
                    status = HttpStatusCode.OK.ToString(),
                    data = employeeData
                });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    code = StatusCodes.Status500InternalServerError,
                    status = HttpStatusCode.InternalServerError.ToString(),
                    message = "Internal Server Error"
                });
            }
        }
    }
}

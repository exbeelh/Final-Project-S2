using Microsoft.AspNetCore.Mvc;
using Server.Base;
using Server.Models;
using Server.ViewModels;
using Server.Repository.Contracts;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace Server.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AccountsController : BaseController<IAccountRepository, Account, string>
{
    public AccountsController(IAccountRepository repository) : base(repository)
    {
    }

    [HttpPost("Register")]
    [AllowAnonymous]
    public async Task<ActionResult> Register(RegisterVM registerVM)
    {
        try
        {
            var result = await _repository.Register(registerVM);

            if (result == 0)
            {
                return Conflict(new
                {
                    code = StatusCodes.Status409Conflict,
                    status = HttpStatusCode.Conflict.ToString(),
                    message = "Data fail to Insert!"
                });
            }

            return Ok(new
            {
                code = StatusCodes.Status200OK,
                status = HttpStatusCode.OK.ToString(),
                message = "Register Succesfully!"
            });
        }
        catch
        {
            return BadRequest(new
            {
                code = StatusCodes.Status400BadRequest,
                status = HttpStatusCode.BadRequest.ToString(),
                message = "Something Wrong!"
            });
        }
    }
}

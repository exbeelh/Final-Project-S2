using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Base;
using Server.Models;
using Server.Repository.Contracts;
using System.Data;
using System.Net;

namespace ClientServerFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationsController : BaseController<IEducationRepository, Education, int>
    {
        public EducationsController(IEducationRepository repository) : base(repository)
        {
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public override async Task<IActionResult> PostAsync([FromBody] Education education)
        {
            try
            {
                await _repository.InsertAsync(education);
                return CreatedAtAction(nameof(GetAsync), new { id = GetAsync() }, education);
            }
            catch
            {
                return BadRequest(new
                {
                    code = StatusCodes.Status400BadRequest,
                    status = HttpStatusCode.BadRequest.ToString(),
                    message = "Input Error"
                });
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public override async Task<IActionResult> PutAsync(int id, [FromBody] Education employee)
        {
            try
            {
                if (id!.Equals(employee.GetType().GetProperty("Id")) ||
                    id.Equals(employee.GetType().GetProperty("Nik")))
                {
                    return BadRequest(new
                    {
                        code = StatusCodes.Status400BadRequest,
                        status = HttpStatusCode.BadRequest.ToString(),
                        message = "ID and NIK not same"
                    });
                }

                await _repository.UpdateAsync(employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound(new
                {
                    code = StatusCodes.Status404NotFound,
                    status = HttpStatusCode.NotFound.ToString(),
                    message = "Data Not Found."
                });
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public override async Task<IActionResult> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound(new
                {
                    code = StatusCodes.Status404NotFound,
                    status = HttpStatusCode.NotFound.ToString(),
                    message = "Data Not Found."
                });
            }

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}

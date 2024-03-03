using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskMenagment.Application.AuthServices;
using TaskMenagment.Domain.Entities.DataTransferObject;

namespace TaskMennagment.API.Controllers.NewIdentity
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<string>> Login(ProgrammerDTO model)
        {
            try
            {
                var result = await _authService.GenerateToken(model);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
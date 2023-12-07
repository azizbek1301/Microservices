using Authtorisation.Api.Dtos;
using Authtorisation.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Authtorisation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthServices _tokenGenerator;

        public AuthController(AuthServices tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        public async ValueTask<IActionResult> Login(LoginDto login)
        {
            var token = _tokenGenerator.GenerateToken(login);
            return Ok(token);
        }
    }
}

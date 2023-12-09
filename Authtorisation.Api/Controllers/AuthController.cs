using Authtorisation.Api.Data;
using Authtorisation.Api.Dtos;
using Authtorisation.Api.Model;
using Authtorisation.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Authtorisation.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthServices _tokenGenerator;
        private readonly AppDbContext _context;

        public AuthController(AuthServices tokenGenerator, AppDbContext context)
        {
            _tokenGenerator = tokenGenerator;
            _context = context;
        }

        [HttpPost]
        public async ValueTask<IActionResult> Login(LoginDTO login)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == login.UserName && x.Password == login.Password);
            if(user == null) {
                return NotFound("User topilmadi");
            }

            var userDTO = new UserDTO()
            {
                Role = user.Role,
                UserName = user.UserName,
            };

            var token = _tokenGenerator.GenerateToken(userDTO);
            return Ok(token);
        }

        [HttpPost]
        public async ValueTask<IActionResult> Register(User user)
        {
            _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var userDTO = new UserDTO()
            {
                Role = user.Role,
                UserName = user.UserName,
            };
            var token = _tokenGenerator.GenerateToken(userDTO);

            return Ok(token);
        }
    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ticketing.Api.Services;
using Ticketing.Application.Contract.Authentication.DTOs;
using Ticketing.Application.Contract.Authentication.Services;

namespace Ticketing.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(IAuthenticationService _service,IConfiguration configuration) : Controller
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginDTO login)
        {
            var userInfo =await _service.Authenticate(login.Email, login.Password);
            var token = TokenGeneration.GenerateJwtToken(userInfo, configuration);
            return Ok(new { token });
        }
        [HttpPost("admin-register")]
        public async Task AdminRegister([FromBody] RegisterDTO item)
        {
            await _service.AdminRegister(item);
        }
        [HttpPost("employee-register")]
        public async Task EmployeeRegister([FromBody] RegisterDTO item)
        {
            await _service.EmployeeRegister(item);

        }
    }
}

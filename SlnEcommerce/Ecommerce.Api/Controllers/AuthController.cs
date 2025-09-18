using Ecommerce.Api.Auth.Service;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Api.Auth.Models;

namespace Ecommerce.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                var token = TokenService.GenerateToken(new AuthModel());
                return Ok(token);
            }

            return BadRequest("username or password invalid");
        }
    }
}

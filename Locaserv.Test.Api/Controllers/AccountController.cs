using Locaserv.Test.Api.Configurations;
using Microsoft.AspNetCore.Mvc;

namespace Locaserv.Test.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class AccountController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(new { Uuid = Guid.NewGuid(), user.UserName });
        }

        [HttpGet("loggout")]
        public IActionResult Logout()
        {
            return Ok();
        }
    }
}
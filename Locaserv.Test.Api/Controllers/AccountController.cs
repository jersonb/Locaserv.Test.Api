using Locaserv.Test.Api.Configurations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Locaserv.Test.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiKey]
    public class AccountController : ControllerBase
    {
        private static ApiConfig apiConfig;

        public AccountController(IOptions<ApiConfig> options)
        {
            apiConfig = options.Value;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
        }

        [HttpGet("auth")]
        public IActionResult Auth()
        {
            return Ok();
        }

        [HttpGet("allow")]
        public IActionResult Allow()
        {
            return Ok();
        }

        [HttpGet("loggout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}
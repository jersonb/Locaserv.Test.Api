using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Locaserv.Test.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await SetLoggedInUser(user);
            
            return Ok();
        }

        [HttpGet("auth")]
        [Authorize]
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

        private async Task SetLoggedInUser(User user)
        {
            var principal = GetClaimsPrincipal(user);

            var properties = SetRememberMe(user.RememberMe);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, properties);
        }

        private static AuthenticationProperties SetRememberMe(bool remember)
        {
            var properties = new AuthenticationProperties
            {
                IsPersistent = remember
            };
            return properties;
        }

        private static ClaimsPrincipal GetClaimsPrincipal(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Expired, "NO"),
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Name, user.UserName),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            return principal;
        }
    }
}
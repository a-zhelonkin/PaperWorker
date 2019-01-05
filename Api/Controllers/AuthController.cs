using Api.Models;
using Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        [Route("verify-token")]
        public IActionResult VerifyToken() => Ok();

        [AllowAnonymous]
        [HttpPost]
        [Route("token")]
        public IActionResult Token([FromBody] AuthDto authDto)
        {
            var token = TokenGenerator.GetToken(authDto.Email, authDto.Password);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new {token});
        }
    }
}
using System.Threading.Tasks;
using Api.Models;
using Auth;
using Core;
using Database;
using Database.Extensions;
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

        [AllowAnonymous]
        [HttpPost]
        [Route("restore-password")]
        public async Task<IActionResult> RestorePassword([FromBody] string email)
        {
            using (var context = new PaperWorkerDbContext())
            {
                var user = context.GetUser(email);
                if (user == null)
                {
                    return BadRequest();
                }

                user.Status = UserStatus.Restoring;
                context.Users.Update(user);
                await context.SaveChangesAsync();

                return Ok();
            }
        }
    }
}
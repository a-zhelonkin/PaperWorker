using System.Threading.Tasks;
using Api.Extensions;
using Auth;
using Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [Authorize]
        [HttpPut]
        [Route("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] string password)
        {
            using (var context = new PaperWorkerDbContext())
            {
                var user = this.GetUser(context);
                if (user == null)
                {
                    return Unauthorized();
                }

                user.Password = password.ToHash();
                context.Users.Update(user);
                await context.SaveChangesAsync();

                return Ok();
            }
        }
    }
}
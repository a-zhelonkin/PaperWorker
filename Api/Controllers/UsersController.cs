using System.Linq;
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
        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new PaperWorkerDbContext())
            {
                return Ok(context.Users.ToList());
            }
        }
    }
}
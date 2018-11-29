using System.Linq;
using Api.Models;
using Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/roles")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            using (var context = new PaperWorkerDbContext())
            {
                return Ok(context.Roles.Select(role => new Role
                {
                    Id = role.Id,
                    Name = role.Name
                }).ToList());
            }
        }
    }
}
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Api.Models;
using Auth;
using Core;
using Database;
using Database.Extensions;
using Database.Models;
using Database.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize(Roles = nameof(RoleName.Admin))]
    [Route("api/invites")]
    [ApiController]
    public class InvitesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var email = HttpContext.User.FindFirst(ClaimsIdentity.DefaultNameClaimType)?.Value;
            if (email == null)
            {
                return Unauthorized();
            }

            using (var context = new PaperWorkerDbContext())
            {
                var user = context.GetUser(email);
                if (user == null)
                {
                    return Unauthorized();
                }

                return Ok(user.Status);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InviteDto invite)
        {
            using (var context = new PaperWorkerDbContext())
            {
                var userId = Guid.NewGuid();

                await context.AddUser(new User
                {
                    Id = userId,
                    Email = invite.Email,
                    Password = Guid.NewGuid().ToString().ToHash(),
                    Status = UserStatus.Prepared,
                    Roles = invite.Roles.Select(roleName => new UserRole
                    {
                        UserId = userId,
                        RoleId = roleName.GetId()
                    }).ToArray(),
                    Profile = new Profile
                    {
                        UserId = userId,
                        EmploymentDateTime = DateTime.Now
                    }
                });

                return Ok(new {userId});
            }
        }
    }
}
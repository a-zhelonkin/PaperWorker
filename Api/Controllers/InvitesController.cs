using System;
using System.Linq;
using System.Security.Claims;
using Api.Models;
using Auth;
using Core;
using Database;
using Database.Models;
using Database.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize(Roles = nameof(RoleName.Admin))]
    [Route("api/invites")]
    [ApiController]
    public class InvitesController : DbController
    {
        public InvitesController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet]
        public IActionResult Get()
        {
            var email = HttpContext.User.FindFirst(ClaimsIdentity.DefaultNameClaimType)?.Value;
            if (email == null)
            {
                return Unauthorized();
            }

            var user = UnitOfWork.UserRepository.Get(email);
            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(user.Status);
        }

        [HttpPost]
        public IActionResult Post([FromBody] InviteDto invite)
        {
            var userId = Guid.NewGuid();

            UnitOfWork.UserRepository.Add(new User
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
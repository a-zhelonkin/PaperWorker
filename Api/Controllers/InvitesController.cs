using System;
using System.Linq;
using Api.Extensions;
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
    public class InvitesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public InvitesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("get-status")]
        public IActionResult GetStatus()
        {
            var email = this.GetEmail();
            if (email == null)
            {
                return Unauthorized();
            }

            var user = _unitOfWork.UserRepository.Get(email);
            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(user.Status);
        }

        [HttpPost]
        [Route("invite")]
        public IActionResult Invite([FromBody] InviteDto invite)
        {
            var userId = Guid.NewGuid();

            _unitOfWork.UserRepository.Add(new User
            {
                Id = userId,
                Email = invite.Email,
                Password = Guid.NewGuid().ToString().ToSha256(),
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

            _unitOfWork.Save();

            return Ok(new {userId});
        }
    }
}
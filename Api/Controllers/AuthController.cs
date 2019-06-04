using System;
using Api.Extensions;
using Api.Models.Account;
using Auth;
using Core;
using Database;
using Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthController(IUnitOfWork unitOfWork,
                              ITokenGenerator tokenGenerator)
        {
            _unitOfWork = unitOfWork;
            _tokenGenerator = tokenGenerator;
        }

        [Authorize]
        [HttpGet]
        [Route("verify-token")]
        public IActionResult VerifyToken() => Ok();

        [Authorize]
        [HttpGet]
        [Route("email")]
        public IActionResult Email()
        {
            var email = this.GetEmail();
            if (email == null)
            {
                return Unauthorized();
            }

            var user = _unitOfWork.UserRepository.GetWithRoles(email);
            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(new AuthInfoDto
            {
                Email = email,
                Roles = user.GetRoleNames()
            });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("token")]
        public IActionResult Token([FromBody] AuthDto authDto)
        {
            var token = _tokenGenerator.GetToken(authDto.Email, authDto.Password);
            if (token == null)
            {
                return Unauthorized();
            }

            var user = _unitOfWork.UserRepository.GetWithRoles(authDto.Email);
            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(new AuthInfoDto
            {
                Token = token,
                Email = authDto.Email,
                Roles = user.GetRoleNames()
            });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("restore-password")]
        public IActionResult RestorePassword([FromBody] string email)
        {
            var user = _unitOfWork.UserRepository.Get(email);
            if (user == null)
            {
                return BadRequest();
            }

            _unitOfWork.EmailMessagesRepository.Add(new EmailMessage
            {
                UserId = user.Id,
                Type = MessageType.RestoreRequest
            });
            _unitOfWork.Save();

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("send-auth-link")]
        public IActionResult SendAuthLink([FromBody] string email)
        {
            var user = _unitOfWork.UserRepository.Get(email);
            if (user == null)
            {
                return BadRequest();
            }

            _unitOfWork.EmailMessagesRepository.Add(new EmailMessage
            {
                UserId = user.Id,
                Type = MessageType.AuthLinkRequest
            });
            _unitOfWork.Save();

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] string email)
        {
            throw new NotImplementedException();
        }
    }
}
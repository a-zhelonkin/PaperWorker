using Api.Models;
using Auth;
using Core;
using Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : DbController
    {
        private readonly ITokenGenerator _tokenGenerator;

        public AuthController(IUnitOfWork unitOfWork,
                              ITokenGenerator tokenGenerator) : base(unitOfWork)
        {
            _tokenGenerator = tokenGenerator;
        }

        [Authorize]
        [HttpGet]
        [Route("verify-token")]
        public IActionResult VerifyToken() => Ok();

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

            return Ok(new {token});
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("restore-password")]
        public IActionResult RestorePassword([FromBody] string email)
        {
            var user = UnitOfWork.UserRepository.Get(email);
            if (user == null)
            {
                return BadRequest();
            }

            user.Status = UserStatus.Restoring;
            UnitOfWork.UserRepository.Update(user);

            return Ok();
        }
    }
}
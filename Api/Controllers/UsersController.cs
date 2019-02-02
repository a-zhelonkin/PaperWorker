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
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        [HttpPut]
        [Route("change-password")]
        public IActionResult ChangePassword([FromBody] string password)
        {
            var email = this.GetEmail();
            if (email == null)
            {
                return Unauthorized();
            }

            var userRepository = _unitOfWork.UserRepository;
            var user = userRepository.Get(email);
            if (user == null)
            {
                return Unauthorized();
            }

            user.Password = password.ToSha256();
            userRepository.Update(user);
            _unitOfWork.Save();

            return Ok();
        }
    }
}
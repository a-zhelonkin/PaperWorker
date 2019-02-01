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
    public class UsersController : DbController
    {
        public UsersController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
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

            var userRepository = UnitOfWork.UserRepository;
            var user = userRepository.Get(email);
            if (user == null)
            {
                return Unauthorized();
            }

            user.Password = password.ToHash();
            userRepository.Update(user);
            UnitOfWork.Save();

            return Ok();
        }
    }
}
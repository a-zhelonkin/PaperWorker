using System.Linq;
using Api.Extensions;
using Api.Models.Account;
using Auth;
using Core;
using Database;
using Database.Models.Account;
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
        private readonly IMapper<User, UserDto> _userDtoMapper;

        public UsersController(IUnitOfWork unitOfWork,
                               IMapper<User, UserDto> userDtoMapper)
        {
            _unitOfWork = unitOfWork;
            _userDtoMapper = userDtoMapper;
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
            var user = userRepository.GetWithRoles(email);
            if (user == null)
            {
                return Unauthorized();
            }

            user.Password = password.ToSha256();
            userRepository.Update(user);
            _unitOfWork.Save();

            return Ok(new AuthInfoDto
            {
                Email = email,
                Roles = user.GetRoleNames()
            });
        }

        [Authorize(Roles = nameof(RoleName.Admin))]
        [HttpGet]
        public IActionResult Get([FromQuery] int start, [FromQuery] int size)
        {
            return Ok(_unitOfWork.UserRepository
                                 .Get(start, size)
                                 .Select(_userDtoMapper.Map)
                                 .ToArray());
        }
    }
}
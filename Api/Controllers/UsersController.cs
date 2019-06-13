using System.Linq;
using Api.Models.Account;
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
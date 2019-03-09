using System;
using Api.Models;
using Database;
using Database.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Core;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/profiles")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Profile, ProfileDto> _profileDtoMapper;
        private readonly IMapper<ProfileDto, Profile> _dtoProfileMapper;

        public ProfilesController(IUnitOfWork unitOfWork,
                                  IMapper<Profile, ProfileDto> profileDtoMapper,
                                  IMapper<ProfileDto, Profile> dtoProfileMapper)
        {
            _unitOfWork = unitOfWork;
            _profileDtoMapper = profileDtoMapper;
            _dtoProfileMapper = dtoProfileMapper;
        }

        [HttpGet("{userId}")]
        public IActionResult Get([FromQuery] Guid userId)
        {
            var profile = _unitOfWork.ProfilesRepository.Get(userId);

            return Ok(_profileDtoMapper.Map(profile));
        }

        [HttpPut]
        public IActionResult Put([FromBody] ProfileDto profileDto)
        {
            _unitOfWork.ProfilesRepository.Update(_dtoProfileMapper.Map(profileDto));
            _unitOfWork.Save();

            return Ok();
        }
    }
}
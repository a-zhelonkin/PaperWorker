using System;
using Api.Mappers;
using Api.Models;
using Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/profiles")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfilesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{userId}")]
        public IActionResult Get([FromQuery] Guid userId)
        {
            return Ok(_unitOfWork.ProfilesRepository.Get(userId).Map());
        }

        [HttpPut]
        public IActionResult Put([FromBody] ProfileDto profileDto)
        {
            _unitOfWork.ProfilesRepository.Update(profileDto.Map());
            _unitOfWork.Save();

            return Ok();
        }
    }
}
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
    public class ProfilesController : DbController
    {
        public ProfilesController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpGet("{userId}")]
        public IActionResult Get([FromQuery] Guid userId)
        {
            return Ok(UnitOfWork.ProfilesRepository.GetProfile(userId).Map());
        }

        [HttpPut]
        public IActionResult Put([FromBody] ProfileDto profileDto)
        {
            UnitOfWork.ProfilesRepository.UpdateProfile(profileDto.Map());
            UnitOfWork.Save();

            return Ok();
        }
    }
}
using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Mappers;
using Api.Models;
using Database;
using Database.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/profiles")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        [HttpGet("{userId}")]
        public IActionResult Get([FromQuery] Guid userId)
        {
            using (var context = new PaperWorkerDbContext())
            {
                return Ok(context.Profiles
                    .Select(ProfileMapper.Map)
                    .FirstOrDefault(profile => profile.UserId == userId)
                );
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProfileDto profileDto)
        {
            using (var context = new PaperWorkerDbContext())
            {
                await context.UpdateProfile(profileDto.Map());
            }

            return Ok();
        }
    }
}
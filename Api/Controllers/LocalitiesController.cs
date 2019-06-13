using System;
using System.Linq;
using Api.Models.Account;
using Core;
using Database;
using Database.Models.Addressing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/localities")]
    [ApiController]
    public class LocalitiesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Locality, LocalityDto> _localityDtoMapper;

        public LocalitiesController(IUnitOfWork unitOfWork,
                                    IMapper<Locality, LocalityDto> localityDtoMapper)
        {
            _unitOfWork = unitOfWork;
            _localityDtoMapper = localityDtoMapper;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] Guid territoryId)
        {
            return Ok(_unitOfWork.LocalitiesRepository.GetByTerritoryId(territoryId).Select(_localityDtoMapper.Map));
        }

        [HttpPost]
        public IActionResult Post([FromBody] LocalityDto dto)
        {
            var localitiesRepository = _unitOfWork.LocalitiesRepository;
            if (localitiesRepository.Exists(dto.TerritoryId, dto.Name))
            {
                return BadRequest();
            }

            var locality = new Locality
            {
                TerritoryId = dto.TerritoryId,
                Name = dto.Name
            };

            localitiesRepository.Add(locality);
            _unitOfWork.Save();

            return Ok(_localityDtoMapper.Map(locality));
        }
    }
}
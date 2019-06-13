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
    [Route("api/territories")]
    [ApiController]
    public class TerritoriesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Territory, TerritoryDto> _territoryDtoMapper;

        public TerritoriesController(IUnitOfWork unitOfWork,
                                     IMapper<Territory, TerritoryDto> territoryDtoMapper)
        {
            _unitOfWork = unitOfWork;
            _territoryDtoMapper = territoryDtoMapper;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] Guid id)
        {
            var territory = _unitOfWork.TerritoriesRepository.Get(id);
            var dto = _territoryDtoMapper.Map(territory);

            return Ok(dto);
        }

        [HttpGet]
        [Route("getByParentId")]
        public IActionResult GetByParentId([FromQuery] Guid? parentId)
        {
            var territoryDtos = _unitOfWork.TerritoriesRepository
                                           .GetByParentId(parentId)
                                           .Select(_territoryDtoMapper.Map)
                                           .ToArray();

            return Ok(territoryDtos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TerritoryDto dto)
        {
            var territoriesRepository = _unitOfWork.TerritoriesRepository;
            if (dto.ParentId.HasValue && territoriesRepository.Exists(dto.ParentId.Value, dto.Name))
            {
                return BadRequest();
            }

            var territory = new Territory
            {
                ParentId = dto.ParentId,
                Name = dto.Name
            };

            territoriesRepository.Add(territory);
            _unitOfWork.Save();

            return Ok(_territoryDtoMapper.Map(territory));
        }
    }
}
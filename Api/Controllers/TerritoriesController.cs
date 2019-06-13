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
        public IActionResult Get([FromQuery] Guid? parentId = null)
        {
            return Ok(parentId.HasValue
                          ? _unitOfWork.TerritoriesRepository.GetByParentId(parentId.Value).Select(_territoryDtoMapper.Map)
                          : _unitOfWork.TerritoriesRepository.Get().Select(_territoryDtoMapper.Map)
            );
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
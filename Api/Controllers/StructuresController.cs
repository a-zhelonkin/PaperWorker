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
    [Route("api/structures")]
    [ApiController]
    public class StructuresController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Structure, StructureDto> _structureDtoMapper;

        public StructuresController(IUnitOfWork unitOfWork,
                                    IMapper<Structure, StructureDto> structureDtoMapper)
        {
            _unitOfWork = unitOfWork;
            _structureDtoMapper = structureDtoMapper;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] Guid id)
        {
            return Ok(_structureDtoMapper.Map(_unitOfWork.StructuresRepository.Get(id)));
        }

        [HttpGet]
        [Route("getByStreetId")]
        public IActionResult GetByStreetId([FromQuery] Guid streetId)
        {
            return Ok(_unitOfWork.StructuresRepository.GetByStreetId(streetId).Select(_structureDtoMapper.Map));
        }

        [HttpPost]
        public IActionResult Post([FromBody] StructureDto dto)
        {
            var structuresRepository = _unitOfWork.StructuresRepository;
            if (structuresRepository.Exists(dto.StreetId, dto.Number))
            {
                return BadRequest();
            }

            var structure = new Structure
            {
                StreetId = dto.StreetId,
                Number = dto.Number,
                Alone = dto.Alone
            };

            structuresRepository.Add(structure);
            _unitOfWork.Save();

            return Ok(_structureDtoMapper.Map(structure));
        }
    }
}
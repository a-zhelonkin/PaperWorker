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
    [Route("api/streets")]
    [ApiController]
    public class StreetsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Street, StreetDto> _streetDtoMapper;

        public StreetsController(IUnitOfWork unitOfWork,
                                 IMapper<Street, StreetDto> streetDtoMapper)
        {
            _unitOfWork = unitOfWork;
            _streetDtoMapper = streetDtoMapper;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] Guid id)
        {
            return Ok(_streetDtoMapper.Map(_unitOfWork.StreetsRepository.Get(id)));
        }

        [HttpGet]
        [Route("getLocalityId")]
        public IActionResult GetByLocalityId([FromQuery] Guid localityId)
        {
            return Ok(_unitOfWork.StreetsRepository.GetByLocalityId(localityId).Select(_streetDtoMapper.Map));
        }

        [HttpPost]
        public IActionResult Post([FromBody] StreetDto dto)
        {
            var streetsRepository = _unitOfWork.StreetsRepository;
            if (streetsRepository.Exists(dto.LocalityId, dto.Name))
            {
                return BadRequest();
            }

            var street = new Street
            {
                LocalityId = dto.LocalityId,
                Name = dto.Name
            };

            streetsRepository.Add(street);
            _unitOfWork.Save();

            return Ok(_streetDtoMapper.Map(street));
        }
    }
}
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
    [Route("api/addresses")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<Address, AddressDto> _addressDtoMapper;

        public AddressesController(IUnitOfWork unitOfWork,
                                   IMapper<Address, AddressDto> addressDtoMapper)
        {
            _unitOfWork = unitOfWork;
            _addressDtoMapper = addressDtoMapper;
        }

        [HttpGet]
        public IActionResult GetAddresses([FromQuery] Guid structureId)
        {
            return Ok(_unitOfWork.AddressesRepository.GetByStructureId(structureId).Select(_addressDtoMapper.Map));
        }

        [HttpPost]
        public IActionResult PostAddress([FromBody] AddressDto dto)
        {
            var structure = _unitOfWork.StructuresRepository.Get(dto.StructureId);
            if (structure.Alone)
            {
                return BadRequest();
            }

            var addressesRepository = _unitOfWork.AddressesRepository;
            if (addressesRepository.Exists(dto.StructureId, dto.Number))
            {
                return BadRequest();
            }

            var address = new Address
            {
                StructureId = dto.StructureId,
                Number = dto.Number
            };

            addressesRepository.Add(address);
            _unitOfWork.Save();

            return Ok(_addressDtoMapper.Map(address));
        }
    }
}
using System.Linq;
using Api.Models.Account;
using Core;
using Database.Models.Addressing;

namespace Api.Mappers
{
    public class StructureDtoMapper : IMapper<Structure, StructureDto>
    {
        private readonly IMapper<Address, AddressDto> _addressDtoMapper;

        public StructureDtoMapper(IMapper<Address, AddressDto> addressDtoMapper)
        {
            _addressDtoMapper = addressDtoMapper;
        }

        public StructureDto Map(Structure source) => source == null
            ? null
            : new StructureDto
            {
                Id = source.Id,
                Number = source.Number,
                Alone = source.Alone,
                StreetId = source.StreetId,
                Addresses = source.Addresses?.Select(_addressDtoMapper.Map).ToArray()
            };
    }
}
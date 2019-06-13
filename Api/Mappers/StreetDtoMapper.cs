using System.Linq;
using Api.Models.Account;
using Core;
using Database.Models.Addressing;

namespace Api.Mappers
{
    public class StreetDtoMapper : IMapper<Street, StreetDto>
    {
        private readonly IMapper<Structure, StructureDto> _structureDtoMapper;

        public StreetDtoMapper(IMapper<Structure, StructureDto> structureDtoMapper)
        {
            _structureDtoMapper = structureDtoMapper;
        }

        public StreetDto Map(Street source) => source == null
            ? null
            : new StreetDto
            {
                Id = source.Id,
                Name = source.Name,
                LocalityId = source.LocalityId,
                Structures = source.Structures?.Select(_structureDtoMapper.Map).ToArray()
            };
    }
}
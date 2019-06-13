using System.Linq;
using Api.Models.Account;
using Core;
using Database.Models.Addressing;

namespace Api.Mappers
{
    public class LocalityDtoMapper : IMapper<Locality, LocalityDto>
    {
        private readonly IMapper<Street, StreetDto> _streetDroMapper;

        public LocalityDtoMapper(IMapper<Street, StreetDto> streetDroMapper)
        {
            _streetDroMapper = streetDroMapper;
        }

        public LocalityDto Map(Locality source) => source == null
            ? null
            : new LocalityDto
            {
                Id = source.Id,
                Name = source.Name,
                TerritoryId = source.TerritoryId,
                Streets = source.Streets?.Select(_streetDroMapper.Map).ToArray()
            };
    }
}
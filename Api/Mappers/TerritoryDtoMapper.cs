using System.Linq;
using Api.Models.Account;
using Core;
using Database.Models.Addressing;

namespace Api.Mappers
{
    public class TerritoryDtoMapper : IMapper<Territory, TerritoryDto>
    {
        private readonly IMapper<Locality, LocalityDto> _localityDtoMapper;

        public TerritoryDtoMapper(IMapper<Locality, LocalityDto> localityDtoMapper)
        {
            _localityDtoMapper = localityDtoMapper;
        }

        public TerritoryDto Map(Territory source) => source == null
            ? null
            : new TerritoryDto
            {
                Id = source.Id,
                Name = source.Name,
                ParentId = source.ParentId,
                Localities = source.Localities?.Select(_localityDtoMapper.Map).ToArray(),
                Children = source.Children?.Select(Map).ToArray()
            };
    }
}
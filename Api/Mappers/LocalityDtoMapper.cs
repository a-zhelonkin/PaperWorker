using Api.Models.Account;
using Core;
using Database.Models.Addressing;

namespace Api.Mappers
{
    public class LocalityDtoMapper : IMapper<Locality, LocalityDto>
    {
        public LocalityDto Map(Locality source) => new LocalityDto
        {
            Id = source.Id,
            Name = source.Name,
            TerritoryId = source.TerritoryId
        };
    }
}
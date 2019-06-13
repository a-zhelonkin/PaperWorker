using Api.Models.Account;
using Core;
using Database.Models.Addressing;

namespace Api.Mappers
{
    public class TerritoryDtoMapper : IMapper<Territory, TerritoryDto>
    {
        public TerritoryDto Map(Territory source) => new TerritoryDto
        {
            Id = source.Id,
            Name = source.Name,
            ParentId = source.ParentId
        };
    }
}
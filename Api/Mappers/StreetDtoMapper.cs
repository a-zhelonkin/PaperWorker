using Api.Models.Account;
using Core;
using Database.Models.Addressing;

namespace Api.Mappers
{
    public class StreetDtoMapper : IMapper<Street, StreetDto>
    {
        public StreetDto Map(Street source) => new StreetDto
        {
            Id = source.Id,
            Name = source.Name,
            LocalityId = source.LocalityId
        };
    }
}
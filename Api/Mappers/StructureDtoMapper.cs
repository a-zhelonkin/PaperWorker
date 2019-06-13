using Api.Models.Account;
using Core;
using Database.Models.Addressing;

namespace Api.Mappers
{
    public class StructureDtoMapper : IMapper<Structure, StructureDto>
    {
        public StructureDto Map(Structure source) => new StructureDto
        {
            Id = source.Id,
            Number = source.Number,
            StreetId = source.StreetId
        };
    }
}
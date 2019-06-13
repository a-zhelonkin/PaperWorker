using Api.Models.Account;
using Core;
using Database.Models.Addressing;

namespace Api.Mappers
{
    public class AddressDtoMapper : IMapper<Address, AddressDto>
    {
        public AddressDto Map(Address source) => new AddressDto
        {
            Number = source.Number,
            StructureId = source.StructureId
        };
    }
}
using Api.Models;
using Core;
using Database.Models;

namespace Api.Mappers
{
    public class ProfileDtoMapper : IMapper<Profile, ProfileDto>
    {
        public ProfileDto Map(Profile source) => source == null
            ? null
            : new ProfileDto
            {
                FirstName = source.FirstName,
                LastName = source.LastName,
                Patronymic = source.Patronymic,
                PhoneNumber = source.PhoneNumber
            };
    }
}
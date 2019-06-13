using Api.Models;
using Core;
using Database.Models;

namespace Api.Mappers
{
    public class DtoProfileMapper : IMapper<ProfileDto, Profile>
    {
        public Profile Map(ProfileDto source) => source == null
            ? null
            : new Profile
            {
                FirstName = source.FirstName,
                LastName = source.LastName,
                Patronymic = source.Patronymic,
                PhoneNumber = source.PhoneNumber
            };
    }
}
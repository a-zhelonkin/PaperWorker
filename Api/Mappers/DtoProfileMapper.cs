using Api.Models;
using Core;
using Database.Models;

namespace Api.Mappers
{
    public class DtoProfileMapper : IMapper<ProfileDto, Profile>
    {
        public Profile Map(ProfileDto profile) => new Profile
        {
            FirstName = profile.FirstName,
            LastName = profile.LastName,
            Patronymic = profile.Patronymic,
            PhoneNumber = profile.PhoneNumber
        };
    }
}
using Api.Models;
using Database.Models;
using Core;

namespace Api.Mappers
{
    public class DtoProfileMapper : IMapper<ProfileDto, Profile>
    {
        public Profile Map(ProfileDto profile) => new Profile
        {
            FirstName = profile.FirstName,
            LastName = profile.LastName,
            Patronymic = profile.Patronymic,
            BirthDateTime = profile.BirthDateTime,
            EmploymentDateTime = profile.EmploymentDateTime
        };
    }
}
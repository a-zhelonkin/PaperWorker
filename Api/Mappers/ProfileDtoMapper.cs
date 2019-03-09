using Api.Models;
using Core;
using Database.Models;

namespace Api.Mappers
{
    public class ProfileDtoMapper : IMapper<Profile, ProfileDto>
    {
        public ProfileDto Map(Profile profile) => new ProfileDto
        {
            FirstName = profile.FirstName,
            LastName = profile.LastName,
            Patronymic = profile.Patronymic,
            BirthDateTime = profile.BirthDateTime,
            EmploymentDateTime = profile.EmploymentDateTime
        };
    }
}
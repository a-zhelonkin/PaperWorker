using Api.Models;
using Database.Models;

namespace Api.Mappers
{
    public static class ProfileMapper
    {
        public static ProfileDto Map(this Profile profile) => new ProfileDto
        {
            FirstName = profile.FirstName,
            LastName = profile.LastName,
            Patronymic = profile.Patronymic,
            BirthDateTime = profile.BirthDateTime,
            EmploymentDateTime = profile.EmploymentDateTime
        };

        public static Profile Map(this ProfileDto profileDto) => new Profile
        {
            FirstName = profileDto.FirstName,
            LastName = profileDto.LastName,
            Patronymic = profileDto.Patronymic,
            BirthDateTime = profileDto.BirthDateTime,
            EmploymentDateTime = profileDto.EmploymentDateTime
        };
    }
}
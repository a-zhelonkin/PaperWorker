using System.Linq;
using Api.Models;
using Core;
using Database.Models.Account;

namespace Api.Mappers
{
    public class UserDtoMapper : IMapper<User, UserDto>
    {
        public UserDto Map(User user) => new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            Status = user.Status,
            Roles = user.Roles.Select(x => x.Role.Name).ToArray(),
            FirstName = user.Profile?.FirstName,
            LastName = user.Profile?.LastName,
            Patronymic = user.Profile?.Patronymic,
            BirthDateTime = user.Profile?.BirthDateTime,
            EmploymentDateTime = user.Profile?.EmploymentDateTime
        };
    }
}
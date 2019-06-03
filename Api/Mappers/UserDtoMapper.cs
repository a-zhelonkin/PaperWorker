using System.Linq;
using Api.Models;
using Api.Models.Account;
using Core;
using Database.Models;
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
            FirstName = user.Profile.FirstName,
            LastName = user.Profile.LastName,
            Patronymic = user.Profile.Patronymic,
            PhoneNumber = user.Profile.PhoneNumber
        };
    }
}
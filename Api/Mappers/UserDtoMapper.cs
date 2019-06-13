using System.Linq;
using Api.Models.Account;
using Core;
using Database.Models.Account;

namespace Api.Mappers
{
    public class UserDtoMapper : IMapper<User, UserDto>
    {
        public UserDto Map(User source) => source == null
            ? null
            : new UserDto
            {
                Id = source.Id,
                Email = source.Email,
                Status = source.Status,
                Roles = source.Roles?.Select(x => x.Role.Name).ToArray(),
                FirstName = source.Profile.FirstName,
                LastName = source.Profile.LastName,
                Patronymic = source.Profile.Patronymic,
                PhoneNumber = source.Profile.PhoneNumber
            };
    }
}
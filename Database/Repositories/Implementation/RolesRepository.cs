using System.Linq;
using Core;
using Database.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories.Implementation
{
    public class RolesRepository : IRolesRepository
    {
        private readonly DbSet<Role> _roles;

        public RolesRepository(DbSet<Role> roles)
        {
            _roles = roles;
        }

        public void Add(Role role)
        {
            _roles.Add(role);
        }

        public bool Exists(RoleName roleName)
        {
            return _roles.Any(role => role.Name == roleName);
        }
    }
}
using System;
using System.Linq;
using Core;
using Database.Models.Account;

namespace Database.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly PaperWorkerDbContext _context;

        public RolesRepository(PaperWorkerDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddRole(Role role)
        {
            _context.Roles.Add(role);
        }

        public bool ExistsRole(RoleName roleName)
        {
            return _context.Roles.Any(role => role.Name == roleName);
        }
    }
}
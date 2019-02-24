using Core;
using Database.Models.Account;

namespace Database.Repositories
{
    public interface IRolesRepository
    {
        void Add(Role role);
        bool Exists(RoleName roleName);
    }
}
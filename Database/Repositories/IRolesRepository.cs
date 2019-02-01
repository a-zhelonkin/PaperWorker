using Core;
using Database.Models.Account;

namespace Database.Repositories
{
    public interface IRolesRepository
    {
        void AddRole(Role role);

        bool ExistsRole(RoleName roleName);
    }
}
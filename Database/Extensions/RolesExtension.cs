using System.Threading.Tasks;
using Core;
using Database.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace Database.Extensions
{
    public static class RolesExtension
    {
        public static async Task AddRole(this PaperWorkerDbContext context, Role role)
        {
            context.Roles.Add(role);
            await context.SaveChangesAsync();
        }

        public static async Task<bool> ExistsRole(this PaperWorkerDbContext context, RoleName roleName)
        {
            return await context.Roles.AnyAsync(role => role.Name == roleName);
        }
    }
}
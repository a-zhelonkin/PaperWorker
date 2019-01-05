using System.Linq;
using System.Threading.Tasks;
using Database.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace Database.Extensions
{
    public static class UsersExtension
    {
        public static async Task AddUser(this PaperWorkerDbContext context, User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
        }

        public static User GetUser(this PaperWorkerDbContext context, string email)
        {
            return context.Users.SingleOrDefault(x => x.Email == email);
        }

        public static User GetUserRoles(this PaperWorkerDbContext context, string email)
        {
            return context.Users
                .Include(x => x.Roles)
                .ThenInclude(x => x.Role)
                .SingleOrDefault(x => x.Email == email);
        }
    }
}
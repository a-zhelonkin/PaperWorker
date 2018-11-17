using Database.Models.Account;

namespace Database.Extensions
{
    public static class UsersExtension
    {
        public static void Add(this PaperWorkerDbContext context, User user)
        {
            context.Users.Add(user);
        }
    }
}
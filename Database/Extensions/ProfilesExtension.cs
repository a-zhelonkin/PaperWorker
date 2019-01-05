using System.Threading.Tasks;
using Database.Models;

namespace Database.Extensions
{
    public static class ProfilesExtension
    {
        public static async Task UpdateProfile(this PaperWorkerDbContext context, Profile profile)
        {
            context.Profiles.Update(profile);
            await context.SaveChangesAsync();
        }
    }
}